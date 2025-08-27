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
            headerPanel1.Size = new System.Drawing.Size(928, 32);
            headerPanel1.TabIndex = 0;
            // 
            // ctbTeklifNo
            // 
            ctbTeklifNo.BackColor = System.Drawing.Color.White;
            ctbTeklifNo.Enabled = false;
            ctbTeklifNo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbTeklifNo.ForeColor = System.Drawing.Color.Black;
            ctbTeklifNo.Location = new System.Drawing.Point(151, 49);
            ctbTeklifNo.Multiline = false;
            ctbTeklifNo.Name = "ctbTeklifNo";
            ctbTeklifNo.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbTeklifNo.Size = new System.Drawing.Size(156, 28);
            ctbTeklifNo.TabIndex = 1;
            // 
            // ctbTeklifTalepTarihi
            // 
            ctbTeklifTalepTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbTeklifTalepTarihi.Location = new System.Drawing.Point(151, 116);
            ctbTeklifTalepTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbTeklifTalepTarihi.Name = "ctbTeklifTalepTarihi";
            ctbTeklifTalepTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbTeklifTalepTarihi.Size = new System.Drawing.Size(145, 32);
            ctbTeklifTalepTarihi.TabIndex = 3;
            // 
            // ctbTeklifTarihi
            // 
            ctbTeklifTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbTeklifTarihi.Location = new System.Drawing.Point(151, 189);
            ctbTeklifTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbTeklifTarihi.Name = "ctbTeklifTarihi";
            ctbTeklifTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbTeklifTarihi.Size = new System.Drawing.Size(145, 32);
            ctbTeklifTarihi.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(54, 53);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 15);
            label1.TabIndex = 6;
            label1.Text = "Teklif No";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(54, 223);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(32, 15);
            label2.TabIndex = 7;
            label2.Text = "Vade";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(54, 189);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 15);
            label3.TabIndex = 8;
            label3.Text = "Teklif Tarihi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(54, 155);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(77, 15);
            label4.TabIndex = 9;
            label4.Text = "Termin Süresi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(54, 125);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(95, 15);
            label5.TabIndex = 10;
            label5.Text = "Teklif Talep Tarihi";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(54, 92);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(37, 15);
            label6.TabIndex = 11;
            label6.Text = "Firma";
            // 
            // ctbTutar
            // 
            ctbTutar.BackColor = System.Drawing.Color.White;
            ctbTutar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbTutar.ForeColor = System.Drawing.Color.Black;
            ctbTutar.Location = new System.Drawing.Point(151, 255);
            ctbTutar.Name = "ctbTutar";
            ctbTutar.OndalikBasamak = 0;
            ctbTutar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbTutar.Size = new System.Drawing.Size(96, 32);
            ctbTutar.TabIndex = 13;
            ctbTutar.TextCustom = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(54, 262);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(34, 15);
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
            ctbTerminSuresi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbTerminSuresi.ForeColor = System.Drawing.Color.Black;
            ctbTerminSuresi.Location = new System.Drawing.Point(151, 150);
            ctbTerminSuresi.Name = "ctbTerminSuresi";
            ctbTerminSuresi.OndalikBasamak = 0;
            ctbTerminSuresi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbTerminSuresi.Size = new System.Drawing.Size(79, 32);
            ctbTerminSuresi.TabIndex = 19;
            ctbTerminSuresi.TextCustom = "0";
            // 
            // ctbTeklifGecerlilikSuresi
            // 
            ctbTeklifGecerlilikSuresi.BackColor = System.Drawing.Color.White;
            ctbTeklifGecerlilikSuresi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbTeklifGecerlilikSuresi.ForeColor = System.Drawing.Color.Black;
            ctbTeklifGecerlilikSuresi.Location = new System.Drawing.Point(151, 293);
            ctbTeklifGecerlilikSuresi.Name = "ctbTeklifGecerlilikSuresi";
            ctbTeklifGecerlilikSuresi.OndalikBasamak = 0;
            ctbTeklifGecerlilikSuresi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbTeklifGecerlilikSuresi.Size = new System.Drawing.Size(73, 32);
            ctbTeklifGecerlilikSuresi.TabIndex = 20;
            ctbTeklifGecerlilikSuresi.TextCustom = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(54, 302);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(89, 15);
            label9.TabIndex = 21;
            label9.Text = "Geçerlilik Süresi";
            // 
            // ctbAciklama
            // 
            ctbAciklama.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ctbAciklama.BackColor = System.Drawing.Color.White;
            ctbAciklama.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbAciklama.ForeColor = System.Drawing.Color.Black;
            ctbAciklama.Location = new System.Drawing.Point(151, 331);
            ctbAciklama.Multiline = false;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbAciklama.Size = new System.Drawing.Size(358, 28);
            ctbAciklama.TabIndex = 22;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(54, 339);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(56, 15);
            label10.TabIndex = 23;
            label10.Text = "Açıklama";
            // 
            // fcbFirma
            // 
            fcbFirma.BorderColor = System.Drawing.Color.Silver;
            fcbFirma.BorderSize = 1;
            fcbFirma.DisplayMember = "ad";
            fcbFirma.Location = new System.Drawing.Point(151, 83);
            fcbFirma.Name = "fcbFirma";
            fcbFirma.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbFirma.PlaceholderText = "Seçiniz...";
            fcbFirma.Size = new System.Drawing.Size(434, 29);
            fcbFirma.TabIndex = 24;
            fcbFirma.ValueMember = "Id";
            // 
            // clbVade
            // 
            clbVade.BorderColor = System.Drawing.Color.Silver;
            clbVade.BorderSize = 1;
            clbVade.DisplayMember = "ad";
            clbVade.Location = new System.Drawing.Point(151, 223);
            clbVade.Name = "clbVade";
            clbVade.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbVade.PlaceholderText = "Seçiniz...";
            clbVade.Size = new System.Drawing.Size(119, 29);
            clbVade.TabIndex = 25;
            clbVade.ValueMember = "Id";
            // 
            // clbDoviz
            // 
            clbDoviz.BorderColor = System.Drawing.Color.Silver;
            clbDoviz.BorderSize = 1;
            clbDoviz.DisplayMember = "kod";
            clbDoviz.Location = new System.Drawing.Point(253, 257);
            clbDoviz.Name = "clbDoviz";
            clbDoviz.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbDoviz.PlaceholderText = "Seçiniz...";
            clbDoviz.Size = new System.Drawing.Size(72, 29);
            clbDoviz.TabIndex = 26;
            clbDoviz.ValueMember = "Id";
            // 
            // btnSipariseDonustur
            // 
            btnSipariseDonustur.FlatAppearance.BorderSize = 0;
            btnSipariseDonustur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSipariseDonustur.ForeColor = System.Drawing.Color.White;
            btnSipariseDonustur.Location = new System.Drawing.Point(552, 748);
            btnSipariseDonustur.Name = "btnSipariseDonustur";
            btnSipariseDonustur.Size = new System.Drawing.Size(150, 40);
            btnSipariseDonustur.TabIndex = 27;
            btnSipariseDonustur.Text = "SİPARİŞE DÖNÜŞTÜR";
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