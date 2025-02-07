namespace YektamakDesktop.Formlar.Satis
{
    partial class SatisSiparisGridForm
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
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            panelFilter = new System.Windows.Forms.Panel();
            dataGridView = new System.Windows.Forms.DataGridView();
            SiparisId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisProje_projeKod_projeKodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisProje_projeKod_projeKodString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisProje_projeKod_marka_markaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisProje_projeKod_marka_markaAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisProje_musteri_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisProje_musteri_unvan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            siparisTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            teslimVadesi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisTutari_tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisTutari_dovizCinsi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            kdv_kdvOrani = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisTutari_dovizCinsi_sembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ongoruMaliyeti_tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ongoruMaliyeti_dovizCinsi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ongoruMaliyeti_dovizCinsi_sembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            buttonSatisSiparisEkle = new System.Windows.Forms.Button();
            buttonTumKayitlariGetir = new System.Windows.Forms.Button();
            buttonFiltre = new System.Windows.Forms.Button();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonCikis = new CustomControls.RoundedButton();
            panelHeader.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Red;
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1239, 56);
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
            buttonClose.Location = new System.Drawing.Point(1175, 9);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(40, 38);
            buttonClose.TabIndex = 106;
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
            buttonHelp.Location = new System.Drawing.Point(1095, 9);
            buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonHelp.Size = new System.Drawing.Size(40, 38);
            buttonHelp.TabIndex = 105;
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
            buttomMinimize.Location = new System.Drawing.Point(1135, 9);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(40, 38);
            buttomMinimize.TabIndex = 104;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = System.Drawing.Color.Red;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(3, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(217, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Satış Sipariş Kayıtları";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFilter
            // 
            panelFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelFilter.BackColor = System.Drawing.Color.Silver;
            panelFilter.Controls.Add(dataGridView);
            panelFilter.Controls.Add(buttonSatisSiparisEkle);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(buttonFiltre);
            panelFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            panelFilter.Location = new System.Drawing.Point(0, 53);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1239, 636);
            panelFilter.TabIndex = 2;
            // 
            // dataGridViewSatisSiparis
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { SiparisId, satisProje_projeKod_projeKodId, satisProje_projeKod_projeKodString, satisProje_projeKod_marka_markaId, satisProje_projeKod_marka_markaAd, satisProje_musteri_id, satisProje_musteri_unvan, siparisTarihi, teslimVadesi, satisTutari_tutar, satisTutari_dovizCinsi_id, kdv_kdvOrani, satisTutari_dovizCinsi_sembol, ongoruMaliyeti_tutar, ongoruMaliyeti_dovizCinsi_id, ongoruMaliyeti_dovizCinsi_sembol, Guncelle, Sil });
            dataGridView.Location = new System.Drawing.Point(0, 90);
            dataGridView.Name = "dataGridViewSatisSiparis";
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new System.Drawing.Size(1239, 546);
            dataGridView.TabIndex = 3;
            dataGridView.CellClick += dataGridViewSatisSiparis_CellClick;
            dataGridView.ColumnWidthChanged += dataGridViewSatisSiparis_ColumnWidthChanged;
            dataGridView.Scroll += dataGridViewSatisSiparis_Scroll;
            // 
            // SiparisId
            // 
            SiparisId.HeaderText = "SiparisId";
            SiparisId.Name = "SiparisId";
            SiparisId.ReadOnly = true;
            SiparisId.Visible = false;
            // 
            // satisProje_projeKod_projeKodId
            // 
            satisProje_projeKod_projeKodId.HeaderText = "projeKodId";
            satisProje_projeKod_projeKodId.Name = "satisProje_projeKod_projeKodId";
            satisProje_projeKod_projeKodId.ReadOnly = true;
            satisProje_projeKod_projeKodId.Visible = false;
            // 
            // satisProje_projeKod_projeKodString
            // 
            satisProje_projeKod_projeKodString.DataPropertyName = "filtre";
            satisProje_projeKod_projeKodString.HeaderText = "Proje Kodu";
            satisProje_projeKod_projeKodString.Name = "satisProje_projeKod_projeKodString";
            satisProje_projeKod_projeKodString.ReadOnly = true;
            // 
            // satisProje_projeKod_marka_markaId
            // 
            satisProje_projeKod_marka_markaId.HeaderText = "MarkaId";
            satisProje_projeKod_marka_markaId.Name = "satisProje_projeKod_marka_markaId";
            satisProje_projeKod_marka_markaId.ReadOnly = true;
            satisProje_projeKod_marka_markaId.Visible = false;
            // 
            // satisProje_projeKod_marka_markaAd
            // 
            satisProje_projeKod_marka_markaAd.DataPropertyName = "filtre";
            satisProje_projeKod_marka_markaAd.HeaderText = "Marka";
            satisProje_projeKod_marka_markaAd.Name = "satisProje_projeKod_marka_markaAd";
            satisProje_projeKod_marka_markaAd.ReadOnly = true;
            // 
            // satisProje_musteri_id
            // 
            satisProje_musteri_id.HeaderText = "Müşteri Id";
            satisProje_musteri_id.Name = "satisProje_musteri_id";
            satisProje_musteri_id.ReadOnly = true;
            satisProje_musteri_id.Visible = false;
            // 
            // satisProje_musteri_unvan
            // 
            satisProje_musteri_unvan.DataPropertyName = "filtre";
            satisProje_musteri_unvan.FillWeight = 250F;
            satisProje_musteri_unvan.HeaderText = "Müşteri";
            satisProje_musteri_unvan.Name = "satisProje_musteri_unvan";
            satisProje_musteri_unvan.ReadOnly = true;
            satisProje_musteri_unvan.Width = 250;
            // 
            // siparisTarihi
            // 
            siparisTarihi.DataPropertyName = "filtre";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            siparisTarihi.DefaultCellStyle = dataGridViewCellStyle1;
            siparisTarihi.HeaderText = "SiparişTarihi";
            siparisTarihi.Name = "siparisTarihi";
            siparisTarihi.ReadOnly = true;
            // 
            // teslimVadesi
            // 
            teslimVadesi.HeaderText = "Termin (Gün)";
            teslimVadesi.Name = "teslimVadesi";
            teslimVadesi.ReadOnly = true;
            teslimVadesi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            teslimVadesi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            teslimVadesi.Width = 85;
            // 
            // satisTutari_tutar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0.00";
            dataGridViewCellStyle2.NullValue = null;
            satisTutari_tutar.DefaultCellStyle = dataGridViewCellStyle2;
            satisTutari_tutar.HeaderText = "Satış Tutarı";
            satisTutari_tutar.Name = "satisTutari_tutar";
            satisTutari_tutar.ReadOnly = true;
            // 
            // satisTutari_dovizCinsi_id
            // 
            satisTutari_dovizCinsi_id.HeaderText = "Satış Döviz ID";
            satisTutari_dovizCinsi_id.Name = "satisTutari_dovizCinsi_id";
            satisTutari_dovizCinsi_id.ReadOnly = true;
            satisTutari_dovizCinsi_id.Visible = false;
            satisTutari_dovizCinsi_id.Width = 50;
            // 
            // kdv_kdvOrani
            // 
            kdv_kdvOrani.HeaderText = "KDVOranı";
            kdv_kdvOrani.Name = "kdv_kdvOrani";
            kdv_kdvOrani.ReadOnly = true;
            kdv_kdvOrani.Width = 70;
            // 
            // satisTutari_dovizCinsi_sembol
            // 
            satisTutari_dovizCinsi_sembol.HeaderText = "Satış Döviz";
            satisTutari_dovizCinsi_sembol.Name = "satisTutari_dovizCinsi_sembol";
            satisTutari_dovizCinsi_sembol.ReadOnly = true;
            satisTutari_dovizCinsi_sembol.Width = 90;
            // 
            // ongoruMaliyeti_tutar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0.00";
            ongoruMaliyeti_tutar.DefaultCellStyle = dataGridViewCellStyle3;
            ongoruMaliyeti_tutar.HeaderText = "Öngörü Maliyeti";
            ongoruMaliyeti_tutar.Name = "ongoruMaliyeti_tutar";
            ongoruMaliyeti_tutar.ReadOnly = true;
            ongoruMaliyeti_tutar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            ongoruMaliyeti_tutar.Width = 120;
            // 
            // ongoruMaliyeti_dovizCinsi_id
            // 
            ongoruMaliyeti_dovizCinsi_id.HeaderText = "Maliyet Döviz ID";
            ongoruMaliyeti_dovizCinsi_id.Name = "ongoruMaliyeti_dovizCinsi_id";
            ongoruMaliyeti_dovizCinsi_id.ReadOnly = true;
            ongoruMaliyeti_dovizCinsi_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            ongoruMaliyeti_dovizCinsi_id.Visible = false;
            ongoruMaliyeti_dovizCinsi_id.Width = 50;
            // 
            // ongoruMaliyeti_dovizCinsi_sembol
            // 
            ongoruMaliyeti_dovizCinsi_sembol.HeaderText = "Maliyet Döviz";
            ongoruMaliyeti_dovizCinsi_sembol.Name = "ongoruMaliyeti_dovizCinsi_sembol";
            ongoruMaliyeti_dovizCinsi_sembol.ReadOnly = true;
            ongoruMaliyeti_dovizCinsi_sembol.Width = 110;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Guncelle";
            Guncelle.Image = Properties.Resources.update_icon;
            Guncelle.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Guncelle.Name = "Guncelle";
            Guncelle.ReadOnly = true;
            Guncelle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Guncelle.Width = 30;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.Image = Properties.Resources.delete_icon;
            Sil.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
            Sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Sil.Width = 30;
            // 
            // buttonSatisSiparisEkle
            // 
            buttonSatisSiparisEkle.BackColor = System.Drawing.Color.Silver;
            buttonSatisSiparisEkle.BackgroundImage = Properties.Resources.Plus_Symbol_PNG_Image_HD;
            buttonSatisSiparisEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonSatisSiparisEkle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSatisSiparisEkle.ForeColor = System.Drawing.Color.Transparent;
            buttonSatisSiparisEkle.Location = new System.Drawing.Point(1155, 9);
            buttonSatisSiparisEkle.Name = "buttonSatisSiparisEkle";
            buttonSatisSiparisEkle.Size = new System.Drawing.Size(58, 52);
            buttonSatisSiparisEkle.TabIndex = 11;
            buttonSatisSiparisEkle.UseVisualStyleBackColor = false;
            buttonSatisSiparisEkle.Click += buttonSatisSiparisEkle_Click;
            // 
            // buttonTumKayitlariGetir
            // 
            buttonTumKayitlariGetir.BackColor = System.Drawing.Color.Tomato;
            buttonTumKayitlariGetir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonTumKayitlariGetir.ForeColor = System.Drawing.Color.Transparent;
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(961, 9);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(103, 52);
            buttonTumKayitlariGetir.TabIndex = 10;
            buttonTumKayitlariGetir.Text = "Tüm Kayıtları Getir";
            buttonTumKayitlariGetir.UseVisualStyleBackColor = false;
            buttonTumKayitlariGetir.Click += buttonTumKayitlariGetir_Click;
            // 
            // buttonFiltre
            // 
            buttonFiltre.BackgroundImage = Properties.Resources.DataReviewWithMagnifier5;
            buttonFiltre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            buttonFiltre.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonFiltre.ForeColor = System.Drawing.Color.Blue;
            buttonFiltre.Location = new System.Drawing.Point(848, 9);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(107, 52);
            buttonFiltre.TabIndex = 9;
            buttonFiltre.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            buttonFiltre.UseVisualStyleBackColor = true;
            buttonFiltre.Click += buttonFiltre_Click;
            // 
            // panelFooter
            // 
            panelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            panelFooter.Controls.Add(rButtonCikis);
            panelFooter.Location = new System.Drawing.Point(0, 692);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1239, 65);
            panelFooter.TabIndex = 1;
            // 
            // rButtonCikis
            // 
            rButtonCikis.BackColor = System.Drawing.Color.Brown;
            rButtonCikis.BackgroundColor = System.Drawing.Color.Brown;
            rButtonCikis.BorderColor = System.Drawing.Color.Crimson;
            rButtonCikis.BorderRadius = 40;
            rButtonCikis.BorderSize = 5;
            rButtonCikis.FlatAppearance.BorderSize = 0;
            rButtonCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonCikis.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonCikis.ForeColor = System.Drawing.Color.White;
            rButtonCikis.Location = new System.Drawing.Point(3, 3);
            rButtonCikis.Name = "rButtonCikis";
            rButtonCikis.Size = new System.Drawing.Size(152, 59);
            rButtonCikis.TabIndex = 0;
            rButtonCikis.Text = "KAPAT";
            rButtonCikis.TextColor = System.Drawing.Color.White;
            rButtonCikis.UseVisualStyleBackColor = false;
            rButtonCikis.Click += rButtonCikis_Click;
            // 
            // SatisSiparisGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1239, 755);
            Controls.Add(panelFilter);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatisSiparisGridForm";
            Text = "PersonelGrid";
            Load += SatisSiparisGridForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private CustomControls.RoundedButton rButtonCikis;
        private System.Windows.Forms.Panel panelFilter;
        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonFiltre;
        private System.Windows.Forms.Button buttonTumKayitlariGetir;
        private System.Windows.Forms.Button buttonSatisSiparisEkle;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiparisId;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisProje_projeKod_projeKodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisProje_projeKod_projeKodString;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisProje_projeKod_marka_markaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisProje_projeKod_marka_markaAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisProje_musteri_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisProje_musteri_unvan;
        private System.Windows.Forms.DataGridViewTextBoxColumn siparisTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn teslimVadesi;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisTutari_tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisTutari_dovizCinsi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdv_kdvOrani;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisTutari_dovizCinsi_sembol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ongoruMaliyeti_tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ongoruMaliyeti_dovizCinsi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ongoruMaliyeti_dovizCinsi_sembol;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}