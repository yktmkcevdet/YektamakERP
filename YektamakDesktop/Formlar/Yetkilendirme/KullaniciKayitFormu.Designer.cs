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
            rButtonKullaniciKaydet = new YektamakDesktop.CustomControls.RoundedButton();
            textBoxKullaniciAdi = new YektamakDesktop.CustomControls.CustomTextBox();
            label2 = new System.Windows.Forms.Label();
            labelKullaniciAdi = new System.Windows.Forms.Label();
            customTextBoxSifre = new YektamakDesktop.CustomControls.CustomTextBox();
            label1 = new System.Windows.Forms.Label();
            labelSifre = new System.Windows.Forms.Label();
            customTextBoxSifreTekrar = new YektamakDesktop.CustomControls.CustomTextBox();
            label3 = new System.Windows.Forms.Label();
            labelSifreTekrar = new System.Windows.Forms.Label();
            comboListBoxRol = new YektamakDesktop.CustomControls.CustomComboListBox();
            label7 = new System.Windows.Forms.Label();
            labelPersonel = new System.Windows.Forms.Label();
            cbxPersonel = new YektamakDesktop.CustomControls.CustomComboListBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            buttonFiltre = new System.Windows.Forms.Button();
            labelUyariKulllaniciAdi = new System.Windows.Forms.Label();
            labelUyariSifre = new System.Windows.Forms.Label();
            labelUyariSifreTekrar = new System.Windows.Forms.Label();
            labelUyariPersonel = new System.Windows.Forms.Label();
            labelUyariRol = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            SuspendLayout();
            // 
            // rButtonKullaniciKaydet
            // 
            rButtonKullaniciKaydet.BackColor = System.Drawing.Color.LimeGreen;
            rButtonKullaniciKaydet.BackgroundColor = System.Drawing.Color.LimeGreen;
            rButtonKullaniciKaydet.BorderColor = System.Drawing.Color.MediumSeaGreen;
            rButtonKullaniciKaydet.BorderRadius = 40;
            rButtonKullaniciKaydet.BorderSize = 5;
            rButtonKullaniciKaydet.FlatAppearance.BorderSize = 0;
            rButtonKullaniciKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonKullaniciKaydet.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonKullaniciKaydet.ForeColor = System.Drawing.Color.White;
            rButtonKullaniciKaydet.Location = new System.Drawing.Point(557, 247);
            rButtonKullaniciKaydet.Name = "rButtonKullaniciKaydet";
            rButtonKullaniciKaydet.Size = new System.Drawing.Size(117, 66);
            rButtonKullaniciKaydet.TabIndex = 24;
            rButtonKullaniciKaydet.Text = "KAYDET";
            rButtonKullaniciKaydet.TextColor = System.Drawing.Color.White;
            rButtonKullaniciKaydet.UseVisualStyleBackColor = false;
            rButtonKullaniciKaydet.Click += rButtonKullaniciKaydet_Click;
            // 
            // textBoxKullaniciAdi
            // 
            textBoxKullaniciAdi.BackColor = System.Drawing.Color.White;
            textBoxKullaniciAdi.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxKullaniciAdi.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxKullaniciAdi.BorderRadius = 0;
            textBoxKullaniciAdi.BorderSize = 2;
            textBoxKullaniciAdi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxKullaniciAdi.ForeColor = System.Drawing.Color.Black;
            textBoxKullaniciAdi.isPlaceHolder = false;
            textBoxKullaniciAdi.Location = new System.Drawing.Point(296, 81);
            textBoxKullaniciAdi.Multiline = false;
            textBoxKullaniciAdi.Name = "textBoxKullaniciAdi";
            textBoxKullaniciAdi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxKullaniciAdi.PasswordChar = false;
            textBoxKullaniciAdi.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxKullaniciAdi.PlaceholderText = "";
            textBoxKullaniciAdi.ReadOnly = false;
            textBoxKullaniciAdi.SelectionStart = 0;
            textBoxKullaniciAdi.Size = new System.Drawing.Size(268, 32);
            textBoxKullaniciAdi.TabIndex = 27;
            textBoxKullaniciAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxKullaniciAdi.TextCustom = "";
            textBoxKullaniciAdi.UnderlinedStyle = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(272, 82);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(18, 30);
            label2.TabIndex = 26;
            label2.Text = ":";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelKullaniciAdi
            // 
            labelKullaniciAdi.AutoSize = true;
            labelKullaniciAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelKullaniciAdi.Location = new System.Drawing.Point(6, 82);
            labelKullaniciAdi.Name = "labelKullaniciAdi";
            labelKullaniciAdi.Size = new System.Drawing.Size(129, 30);
            labelKullaniciAdi.TabIndex = 25;
            labelKullaniciAdi.Text = "Kullanıcı Adı";
            labelKullaniciAdi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customTextBoxSifre
            // 
            customTextBoxSifre.BackColor = System.Drawing.Color.White;
            customTextBoxSifre.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxSifre.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxSifre.BorderRadius = 0;
            customTextBoxSifre.BorderSize = 2;
            customTextBoxSifre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxSifre.ForeColor = System.Drawing.Color.Black;
            customTextBoxSifre.isPlaceHolder = false;
            customTextBoxSifre.Location = new System.Drawing.Point(296, 119);
            customTextBoxSifre.Multiline = false;
            customTextBoxSifre.Name = "customTextBoxSifre";
            customTextBoxSifre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxSifre.PasswordChar = true;
            customTextBoxSifre.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxSifre.PlaceholderText = "";
            customTextBoxSifre.ReadOnly = false;
            customTextBoxSifre.SelectionStart = 0;
            customTextBoxSifre.Size = new System.Drawing.Size(268, 32);
            customTextBoxSifre.TabIndex = 30;
            customTextBoxSifre.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxSifre.TextCustom = "";
            customTextBoxSifre.UnderlinedStyle = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(272, 120);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(18, 30);
            label1.TabIndex = 29;
            label1.Text = ":";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSifre
            // 
            labelSifre.AutoSize = true;
            labelSifre.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelSifre.Location = new System.Drawing.Point(6, 120);
            labelSifre.Name = "labelSifre";
            labelSifre.Size = new System.Drawing.Size(55, 30);
            labelSifre.TabIndex = 28;
            labelSifre.Text = "Şifre";
            labelSifre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customTextBoxSifreTekrar
            // 
            customTextBoxSifreTekrar.BackColor = System.Drawing.Color.White;
            customTextBoxSifreTekrar.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxSifreTekrar.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxSifreTekrar.BorderRadius = 0;
            customTextBoxSifreTekrar.BorderSize = 2;
            customTextBoxSifreTekrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxSifreTekrar.ForeColor = System.Drawing.Color.Black;
            customTextBoxSifreTekrar.isPlaceHolder = false;
            customTextBoxSifreTekrar.Location = new System.Drawing.Point(296, 155);
            customTextBoxSifreTekrar.Multiline = false;
            customTextBoxSifreTekrar.Name = "customTextBoxSifreTekrar";
            customTextBoxSifreTekrar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxSifreTekrar.PasswordChar = true;
            customTextBoxSifreTekrar.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxSifreTekrar.PlaceholderText = "";
            customTextBoxSifreTekrar.ReadOnly = false;
            customTextBoxSifreTekrar.SelectionStart = 0;
            customTextBoxSifreTekrar.Size = new System.Drawing.Size(268, 32);
            customTextBoxSifreTekrar.TabIndex = 33;
            customTextBoxSifreTekrar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxSifreTekrar.TextCustom = "";
            customTextBoxSifreTekrar.UnderlinedStyle = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(272, 156);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(18, 30);
            label3.TabIndex = 32;
            label3.Text = ":";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSifreTekrar
            // 
            labelSifreTekrar.AutoSize = true;
            labelSifreTekrar.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelSifreTekrar.Location = new System.Drawing.Point(6, 156);
            labelSifreTekrar.Name = "labelSifreTekrar";
            labelSifreTekrar.Size = new System.Drawing.Size(120, 30);
            labelSifreTekrar.TabIndex = 31;
            labelSifreTekrar.Text = "Şifre Tekrar";
            labelSifreTekrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboListBoxRol
            // 
            comboListBoxRol.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxRol.ListBoxVisualSize = 5;
            comboListBoxRol.Location = new System.Drawing.Point(296, 229);
            comboListBoxRol.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxRol.Name = "comboListBoxRol";
            comboListBoxRol.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxRol.Size = new System.Drawing.Size(204, 36);
            comboListBoxRol.TabIndex = 51;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(272, 230);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(18, 30);
            label7.TabIndex = 50;
            label7.Text = ":";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPersonel
            // 
            labelPersonel.AutoSize = true;
            labelPersonel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelPersonel.Location = new System.Drawing.Point(6, 230);
            labelPersonel.Name = "labelPersonel";
            labelPersonel.Size = new System.Drawing.Size(43, 30);
            labelPersonel.TabIndex = 49;
            labelPersonel.Text = "Rol";
            labelPersonel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxPersonel
            // 
            cbxPersonel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxPersonel.ListBoxVisualSize = 5;
            cbxPersonel.Location = new System.Drawing.Point(296, 191);
            cbxPersonel.Margin = new System.Windows.Forms.Padding(1);
            cbxPersonel.Name = "cbxPersonel";
            cbxPersonel.Padding = new System.Windows.Forms.Padding(1);
            cbxPersonel.Size = new System.Drawing.Size(378, 36);
            cbxPersonel.TabIndex = 54;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(272, 192);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(18, 30);
            label4.TabIndex = 53;
            label4.Text = ":";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(6, 192);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(93, 30);
            label5.TabIndex = 52;
            label5.Text = "Personel";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonFiltre
            // 
            buttonFiltre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonFiltre.BackgroundImage = Properties.Resources.pngegg;
            buttonFiltre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonFiltre.Location = new System.Drawing.Point(48, 281);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(34, 32);
            buttonFiltre.TabIndex = 56;
            buttonFiltre.UseVisualStyleBackColor = true;
            buttonFiltre.Click += buttonFiltre_Click;
            // 
            // labelUyariKulllaniciAdi
            // 
            labelUyariKulllaniciAdi.AutoSize = true;
            labelUyariKulllaniciAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariKulllaniciAdi.ForeColor = System.Drawing.Color.Red;
            labelUyariKulllaniciAdi.Location = new System.Drawing.Point(570, 90);
            labelUyariKulllaniciAdi.Name = "labelUyariKulllaniciAdi";
            labelUyariKulllaniciAdi.Size = new System.Drawing.Size(0, 15);
            labelUyariKulllaniciAdi.TabIndex = 91;
            // 
            // labelUyariSifre
            // 
            labelUyariSifre.AutoSize = true;
            labelUyariSifre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariSifre.ForeColor = System.Drawing.Color.Red;
            labelUyariSifre.Location = new System.Drawing.Point(570, 129);
            labelUyariSifre.Name = "labelUyariSifre";
            labelUyariSifre.Size = new System.Drawing.Size(0, 15);
            labelUyariSifre.TabIndex = 92;
            // 
            // labelUyariSifreTekrar
            // 
            labelUyariSifreTekrar.AutoSize = true;
            labelUyariSifreTekrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariSifreTekrar.ForeColor = System.Drawing.Color.Red;
            labelUyariSifreTekrar.Location = new System.Drawing.Point(570, 164);
            labelUyariSifreTekrar.Name = "labelUyariSifreTekrar";
            labelUyariSifreTekrar.Size = new System.Drawing.Size(0, 15);
            labelUyariSifreTekrar.TabIndex = 93;
            // 
            // labelUyariPersonel
            // 
            labelUyariPersonel.AutoSize = true;
            labelUyariPersonel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariPersonel.ForeColor = System.Drawing.Color.Red;
            labelUyariPersonel.Location = new System.Drawing.Point(678, 197);
            labelUyariPersonel.Name = "labelUyariPersonel";
            labelUyariPersonel.Size = new System.Drawing.Size(0, 15);
            labelUyariPersonel.TabIndex = 94;
            // 
            // labelUyariRol
            // 
            labelUyariRol.AutoSize = true;
            labelUyariRol.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariRol.ForeColor = System.Drawing.Color.Red;
            labelUyariRol.Location = new System.Drawing.Point(504, 235);
            labelUyariRol.Name = "labelUyariRol";
            labelUyariRol.Size = new System.Drawing.Size(0, 15);
            labelUyariRol.TabIndex = 95;
            // 
            // button1
            // 
            button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button1.Location = new System.Drawing.Point(781, 47);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(101, 28);
            button1.TabIndex = 96;
            button1.Text = "Formu Temizle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            headerPanel1.Size = new System.Drawing.Size(924, 32);
            headerPanel1.TabIndex = 97;
            // 
            // universalGrid1
            // 
            universalGrid1.kullanici = null;
            universalGrid1.Location = new System.Drawing.Point(48, 319);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(819, 291);
            universalGrid1.TabIndex = 98;
            // 
            // KullaniciKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(924, 673);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            Controls.Add(button1);
            Controls.Add(labelUyariRol);
            Controls.Add(labelUyariPersonel);
            Controls.Add(labelUyariSifreTekrar);
            Controls.Add(labelUyariSifre);
            Controls.Add(labelUyariKulllaniciAdi);
            Controls.Add(buttonFiltre);
            Controls.Add(cbxPersonel);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(comboListBoxRol);
            Controls.Add(label7);
            Controls.Add(labelPersonel);
            Controls.Add(customTextBoxSifreTekrar);
            Controls.Add(label3);
            Controls.Add(labelSifreTekrar);
            Controls.Add(customTextBoxSifre);
            Controls.Add(label1);
            Controls.Add(labelSifre);
            Controls.Add(textBoxKullaniciAdi);
            Controls.Add(label2);
            Controls.Add(labelKullaniciAdi);
            Controls.Add(rButtonKullaniciKaydet);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "KullaniciKayitFormu";
            Text = "KullaniciKayitFormu";
            FormClosing += KullaniciKayitFormu_FormClosing;
            Load += KullaniciKayitFormu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CustomControls.RoundedButton rButtonKullaniciKaydet;
        public CustomControls.CustomTextBox textBoxKullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelKullaniciAdi;
        public CustomControls.CustomTextBox customTextBoxSifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSifre;
        public CustomControls.CustomTextBox customTextBoxSifreTekrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSifreTekrar;
        private CustomControls.CustomComboListBox comboListBoxRol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelPersonel;
        private CustomControls.CustomComboListBox cbxPersonel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonFiltre;
        private System.Windows.Forms.Label labelUyariKulllaniciAdi;
        private System.Windows.Forms.Label labelUyariSifre;
        private System.Windows.Forms.Label labelUyariSifreTekrar;
        private System.Windows.Forms.Label labelUyariPersonel;
        private System.Windows.Forms.Label labelUyariRol;
        private System.Windows.Forms.Button button1;
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
    }
}