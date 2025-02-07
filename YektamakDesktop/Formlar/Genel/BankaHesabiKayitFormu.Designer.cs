namespace YektamakDesktop.Formlar.Genel
{
    partial class BankaHesabiKayitFormu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankaHesabiKayitFormu));
            comboBoxHesapSahibiFirma = new CustomControls.CustomComboListBox();
            comboListBoxDovizTuru = new CustomControls.CustomComboListBox();
            comboBoxBanka = new CustomControls.CustomComboListBox();
            labelBankaUyari = new System.Windows.Forms.Label();
            labelIBANPrefix = new System.Windows.Forms.Label();
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            rButtonKapat = new CustomControls.RoundedButton();
            rButtonGuncelle = new CustomControls.RoundedButton();
            rButtonKaydet = new CustomControls.RoundedButton();
            label11 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            textBoxIBAN = new CustomControls.CustomTextBox();
            textBoxHesapAdi = new CustomControls.CustomTextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            labelIBANUyari = new System.Windows.Forms.Label();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxHesapSahibiFirma
            // 
            comboBoxHesapSahibiFirma.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboBoxHesapSahibiFirma.Enabled = false;
            comboBoxHesapSahibiFirma.ListBoxVisualSize = 5;
            comboBoxHesapSahibiFirma.Location = new System.Drawing.Point(252, 253);
            comboBoxHesapSahibiFirma.Margin = new System.Windows.Forms.Padding(1);
            comboBoxHesapSahibiFirma.Name = "comboBoxHesapSahibiFirma";
            comboBoxHesapSahibiFirma.Padding = new System.Windows.Forms.Padding(1);
            comboBoxHesapSahibiFirma.Size = new System.Drawing.Size(453, 36);
            comboBoxHesapSahibiFirma.TabIndex = 54;
            // 
            // comboListBoxDovizTuru
            // 
            comboListBoxDovizTuru.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxDovizTuru.ListBoxVisualSize = 5;
            comboListBoxDovizTuru.Location = new System.Drawing.Point(251, 208);
            comboListBoxDovizTuru.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxDovizTuru.Name = "comboListBoxDovizTuru";
            comboListBoxDovizTuru.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxDovizTuru.Size = new System.Drawing.Size(69, 36);
            comboListBoxDovizTuru.TabIndex = 52;
            // 
            // comboListBoxBankalar
            // 
            comboBoxBanka.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboBoxBanka.ListBoxVisualSize = 5;
            comboBoxBanka.Location = new System.Drawing.Point(252, 298);
            comboBoxBanka.Margin = new System.Windows.Forms.Padding(1);
            comboBoxBanka.Name = "comboListBoxBankalar";
            comboBoxBanka.Padding = new System.Windows.Forms.Padding(1);
            comboBoxBanka.Size = new System.Drawing.Size(251, 36);
            comboBoxBanka.TabIndex = 51;
            // 
            // labelBankaUyari
            // 
            labelBankaUyari.AutoSize = true;
            labelBankaUyari.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelBankaUyari.ForeColor = System.Drawing.Color.Red;
            labelBankaUyari.Location = new System.Drawing.Point(508, 306);
            labelBankaUyari.Name = "labelBankaUyari";
            labelBankaUyari.Size = new System.Drawing.Size(0, 15);
            labelBankaUyari.TabIndex = 50;
            // 
            // labelIBANPrefix
            // 
            labelIBANPrefix.AutoSize = true;
            labelIBANPrefix.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelIBANPrefix.Location = new System.Drawing.Point(248, 164);
            labelIBANPrefix.Name = "labelIBANPrefix";
            labelIBANPrefix.Size = new System.Drawing.Size(38, 30);
            labelIBANPrefix.TabIndex = 48;
            labelIBANPrefix.Text = "TR";
            labelIBANPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelHeader
            // 
            panelHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            panelHeader.BackColor = System.Drawing.Color.Red;
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Location = new System.Drawing.Point(1, -1);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(938, 47);
            panelHeader.TabIndex = 22;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = System.Drawing.Color.Red;
            buttonClose.BackgroundColor = System.Drawing.Color.Red;
            buttonClose.BorderColor = System.Drawing.Color.LavenderBlush;
            buttonClose.BorderRadius = 10;
            buttonClose.BorderSize = 2;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonClose.ForeColor = System.Drawing.Color.White;
            buttonClose.Location = new System.Drawing.Point(890, 4);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(40, 38);
            buttonClose.TabIndex = 106;
            buttonClose.Text = "x";
            buttonClose.TextColor = System.Drawing.Color.White;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.BackColor = System.Drawing.Color.Red;
            buttonHelp.BackgroundColor = System.Drawing.Color.Red;
            buttonHelp.BorderColor = System.Drawing.Color.LavenderBlush;
            buttonHelp.BorderRadius = 10;
            buttonHelp.BorderSize = 2;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonHelp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonHelp.ForeColor = System.Drawing.Color.White;
            buttonHelp.Location = new System.Drawing.Point(810, 4);
            buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonHelp.Size = new System.Drawing.Size(40, 38);
            buttonHelp.TabIndex = 105;
            buttonHelp.Text = "?";
            buttonHelp.TextColor = System.Drawing.Color.White;
            buttonHelp.UseVisualStyleBackColor = false;
            // 
            // buttomMinimize
            // 
            buttomMinimize.BackColor = System.Drawing.Color.Red;
            buttomMinimize.BackgroundColor = System.Drawing.Color.Red;
            buttomMinimize.BorderColor = System.Drawing.Color.LavenderBlush;
            buttomMinimize.BorderRadius = 10;
            buttomMinimize.BorderSize = 2;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttomMinimize.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttomMinimize.ForeColor = System.Drawing.Color.White;
            buttomMinimize.Location = new System.Drawing.Point(850, 4);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(40, 38);
            buttomMinimize.TabIndex = 104;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            labelHeader.Location = new System.Drawing.Point(3, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(201, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Banka Hesabı Kayıt";
            // 
            // rButtonKapat
            // 
            rButtonKapat.BackColor = System.Drawing.Color.Brown;
            rButtonKapat.BackgroundColor = System.Drawing.Color.Brown;
            rButtonKapat.BorderColor = System.Drawing.Color.Crimson;
            rButtonKapat.BorderRadius = 40;
            rButtonKapat.BorderSize = 5;
            rButtonKapat.FlatAppearance.BorderSize = 0;
            rButtonKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonKapat.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonKapat.ForeColor = System.Drawing.Color.White;
            rButtonKapat.Location = new System.Drawing.Point(236, 379);
            rButtonKapat.Name = "rButtonKapat";
            rButtonKapat.Size = new System.Drawing.Size(150, 66);
            rButtonKapat.TabIndex = 21;
            rButtonKapat.Text = "KAPAT";
            rButtonKapat.TextColor = System.Drawing.Color.White;
            rButtonKapat.UseVisualStyleBackColor = false;
            rButtonKapat.Click += rButtonKapat_Click;
            // 
            // rButtonGuncelle
            // 
            rButtonGuncelle.BackColor = System.Drawing.Color.CornflowerBlue;
            rButtonGuncelle.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            rButtonGuncelle.BorderColor = System.Drawing.Color.RoyalBlue;
            rButtonGuncelle.BorderRadius = 40;
            rButtonGuncelle.BorderSize = 5;
            rButtonGuncelle.FlatAppearance.BorderSize = 0;
            rButtonGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonGuncelle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonGuncelle.ForeColor = System.Drawing.Color.White;
            rButtonGuncelle.Location = new System.Drawing.Point(75, 379);
            rButtonGuncelle.Name = "rButtonGuncelle";
            rButtonGuncelle.Size = new System.Drawing.Size(150, 66);
            rButtonGuncelle.TabIndex = 20;
            rButtonGuncelle.Text = "GÜNCELLE";
            rButtonGuncelle.TextColor = System.Drawing.Color.White;
            rButtonGuncelle.UseVisualStyleBackColor = false;
            rButtonGuncelle.Click += rButtonGuncelle_Click;
            // 
            // rButtonKaydet
            // 
            rButtonKaydet.BackColor = System.Drawing.Color.LimeGreen;
            rButtonKaydet.BackgroundColor = System.Drawing.Color.LimeGreen;
            rButtonKaydet.BorderColor = System.Drawing.Color.MediumSeaGreen;
            rButtonKaydet.BorderRadius = 40;
            rButtonKaydet.BorderSize = 5;
            rButtonKaydet.FlatAppearance.BorderSize = 0;
            rButtonKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonKaydet.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonKaydet.ForeColor = System.Drawing.Color.White;
            rButtonKaydet.Location = new System.Drawing.Point(75, 379);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new System.Drawing.Size(150, 66);
            rButtonKaydet.TabIndex = 19;
            rButtonKaydet.Text = "KAYDET";
            rButtonKaydet.TextColor = System.Drawing.Color.White;
            rButtonKaydet.UseVisualStyleBackColor = false;
            rButtonKaydet.Click += rButtonKaydet_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label11.Location = new System.Drawing.Point(228, 298);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(18, 30);
            label11.TabIndex = 14;
            label11.Text = ":";
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label9.Location = new System.Drawing.Point(76, 298);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(71, 30);
            label9.TabIndex = 12;
            label9.Text = "Banka";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(228, 253);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(18, 30);
            label7.TabIndex = 10;
            label7.Text = ":";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(76, 253);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(135, 30);
            label8.TabIndex = 9;
            label8.Text = "Hesap Sahibi";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(228, 208);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(18, 30);
            label6.TabIndex = 7;
            label6.Text = ":";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(76, 208);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(115, 30);
            label5.TabIndex = 6;
            label5.Text = "Döviz Türü";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxIBAN
            // 
            textBoxIBAN.BackColor = System.Drawing.Color.White;
            textBoxIBAN.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxIBAN.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxIBAN.BorderRadius = 0;
            textBoxIBAN.BorderSize = 2;
            textBoxIBAN.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBoxIBAN.ForeColor = System.Drawing.Color.Black;
            textBoxIBAN.isPlaceHolder = false;
            textBoxIBAN.Location = new System.Drawing.Point(291, 163);
            textBoxIBAN.Multiline = false;
            textBoxIBAN.Name = "textBoxIBAN";
            textBoxIBAN.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxIBAN.PasswordChar = false;
            textBoxIBAN.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxIBAN.PlaceholderText = "";
            textBoxIBAN.ReadOnly = false;
            textBoxIBAN.SelectionStart = 0;
            textBoxIBAN.Size = new System.Drawing.Size(341, 40);
            textBoxIBAN.TabIndex = 5;
            textBoxIBAN.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxIBAN.TextCustom = "";
            textBoxIBAN.UnderlinedStyle = false;
            textBoxIBAN.TextChanged += textBoxIBAN_TextChanged;
            textBoxIBAN.Load += textBoxIBAN_Load;
            // 
            // textBoxHesapAdi
            // 
            textBoxHesapAdi.BackColor = System.Drawing.Color.White;
            textBoxHesapAdi.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxHesapAdi.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxHesapAdi.BorderRadius = 0;
            textBoxHesapAdi.BorderSize = 2;
            textBoxHesapAdi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxHesapAdi.ForeColor = System.Drawing.Color.Black;
            textBoxHesapAdi.isPlaceHolder = false;
            textBoxHesapAdi.Location = new System.Drawing.Point(252, 117);
            textBoxHesapAdi.Multiline = false;
            textBoxHesapAdi.Name = "textBoxHesapAdi";
            textBoxHesapAdi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxHesapAdi.PasswordChar = false;
            textBoxHesapAdi.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxHesapAdi.PlaceholderText = "";
            textBoxHesapAdi.ReadOnly = false;
            textBoxHesapAdi.SelectionStart = 0;
            textBoxHesapAdi.Size = new System.Drawing.Size(380, 32);
            textBoxHesapAdi.TabIndex = 4;
            textBoxHesapAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxHesapAdi.TextCustom = "";
            textBoxHesapAdi.UnderlinedStyle = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(228, 163);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(18, 30);
            label3.TabIndex = 3;
            label3.Text = ":";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(76, 163);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(62, 30);
            label4.TabIndex = 2;
            label4.Text = "IBAN";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(228, 118);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(18, 30);
            label2.TabIndex = 1;
            label2.Text = ":";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(76, 118);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(110, 30);
            label1.TabIndex = 0;
            label1.Text = "Hesap Adı";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelIBANUyari
            // 
            labelIBANUyari.AutoSize = true;
            labelIBANUyari.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelIBANUyari.ForeColor = System.Drawing.Color.Red;
            labelIBANUyari.Location = new System.Drawing.Point(653, 178);
            labelIBANUyari.Name = "labelIBANUyari";
            labelIBANUyari.Size = new System.Drawing.Size(0, 15);
            labelIBANUyari.TabIndex = 55;
            // 
            // BankaHesabiKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(938, 513);
            Controls.Add(labelIBANUyari);
            Controls.Add(comboBoxHesapSahibiFirma);
            Controls.Add(panelHeader);
            Controls.Add(comboListBoxDovizTuru);
            Controls.Add(label1);
            Controls.Add(comboBoxBanka);
            Controls.Add(label2);
            Controls.Add(labelBankaUyari);
            Controls.Add(label4);
            Controls.Add(labelIBANPrefix);
            Controls.Add(label3);
            Controls.Add(textBoxHesapAdi);
            Controls.Add(textBoxIBAN);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(rButtonKapat);
            Controls.Add(label9);
            Controls.Add(rButtonGuncelle);
            Controls.Add(label11);
            Controls.Add(rButtonKaydet);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "BankaHesabiKayitFormu";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PersonelKayit";
            Load += BankaHesabiKayitFormu_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private CustomControls.RoundedButton rButtonKapat;
        private CustomControls.RoundedButton rButtonGuncelle;
        private CustomControls.RoundedButton rButtonKaydet;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        public CustomControls.CustomTextBox textBoxHesapAdi;
        public CustomControls.CustomTextBox textBoxIBAN;
        private System.Windows.Forms.Label labelIBANPrefix;
        private System.Windows.Forms.Label labelBankaUyari;
        private CustomControls.CustomComboListBox comboBoxBanka;
        private CustomControls.CustomComboListBox comboListBoxDovizTuru;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private CustomControls.CustomComboListBox comboBoxHesapSahibiFirma;
        private System.Windows.Forms.Label labelIBANUyari;
    }
}