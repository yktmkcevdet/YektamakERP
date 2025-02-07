namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTalepleri
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
            btnClose = new System.Windows.Forms.Button();
            dataGridView = new System.Windows.Forms.DataGridView();
            sec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKart_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKart_kod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKart_ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satinalmaTalepBaslik_proje_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satinalmaTalepBaslik_proje_kod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKart_parcaGrup_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKart_parcaGrup_ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKart_malzemeGrup_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKart_malzemeGrup_ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            olcuBirim_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            olcuBirim_ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            panelFilter = new System.Windows.Forms.Panel();
            customComboListBoxFirma = new CustomControls.CustomComboListBox();
            roundedIconButton1 = new CustomControls.RoundedIconButton();
            buttonFiltre = new CustomControls.RoundedIconButton();
            panelHeader = new System.Windows.Forms.Panel();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panelFilter.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.Transparent;
            btnClose.BackgroundImage = Properties.Resources.close;
            btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.ForeColor = System.Drawing.Color.Transparent;
            btnClose.Location = new System.Drawing.Point(1177, 9);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(39, 38);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { sec, id, stokKart_id, stokKart_kod, stokKart_ad, satinalmaTalepBaslik_proje_id, satinalmaTalepBaslik_proje_kod, stokKart_parcaGrup_id, stokKart_parcaGrup_ad, stokKart_malzemeGrup_id, stokKart_malzemeGrup_ad, miktar, olcuBirim_id, olcuBirim_ad, aciklama, Guncelle, Sil });
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.Location = new System.Drawing.Point(0, 105);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new System.Drawing.Size(1257, 414);
            dataGridView.TabIndex = 1;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // sec
            // 
            sec.HeaderText = "Seç";
            sec.Name = "sec";
            sec.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            sec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            sec.Width = 40;
            // 
            // id
            // 
            id.HeaderText = "satinalmaTalepDetayId";
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            // 
            // stokKart_id
            // 
            stokKart_id.HeaderText = "Stok Kart ID";
            stokKart_id.Name = "stokKart_id";
            stokKart_id.ReadOnly = true;
            stokKart_id.Visible = false;
            // 
            // stokKart_kod
            // 
            stokKart_kod.DataPropertyName = "filtre";
            stokKart_kod.FillWeight = 250F;
            stokKart_kod.HeaderText = "Stok Kodu";
            stokKart_kod.Name = "stokKart_kod";
            stokKart_kod.ReadOnly = true;
            stokKart_kod.Width = 150;
            // 
            // stokKart_ad
            // 
            stokKart_ad.DataPropertyName = "filtre";
            stokKart_ad.FillWeight = 300F;
            stokKart_ad.HeaderText = "Stok Adı";
            stokKart_ad.Name = "stokKart_ad";
            stokKart_ad.ReadOnly = true;
            stokKart_ad.Width = 200;
            // 
            // satinalmaTalepBaslik_proje_id
            // 
            satinalmaTalepBaslik_proje_id.HeaderText = "satainlmaTalepBaslik_proje_id";
            satinalmaTalepBaslik_proje_id.Name = "satinalmaTalepBaslik_proje_id";
            satinalmaTalepBaslik_proje_id.Visible = false;
            // 
            // satinalmaTalepBaslik_proje_kod
            // 
            satinalmaTalepBaslik_proje_kod.DataPropertyName = "filtre";
            satinalmaTalepBaslik_proje_kod.HeaderText = "Proje Kodu";
            satinalmaTalepBaslik_proje_kod.Name = "satinalmaTalepBaslik_proje_kod";
            // 
            // stokKart_parcaGrup_id
            // 
            stokKart_parcaGrup_id.HeaderText = "parcaGrup_id";
            stokKart_parcaGrup_id.Name = "stokKart_parcaGrup_id";
            stokKart_parcaGrup_id.ReadOnly = true;
            stokKart_parcaGrup_id.Visible = false;
            // 
            // stokKart_parcaGrup_ad
            // 
            stokKart_parcaGrup_ad.DataPropertyName = "filtre";
            stokKart_parcaGrup_ad.FillWeight = 150F;
            stokKart_parcaGrup_ad.HeaderText = "Parça Grubu";
            stokKart_parcaGrup_ad.Name = "stokKart_parcaGrup_ad";
            stokKart_parcaGrup_ad.ReadOnly = true;
            stokKart_parcaGrup_ad.Width = 150;
            // 
            // stokKart_malzemeGrup_id
            // 
            stokKart_malzemeGrup_id.HeaderText = "stokKart_malzemeGrup_id";
            stokKart_malzemeGrup_id.Name = "stokKart_malzemeGrup_id";
            stokKart_malzemeGrup_id.ReadOnly = true;
            stokKart_malzemeGrup_id.Visible = false;
            // 
            // stokKart_malzemeGrup_ad
            // 
            stokKart_malzemeGrup_ad.DataPropertyName = "filtre";
            stokKart_malzemeGrup_ad.HeaderText = "Malzeme Grubu";
            stokKart_malzemeGrup_ad.Name = "stokKart_malzemeGrup_ad";
            stokKart_malzemeGrup_ad.ReadOnly = true;
            // 
            // miktar
            // 
            miktar.HeaderText = "Miktar";
            miktar.Name = "miktar";
            miktar.ReadOnly = true;
            miktar.Width = 75;
            // 
            // olcuBirim_id
            // 
            olcuBirim_id.HeaderText = "olcuBirimId";
            olcuBirim_id.Name = "olcuBirim_id";
            olcuBirim_id.ReadOnly = true;
            olcuBirim_id.Visible = false;
            // 
            // olcuBirim_ad
            // 
            olcuBirim_ad.HeaderText = "Ölçü Birimi";
            olcuBirim_ad.Name = "olcuBirim_ad";
            olcuBirim_ad.ReadOnly = true;
            olcuBirim_ad.Width = 90;
            // 
            // aciklama
            // 
            aciklama.HeaderText = "Açıklama";
            aciklama.Name = "aciklama";
            aciklama.ReadOnly = true;
            aciklama.Width = 400;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Guncelle";
            Guncelle.Image = Properties.Resources.update_icon;
            Guncelle.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Guncelle.Name = "Guncelle";
            Guncelle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Guncelle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            Guncelle.Visible = false;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.Image = Properties.Resources.delete_icon;
            Sil.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Sil.Name = "Sil";
            Sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Sil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            Sil.Visible = false;
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(roundedIconButton1);
            panelFilter.Controls.Add(buttonFiltre);
            panelFilter.Controls.Add(dataGridView);
            panelFilter.Location = new System.Drawing.Point(0, 53);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1257, 522);
            panelFilter.TabIndex = 2;
            // 
            // customComboListBoxFirma
            // 
            customComboListBoxFirma.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxFirma.ListBoxVisualSize = 5;
            customComboListBoxFirma.Location = new System.Drawing.Point(509, 607);
            customComboListBoxFirma.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxFirma.Name = "customComboListBoxFirma";
            customComboListBoxFirma.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxFirma.Size = new System.Drawing.Size(264, 36);
            customComboListBoxFirma.TabIndex = 23;
            // 
            // roundedIconButton1
            // 
            roundedIconButton1.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            roundedIconButton1.CornerRadius = 15;
            roundedIconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedIconButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            roundedIconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            roundedIconButton1.IconChar = FontAwesome.Sharp.IconChar.Filter;
            roundedIconButton1.IconColor = System.Drawing.Color.Gainsboro;
            roundedIconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            roundedIconButton1.IconSize = 25;
            roundedIconButton1.Location = new System.Drawing.Point(757, 7);
            roundedIconButton1.Name = "roundedIconButton1";
            roundedIconButton1.Size = new System.Drawing.Size(82, 46);
            roundedIconButton1.TabIndex = 22;
            roundedIconButton1.Text = "Filtrele";
            roundedIconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            roundedIconButton1.UseVisualStyleBackColor = false;
            roundedIconButton1.Click += roundedIconButton1_Click;
            // 
            // buttonFiltre
            // 
            buttonFiltre.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonFiltre.CornerRadius = 15;
            buttonFiltre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonFiltre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            buttonFiltre.ForeColor = System.Drawing.Color.Gainsboro;
            buttonFiltre.IconChar = FontAwesome.Sharp.IconChar.Filter;
            buttonFiltre.IconColor = System.Drawing.Color.Gainsboro;
            buttonFiltre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonFiltre.IconSize = 25;
            buttonFiltre.Location = new System.Drawing.Point(950, 19);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(82, 46);
            buttonFiltre.TabIndex = 21;
            buttonFiltre.Text = "Filtrele";
            buttonFiltre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonFiltre.UseVisualStyleBackColor = false;
            buttonFiltre.Click += buttonFiltre_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Red;
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1257, 56);
            panelHeader.TabIndex = 3;
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
            buttonHelp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            buttonHelp.ForeColor = System.Drawing.Color.White;
            buttonHelp.Location = new System.Drawing.Point(1088, 9);
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
            buttomMinimize.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            buttomMinimize.ForeColor = System.Drawing.Color.White;
            buttomMinimize.Location = new System.Drawing.Point(1128, 9);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(40, 38);
            buttomMinimize.TabIndex = 104;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = System.Drawing.Color.Red;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(33, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(198, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Satınalma Talepleri";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SatinalmaTalepleri
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1263, 668);
            Controls.Add(customComboListBoxFirma);
            Controls.Add(panelHeader);
            Controls.Add(panelFilter);
            DoubleBuffered = true;
            ForeColor = System.Drawing.Color.Transparent;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepleri";
            Text = "SatinalmaTalepleri";
            Load += form_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panelFilter.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedIconButton buttonFiltre;
        private CustomControls.RoundedIconButton roundedIconButton1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sec;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKart_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKart_kod;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKart_ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn satinalmaTalepBaslik_proje_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn satinalmaTalepBaslik_proje_kod;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKart_parcaGrup_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKart_parcaGrup_ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKart_malzemeGrup_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKart_malzemeGrup_ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn miktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn olcuBirim_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn olcuBirim_ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn aciklama;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
        private CustomControls.CustomComboListBox customComboListBoxFirma;
    }
}