namespace YektamakDesktop.Formlar.Satinalma.Siparis
{
    partial class SatinalmaSiparisKayitFormu
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
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            ctbId = new YektamakDesktop.CustomControls.CustomTextBox();
            ctbSiparisTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            ctbTeslimTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            fcbFirmaId = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbVadeId = new YektamakDesktop.CustomControls.FilterableComboBox();
            ctbAciklama = new YektamakDesktop.CustomControls.CustomTextBox();
            ctbSiparisNo = new YektamakDesktop.CustomControls.CustomTextBox();
            fcbKdv = new YektamakDesktop.CustomControls.FilterableComboBox();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            ctbTutar = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            label9 = new System.Windows.Forms.Label();
            fcbDovizCinsi = new YektamakDesktop.CustomControls.FilterableComboBox();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Satınalma Sipariş Kayıt";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(920, 25);
            headerPanel1.TabIndex = 0;
            // 
            // ctbId
            // 
            ctbId.BackColor = System.Drawing.SystemColors.Window;
            ctbId.BorderColor = System.Drawing.Color.Silver;
            ctbId.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbId.BorderSize = 1;
            ctbId.Enabled = false;
            ctbId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbId.ForeColor = System.Drawing.Color.DimGray;
            ctbId.Location = new System.Drawing.Point(104, 57);
            ctbId.Margin = new System.Windows.Forms.Padding(1);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbId.PasswordChar = false;
            ctbId.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbId.PlaceholderText = "";
            ctbId.ReadOnly = false;
            ctbId.SelectionStart = 0;
            ctbId.Size = new System.Drawing.Size(49, 33);
            ctbId.TabIndex = 1;
            ctbId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbId.TextCustom = "";
            ctbId.UnderlinedStyle = false;
            // 
            // ctbSiparisTarihi
            // 
            ctbSiparisTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbSiparisTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbSiparisTarihi.Location = new System.Drawing.Point(104, 123);
            ctbSiparisTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbSiparisTarihi.Name = "ctbSiparisTarihi";
            ctbSiparisTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbSiparisTarihi.Size = new System.Drawing.Size(145, 32);
            ctbSiparisTarihi.TabIndex = 2;
            // 
            // ctbTeslimTarihi
            // 
            ctbTeslimTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbTeslimTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTeslimTarihi.Location = new System.Drawing.Point(104, 157);
            ctbTeslimTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbTeslimTarihi.Name = "ctbTeslimTarihi";
            ctbTeslimTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbTeslimTarihi.Size = new System.Drawing.Size(145, 32);
            ctbTeslimTarihi.TabIndex = 3;
            // 
            // fcbFirmaId
            // 
            fcbFirmaId.BorderColor = System.Drawing.Color.Silver;
            fcbFirmaId.BorderRadius = 8;
            fcbFirmaId.BorderSize = 1;
            fcbFirmaId.DisplayMember = "ad";
            fcbFirmaId.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbFirmaId.Location = new System.Drawing.Point(104, 193);
            fcbFirmaId.Margin = new System.Windows.Forms.Padding(1);
            fcbFirmaId.Name = "fcbFirmaId";
            fcbFirmaId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbFirmaId.PlaceholderText = "Seçiniz...";
            fcbFirmaId.Size = new System.Drawing.Size(427, 29);
            fcbFirmaId.TabIndex = 4;
            fcbFirmaId.ValueMember = "Id";
            // 
            // fcbVadeId
            // 
            fcbVadeId.BorderColor = System.Drawing.Color.Silver;
            fcbVadeId.BorderRadius = 8;
            fcbVadeId.BorderSize = 1;
            fcbVadeId.DisplayMember = "ad";
            fcbVadeId.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbVadeId.Location = new System.Drawing.Point(104, 228);
            fcbVadeId.Margin = new System.Windows.Forms.Padding(1);
            fcbVadeId.Name = "fcbVadeId";
            fcbVadeId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbVadeId.PlaceholderText = "Seçiniz...";
            fcbVadeId.Size = new System.Drawing.Size(119, 29);
            fcbVadeId.TabIndex = 5;
            fcbVadeId.ValueMember = "Id";
            // 
            // ctbAciklama
            // 
            ctbAciklama.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ctbAciklama.BackColor = System.Drawing.SystemColors.Window;
            ctbAciklama.BorderColor = System.Drawing.Color.Silver;
            ctbAciklama.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbAciklama.BorderSize = 1;
            ctbAciklama.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbAciklama.ForeColor = System.Drawing.Color.DimGray;
            ctbAciklama.Location = new System.Drawing.Point(595, 234);
            ctbAciklama.Margin = new System.Windows.Forms.Padding(1);
            ctbAciklama.Multiline = true;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbAciklama.PasswordChar = false;
            ctbAciklama.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAciklama.PlaceholderText = "";
            ctbAciklama.ReadOnly = false;
            ctbAciklama.SelectionStart = 0;
            ctbAciklama.Size = new System.Drawing.Size(302, 104);
            ctbAciklama.TabIndex = 6;
            ctbAciklama.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbAciklama.TextCustom = "";
            ctbAciklama.UnderlinedStyle = false;
            // 
            // ctbSiparisNo
            // 
            ctbSiparisNo.BackColor = System.Drawing.SystemColors.Window;
            ctbSiparisNo.BorderColor = System.Drawing.Color.Silver;
            ctbSiparisNo.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbSiparisNo.BorderSize = 1;
            ctbSiparisNo.Enabled = false;
            ctbSiparisNo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbSiparisNo.ForeColor = System.Drawing.Color.DimGray;
            ctbSiparisNo.Location = new System.Drawing.Point(104, 91);
            ctbSiparisNo.Margin = new System.Windows.Forms.Padding(1);
            ctbSiparisNo.Multiline = false;
            ctbSiparisNo.Name = "ctbSiparisNo";
            ctbSiparisNo.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbSiparisNo.PasswordChar = false;
            ctbSiparisNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbSiparisNo.PlaceholderText = "";
            ctbSiparisNo.ReadOnly = false;
            ctbSiparisNo.SelectionStart = 0;
            ctbSiparisNo.Size = new System.Drawing.Size(104, 33);
            ctbSiparisNo.TabIndex = 7;
            ctbSiparisNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbSiparisNo.TextCustom = "";
            ctbSiparisNo.UnderlinedStyle = false;
            // 
            // fcbKdv
            // 
            fcbKdv.BorderColor = System.Drawing.Color.Silver;
            fcbKdv.BorderRadius = 8;
            fcbKdv.BorderSize = 1;
            fcbKdv.DisplayMember = "ad";
            fcbKdv.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbKdv.Location = new System.Drawing.Point(104, 263);
            fcbKdv.Margin = new System.Windows.Forms.Padding(1);
            fcbKdv.Name = "fcbKdv";
            fcbKdv.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbKdv.PlaceholderText = "Seçiniz...";
            fcbKdv.Size = new System.Drawing.Size(119, 29);
            fcbKdv.TabIndex = 8;
            fcbKdv.ValueMember = "Id";
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(12, 343);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(896, 430);
            universalGrid1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(16, 63);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 15);
            label1.TabIndex = 10;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(16, 97);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(60, 15);
            label2.TabIndex = 11;
            label2.Text = "Sipariş No";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(16, 129);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 15);
            label3.TabIndex = 12;
            label3.Text = "Sipariş Tarihi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(16, 163);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(71, 15);
            label4.TabIndex = 13;
            label4.Text = "Teslim Tarihi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(16, 199);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(37, 15);
            label5.TabIndex = 14;
            label5.Text = "Firma";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(16, 234);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(32, 15);
            label6.TabIndex = 15;
            label6.Text = "Vade";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(16, 269);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(27, 15);
            label7.TabIndex = 16;
            label7.Text = "Kdv";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(595, 216);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(56, 15);
            label8.TabIndex = 17;
            label8.Text = "Açıklama";
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(782, 779);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 18;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // ctbTutar
            // 
            ctbTutar.BackColor = System.Drawing.SystemColors.Window;
            ctbTutar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbTutar.ForeColor = System.Drawing.Color.DimGray;
            ctbTutar.Location = new System.Drawing.Point(104, 298);
            ctbTutar.Margin = new System.Windows.Forms.Padding(1);
            ctbTutar.Name = "ctbTutar";
            ctbTutar.OndalikBasamak = 0;
            ctbTutar.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbTutar.Size = new System.Drawing.Size(119, 33);
            ctbTutar.TabIndex = 19;
            ctbTutar.TextCustom = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(16, 304);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(34, 15);
            label9.TabIndex = 20;
            label9.Text = "Tutar";
            // 
            // fcbDovizCinsi
            // 
            fcbDovizCinsi.BorderColor = System.Drawing.Color.Silver;
            fcbDovizCinsi.BorderRadius = 8;
            fcbDovizCinsi.BorderSize = 1;
            fcbDovizCinsi.DisplayMember = "ad";
            fcbDovizCinsi.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbDovizCinsi.Location = new System.Drawing.Point(231, 297);
            fcbDovizCinsi.Margin = new System.Windows.Forms.Padding(1);
            fcbDovizCinsi.Name = "fcbDovizCinsi";
            fcbDovizCinsi.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbDovizCinsi.PlaceholderText = "Seçiniz...";
            fcbDovizCinsi.Size = new System.Drawing.Size(106, 29);
            fcbDovizCinsi.TabIndex = 21;
            fcbDovizCinsi.ValueMember = "Id";
            // 
            // SatinalmaSiparisKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(920, 831);
            Controls.Add(fcbDovizCinsi);
            Controls.Add(label9);
            Controls.Add(ctbTutar);
            Controls.Add(customButtonSave1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(universalGrid1);
            Controls.Add(fcbKdv);
            Controls.Add(ctbSiparisNo);
            Controls.Add(ctbAciklama);
            Controls.Add(fcbVadeId);
            Controls.Add(fcbFirmaId);
            Controls.Add(ctbTeslimTarihi);
            Controls.Add(ctbSiparisTarihi);
            Controls.Add(ctbId);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaSiparisKayitFormu";
            Text = "SatinalmaSiparisKayitFormu";
            FormClosing += SatinalmaSiparisKayitFormu_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBox ctbId;
        private CustomControls.CustomTextBoxTarih ctbSiparisTarihi;
        private CustomControls.CustomTextBoxTarih ctbTeslimTarihi;
        private CustomControls.FilterableComboBox fcbFirmaId;
        private CustomControls.FilterableComboBox fcbVadeId;
        private CustomControls.CustomTextBox ctbAciklama;
        private CustomControls.CustomTextBox ctbSiparisNo;
        private CustomControls.FilterableComboBox fcbKdv;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.CustomTextBoxSayisal ctbTutar;
        private System.Windows.Forms.Label label9;
        private CustomControls.FilterableComboBox fcbDovizCinsi;
    }
}