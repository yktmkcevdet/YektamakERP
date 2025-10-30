namespace YektamakDesktop.Formlar.Satinalma.Teklif
{
    partial class SatinalmaTeklifKayitFormu
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
            ctbTeklifNo = new YektamakDesktop.CustomControls.CustomTextBox();
            ctbTeklifTalepTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            ctbTeklifTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            ctbTutar = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            label7 = new System.Windows.Forms.Label();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            ctbTerminSuresi = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            ctbTeklifGecerlilikSuresi = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            label9 = new System.Windows.Forms.Label();
            ctbAciklama = new YektamakDesktop.CustomControls.CustomTextBox();
            label10 = new System.Windows.Forms.Label();
            fcbFirma = new YektamakDesktop.CustomControls.FilterableComboBox();
            clbVade = new YektamakDesktop.CustomControls.FilterableComboBox();
            clbDoviz = new YektamakDesktop.CustomControls.FilterableComboBox();
            btnSipariseDonustur = new YektamakDesktop.CustomControls.RoundedButton();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Teklif Kayıt Formu";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(928, 25);
            headerPanel1.TabIndex = 0;
            // 
            // ctbTeklifNo
            // 
            ctbTeklifNo.BackColor = System.Drawing.Color.White;
            ctbTeklifNo.BorderColor = System.Drawing.Color.Silver;
            ctbTeklifNo.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbTeklifNo.BorderSize = 1;
            ctbTeklifNo.Enabled = false;
            ctbTeklifNo.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTeklifNo.ForeColor = System.Drawing.Color.Black;
            ctbTeklifNo.Location = new System.Drawing.Point(160, 49);
            ctbTeklifNo.Margin = new System.Windows.Forms.Padding(1);
            ctbTeklifNo.Multiline = false;
            ctbTeklifNo.Name = "ctbTeklifNo";
            ctbTeklifNo.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbTeklifNo.PasswordChar = false;
            ctbTeklifNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbTeklifNo.PlaceholderText = "";
            ctbTeklifNo.ReadOnly = false;
            ctbTeklifNo.SelectionStart = 0;
            ctbTeklifNo.Size = new System.Drawing.Size(156, 29);
            ctbTeklifNo.TabIndex = 1;
            ctbTeklifNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbTeklifNo.TextCustom = "";
            ctbTeklifNo.UnderlinedStyle = false;
            // 
            // ctbTeklifTalepTarihi
            // 
            ctbTeklifTalepTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbTeklifTalepTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTeklifTalepTarihi.Location = new System.Drawing.Point(160, 107);
            ctbTeklifTalepTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbTeklifTalepTarihi.Name = "ctbTeklifTalepTarihi";
            ctbTeklifTalepTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbTeklifTalepTarihi.Size = new System.Drawing.Size(145, 32);
            ctbTeklifTalepTarihi.TabIndex = 3;
            // 
            // ctbTeklifTarihi
            // 
            ctbTeklifTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbTeklifTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTeklifTarihi.Location = new System.Drawing.Point(160, 176);
            ctbTeklifTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbTeklifTarihi.Name = "ctbTeklifTarihi";
            ctbTeklifTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbTeklifTarihi.Size = new System.Drawing.Size(145, 32);
            ctbTeklifTarihi.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(54, 58);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 15);
            label1.TabIndex = 6;
            label1.Text = "Teklif No";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(54, 215);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 15);
            label2.TabIndex = 7;
            label2.Text = "Vade";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(54, 181);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(71, 15);
            label3.TabIndex = 8;
            label3.Text = "Teklif Tarihi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(54, 146);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(83, 15);
            label4.TabIndex = 9;
            label4.Text = "Termin Süresi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(54, 112);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(103, 15);
            label5.TabIndex = 10;
            label5.Text = "Teklif Talep Tarihi";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(54, 85);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(38, 15);
            label6.TabIndex = 11;
            label6.Text = "Firma";
            // 
            // ctbTutar
            // 
            ctbTutar.BackColor = System.Drawing.Color.White;
            ctbTutar.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTutar.ForeColor = System.Drawing.Color.Black;
            ctbTutar.Location = new System.Drawing.Point(160, 237);
            ctbTutar.Margin = new System.Windows.Forms.Padding(1);
            ctbTutar.Name = "ctbTutar";
            ctbTutar.OndalikBasamak = 2;
            ctbTutar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbTutar.Size = new System.Drawing.Size(96, 33);
            ctbTutar.TabIndex = 13;
            ctbTutar.TextCustom = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(54, 244);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(36, 15);
            label7.TabIndex = 15;
            label7.Text = "Tutar";
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(54, 378);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(824, 364);
            universalGrid1.TabIndex = 17;
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(772, 748);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 18;
            customButtonSave1.SaveButtonClick += customButtonSave1_Click;
            // 
            // ctbTerminSuresi
            // 
            ctbTerminSuresi.BackColor = System.Drawing.Color.White;
            ctbTerminSuresi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTerminSuresi.ForeColor = System.Drawing.Color.Black;
            ctbTerminSuresi.Location = new System.Drawing.Point(160, 141);
            ctbTerminSuresi.Margin = new System.Windows.Forms.Padding(1);
            ctbTerminSuresi.Name = "ctbTerminSuresi";
            ctbTerminSuresi.OndalikBasamak = 0;
            ctbTerminSuresi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbTerminSuresi.Size = new System.Drawing.Size(79, 33);
            ctbTerminSuresi.TabIndex = 19;
            ctbTerminSuresi.TextCustom = "0";
            // 
            // ctbTeklifGecerlilikSuresi
            // 
            ctbTeklifGecerlilikSuresi.BackColor = System.Drawing.Color.White;
            ctbTeklifGecerlilikSuresi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTeklifGecerlilikSuresi.ForeColor = System.Drawing.Color.Black;
            ctbTeklifGecerlilikSuresi.Location = new System.Drawing.Point(160, 272);
            ctbTeklifGecerlilikSuresi.Margin = new System.Windows.Forms.Padding(1);
            ctbTeklifGecerlilikSuresi.Name = "ctbTeklifGecerlilikSuresi";
            ctbTeklifGecerlilikSuresi.OndalikBasamak = 0;
            ctbTeklifGecerlilikSuresi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbTeklifGecerlilikSuresi.Size = new System.Drawing.Size(73, 33);
            ctbTeklifGecerlilikSuresi.TabIndex = 20;
            ctbTeklifGecerlilikSuresi.TextCustom = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label9.Location = new System.Drawing.Point(54, 277);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(97, 15);
            label9.TabIndex = 21;
            label9.Text = "Geçerlilik Süresi";
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
            ctbAciklama.Location = new System.Drawing.Point(160, 307);
            ctbAciklama.Margin = new System.Windows.Forms.Padding(1);
            ctbAciklama.Multiline = false;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbAciklama.PasswordChar = false;
            ctbAciklama.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAciklama.PlaceholderText = "";
            ctbAciklama.ReadOnly = false;
            ctbAciklama.SelectionStart = 0;
            ctbAciklama.Size = new System.Drawing.Size(358, 29);
            ctbAciklama.TabIndex = 22;
            ctbAciklama.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbAciklama.TextCustom = "";
            ctbAciklama.UnderlinedStyle = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label10.Location = new System.Drawing.Point(54, 312);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(57, 15);
            label10.TabIndex = 23;
            label10.Text = "Açıklama";
            // 
            // fcbFirma
            // 
            fcbFirma.BorderColor = System.Drawing.Color.Silver;
            fcbFirma.BorderRadius = 8;
            fcbFirma.BorderSize = 1;
            fcbFirma.DisplayMember = "ad";
            fcbFirma.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbFirma.Location = new System.Drawing.Point(160, 80);
            fcbFirma.Margin = new System.Windows.Forms.Padding(1);
            fcbFirma.Name = "fcbFirma";
            fcbFirma.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbFirma.PlaceholderText = "Seçiniz...";
            fcbFirma.Size = new System.Drawing.Size(434, 25);
            fcbFirma.TabIndex = 24;
            fcbFirma.ValueMember = "Id";
            // 
            // clbVade
            // 
            clbVade.BorderColor = System.Drawing.Color.Silver;
            clbVade.BorderRadius = 8;
            clbVade.BorderSize = 1;
            clbVade.DisplayMember = "ad";
            clbVade.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbVade.Location = new System.Drawing.Point(160, 210);
            clbVade.Margin = new System.Windows.Forms.Padding(1);
            clbVade.Name = "clbVade";
            clbVade.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbVade.PlaceholderText = "Seçiniz...";
            clbVade.Size = new System.Drawing.Size(119, 25);
            clbVade.TabIndex = 25;
            clbVade.ValueMember = "Id";
            // 
            // clbDoviz
            // 
            clbDoviz.BorderColor = System.Drawing.Color.Silver;
            clbDoviz.BorderRadius = 8;
            clbDoviz.BorderSize = 1;
            clbDoviz.DisplayMember = "kod";
            clbDoviz.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbDoviz.Location = new System.Drawing.Point(257, 239);
            clbDoviz.Margin = new System.Windows.Forms.Padding(1);
            clbDoviz.Name = "clbDoviz";
            clbDoviz.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbDoviz.PlaceholderText = "Seçiniz...";
            clbDoviz.Size = new System.Drawing.Size(72, 25);
            clbDoviz.TabIndex = 26;
            clbDoviz.ValueMember = "Id";
            // 
            // btnSipariseDonustur
            // 
            btnSipariseDonustur.BackgroundColor = System.Drawing.Color.Firebrick;
            btnSipariseDonustur.BorderColor = System.Drawing.Color.Black;
            btnSipariseDonustur.BorderSize = 0;
            btnSipariseDonustur.CornerRadius = 10;
            btnSipariseDonustur.FlatAppearance.BorderSize = 0;
            btnSipariseDonustur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSipariseDonustur.ForeColor = System.Drawing.Color.White;
            btnSipariseDonustur.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnSipariseDonustur.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnSipariseDonustur.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnSipariseDonustur.HoverColor2 = System.Drawing.Color.Navy;
            btnSipariseDonustur.Icon = null;
            btnSipariseDonustur.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSipariseDonustur.Location = new System.Drawing.Point(552, 748);
            btnSipariseDonustur.Name = "btnSipariseDonustur";
            btnSipariseDonustur.Size = new System.Drawing.Size(150, 40);
            btnSipariseDonustur.TabIndex = 27;
            btnSipariseDonustur.Text = "SİPARİŞE DÖNÜŞTÜR";
            btnSipariseDonustur.TextColor = System.Drawing.Color.White;
            btnSipariseDonustur.UseVisualStyleBackColor = true;
            btnSipariseDonustur.Click += btnSipariseDonustur_Click;
            // 
            // SatinalmaTeklifKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(928, 806);
            Controls.Add(btnSipariseDonustur);
            Controls.Add(clbDoviz);
            Controls.Add(clbVade);
            Controls.Add(fcbFirma);
            Controls.Add(label10);
            Controls.Add(ctbAciklama);
            Controls.Add(label9);
            Controls.Add(ctbTeklifGecerlilikSuresi);
            Controls.Add(ctbTerminSuresi);
            Controls.Add(customButtonSave1);
            Controls.Add(universalGrid1);
            Controls.Add(label7);
            Controls.Add(ctbTutar);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ctbTeklifTarihi);
            Controls.Add(ctbTeklifTalepTarihi);
            Controls.Add(ctbTeklifNo);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTeklifKayitFormu";
            Text = "SatinalmaTeklifKayitFormu";
            FormClosing += SatinalmaTeklifKayitFormu_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBox ctbTeklifNo;
        private CustomControls.CustomTextBoxTarih ctbTeklifTalepTarihi;
        private CustomControls.CustomTextBoxTarih ctbTeklifTarihi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CustomControls.CustomTextBoxSayisal ctbTutar;
        private System.Windows.Forms.Label label7;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.CustomTextBoxSayisal ctbTerminSuresi;
        private CustomControls.CustomTextBoxSayisal ctbTeklifGecerlilikSuresi;
        private System.Windows.Forms.Label label9;
        private CustomControls.CustomTextBox ctbAciklama;
        private System.Windows.Forms.Label label10;
        private CustomControls.FilterableComboBox filterableComboBox1;
        private CustomControls.FilterableComboBox fcbFirma;
        private CustomControls.FilterableComboBox clbVade;
        private CustomControls.FilterableComboBox clbDoviz;
        private CustomControls.RoundedButton btnSipariseDonustur;
    }
}