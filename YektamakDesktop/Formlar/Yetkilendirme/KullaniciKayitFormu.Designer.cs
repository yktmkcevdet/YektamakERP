namespace YektamakDesktop.Formlar.Yetkilendirme
{
    partial class KullaniciKayitFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelUyariKulllaniciAdi = new System.Windows.Forms.Label();
            labelUyariSifre = new System.Windows.Forms.Label();
            labelUyariSifreTekrar = new System.Windows.Forms.Label();
            labelUyariPersonel = new System.Windows.Forms.Label();
            labelUyariRol = new System.Windows.Forms.Label();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            btnSave = new YektamakDesktop.CustomControls.CustomButtonSave();
            ctbKullaniciAd = new YektamakDesktop.CustomControls.CustomTextBox();
            ctbSifre = new YektamakDesktop.CustomControls.CustomTextBox();
            ctbSifreTekrar = new YektamakDesktop.CustomControls.CustomTextBox();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            label4 = new System.Windows.Forms.Label();
            ctbId = new YektamakDesktop.CustomControls.CustomTextBox();
            clbPersonel = new YektamakDesktop.CustomControls.FilterableComboBox();
            clbRol = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbMailAdres = new YektamakDesktop.CustomControls.FilterableComboBox();
            label5 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // labelUyariKulllaniciAdi
            // 
            labelUyariKulllaniciAdi.AutoSize = true;
            labelUyariKulllaniciAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            labelUyariKulllaniciAdi.ForeColor = System.Drawing.Color.Red;
            labelUyariKulllaniciAdi.Location = new System.Drawing.Point(570, 90);
            labelUyariKulllaniciAdi.Name = "labelUyariKulllaniciAdi";
            labelUyariKulllaniciAdi.Size = new System.Drawing.Size(0, 15);
            labelUyariKulllaniciAdi.TabIndex = 91;
            // 
            // labelUyariSifre
            // 
            labelUyariSifre.AutoSize = true;
            labelUyariSifre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            labelUyariSifre.ForeColor = System.Drawing.Color.Red;
            labelUyariSifre.Location = new System.Drawing.Point(570, 129);
            labelUyariSifre.Name = "labelUyariSifre";
            labelUyariSifre.Size = new System.Drawing.Size(0, 15);
            labelUyariSifre.TabIndex = 92;
            // 
            // labelUyariSifreTekrar
            // 
            labelUyariSifreTekrar.AutoSize = true;
            labelUyariSifreTekrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            labelUyariSifreTekrar.ForeColor = System.Drawing.Color.Red;
            labelUyariSifreTekrar.Location = new System.Drawing.Point(570, 164);
            labelUyariSifreTekrar.Name = "labelUyariSifreTekrar";
            labelUyariSifreTekrar.Size = new System.Drawing.Size(0, 15);
            labelUyariSifreTekrar.TabIndex = 93;
            // 
            // labelUyariPersonel
            // 
            labelUyariPersonel.AutoSize = true;
            labelUyariPersonel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            labelUyariPersonel.ForeColor = System.Drawing.Color.Red;
            labelUyariPersonel.Location = new System.Drawing.Point(678, 197);
            labelUyariPersonel.Name = "labelUyariPersonel";
            labelUyariPersonel.Size = new System.Drawing.Size(0, 15);
            labelUyariPersonel.TabIndex = 94;
            // 
            // labelUyariRol
            // 
            labelUyariRol.AutoSize = true;
            labelUyariRol.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            labelUyariRol.ForeColor = System.Drawing.Color.Red;
            labelUyariRol.Location = new System.Drawing.Point(332, 186);
            labelUyariRol.Name = "labelUyariRol";
            labelUyariRol.Size = new System.Drawing.Size(0, 15);
            labelUyariRol.TabIndex = 95;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Kullanıcı kayıt Formu";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(693, 25);
            headerPanel1.TabIndex = 97;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.Transparent;
            btnSave.Location = new System.Drawing.Point(480, 178);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(106, 46);
            btnSave.TabIndex = 98;
            btnSave.SaveButtonClick += rButtonKullaniciKaydet_Click;
            btnSave.Click += rButtonKullaniciKaydet_Click;
            // 
            // ctbKullaniciAd
            // 
            ctbKullaniciAd.BackColor = System.Drawing.Color.White;
            ctbKullaniciAd.BorderColor = System.Drawing.Color.Silver;
            ctbKullaniciAd.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbKullaniciAd.BorderSize = 1;
            ctbKullaniciAd.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbKullaniciAd.ForeColor = System.Drawing.Color.Black;
            ctbKullaniciAd.Location = new System.Drawing.Point(124, 79);
            ctbKullaniciAd.Margin = new System.Windows.Forms.Padding(1);
            ctbKullaniciAd.Multiline = false;
            ctbKullaniciAd.Name = "ctbKullaniciAd";
            ctbKullaniciAd.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbKullaniciAd.PasswordChar = false;
            ctbKullaniciAd.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbKullaniciAd.PlaceholderText = "";
            ctbKullaniciAd.ReadOnly = false;
            ctbKullaniciAd.SelectionStart = 0;
            ctbKullaniciAd.Size = new System.Drawing.Size(204, 29);
            ctbKullaniciAd.TabIndex = 99;
            ctbKullaniciAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbKullaniciAd.TextCustom = "";
            ctbKullaniciAd.UnderlinedStyle = false;
            // 
            // ctbSifre
            // 
            ctbSifre.BackColor = System.Drawing.Color.White;
            ctbSifre.BorderColor = System.Drawing.Color.Silver;
            ctbSifre.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbSifre.BorderSize = 1;
            ctbSifre.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbSifre.ForeColor = System.Drawing.Color.Black;
            ctbSifre.Location = new System.Drawing.Point(124, 110);
            ctbSifre.Margin = new System.Windows.Forms.Padding(1);
            ctbSifre.Multiline = false;
            ctbSifre.Name = "ctbSifre";
            ctbSifre.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbSifre.PasswordChar = true;
            ctbSifre.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbSifre.PlaceholderText = "";
            ctbSifre.ReadOnly = false;
            ctbSifre.SelectionStart = 0;
            ctbSifre.Size = new System.Drawing.Size(262, 29);
            ctbSifre.TabIndex = 100;
            ctbSifre.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbSifre.TextCustom = "";
            ctbSifre.UnderlinedStyle = false;
            // 
            // ctbSifreTekrar
            // 
            ctbSifreTekrar.BackColor = System.Drawing.Color.White;
            ctbSifreTekrar.BorderColor = System.Drawing.Color.Silver;
            ctbSifreTekrar.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbSifreTekrar.BorderSize = 1;
            ctbSifreTekrar.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbSifreTekrar.ForeColor = System.Drawing.Color.Black;
            ctbSifreTekrar.Location = new System.Drawing.Point(124, 141);
            ctbSifreTekrar.Margin = new System.Windows.Forms.Padding(1);
            ctbSifreTekrar.Multiline = false;
            ctbSifreTekrar.Name = "ctbSifreTekrar";
            ctbSifreTekrar.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbSifreTekrar.PasswordChar = true;
            ctbSifreTekrar.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbSifreTekrar.PlaceholderText = "";
            ctbSifreTekrar.ReadOnly = false;
            ctbSifreTekrar.SelectionStart = 0;
            ctbSifreTekrar.Size = new System.Drawing.Size(262, 29);
            ctbSifreTekrar.TabIndex = 101;
            ctbSifreTekrar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbSifreTekrar.TextCustom = "";
            ctbSifreTekrar.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(45, 84);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(74, 15);
            label6.TabIndex = 102;
            label6.Text = "Kullanıcı Adı";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label8.Location = new System.Drawing.Point(45, 117);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(34, 15);
            label8.TabIndex = 103;
            label8.Text = "Şifre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(45, 147);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 15);
            label1.TabIndex = 104;
            label1.Text = "Şifre Tekrar";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(45, 177);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 15);
            label2.TabIndex = 105;
            label2.Text = "Personel";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(45, 207);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(25, 15);
            label3.TabIndex = 106;
            label3.Text = "Rol";
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(0, 310);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(693, 362);
            universalGrid1.TabIndex = 107;
            // 
            // roundedButton1
            // 
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Black;
            roundedButton1.BorderSize = 0;
            roundedButton1.CornerRadius = 20;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedButton1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedButton1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedButton1.HoverColor2 = System.Drawing.Color.Navy;
            roundedButton1.Icon = null;
            roundedButton1.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton1.Location = new System.Drawing.Point(442, 53);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(78, 40);
            roundedButton1.TabIndex = 108;
            roundedButton1.Text = "Yeni Kayıt";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(45, 53);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(67, 15);
            label4.TabIndex = 110;
            label4.Text = "Kullanıcı Id";
            // 
            // ctbId
            // 
            ctbId.BackColor = System.Drawing.Color.White;
            ctbId.BorderColor = System.Drawing.Color.Silver;
            ctbId.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbId.BorderSize = 1;
            ctbId.Enabled = false;
            ctbId.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbId.ForeColor = System.Drawing.Color.Black;
            ctbId.Location = new System.Drawing.Point(124, 48);
            ctbId.Margin = new System.Windows.Forms.Padding(1);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbId.PasswordChar = false;
            ctbId.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbId.PlaceholderText = "";
            ctbId.ReadOnly = false;
            ctbId.SelectionStart = 0;
            ctbId.Size = new System.Drawing.Size(87, 29);
            ctbId.TabIndex = 109;
            ctbId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbId.TextCustom = "";
            ctbId.UnderlinedStyle = false;
            // 
            // clbPersonel
            // 
            clbPersonel.BorderColor = System.Drawing.Color.Silver;
            clbPersonel.BorderRadius = 8;
            clbPersonel.BorderSize = 1;
            clbPersonel.DisplayMember = "adSoyad";
            clbPersonel.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbPersonel.Location = new System.Drawing.Point(124, 172);
            clbPersonel.Margin = new System.Windows.Forms.Padding(1);
            clbPersonel.Name = "clbPersonel";
            clbPersonel.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbPersonel.PlaceholderText = "Seçiniz...";
            clbPersonel.Size = new System.Drawing.Size(231, 25);
            clbPersonel.TabIndex = 111;
            clbPersonel.ValueMember = "Id";
            // 
            // clbRol
            // 
            clbRol.BorderColor = System.Drawing.Color.Silver;
            clbRol.BorderRadius = 8;
            clbRol.BorderSize = 1;
            clbRol.DisplayMember = "ad";
            clbRol.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbRol.Location = new System.Drawing.Point(124, 199);
            clbRol.Margin = new System.Windows.Forms.Padding(1);
            clbRol.Name = "clbRol";
            clbRol.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbRol.PlaceholderText = "Seçiniz...";
            clbRol.Size = new System.Drawing.Size(179, 25);
            clbRol.TabIndex = 112;
            clbRol.ValueMember = "Id";
            // 
            // fcbMailAdres
            // 
            fcbMailAdres.BorderColor = System.Drawing.Color.Silver;
            fcbMailAdres.BorderRadius = 8;
            fcbMailAdres.BorderSize = 1;
            fcbMailAdres.DisplayMember = "adres";
            fcbMailAdres.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMailAdres.Location = new System.Drawing.Point(124, 226);
            fcbMailAdres.Margin = new System.Windows.Forms.Padding(1);
            fcbMailAdres.Name = "fcbMailAdres";
            fcbMailAdres.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMailAdres.PlaceholderText = "Seçiniz...";
            fcbMailAdres.Size = new System.Drawing.Size(179, 25);
            fcbMailAdres.TabIndex = 114;
            fcbMailAdres.ValueMember = "Id";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(45, 234);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(65, 15);
            label5.TabIndex = 113;
            label5.Text = "Mail Adres";
            // 
            // KullaniciKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(693, 673);
            Controls.Add(fcbMailAdres);
            Controls.Add(label5);
            Controls.Add(clbRol);
            Controls.Add(clbPersonel);
            Controls.Add(label4);
            Controls.Add(ctbId);
            Controls.Add(roundedButton1);
            Controls.Add(universalGrid1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(ctbSifreTekrar);
            Controls.Add(ctbSifre);
            Controls.Add(ctbKullaniciAd);
            Controls.Add(btnSave);
            Controls.Add(headerPanel1);
            Controls.Add(labelUyariRol);
            Controls.Add(labelUyariPersonel);
            Controls.Add(labelUyariSifreTekrar);
            Controls.Add(labelUyariSifre);
            Controls.Add(labelUyariKulllaniciAdi);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "KullaniciKayitFormu";
            Text = "KullaniciKayitFormu";
            FormClosing += KullaniciKayitFormu_FormClosing;
            Load += KullaniciKayitFormu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label labelUyariKulllaniciAdi;
        private System.Windows.Forms.Label labelUyariSifre;
        private System.Windows.Forms.Label labelUyariSifreTekrar;
        private System.Windows.Forms.Label labelUyariPersonel;
        private System.Windows.Forms.Label labelUyariRol;
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomButtonSave btnSave;
        private CustomControls.CustomTextBox ctbKullaniciAd;
        private CustomControls.CustomTextBox ctbSifre;
        private CustomControls.CustomTextBox ctbSifreTekrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.RoundedButton roundedButton1;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBox ctbId;
        private CustomControls.FilterableComboBox clbPersonel;
        private CustomControls.FilterableComboBox clbRol;
        private CustomControls.FilterableComboBox fcbMailAdres;
        private System.Windows.Forms.Label label5;
    }
}