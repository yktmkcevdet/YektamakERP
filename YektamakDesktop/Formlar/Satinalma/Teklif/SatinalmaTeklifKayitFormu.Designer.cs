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
            firmaId = new YektamakDesktop.CustomControls.CustomComboListBox();
            ctbTeklifTalepTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            ctbTeklifTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            clbVade = new YektamakDesktop.CustomControls.CustomComboListBox();
            ctbTutar = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            clbDoviz = new YektamakDesktop.CustomControls.CustomComboListBox();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            ctbTerminSuresi = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            ctbTeklifGecerlilikSuresi = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            label9 = new System.Windows.Forms.Label();
            ctbAciklama = new YektamakDesktop.CustomControls.CustomTextBox();
            label10 = new System.Windows.Forms.Label();
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
            ctbTeklifNo.BorderColor = System.Drawing.Color.Silver;
            ctbTeklifNo.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbTeklifNo.BorderRadius = 5;
            ctbTeklifNo.BorderSize = 1;
            ctbTeklifNo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbTeklifNo.ForeColor = System.Drawing.Color.Black;
            ctbTeklifNo.isPlaceHolder = false;
            ctbTeklifNo.Location = new System.Drawing.Point(151, 53);
            ctbTeklifNo.Multiline = false;
            ctbTeklifNo.Name = "ctbTeklifNo";
            ctbTeklifNo.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbTeklifNo.PasswordChar = false;
            ctbTeklifNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbTeklifNo.PlaceholderText = "";
            ctbTeklifNo.ReadOnly = false;
            ctbTeklifNo.SelectionStart = 0;
            ctbTeklifNo.Size = new System.Drawing.Size(156, 28);
            ctbTeklifNo.TabIndex = 1;
            ctbTeklifNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbTeklifNo.TextCustom = "";
            ctbTeklifNo.UnderlinedStyle = false;
            // 
            // firmaId
            // 
            firmaId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            firmaId.ListBoxVisualSize = 5;
            firmaId.Location = new System.Drawing.Point(151, 85);
            firmaId.Margin = new System.Windows.Forms.Padding(1);
            firmaId.Name = "firmaId";
            firmaId.Padding = new System.Windows.Forms.Padding(1);
            firmaId.selectedDataRowId = -1;
            firmaId.Size = new System.Drawing.Size(506, 36);
            firmaId.TabIndex = 2;
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
            ctbTeklifTalepTarihi.TextCustom = null;
            // 
            // ctbTeklifTarihi
            // 
            ctbTeklifTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbTeklifTarihi.Location = new System.Drawing.Point(151, 184);
            ctbTeklifTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbTeklifTarihi.Name = "ctbTeklifTarihi";
            ctbTeklifTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbTeklifTarihi.Size = new System.Drawing.Size(145, 32);
            ctbTeklifTarihi.TabIndex = 5;
            ctbTeklifTarihi.TextCustom = null;
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
            label2.Location = new System.Drawing.Point(54, 218);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(32, 15);
            label2.TabIndex = 7;
            label2.Text = "Vade";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(54, 184);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 15);
            label3.TabIndex = 8;
            label3.Text = "Teklif Tarihi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(54, 150);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(77, 15);
            label4.TabIndex = 9;
            label4.Text = "Termin Süresi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(54, 116);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(95, 15);
            label5.TabIndex = 10;
            label5.Text = "Teklif Talep Tarihi";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(54, 85);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(37, 15);
            label6.TabIndex = 11;
            label6.Text = "Firma";
            // 
            // clbVade
            // 
            clbVade.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbVade.ListBoxVisualSize = 5;
            clbVade.Location = new System.Drawing.Point(151, 218);
            clbVade.Margin = new System.Windows.Forms.Padding(1);
            clbVade.Name = "clbVade";
            clbVade.Padding = new System.Windows.Forms.Padding(1);
            clbVade.selectedDataRowId = -1;
            clbVade.Size = new System.Drawing.Size(207, 36);
            clbVade.TabIndex = 12;
            // 
            // ctbTutar
            // 
            ctbTutar.BackColor = System.Drawing.Color.White;
            ctbTutar.BorderColor = System.Drawing.Color.Silver;
            ctbTutar.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbTutar.BorderRadius = 5;
            ctbTutar.BorderSize = 1;
            ctbTutar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbTutar.ForeColor = System.Drawing.Color.Black;
            ctbTutar.Location = new System.Drawing.Point(151, 250);
            ctbTutar.Multiline = false;
            ctbTutar.Name = "ctbTutar";
            ctbTutar.OndalikBasamak = 0;
            ctbTutar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbTutar.PasswordChar = false;
            ctbTutar.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbTutar.PlaceholderText = "";
            ctbTutar.ReadOnly = false;
            ctbTutar.SelectionStart = 0;
            ctbTutar.Size = new System.Drawing.Size(250, 32);
            ctbTutar.TabIndex = 13;
            ctbTutar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            ctbTutar.TextCustom = "0";
            ctbTutar.UnderlinedStyle = false;
            // 
            // clbDoviz
            // 
            clbDoviz.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbDoviz.ListBoxVisualSize = 5;
            clbDoviz.Location = new System.Drawing.Point(151, 286);
            clbDoviz.Margin = new System.Windows.Forms.Padding(1);
            clbDoviz.Name = "clbDoviz";
            clbDoviz.Padding = new System.Windows.Forms.Padding(1);
            clbDoviz.selectedDataRowId = -1;
            clbDoviz.Size = new System.Drawing.Size(250, 36);
            clbDoviz.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(54, 250);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(34, 15);
            label7.TabIndex = 15;
            label7.Text = "Tutar";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(54, 286);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(65, 15);
            label8.TabIndex = 16;
            label8.Text = "Döviz Cinsi";
            // 
            // universalGrid1
            // 
            universalGrid1.kullanici = null;
            universalGrid1.Location = new System.Drawing.Point(54, 378);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(824, 364);
            universalGrid1.TabIndex = 17;
            // 
            // customButtonSave1
            // 
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
            ctbTerminSuresi.BorderColor = System.Drawing.Color.Silver;
            ctbTerminSuresi.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbTerminSuresi.BorderRadius = 5;
            ctbTerminSuresi.BorderSize = 1;
            ctbTerminSuresi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbTerminSuresi.ForeColor = System.Drawing.Color.Black;
            ctbTerminSuresi.Location = new System.Drawing.Point(151, 150);
            ctbTerminSuresi.Multiline = false;
            ctbTerminSuresi.Name = "ctbTerminSuresi";
            ctbTerminSuresi.OndalikBasamak = 0;
            ctbTerminSuresi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbTerminSuresi.PasswordChar = false;
            ctbTerminSuresi.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbTerminSuresi.PlaceholderText = "";
            ctbTerminSuresi.ReadOnly = false;
            ctbTerminSuresi.SelectionStart = 0;
            ctbTerminSuresi.Size = new System.Drawing.Size(79, 32);
            ctbTerminSuresi.TabIndex = 19;
            ctbTerminSuresi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            ctbTerminSuresi.TextCustom = "0";
            ctbTerminSuresi.UnderlinedStyle = false;
            // 
            // ctbTeklifGecerlilikSuresi
            // 
            ctbTeklifGecerlilikSuresi.BackColor = System.Drawing.Color.White;
            ctbTeklifGecerlilikSuresi.BorderColor = System.Drawing.Color.Silver;
            ctbTeklifGecerlilikSuresi.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbTeklifGecerlilikSuresi.BorderRadius = 5;
            ctbTeklifGecerlilikSuresi.BorderSize = 1;
            ctbTeklifGecerlilikSuresi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbTeklifGecerlilikSuresi.ForeColor = System.Drawing.Color.Black;
            ctbTeklifGecerlilikSuresi.Location = new System.Drawing.Point(151, 317);
            ctbTeklifGecerlilikSuresi.Multiline = false;
            ctbTeklifGecerlilikSuresi.Name = "ctbTeklifGecerlilikSuresi";
            ctbTeklifGecerlilikSuresi.OndalikBasamak = 0;
            ctbTeklifGecerlilikSuresi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbTeklifGecerlilikSuresi.PasswordChar = false;
            ctbTeklifGecerlilikSuresi.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbTeklifGecerlilikSuresi.PlaceholderText = "";
            ctbTeklifGecerlilikSuresi.ReadOnly = false;
            ctbTeklifGecerlilikSuresi.SelectionStart = 0;
            ctbTeklifGecerlilikSuresi.Size = new System.Drawing.Size(73, 32);
            ctbTeklifGecerlilikSuresi.TabIndex = 20;
            ctbTeklifGecerlilikSuresi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            ctbTeklifGecerlilikSuresi.TextCustom = "0";
            ctbTeklifGecerlilikSuresi.UnderlinedStyle = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(54, 317);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(89, 15);
            label9.TabIndex = 21;
            label9.Text = "Geçerlilik Süresi";
            // 
            // ctbAciklama
            // 
            ctbAciklama.BackColor = System.Drawing.SystemColors.Window;
            ctbAciklama.BorderColor = System.Drawing.Color.Silver;
            ctbAciklama.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbAciklama.BorderRadius = 5;
            ctbAciklama.BorderSize = 1;
            ctbAciklama.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbAciklama.ForeColor = System.Drawing.Color.DimGray;
            ctbAciklama.isPlaceHolder = false;
            ctbAciklama.Location = new System.Drawing.Point(529, 202);
            ctbAciklama.Multiline = true;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbAciklama.PasswordChar = false;
            ctbAciklama.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAciklama.PlaceholderText = "";
            ctbAciklama.ReadOnly = false;
            ctbAciklama.SelectionStart = 0;
            ctbAciklama.Size = new System.Drawing.Size(358, 147);
            ctbAciklama.TabIndex = 22;
            ctbAciklama.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbAciklama.TextCustom = "";
            ctbAciklama.UnderlinedStyle = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(529, 184);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(56, 15);
            label10.TabIndex = 23;
            label10.Text = "Açıklama";
            // 
            // SatinalmaTeklifKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(928, 806);
            Controls.Add(label10);
            Controls.Add(ctbAciklama);
            Controls.Add(label9);
            Controls.Add(ctbTeklifGecerlilikSuresi);
            Controls.Add(ctbTerminSuresi);
            Controls.Add(customButtonSave1);
            Controls.Add(universalGrid1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(clbDoviz);
            Controls.Add(ctbTutar);
            Controls.Add(clbVade);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ctbTeklifTarihi);
            Controls.Add(ctbTeklifTalepTarihi);
            Controls.Add(firmaId);
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
        private CustomControls.CustomComboListBox firmaId;
        private CustomControls.CustomTextBoxTarih ctbTeklifTalepTarihi;
        private CustomControls.CustomTextBoxTarih ctbTeklifTarihi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CustomControls.CustomComboListBox clbVade;
        private CustomControls.CustomTextBoxSayisal ctbTutar;
        private CustomControls.CustomComboListBox clbDoviz;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.CustomTextBoxSayisal ctbTerminSuresi;
        private CustomControls.CustomTextBoxSayisal ctbTeklifGecerlilikSuresi;
        private System.Windows.Forms.Label label9;
        private CustomControls.CustomTextBox ctbAciklama;
        private System.Windows.Forms.Label label10;
    }
}