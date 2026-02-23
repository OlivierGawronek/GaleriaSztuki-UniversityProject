namespace GaleriaSztuki
{
    partial class Form1
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
            this.txtImie = new System.Windows.Forms.TextBox();
            this.txtNazwisko = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRejestracja = new System.Windows.Forms.Button();
            this.txtPortfel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtImie
            // 
            this.txtImie.Location = new System.Drawing.Point(130, 40);
            this.txtImie.Name = "txtImie";
            this.txtImie.Size = new System.Drawing.Size(200, 23);
            this.txtImie.TabIndex = 0;
            // 
            // txtNazwisko
            // 
            this.txtNazwisko.Location = new System.Drawing.Point(130, 80);
            this.txtNazwisko.Name = "txtNazwisko";
            this.txtNazwisko.Size = new System.Drawing.Size(200, 23);
            this.txtNazwisko.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Imię:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nazwisko:";
            // 
            // btnRejestracja
            // 
            this.btnRejestracja.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRejestracja.Location = new System.Drawing.Point(130, 160);
            this.btnRejestracja.Name = "btnRejestracja";
            this.btnRejestracja.Size = new System.Drawing.Size(200, 40);
            this.btnRejestracja.TabIndex = 3;
            this.btnRejestracja.Text = "DODAJ KLIENTA";
            this.btnRejestracja.UseVisualStyleBackColor = true;
            this.btnRejestracja.Click += new System.EventHandler(this.btnRejestracja_Click);
            // 
            // txtPortfel
            // 
            this.txtPortfel.Location = new System.Drawing.Point(130, 120);
            this.txtPortfel.Name = "txtPortfel";
            this.txtPortfel.PlaceholderText = "Np. 5000";
            this.txtPortfel.Size = new System.Drawing.Size(200, 23);
            this.txtPortfel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Stan portfela:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPortfel);
            this.Controls.Add(this.btnRejestracja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNazwisko);
            this.Controls.Add(this.txtImie);
            this.Name = "Form1";
            this.Text = "Dodaj Nowego Klienta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImie;
        private System.Windows.Forms.TextBox txtNazwisko;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRejestracja;
        private System.Windows.Forms.TextBox txtPortfel;
        private System.Windows.Forms.Label label3;
    }
}