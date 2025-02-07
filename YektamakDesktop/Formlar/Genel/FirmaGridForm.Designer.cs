namespace YektamakDesktop.Formlar.Genel
{
    partial class FirmaGridForm
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
            buttonFirmaEkle = new CustomControls.RoundedIconButton();
            buttonTumKayitlariGetir = new CustomControls.RoundedIconButton();
            buttonFiltre = new CustomControls.RoundedIconButton();
            dataGridView = new System.Windows.Forms.DataGridView();
            id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            unvan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            adres_acikAdres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            adres_ulke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            adres_postaKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            vergiDairesi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            vergiNumarasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            faks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            adres_sehir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            sektorIdList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            bankaHesabiList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            yetkiliList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonCikis = new CustomControls.RoundedButton();
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
            panelHeader.Size = new System.Drawing.Size(1216, 56);
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
            buttonClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            buttonClose.ForeColor = System.Drawing.Color.White;
            buttonClose.Location = new System.Drawing.Point(1168, 9);
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
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = System.Drawing.Color.Red;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(37, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(155, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Firma Kayıtları";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFilter
            // 
            panelFilter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelFilter.BackColor = System.Drawing.Color.Silver;
            panelFilter.Controls.Add(buttonFirmaEkle);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(buttonFiltre);
            panelFilter.Controls.Add(dataGridView);
            panelFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            panelFilter.Location = new System.Drawing.Point(0, 53);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1216, 638);
            panelFilter.TabIndex = 2;
            // 
            // buttonFirmaEkle
            // 
            buttonFirmaEkle.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonFirmaEkle.CornerRadius = 15;
            buttonFirmaEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonFirmaEkle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            buttonFirmaEkle.ForeColor = System.Drawing.Color.Gainsboro;
            buttonFirmaEkle.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            buttonFirmaEkle.IconColor = System.Drawing.Color.Gainsboro;
            buttonFirmaEkle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonFirmaEkle.IconSize = 25;
            buttonFirmaEkle.Location = new System.Drawing.Point(1102, 9);
            buttonFirmaEkle.Name = "buttonFirmaEkle";
            buttonFirmaEkle.Size = new System.Drawing.Size(93, 46);
            buttonFirmaEkle.TabIndex = 22;
            buttonFirmaEkle.Text = "Kayıt Ekle";
            buttonFirmaEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonFirmaEkle.UseVisualStyleBackColor = false;
            buttonFirmaEkle.Click += buttonEkle_Click;
            // 
            // buttonTumKayitlariGetir
            // 
            buttonTumKayitlariGetir.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonTumKayitlariGetir.CornerRadius = 15;
            buttonTumKayitlariGetir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonTumKayitlariGetir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            buttonTumKayitlariGetir.ForeColor = System.Drawing.Color.Gainsboro;
            buttonTumKayitlariGetir.IconChar = FontAwesome.Sharp.IconChar.FilterCircleXmark;
            buttonTumKayitlariGetir.IconColor = System.Drawing.Color.Gainsboro;
            buttonTumKayitlariGetir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonTumKayitlariGetir.IconSize = 25;
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(947, 9);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(93, 46);
            buttonTumKayitlariGetir.TabIndex = 21;
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
            buttonFiltre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            buttonFiltre.ForeColor = System.Drawing.Color.Gainsboro;
            buttonFiltre.IconChar = FontAwesome.Sharp.IconChar.Filter;
            buttonFiltre.IconColor = System.Drawing.Color.Gainsboro;
            buttonFiltre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonFiltre.IconSize = 25;
            buttonFiltre.Location = new System.Drawing.Point(859, 9);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(82, 46);
            buttonFiltre.TabIndex = 20;
            buttonFiltre.Text = "Filtrele";
            buttonFiltre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonFiltre.UseVisualStyleBackColor = false;
            buttonFiltre.Click += buttonFiltre_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { id, unvan, adres_acikAdres, adres_ulke, adres_postaKodu, vergiDairesi, vergiNumarasi, telefon, faks, mail, adres_sehir, sektorIdList, bankaHesabiList, yetkiliList, Guncelle, Sil });
            dataGridView.Location = new System.Drawing.Point(0, 105);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new System.Drawing.Size(1216, 533);
            dataGridView.TabIndex = 3;
            dataGridView.CellClick += dataGridView_CellClick;
            dataGridView.ColumnWidthChanged += dataGridView_ColumnWidthChanged;
            dataGridView.Scroll += dataGridView_Scroll;
            // 
            // id
            // 
            id.HeaderText = "firmaId";
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            // 
            // unvan
            // 
            unvan.DataPropertyName = "filtre";
            unvan.HeaderText = "Ünvan";
            unvan.Name = "unvan";
            unvan.ReadOnly = true;
            unvan.Width = 400;
            // 
            // adres_acikAdres
            // 
            adres_acikAdres.HeaderText = "adres";
            adres_acikAdres.Name = "adres_acikAdres";
            adres_acikAdres.Visible = false;
            // 
            // adres_ulke
            // 
            adres_ulke.HeaderText = "adresUlke";
            adres_ulke.Name = "adres_ulke";
            adres_ulke.Visible = false;
            // 
            // adres_postaKodu
            // 
            adres_postaKodu.HeaderText = "adresPostaKodu";
            adres_postaKodu.Name = "adres_postaKodu";
            adres_postaKodu.Visible = false;
            // 
            // vergiDairesi
            // 
            vergiDairesi.DataPropertyName = "filtre";
            vergiDairesi.HeaderText = "Vergi Dairesi";
            vergiDairesi.Name = "vergiDairesi";
            vergiDairesi.ReadOnly = true;
            // 
            // vergiNumarasi
            // 
            vergiNumarasi.HeaderText = "Verginumarasi";
            vergiNumarasi.Name = "vergiNumarasi";
            vergiNumarasi.Visible = false;
            // 
            // telefon
            // 
            telefon.HeaderText = "Telefon";
            telefon.Name = "telefon";
            // 
            // faks
            // 
            faks.HeaderText = "Faks";
            faks.Name = "faks";
            faks.Visible = false;
            // 
            // mail
            // 
            mail.HeaderText = "Mail";
            mail.Name = "mail";
            mail.Visible = false;
            // 
            // adres_sehir
            // 
            adres_sehir.HeaderText = "Şehir";
            adres_sehir.Name = "adres_sehir";
            adres_sehir.ReadOnly = true;
            // 
            // sektorIdList
            // 
            sektorIdList.HeaderText = "Faaliyet Alan(lar)ı";
            sektorIdList.Name = "sektorIdList";
            sektorIdList.ReadOnly = true;
            sektorIdList.Width = 300;
            // 
            // bankaHesabiList
            // 
            bankaHesabiList.HeaderText = "bankaHesabiList";
            bankaHesabiList.Name = "bankaHesabiList";
            bankaHesabiList.Visible = false;
            // 
            // yetkiliList
            // 
            yetkiliList.HeaderText = "yetkiliList";
            yetkiliList.Name = "yetkiliList";
            yetkiliList.Visible = false;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Güncelle";
            Guncelle.Image = Properties.Resources.update_icon;
            Guncelle.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Guncelle.Name = "Guncelle";
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
            Sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Sil.Width = 30;
            // 
            // panelFooter
            // 
            panelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            panelFooter.Controls.Add(rButtonCikis);
            panelFooter.Location = new System.Drawing.Point(0, 692);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1216, 65);
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
            rButtonCikis.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            rButtonCikis.ForeColor = System.Drawing.Color.White;
            rButtonCikis.Location = new System.Drawing.Point(3, 3);
            rButtonCikis.Name = "rButtonCikis";
            rButtonCikis.Size = new System.Drawing.Size(152, 59);
            rButtonCikis.TabIndex = 0;
            rButtonCikis.Text = "KAPAT";
            rButtonCikis.TextColor = System.Drawing.Color.White;
            rButtonCikis.UseVisualStyleBackColor = false;
            rButtonCikis.Click += buttonClose_Click;
            // 
            // FirmaGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1216, 755);
            Controls.Add(panelFilter);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "FirmaGridForm";
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
        private CustomControls.RoundedButton rButtonCikis;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.DataGridView dataGridView;
        private CustomControls.RoundedIconButton buttonTumKayitlariGetir;
        private CustomControls.RoundedIconButton buttonFirmaEkle;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn unvan;
        private System.Windows.Forms.DataGridViewTextBoxColumn adres_acikAdres;
        private System.Windows.Forms.DataGridViewTextBoxColumn adres_ulke;
        private System.Windows.Forms.DataGridViewTextBoxColumn adres_postaKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn vergiDairesi;
        private System.Windows.Forms.DataGridViewTextBoxColumn vergiNumarasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn faks;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn adres_sehir;
        private System.Windows.Forms.DataGridViewTextBoxColumn sektorIdList;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaHesabiList;
        private System.Windows.Forms.DataGridViewTextBoxColumn yetkiliList;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
        private CustomControls.RoundedIconButton buttonFiltre;
    }
}