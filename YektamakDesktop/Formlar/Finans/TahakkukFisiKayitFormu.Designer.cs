namespace YektamakDesktop.Formlar.Finans
{
    partial class TahakkukFisiKayitFormu
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
            rButtonKapat = new CustomControls.RoundedButton();
            rButtonGuncelle = new CustomControls.RoundedButton();
            rButtonKaydet = new CustomControls.RoundedButton();
            customComboListBoxCariKartId = new CustomControls.CustomComboListBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            customComboListBoxDovizId = new CustomControls.CustomComboListBox();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            textBoxAciklama = new System.Windows.Forms.TextBox();
            labelUyariCariAdi = new System.Windows.Forms.Label();
            labelUyariTutar = new System.Windows.Forms.Label();
            labelUyariTahakkukTarihi = new System.Windows.Forms.Label();
            labelUyariOdemeTarihi = new System.Windows.Forms.Label();
            textBoxTutar = new CustomControls.CustomTextBoxSayisal();
            textBoxTahakkukTarihi = new CustomControls.CustomTextBoxTarih();
            textBoxVadeTarihi = new CustomControls.CustomTextBoxTarih();
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
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(654, 56);
            panelHeader.TabIndex = 1;
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
            buttonClose.Location = new System.Drawing.Point(607, 9);
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
            buttonHelp.Location = new System.Drawing.Point(527, 9);
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
            buttomMinimize.Location = new System.Drawing.Point(567, 9);
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
            labelHeader.Size = new System.Drawing.Size(145, 30);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Tahakkuk Fişi";
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
            rButtonKapat.Location = new System.Drawing.Point(209, 441);
            rButtonKapat.Name = "rButtonKapat";
            rButtonKapat.Size = new System.Drawing.Size(152, 59);
            rButtonKapat.TabIndex = 2;
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
            rButtonGuncelle.Location = new System.Drawing.Point(41, 441);
            rButtonGuncelle.Name = "rButtonGuncelle";
            rButtonGuncelle.Size = new System.Drawing.Size(152, 59);
            rButtonGuncelle.TabIndex = 4;
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
            rButtonKaydet.Location = new System.Drawing.Point(41, 441);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new System.Drawing.Size(152, 59);
            rButtonKaydet.TabIndex = 6;
            rButtonKaydet.Text = "KAYDET";
            rButtonKaydet.TextColor = System.Drawing.Color.White;
            rButtonKaydet.UseVisualStyleBackColor = false;
            rButtonKaydet.Click += rButtonKaydet_Click;
            // 
            // customComboListBoxCariKartId
            // 
            customComboListBoxCariKartId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxCariKartId.ListBoxVisualSize = 5;
            customComboListBoxCariKartId.Location = new System.Drawing.Point(228, 176);
            customComboListBoxCariKartId.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxCariKartId.Name = "customComboListBoxCariKartId";
            customComboListBoxCariKartId.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxCariKartId.Size = new System.Drawing.Size(336, 36);
            customComboListBoxCariKartId.TabIndex = 7;
            customComboListBoxCariKartId.SelectedIndexChanged += customComboListBoxCariKartId_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(33, 176);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(88, 30);
            label2.TabIndex = 20;
            label2.Text = "Cari Adı";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(33, 218);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 30);
            label1.TabIndex = 21;
            label1.Text = "Tutar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(33, 104);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(159, 30);
            label3.TabIndex = 22;
            label3.Text = "Tahakkuk Tarihi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(33, 139);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(116, 30);
            label4.TabIndex = 23;
            label4.Text = "Vade Tarihi";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label10.Location = new System.Drawing.Point(209, 176);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(18, 30);
            label10.TabIndex = 43;
            label10.Text = ":";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(209, 218);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(18, 30);
            label5.TabIndex = 44;
            label5.Text = ":";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(209, 104);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(18, 30);
            label6.TabIndex = 45;
            label6.Text = ":";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(209, 139);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(18, 30);
            label7.TabIndex = 46;
            label7.Text = ":";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customComboListBoxDovizId
            // 
            customComboListBoxDovizId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxDovizId.Enabled = false;
            customComboListBoxDovizId.ListBoxVisualSize = 5;
            customComboListBoxDovizId.Location = new System.Drawing.Point(365, 221);
            customComboListBoxDovizId.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxDovizId.Name = "customComboListBoxDovizId";
            customComboListBoxDovizId.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxDovizId.Size = new System.Drawing.Size(63, 36);
            customComboListBoxDovizId.TabIndex = 47;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(209, 259);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(18, 30);
            label8.TabIndex = 49;
            label8.Text = ":";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label9.Location = new System.Drawing.Point(33, 259);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(99, 30);
            label9.TabIndex = 48;
            label9.Text = "Açıklama";
            // 
            // textBoxAciklama
            // 
            textBoxAciklama.Location = new System.Drawing.Point(228, 259);
            textBoxAciklama.Multiline = true;
            textBoxAciklama.Name = "textBoxAciklama";
            textBoxAciklama.Size = new System.Drawing.Size(333, 118);
            textBoxAciklama.TabIndex = 50;
            // 
            // labelUyariCariAdi
            // 
            labelUyariCariAdi.AutoSize = true;
            labelUyariCariAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariCariAdi.ForeColor = System.Drawing.Color.Red;
            labelUyariCariAdi.Location = new System.Drawing.Point(568, 182);
            labelUyariCariAdi.Name = "labelUyariCariAdi";
            labelUyariCariAdi.Size = new System.Drawing.Size(0, 15);
            labelUyariCariAdi.TabIndex = 51;
            // 
            // labelUyariTutar
            // 
            labelUyariTutar.AutoSize = true;
            labelUyariTutar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariTutar.ForeColor = System.Drawing.Color.Red;
            labelUyariTutar.Location = new System.Drawing.Point(432, 229);
            labelUyariTutar.Name = "labelUyariTutar";
            labelUyariTutar.Size = new System.Drawing.Size(0, 15);
            labelUyariTutar.TabIndex = 52;
            // 
            // labelUyariTahakkukTarihi
            // 
            labelUyariTahakkukTarihi.AutoSize = true;
            labelUyariTahakkukTarihi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariTahakkukTarihi.ForeColor = System.Drawing.Color.Red;
            labelUyariTahakkukTarihi.Location = new System.Drawing.Point(377, 114);
            labelUyariTahakkukTarihi.Name = "labelUyariTahakkukTarihi";
            labelUyariTahakkukTarihi.Size = new System.Drawing.Size(0, 15);
            labelUyariTahakkukTarihi.TabIndex = 53;
            // 
            // labelUyariOdemeTarihi
            // 
            labelUyariOdemeTarihi.AutoSize = true;
            labelUyariOdemeTarihi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariOdemeTarihi.ForeColor = System.Drawing.Color.Red;
            labelUyariOdemeTarihi.Location = new System.Drawing.Point(377, 149);
            labelUyariOdemeTarihi.Name = "labelUyariOdemeTarihi";
            labelUyariOdemeTarihi.Size = new System.Drawing.Size(0, 15);
            labelUyariOdemeTarihi.TabIndex = 54;
            // 
            // textBoxTutar
            // 
            textBoxTutar.BackColor = System.Drawing.Color.White;
            textBoxTutar.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxTutar.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxTutar.BorderRadius = 0;
            textBoxTutar.BorderSize = 2;
            textBoxTutar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxTutar.ForeColor = System.Drawing.Color.Black;
            textBoxTutar.Location = new System.Drawing.Point(228, 218);
            textBoxTutar.Multiline = false;
            textBoxTutar.Name = "textBoxTutar";
            textBoxTutar.OndalikBasamak = 2;
            textBoxTutar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxTutar.PasswordChar = false;
            textBoxTutar.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxTutar.PlaceholderText = "";
            textBoxTutar.ReadOnly = false;
            textBoxTutar.SelectionStart = 0;
            textBoxTutar.Size = new System.Drawing.Size(130, 32);
            textBoxTutar.TabIndex = 55;
            textBoxTutar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            textBoxTutar.TextCustom = "0,00";
            textBoxTutar.UnderlinedStyle = false;
            // 
            // textBoxTahakkukTarihi
            // 
            textBoxTahakkukTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            textBoxTahakkukTarihi.Location = new System.Drawing.Point(228, 107);
            textBoxTahakkukTarihi.Margin = new System.Windows.Forms.Padding(1);
            textBoxTahakkukTarihi.Name = "textBoxTahakkukTarihi";
            textBoxTahakkukTarihi.Padding = new System.Windows.Forms.Padding(1);
            textBoxTahakkukTarihi.Size = new System.Drawing.Size(145, 30);
            textBoxTahakkukTarihi.TabIndex = 56;
            textBoxTahakkukTarihi.TextCustom = "";
            // 
            // textBoxVadeTarihi
            // 
            textBoxVadeTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            textBoxVadeTarihi.Location = new System.Drawing.Point(228, 139);
            textBoxVadeTarihi.Margin = new System.Windows.Forms.Padding(1);
            textBoxVadeTarihi.Name = "textBoxVadeTarihi";
            textBoxVadeTarihi.Padding = new System.Windows.Forms.Padding(1);
            textBoxVadeTarihi.Size = new System.Drawing.Size(145, 30);
            textBoxVadeTarihi.TabIndex = 57;
            textBoxVadeTarihi.TextCustom = "";
            // 
            // TahakkukFisiKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(654, 520);
            Controls.Add(textBoxVadeTarihi);
            Controls.Add(textBoxTahakkukTarihi);
            Controls.Add(textBoxTutar);
            Controls.Add(labelUyariOdemeTarihi);
            Controls.Add(labelUyariTahakkukTarihi);
            Controls.Add(labelUyariTutar);
            Controls.Add(labelUyariCariAdi);
            Controls.Add(textBoxAciklama);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(customComboListBoxDovizId);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label10);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(customComboListBoxCariKartId);
            Controls.Add(rButtonGuncelle);
            Controls.Add(rButtonKapat);
            Controls.Add(panelHeader);
            Controls.Add(rButtonKaydet);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "TahakkukFisiKayitFormu";
            Text = "TahakkukFisiKayitFormu";
            Load += TahakkukFisiKayitFormu_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton rButtonKapat;
        private CustomControls.RoundedButton rButtonGuncelle;
        private CustomControls.RoundedButton rButtonKaydet;
        private CustomControls.CustomComboListBox customComboListBoxCariKartId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CustomControls.CustomComboListBox customComboListBoxDovizId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAciklama;
        private System.Windows.Forms.Label labelUyariCariAdi;
        private System.Windows.Forms.Label labelUyariTutar;
        private System.Windows.Forms.Label labelUyariTahakkukTarihi;
        private System.Windows.Forms.Label labelUyariOdemeTarihi;
        private CustomControls.CustomTextBoxSayisal textBoxTutar;
        private CustomControls.CustomTextBoxTarih textBoxTahakkukTarihi;
        private CustomControls.CustomTextBoxTarih textBoxVadeTarihi;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
    }
}