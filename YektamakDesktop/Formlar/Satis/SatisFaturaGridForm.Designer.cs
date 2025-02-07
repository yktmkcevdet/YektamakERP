namespace YektamakDesktop.Formlar.Satis
{
    partial class SatisFaturaGridForm
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
            dataGridViewSatisFatura = new System.Windows.Forms.DataGridView();
            buttonSatisSiparisEkle = new System.Windows.Forms.Button();
            buttonTumKayitlariGetir = new System.Windows.Forms.Button();
            buttonFiltre = new System.Windows.Forms.Button();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonCikis = new CustomControls.RoundedButton();
            satisFaturaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisSiparis_siparisId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            faturaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            faturaTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisSiparis_satisProje_projeKod_projekodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisSiparis_satisProje_projeKod_projekodString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cariKart_cariId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cariKart_cariAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            faturalandirilmamisTutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            panelHeader.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatisFatura).BeginInit();
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
            buttonHelp.Location = new System.Drawing.Point(958, 9);
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
            buttomMinimize.Location = new System.Drawing.Point(998, 9);
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
            labelHeader.Size = new System.Drawing.Size(213, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Satış Fatura Kayıtları";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFilter
            // 
            panelFilter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelFilter.BackColor = System.Drawing.Color.Silver;
            panelFilter.Controls.Add(dataGridViewSatisFatura);
            panelFilter.Controls.Add(buttonSatisSiparisEkle);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(buttonFiltre);
            panelFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            panelFilter.Location = new System.Drawing.Point(0, 53);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1085, 644);
            panelFilter.TabIndex = 2;
            // 
            // dataGridViewSatisFatura
            // 
            dataGridViewSatisFatura.AllowUserToAddRows = false;
            dataGridViewSatisFatura.AllowUserToDeleteRows = false;
            dataGridViewSatisFatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSatisFatura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { satisFaturaId, satisSiparis_siparisId, faturaNo, faturaTarihi, satisSiparis_satisProje_projeKod_projekodId, satisSiparis_satisProje_projeKod_projekodString, cariKart_cariId, cariKart_cariAdi, tutar_tutar, faturalandirilmamisTutar, Guncelle, Sil });
            dataGridViewSatisFatura.Location = new System.Drawing.Point(1, 94);
            dataGridViewSatisFatura.Name = "dataGridViewSatisFatura";
            dataGridViewSatisFatura.ReadOnly = true;
            dataGridViewSatisFatura.RowTemplate.Height = 25;
            dataGridViewSatisFatura.Size = new System.Drawing.Size(1082, 550);
            dataGridViewSatisFatura.TabIndex = 12;
            dataGridViewSatisFatura.CellClick += dataGridViewSatisFatura_CellClick;
            dataGridViewSatisFatura.ColumnWidthChanged += dataGridViewSatisFatura_ColumnWidthChanged;
            // 
            // buttonSatisSiparisEkle
            // 
            buttonSatisSiparisEkle.BackColor = System.Drawing.Color.Silver;
            buttonSatisSiparisEkle.BackgroundImage = Properties.Resources.Plus_Symbol_PNG_Image_HD;
            buttonSatisSiparisEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonSatisSiparisEkle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSatisSiparisEkle.ForeColor = System.Drawing.Color.Transparent;
            buttonSatisSiparisEkle.Location = new System.Drawing.Point(1024, 0);
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
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(830, 0);
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
            buttonFiltre.Location = new System.Drawing.Point(717, 0);
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
            panelFooter.Size = new System.Drawing.Size(1085, 65);
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
            // satisFaturaId
            // 
            satisFaturaId.HeaderText = "SatisFaturaId";
            satisFaturaId.Name = "satisFaturaId";
            satisFaturaId.ReadOnly = true;
            satisFaturaId.Visible = false;
            // 
            // satisSiparis_siparisId
            // 
            satisSiparis_siparisId.HeaderText = "satisSiparisId";
            satisSiparis_siparisId.Name = "satisSiparis_siparisId";
            satisSiparis_siparisId.ReadOnly = true;
            satisSiparis_siparisId.Visible = false;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            faturaTarihi.DefaultCellStyle = dataGridViewCellStyle1;
            faturaTarihi.HeaderText = "Fatura Tarihi";
            faturaTarihi.Name = "faturaTarihi";
            faturaTarihi.ReadOnly = true;
            faturaTarihi.Width = 120;
            // 
            // satisSiparis_satisProje_projeKod_projekodId
            // 
            satisSiparis_satisProje_projeKod_projekodId.HeaderText = "ProjeKodId";
            satisSiparis_satisProje_projeKod_projekodId.Name = "satisSiparis_satisProje_projeKod_projekodId";
            satisSiparis_satisProje_projeKod_projekodId.ReadOnly = true;
            satisSiparis_satisProje_projeKod_projekodId.Visible = false;
            // 
            // satisSiparis_satisProje_projeKod_projekodString
            // 
            satisSiparis_satisProje_projeKod_projekodString.DataPropertyName = "filtre";
            dataGridViewCellStyle2.NullValue = null;
            satisSiparis_satisProje_projeKod_projekodString.DefaultCellStyle = dataGridViewCellStyle2;
            satisSiparis_satisProje_projeKod_projekodString.HeaderText = "Proje Kodu";
            satisSiparis_satisProje_projeKod_projekodString.Name = "satisSiparis_satisProje_projeKod_projekodString";
            satisSiparis_satisProje_projeKod_projekodString.ReadOnly = true;
            satisSiparis_satisProje_projeKod_projekodString.Width = 120;
            // 
            // cariKart_cariId
            // 
            cariKart_cariId.HeaderText = "CariKartId";
            cariKart_cariId.Name = "cariKart_cariId";
            cariKart_cariId.ReadOnly = true;
            cariKart_cariId.Visible = false;
            // 
            // cariKart_cariAdi
            // 
            cariKart_cariAdi.DataPropertyName = "filtre";
            cariKart_cariAdi.FillWeight = 200F;
            cariKart_cariAdi.HeaderText = "Müşteri";
            cariKart_cariAdi.Name = "cariKart_cariAdi";
            cariKart_cariAdi.ReadOnly = true;
            cariKart_cariAdi.Width = 200;
            // 
            // tutar_tutar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            tutar_tutar.DefaultCellStyle = dataGridViewCellStyle3;
            tutar_tutar.HeaderText = "Tutar";
            tutar_tutar.Name = "tutar_tutar";
            tutar_tutar.ReadOnly = true;
            tutar_tutar.Width = 150;
            // 
            // faturalandirilmamisTutar
            // 
            faturalandirilmamisTutar.HeaderText = "faturalandirilmamisTutar";
            faturalandirilmamisTutar.Name = "faturalandirilmamisTutar";
            faturalandirilmamisTutar.ReadOnly = true;
            faturalandirilmamisTutar.Visible = false;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Güncelle";
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
            // SatisFaturaGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1085, 755);
            Controls.Add(panelFilter);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatisFaturaGridForm";
            Text = "PersonelGrid";
            Load += SatisFaturaGridForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatisFatura).EndInit();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private CustomControls.RoundedButton rButtonCikis;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button buttonFiltre;
        private System.Windows.Forms.Button buttonTumKayitlariGetir;
        private System.Windows.Forms.Button buttonSatisSiparisEkle;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        public System.Windows.Forms.DataGridView dataGridViewSatisFatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisSiparisId;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisFaturaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisSiparis_siparisId;
        private System.Windows.Forms.DataGridViewTextBoxColumn faturaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn faturaTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisSiparis_satisProje_projeKod_projekodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisSiparis_satisProje_projeKod_projekodString;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariKart_cariId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariKart_cariAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn faturalandirilmamisTutar;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}