namespace YektamakDesktop.Formlar.Satis
{
    partial class SatisSiparisTeklifTalepGridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatisSiparisTeklifTalepGridForm));
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            panelFilter = new System.Windows.Forms.Panel();
            dataGridView = new System.Windows.Forms.DataGridView();
            buttonSatisSiparisTeklifTalepEkle = new System.Windows.Forms.Button();
            buttonTumKayitlariGetir = new System.Windows.Forms.Button();
            buttonFiltre = new System.Windows.Forms.Button();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonCikis = new CustomControls.RoundedButton();
            teklifTalepId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            teklifTalepTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            musteri_FirmaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            musteri_Unvan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            teklifKonusu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            marka_MarkaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            marka_MarkaAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            AltGrup_altGrupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            AltGrup_AltGrupAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            referansKaynak_referansKaynakId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            referanskaynak_referansKaynakAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisSorumluId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisSorumlusu_PersonelAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            maliyetSorumlusu_PersonelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            maliyetSorumlusu_PersonelAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Onay = new System.Windows.Forms.DataGridViewImageColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
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
            labelHeader.Size = new System.Drawing.Size(277, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Satış Sipariş Teklif Talepleri";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            labelHeader.Click += labelHeader_Click;
            // 
            // panelFilter
            // 
            panelFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelFilter.BackColor = System.Drawing.Color.Silver;
            panelFilter.Controls.Add(dataGridView);
            panelFilter.Controls.Add(buttonSatisSiparisTeklifTalepEkle);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(buttonFiltre);
            panelFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            panelFilter.Location = new System.Drawing.Point(0, 53);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1239, 636);
            panelFilter.TabIndex = 2;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { teklifTalepId, teklifTalepTarihi, musteri_FirmaId, musteri_Unvan, teklifKonusu, marka_MarkaId, marka_MarkaAd, AltGrup_altGrupId, AltGrup_AltGrupAd, referansKaynak_referansKaynakId, referanskaynak_referansKaynakAdi, satisSorumluId, satisSorumlusu_PersonelAd, maliyetSorumlusu_PersonelId, maliyetSorumlusu_PersonelAd, Onay, Guncelle, Sil });
            dataGridView.Location = new System.Drawing.Point(0, 90);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new System.Drawing.Size(1239, 546);
            dataGridView.TabIndex = 3;
            dataGridView.CellClick += dataGridViewSatisSiparis_CellClick;
            dataGridView.ColumnWidthChanged += dataGridViewSatisSiparisTeklifTalep_ColumnWidthChanged;
            dataGridView.Scroll += dataGridViewSatisSiparisTeklifTalep_Scroll;
            // 
            // buttonSatisSiparisTeklifTalepEkle
            // 
            buttonSatisSiparisTeklifTalepEkle.BackColor = System.Drawing.Color.Silver;
            buttonSatisSiparisTeklifTalepEkle.BackgroundImage = Properties.Resources.Plus_Symbol_PNG_Image_HD;
            buttonSatisSiparisTeklifTalepEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonSatisSiparisTeklifTalepEkle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSatisSiparisTeklifTalepEkle.ForeColor = System.Drawing.Color.Transparent;
            buttonSatisSiparisTeklifTalepEkle.Location = new System.Drawing.Point(1155, 9);
            buttonSatisSiparisTeklifTalepEkle.Name = "buttonSatisSiparisTeklifTalepEkle";
            buttonSatisSiparisTeklifTalepEkle.Size = new System.Drawing.Size(58, 52);
            buttonSatisSiparisTeklifTalepEkle.TabIndex = 11;
            buttonSatisSiparisTeklifTalepEkle.UseVisualStyleBackColor = false;
            buttonSatisSiparisTeklifTalepEkle.Click += buttonSatisSiparisEkle_Click;
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
            // teklifTalepId
            // 
            teklifTalepId.HeaderText = "teklifTalepId";
            teklifTalepId.Name = "teklifTalepId";
            teklifTalepId.ReadOnly = true;
            teklifTalepId.Visible = false;
            // 
            // teklifTalepTarihi
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            teklifTalepTarihi.DefaultCellStyle = dataGridViewCellStyle1;
            teklifTalepTarihi.HeaderText = "Teklif Talep Tarihi";
            teklifTalepTarihi.Name = "teklifTalepTarihi";
            teklifTalepTarihi.ReadOnly = true;
            // 
            // musteri_FirmaId
            // 
            musteri_FirmaId.HeaderText = "firmaId";
            musteri_FirmaId.Name = "musteri_FirmaId";
            musteri_FirmaId.ReadOnly = true;
            musteri_FirmaId.Visible = false;
            // 
            // musteri_Unvan
            // 
            musteri_Unvan.HeaderText = "Müşteri";
            musteri_Unvan.Name = "musteri_Unvan";
            musteri_Unvan.ReadOnly = true;
            // 
            // teklifKonusu
            // 
            teklifKonusu.HeaderText = "Teklif Konusu";
            teklifKonusu.Name = "teklifKonusu";
            teklifKonusu.ReadOnly = true;
            // 
            // marka_MarkaId
            // 
            marka_MarkaId.HeaderText = "MarkaId";
            marka_MarkaId.Name = "marka_MarkaId";
            marka_MarkaId.ReadOnly = true;
            marka_MarkaId.Visible = false;
            // 
            // marka_MarkaAd
            // 
            marka_MarkaAd.HeaderText = "Marka";
            marka_MarkaAd.Name = "marka_MarkaAd";
            marka_MarkaAd.ReadOnly = true;
            // 
            // AltGrup_altGrupId
            // 
            AltGrup_altGrupId.HeaderText = "altGrupId";
            AltGrup_altGrupId.Name = "AltGrup_altGrupId";
            AltGrup_altGrupId.ReadOnly = true;
            AltGrup_altGrupId.Visible = false;
            // 
            // AltGrup_AltGrupAd
            // 
            AltGrup_AltGrupAd.HeaderText = "Alt Grup";
            AltGrup_AltGrupAd.Name = "AltGrup_AltGrupAd";
            AltGrup_AltGrupAd.ReadOnly = true;
            // 
            // referansKaynak_referansKaynakId
            // 
            referansKaynak_referansKaynakId.HeaderText = "referansKaynakId";
            referansKaynak_referansKaynakId.Name = "referansKaynak_referansKaynakId";
            referansKaynak_referansKaynakId.ReadOnly = true;
            referansKaynak_referansKaynakId.Visible = false;
            // 
            // referanskaynak_referansKaynakAdi
            // 
            referanskaynak_referansKaynakAdi.HeaderText = "Referans Kaynağı";
            referanskaynak_referansKaynakAdi.Name = "referanskaynak_referansKaynakAdi";
            referanskaynak_referansKaynakAdi.ReadOnly = true;
            // 
            // satisSorumluId
            // 
            satisSorumluId.HeaderText = "satisSorumluId";
            satisSorumluId.Name = "satisSorumluId";
            satisSorumluId.ReadOnly = true;
            satisSorumluId.Visible = false;
            // 
            // satisSorumlusu_PersonelAd
            // 
            satisSorumlusu_PersonelAd.HeaderText = "Satış Sorumlusu";
            satisSorumlusu_PersonelAd.Name = "satisSorumlusu_PersonelAd";
            satisSorumlusu_PersonelAd.ReadOnly = true;
            // 
            // maliyetSorumlusu_PersonelId
            // 
            maliyetSorumlusu_PersonelId.HeaderText = "maliyetSorumlusu_PersonelId";
            maliyetSorumlusu_PersonelId.Name = "maliyetSorumlusu_PersonelId";
            maliyetSorumlusu_PersonelId.ReadOnly = true;
            maliyetSorumlusu_PersonelId.Visible = false;
            // 
            // maliyetSorumlusu_PersonelAd
            // 
            maliyetSorumlusu_PersonelAd.HeaderText = "Maliyet Sorumlusu";
            maliyetSorumlusu_PersonelAd.Name = "maliyetSorumlusu_PersonelAd";
            maliyetSorumlusu_PersonelAd.ReadOnly = true;
            // 
            // Onay
            // 
            Onay.HeaderText = "Onay";
            Onay.Image = (System.Drawing.Image)resources.GetObject("Onay.Image");
            Onay.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Onay.Name = "Onay";
            Onay.ReadOnly = true;
            Onay.Width = 50;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Guncelle";
            Guncelle.Image = Properties.Resources.update_icon;
            Guncelle.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Guncelle.Name = "Guncelle";
            Guncelle.ReadOnly = true;
            Guncelle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Guncelle.Width = 50;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.Image = Properties.Resources.delete_icon;
            Sil.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
            Sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Sil.Width = 50;
            // 
            // SatisSiparisTeklifTalepGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1239, 755);
            Controls.Add(panelFilter);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatisSiparisTeklifTalepGridForm";
            Text = "PersonelGrid";
            Load += SatisSiparisTeklifTalepGridForm_Load;
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
        private System.Windows.Forms.Button buttonSatisSiparisTeklifTalepEkle;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.DataGridViewTextBoxColumn teklifTalepId;
        private System.Windows.Forms.DataGridViewTextBoxColumn teklifTalepTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn musteri_FirmaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn musteri_Unvan;
        private System.Windows.Forms.DataGridViewTextBoxColumn teklifKonusu;
        private System.Windows.Forms.DataGridViewTextBoxColumn marka_MarkaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn marka_MarkaAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn AltGrup_altGrupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AltGrup_AltGrupAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn referansKaynak_referansKaynakId;
        private System.Windows.Forms.DataGridViewTextBoxColumn referanskaynak_referansKaynakAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisSorumluId;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisSorumlusu_PersonelAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn maliyetSorumlusu_PersonelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn maliyetSorumlusu_PersonelAd;
        private System.Windows.Forms.DataGridViewImageColumn Onay;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}