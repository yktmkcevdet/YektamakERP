namespace YektamakDesktop.Formlar.Genel
{
    partial class SatinalmaFaturaGridForm
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
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            panelFilter = new System.Windows.Forms.Panel();
            dataGridViewSatinalmaFatura = new System.Windows.Forms.DataGridView();
            SatinalmaFaturaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            faturaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            faturaTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_Tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_DovizCinsi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_DovizCinsi_sembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            kdv_kdvId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            kdv_kdvOrani = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tevkifat_tevkifatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            KDVliTutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cariKart_cariKartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cariKart_cariAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            giderTuru_giderTurId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            giderTuru_giderTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            siparisIdList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            faturaResim_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            buttonKayitEkle = new CustomControls.RoundedIconButton();
            buttonTumKayitlariGetir = new CustomControls.RoundedIconButton();
            buttonFiltre = new CustomControls.RoundedIconButton();
            panel2 = new System.Windows.Forms.Panel();
            rButtonCikis = new CustomControls.RoundedButton();
            panelHeader.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatinalmaFatura).BeginInit();
            panel2.SuspendLayout();
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
            panelHeader.Size = new System.Drawing.Size(1186, 56);
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
            buttonClose.Location = new System.Drawing.Point(1139, 9);
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
            buttonHelp.Location = new System.Drawing.Point(1059, 9);
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
            buttomMinimize.Location = new System.Drawing.Point(1099, 9);
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
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(3, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(208, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Satınalma Faturaları";
            // 
            // panelFilter
            // 
            panelFilter.BackColor = System.Drawing.Color.Silver;
            panelFilter.Controls.Add(dataGridViewSatinalmaFatura);
            panelFilter.Location = new System.Drawing.Point(1, 56);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1186, 612);
            panelFilter.TabIndex = 1;
            panelFilter.MouseDown += panelHeader_MouseDown;
            panelFilter.MouseMove += panelHeader_MouseMove;
            panelFilter.MouseUp += panelHeader_MouseUp;
            // 
            // dataGridViewSatinalmaFatura
            // 
            dataGridViewSatinalmaFatura.AllowUserToAddRows = false;
            dataGridViewSatinalmaFatura.AllowUserToDeleteRows = false;
            dataGridViewSatinalmaFatura.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewSatinalmaFatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSatinalmaFatura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { SatinalmaFaturaId, faturaNo, faturaTarihi, tutar_Tutar, tutar_DovizCinsi_id, tutar_DovizCinsi_sembol, kdv_kdvId, kdv_kdvOrani, tevkifat_tevkifatId, KDVliTutar, cariKart_cariKartId, cariKart_cariAdi, giderTuru_giderTurId, giderTuru_giderTuru, siparisIdList, faturaResim_id, Guncelle, Sil });
            dataGridViewSatinalmaFatura.Location = new System.Drawing.Point(3, 95);
            dataGridViewSatinalmaFatura.Name = "dataGridViewSatinalmaFatura";
            dataGridViewSatinalmaFatura.ReadOnly = true;
            dataGridViewSatinalmaFatura.RowTemplate.Height = 25;
            dataGridViewSatinalmaFatura.Size = new System.Drawing.Size(1183, 517);
            dataGridViewSatinalmaFatura.TabIndex = 3;
            dataGridViewSatinalmaFatura.CellClick += dataGridView_CellClick;
            dataGridViewSatinalmaFatura.ColumnWidthChanged += dataGridViewSatinalmaFatura_ColumnWidthChanged;
            dataGridViewSatinalmaFatura.Scroll += dataGridView_Scroll;
            // 
            // SatinalmaFaturaId
            // 
            SatinalmaFaturaId.HeaderText = "SatinalmaFaturaId";
            SatinalmaFaturaId.Name = "SatinalmaFaturaId";
            SatinalmaFaturaId.ReadOnly = true;
            SatinalmaFaturaId.Visible = false;
            // 
            // faturaNo
            // 
            faturaNo.DataPropertyName = "filtre";
            faturaNo.HeaderText = "Fatura No";
            faturaNo.Name = "faturaNo";
            faturaNo.ReadOnly = true;
            faturaNo.Width = 120;
            // 
            // faturaTarihi
            // 
            faturaTarihi.DataPropertyName = "filtre";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            faturaTarihi.DefaultCellStyle = dataGridViewCellStyle1;
            faturaTarihi.HeaderText = "Fatura Tarihi";
            faturaTarihi.Name = "faturaTarihi";
            faturaTarihi.ReadOnly = true;
            faturaTarihi.Width = 105;
            // 
            // tutar_Tutar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            tutar_Tutar.DefaultCellStyle = dataGridViewCellStyle2;
            tutar_Tutar.HeaderText = "Tutar";
            tutar_Tutar.Name = "tutar_Tutar";
            tutar_Tutar.ReadOnly = true;
            tutar_Tutar.Width = 59;
            // 
            // tutar_DovizCinsi_id
            // 
            tutar_DovizCinsi_id.HeaderText = "tutar_DovizCinsi_id";
            tutar_DovizCinsi_id.Name = "tutar_DovizCinsi_id";
            tutar_DovizCinsi_id.ReadOnly = true;
            tutar_DovizCinsi_id.Visible = false;
            // 
            // tutar_DovizCinsi_sembol
            // 
            tutar_DovizCinsi_sembol.HeaderText = "Döviz Türü";
            tutar_DovizCinsi_sembol.Name = "tutar_DovizCinsi_sembol";
            tutar_DovizCinsi_sembol.ReadOnly = true;
            // 
            // kdv_kdvId
            // 
            kdv_kdvId.HeaderText = "kdv_kdvId";
            kdv_kdvId.Name = "kdv_kdvId";
            kdv_kdvId.ReadOnly = true;
            kdv_kdvId.Visible = false;
            // 
            // kdv_kdvOrani
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            kdv_kdvOrani.DefaultCellStyle = dataGridViewCellStyle3;
            kdv_kdvOrani.HeaderText = "KDV";
            kdv_kdvOrani.Name = "kdv_kdvOrani";
            kdv_kdvOrani.ReadOnly = true;
            kdv_kdvOrani.Width = 54;
            // 
            // tevkifat_tevkifatId
            // 
            tevkifat_tevkifatId.HeaderText = "TevkifatId";
            tevkifat_tevkifatId.Name = "tevkifat_tevkifatId";
            tevkifat_tevkifatId.ReadOnly = true;
            tevkifat_tevkifatId.Visible = false;
            // 
            // KDVliTutar
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            KDVliTutar.DefaultCellStyle = dataGridViewCellStyle4;
            KDVliTutar.HeaderText = "Tutar + KDV";
            KDVliTutar.Name = "KDVliTutar";
            KDVliTutar.ReadOnly = true;
            KDVliTutar.Width = 95;
            // 
            // cariKart_cariKartId
            // 
            cariKart_cariKartId.HeaderText = "cariKart_cariKartId";
            cariKart_cariKartId.Name = "cariKart_cariKartId";
            cariKart_cariKartId.ReadOnly = true;
            cariKart_cariKartId.Visible = false;
            // 
            // cariKart_cariAdi
            // 
            cariKart_cariAdi.DataPropertyName = "filtre";
            cariKart_cariAdi.HeaderText = "Firma";
            cariKart_cariAdi.Name = "cariKart_cariAdi";
            cariKart_cariAdi.ReadOnly = true;
            cariKart_cariAdi.Width = 200;
            // 
            // giderTuru_giderTurId
            // 
            giderTuru_giderTurId.HeaderText = "giderTuru_giderTurId";
            giderTuru_giderTurId.Name = "giderTuru_giderTurId";
            giderTuru_giderTurId.ReadOnly = true;
            giderTuru_giderTurId.Visible = false;
            // 
            // giderTuru_giderTuru
            // 
            giderTuru_giderTuru.DataPropertyName = "filtre";
            giderTuru_giderTuru.HeaderText = "Gider Türü";
            giderTuru_giderTuru.Name = "giderTuru_giderTuru";
            giderTuru_giderTuru.ReadOnly = true;
            giderTuru_giderTuru.Width = 87;
            // 
            // siparisIdList
            // 
            siparisIdList.HeaderText = "siparisIdList";
            siparisIdList.Name = "siparisIdList";
            siparisIdList.ReadOnly = true;
            siparisIdList.Visible = false;
            // 
            // faturaResim_id
            // 
            faturaResim_id.HeaderText = "faturaResim_id";
            faturaResim_id.Name = "faturaResim_id";
            faturaResim_id.ReadOnly = true;
            faturaResim_id.Visible = false;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Güncelle";
            Guncelle.Image = Properties.Resources.update_icon;
            Guncelle.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Guncelle.Name = "Guncelle";
            Guncelle.ReadOnly = true;
            Guncelle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Guncelle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            Guncelle.Width = 78;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.Image = Properties.Resources.delete_icon;
            Sil.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
            Sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Sil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            Sil.Width = 44;
            // 
            // buttonKayitEkle
            // 
            buttonKayitEkle.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonKayitEkle.CornerRadius = 15;
            buttonKayitEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonKayitEkle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonKayitEkle.ForeColor = System.Drawing.Color.Gainsboro;
            buttonKayitEkle.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            buttonKayitEkle.IconColor = System.Drawing.Color.Gainsboro;
            buttonKayitEkle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonKayitEkle.IconSize = 25;
            buttonKayitEkle.Location = new System.Drawing.Point(1092, 57);
            buttonKayitEkle.Name = "buttonKayitEkle";
            buttonKayitEkle.Size = new System.Drawing.Size(93, 46);
            buttonKayitEkle.TabIndex = 18;
            buttonKayitEkle.Text = "Kayıt Ekle";
            buttonKayitEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonKayitEkle.UseVisualStyleBackColor = false;
            buttonKayitEkle.Click += buttonEkle_Click;
            // 
            // buttonTumKayitlariGetir
            // 
            buttonTumKayitlariGetir.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonTumKayitlariGetir.CornerRadius = 15;
            buttonTumKayitlariGetir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonTumKayitlariGetir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonTumKayitlariGetir.ForeColor = System.Drawing.Color.Gainsboro;
            buttonTumKayitlariGetir.IconChar = FontAwesome.Sharp.IconChar.FilterCircleXmark;
            buttonTumKayitlariGetir.IconColor = System.Drawing.Color.Gainsboro;
            buttonTumKayitlariGetir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonTumKayitlariGetir.IconSize = 25;
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(988, 57);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(93, 46);
            buttonTumKayitlariGetir.TabIndex = 17;
            buttonTumKayitlariGetir.Text = "Tüm Kayıtlar";
            buttonTumKayitlariGetir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonTumKayitlariGetir.UseVisualStyleBackColor = false;
            buttonTumKayitlariGetir.Click += buttonTumKayitlariGetir_Click;
            // 
            // buttonFiltre
            // 
            buttonFiltre.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonFiltre.CornerRadius = 15;
            buttonFiltre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonFiltre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonFiltre.ForeColor = System.Drawing.Color.Gainsboro;
            buttonFiltre.IconChar = FontAwesome.Sharp.IconChar.Filter;
            buttonFiltre.IconColor = System.Drawing.Color.Gainsboro;
            buttonFiltre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonFiltre.IconSize = 25;
            buttonFiltre.Location = new System.Drawing.Point(900, 57);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(82, 46);
            buttonFiltre.TabIndex = 16;
            buttonFiltre.Text = "Filtrele";
            buttonFiltre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonFiltre.UseVisualStyleBackColor = false;
            buttonFiltre.Click += buttonFiltre_Click;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            panel2.Controls.Add(rButtonCikis);
            panel2.Location = new System.Drawing.Point(0, 669);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1186, 65);
            panel2.TabIndex = 2;
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
            // SatinalmaFaturaGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1187, 755);
            Controls.Add(buttonKayitEkle);
            Controls.Add(buttonTumKayitlariGetir);
            Controls.Add(panel2);
            Controls.Add(buttonFiltre);
            Controls.Add(panelHeader);
            Controls.Add(panelFilter);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaFaturaGridForm";
            Text = "SatinalmaFaturaGridFormu";
            Load += SatinalmaFaturaGridForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatinalmaFatura).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.DataGridView dataGridViewSatinalmaFatura;
        private CustomControls.RoundedButton rButtonCikis;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private CustomControls.RoundedIconButton buttonTumKayitlariGetir;
        private CustomControls.RoundedIconButton buttonFiltre;
        private CustomControls.RoundedIconButton buttonKayitEkle;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatinalmaFaturaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn faturaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn faturaTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_Tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_DovizCinsi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_DovizCinsi_sembol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdv_kdvId;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdv_kdvOrani;
        private System.Windows.Forms.DataGridViewTextBoxColumn tevkifat_tevkifatId;
        private System.Windows.Forms.DataGridViewTextBoxColumn KDVliTutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariKart_cariKartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariKart_cariAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn giderTuru_giderTurId;
        private System.Windows.Forms.DataGridViewTextBoxColumn giderTuru_giderTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn siparisIdList;
        private System.Windows.Forms.DataGridViewTextBoxColumn faturaResim_id;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}