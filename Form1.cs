using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaleriaSztuki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRejestracja_Click(object sender, EventArgs e)
        {
            string imie = txtImie.Text.Trim();
            string nazwisko = txtNazwisko.Text.Trim();
            string portfelStr = txtPortfel.Text.Trim();

            if (string.IsNullOrEmpty(imie) || string.IsNullOrEmpty(nazwisko))
            {
                MessageBox.Show("Podaj imię i nazwisko!");
                return;
            }

            if (!decimal.TryParse(portfelStr, out decimal portfel) || portfel < 0)
            {
                MessageBox.Show("Podaj poprawną kwotę portfela!");
                return;
            }

            string sql = "INSERT INTO klient (imie, nazwisko, portfel) VALUES (@imie, @nazwisko, @portfel)";

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("imie", imie);
                        cmd.Parameters.AddWithValue("nazwisko", nazwisko);
                        cmd.Parameters.AddWithValue("portfel", portfel);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Klient dodany pomyślnie!");
                        this.DialogResult = DialogResult.OK; // Sygnał dla głównego okna, że dodano kogoś
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

    }
}
