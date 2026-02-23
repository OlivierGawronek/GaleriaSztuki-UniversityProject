using Microsoft.Reporting.WinForms;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace GaleriaSztuki
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadDziela();
            this.reportViewer1.RefreshReport();
        }


        private void LoadUsers(string filter = "")
        {
            try
            {
                string sql = "SELECT id_klienta, imie || ' ' || nazwisko AS display_name FROM klient";
                if (!string.IsNullOrEmpty(filter))
                {
                    sql += " WHERE imie ILIKE @filter OR nazwisko ILIKE @filter";
                }
                sql += " ORDER BY nazwisko, imie";

                NpgsqlParameter[] p = null;
                if (!string.IsNullOrEmpty(filter))
                {
                    p = new NpgsqlParameter[] { new NpgsqlParameter("filter", "%" + filter + "%") };
                }

                DataTable dt = DbHelper.GetDataTable(sql, p);
                cbUzytkownicy.DataSource = dt;
                cbUzytkownicy.DisplayMember = "display_name";
                cbUzytkownicy.ValueMember = "id_klienta";
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d u¿ytkowników: " + ex.Message);
            }
        }

        private void cbUzytkownicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gdy zmieniam osobê na liœcie, aktualizuje sesjê i portfel
            if (cbUzytkownicy.SelectedValue != null && int.TryParse(cbUzytkownicy.SelectedValue.ToString(), out int id))
            {
                UserSession.UserId = id;
                RefreshWallet();
                LoadHistory(); // Odœwie¿ zak³adkê "Moje konto" dla nowej osoby
            }
        }

        private void txtSzukajKlienta_TextChanged(object sender, EventArgs e)
        {
            LoadUsers(txtSzukajKlienta.Text);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Form1 registerForm = new Form1();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers(); // Odœwie¿ listê po dodaniu nowego klienta
            }
        }

        // --- DZIE£A SZTUKI I WYSZUKIWANIE ---

        private void LoadDziela(string filter = "")
        {
            try
            {
                string sql = @"
            SELECT 
                d.id_dziela_sztuki, 
                d.nazwa || ' - ' || 
                COALESCE(
                    (SELECT nazwa FROM pseudonim WHERE id_artysty = a.id_artysty LIMIT 1), 
                    a.imie || ' ' || a.nazwisko
                ) || ' (' || d.cena || ' PLN)' AS display_name
            FROM dzielo_sztuki d
            JOIN artysta a ON d.id_artysty = a.id_artysty
            WHERE NOT EXISTS (
                SELECT 1 FROM transakcja t WHERE t.id_dziela_sztuki = d.id_dziela_sztuki
            )";

                if (!string.IsNullOrEmpty(filter))
                {
                    sql += " AND d.nazwa ILIKE @filter";
                }

                NpgsqlParameter[] p = null;
                if (!string.IsNullOrEmpty(filter))
                {
                    p = new NpgsqlParameter[] { new NpgsqlParameter("filter", "%" + filter + "%") };
                }

                DataTable dt = DbHelper.GetDataTable(sql, p);
                cbDziela.DataSource = dt;
                cbDziela.DisplayMember = "display_name";
                cbDziela.ValueMember = "id_dziela_sztuki";
            }
            catch (Exception ex) { MessageBox.Show("B³¹d ³adowania dzie³: " + ex.Message); }
        }

        private void txtSzukajDziela_TextChanged(object sender, EventArgs e)
        {
            LoadDziela(txtSzukajDziela.Text);
        }

        // --- POZOSTA£A LOGIKA ---

        private void RefreshWallet()
        {
            if (UserSession.UserId == 0) return;
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT portfel FROM klient WHERE id_klienta = @id";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", UserSession.UserId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            UserSession.Portfel = Convert.ToDecimal(result);
                            lblStanKonta.Text = $"Stan konta: {UserSession.Portfel:N2} PLN";
                        }
                    }
                }
            }
            catch { }
        }

        private void btnKup_Click(object sender, EventArgs e)
        {
            if (cbDziela.SelectedValue == null) { MessageBox.Show("Wybierz dzie³o!"); return; }
            if (UserSession.UserId == 0) { MessageBox.Show("Wybierz klienta z listy!"); return; }

            int idDziela = Convert.ToInt32(cbDziela.SelectedValue);
            bool czyKarta = rbKarta.Checked;

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var transaction = conn.BeginTransaction();
                try
                {
                    string sqlMain = 
                        @"INSERT INTO transakcja (id_dziela_sztuki, 
                        id_klienta, data_tranzakcji) VALUES (@idD, @idK, NOW()) RETURNING id_transakcji";
                    int idTransakcji;
                    using (var cmd = new NpgsqlCommand(sqlMain, conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("idD", idDziela);
                        cmd.Parameters.AddWithValue("idK", UserSession.UserId);
                        idTransakcji = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    if (czyKarta)
                    {
                        string sqlCard = "INSERT INTO tranzakcja_karta " +
                            "(id_transakcji, numer_karty) VALUES (@idT, 'CARD-123')";
                        using (var cmd = new NpgsqlCommand(sqlCard, conn))
                        {
                            cmd.Transaction = transaction;
                            cmd.Parameters.AddWithValue("idT", idTransakcji);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string sqlCash = "INSERT INTO tranzakcja_gotowka " +
                            "(id_transakcji, czy_reszta) VALUES (@idT, false)";
                        using (var cmd = new NpgsqlCommand(sqlCash, conn))
                        {
                            cmd.Transaction = transaction;
                            cmd.Parameters.AddWithValue("idT", idTransakcji);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Zakup udany!");
                    RefreshWallet();
                    LoadDziela(); // Usuñ kupione z listy
                    LoadHistory();
                }
                catch (PostgresException ex)
                {
                    transaction.Rollback();
                    if (ex.SqlState == "P0001") MessageBox.Show($"B³¹d: {ex.MessageText}");
                    else MessageBox.Show("B³¹d SQL: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("B³¹d: " + ex.Message);
                }
            }
        }

        private void LoadHistory()
        {
            if (UserSession.UserId == 0) return;
            try
            {
                string sql = @"
            SELECT 
                d.nazwa AS ""Dzie³o"", 
                COALESCE(
                    (SELECT nazwa FROM pseudonim WHERE id_artysty = a.id_artysty LIMIT 1), 
                    a.imie || ' ' || a.nazwisko
                ) AS ""Artysta"",
                d.cena AS ""Cena"", 
                t.data_tranzakcji AS ""Data""
            FROM transakcja t
            JOIN dzielo_sztuki d ON t.id_dziela_sztuki = d.id_dziela_sztuki
            JOIN artysta a ON d.id_artysty = a.id_artysty
            WHERE t.id_klienta = @id
            ORDER BY t.data_tranzakcji DESC";

                DataTable dt = DbHelper.GetDataTable(sql, new NpgsqlParameter[] { new NpgsqlParameter("id", UserSession.UserId) });
                dgvHistoria.DataSource = dt;
                dgvHistoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch { }
        }

        private void btnOdswiezHistorie_Click(object sender, EventArgs e)
        {
            LoadHistory();
        }

        // 1. Zmiana etykiet w zale¿noœci od wybranego raportu
        private void cbRodzajRaportu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbRodzajRaportu.SelectedIndex;

            // Czyszcze pola
            txtKryterium1.Text = "";
            txtKryterium2.Text = "";

            switch (index)
            {
                case 0: // Historia (Tabela)
                    lblKryterium1.Text = "Data od (RRRR-MM-DD):";
                    lblKryterium2.Text = "Cena minimalna:";
                    txtKryterium1.Text = "2020-01-01"; // Domyœlna
                    txtKryterium2.Text = "0";
                    break;
                case 1: // Dzie³a wg Artysty (Grupowanie)
                    lblKryterium1.Text = "Pseudonim artysty:";
                    lblKryterium2.Text = "Cena maksymalna:";
                    break;
                case 2: // Sprzeda¿ (Wykres)
                    lblKryterium1.Text = "Data od:";
                    lblKryterium2.Text = "Data do:";
                    txtKryterium1.Text = "2020-01-01";
                    txtKryterium2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    break;
                case 3: // Certyfikat (Formularz)
                    lblKryterium1.Text = "Pseudonim Artysty:";
                    lblKryterium2.Text = "Nazwisko Klienta:";
                    break;
            }
        }

        // 2. Generowanie odpowiedniego raportu
        private void btnGeneruj_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                string raportPlik = "";
                NpgsqlParameter[] p = null;

                int index = cbRodzajRaportu.SelectedIndex;

                // Pobieram wartoœci z pól tekstowych
                string k1 = txtKryterium1.Text;
                string k2 = txtKryterium2.Text;

                switch (index)
                {
                    case 0: // --- RAPORT 1: TABELA (Historia) ---
                        raportPlik = "RaportKlienta.rdlc";
                        sql = @"
                    SELECT 
                        d.nazwa AS TytulDziela, 
                        t.data_tranzakcji AS DataZakupu, 
                        d.cena AS Cena,
                        CASE WHEN EXISTS (SELECT 1 FROM tranzakcja_karta tk WHERE 
                    tk.id_transakcji = t.id_transakcji) THEN 'Karta' ELSE 'Gotówka' END AS MetodaPlatnosci
                    FROM transakcja t
                    JOIN dzielo_sztuki d ON t.id_dziela_sztuki = d.id_dziela_sztuki
                    WHERE t.id_klienta = @id AND t.data_tranzakcji >= @d1 AND d.cena >= @c1";

                        // Parsowanie filtrów
                        DateTime.TryParse(k1, out DateTime d1);
                        decimal.TryParse(k2, out decimal c1);

                        p = new NpgsqlParameter[] {
                    new NpgsqlParameter("id", UserSession.UserId),
                    new NpgsqlParameter("d1", d1),
                    new NpgsqlParameter("c1", c1)
                };
                        break;

                    case 1: // --- RAPORT 2: GRUPOWANIE (Dzie³a dostêpne) ---
                        raportPlik = "RaportGrupowanie.rdlc";
                        sql = @"
                    SELECT 
                        d.nazwa AS TytulDziela, 
                        d.cena AS Cena, 
                        COALESCE(
                            (SELECT nazwa FROM pseudonim WHERE id_artysty = a.id_artysty LIMIT 1), 
                            a.imie || ' ' || a.nazwisko
                        ) AS Artysta
                    FROM dzielo_sztuki d
                    JOIN artysta a ON d.id_artysty = a.id_artysty
                    WHERE NOT EXISTS (SELECT 1 FROM transakcja t WHERE 
                    t.id_dziela_sztuki = d.id_dziela_sztuki)
                    AND (
                        a.nazwisko ILIKE @nazwisko 
                        OR 
                        EXISTS (SELECT 1 FROM pseudonim p WHERE p.id_artysty = a.id_artysty AND 
                    p.nazwa ILIKE @nazwisko)
                    )
                    AND d.cena <= @cenaMax
                    ORDER BY 3"; // Sortuje po 3 kolumnie (Artysta), ¿eby grupowanie w raporcie dzia³a³o!

                        decimal.TryParse(k2, out decimal cenaMax);
                        if (cenaMax == 0) cenaMax = 999999;

                        p = new NpgsqlParameter[] {
                    new NpgsqlParameter("nazwisko", "%" + k1 + "%"),
                    new NpgsqlParameter("cenaMax", cenaMax)
                };
                        break;

                    case 2: // --- RAPORT 3: WYKRES (Statystyki) ---
                        raportPlik = "RaportWykres.rdlc";
                        sql = @"
                    SELECT 
                        CASE WHEN EXISTS (SELECT 1 FROM tranzakcja_karta tk WHERE 
                    tk.id_transakcji = t.id_transakcji) THEN 'Karta' ELSE 'Gotówka' END AS MetodaPlatnosci,
                        d.cena AS Cena
                    FROM transakcja t
                    JOIN dzielo_sztuki d ON t.id_dziela_sztuki = d.id_dziela_sztuki
                    WHERE t.data_tranzakcji >= @dOd AND t.data_tranzakcji <= @dDo";

                        DateTime.TryParse(k1, out DateTime dOd);
                        DateTime.TryParse(k2, out DateTime dDo);

                        p = new NpgsqlParameter[] {
                    new NpgsqlParameter("dOd", dOd),
                    new NpgsqlParameter("dDo", dDo)
                };
                        break;

                    case 3: // --- RAPORT 4: FORMULARZ (Certyfikat) ---
                        raportPlik = "RaportFormularz.rdlc";
                        sql = @"
                    SELECT 
                        d.nazwa AS TytulDziela, 
                        t.data_tranzakcji AS DataZakupu, 
                        d.cena AS Cena, 
                        COALESCE(
                            (SELECT nazwa FROM pseudonim WHERE id_artysty = a.id_artysty LIMIT 1), 
                            a.imie || ' ' || a.nazwisko
                        ) AS Artysta, 
                        k.imie || ' ' || k.nazwisko AS Klient
                    FROM transakcja t
                    JOIN dzielo_sztuki d ON t.id_dziela_sztuki = d.id_dziela_sztuki
                    JOIN artysta a ON d.id_artysty = a.id_artysty
                    JOIN klient k ON t.id_klienta = k.id_klienta
                    WHERE 
                      (
                        a.nazwisko ILIKE @artysta 
                        OR 
                        EXISTS (SELECT 1 FROM pseudonim p 
                        WHERE p.id_artysty = a.id_artysty AND p.nazwa ILIKE @artysta)
                      )
                      AND k.nazwisko ILIKE @klient";

                        p = new NpgsqlParameter[] {
                    new NpgsqlParameter("artysta", "%" + k1 + "%"),
                    new NpgsqlParameter("klient", "%" + k2 + "%")
                };
                        break;
                }

                // --- WSPÓLNE WYKONANIE ---
                if (!string.IsNullOrEmpty(sql))
                {
                    DataTable dt = DbHelper.GetDataTable(sql, p);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Brak danych spe³niaj¹cych kryteria.");
                        return;
                    }

                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                    reportViewer1.LocalReport.ReportPath = raportPlik;
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d generowania raportu: " + ex.Message);
            }
        }
    }
}