namespace YektamakDesktop.Formlar.Finans
{
    partial class KasaTanimlariGridForm
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
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            panelFilter = new System.Windows.Forms.Panel();
            buttonEkle = new CustomControls.RoundedIconButton();
            buttonTumKayitlariGetir = new CustomControls.RoundedIconButton();
            buttonFiltre = new CustomControls.RoundedIconButton();
            dataGridView = new System.Windows.Forms.DataGridView();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonKapat = new CustomControls.RoundedButton();
            KasaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            KasaTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            bankaHesabi_hesapId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            bankaHesabi_hesapAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            KasaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            bakiye_tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            bakiye_dovizCinsi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            bakiye_dovizCinsi_sembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(900, 56);
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
            buttonClose.Location = new System.Drawing.Point(852, 8);
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
            buttonHelp.Location = new System.Drawing.Point(772, 8);
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
            buttomMinimize.Location = new System.Drawing.Point(812, 8);
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
            labelHeader.Size = new System.Drawing.Size(154, 30);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Kasa Tanımları";
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(buttonEkle);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(buttonFiltre);
            panelFilter.Controls.Add(dataGridView);
            panelFilter.Location = new System.Drawing.Point(0, 56);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(900, 634);
            panelFilter.TabIndex = 1;
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
            buttonEkle.Location = new System.Drawing.Point(802, 3);
            buttonEkle.Name = "buttonEkle";
            buttonEkle.Size = new System.Drawing.Size(93, 46);
            buttonEkle.TabIndex = 29;
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
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(646, 3);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(93, 46);
            buttonTumKayitlariGetir.TabIndex = 28;
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
            buttonFiltre.Location = new System.Drawing.Point(555, 3);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(82, 46);
            buttonFiltre.TabIndex = 27;
            buttonFiltre.Text = "Filtrele";
            buttonFiltre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonFiltre.UseVisualStyleBackColor = false;
            buttonFiltre.Click += buttonFiltre_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { KasaId, KasaTuru, bankaHesabi_hesapId, bankaHesabi_hesapAdi, KasaAdi, bakiye_tutar, bakiye_dovizCinsi_id, bakiye_dovizCinsi_sembol, Guncelle, Sil });
            dataGridView.Location = new System.Drawing.Point(0, 111);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new System.Drawing.Size(897, 523);
            dataGridView.TabIndex = 3;
            dataGridView.CellClick += dataGridView_CellClick;
            dataGridView.ColumnWidthChanged += dataGridView_ColumnWidthChanged;
            dataGridView.Scroll += dataGridView_Scroll;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(rButtonKapat);
            panelFooter.Location = new System.Drawing.Point(0, 689);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(685, 65);
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
            rButtonKapat.Click += buttonClose_Click;
            // 
            // KasaId
            // 
            KasaId.HeaderText = "Kasa ID";
            KasaId.Name = "KasaId";
            KasaId.ReadOnly = true;
            KasaId.Visible = false;
            // 
            // KasaTuru
            // 
            KasaTuru.HeaderText = "KasaTuruId";
            KasaTuru.Name = "KasaTuru";
            KasaTuru.ReadOnly = true;
            // 
            // bankaHesabi_hesapId
            // 
            bankaHesabi_hesapId.HeaderText = "BankaHesapId";
            bankaHesabi_hesapId.Name = "bankaHesabi_hesapId";
            bankaHesabi_hesapId.ReadOnly = true;
            bankaHesabi_hesapId.Visible = false;
            // 
            // bankaHesabi_hesapAdi
            // 
            bankaHesabi_hesapAdi.HeaderText = "Banka Hesabı";
            bankaHesabi_hesapAdi.Name = "bankaHesabi_hesapAdi";
            bankaHesabi_hesapAdi.ReadOnly = true;
            // 
            // KasaAdi
            // 
            KasaAdi.HeaderText = "Kasa Adı";
            KasaAdi.Name = "KasaAdi";
            KasaAdi.ReadOnly = true;
            KasaAdi.Width = 250;
            // 
            // bakiye_tutar
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            bakiye_tutar.DefaultCellStyle = dataGridViewCellStyle1;
            bakiye_tutar.HeaderText = "Bakiye";
            bakiye_tutar.Name = "bakiye_tutar";
            bakiye_tutar.ReadOnly = true;
            bakiye_tutar.Width = 150;
            // 
            // bakiye_dovizCinsi_id
            // 
            bakiye_dovizCinsi_id.HeaderText = "DovizId";
            bakiye_dovizCinsi_id.Name = "bakiye_dovizCinsi_id";
            bakiye_dovizCinsi_id.ReadOnly = true;
            bakiye_dovizCinsi_id.Visible = false;
            // 
            // bakiye_dovizCinsi_sembol
            // 
            bakiye_dovizCinsi_sembol.HeaderText = "Döviz Türü";
            bakiye_dovizCinsi_sembol.Name = "bakiye_dovizCinsi_sembol";
            bakiye_dovizCinsi_sembol.ReadOnly = true;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Güncelle";
            Guncelle.Image = Properties.Resources.update_icon;
            Guncelle.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Guncelle.Name = "Guncelle";
            Guncelle.ReadOnly = true;
            Guncelle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Guncelle.Width = 70;
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
            Sil.Width = 70;
            // 
            // KasaTanimlariGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(899, 755);
            Controls.Add(panelFooter);
            Controls.Add(panelFilter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "KasaTanimlariGridForm";
            Text = "GelenOdemeler";
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
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.DataGridView dataGridView;
        private CustomControls.RoundedButton rButtonKapat;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private CustomControls.RoundedIconButton buttonEkle;
        private CustomControls.RoundedIconButton buttonTumKayitlariGetir;
        private CustomControls.RoundedIconButton buttonFiltre;
        private System.Windows.Forms.DataGridViewTextBoxColumn KasaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn KasaTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaHesabi_hesapId;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaHesabi_hesapAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn KasaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn bakiye_tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn bakiye_dovizCinsi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bakiye_dovizCinsi_sembol;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}