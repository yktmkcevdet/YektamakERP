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
            fcbFirmaId = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbVadeId = new YektamakDesktop.CustomControls.FilterableComboBox();
            ctbAciklama = new YektamakDesktop.CustomControls.CustomTextBox();
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
            label9 = new System.Windows.Forms.Label();
            fcbDovizCinsi = new YektamakDesktop.CustomControls.FilterableComboBox();
            ctbId = new YektamakDesktop.CustomControls.CustomTextBox();
            ctbSiparisNo = new YektamakDesktop.CustomControls.CustomTextBox();
            ctbSiparisTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            ctbTeslimTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            fcbProjeKod = new YektamakDesktop.CustomControls.FilterableComboBox();
            label10 = new System.Windows.Forms.Label();
            ctbTutar = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            fcbMalzemeGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            label11 = new System.Windows.Forms.Label();
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
            // fcbFirmaId
            // 
            fcbFirmaId.BorderColor = System.Drawing.Color.Silver;
            fcbFirmaId.BorderRadius = 8;
            fcbFirmaId.BorderSize = 1;
            fcbFirmaId.DisplayMember = "ad";
            fcbFirmaId.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbFirmaId.Location = new System.Drawing.Point(111, 197);
            fcbFirmaId.Margin = new System.Windows.Forms.Padding(1);
            fcbFirmaId.Name = "fcbFirmaId";
            fcbFirmaId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbFirmaId.PlaceholderText = "Seçiniz...";
            fcbFirmaId.ReadOnly = false;
            fcbFirmaId.Size = new System.Drawing.Size(427, 25);
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
            fcbVadeId.Location = new System.Drawing.Point(111, 224);
            fcbVadeId.Margin = new System.Windows.Forms.Padding(1);
            fcbVadeId.Name = "fcbVadeId";
            fcbVadeId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbVadeId.PlaceholderText = "Seçiniz...";
            fcbVadeId.ReadOnly = false;
            fcbVadeId.Size = new System.Drawing.Size(119, 25);
            fcbVadeId.TabIndex = 5;
            fcbVadeId.ValueMember = "Id";
            // 
            // ctbAciklama
            // 
            ctbAciklama.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ctbAciklama.BackColor = System.Drawing.Color.White;
            ctbAciklama.BorderColor = System.Drawing.Color.Silver;
            ctbAciklama.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbAciklama.BorderSize = 1;
            ctbAciklama.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbAciklama.ForeColor = System.Drawing.Color.Black;
            ctbAciklama.Location = new System.Drawing.Point(503, 63);
            ctbAciklama.Margin = new System.Windows.Forms.Padding(1);
            ctbAciklama.Multiline = true;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbAciklama.PasswordChar = false;
            ctbAciklama.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAciklama.PlaceholderText = "";
            ctbAciklama.ReadOnly = false;
            ctbAciklama.SelectionStart = 0;
            ctbAciklama.Size = new System.Drawing.Size(405, 93);
            ctbAciklama.TabIndex = 6;
            ctbAciklama.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbAciklama.TextCustom = "";
            ctbAciklama.UnderlinedStyle = false;
            // 
            // fcbKdv
            // 
            fcbKdv.BorderColor = System.Drawing.Color.Silver;
            fcbKdv.BorderRadius = 8;
            fcbKdv.BorderSize = 1;
            fcbKdv.DisplayMember = "ad";
            fcbKdv.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbKdv.Location = new System.Drawing.Point(111, 251);
            fcbKdv.Margin = new System.Windows.Forms.Padding(1);
            fcbKdv.Name = "fcbKdv";
            fcbKdv.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbKdv.PlaceholderText = "Seçiniz...";
            fcbKdv.ReadOnly = false;
            fcbKdv.Size = new System.Drawing.Size(119, 25);
            fcbKdv.TabIndex = 8;
            fcbKdv.ValueMember = "Id";
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(12, 325);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(896, 430);
            universalGrid1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(16, 45);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 15);
            label1.TabIndex = 10;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(16, 72);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 15);
            label2.TabIndex = 11;
            label2.Text = "Sipariş No";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(16, 99);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(76, 15);
            label3.TabIndex = 12;
            label3.Text = "Sipariş Tarihi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(16, 126);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(75, 15);
            label4.TabIndex = 13;
            label4.Text = "Teslim Tarihi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(16, 207);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(38, 15);
            label5.TabIndex = 14;
            label5.Text = "Firma";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(16, 233);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(34, 15);
            label6.TabIndex = 15;
            label6.Text = "Vade";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(16, 261);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(29, 15);
            label7.TabIndex = 16;
            label7.Text = "Kdv";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label8.Location = new System.Drawing.Point(503, 47);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(57, 15);
            label8.TabIndex = 17;
            label8.Text = "Açıklama";
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.BorderColor = System.Drawing.Color.Black;
            customButtonSave1.BorderSize = 0;
            customButtonSave1.CornerRadius = 6;
            customButtonSave1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            customButtonSave1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            customButtonSave1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            customButtonSave1.HoverColor2 = System.Drawing.Color.Navy;
            customButtonSave1.Location = new System.Drawing.Point(782, 779);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 18;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label9.Location = new System.Drawing.Point(16, 288);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(36, 15);
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
            fcbDovizCinsi.Location = new System.Drawing.Point(204, 277);
            fcbDovizCinsi.Margin = new System.Windows.Forms.Padding(1);
            fcbDovizCinsi.Name = "fcbDovizCinsi";
            fcbDovizCinsi.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbDovizCinsi.PlaceholderText = "Seçiniz...";
            fcbDovizCinsi.ReadOnly = false;
            fcbDovizCinsi.Size = new System.Drawing.Size(106, 25);
            fcbDovizCinsi.TabIndex = 21;
            fcbDovizCinsi.ValueMember = "Id";
            // 
            // ctbId
            // 
            ctbId.BackColor = System.Drawing.Color.White;
            ctbId.BorderColor = System.Drawing.Color.Silver;
            ctbId.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbId.BorderSize = 1;
            ctbId.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbId.ForeColor = System.Drawing.Color.Black;
            ctbId.Location = new System.Drawing.Point(111, 35);
            ctbId.Margin = new System.Windows.Forms.Padding(1);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new System.Windows.Forms.Padding(3);
            ctbId.PasswordChar = false;
            ctbId.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbId.PlaceholderText = "";
            ctbId.ReadOnly = false;
            ctbId.SelectionStart = 0;
            ctbId.Size = new System.Drawing.Size(65, 25);
            ctbId.TabIndex = 22;
            ctbId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbId.TextCustom = "";
            ctbId.UnderlinedStyle = false;
            // 
            // ctbSiparisNo
            // 
            ctbSiparisNo.BackColor = System.Drawing.Color.White;
            ctbSiparisNo.BorderColor = System.Drawing.Color.Silver;
            ctbSiparisNo.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbSiparisNo.BorderSize = 1;
            ctbSiparisNo.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbSiparisNo.ForeColor = System.Drawing.Color.Black;
            ctbSiparisNo.Location = new System.Drawing.Point(111, 62);
            ctbSiparisNo.Margin = new System.Windows.Forms.Padding(1);
            ctbSiparisNo.Multiline = false;
            ctbSiparisNo.Name = "ctbSiparisNo";
            ctbSiparisNo.Padding = new System.Windows.Forms.Padding(3);
            ctbSiparisNo.PasswordChar = false;
            ctbSiparisNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbSiparisNo.PlaceholderText = "";
            ctbSiparisNo.ReadOnly = false;
            ctbSiparisNo.SelectionStart = 0;
            ctbSiparisNo.Size = new System.Drawing.Size(106, 25);
            ctbSiparisNo.TabIndex = 23;
            ctbSiparisNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbSiparisNo.TextCustom = "";
            ctbSiparisNo.UnderlinedStyle = false;
            // 
            // ctbSiparisTarihi
            // 
            ctbSiparisTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbSiparisTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbSiparisTarihi.Location = new System.Drawing.Point(111, 89);
            ctbSiparisTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbSiparisTarihi.Name = "ctbSiparisTarihi";
            ctbSiparisTarihi.Padding = new System.Windows.Forms.Padding(3);
            ctbSiparisTarihi.Size = new System.Drawing.Size(91, 25);
            ctbSiparisTarihi.TabIndex = 24;
            // 
            // ctbTeslimTarihi
            // 
            ctbTeslimTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbTeslimTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTeslimTarihi.Location = new System.Drawing.Point(111, 116);
            ctbTeslimTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbTeslimTarihi.Name = "ctbTeslimTarihi";
            ctbTeslimTarihi.Padding = new System.Windows.Forms.Padding(3);
            ctbTeslimTarihi.Size = new System.Drawing.Size(91, 25);
            ctbTeslimTarihi.TabIndex = 25;
            // 
            // fcbProjeKod
            // 
            fcbProjeKod.BorderColor = System.Drawing.Color.Silver;
            fcbProjeKod.BorderRadius = 8;
            fcbProjeKod.BorderSize = 1;
            fcbProjeKod.DisplayMember = "kod";
            fcbProjeKod.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbProjeKod.Location = new System.Drawing.Point(111, 143);
            fcbProjeKod.Margin = new System.Windows.Forms.Padding(1);
            fcbProjeKod.Name = "fcbProjeKod";
            fcbProjeKod.Padding = new System.Windows.Forms.Padding(3);
            fcbProjeKod.PlaceholderText = "Seçiniz...";
            fcbProjeKod.ReadOnly = false;
            fcbProjeKod.Size = new System.Drawing.Size(156, 25);
            fcbProjeKod.TabIndex = 26;
            fcbProjeKod.ValueMember = "Id";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label10.Location = new System.Drawing.Point(16, 153);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(68, 15);
            label10.TabIndex = 27;
            label10.Text = "Proje Kodu";
            // 
            // ctbTutar
            // 
            ctbTutar.BackColor = System.Drawing.SystemColors.Window;
            ctbTutar.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTutar.ForeColor = System.Drawing.Color.DimGray;
            ctbTutar.Location = new System.Drawing.Point(111, 278);
            ctbTutar.Margin = new System.Windows.Forms.Padding(1);
            ctbTutar.Name = "ctbTutar";
            ctbTutar.OndalikBasamak = 0;
            ctbTutar.Padding = new System.Windows.Forms.Padding(3);
            ctbTutar.Size = new System.Drawing.Size(91, 25);
            ctbTutar.TabIndex = 28;
            ctbTutar.TextCustom = "0";
            // 
            // fcbMalzemeGrup
            // 
            fcbMalzemeGrup.BorderColor = System.Drawing.Color.Silver;
            fcbMalzemeGrup.BorderRadius = 8;
            fcbMalzemeGrup.BorderSize = 1;
            fcbMalzemeGrup.DisplayMember = "ad";
            fcbMalzemeGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMalzemeGrup.Location = new System.Drawing.Point(111, 170);
            fcbMalzemeGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbMalzemeGrup.Name = "fcbMalzemeGrup";
            fcbMalzemeGrup.Padding = new System.Windows.Forms.Padding(3);
            fcbMalzemeGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeGrup.ReadOnly = false;
            fcbMalzemeGrup.Size = new System.Drawing.Size(156, 25);
            fcbMalzemeGrup.TabIndex = 29;
            fcbMalzemeGrup.ValueMember = "Id";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label11.Location = new System.Drawing.Point(16, 180);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(96, 15);
            label11.TabIndex = 30;
            label11.Text = "Malzeme Grubu";
            // 
            // SatinalmaSiparisKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(920, 831);
            Controls.Add(label11);
            Controls.Add(fcbMalzemeGrup);
            Controls.Add(ctbTutar);
            Controls.Add(label10);
            Controls.Add(fcbProjeKod);
            Controls.Add(ctbTeslimTarihi);
            Controls.Add(ctbSiparisTarihi);
            Controls.Add(ctbSiparisNo);
            Controls.Add(ctbId);
            Controls.Add(fcbDovizCinsi);
            Controls.Add(label9);
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
            Controls.Add(ctbAciklama);
            Controls.Add(fcbVadeId);
            Controls.Add(fcbFirmaId);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaSiparisKayitFormu";
            Text = "SatinalmaSiparisKayitFormu";
            FormClosing += SatinalmaSiparisKayitFormu_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.FilterableComboBox fcbFirmaId;
        private CustomControls.FilterableComboBox fcbVadeId;
        private CustomControls.CustomTextBox ctbAciklama;
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
        private System.Windows.Forms.Label label9;
        private CustomControls.FilterableComboBox fcbDovizCinsi;
        private CustomControls.CustomTextBox ctbId;
        private CustomControls.CustomTextBox ctbSiparisNo;
        private CustomControls.CustomTextBoxTarih ctbSiparisTarihi;
        private CustomControls.CustomTextBoxTarih ctbTeslimTarihi;
        private CustomControls.FilterableComboBox fcbProjeKod;
        private System.Windows.Forms.Label label10;
        private CustomControls.CustomTextBoxSayisal ctbTutar;
        private CustomControls.FilterableComboBox fcbMalzemeGrup;
        private System.Windows.Forms.Label label11;
    }
}