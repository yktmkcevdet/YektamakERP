using YektamakDesktop.Abstracts;
using Models;

namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaSiparisGridForm
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
        public void InitializeComponent()
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
            buttonKayitEkle = new CustomControls.RoundedIconButton();
            buttonTumKayitlariGetir = new CustomControls.RoundedIconButton();
            dataGridView = new System.Windows.Forms.DataGridView();
            buttonFiltre = new CustomControls.RoundedIconButton();
            panelFooter = new System.Windows.Forms.Panel();
            buttonCikis = new CustomControls.RoundedButton();
            satinalmaSiparisId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            projeKod_projeKodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            projeKod_projeKodString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            siparisTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            firma_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            firma_unvan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            siparisAciklamasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_dovizCinsi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_dovizCinsi_sembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            avans_tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            avans_dovizCinsi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            avans_dovizCinsi_sembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            termin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            vade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satinalmaFatura_satinalmaFaturaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satinalmaFatura_faturaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            kdv_kdvId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            talepTip_talepTipId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satinalmaSiparisDetayList = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            panelHeader.Size = new System.Drawing.Size(1152, 56);
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
            buttonClose.Location = new System.Drawing.Point(1104, 8);
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
            buttonHelp.Location = new System.Drawing.Point(1024, 8);
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
            buttomMinimize.Location = new System.Drawing.Point(1064, 8);
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
            labelHeader.Size = new System.Drawing.Size(268, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Satınalma Sipariş Kayıtları";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFilter
            // 
            panelFilter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelFilter.BackColor = System.Drawing.Color.Silver;
            panelFilter.Controls.Add(buttonKayitEkle);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(dataGridView);
            panelFilter.Controls.Add(buttonFiltre);
            panelFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            panelFilter.Location = new System.Drawing.Point(0, 53);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1152, 638);
            panelFilter.TabIndex = 2;
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
            buttonKayitEkle.Location = new System.Drawing.Point(1038, 3);
            buttonKayitEkle.Name = "buttonKayitEkle";
            buttonKayitEkle.Size = new System.Drawing.Size(93, 46);
            buttonKayitEkle.TabIndex = 109;
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
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(934, 3);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(93, 46);
            buttonTumKayitlariGetir.TabIndex = 108;
            buttonTumKayitlariGetir.Text = "Tüm Kayıtlar";
            buttonTumKayitlariGetir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonTumKayitlariGetir.UseVisualStyleBackColor = false;
            buttonTumKayitlariGetir.Click += buttonTumKayitlariGetir_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { satinalmaSiparisId, projeKod_projeKodId, projeKod_projeKodString, siparisTarihi, firma_id, firma_unvan, siparisAciklamasi, tutar_tutar, tutar_dovizCinsi_id, tutar_dovizCinsi_sembol, avans_tutar, avans_dovizCinsi_id, avans_dovizCinsi_sembol, termin, vade, satinalmaFatura_satinalmaFaturaId, satinalmaFatura_faturaNo, kdv_kdvId, talepTip_talepTipId, satinalmaSiparisDetayList, Guncelle, Sil });
            dataGridView.Location = new System.Drawing.Point(3, 92);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new System.Drawing.Size(1146, 546);
            dataGridView.TabIndex = 3;
            dataGridView.CellClick += dataGridView_CellClick;
            dataGridView.ColumnWidthChanged += dataGridView_ColumnWidthChanged;
            dataGridView.Scroll += dataGridView_Scroll;
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
            buttonFiltre.Location = new System.Drawing.Point(846, 3);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(82, 46);
            buttonFiltre.TabIndex = 107;
            buttonFiltre.Text = "Filtrele";
            buttonFiltre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonFiltre.UseVisualStyleBackColor = false;
            buttonFiltre.Click += buttonFiltre_Click;
            // 
            // panelFooter
            // 
            panelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            panelFooter.Controls.Add(buttonCikis);
            panelFooter.Location = new System.Drawing.Point(0, 692);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1152, 65);
            panelFooter.TabIndex = 1;
            // 
            // buttonCikis
            // 
            buttonCikis.BackColor = System.Drawing.Color.Brown;
            buttonCikis.BackgroundColor = System.Drawing.Color.Brown;
            buttonCikis.BorderColor = System.Drawing.Color.Crimson;
            buttonCikis.BorderRadius = 40;
            buttonCikis.BorderSize = 5;
            buttonCikis.FlatAppearance.BorderSize = 0;
            buttonCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCikis.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCikis.ForeColor = System.Drawing.Color.White;
            buttonCikis.Location = new System.Drawing.Point(3, 3);
            buttonCikis.Name = "buttonCikis";
            buttonCikis.Size = new System.Drawing.Size(152, 59);
            buttonCikis.TabIndex = 0;
            buttonCikis.Text = "KAPAT";
            buttonCikis.TextColor = System.Drawing.Color.White;
            buttonCikis.UseVisualStyleBackColor = false;
            buttonCikis.Click += buttonClose_Click;
            // 
            // satinalmaSiparisId
            // 
            satinalmaSiparisId.HeaderText = "SatinalmaSiparisId";
            satinalmaSiparisId.Name = "satinalmaSiparisId";
            satinalmaSiparisId.ReadOnly = true;
            satinalmaSiparisId.Visible = false;
            // 
            // projeKod_projeKodId
            // 
            projeKod_projeKodId.HeaderText = "projeKod_projeKodId";
            projeKod_projeKodId.Name = "projeKod_projeKodId";
            projeKod_projeKodId.ReadOnly = true;
            projeKod_projeKodId.Visible = false;
            // 
            // projeKod_projeKodString
            // 
            projeKod_projeKodString.DataPropertyName = "filtre";
            dataGridViewCellStyle1.NullValue = null;
            projeKod_projeKodString.DefaultCellStyle = dataGridViewCellStyle1;
            projeKod_projeKodString.HeaderText = "Proje Kodu";
            projeKod_projeKodString.Name = "projeKod_projeKodString";
            projeKod_projeKodString.ReadOnly = true;
            projeKod_projeKodString.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            projeKod_projeKodString.Width = 120;
            // 
            // siparisTarihi
            // 
            siparisTarihi.DataPropertyName = "filtre";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            siparisTarihi.DefaultCellStyle = dataGridViewCellStyle2;
            siparisTarihi.HeaderText = "Sipariş Tarihi";
            siparisTarihi.Name = "siparisTarihi";
            siparisTarihi.ReadOnly = true;
            // 
            // firma_id
            // 
            firma_id.HeaderText = "firma_id";
            firma_id.Name = "firma_id";
            firma_id.ReadOnly = true;
            firma_id.Visible = false;
            // 
            // firma_unvan
            // 
            firma_unvan.DataPropertyName = "filtre";
            firma_unvan.HeaderText = "Firma";
            firma_unvan.Name = "firma_unvan";
            firma_unvan.ReadOnly = true;
            firma_unvan.Width = 200;
            // 
            // siparisAciklamasi
            // 
            siparisAciklamasi.DataPropertyName = "filtre";
            siparisAciklamasi.HeaderText = "Sipariş Açıklaması";
            siparisAciklamasi.Name = "siparisAciklamasi";
            siparisAciklamasi.ReadOnly = true;
            // 
            // tutar_tutar
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            tutar_tutar.DefaultCellStyle = dataGridViewCellStyle3;
            tutar_tutar.HeaderText = "Tutar";
            tutar_tutar.Name = "tutar_tutar";
            tutar_tutar.ReadOnly = true;
            tutar_tutar.Width = 80;
            // 
            // tutar_dovizCinsi_id
            // 
            tutar_dovizCinsi_id.HeaderText = "tutar_dovizCinsi_id";
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
            // avans_tutar
            // 
            avans_tutar.HeaderText = "Avans";
            avans_tutar.Name = "avans_tutar";
            avans_tutar.ReadOnly = true;
            avans_tutar.Width = 80;
            // 
            // avans_dovizCinsi_id
            // 
            avans_dovizCinsi_id.HeaderText = "avans_dovizCinsi_id";
            avans_dovizCinsi_id.Name = "avans_dovizCinsi_id";
            avans_dovizCinsi_id.ReadOnly = true;
            avans_dovizCinsi_id.Visible = false;
            // 
            // avans_dovizCinsi_sembol
            // 
            avans_dovizCinsi_sembol.HeaderText = "Döviz Cinsi";
            avans_dovizCinsi_sembol.Name = "avans_dovizCinsi_sembol";
            avans_dovizCinsi_sembol.ReadOnly = true;
            avans_dovizCinsi_sembol.Visible = false;
            // 
            // termin
            // 
            termin.FillWeight = 200F;
            termin.HeaderText = "Termin";
            termin.Name = "termin";
            termin.ReadOnly = true;
            termin.Width = 60;
            // 
            // vade
            // 
            vade.HeaderText = "Vade";
            vade.Name = "vade";
            vade.ReadOnly = true;
            vade.Width = 60;
            // 
            // satinalmaFatura_satinalmaFaturaId
            // 
            satinalmaFatura_satinalmaFaturaId.HeaderText = "satinalmaFatura_satinalmaFaturaId";
            satinalmaFatura_satinalmaFaturaId.Name = "satinalmaFatura_satinalmaFaturaId";
            satinalmaFatura_satinalmaFaturaId.ReadOnly = true;
            satinalmaFatura_satinalmaFaturaId.Visible = false;
            // 
            // satinalmaFatura_faturaNo
            // 
            satinalmaFatura_faturaNo.HeaderText = "Fatura No";
            satinalmaFatura_faturaNo.Name = "satinalmaFatura_faturaNo";
            satinalmaFatura_faturaNo.ReadOnly = true;
            satinalmaFatura_faturaNo.Width = 120;
            // 
            // kdv_kdvId
            // 
            kdv_kdvId.HeaderText = "kdv_kdvId";
            kdv_kdvId.Name = "kdv_kdvId";
            kdv_kdvId.ReadOnly = true;
            kdv_kdvId.Visible = false;
            // 
            // talepTip_talepTipId
            // 
            talepTip_talepTipId.HeaderText = "talepTip_talepTipId";
            talepTip_talepTipId.Name = "talepTip_talepTipId";
            talepTip_talepTipId.ReadOnly = true;
            talepTip_talepTipId.Visible = false;
            // 
            // satinalmaSiparisDetayList
            // 
            satinalmaSiparisDetayList.HeaderText = "satinalmaSiparisDetayList";
            satinalmaSiparisDetayList.Name = "satinalmaSiparisDetayList";
            satinalmaSiparisDetayList.ReadOnly = true;
            satinalmaSiparisDetayList.Visible = false;
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
            // SatinalmaSiparisGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1152, 755);
            Controls.Add(panelFilter);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaSiparisGridForm";
            Text = "PersonelGrid";
            Load += form_Load;
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
        private CustomControls.RoundedButton buttonCikis;
        private System.Windows.Forms.DataGridView dataGridView;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.Panel panelFilter;
        private CustomControls.RoundedIconButton buttonKayitEkle;
        private CustomControls.RoundedIconButton buttonTumKayitlariGetir;
        private CustomControls.RoundedIconButton buttonFiltre;
        private System.Windows.Forms.DataGridViewTextBoxColumn satinalmaSiparisId;
        private System.Windows.Forms.DataGridViewTextBoxColumn projeKod_projeKodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn projeKod_projeKodString;
        private System.Windows.Forms.DataGridViewTextBoxColumn siparisTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn firma_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn firma_unvan;
        private System.Windows.Forms.DataGridViewTextBoxColumn siparisAciklamasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_dovizCinsi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_dovizCinsi_sembol;
        private System.Windows.Forms.DataGridViewTextBoxColumn avans_tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn avans_dovizCinsi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn avans_dovizCinsi_sembol;
        private System.Windows.Forms.DataGridViewTextBoxColumn termin;
        private System.Windows.Forms.DataGridViewTextBoxColumn vade;
        private System.Windows.Forms.DataGridViewTextBoxColumn satinalmaFatura_satinalmaFaturaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn satinalmaFatura_faturaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdv_kdvId;
        private System.Windows.Forms.DataGridViewTextBoxColumn talepTip_talepTipId;
        private System.Windows.Forms.DataGridViewTextBoxColumn satinalmaSiparisDetayList;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}