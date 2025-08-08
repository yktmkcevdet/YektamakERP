namespace YektamakDesktop.Formlar.Satis
{
    partial class ProjeTanimlamaFormu
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
            fcbProjeTip = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbMarka = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbMarkaAltGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            Id = new System.Windows.Forms.Label();
            ctbAd = new YektamakDesktop.CustomControls.CustomTextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ctbAciklama = new YektamakDesktop.CustomControls.CustomTextBox();
            ctbMarkaAltGrupKategori = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbMirasProje = new YektamakDesktop.CustomControls.FilterableComboBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Proje Tanımlama";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(962, 32);
            headerPanel1.TabIndex = 0;
            // 
            // ctbId
            // 
            ctbId.BackColor = System.Drawing.Color.White;
            ctbId.BorderColor = System.Drawing.Color.Silver;
            ctbId.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbId.BorderRadius = 5;
            ctbId.BorderSize = 1;
            ctbId.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbId.ForeColor = System.Drawing.Color.Black;
            ctbId.isPlaceHolder = false;
            ctbId.Location = new System.Drawing.Point(150, 60);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbId.PasswordChar = false;
            ctbId.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbId.PlaceholderText = "";
            ctbId.ReadOnly = false;
            ctbId.SelectionStart = 0;
            ctbId.Size = new System.Drawing.Size(112, 28);
            ctbId.TabIndex = 1;
            ctbId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbId.TextCustom = "";
            ctbId.UnderlinedStyle = false;
            // 
            // fcbProjeTip
            // 
            fcbProjeTip.BorderColor = System.Drawing.Color.Silver;
            fcbProjeTip.BorderSize = 1;
            fcbProjeTip.DataSource = null;
            fcbProjeTip.DisplayMember = "";
            fcbProjeTip.Location = new System.Drawing.Point(150, 94);
            fcbProjeTip.Name = "fcbProjeTip";
            fcbProjeTip.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbProjeTip.PlaceholderText = "Seçiniz...";
            fcbProjeTip.SelectedIndex = -1;
            fcbProjeTip.SelectedItem = null;
            fcbProjeTip.SelectedValue = null;
            fcbProjeTip.Size = new System.Drawing.Size(163, 29);
            fcbProjeTip.TabIndex = 2;
            fcbProjeTip.UnderlinedStyle = false;
            fcbProjeTip.ValueMember = "";
            // 
            // fcbMarka
            // 
            fcbMarka.BorderColor = System.Drawing.Color.Silver;
            fcbMarka.BorderSize = 1;
            fcbMarka.DataSource = null;
            fcbMarka.DisplayMember = "";
            fcbMarka.Location = new System.Drawing.Point(150, 129);
            fcbMarka.Name = "fcbMarka";
            fcbMarka.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMarka.PlaceholderText = "Seçiniz...";
            fcbMarka.SelectedIndex = -1;
            fcbMarka.SelectedItem = null;
            fcbMarka.SelectedValue = null;
            fcbMarka.Size = new System.Drawing.Size(163, 29);
            fcbMarka.TabIndex = 3;
            fcbMarka.UnderlinedStyle = false;
            fcbMarka.ValueMember = "";
            // 
            // fcbMarkaAltGrup
            // 
            fcbMarkaAltGrup.BorderColor = System.Drawing.Color.Silver;
            fcbMarkaAltGrup.BorderSize = 1;
            fcbMarkaAltGrup.DataSource = null;
            fcbMarkaAltGrup.DisplayMember = "";
            fcbMarkaAltGrup.Location = new System.Drawing.Point(150, 198);
            fcbMarkaAltGrup.Name = "fcbMarkaAltGrup";
            fcbMarkaAltGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMarkaAltGrup.PlaceholderText = "Seçiniz...";
            fcbMarkaAltGrup.SelectedIndex = -1;
            fcbMarkaAltGrup.SelectedItem = null;
            fcbMarkaAltGrup.SelectedValue = null;
            fcbMarkaAltGrup.Size = new System.Drawing.Size(163, 29);
            fcbMarkaAltGrup.TabIndex = 5;
            fcbMarkaAltGrup.UnderlinedStyle = false;
            fcbMarkaAltGrup.ValueMember = "";
            // 
            // Id
            // 
            Id.AutoSize = true;
            Id.Location = new System.Drawing.Point(37, 69);
            Id.Name = "Id";
            Id.Size = new System.Drawing.Size(17, 15);
            Id.TabIndex = 5;
            Id.Text = "Id";
            // 
            // ctbAd
            // 
            ctbAd.BackColor = System.Drawing.Color.White;
            ctbAd.BorderColor = System.Drawing.Color.Silver;
            ctbAd.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbAd.BorderRadius = 5;
            ctbAd.BorderSize = 1;
            ctbAd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbAd.ForeColor = System.Drawing.Color.Black;
            ctbAd.isPlaceHolder = false;
            ctbAd.Location = new System.Drawing.Point(465, 95);
            ctbAd.Multiline = false;
            ctbAd.Name = "ctbAd";
            ctbAd.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbAd.PasswordChar = false;
            ctbAd.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAd.PlaceholderText = "";
            ctbAd.ReadOnly = false;
            ctbAd.SelectionStart = 0;
            ctbAd.Size = new System.Drawing.Size(428, 28);
            ctbAd.TabIndex = 7;
            ctbAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbAd.TextCustom = "";
            ctbAd.UnderlinedStyle = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(37, 101);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 15);
            label1.TabIndex = 7;
            label1.Text = "Proje Tipi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(37, 136);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(40, 15);
            label2.TabIndex = 8;
            label2.Text = "Marka";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(37, 205);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(85, 15);
            label3.TabIndex = 9;
            label3.Text = "Marka alt Grup";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(352, 102);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(55, 15);
            label4.TabIndex = 10;
            label4.Text = "Proje Adı";
            // 
            // ctbAciklama
            // 
            ctbAciklama.BackColor = System.Drawing.Color.White;
            ctbAciklama.BorderColor = System.Drawing.Color.Silver;
            ctbAciklama.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbAciklama.BorderRadius = 5;
            ctbAciklama.BorderSize = 1;
            ctbAciklama.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbAciklama.ForeColor = System.Drawing.Color.Black;
            ctbAciklama.isPlaceHolder = false;
            ctbAciklama.Location = new System.Drawing.Point(465, 129);
            ctbAciklama.Multiline = true;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbAciklama.PasswordChar = false;
            ctbAciklama.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAciklama.PlaceholderText = "";
            ctbAciklama.ReadOnly = false;
            ctbAciklama.SelectionStart = 0;
            ctbAciklama.Size = new System.Drawing.Size(428, 82);
            ctbAciklama.TabIndex = 8;
            ctbAciklama.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbAciklama.TextCustom = "";
            ctbAciklama.UnderlinedStyle = false;
            // 
            // ctbMarkaAltGrupKategori
            // 
            ctbMarkaAltGrupKategori.BorderColor = System.Drawing.Color.Silver;
            ctbMarkaAltGrupKategori.BorderSize = 1;
            ctbMarkaAltGrupKategori.DataSource = null;
            ctbMarkaAltGrupKategori.DisplayMember = "";
            ctbMarkaAltGrupKategori.Location = new System.Drawing.Point(465, 60);
            ctbMarkaAltGrupKategori.Name = "ctbMarkaAltGrupKategori";
            ctbMarkaAltGrupKategori.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbMarkaAltGrupKategori.PlaceholderText = "Seçiniz...";
            ctbMarkaAltGrupKategori.SelectedIndex = -1;
            ctbMarkaAltGrupKategori.SelectedItem = null;
            ctbMarkaAltGrupKategori.SelectedValue = null;
            ctbMarkaAltGrupKategori.Size = new System.Drawing.Size(119, 29);
            ctbMarkaAltGrupKategori.TabIndex = 6;
            ctbMarkaAltGrupKategori.UnderlinedStyle = false;
            ctbMarkaAltGrupKategori.ValueMember = "";
            // 
            // fcbMirasProje
            // 
            fcbMirasProje.BorderColor = System.Drawing.Color.Silver;
            fcbMirasProje.BorderSize = 1;
            fcbMirasProje.DataSource = null;
            fcbMirasProje.DisplayMember = "";
            fcbMirasProje.Location = new System.Drawing.Point(150, 163);
            fcbMirasProje.Name = "fcbMirasProje";
            fcbMirasProje.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMirasProje.PlaceholderText = "Seçiniz...";
            fcbMirasProje.SelectedIndex = -1;
            fcbMirasProje.SelectedItem = null;
            fcbMirasProje.SelectedValue = null;
            fcbMirasProje.Size = new System.Drawing.Size(119, 29);
            fcbMirasProje.TabIndex = 4;
            fcbMirasProje.UnderlinedStyle = false;
            fcbMirasProje.ValueMember = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(352, 134);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(56, 15);
            label5.TabIndex = 14;
            label5.Text = "Açıklama";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(352, 65);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(51, 15);
            label6.TabIndex = 15;
            label6.Text = "Kategori";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(37, 168);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(103, 15);
            label7.TabIndex = 16;
            label7.Text = "Miras Alınan Proje";
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(844, 580);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 17;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(37, 233);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(913, 341);
            universalGrid1.TabIndex = 18;
            // 
            // ProjeTanimlamaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(962, 642);
            Controls.Add(universalGrid1);
            Controls.Add(customButtonSave1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(fcbMirasProje);
            Controls.Add(ctbMarkaAltGrupKategori);
            Controls.Add(ctbAciklama);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ctbAd);
            Controls.Add(Id);
            Controls.Add(fcbMarkaAltGrup);
            Controls.Add(fcbMarka);
            Controls.Add(fcbProjeTip);
            Controls.Add(ctbId);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ProjeTanimlamaFormu";
            Text = "ProjeTanimlamaFormu";
            Load += ProjeTanimlamaFormu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBox ctbId;
        private CustomControls.FilterableComboBox fcbProjeTip;
        private CustomControls.FilterableComboBox fcbMarka;
        private CustomControls.FilterableComboBox fcbMarkaAltGrup;
        private System.Windows.Forms.Label Id;
        private CustomControls.CustomTextBox ctbAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBox ctbAciklama;
        private CustomControls.FilterableComboBox ctbMarkaAltGrupKategori;
        private CustomControls.FilterableComboBox fcbMirasProje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.UniversalGrid universalGrid1;
    }
}