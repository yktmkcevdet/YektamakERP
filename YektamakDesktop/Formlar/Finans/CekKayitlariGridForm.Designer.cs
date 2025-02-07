namespace YektamakDesktop.Formlar.Finans
{
    partial class CekKayitlariGridForm
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
            roundedButton3 = new CustomControls.RoundedButton();
            roundedButton2 = new CustomControls.RoundedButton();
            roundedButton1 = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonKapat = new CustomControls.RoundedButton();
            panelFilter = new System.Windows.Forms.Panel();
            buttonEkle = new CustomControls.RoundedIconButton();
            buttonTumKayitlariGetir = new CustomControls.RoundedIconButton();
            buttonFiltre = new CustomControls.RoundedIconButton();
            dataGridViewCek = new System.Windows.Forms.DataGridView();
            CekId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cekNumarasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_dovizCinsi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_dovizCinsi_sembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            vadeTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cekinVerildigiTarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cekiVerenFirma_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cekiVerenFirma_unvan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cekiAlanFirma_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cekiAlanFirma_unvan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cekSahibiBanka_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cekSahibiBanka_unvan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cekResim_onYuzResimData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cekResim_onYuzImageFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cekResim_arkaYuzResimData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cekResim_arkaYuzImageFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            panelHeader.SuspendLayout();
            panelFooter.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCek).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Red;
            panelHeader.Controls.Add(roundedButton3);
            panelHeader.Controls.Add(roundedButton2);
            panelHeader.Controls.Add(roundedButton1);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1166, 56);
            panelHeader.TabIndex = 3;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // roundedButton3
            // 
            roundedButton3.BackColor = System.Drawing.Color.Red;
            roundedButton3.BackgroundColor = System.Drawing.Color.Red;
            roundedButton3.BorderColor = System.Drawing.Color.LavenderBlush;
            roundedButton3.BorderRadius = 10;
            roundedButton3.BorderSize = 2;
            roundedButton3.FlatAppearance.BorderSize = 0;
            roundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton3.ForeColor = System.Drawing.Color.White;
            roundedButton3.Location = new System.Drawing.Point(1117, 9);
            roundedButton3.Margin = new System.Windows.Forms.Padding(0);
            roundedButton3.Name = "roundedButton3";
            roundedButton3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton3.Size = new System.Drawing.Size(40, 38);
            roundedButton3.TabIndex = 100;
            roundedButton3.Text = "x";
            roundedButton3.TextColor = System.Drawing.Color.White;
            roundedButton3.UseVisualStyleBackColor = false;
            roundedButton3.Click += buttonClose_Click;
            // 
            // roundedButton2
            // 
            roundedButton2.BackColor = System.Drawing.Color.Red;
            roundedButton2.BackgroundColor = System.Drawing.Color.Red;
            roundedButton2.BorderColor = System.Drawing.Color.LavenderBlush;
            roundedButton2.BorderRadius = 10;
            roundedButton2.BorderSize = 2;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton2.ForeColor = System.Drawing.Color.White;
            roundedButton2.Location = new System.Drawing.Point(1037, 9);
            roundedButton2.Margin = new System.Windows.Forms.Padding(0);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton2.Size = new System.Drawing.Size(40, 38);
            roundedButton2.TabIndex = 99;
            roundedButton2.Text = "?";
            roundedButton2.TextColor = System.Drawing.Color.White;
            roundedButton2.UseVisualStyleBackColor = false;
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = System.Drawing.Color.Red;
            roundedButton1.BackgroundColor = System.Drawing.Color.Red;
            roundedButton1.BorderColor = System.Drawing.Color.LavenderBlush;
            roundedButton1.BorderRadius = 10;
            roundedButton1.BorderSize = 2;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.Location = new System.Drawing.Point(1077, 9);
            roundedButton1.Margin = new System.Windows.Forms.Padding(0);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton1.Size = new System.Drawing.Size(40, 38);
            roundedButton1.TabIndex = 98;
            roundedButton1.Text = "-";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += buttomMinimize_Click;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(12, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(136, 30);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Çek Kayıtları";
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(rButtonKapat);
            panelFooter.Location = new System.Drawing.Point(0, 570);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1166, 64);
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
            rButtonKapat.Location = new System.Drawing.Point(30, 3);
            rButtonKapat.Name = "rButtonKapat";
            rButtonKapat.Size = new System.Drawing.Size(152, 59);
            rButtonKapat.TabIndex = 0;
            rButtonKapat.Text = "KAPAT";
            rButtonKapat.TextColor = System.Drawing.Color.White;
            rButtonKapat.UseVisualStyleBackColor = false;
            rButtonKapat.Click += buttonClose_Click;
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(buttonEkle);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(buttonFiltre);
            panelFilter.Controls.Add(dataGridViewCek);
            panelFilter.Location = new System.Drawing.Point(0, 56);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1166, 512);
            panelFilter.TabIndex = 5;
            // 
            // buttonEkle
            // 
            buttonEkle.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonEkle.CornerRadius = 15;
            buttonEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonEkle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonEkle.ForeColor = System.Drawing.Color.Gainsboro;
            buttonEkle.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            buttonEkle.IconColor = System.Drawing.Color.Gainsboro;
            buttonEkle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonEkle.IconSize = 25;
            buttonEkle.Location = new System.Drawing.Point(1062, 6);
            buttonEkle.Name = "buttonEkle";
            buttonEkle.Size = new System.Drawing.Size(93, 46);
            buttonEkle.TabIndex = 26;
            buttonEkle.Text = "Kayıt Ekle";
            buttonEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonEkle.UseVisualStyleBackColor = false;
            buttonEkle.Click += buttonEkle_Click;
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
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(906, 6);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(93, 46);
            buttonTumKayitlariGetir.TabIndex = 25;
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
            buttonFiltre.Location = new System.Drawing.Point(815, 6);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(82, 46);
            buttonFiltre.TabIndex = 24;
            buttonFiltre.Text = "Filtrele";
            buttonFiltre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonFiltre.UseVisualStyleBackColor = false;
            buttonFiltre.Click += buttonFiltre_Click;
            // 
            // dataGridViewCek
            // 
            dataGridViewCek.AllowUserToAddRows = false;
            dataGridViewCek.AllowUserToDeleteRows = false;
            dataGridViewCek.AllowUserToOrderColumns = true;
            dataGridViewCek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { CekId, cekNumarasi, tutar_tutar, tutar_dovizCinsi_id, tutar_dovizCinsi_sembol, vadeTarihi, cekinVerildigiTarih, cekiVerenFirma_id, cekiVerenFirma_unvan, cekiAlanFirma_id, cekiAlanFirma_unvan, cekSahibiBanka_id, cekSahibiBanka_unvan, cekResim_onYuzResimData, cekResim_onYuzImageFormat, cekResim_arkaYuzResimData, cekResim_arkaYuzImageFormat, Guncelle, Sil });
            dataGridViewCek.Location = new System.Drawing.Point(3, 108);
            dataGridViewCek.Name = "dataGridViewCek";
            dataGridViewCek.ReadOnly = true;
            dataGridViewCek.RowTemplate.Height = 25;
            dataGridViewCek.Size = new System.Drawing.Size(1166, 400);
            dataGridViewCek.TabIndex = 6;
            dataGridViewCek.CellClick += dataGridView_CellClick;
            dataGridViewCek.ColumnWidthChanged += dataGridView_ColumnWidthChanged;
            dataGridViewCek.Scroll += dataGridView_Scroll;
            // 
            // CekId
            // 
            CekId.HeaderText = "CekId";
            CekId.Name = "CekId";
            CekId.ReadOnly = true;
            CekId.Visible = false;
            // 
            // cekNumarasi
            // 
            cekNumarasi.DataPropertyName = "filtre";
            cekNumarasi.HeaderText = "Çek No";
            cekNumarasi.Name = "cekNumarasi";
            cekNumarasi.ReadOnly = true;
            // 
            // tutar_tutar
            // 
            tutar_tutar.DataPropertyName = "filtre";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            tutar_tutar.DefaultCellStyle = dataGridViewCellStyle1;
            tutar_tutar.HeaderText = "Tutar";
            tutar_tutar.Name = "tutar_tutar";
            tutar_tutar.ReadOnly = true;
            // 
            // tutar_dovizCinsi_id
            // 
            tutar_dovizCinsi_id.HeaderText = "DovizId";
            tutar_dovizCinsi_id.Name = "tutar_dovizCinsi_id";
            tutar_dovizCinsi_id.ReadOnly = true;
            tutar_dovizCinsi_id.Visible = false;
            // 
            // tutar_dovizCinsi_sembol
            // 
            tutar_dovizCinsi_sembol.HeaderText = "Döviz Cinsi";
            tutar_dovizCinsi_sembol.Name = "tutar_dovizCinsi_sembol";
            tutar_dovizCinsi_sembol.ReadOnly = true;
            // 
            // vadeTarihi
            // 
            vadeTarihi.DataPropertyName = "filtre";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            vadeTarihi.DefaultCellStyle = dataGridViewCellStyle2;
            vadeTarihi.HeaderText = "VadeTarihi";
            vadeTarihi.Name = "vadeTarihi";
            vadeTarihi.ReadOnly = true;
            // 
            // cekinVerildigiTarih
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            cekinVerildigiTarih.DefaultCellStyle = dataGridViewCellStyle3;
            cekinVerildigiTarih.HeaderText = "Verildiği Tarihi";
            cekinVerildigiTarih.Name = "cekinVerildigiTarih";
            cekinVerildigiTarih.ReadOnly = true;
            // 
            // cekiVerenFirma_id
            // 
            cekiVerenFirma_id.HeaderText = "cekiVerenFirmaId";
            cekiVerenFirma_id.Name = "cekiVerenFirma_id";
            cekiVerenFirma_id.ReadOnly = true;
            cekiVerenFirma_id.Visible = false;
            // 
            // cekiVerenFirma_unvan
            // 
            cekiVerenFirma_unvan.DataPropertyName = "filtre";
            cekiVerenFirma_unvan.HeaderText = "Çeki Veren Firma";
            cekiVerenFirma_unvan.Name = "cekiVerenFirma_unvan";
            cekiVerenFirma_unvan.ReadOnly = true;
            cekiVerenFirma_unvan.Width = 150;
            // 
            // cekiAlanFirma_id
            // 
            cekiAlanFirma_id.HeaderText = "cekiAlanFirmaId";
            cekiAlanFirma_id.Name = "cekiAlanFirma_id";
            cekiAlanFirma_id.ReadOnly = true;
            cekiAlanFirma_id.Visible = false;
            // 
            // cekiAlanFirma_unvan
            // 
            cekiAlanFirma_unvan.DataPropertyName = "filtre";
            cekiAlanFirma_unvan.HeaderText = "Çeki Alan Firma";
            cekiAlanFirma_unvan.Name = "cekiAlanFirma_unvan";
            cekiAlanFirma_unvan.ReadOnly = true;
            cekiAlanFirma_unvan.Width = 150;
            // 
            // cekSahibiBanka_id
            // 
            cekSahibiBanka_id.HeaderText = "cekSahibiBankaId";
            cekSahibiBanka_id.Name = "cekSahibiBanka_id";
            cekSahibiBanka_id.ReadOnly = true;
            cekSahibiBanka_id.Visible = false;
            // 
            // cekSahibiBanka_unvan
            // 
            cekSahibiBanka_unvan.DataPropertyName = "filtre";
            cekSahibiBanka_unvan.HeaderText = "Çek Banka";
            cekSahibiBanka_unvan.Name = "cekSahibiBanka_unvan";
            cekSahibiBanka_unvan.ReadOnly = true;
            // 
            // cekResim_onYuzResimData
            // 
            cekResim_onYuzResimData.HeaderText = "cekResim_onYuzResimData";
            cekResim_onYuzResimData.Name = "cekResim_onYuzResimData";
            cekResim_onYuzResimData.ReadOnly = true;
            cekResim_onYuzResimData.Visible = false;
            // 
            // cekResim_onYuzImageFormat
            // 
            cekResim_onYuzImageFormat.HeaderText = "cekResim_onYuzImageFormat";
            cekResim_onYuzImageFormat.Name = "cekResim_onYuzImageFormat";
            cekResim_onYuzImageFormat.ReadOnly = true;
            cekResim_onYuzImageFormat.Visible = false;
            // 
            // cekResim_arkaYuzResimData
            // 
            cekResim_arkaYuzResimData.HeaderText = "cekResim_arkaYuzResimData";
            cekResim_arkaYuzResimData.Name = "cekResim_arkaYuzResimData";
            cekResim_arkaYuzResimData.ReadOnly = true;
            cekResim_arkaYuzResimData.Visible = false;
            // 
            // cekResim_arkaYuzImageFormat
            // 
            cekResim_arkaYuzImageFormat.HeaderText = "cekResim_arkaYuzImageFormat";
            cekResim_arkaYuzImageFormat.Name = "cekResim_arkaYuzImageFormat";
            cekResim_arkaYuzImageFormat.ReadOnly = true;
            cekResim_arkaYuzImageFormat.Visible = false;
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
            // 
            // CekKayitlariGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1167, 634);
            Controls.Add(panelFilter);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "CekKayitlariGridForm";
            Text = "CekKayitlariGridForm";
            Load += form_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFooter.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCek).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private CustomControls.RoundedButton rButtonKapat;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.DataGridView dataGridViewCek;
        private CustomControls.RoundedButton roundedButton3;
        private CustomControls.RoundedButton roundedButton2;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.RoundedIconButton buttonEkle;
        private CustomControls.RoundedIconButton buttonTumKayitlariGetir;
        private CustomControls.RoundedIconButton buttonFiltre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CekId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cekNumarasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_dovizCinsi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_dovizCinsi_sembol;
        private System.Windows.Forms.DataGridViewTextBoxColumn vadeTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cekinVerildigiTarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn cekiVerenFirma_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cekiVerenFirma_unvan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cekiAlanFirma_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cekiAlanFirma_unvan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cekSahibiBanka_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cekSahibiBanka_unvan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cekResim_onYuzResimData;
        private System.Windows.Forms.DataGridViewTextBoxColumn cekResim_onYuzImageFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn cekResim_arkaYuzResimData;
        private System.Windows.Forms.DataGridViewTextBoxColumn cekResim_arkaYuzImageFormat;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}