namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTalepGridForm
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
            labelHeader = new System.Windows.Forms.Label();
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonCikis = new CustomControls.RoundedButton();
            panelFilter = new System.Windows.Forms.Panel();
            buttonSatinalmaTalepEkle = new CustomControls.RoundedIconButton();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            buttonTumKayitlariGetir = new CustomControls.RoundedIconButton();
            roundedIconButton1 = new CustomControls.RoundedIconButton();
            SatinalmaTalepBaslikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TalepTipId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ProjeKodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ProjeKod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TalepTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TalepEdenKullaniciId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            KullaniciAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            panelHeader.SuspendLayout();
            panelFooter.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = System.Drawing.Color.Red;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(3, 10);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(198, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Satınalma Talepleri";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            panelHeader.Size = new System.Drawing.Size(1086, 56);
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
            // 
            // panelFooter
            // 
            panelFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            panelFooter.Controls.Add(rButtonCikis);
            panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelFooter.Location = new System.Drawing.Point(0, 640);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1086, 65);
            panelFooter.TabIndex = 2;
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
            // panelFilter
            // 
            panelFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelFilter.BackColor = System.Drawing.Color.Silver;
            panelFilter.Controls.Add(buttonSatinalmaTalepEkle);
            panelFilter.Controls.Add(dataGridView1);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(roundedIconButton1);
            panelFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            panelFilter.Location = new System.Drawing.Point(0, 56);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1086, 581);
            panelFilter.TabIndex = 3;
            // 
            // buttonSatinalmaTalepEkle
            // 
            buttonSatinalmaTalepEkle.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonSatinalmaTalepEkle.CornerRadius = 15;
            buttonSatinalmaTalepEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSatinalmaTalepEkle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSatinalmaTalepEkle.ForeColor = System.Drawing.Color.Gainsboro;
            buttonSatinalmaTalepEkle.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            buttonSatinalmaTalepEkle.IconColor = System.Drawing.Color.Gainsboro;
            buttonSatinalmaTalepEkle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonSatinalmaTalepEkle.IconSize = 25;
            buttonSatinalmaTalepEkle.Location = new System.Drawing.Point(958, 6);
            buttonSatinalmaTalepEkle.Name = "buttonSatinalmaTalepEkle";
            buttonSatinalmaTalepEkle.Size = new System.Drawing.Size(93, 46);
            buttonSatinalmaTalepEkle.TabIndex = 20;
            buttonSatinalmaTalepEkle.Text = "Kayıt Ekle";
            buttonSatinalmaTalepEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonSatinalmaTalepEkle.UseVisualStyleBackColor = false;
            buttonSatinalmaTalepEkle.Click += buttonSatinalmaTalepEkle_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { SatinalmaTalepBaslikId, TalepTipId, ProjeKodId, ProjeKod, TalepTarihi, TalepEdenKullaniciId, KullaniciAdi, Guncelle, Sil });
            dataGridView1.Location = new System.Drawing.Point(3, 96);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(1083, 483);
            dataGridView1.TabIndex = 15;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.ColumnWidthChanged += dataGridView1_ColumnWidthChanged;
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
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(837, 6);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(93, 46);
            buttonTumKayitlariGetir.TabIndex = 13;
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
            roundedIconButton1.Location = new System.Drawing.Point(749, 6);
            roundedIconButton1.Name = "roundedIconButton1";
            roundedIconButton1.Size = new System.Drawing.Size(82, 46);
            roundedIconButton1.TabIndex = 12;
            roundedIconButton1.Text = "Filtrele";
            roundedIconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            roundedIconButton1.UseVisualStyleBackColor = false;
            // 
            // SatinalmaTalepBaslikId
            // 
            SatinalmaTalepBaslikId.HeaderText = "SatinalmaTalepBaslikId";
            SatinalmaTalepBaslikId.Name = "SatinalmaTalepBaslikId";
            SatinalmaTalepBaslikId.ReadOnly = true;
            SatinalmaTalepBaslikId.Visible = false;
            // 
            // TalepTipId
            // 
            TalepTipId.HeaderText = "TalepTipId";
            TalepTipId.Name = "TalepTipId";
            TalepTipId.ReadOnly = true;
            TalepTipId.Visible = false;
            // 
            // ProjeKodId
            // 
            ProjeKodId.HeaderText = "ProjeKodId";
            ProjeKodId.Name = "ProjeKodId";
            ProjeKodId.ReadOnly = true;
            ProjeKodId.Visible = false;
            // 
            // ProjeKod
            // 
            ProjeKod.DataPropertyName = "filtre";
            ProjeKod.HeaderText = "Proje Kodu";
            ProjeKod.Name = "ProjeKod";
            ProjeKod.ReadOnly = true;
            // 
            // TalepTarihi
            // 
            TalepTarihi.DataPropertyName = "filtre";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            TalepTarihi.DefaultCellStyle = dataGridViewCellStyle1;
            TalepTarihi.HeaderText = "Talep Tarihi";
            TalepTarihi.Name = "TalepTarihi";
            TalepTarihi.ReadOnly = true;
            TalepTarihi.Width = 150;
            // 
            // TalepEdenKullaniciId
            // 
            TalepEdenKullaniciId.HeaderText = "TalepEdenKullaniciId";
            TalepEdenKullaniciId.Name = "TalepEdenKullaniciId";
            TalepEdenKullaniciId.ReadOnly = true;
            TalepEdenKullaniciId.Visible = false;
            // 
            // KullaniciAdi
            // 
            KullaniciAdi.DataPropertyName = "filtre";
            KullaniciAdi.HeaderText = "Talep Eden Kullanıcı";
            KullaniciAdi.Name = "KullaniciAdi";
            KullaniciAdi.ReadOnly = true;
            KullaniciAdi.Width = 150;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Güncelle";
            Guncelle.Image = Properties.Resources.update_icon;
            Guncelle.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Guncelle.Name = "Guncelle";
            Guncelle.ReadOnly = true;
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
            Sil.Width = 50;
            // 
            // SatinalmaTalepGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1086, 705);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            Controls.Add(panelFilter);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepGridForm";
            Text = "SatinalmaTalepGridForm";
            Load += SatinalmaTalepGridForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFooter.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.Panel panelFooter;
        private CustomControls.RoundedButton rButtonCikis;
        private System.Windows.Forms.Panel panelFilter;
        private CustomControls.RoundedIconButton roundedIconButton1;
        private CustomControls.RoundedIconButton buttonTumKayitlariGetir;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CustomControls.RoundedIconButton buttonSatinalmaTalepEkle;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatinalmaTalepBaslikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TalepTipId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjeKodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjeKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn TalepTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TalepEdenKullaniciId;
        private System.Windows.Forms.DataGridViewTextBoxColumn KullaniciAdi;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}