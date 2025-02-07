namespace YektamakDesktop.Formlar.Finans
{
    partial class KasaKayitFormu
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
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            rButtonGuncelle = new CustomControls.RoundedButton();
            rButtonKapat = new CustomControls.RoundedButton();
            rButtonKaydet = new CustomControls.RoundedButton();
            customTextBoxHesapAdi = new CustomControls.CustomTextBox();
            label1 = new System.Windows.Forms.Label();
            customComboListBoxDovizTuru = new CustomControls.CustomComboListBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            customComboListBoxKasaTuru = new CustomControls.CustomComboListBox();
            label8 = new System.Windows.Forms.Label();
            labelBankaHesabi = new System.Windows.Forms.Label();
            customComboListBoxBankaHesabi = new CustomControls.CustomComboListBox();
            customTextBoxBakiye = new CustomControls.CustomTextBoxSayisal();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Red;
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Location = new System.Drawing.Point(1, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(540, 56);
            panelHeader.TabIndex = 2;
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
            buttonClose.Location = new System.Drawing.Point(494, 9);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(40, 38);
            buttonClose.TabIndex = 103;
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
            buttonHelp.Location = new System.Drawing.Point(414, 9);
            buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonHelp.Size = new System.Drawing.Size(40, 38);
            buttonHelp.TabIndex = 102;
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
            buttomMinimize.Location = new System.Drawing.Point(454, 9);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(40, 38);
            buttomMinimize.TabIndex = 101;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(12, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(240, 30);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Kasa Tanımlama Formu";
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
            rButtonGuncelle.Location = new System.Drawing.Point(74, 339);
            rButtonGuncelle.Name = "rButtonGuncelle";
            rButtonGuncelle.Size = new System.Drawing.Size(152, 59);
            rButtonGuncelle.TabIndex = 3;
            rButtonGuncelle.Text = "GÜNCELLE";
            rButtonGuncelle.TextColor = System.Drawing.Color.White;
            rButtonGuncelle.UseVisualStyleBackColor = false;
            rButtonGuncelle.Click += rButtonKaydet_Click;
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
            rButtonKapat.Location = new System.Drawing.Point(246, 339);
            rButtonKapat.Name = "rButtonKapat";
            rButtonKapat.Size = new System.Drawing.Size(152, 59);
            rButtonKapat.TabIndex = 4;
            rButtonKapat.Text = "KAPAT";
            rButtonKapat.TextColor = System.Drawing.Color.White;
            rButtonKapat.UseVisualStyleBackColor = false;
            rButtonKapat.Click += rButtonKapat_Click;
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
            rButtonKaydet.Location = new System.Drawing.Point(74, 339);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new System.Drawing.Size(152, 59);
            rButtonKaydet.TabIndex = 5;
            rButtonKaydet.Text = "KAYDET";
            rButtonKaydet.TextColor = System.Drawing.Color.White;
            rButtonKaydet.UseVisualStyleBackColor = false;
            rButtonKaydet.Click += rButtonKaydet_Click;
            // 
            // customTextBoxHesapAdi
            // 
            customTextBoxHesapAdi.BackColor = System.Drawing.Color.White;
            customTextBoxHesapAdi.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxHesapAdi.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxHesapAdi.BorderRadius = 0;
            customTextBoxHesapAdi.BorderSize = 2;
            customTextBoxHesapAdi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxHesapAdi.ForeColor = System.Drawing.Color.Black;
            customTextBoxHesapAdi.Location = new System.Drawing.Point(200, 113);
            customTextBoxHesapAdi.Multiline = false;
            customTextBoxHesapAdi.Name = "customTextBoxHesapAdi";
            customTextBoxHesapAdi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxHesapAdi.PasswordChar = false;
            customTextBoxHesapAdi.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxHesapAdi.PlaceholderText = "";
            customTextBoxHesapAdi.ReadOnly = false;
            customTextBoxHesapAdi.SelectionStart = 0;
            customTextBoxHesapAdi.Size = new System.Drawing.Size(250, 32);
            customTextBoxHesapAdi.TabIndex = 6;
            customTextBoxHesapAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxHesapAdi.TextCustom = "";
            customTextBoxHesapAdi.UnderlinedStyle = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(40, 113);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(95, 30);
            label1.TabIndex = 11;
            label1.Text = "Kasa Adı";
            // 
            // customComboListBoxDovizTuru
            // 
            customComboListBoxDovizTuru.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxDovizTuru.ListBoxVisualSize = 5;
            customComboListBoxDovizTuru.Location = new System.Drawing.Point(200, 149);
            customComboListBoxDovizTuru.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxDovizTuru.Name = "customComboListBoxDovizTuru";
            customComboListBoxDovizTuru.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxDovizTuru.Size = new System.Drawing.Size(105, 36);
            customComboListBoxDovizTuru.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(40, 149);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(115, 30);
            label3.TabIndex = 13;
            label3.Text = "Döviz Türü";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(40, 191);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(75, 30);
            label4.TabIndex = 14;
            label4.Text = "Bakiye";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label11.Location = new System.Drawing.Point(176, 113);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(18, 30);
            label11.TabIndex = 54;
            label11.Text = ":";
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(176, 149);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(18, 30);
            label2.TabIndex = 55;
            label2.Text = ":";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(176, 193);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(18, 30);
            label5.TabIndex = 56;
            label5.Text = ":";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(176, 68);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(18, 30);
            label6.TabIndex = 59;
            label6.Text = ":";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(40, 68);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(105, 30);
            label7.TabIndex = 58;
            label7.Text = "Kasa Türü";
            // 
            // customComboListBoxKasaTuru
            // 
            customComboListBoxKasaTuru.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxKasaTuru.ListBoxVisualSize = 5;
            customComboListBoxKasaTuru.Location = new System.Drawing.Point(198, 68);
            customComboListBoxKasaTuru.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxKasaTuru.Name = "customComboListBoxKasaTuru";
            customComboListBoxKasaTuru.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxKasaTuru.Size = new System.Drawing.Size(202, 36);
            customComboListBoxKasaTuru.TabIndex = 57;
            customComboListBoxKasaTuru.SelectedIndexChanged += customComboListBoxKasaTuru_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(176, 234);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(18, 30);
            label8.TabIndex = 62;
            label8.Text = ":";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label8.Visible = false;
            // 
            // labelBankaHesabi
            // 
            labelBankaHesabi.AutoSize = true;
            labelBankaHesabi.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelBankaHesabi.Location = new System.Drawing.Point(40, 234);
            labelBankaHesabi.Name = "labelBankaHesabi";
            labelBankaHesabi.Size = new System.Drawing.Size(141, 30);
            labelBankaHesabi.TabIndex = 61;
            labelBankaHesabi.Text = "Banka Hesabı";
            labelBankaHesabi.Visible = false;
            // 
            // customComboListBoxBankaHesabi
            // 
            customComboListBoxBankaHesabi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxBankaHesabi.ListBoxVisualSize = 5;
            customComboListBoxBankaHesabi.Location = new System.Drawing.Point(198, 234);
            customComboListBoxBankaHesabi.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxBankaHesabi.Name = "customComboListBoxBankaHesabi";
            customComboListBoxBankaHesabi.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxBankaHesabi.Size = new System.Drawing.Size(202, 36);
            customComboListBoxBankaHesabi.TabIndex = 60;
            customComboListBoxBankaHesabi.Visible = false;
            // 
            // customTextBoxBakiye
            // 
            customTextBoxBakiye.BackColor = System.Drawing.Color.White;
            customTextBoxBakiye.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxBakiye.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxBakiye.BorderRadius = 0;
            customTextBoxBakiye.BorderSize = 2;
            customTextBoxBakiye.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxBakiye.ForeColor = System.Drawing.Color.Black;
            customTextBoxBakiye.Location = new System.Drawing.Point(200, 193);
            customTextBoxBakiye.Multiline = false;
            customTextBoxBakiye.Name = "customTextBoxBakiye";
            customTextBoxBakiye.OndalikBasamak = 2;
            customTextBoxBakiye.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxBakiye.PasswordChar = false;
            customTextBoxBakiye.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxBakiye.PlaceholderText = "";
            customTextBoxBakiye.ReadOnly = false;
            customTextBoxBakiye.SelectionStart = 0;
            customTextBoxBakiye.Size = new System.Drawing.Size(105, 32);
            customTextBoxBakiye.TabIndex = 63;
            customTextBoxBakiye.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            customTextBoxBakiye.TextCustom = "";
            customTextBoxBakiye.UnderlinedStyle = false;
            // 
            // KasaTanimlamaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(542, 426);
            Controls.Add(customTextBoxBakiye);
            Controls.Add(label8);
            Controls.Add(labelBankaHesabi);
            Controls.Add(customComboListBoxBankaHesabi);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(customComboListBoxKasaTuru);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label11);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(customComboListBoxDovizTuru);
            Controls.Add(customTextBoxHesapAdi);
            Controls.Add(rButtonKapat);
            Controls.Add(rButtonGuncelle);
            Controls.Add(panelHeader);
            Controls.Add(rButtonKaydet);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "KasaTanimlamaFormu";
            Text = "CekKayitFormu";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton rButtonGuncelle;
        private CustomControls.RoundedButton rButtonKapat;
        private CustomControls.RoundedButton rButtonKaydet;
        private CustomControls.CustomTextBox customTextBoxHesapAdi;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomComboListBox customComboListBoxDovizTuru;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CustomControls.CustomComboListBox customComboListBoxKasaTuru;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelBankaHesabi;
        private CustomControls.CustomComboListBox customComboListBoxBankaHesabi;
        private CustomControls.CustomTextBoxSayisal customTextBoxBakiye;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
    }
}