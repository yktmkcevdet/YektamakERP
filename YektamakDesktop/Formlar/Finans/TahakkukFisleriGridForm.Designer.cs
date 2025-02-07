namespace YektamakDesktop.Formlar.Finans
{
    partial class TahakkukFisleriGridForm
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
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            panelFilter = new System.Windows.Forms.Panel();
            textBoxFiltreKartSahibi = new System.Windows.Forms.TextBox();
            buttonTahakkukFisiEkle = new System.Windows.Forms.Button();
            buttonTumKayitlariGetir = new System.Windows.Forms.Button();
            buttonFiltre = new System.Windows.Forms.Button();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonKapat = new CustomControls.RoundedButton();
            dataGridViewTahakkukFisleri = new System.Windows.Forms.DataGridView();
            TahakkukFisId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CariKartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CariAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DovizId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DovizSembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TahakkukTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            VadeTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Sil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelHeader.SuspendLayout();
            panelFilter.SuspendLayout();
            panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTahakkukFisleri).BeginInit();
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
            panelHeader.Size = new System.Drawing.Size(944, 56);
            panelHeader.TabIndex = 1;
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
            buttonClose.Location = new System.Drawing.Point(897, 9);
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
            buttonHelp.Location = new System.Drawing.Point(817, 9);
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
            buttomMinimize.Location = new System.Drawing.Point(857, 9);
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
            labelHeader.Size = new System.Drawing.Size(170, 30);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Tahakkuk Fişleri";
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(textBoxFiltreKartSahibi);
            panelFilter.Controls.Add(buttonTahakkukFisiEkle);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(buttonFiltre);
            panelFilter.Location = new System.Drawing.Point(0, 56);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(944, 56);
            panelFilter.TabIndex = 2;
            // 
            // textBoxFiltreKartSahibi
            // 
            textBoxFiltreKartSahibi.Location = new System.Drawing.Point(42, 27);
            textBoxFiltreKartSahibi.Name = "textBoxFiltreKartSahibi";
            textBoxFiltreKartSahibi.Size = new System.Drawing.Size(100, 23);
            textBoxFiltreKartSahibi.TabIndex = 3;
            // 
            // buttonTahakkukFisiEkle
            // 
            buttonTahakkukFisiEkle.BackgroundImage = Properties.Resources.Plus_Symbol_PNG_Image_HD;
            buttonTahakkukFisiEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            buttonTahakkukFisiEkle.Location = new System.Drawing.Point(875, 3);
            buttonTahakkukFisiEkle.Name = "buttonTahakkukFisiEkle";
            buttonTahakkukFisiEkle.Size = new System.Drawing.Size(58, 52);
            buttonTahakkukFisiEkle.TabIndex = 2;
            buttonTahakkukFisiEkle.UseVisualStyleBackColor = true;
            buttonTahakkukFisiEkle.Click += buttonTahakkukFisiEkle_Click;
            // 
            // buttonTumKayitlariGetir
            // 
            buttonTumKayitlariGetir.BackColor = System.Drawing.Color.Tomato;
            buttonTumKayitlariGetir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonTumKayitlariGetir.ForeColor = System.Drawing.Color.Transparent;
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(661, 2);
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
            buttonFiltre.Location = new System.Drawing.Point(506, 2);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(107, 52);
            buttonFiltre.TabIndex = 0;
            buttonFiltre.UseVisualStyleBackColor = true;
            buttonFiltre.Click += buttonFiltre_Click;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(rButtonKapat);
            panelFooter.Location = new System.Drawing.Point(0, 571);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(944, 65);
            panelFooter.TabIndex = 3;
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
            rButtonKapat.Location = new System.Drawing.Point(30, 4);
            rButtonKapat.Name = "rButtonKapat";
            rButtonKapat.Size = new System.Drawing.Size(152, 59);
            rButtonKapat.TabIndex = 0;
            rButtonKapat.Text = "KAPAT";
            rButtonKapat.TextColor = System.Drawing.Color.White;
            rButtonKapat.UseVisualStyleBackColor = false;
            rButtonKapat.Click += rButtonKapat_Click;
            // 
            // dataGridViewTahakkukFisleri
            // 
            dataGridViewTahakkukFisleri.AllowUserToAddRows = false;
            dataGridViewTahakkukFisleri.AllowUserToDeleteRows = false;
            dataGridViewTahakkukFisleri.AllowUserToOrderColumns = true;
            dataGridViewTahakkukFisleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTahakkukFisleri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { TahakkukFisId, CariKartId, CariAdi, Tutar, DovizId, DovizSembol, TahakkukTarihi, VadeTarihi, Aciklama, Guncelle, Sil });
            dataGridViewTahakkukFisleri.Location = new System.Drawing.Point(0, 112);
            dataGridViewTahakkukFisleri.Name = "dataGridViewTahakkukFisleri";
            dataGridViewTahakkukFisleri.ReadOnly = true;
            dataGridViewTahakkukFisleri.RowTemplate.Height = 25;
            dataGridViewTahakkukFisleri.Size = new System.Drawing.Size(944, 458);
            dataGridViewTahakkukFisleri.TabIndex = 4;
            dataGridViewTahakkukFisleri.CellClick += dataGridView_CellClick;
            dataGridViewTahakkukFisleri.CellPainting += dataGridView_CellPainting;
            // 
            // TahakkukFisId
            // 
            TahakkukFisId.HeaderText = "TahakkukFisId";
            TahakkukFisId.Name = "TahakkukFisId";
            TahakkukFisId.ReadOnly = true;
            TahakkukFisId.Visible = false;
            // 
            // CariKartId
            // 
            CariKartId.HeaderText = "CariKartId";
            CariKartId.Name = "CariKartId";
            CariKartId.ReadOnly = true;
            CariKartId.Visible = false;
            // 
            // CariAdi
            // 
            CariAdi.HeaderText = "Cari Adı";
            CariAdi.Name = "CariAdi";
            CariAdi.ReadOnly = true;
            CariAdi.Width = 150;
            // 
            // Tutar
            // 
            Tutar.HeaderText = "Tutar";
            Tutar.Name = "Tutar";
            Tutar.ReadOnly = true;
            // 
            // DovizId
            // 
            DovizId.HeaderText = "DovizId";
            DovizId.Name = "DovizId";
            DovizId.ReadOnly = true;
            DovizId.Visible = false;
            // 
            // DovizSembol
            // 
            DovizSembol.HeaderText = "Döviz Cinsi";
            DovizSembol.Name = "DovizSembol";
            DovizSembol.ReadOnly = true;
            // 
            // TahakkukTarihi
            // 
            TahakkukTarihi.HeaderText = "Tahakkuk Tarihi";
            TahakkukTarihi.Name = "TahakkukTarihi";
            TahakkukTarihi.ReadOnly = true;
            // 
            // VadeTarihi
            // 
            VadeTarihi.HeaderText = "OdemeTarihi";
            VadeTarihi.Name = "VadeTarihi";
            VadeTarihi.ReadOnly = true;
            // 
            // Aciklama
            // 
            Aciklama.HeaderText = "Açıklama";
            Aciklama.Name = "Aciklama";
            Aciklama.ReadOnly = true;
            Aciklama.Width = 200;
            // 
            // Guncelle
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            Guncelle.DefaultCellStyle = dataGridViewCellStyle1;
            Guncelle.HeaderText = "Güncelle";
            Guncelle.Name = "Guncelle";
            Guncelle.ReadOnly = true;
            Guncelle.Width = 80;
            // 
            // Sil
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            Sil.DefaultCellStyle = dataGridViewCellStyle2;
            Sil.HeaderText = "Sil";
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
            Sil.Width = 80;
            // 
            // TahakkukFisleriGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(944, 636);
            Controls.Add(dataGridViewTahakkukFisleri);
            Controls.Add(panelFilter);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "TahakkukFisleriGridForm";
            Text = "TahakkukFisleriGridForm";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTahakkukFisleri).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.TextBox textBoxFiltreKartSahibi;
        private System.Windows.Forms.Button buttonTahakkukFisiEkle;
        private System.Windows.Forms.Button buttonTumKayitlariGetir;
        private System.Windows.Forms.Button buttonFiltre;
        private System.Windows.Forms.Panel panelFooter;
        private CustomControls.RoundedButton rButtonKapat;
        private System.Windows.Forms.DataGridView dataGridViewTahakkukFisleri;
        private System.Windows.Forms.DataGridViewTextBoxColumn TahakkukFisId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CariKartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CariAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DovizId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DovizSembol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TahakkukTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn VadeTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aciklama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Guncelle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sil;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
    }
}