namespace GaleriaSztuki
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label6 = new Label();
            txtSzukajDziela = new TextBox();
            label5 = new Label();
            txtSzukajKlienta = new TextBox();
            btnAddUser = new Button();
            label4 = new Label();
            cbUzytkownicy = new ComboBox();
            btnKup = new Button();
            groupBox1 = new GroupBox();
            rbGotowka = new RadioButton();
            rbKarta = new RadioButton();
            label2 = new Label();
            cbDziela = new ComboBox();
            lblStanKonta = new Label();
            tabPage2 = new TabPage();
            dgvHistoria = new DataGridView();
            btnOdswiezHistorie = new Button();
            labelInfo = new Label();
            tabPage3 = new TabPage();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            panelFiltry = new Panel();
            cbRodzajRaportu = new ComboBox();
            labelRaport = new Label();
            btnGeneruj = new Button();
            txtKryterium2 = new TextBox();
            lblKryterium2 = new Label();
            txtKryterium1 = new TextBox();
            lblKryterium1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistoria).BeginInit();
            tabPage3.SuspendLayout();
            panelFiltry.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1143, 1000);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(txtSzukajDziela);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(txtSzukajKlienta);
            tabPage1.Controls.Add(btnAddUser);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(cbUzytkownicy);
            tabPage1.Controls.Add(btnKup);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(cbDziela);
            tabPage1.Controls.Add(lblStanKonta);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Margin = new Padding(4, 5, 4, 5);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 5, 4, 5);
            tabPage1.Size = new Size(1135, 962);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Zakupy";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label6.Location = new Point(497, 247);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 11;
            label6.Text = "Szukaj:";
            // 
            // txtSzukajDziela
            // 
            txtSzukajDziela.Location = new Point(567, 242);
            txtSzukajDziela.Margin = new Padding(4, 5, 4, 5);
            txtSzukajDziela.Name = "txtSzukajDziela";
            txtSzukajDziela.Size = new Size(213, 31);
            txtSzukajDziela.TabIndex = 10;
            txtSzukajDziela.TextChanged += txtSzukajDziela_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label5.Location = new Point(497, 80);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 9;
            label5.Text = "Szukaj:";
            // 
            // txtSzukajKlienta
            // 
            txtSzukajKlienta.Location = new Point(567, 75);
            txtSzukajKlienta.Margin = new Padding(4, 5, 4, 5);
            txtSzukajKlienta.Name = "txtSzukajKlienta";
            txtSzukajKlienta.Size = new Size(213, 31);
            txtSzukajKlienta.TabIndex = 8;
            txtSzukajKlienta.TextChanged += txtSzukajKlienta_TextChanged;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(800, 73);
            btnAddUser.Margin = new Padding(4, 5, 4, 5);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(214, 42);
            btnAddUser.TabIndex = 7;
            btnAddUser.Text = "+ Dodaj nowego klienta";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(29, 42);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(150, 25);
            label4.TabIndex = 6;
            label4.Text = "Wybierz klienta:";
            // 
            // cbUzytkownicy
            // 
            cbUzytkownicy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUzytkownicy.FormattingEnabled = true;
            cbUzytkownicy.Location = new Point(29, 75);
            cbUzytkownicy.Margin = new Padding(4, 5, 4, 5);
            cbUzytkownicy.Name = "cbUzytkownicy";
            cbUzytkownicy.Size = new Size(427, 33);
            cbUzytkownicy.TabIndex = 5;
            cbUzytkownicy.SelectedIndexChanged += cbUzytkownicy_SelectedIndexChanged;
            // 
            // btnKup
            // 
            btnKup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnKup.Location = new Point(29, 533);
            btnKup.Margin = new Padding(4, 5, 4, 5);
            btnKup.Name = "btnKup";
            btnKup.Size = new Size(286, 83);
            btnKup.TabIndex = 4;
            btnKup.Text = "KUP TERAZ";
            btnKup.UseVisualStyleBackColor = true;
            btnKup.Click += btnKup_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbGotowka);
            groupBox1.Controls.Add(rbKarta);
            groupBox1.Location = new Point(29, 333);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(429, 167);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Metoda płatności";
            // 
            // rbGotowka
            // 
            rbGotowka.AutoSize = true;
            rbGotowka.Location = new Point(29, 100);
            rbGotowka.Margin = new Padding(4, 5, 4, 5);
            rbGotowka.Name = "rbGotowka";
            rbGotowka.Size = new Size(108, 29);
            rbGotowka.TabIndex = 1;
            rbGotowka.Text = "Gotówka";
            rbGotowka.UseVisualStyleBackColor = true;
            // 
            // rbKarta
            // 
            rbKarta.AutoSize = true;
            rbKarta.Checked = true;
            rbKarta.Location = new Point(29, 50);
            rbKarta.Margin = new Padding(4, 5, 4, 5);
            rbKarta.Name = "rbKarta";
            rbKarta.Size = new Size(152, 29);
            rbKarta.TabIndex = 0;
            rbKarta.TabStop = true;
            rbKarta.Text = "Karta płatnicza";
            rbKarta.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(29, 208);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(144, 25);
            label2.TabIndex = 2;
            label2.Text = "Wybierz dzieło:";
            // 
            // cbDziela
            // 
            cbDziela.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDziela.FormattingEnabled = true;
            cbDziela.Location = new Point(29, 242);
            cbDziela.Margin = new Padding(4, 5, 4, 5);
            cbDziela.Name = "cbDziela";
            cbDziela.Size = new Size(427, 33);
            cbDziela.TabIndex = 1;
            // 
            // lblStanKonta
            // 
            lblStanKonta.AutoSize = true;
            lblStanKonta.Font = new Font("Segoe UI", 12F);
            lblStanKonta.ForeColor = Color.Green;
            lblStanKonta.Location = new Point(29, 133);
            lblStanKonta.Margin = new Padding(4, 0, 4, 0);
            lblStanKonta.Name = "lblStanKonta";
            lblStanKonta.Size = new Size(201, 32);
            lblStanKonta.TabIndex = 0;
            lblStanKonta.Text = "Stan konta: 0 PLN";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvHistoria);
            tabPage2.Controls.Add(btnOdswiezHistorie);
            tabPage2.Controls.Add(labelInfo);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Margin = new Padding(4, 5, 4, 5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 5, 4, 5);
            tabPage2.Size = new Size(1135, 962);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Moje Konto";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvHistoria
            // 
            dgvHistoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistoria.Location = new Point(29, 100);
            dgvHistoria.Margin = new Padding(4, 5, 4, 5);
            dgvHistoria.Name = "dgvHistoria";
            dgvHistoria.RowHeadersWidth = 62;
            dgvHistoria.RowTemplate.Height = 25;
            dgvHistoria.Size = new Size(1071, 800);
            dgvHistoria.TabIndex = 2;
            // 
            // btnOdswiezHistorie
            // 
            btnOdswiezHistorie.Location = new Point(957, 33);
            btnOdswiezHistorie.Margin = new Padding(4, 5, 4, 5);
            btnOdswiezHistorie.Name = "btnOdswiezHistorie";
            btnOdswiezHistorie.Size = new Size(143, 50);
            btnOdswiezHistorie.TabIndex = 1;
            btnOdswiezHistorie.Text = "Odśwież";
            btnOdswiezHistorie.UseVisualStyleBackColor = true;
            btnOdswiezHistorie.Click += btnOdswiezHistorie_Click;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Location = new Point(29, 33);
            labelInfo.Margin = new Padding(4, 0, 4, 0);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(149, 25);
            labelInfo.TabIndex = 3;
            labelInfo.Text = "Historia zakupów";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(reportViewer1);
            tabPage3.Controls.Add(panelFiltry);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Margin = new Padding(4, 5, 4, 5);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(4, 5, 4, 5);
            tabPage3.Size = new Size(1135, 962);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Raporty";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(4, 138);
            reportViewer1.Margin = new Padding(4, 5, 4, 5);
            reportViewer1.Name = "reportViewer1";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1127, 819);
            reportViewer1.TabIndex = 1;
            // 
            // panelFiltry
            // 
            panelFiltry.Controls.Add(cbRodzajRaportu);
            panelFiltry.Controls.Add(labelRaport);
            panelFiltry.Controls.Add(btnGeneruj);
            panelFiltry.Controls.Add(txtKryterium2);
            panelFiltry.Controls.Add(lblKryterium2);
            panelFiltry.Controls.Add(txtKryterium1);
            panelFiltry.Controls.Add(lblKryterium1);
            panelFiltry.Dock = DockStyle.Top;
            panelFiltry.Location = new Point(4, 5);
            panelFiltry.Margin = new Padding(4, 5, 4, 5);
            panelFiltry.Name = "panelFiltry";
            panelFiltry.Size = new Size(1127, 133);
            panelFiltry.TabIndex = 0;
            // 
            // cbRodzajRaportu
            // 
            cbRodzajRaportu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRodzajRaportu.FormattingEnabled = true;
            cbRodzajRaportu.Items.AddRange(new object[] { "1. Historia Zakupów (Tabela)", "2. Dzieła wg Artysty (Grupowanie)", "3. Sprzedaż wg Metody (Wykres)", "4. Certyfikat Zakupu (Formularz)" });
            cbRodzajRaportu.Location = new Point(157, 20);
            cbRodzajRaportu.Margin = new Padding(4, 5, 4, 5);
            cbRodzajRaportu.Name = "cbRodzajRaportu";
            cbRodzajRaportu.Size = new Size(355, 33);
            cbRodzajRaportu.TabIndex = 0;
            cbRodzajRaportu.SelectedIndexChanged += cbRodzajRaportu_SelectedIndexChanged;
            // 
            // labelRaport
            // 
            labelRaport.AutoSize = true;
            labelRaport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelRaport.Location = new Point(29, 25);
            labelRaport.Margin = new Padding(4, 0, 4, 0);
            labelRaport.Name = "labelRaport";
            labelRaport.Size = new Size(123, 25);
            labelRaport.TabIndex = 10;
            labelRaport.Text = "Typ Raportu:";
            // 
            // btnGeneruj
            // 
            btnGeneruj.Location = new Point(714, 72);
            btnGeneruj.Margin = new Padding(4, 5, 4, 5);
            btnGeneruj.Name = "btnGeneruj";
            btnGeneruj.Size = new Size(214, 50);
            btnGeneruj.TabIndex = 4;
            btnGeneruj.Text = "Generuj Raport";
            btnGeneruj.UseVisualStyleBackColor = true;
            btnGeneruj.Click += btnGeneruj_Click;
            // 
            // txtKryterium2
            // 
            txtKryterium2.Location = new Point(337, 91);
            txtKryterium2.Margin = new Padding(4, 5, 4, 5);
            txtKryterium2.Name = "txtKryterium2";
            txtKryterium2.Size = new Size(170, 31);
            txtKryterium2.TabIndex = 3;
            // 
            // lblKryterium2
            // 
            lblKryterium2.AutoSize = true;
            lblKryterium2.Location = new Point(337, 61);
            lblKryterium2.Margin = new Padding(4, 0, 4, 0);
            lblKryterium2.Name = "lblKryterium2";
            lblKryterium2.Size = new Size(107, 25);
            lblKryterium2.TabIndex = 2;
            lblKryterium2.Text = "Kryterium 2:";
            // 
            // txtKryterium1
            // 
            txtKryterium1.Location = new Point(42, 91);
            txtKryterium1.Margin = new Padding(4, 5, 4, 5);
            txtKryterium1.Name = "txtKryterium1";
            txtKryterium1.Size = new Size(170, 31);
            txtKryterium1.TabIndex = 1;
            // 
            // lblKryterium1
            // 
            lblKryterium1.AutoSize = true;
            lblKryterium1.Location = new Point(42, 61);
            lblKryterium1.Margin = new Padding(4, 0, 4, 0);
            lblKryterium1.Name = "lblKryterium1";
            lblKryterium1.Size = new Size(107, 25);
            lblKryterium1.TabIndex = 0;
            lblKryterium1.Text = "Kryterium 1:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 1000);
            Controls.Add(tabControl1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "Galeria Sztuki";
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistoria).EndInit();
            tabPage3.ResumeLayout(false);
            panelFiltry.ResumeLayout(false);
            panelFiltry.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblStanKonta;
        private System.Windows.Forms.ComboBox cbDziela;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbGotowka;
        private System.Windows.Forms.RadioButton rbKarta;
        private System.Windows.Forms.Button btnKup;
        private System.Windows.Forms.DataGridView dgvHistoria;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button btnOdswiezHistorie;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;

        // Zaktualizowane pola do raportów
        private System.Windows.Forms.Panel panelFiltry;
        private System.Windows.Forms.Button btnGeneruj;
        private System.Windows.Forms.ComboBox cbRodzajRaportu;
        private System.Windows.Forms.Label labelRaport;
        private System.Windows.Forms.Label lblKryterium1;
        private System.Windows.Forms.TextBox txtKryterium1;
        private System.Windows.Forms.Label lblKryterium2;
        private System.Windows.Forms.TextBox txtKryterium2;

        private System.Windows.Forms.ComboBox cbUzytkownicy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtSzukajKlienta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSzukajDziela;
    }
}