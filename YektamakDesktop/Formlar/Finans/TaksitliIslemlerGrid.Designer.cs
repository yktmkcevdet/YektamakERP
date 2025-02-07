namespace YektamakDesktop.Formlar.Finans
{
    partial class TaksitliOdemeGrid
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
            panel1 = new System.Windows.Forms.Panel();
            buttonKrediKartiEkle = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            customTextBoxFilterBitisIslemTarihi = new CustomControls.CustomTextBox();
            customTextBoxFilterBaslangicIslemTarihi = new CustomControls.CustomTextBox();
            monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            rButtonTemizle = new CustomControls.RoundedButton();
            rButtonFiltre = new CustomControls.RoundedButton();
            label2 = new System.Windows.Forms.Label();
            customComboListBoxFilterDovizId = new CustomControls.CustomComboListBox();
            label1 = new System.Windows.Forms.Label();
            customComboListBoxFilterCariId = new CustomControls.CustomComboListBox();
            dataGridViewTaksitliOdeme = new System.Windows.Forms.DataGridView();
            TaksitliOdemeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            OdemeTanimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cariId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cariAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            IslemTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ToplamTutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TaksitAdedi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TaksitTutari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TaksistAraligi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DovizId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DovizSembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Sil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonKapat = new CustomControls.RoundedButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTaksitliOdeme).BeginInit();
            panelHeader.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonKrediKartiEkle);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(customTextBoxFilterBitisIslemTarihi);
            panel1.Controls.Add(customTextBoxFilterBaslangicIslemTarihi);
            panel1.Controls.Add(monthCalendar1);
            panel1.Controls.Add(rButtonTemizle);
            panel1.Controls.Add(rButtonFiltre);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(customComboListBoxFilterDovizId);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(customComboListBoxFilterCariId);
            panel1.Location = new System.Drawing.Point(1, 56);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(238, 577);
            panel1.TabIndex = 0;
            // 
            // buttonKrediKartiEkle
            // 
            buttonKrediKartiEkle.BackgroundImage = Properties.Resources.Plus_Symbol_PNG_Image_HD;
            buttonKrediKartiEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            buttonKrediKartiEkle.Location = new System.Drawing.Point(180, 0);
            buttonKrediKartiEkle.Name = "buttonKrediKartiEkle";
            buttonKrediKartiEkle.Size = new System.Drawing.Size(58, 52);
            buttonKrediKartiEkle.TabIndex = 79;
            buttonKrediKartiEkle.UseVisualStyleBackColor = true;
            buttonKrediKartiEkle.Click += buttonKrediKartiEkle_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(22, 119);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(69, 15);
            label3.TabIndex = 78;
            label3.Text = "Tarih Aralığı";
            // 
            // customTextBoxFilterBitisIslemTarihi
            // 
            customTextBoxFilterBitisIslemTarihi.BackColor = System.Drawing.Color.WhiteSmoke;
            customTextBoxFilterBitisIslemTarihi.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxFilterBitisIslemTarihi.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxFilterBitisIslemTarihi.BorderRadius = 0;
            customTextBoxFilterBitisIslemTarihi.BorderSize = 2;
            customTextBoxFilterBitisIslemTarihi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxFilterBitisIslemTarihi.ForeColor = System.Drawing.Color.Black;
            customTextBoxFilterBitisIslemTarihi.Location = new System.Drawing.Point(112, 129);
            customTextBoxFilterBitisIslemTarihi.Multiline = false;
            customTextBoxFilterBitisIslemTarihi.Name = "customTextBoxFilterBitisIslemTarihi";
            customTextBoxFilterBitisIslemTarihi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxFilterBitisIslemTarihi.PasswordChar = false;
            customTextBoxFilterBitisIslemTarihi.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxFilterBitisIslemTarihi.PlaceholderText = "";
            customTextBoxFilterBitisIslemTarihi.ReadOnly = true;
            customTextBoxFilterBitisIslemTarihi.SelectionStart = 0;
            customTextBoxFilterBitisIslemTarihi.Size = new System.Drawing.Size(118, 32);
            customTextBoxFilterBitisIslemTarihi.TabIndex = 3;
            customTextBoxFilterBitisIslemTarihi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxFilterBitisIslemTarihi.TextCustom = "";
            customTextBoxFilterBitisIslemTarihi.UnderlinedStyle = false;
            customTextBoxFilterBitisIslemTarihi.Click += SelectCustomTextBox;
            customTextBoxFilterBitisIslemTarihi.Enter += SelectCustomTextBox;
            // 
            // customTextBoxFilterBaslangicIslemTarihi
            // 
            customTextBoxFilterBaslangicIslemTarihi.BackColor = System.Drawing.Color.WhiteSmoke;
            customTextBoxFilterBaslangicIslemTarihi.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxFilterBaslangicIslemTarihi.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxFilterBaslangicIslemTarihi.BorderRadius = 0;
            customTextBoxFilterBaslangicIslemTarihi.BorderSize = 2;
            customTextBoxFilterBaslangicIslemTarihi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxFilterBaslangicIslemTarihi.ForeColor = System.Drawing.Color.Black;
            customTextBoxFilterBaslangicIslemTarihi.Location = new System.Drawing.Point(112, 91);
            customTextBoxFilterBaslangicIslemTarihi.Multiline = false;
            customTextBoxFilterBaslangicIslemTarihi.Name = "customTextBoxFilterBaslangicIslemTarihi";
            customTextBoxFilterBaslangicIslemTarihi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxFilterBaslangicIslemTarihi.PasswordChar = false;
            customTextBoxFilterBaslangicIslemTarihi.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxFilterBaslangicIslemTarihi.PlaceholderText = "";
            customTextBoxFilterBaslangicIslemTarihi.ReadOnly = true;
            customTextBoxFilterBaslangicIslemTarihi.SelectionStart = 0;
            customTextBoxFilterBaslangicIslemTarihi.Size = new System.Drawing.Size(118, 32);
            customTextBoxFilterBaslangicIslemTarihi.TabIndex = 2;
            customTextBoxFilterBaslangicIslemTarihi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxFilterBaslangicIslemTarihi.TextCustom = "";
            customTextBoxFilterBaslangicIslemTarihi.UnderlinedStyle = false;
            customTextBoxFilterBaslangicIslemTarihi.Click += SelectCustomTextBox;
            customTextBoxFilterBaslangicIslemTarihi.Enter += SelectCustomTextBox;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new System.Drawing.Point(0, 300);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 77;
            monthCalendar1.Visible = false;
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            // 
            // rButtonTemizle
            // 
            rButtonTemizle.BackColor = System.Drawing.Color.Gray;
            rButtonTemizle.BackgroundColor = System.Drawing.Color.Gray;
            rButtonTemizle.BorderColor = System.Drawing.Color.DimGray;
            rButtonTemizle.BorderRadius = 20;
            rButtonTemizle.BorderSize = 2;
            rButtonTemizle.FlatAppearance.BorderSize = 0;
            rButtonTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonTemizle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonTemizle.ForeColor = System.Drawing.Color.White;
            rButtonTemizle.Location = new System.Drawing.Point(140, 216);
            rButtonTemizle.Name = "rButtonTemizle";
            rButtonTemizle.Size = new System.Drawing.Size(90, 40);
            rButtonTemizle.TabIndex = 76;
            rButtonTemizle.Text = "Temizle";
            rButtonTemizle.TextColor = System.Drawing.Color.White;
            rButtonTemizle.UseVisualStyleBackColor = false;
            rButtonTemizle.Click += rButtonTemizle_Click;
            // 
            // rButtonFiltre
            // 
            rButtonFiltre.BackColor = System.Drawing.Color.Gray;
            rButtonFiltre.BackgroundColor = System.Drawing.Color.Gray;
            rButtonFiltre.BorderColor = System.Drawing.Color.DimGray;
            rButtonFiltre.BorderRadius = 20;
            rButtonFiltre.BorderSize = 2;
            rButtonFiltre.FlatAppearance.BorderSize = 0;
            rButtonFiltre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonFiltre.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonFiltre.ForeColor = System.Drawing.Color.White;
            rButtonFiltre.Location = new System.Drawing.Point(22, 216);
            rButtonFiltre.Name = "rButtonFiltre";
            rButtonFiltre.Size = new System.Drawing.Size(90, 40);
            rButtonFiltre.TabIndex = 75;
            rButtonFiltre.Text = "Filtrele";
            rButtonFiltre.TextColor = System.Drawing.Color.White;
            rButtonFiltre.UseVisualStyleBackColor = false;
            rButtonFiltre.Click += rButtonfiltre_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(22, 176);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(64, 15);
            label2.TabIndex = 5;
            label2.Text = "Para Birimi";
            // 
            // customComboListBoxFilterDovizId
            // 
            customComboListBoxFilterDovizId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxFilterDovizId.ListBoxVisualSize = 5;
            customComboListBoxFilterDovizId.Location = new System.Drawing.Point(113, 168);
            customComboListBoxFilterDovizId.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxFilterDovizId.Name = "customComboListBoxFilterDovizId";
            customComboListBoxFilterDovizId.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxFilterDovizId.Size = new System.Drawing.Size(117, 36);
            customComboListBoxFilterDovizId.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 60);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 15);
            label1.TabIndex = 1;
            label1.Text = "Firma Adı";
            // 
            // customComboListBoxFilterCariId
            // 
            customComboListBoxFilterCariId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxFilterCariId.ListBoxVisualSize = 5;
            customComboListBoxFilterCariId.Location = new System.Drawing.Point(113, 53);
            customComboListBoxFilterCariId.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxFilterCariId.Name = "customComboListBoxFilterCariId";
            customComboListBoxFilterCariId.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxFilterCariId.Size = new System.Drawing.Size(117, 36);
            customComboListBoxFilterCariId.TabIndex = 0;
            // 
            // dataGridViewTaksitliOdeme
            // 
            dataGridViewTaksitliOdeme.AllowUserToAddRows = false;
            dataGridViewTaksitliOdeme.AllowUserToDeleteRows = false;
            dataGridViewTaksitliOdeme.AllowUserToOrderColumns = true;
            dataGridViewTaksitliOdeme.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewTaksitliOdeme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTaksitliOdeme.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { TaksitliOdemeId, OdemeTanimi, cariId, cariAdi, IslemTarihi, ToplamTutar, TaksitAdedi, TaksitTutari, TaksistAraligi, DovizId, DovizSembol, Guncelle, Sil });
            dataGridViewTaksitliOdeme.Location = new System.Drawing.Point(240, 56);
            dataGridViewTaksitliOdeme.Name = "dataGridViewTaksitliOdeme";
            dataGridViewTaksitliOdeme.ReadOnly = true;
            dataGridViewTaksitliOdeme.RowTemplate.Height = 25;
            dataGridViewTaksitliOdeme.Size = new System.Drawing.Size(1045, 577);
            dataGridViewTaksitliOdeme.TabIndex = 1;
            dataGridViewTaksitliOdeme.CellClick += dataGridView_CellClick;
            dataGridViewTaksitliOdeme.CellPainting += dataGridView_CellPainting;
            // 
            // TaksitliOdemeId
            // 
            TaksitliOdemeId.HeaderText = "TaksitliOdemeId";
            TaksitliOdemeId.Name = "TaksitliOdemeId";
            TaksitliOdemeId.ReadOnly = true;
            TaksitliOdemeId.Visible = false;
            // 
            // OdemeTanimi
            // 
            OdemeTanimi.HeaderText = "Ödeme Tanımı";
            OdemeTanimi.Name = "OdemeTanimi";
            OdemeTanimi.ReadOnly = true;
            // 
            // cariId
            // 
            cariId.HeaderText = "cariId";
            cariId.Name = "cariId";
            cariId.ReadOnly = true;
            cariId.Visible = false;
            // 
            // cariAdi
            // 
            cariAdi.HeaderText = "Cari Adı";
            cariAdi.Name = "cariAdi";
            cariAdi.ReadOnly = true;
            // 
            // IslemTarihi
            // 
            IslemTarihi.HeaderText = "İşlem Tarihi";
            IslemTarihi.Name = "IslemTarihi";
            IslemTarihi.ReadOnly = true;
            // 
            // ToplamTutar
            // 
            ToplamTutar.HeaderText = "Toplam Tutar";
            ToplamTutar.Name = "ToplamTutar";
            ToplamTutar.ReadOnly = true;
            // 
            // TaksitAdedi
            // 
            TaksitAdedi.HeaderText = "Taksit Adedi";
            TaksitAdedi.Name = "TaksitAdedi";
            TaksitAdedi.ReadOnly = true;
            // 
            // TaksitTutari
            // 
            TaksitTutari.HeaderText = "Taksti Tutarı";
            TaksitTutari.Name = "TaksitTutari";
            TaksitTutari.ReadOnly = true;
            // 
            // TaksistAraligi
            // 
            TaksistAraligi.HeaderText = "Taksit Aralığı";
            TaksistAraligi.Name = "TaksistAraligi";
            TaksistAraligi.ReadOnly = true;
            // 
            // DovizId
            // 
            DovizId.HeaderText = "DovizId";
            DovizId.Name = "DovizId";
            DovizId.ReadOnly = true;
            DovizId.Visible = false;
            // 
            // DovizSembol
            // 
            DovizSembol.HeaderText = "Para Birimi";
            DovizSembol.Name = "DovizSembol";
            DovizSembol.ReadOnly = true;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Güncelle";
            Guncelle.Name = "Guncelle";
            Guncelle.ReadOnly = true;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
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
            panelHeader.Size = new System.Drawing.Size(1284, 56);
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
            buttonClose.Location = new System.Drawing.Point(1237, 9);
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
            buttonHelp.Location = new System.Drawing.Point(1157, 9);
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
            buttomMinimize.Location = new System.Drawing.Point(1197, 9);
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
            labelHeader.Size = new System.Drawing.Size(164, 30);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Taksitli İşlemler";
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(rButtonKapat);
            panelFooter.Location = new System.Drawing.Point(1, 633);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1284, 66);
            panelFooter.TabIndex = 4;
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
            rButtonKapat.Location = new System.Drawing.Point(30, 4);
            rButtonKapat.Name = "rButtonKapat";
            rButtonKapat.Size = new System.Drawing.Size(152, 59);
            rButtonKapat.TabIndex = 0;
            rButtonKapat.Text = "KAPAT";
            rButtonKapat.TextColor = System.Drawing.Color.White;
            rButtonKapat.UseVisualStyleBackColor = false;
            rButtonKapat.Click += rButtonKapat_Click;
            // 
            // TaksitliOdemeGrid
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1285, 700);
            Controls.Add(panel1);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            Controls.Add(dataGridViewTaksitliOdeme);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "TaksitliOdemeGrid";
            Text = "TaksitliIslemlerGrid";
            Load += TaksitliOdemeGrid_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTaksitliOdeme).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomControls.CustomComboListBox customComboListBoxFilterDovizId;
        private CustomControls.CustomTextBox customTextBoxFilterBitisIslemTarihi;
        private CustomControls.CustomTextBox customTextBoxFilterBaslangicIslemTarihi;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomComboListBox customComboListBoxFilterCariId;
        private System.Windows.Forms.DataGridView dataGridViewTaksitliOdeme;
        private System.Windows.Forms.Label label2;
        private CustomControls.RoundedButton rButtonTemizle;
        private CustomControls.RoundedButton rButtonFiltre;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private CustomControls.RoundedButton rButtonKapat;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonKrediKartiEkle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaksitliOdemeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OdemeTanimi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IslemTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToplamTutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaksitAdedi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaksitTutari;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaksistAraligi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DovizId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DovizSembol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Guncelle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sil;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
    }
}