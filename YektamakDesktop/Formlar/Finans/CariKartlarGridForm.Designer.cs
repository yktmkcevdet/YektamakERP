namespace YektamakDesktop.Formlar.Finans
{
    partial class CariKartlarGridForm
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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            panelHeader = new System.Windows.Forms.Panel();
            roundedButton3 = new CustomControls.RoundedButton();
            roundedButton2 = new CustomControls.RoundedButton();
            roundedButton1 = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            panelFilter = new System.Windows.Forms.Panel();
            buttonCariKartEkle = new CustomControls.RoundedIconButton();
            dataGridViewCariKartlar = new System.Windows.Forms.DataGridView();
            buttonTumKayitlariGetir = new CustomControls.RoundedIconButton();
            roundedIconButton2 = new CustomControls.RoundedIconButton();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonKapat = new CustomControls.RoundedButton();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            tahakkukFisleri = new System.Windows.Forms.ToolStripMenuItem();
            cariÖdemeler = new System.Windows.Forms.ToolStripMenuItem();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            CariKartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cariAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cari_cariTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cari_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            guncelCari_tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            guncelCari_dovizCinsi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            guncelCari_dovizCinsi_sembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            panelHeader.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCariKartlar).BeginInit();
            panelFooter.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
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
            panelHeader.Size = new System.Drawing.Size(1085, 56);
            panelHeader.TabIndex = 0;
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
            roundedButton3.Location = new System.Drawing.Point(1039, 9);
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
            roundedButton2.Location = new System.Drawing.Point(959, 9);
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
            roundedButton1.Location = new System.Drawing.Point(999, 9);
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
            labelHeader.Size = new System.Drawing.Size(124, 30);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Cari Kartlar";
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(buttonCariKartEkle);
            panelFilter.Controls.Add(dataGridViewCariKartlar);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(roundedIconButton2);
            panelFilter.Location = new System.Drawing.Point(0, 56);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1085, 634);
            panelFilter.TabIndex = 1;
            // 
            // buttonCariKartEkle
            // 
            buttonCariKartEkle.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonCariKartEkle.CornerRadius = 15;
            buttonCariKartEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCariKartEkle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCariKartEkle.ForeColor = System.Drawing.Color.Gainsboro;
            buttonCariKartEkle.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            buttonCariKartEkle.IconColor = System.Drawing.Color.Gainsboro;
            buttonCariKartEkle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonCariKartEkle.IconSize = 25;
            buttonCariKartEkle.Location = new System.Drawing.Point(980, 1);
            buttonCariKartEkle.Name = "buttonCariKartEkle";
            buttonCariKartEkle.Size = new System.Drawing.Size(93, 46);
            buttonCariKartEkle.TabIndex = 23;
            buttonCariKartEkle.Text = "Kayıt Ekle";
            buttonCariKartEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonCariKartEkle.UseVisualStyleBackColor = false;
            buttonCariKartEkle.Click += buttonEkle_Click;
            // 
            // dataGridViewCariKartlar
            // 
            dataGridViewCariKartlar.AllowUserToAddRows = false;
            dataGridViewCariKartlar.AllowUserToDeleteRows = false;
            dataGridViewCariKartlar.AllowUserToOrderColumns = true;
            dataGridViewCariKartlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCariKartlar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { CariKartId, cariAdi, cari_cariTuru, cari_Id, guncelCari_tutar, guncelCari_dovizCinsi_id, guncelCari_dovizCinsi_sembol, Guncelle, Sil });
            dataGridViewCariKartlar.Location = new System.Drawing.Point(0, 113);
            dataGridViewCariKartlar.Name = "dataGridViewCariKartlar";
            dataGridViewCariKartlar.ReadOnly = true;
            dataGridViewCariKartlar.RowTemplate.Height = 25;
            dataGridViewCariKartlar.Size = new System.Drawing.Size(1085, 518);
            dataGridViewCariKartlar.TabIndex = 18;
            dataGridViewCariKartlar.CellClick += dataGridView_CellClick;
            dataGridViewCariKartlar.ColumnWidthChanged += dataGridView_ColumnWidthChanged;
            dataGridViewCariKartlar.Scroll += dataGridView_Scroll;
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
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(824, 1);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(93, 46);
            buttonTumKayitlariGetir.TabIndex = 17;
            buttonTumKayitlariGetir.Text = "Tüm Kayıtlar";
            buttonTumKayitlariGetir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonTumKayitlariGetir.UseVisualStyleBackColor = false;
            buttonTumKayitlariGetir.Click += buttonTumKayitlariGetir_Click;
            // 
            // roundedIconButton2
            // 
            roundedIconButton2.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            roundedIconButton2.CornerRadius = 15;
            roundedIconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedIconButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedIconButton2.ForeColor = System.Drawing.Color.Gainsboro;
            roundedIconButton2.IconChar = FontAwesome.Sharp.IconChar.Filter;
            roundedIconButton2.IconColor = System.Drawing.Color.Gainsboro;
            roundedIconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            roundedIconButton2.IconSize = 25;
            roundedIconButton2.Location = new System.Drawing.Point(733, 1);
            roundedIconButton2.Name = "roundedIconButton2";
            roundedIconButton2.Size = new System.Drawing.Size(82, 46);
            roundedIconButton2.TabIndex = 16;
            roundedIconButton2.Text = "Filtrele";
            roundedIconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            roundedIconButton2.UseVisualStyleBackColor = false;
            roundedIconButton2.Click += buttonFiltre_Click;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(rButtonKapat);
            panelFooter.Location = new System.Drawing.Point(0, 689);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1085, 65);
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tahakkukFisleri, cariÖdemeler });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(157, 48);
            // 
            // tahakkukFisleri
            // 
            tahakkukFisleri.Image = Properties.Resources.DataReviewWithMagnifier;
            tahakkukFisleri.Name = "tahakkukFisleri";
            tahakkukFisleri.Size = new System.Drawing.Size(156, 22);
            tahakkukFisleri.Text = "Tahakkuk Fişleri";
            // 
            // cariÖdemeler
            // 
            cariÖdemeler.Image = Properties.Resources.DataReviewWithMagnifier7_1;
            cariÖdemeler.Name = "cariÖdemeler";
            cariÖdemeler.Size = new System.Drawing.Size(156, 22);
            cariÖdemeler.Text = "Cari Ödemeler";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // CariKartId
            // 
            CariKartId.HeaderText = "CariKartId";
            CariKartId.Name = "CariKartId";
            CariKartId.ReadOnly = true;
            CariKartId.Visible = false;
            // 
            // cariAdi
            // 
            cariAdi.DataPropertyName = "filtre";
            cariAdi.HeaderText = "Cari Adı";
            cariAdi.Name = "cariAdi";
            cariAdi.ReadOnly = true;
            cariAdi.Width = 400;
            // 
            // cari_cariTuru
            // 
            cari_cariTuru.HeaderText = "Cari Türü";
            cari_cariTuru.Name = "cari_cariTuru";
            cari_cariTuru.ReadOnly = true;
            // 
            // cari_Id
            // 
            cari_Id.HeaderText = "CariId";
            cari_Id.Name = "cari_Id";
            cari_Id.ReadOnly = true;
            cari_Id.Visible = false;
            // 
            // guncelCari_tutar
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            guncelCari_tutar.DefaultCellStyle = dataGridViewCellStyle1;
            guncelCari_tutar.HeaderText = "Güncel Bakiye";
            guncelCari_tutar.Name = "guncelCari_tutar";
            guncelCari_tutar.ReadOnly = true;
            guncelCari_tutar.Width = 110;
            // 
            // guncelCari_dovizCinsi_id
            // 
            guncelCari_dovizCinsi_id.HeaderText = "DovizId";
            guncelCari_dovizCinsi_id.Name = "guncelCari_dovizCinsi_id";
            guncelCari_dovizCinsi_id.ReadOnly = true;
            guncelCari_dovizCinsi_id.Visible = false;
            // 
            // guncelCari_dovizCinsi_sembol
            // 
            guncelCari_dovizCinsi_sembol.HeaderText = "Döviz Türü";
            guncelCari_dovizCinsi_sembol.Name = "guncelCari_dovizCinsi_sembol";
            guncelCari_dovizCinsi_sembol.ReadOnly = true;
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
            Guncelle.Width = 80;
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
            Sil.Width = 80;
            // 
            // CariKartlarGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1085, 755);
            Controls.Add(panelFooter);
            Controls.Add(panelFilter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "CariKartlarGridForm";
            Text = "GelenOdemeler";
            Load += form_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCariKartlar).EndInit();
            panelFooter.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Panel panelFooter;
        private CustomControls.RoundedButton rButtonKapat;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tahakkukFisleri;
        private System.Windows.Forms.ToolStripMenuItem cariÖdemeler;
        private CustomControls.RoundedButton roundedButton3;
        private CustomControls.RoundedButton roundedButton2;
        private CustomControls.RoundedButton roundedButton1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridViewCariKartlar;
        private CustomControls.RoundedIconButton buttonTumKayitlariGetir;
        private CustomControls.RoundedIconButton roundedIconButton2;
        private CustomControls.RoundedIconButton buttonCariKartEkle;
        private System.Windows.Forms.DataGridViewTextBoxColumn CariKartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cari_cariTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn cari_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn guncelCari_tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn guncelCari_dovizCinsi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn guncelCari_dovizCinsi_sembol;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}