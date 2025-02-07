namespace YektamakDesktop.Formlar.Genel
{
    partial class BankaHesabiGridFormu
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
            panelFilter = new System.Windows.Forms.Panel();
            buttonBankaHesabiEkle = new CustomControls.RoundedIconButton();
            buttonTumKayitlariGetir = new CustomControls.RoundedIconButton();
            roundedIconButton1 = new CustomControls.RoundedIconButton();
            dataGridViewBankaHesabi = new System.Windows.Forms.DataGridView();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonCikis = new CustomControls.RoundedButton();
            hesapId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            banka_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            banka_unvan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            hesapAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            IBAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dovizCinsi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dovizCinsi_sembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            firma_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            firma_unvan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            panelHeader.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBankaHesabi).BeginInit();
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
            labelHeader.Size = new System.Drawing.Size(170, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Banka Hesapları";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFilter
            // 
            panelFilter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelFilter.BackColor = System.Drawing.Color.Silver;
            panelFilter.Controls.Add(buttonBankaHesabiEkle);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(roundedIconButton1);
            panelFilter.Controls.Add(dataGridViewBankaHesabi);
            panelFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            panelFilter.Location = new System.Drawing.Point(0, 53);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1085, 636);
            panelFilter.TabIndex = 2;
            // 
            // buttonBankaHesabiEkle
            // 
            buttonBankaHesabiEkle.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonBankaHesabiEkle.CornerRadius = 15;
            buttonBankaHesabiEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonBankaHesabiEkle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonBankaHesabiEkle.ForeColor = System.Drawing.Color.Gainsboro;
            buttonBankaHesabiEkle.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            buttonBankaHesabiEkle.IconColor = System.Drawing.Color.Gainsboro;
            buttonBankaHesabiEkle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonBankaHesabiEkle.IconSize = 25;
            buttonBankaHesabiEkle.Location = new System.Drawing.Point(985, 8);
            buttonBankaHesabiEkle.Name = "buttonBankaHesabiEkle";
            buttonBankaHesabiEkle.Size = new System.Drawing.Size(93, 46);
            buttonBankaHesabiEkle.TabIndex = 19;
            buttonBankaHesabiEkle.Text = "Kayıt Ekle";
            buttonBankaHesabiEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonBankaHesabiEkle.UseVisualStyleBackColor = false;
            buttonBankaHesabiEkle.Click += buttonBankaHesabiEkle_Click;
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
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(830, 8);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(93, 46);
            buttonTumKayitlariGetir.TabIndex = 15;
            buttonTumKayitlariGetir.Text = "Tüm Kayıtlar";
            buttonTumKayitlariGetir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonTumKayitlariGetir.UseVisualStyleBackColor = false;
            buttonTumKayitlariGetir.Click += buttonTumKayitlariGetir_Click;
            // 
            // roundedIconButton1
            // 
            roundedIconButton1.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            roundedIconButton1.CornerRadius = 15;
            roundedIconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedIconButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedIconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            roundedIconButton1.IconChar = FontAwesome.Sharp.IconChar.Filter;
            roundedIconButton1.IconColor = System.Drawing.Color.Gainsboro;
            roundedIconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            roundedIconButton1.IconSize = 25;
            roundedIconButton1.Location = new System.Drawing.Point(742, 8);
            roundedIconButton1.Name = "roundedIconButton1";
            roundedIconButton1.Size = new System.Drawing.Size(82, 46);
            roundedIconButton1.TabIndex = 14;
            roundedIconButton1.Text = "Filtrele";
            roundedIconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            roundedIconButton1.UseVisualStyleBackColor = false;
            // 
            // dataGridViewBankaHesabi
            // 
            dataGridViewBankaHesabi.AllowUserToAddRows = false;
            dataGridViewBankaHesabi.AllowUserToDeleteRows = false;
            dataGridViewBankaHesabi.AllowUserToOrderColumns = true;
            dataGridViewBankaHesabi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBankaHesabi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { hesapId, banka_id, banka_unvan, hesapAdi, IBAN, dovizCinsi_id, dovizCinsi_sembol, firma_id, firma_unvan, Guncelle, Sil });
            dataGridViewBankaHesabi.Location = new System.Drawing.Point(2, 105);
            dataGridViewBankaHesabi.Name = "dataGridViewBankaHesabi";
            dataGridViewBankaHesabi.ReadOnly = true;
            dataGridViewBankaHesabi.RowTemplate.Height = 25;
            dataGridViewBankaHesabi.Size = new System.Drawing.Size(1083, 533);
            dataGridViewBankaHesabi.TabIndex = 11;
            dataGridViewBankaHesabi.CellClick += dataGridView_CellClick;
            dataGridViewBankaHesabi.ColumnWidthChanged += dataGridViewBankaHesabi_ColumnWidthChanged;
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
            // hesapId
            // 
            hesapId.HeaderText = "hesapId";
            hesapId.Name = "hesapId";
            hesapId.ReadOnly = true;
            hesapId.Visible = false;
            // 
            // banka_id
            // 
            banka_id.HeaderText = "banka_id";
            banka_id.Name = "banka_id";
            banka_id.ReadOnly = true;
            banka_id.Visible = false;
            // 
            // banka_unvan
            // 
            banka_unvan.DataPropertyName = "filtre";
            banka_unvan.HeaderText = "Banka";
            banka_unvan.Name = "banka_unvan";
            banka_unvan.ReadOnly = true;
            banka_unvan.Width = 150;
            // 
            // hesapAdi
            // 
            hesapAdi.DataPropertyName = "filtre";
            hesapAdi.HeaderText = "Hesap Adı";
            hesapAdi.Name = "hesapAdi";
            hesapAdi.ReadOnly = true;
            hesapAdi.Width = 150;
            // 
            // IBAN
            // 
            IBAN.HeaderText = "IBAN";
            IBAN.Name = "IBAN";
            IBAN.ReadOnly = true;
            IBAN.Width = 250;
            // 
            // dovizCinsi_id
            // 
            dovizCinsi_id.HeaderText = "dovizCinsi_id";
            dovizCinsi_id.Name = "dovizCinsi_id";
            dovizCinsi_id.ReadOnly = true;
            dovizCinsi_id.Visible = false;
            // 
            // dovizCinsi_sembol
            // 
            dovizCinsi_sembol.HeaderText = "Döviz Türü";
            dovizCinsi_sembol.Name = "dovizCinsi_sembol";
            dovizCinsi_sembol.ReadOnly = true;
            dovizCinsi_sembol.Width = 90;
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
            firma_unvan.HeaderText = "Firma";
            firma_unvan.Name = "firma_unvan";
            firma_unvan.ReadOnly = true;
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
            Guncelle.Width = 60;
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
            // BankaHesabiGridFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1085, 755);
            Controls.Add(panelFilter);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "BankaHesabiGridFormu";
            Text = "PersonelGrid";
            Load += BankaHesabiGridFormu_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewBankaHesabi).EndInit();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private CustomControls.RoundedButton rButtonCikis;
        private System.Windows.Forms.Panel panelFilter;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        public System.Windows.Forms.DataGridView dataGridViewBankaHesabi;
        private CustomControls.RoundedIconButton buttonTumKayitlariGetir;
        private CustomControls.RoundedIconButton roundedIconButton1;
        private CustomControls.RoundedIconButton buttonBankaHesabiEkle;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesapId;
        private System.Windows.Forms.DataGridViewTextBoxColumn banka_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn banka_unvan;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesapAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IBAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dovizCinsi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dovizCinsi_sembol;
        private System.Windows.Forms.DataGridViewTextBoxColumn firma_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn firma_unvan;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}