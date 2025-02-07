namespace YektamakDesktop.Formlar.Finans
{
    partial class KrediKartlariGridForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            panelFilter = new System.Windows.Forms.Panel();
            textBoxFiltreKartSahibi = new System.Windows.Forms.TextBox();
            buttonKrediKartiEkle = new System.Windows.Forms.Button();
            buttonTumKayitlariGetir = new System.Windows.Forms.Button();
            buttonFiltre = new System.Windows.Forms.Button();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonKapat = new CustomControls.RoundedButton();
            dataGridViewKrediKarti = new System.Windows.Forms.DataGridView();
            KrediKartiId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            kartSahibi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            kartNumarasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            HesapId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            bagliHesapAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DovizId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dovizSembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            hesapKesimTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            sonOdemeTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            kartLimiti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            guncelKartLimiti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ekstreBorcu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            panelHeader.SuspendLayout();
            panelFilter.SuspendLayout();
            panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKrediKarti).BeginInit();
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
            panelHeader.Size = new System.Drawing.Size(1085, 56);
            panelHeader.TabIndex = 0;
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
            buttonClose.Location = new System.Drawing.Point(1038, 9);
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
            buttonHelp.Location = new System.Drawing.Point(958, 9);
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
            buttomMinimize.Location = new System.Drawing.Point(998, 9);
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
            labelHeader.Size = new System.Drawing.Size(215, 30);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Kredi Kartı Tanımları";
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(textBoxFiltreKartSahibi);
            panelFilter.Controls.Add(buttonKrediKartiEkle);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(buttonFiltre);
            panelFilter.Location = new System.Drawing.Point(0, 56);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1085, 56);
            panelFilter.TabIndex = 1;
            // 
            // textBoxFiltreKartSahibi
            // 
            textBoxFiltreKartSahibi.Location = new System.Drawing.Point(40, 18);
            textBoxFiltreKartSahibi.Name = "textBoxFiltreKartSahibi";
            textBoxFiltreKartSahibi.Size = new System.Drawing.Size(100, 23);
            textBoxFiltreKartSahibi.TabIndex = 3;
            // 
            // buttonKrediKartiEkle
            // 
            buttonKrediKartiEkle.BackgroundImage = Properties.Resources.Plus_Symbol_PNG_Image_HD;
            buttonKrediKartiEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            buttonKrediKartiEkle.Location = new System.Drawing.Point(1005, 3);
            buttonKrediKartiEkle.Name = "buttonKrediKartiEkle";
            buttonKrediKartiEkle.Size = new System.Drawing.Size(58, 52);
            buttonKrediKartiEkle.TabIndex = 2;
            buttonKrediKartiEkle.UseVisualStyleBackColor = true;
            buttonKrediKartiEkle.Click += buttonKrediKartiEkle_Click;
            // 
            // buttonTumKayitlariGetir
            // 
            buttonTumKayitlariGetir.BackColor = System.Drawing.Color.Tomato;
            buttonTumKayitlariGetir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonTumKayitlariGetir.ForeColor = System.Drawing.Color.Transparent;
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(791, 2);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(103, 52);
            buttonTumKayitlariGetir.TabIndex = 1;
            buttonTumKayitlariGetir.Text = "Tüm Kayıtları Getir";
            buttonTumKayitlariGetir.UseVisualStyleBackColor = false;
            buttonTumKayitlariGetir.Click += buttonTumKayitlariGetir_Click;
            // 
            // buttonFiltre
            // 
            buttonFiltre.BackgroundImage = Properties.Resources.DataReviewWithMagnifier5;
            buttonFiltre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            buttonFiltre.Location = new System.Drawing.Point(652, 2);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(107, 52);
            buttonFiltre.TabIndex = 0;
            buttonFiltre.UseVisualStyleBackColor = true;
            buttonFiltre.Click += buttonFiltre_Click;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(rButtonKapat);
            panelFooter.Location = new System.Drawing.Point(0, 689);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1085, 65);
            panelFooter.TabIndex = 2;
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
            rButtonKapat.Location = new System.Drawing.Point(30, 7);
            rButtonKapat.Name = "rButtonKapat";
            rButtonKapat.Size = new System.Drawing.Size(152, 59);
            rButtonKapat.TabIndex = 0;
            rButtonKapat.Text = "KAPAT";
            rButtonKapat.TextColor = System.Drawing.Color.White;
            rButtonKapat.UseVisualStyleBackColor = false;
            rButtonKapat.Click += rButtonKapat_Click;
            // 
            // dataGridViewKrediKarti
            // 
            dataGridViewKrediKarti.AllowUserToAddRows = false;
            dataGridViewKrediKarti.AllowUserToDeleteRows = false;
            dataGridViewKrediKarti.AllowUserToOrderColumns = true;
            dataGridViewKrediKarti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKrediKarti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { KrediKartiId, kartSahibi, kartNumarasi, HesapId, bagliHesapAdi, DovizId, dovizSembol, hesapKesimTarihi, sonOdemeTarihi, kartLimiti, guncelKartLimiti, ekstreBorcu, Guncelle, Sil });
            dataGridViewKrediKarti.Location = new System.Drawing.Point(0, 112);
            dataGridViewKrediKarti.Name = "dataGridViewKrediKarti";
            dataGridViewKrediKarti.ReadOnly = true;
            dataGridViewKrediKarti.RowTemplate.Height = 25;
            dataGridViewKrediKarti.Size = new System.Drawing.Size(1085, 578);
            dataGridViewKrediKarti.TabIndex = 3;
            dataGridViewKrediKarti.CellClick += dataGridViewCariKartlar_CellClick;
            // 
            // KrediKartiId
            // 
            KrediKartiId.HeaderText = "KrediKartiId";
            KrediKartiId.Name = "KrediKartiId";
            KrediKartiId.ReadOnly = true;
            KrediKartiId.Visible = false;
            // 
            // kartSahibi
            // 
            kartSahibi.HeaderText = "Kart Sahibi";
            kartSahibi.Name = "kartSahibi";
            kartSahibi.ReadOnly = true;
            kartSahibi.Width = 150;
            // 
            // kartNumarasi
            // 
            kartNumarasi.HeaderText = "Kart No";
            kartNumarasi.Name = "kartNumarasi";
            kartNumarasi.ReadOnly = true;
            kartNumarasi.Width = 150;
            // 
            // HesapId
            // 
            HesapId.HeaderText = "HesapId";
            HesapId.Name = "HesapId";
            HesapId.ReadOnly = true;
            HesapId.Visible = false;
            // 
            // bagliHesapAdi
            // 
            bagliHesapAdi.HeaderText = "Bağlı Hesap";
            bagliHesapAdi.Name = "bagliHesapAdi";
            bagliHesapAdi.ReadOnly = true;
            bagliHesapAdi.Width = 150;
            // 
            // DovizId
            // 
            DovizId.HeaderText = "DovizId";
            DovizId.Name = "DovizId";
            DovizId.ReadOnly = true;
            DovizId.Visible = false;
            // 
            // dovizSembol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dovizSembol.DefaultCellStyle = dataGridViewCellStyle1;
            dovizSembol.HeaderText = "Para Birimi";
            dovizSembol.Name = "dovizSembol";
            dovizSembol.ReadOnly = true;
            dovizSembol.Width = 50;
            // 
            // hesapKesimTarihi
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            hesapKesimTarihi.DefaultCellStyle = dataGridViewCellStyle2;
            hesapKesimTarihi.HeaderText = "Hesap Kesim Günü";
            hesapKesimTarihi.Name = "hesapKesimTarihi";
            hesapKesimTarihi.ReadOnly = true;
            // 
            // sonOdemeTarihi
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            sonOdemeTarihi.DefaultCellStyle = dataGridViewCellStyle3;
            sonOdemeTarihi.HeaderText = "Son Ödeme Günü";
            sonOdemeTarihi.Name = "sonOdemeTarihi";
            sonOdemeTarihi.ReadOnly = true;
            // 
            // kartLimiti
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            kartLimiti.DefaultCellStyle = dataGridViewCellStyle4;
            kartLimiti.HeaderText = "Kart Limiti";
            kartLimiti.Name = "kartLimiti";
            kartLimiti.ReadOnly = true;
            kartLimiti.Width = 70;
            // 
            // guncelKartLimiti
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            guncelKartLimiti.DefaultCellStyle = dataGridViewCellStyle5;
            guncelKartLimiti.HeaderText = "Güncel Limiti";
            guncelKartLimiti.Name = "guncelKartLimiti";
            guncelKartLimiti.ReadOnly = true;
            guncelKartLimiti.Width = 70;
            // 
            // ekstreBorcu
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            ekstreBorcu.DefaultCellStyle = dataGridViewCellStyle6;
            ekstreBorcu.HeaderText = "Ekstre Borcu";
            ekstreBorcu.Name = "ekstreBorcu";
            ekstreBorcu.ReadOnly = true;
            ekstreBorcu.Width = 70;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Güncelle";
            Guncelle.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Guncelle.Name = "Guncelle";
            Guncelle.ReadOnly = true;
            Guncelle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Guncelle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            Guncelle.Width = 70;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
            Sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Sil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            Sil.Width = 70;
            // 
            // KrediKartlariGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1085, 755);
            Controls.Add(dataGridViewKrediKarti);
            Controls.Add(panelFooter);
            Controls.Add(panelFilter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "KrediKartlariGridForm";
            Text = "GelenOdemeler";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewKrediKarti).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.DataGridView dataGridViewKrediKarti;
        private CustomControls.RoundedButton rButtonKapat;
        private System.Windows.Forms.Button buttonFiltre;
        private System.Windows.Forms.Button buttonTumKayitlariGetir;
        private System.Windows.Forms.Button buttonKrediKartiEkle;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.TextBox textBoxFiltreKartSahibi;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.DataGridViewTextBoxColumn KrediKartiId;
        private System.Windows.Forms.DataGridViewTextBoxColumn kartSahibi;
        private System.Windows.Forms.DataGridViewTextBoxColumn kartNumarasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HesapId;
        private System.Windows.Forms.DataGridViewTextBoxColumn bagliHesapAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DovizId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dovizSembol;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesapKesimTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn sonOdemeTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn kartLimiti;
        private System.Windows.Forms.DataGridViewTextBoxColumn guncelKartLimiti;
        private System.Windows.Forms.DataGridViewTextBoxColumn ekstreBorcu;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}