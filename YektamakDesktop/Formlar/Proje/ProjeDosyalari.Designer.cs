namespace YektamakDesktop.Formlar.Proje
{
    partial class ProjeDosyalari
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
            dataGridViewStokKart = new System.Windows.Forms.DataGridView();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            sec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            proje_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            proje_kod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            kod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            parcaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            boyut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            uzunluk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            malzeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            agirlik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            isPdf = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            isDxf = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            isStep = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            parcaAltGrup_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            parcaAltGrup_ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            parcaGrup_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            olcuBirimId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            boy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            en = new System.Windows.Forms.DataGridViewTextBoxColumn();
            yukseklik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            etKalinligi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokTipId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            logoKod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            malzemeStandartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            profilTipId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            parcaGrup_ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            isSatinalma = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            Pdf = new System.Windows.Forms.DataGridViewImageColumn();
            Dxf = new System.Windows.Forms.DataGridViewImageColumn();
            Step = new System.Windows.Forms.DataGridViewImageColumn();
            guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            panelFilter = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            projeKod = new CustomControls.CustomComboListBox();
            panelHeader = new System.Windows.Forms.Panel();
            roundedButton3 = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            roundedButton1 = new CustomControls.RoundedButton();
            roundedButton2 = new CustomControls.RoundedButton();
            panelFooter = new System.Windows.Forms.Panel();
            roundedButton4 = new CustomControls.RoundedButton();
            label1 = new System.Windows.Forms.Label();
            parcaGrubu = new CustomControls.CustomComboListBox();
            parcaAltGrubu = new CustomControls.CustomComboListBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            textBoxParcaAdi = new CustomControls.CustomTextBox();
            chkSatinalma = new System.Windows.Forms.CheckBox();
            chkPdf = new System.Windows.Forms.CheckBox();
            chkDxf = new System.Windows.Forms.CheckBox();
            chkStep = new System.Windows.Forms.CheckBox();
            chkSec = new System.Windows.Forms.CheckBox();
            selectAll = new System.Windows.Forms.CheckBox();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            seçiliKalemlerİçinSaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            stokKartınıGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            lblToplamKayitSayisi = new System.Windows.Forms.Label();
            lblSecilmisKayitSayisi = new System.Windows.Forms.Label();
            lblKayitSayisi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStokKart).BeginInit();
            panelFilter.SuspendLayout();
            panelHeader.SuspendLayout();
            panelFooter.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewStokKart
            // 
            dataGridViewStokKart.AllowUserToAddRows = false;
            dataGridViewStokKart.AllowUserToDeleteRows = false;
            dataGridViewStokKart.AllowUserToOrderColumns = true;
            dataGridViewStokKart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStokKart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, sec, proje_Id, proje_kod, kod, ad, parcaAdi, boyut, uzunluk, malzeme, aciklama, agirlik, miktar, isPdf, isDxf, isStep, parcaAltGrup_Id, parcaAltGrup_ad, parcaGrup_Id, olcuBirimId, boy, en, yukseklik, cap, etKalinligi, stokTipId, logoKod, malzemeStandartId, profilTipId, parcaGrup_ad, isSatinalma, Pdf, Dxf, Step, guncelle, Sil });
            dataGridViewStokKart.Location = new System.Drawing.Point(3, 20);
            dataGridViewStokKart.Name = "dataGridViewStokKart";
            dataGridViewStokKart.RowTemplate.Height = 25;
            dataGridViewStokKart.ShowCellToolTips = false;
            dataGridViewStokKart.Size = new System.Drawing.Size(1279, 524);
            dataGridViewStokKart.TabIndex = 5;
            dataGridViewStokKart.CellClick += dataGridView_CellClick;
            dataGridViewStokKart.CellFormatting += dataGridViewStokKart_CellFormatting;
            dataGridViewStokKart.CellMouseMove += dataGridViewStokKart_CellMouseMove;
            dataGridViewStokKart.CellPainting += dataGridViewStokKart_CellPainting;
            dataGridViewStokKart.CurrentCellDirtyStateChanged += dataGridViewStokKart_CurrentCellDirtyStateChanged;
            dataGridViewStokKart.MouseDown += dataGridViewStokKart_MouseDown;
            // 
            // Id
            // 
            Id.HeaderText = "stokKartId";
            Id.Name = "Id";
            Id.Visible = false;
            // 
            // sec
            // 
            sec.DataPropertyName = "filtre";
            sec.HeaderText = "";
            sec.Name = "sec";
            sec.Width = 20;
            // 
            // proje_Id
            // 
            proje_Id.DataPropertyName = "filtre";
            proje_Id.HeaderText = "Proje Id";
            proje_Id.Name = "proje_Id";
            proje_Id.Visible = false;
            // 
            // proje_kod
            // 
            proje_kod.HeaderText = "Proje Kodu";
            proje_kod.Name = "proje_kod";
            proje_kod.ReadOnly = true;
            // 
            // kod
            // 
            kod.DataPropertyName = "filtre";
            kod.HeaderText = "Stok Kodu";
            kod.Name = "kod";
            kod.ReadOnly = true;
            // 
            // ad
            // 
            ad.DataPropertyName = "filtre";
            ad.HeaderText = "Stok Adı";
            ad.Name = "ad";
            ad.ReadOnly = true;
            // 
            // parcaAdi
            // 
            parcaAdi.HeaderText = "parcaAdi";
            parcaAdi.Name = "parcaAdi";
            parcaAdi.Visible = false;
            // 
            // boyut
            // 
            boyut.HeaderText = "Boyut";
            boyut.Name = "boyut";
            boyut.ReadOnly = true;
            // 
            // uzunluk
            // 
            uzunluk.HeaderText = "Uzunluk";
            uzunluk.Name = "uzunluk";
            uzunluk.ReadOnly = true;
            // 
            // malzeme
            // 
            malzeme.HeaderText = "Malzeme";
            malzeme.Name = "malzeme";
            malzeme.ReadOnly = true;
            // 
            // aciklama
            // 
            aciklama.HeaderText = "Açıklama";
            aciklama.Name = "aciklama";
            aciklama.ReadOnly = true;
            // 
            // agirlik
            // 
            agirlik.HeaderText = "Ağırlık";
            agirlik.Name = "agirlik";
            agirlik.ReadOnly = true;
            // 
            // miktar
            // 
            miktar.HeaderText = "Miktar";
            miktar.Name = "miktar";
            miktar.ReadOnly = true;
            // 
            // isPdf
            // 
            isPdf.DataPropertyName = "filtre";
            isPdf.HeaderText = "Pdf?";
            isPdf.Name = "isPdf";
            isPdf.ReadOnly = true;
            isPdf.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            isPdf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            isPdf.Visible = false;
            // 
            // isDxf
            // 
            isDxf.DataPropertyName = "filtre";
            isDxf.HeaderText = "Dxf?";
            isDxf.Name = "isDxf";
            isDxf.ReadOnly = true;
            isDxf.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            isDxf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            isDxf.Visible = false;
            // 
            // isStep
            // 
            isStep.DataPropertyName = "filtre";
            isStep.HeaderText = "Step?";
            isStep.Name = "isStep";
            isStep.ReadOnly = true;
            isStep.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            isStep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            isStep.Visible = false;
            // 
            // parcaAltGrup_Id
            // 
            parcaAltGrup_Id.DataPropertyName = "filtre";
            parcaAltGrup_Id.HeaderText = "parcaAltGrup_Id";
            parcaAltGrup_Id.Name = "parcaAltGrup_Id";
            parcaAltGrup_Id.ReadOnly = true;
            parcaAltGrup_Id.Visible = false;
            // 
            // parcaAltGrup_ad
            // 
            parcaAltGrup_ad.HeaderText = "Parça Alt Grup";
            parcaAltGrup_ad.Name = "parcaAltGrup_ad";
            parcaAltGrup_ad.ReadOnly = true;
            // 
            // parcaGrup_Id
            // 
            parcaGrup_Id.DataPropertyName = "filtre";
            parcaGrup_Id.HeaderText = "parcaGrup_Id";
            parcaGrup_Id.Name = "parcaGrup_Id";
            parcaGrup_Id.ReadOnly = true;
            parcaGrup_Id.Visible = false;
            // 
            // olcuBirimId
            // 
            olcuBirimId.HeaderText = "olcuBirimId";
            olcuBirimId.Name = "olcuBirimId";
            olcuBirimId.Visible = false;
            // 
            // boy
            // 
            boy.HeaderText = "boy";
            boy.Name = "boy";
            boy.Visible = false;
            // 
            // en
            // 
            en.HeaderText = "en";
            en.Name = "en";
            en.Visible = false;
            // 
            // yukseklik
            // 
            yukseklik.HeaderText = "yukseklik";
            yukseklik.Name = "yukseklik";
            yukseklik.Visible = false;
            // 
            // cap
            // 
            cap.HeaderText = "cap";
            cap.Name = "cap";
            cap.Visible = false;
            // 
            // etKalinligi
            // 
            etKalinligi.HeaderText = "etKalinligi";
            etKalinligi.Name = "etKalinligi";
            etKalinligi.Visible = false;
            // 
            // stokTipId
            // 
            stokTipId.HeaderText = "stokTipId";
            stokTipId.Name = "stokTipId";
            stokTipId.Visible = false;
            // 
            // logoKod
            // 
            logoKod.HeaderText = "logoKod";
            logoKod.Name = "logoKod";
            logoKod.Visible = false;
            // 
            // malzemeStandartId
            // 
            malzemeStandartId.HeaderText = "malzemeStandartId";
            malzemeStandartId.Name = "malzemeStandartId";
            malzemeStandartId.Visible = false;
            // 
            // profilTipId
            // 
            profilTipId.HeaderText = "profilTipId";
            profilTipId.Name = "profilTipId";
            profilTipId.Visible = false;
            // 
            // parcaGrup_ad
            // 
            parcaGrup_ad.HeaderText = "Parça Grubu";
            parcaGrup_ad.Name = "parcaGrup_ad";
            parcaGrup_ad.ReadOnly = true;
            // 
            // isSatinalma
            // 
            isSatinalma.DataPropertyName = "filtre";
            isSatinalma.HeaderText = "SatınalmaTalepAçıldı?";
            isSatinalma.Name = "isSatinalma";
            isSatinalma.ReadOnly = true;
            isSatinalma.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            isSatinalma.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            isSatinalma.Visible = false;
            // 
            // Pdf
            // 
            Pdf.HeaderText = "Pdf";
            Pdf.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Pdf.Name = "Pdf";
            Pdf.Width = 50;
            // 
            // Dxf
            // 
            Dxf.HeaderText = "Dxf";
            Dxf.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Dxf.Name = "Dxf";
            Dxf.Width = 50;
            // 
            // Step
            // 
            Step.HeaderText = "Step";
            Step.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Step.Name = "Step";
            Step.Width = 50;
            // 
            // guncelle
            // 
            guncelle.HeaderText = "Güncelle";
            guncelle.Name = "guncelle";
            guncelle.Visible = false;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.Name = "Sil";
            Sil.Visible = false;
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(dataGridViewStokKart);
            panelFilter.Location = new System.Drawing.Point(0, 191);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1284, 547);
            panelFilter.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 54);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 26;
            label2.Text = "Proje Kodu";
            // 
            // projeKod
            // 
            projeKod.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            projeKod.ListBoxVisualSize = 5;
            projeKod.Location = new System.Drawing.Point(103, 45);
            projeKod.Margin = new System.Windows.Forms.Padding(1);
            projeKod.Name = "projeKod";
            projeKod.Padding = new System.Windows.Forms.Padding(1);
            projeKod.Size = new System.Drawing.Size(251, 36);
            projeKod.TabIndex = 24;
            projeKod.SelectedIndexChanged += projeKod_SelectedIndexChanged;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Firebrick;
            panelHeader.Controls.Add(roundedButton3);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Controls.Add(roundedButton1);
            panelHeader.Controls.Add(roundedButton2);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1287, 32);
            panelHeader.TabIndex = 7;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // roundedButton3
            // 
            roundedButton3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton3.BackColor = System.Drawing.Color.Firebrick;
            roundedButton3.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton3.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton3.BorderRadius = 10;
            roundedButton3.BorderSize = 2;
            roundedButton3.FlatAppearance.BorderSize = 0;
            roundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton3.ForeColor = System.Drawing.Color.White;
            roundedButton3.Location = new System.Drawing.Point(1249, 1);
            roundedButton3.Margin = new System.Windows.Forms.Padding(0);
            roundedButton3.Name = "roundedButton3";
            roundedButton3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton3.Size = new System.Drawing.Size(29, 27);
            roundedButton3.TabIndex = 100;
            roundedButton3.Text = "X";
            roundedButton3.TextColor = System.Drawing.Color.White;
            roundedButton3.UseVisualStyleBackColor = false;
            roundedButton3.Click += buttonClose_Click;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(12, 6);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(102, 17);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Proje Dosyaları";
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton1.BackColor = System.Drawing.Color.Firebrick;
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderRadius = 10;
            roundedButton1.BorderSize = 2;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.Location = new System.Drawing.Point(1209, 1);
            roundedButton1.Margin = new System.Windows.Forms.Padding(0);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton1.Size = new System.Drawing.Size(29, 27);
            roundedButton1.TabIndex = 98;
            roundedButton1.Text = "-";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // roundedButton2
            // 
            roundedButton2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton2.BackColor = System.Drawing.Color.Firebrick;
            roundedButton2.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton2.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton2.BorderRadius = 10;
            roundedButton2.BorderSize = 2;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton2.ForeColor = System.Drawing.Color.White;
            roundedButton2.Location = new System.Drawing.Point(1170, 2);
            roundedButton2.Margin = new System.Windows.Forms.Padding(0);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton2.Size = new System.Drawing.Size(29, 27);
            roundedButton2.TabIndex = 99;
            roundedButton2.Text = "?";
            roundedButton2.TextColor = System.Drawing.Color.White;
            roundedButton2.UseVisualStyleBackColor = false;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(roundedButton4);
            panelFooter.Location = new System.Drawing.Point(0, 741);
            panelFooter.Margin = new System.Windows.Forms.Padding(0);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1284, 65);
            panelFooter.TabIndex = 101;
            // 
            // roundedButton4
            // 
            roundedButton4.BackColor = System.Drawing.Color.OliveDrab;
            roundedButton4.BackgroundColor = System.Drawing.Color.OliveDrab;
            roundedButton4.BorderColor = System.Drawing.Color.MediumSeaGreen;
            roundedButton4.BorderRadius = 40;
            roundedButton4.BorderSize = 2;
            roundedButton4.FlatAppearance.BorderSize = 0;
            roundedButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton4.ForeColor = System.Drawing.Color.White;
            roundedButton4.Location = new System.Drawing.Point(1026, 3);
            roundedButton4.Name = "roundedButton4";
            roundedButton4.Size = new System.Drawing.Size(152, 59);
            roundedButton4.TabIndex = 2;
            roundedButton4.Text = "Satınalma Talebi Oluştur =>";
            roundedButton4.TextColor = System.Drawing.Color.White;
            roundedButton4.UseVisualStyleBackColor = false;
            roundedButton4.Click += roundedButton4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 84);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(72, 15);
            label1.TabIndex = 103;
            label1.Text = "Parça Grubu";
            // 
            // parcaGrubu
            // 
            parcaGrubu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            parcaGrubu.ListBoxVisualSize = 5;
            parcaGrubu.Location = new System.Drawing.Point(103, 75);
            parcaGrubu.Margin = new System.Windows.Forms.Padding(1);
            parcaGrubu.Name = "parcaGrubu";
            parcaGrubu.Padding = new System.Windows.Forms.Padding(1);
            parcaGrubu.Size = new System.Drawing.Size(251, 36);
            parcaGrubu.TabIndex = 102;
            parcaGrubu.SelectedIndexChanged += parcaGrubu_SelectedIndexChanged;
            // 
            // parcaAltGrubu
            // 
            parcaAltGrubu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            parcaAltGrubu.ListBoxVisualSize = 5;
            parcaAltGrubu.Location = new System.Drawing.Point(103, 107);
            parcaAltGrubu.Margin = new System.Windows.Forms.Padding(1);
            parcaAltGrubu.Name = "parcaAltGrubu";
            parcaAltGrubu.Padding = new System.Windows.Forms.Padding(1);
            parcaAltGrubu.Size = new System.Drawing.Size(251, 36);
            parcaAltGrubu.TabIndex = 104;
            parcaAltGrubu.SelectedIndexChanged += parcaAltGrubu_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(9, 116);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(90, 15);
            label3.TabIndex = 105;
            label3.Text = "Parça Alt Grubu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(9, 148);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 15);
            label4.TabIndex = 107;
            label4.Text = "Parça Adı";
            // 
            // textBoxParcaAdi
            // 
            textBoxParcaAdi.BackColor = System.Drawing.Color.White;
            textBoxParcaAdi.BorderColor = System.Drawing.Color.Silver;
            textBoxParcaAdi.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxParcaAdi.BorderRadius = 5;
            textBoxParcaAdi.BorderSize = 1;
            textBoxParcaAdi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxParcaAdi.ForeColor = System.Drawing.Color.Black;
            textBoxParcaAdi.isPlaceHolder = false;
            textBoxParcaAdi.Location = new System.Drawing.Point(103, 142);
            textBoxParcaAdi.Multiline = false;
            textBoxParcaAdi.Name = "textBoxParcaAdi";
            textBoxParcaAdi.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            textBoxParcaAdi.PasswordChar = false;
            textBoxParcaAdi.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxParcaAdi.PlaceholderText = "";
            textBoxParcaAdi.ReadOnly = false;
            textBoxParcaAdi.SelectionStart = 0;
            textBoxParcaAdi.Size = new System.Drawing.Size(250, 28);
            textBoxParcaAdi.TabIndex = 108;
            textBoxParcaAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxParcaAdi.TextCustom = "";
            textBoxParcaAdi.UnderlinedStyle = false;
            textBoxParcaAdi.KeyDown += parcaAdi_KeyDown;
            // 
            // chkSatinalma
            // 
            chkSatinalma.AutoSize = true;
            chkSatinalma.Location = new System.Drawing.Point(542, 52);
            chkSatinalma.Name = "chkSatinalma";
            chkSatinalma.Size = new System.Drawing.Size(219, 19);
            chkSatinalma.TabIndex = 109;
            chkSatinalma.Text = "Satınalma siparişi verilmemiş kayıtlar";
            chkSatinalma.UseVisualStyleBackColor = true;
            chkSatinalma.CheckedChanged += chkSatinalma_CheckedChanged;
            // 
            // chkPdf
            // 
            chkPdf.AutoSize = true;
            chkPdf.Location = new System.Drawing.Point(542, 80);
            chkPdf.Name = "chkPdf";
            chkPdf.Size = new System.Drawing.Size(137, 19);
            chkPdf.TabIndex = 110;
            chkPdf.Text = "PDF olmayan kayıtlar";
            chkPdf.UseVisualStyleBackColor = true;
            chkPdf.CheckedChanged += chkPdf_CheckedChanged;
            // 
            // chkDxf
            // 
            chkDxf.AutoSize = true;
            chkDxf.Location = new System.Drawing.Point(542, 105);
            chkDxf.Name = "chkDxf";
            chkDxf.Size = new System.Drawing.Size(137, 19);
            chkDxf.TabIndex = 111;
            chkDxf.Text = "DXF olmayan kayıtlar";
            chkDxf.UseVisualStyleBackColor = true;
            chkDxf.CheckedChanged += chkDxf_CheckedChanged;
            // 
            // chkStep
            // 
            chkStep.AutoSize = true;
            chkStep.Location = new System.Drawing.Point(542, 126);
            chkStep.Name = "chkStep";
            chkStep.Size = new System.Drawing.Size(141, 19);
            chkStep.TabIndex = 112;
            chkStep.Text = "STEP olmayan kayıtlar";
            chkStep.UseVisualStyleBackColor = true;
            chkStep.CheckedChanged += chkStep_CheckedChanged;
            // 
            // chkSec
            // 
            chkSec.AutoSize = true;
            chkSec.Location = new System.Drawing.Point(542, 151);
            chkSec.Name = "chkSec";
            chkSec.Size = new System.Drawing.Size(189, 19);
            chkSec.TabIndex = 113;
            chkSec.Text = "Seçilmiş ve Seçilmemiş Kayıtlar";
            chkSec.ThreeState = true;
            chkSec.UseVisualStyleBackColor = true;
            chkSec.CheckStateChanged += chkSec_CheckStateChanged;
            // 
            // selectAll
            // 
            selectAll.AutoSize = true;
            selectAll.Location = new System.Drawing.Point(46, 176);
            selectAll.Name = "selectAll";
            selectAll.Size = new System.Drawing.Size(92, 19);
            selectAll.TabIndex = 114;
            selectAll.Text = "Tümünü Seç";
            selectAll.UseVisualStyleBackColor = true;
            selectAll.CheckStateChanged += selectAll_CheckStateChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { seçiliKalemlerİçinSaToolStripMenuItem, stokKartınıGörüntüleToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(303, 48);
            // 
            // seçiliKalemlerİçinSaToolStripMenuItem
            // 
            seçiliKalemlerİçinSaToolStripMenuItem.Name = "seçiliKalemlerİçinSaToolStripMenuItem";
            seçiliKalemlerİçinSaToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            seçiliKalemlerİçinSaToolStripMenuItem.Text = "Seçili Kalemler İçin Satınalma Talebi Oluştur";
            seçiliKalemlerİçinSaToolStripMenuItem.Click += SatinalmaTalebiOlustur;
            // 
            // stokKartınıGörüntüleToolStripMenuItem
            // 
            stokKartınıGörüntüleToolStripMenuItem.Name = "stokKartınıGörüntüleToolStripMenuItem";
            stokKartınıGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            stokKartınıGörüntüleToolStripMenuItem.Text = "Stok Kartını Görüntüle";
            stokKartınıGörüntüleToolStripMenuItem.Click += stokKartınıGörüntüleToolStripMenuItem_Click;
            // 
            // lblToplamKayitSayisi
            // 
            lblToplamKayitSayisi.AutoSize = true;
            lblToplamKayitSayisi.Location = new System.Drawing.Point(1065, 45);
            lblToplamKayitSayisi.Name = "lblToplamKayitSayisi";
            lblToplamKayitSayisi.Size = new System.Drawing.Size(13, 15);
            lblToplamKayitSayisi.TabIndex = 117;
            lblToplamKayitSayisi.Text = "0";
            // 
            // lblSecilmisKayitSayisi
            // 
            lblSecilmisKayitSayisi.AutoSize = true;
            lblSecilmisKayitSayisi.Location = new System.Drawing.Point(1065, 87);
            lblSecilmisKayitSayisi.Name = "lblSecilmisKayitSayisi";
            lblSecilmisKayitSayisi.Size = new System.Drawing.Size(13, 15);
            lblSecilmisKayitSayisi.TabIndex = 116;
            lblSecilmisKayitSayisi.Text = "0";
            // 
            // lblKayitSayisi
            // 
            lblKayitSayisi.AutoSize = true;
            lblKayitSayisi.Location = new System.Drawing.Point(1065, 66);
            lblKayitSayisi.Name = "lblKayitSayisi";
            lblKayitSayisi.Size = new System.Drawing.Size(13, 15);
            lblKayitSayisi.TabIndex = 115;
            lblKayitSayisi.Text = "0";
            // 
            // ProjeDosyalari
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1287, 807);
            Controls.Add(lblToplamKayitSayisi);
            Controls.Add(lblSecilmisKayitSayisi);
            Controls.Add(lblKayitSayisi);
            Controls.Add(selectAll);
            Controls.Add(chkSec);
            Controls.Add(chkStep);
            Controls.Add(chkDxf);
            Controls.Add(chkPdf);
            Controls.Add(chkSatinalma);
            Controls.Add(textBoxParcaAdi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(parcaAltGrubu);
            Controls.Add(label1);
            Controls.Add(parcaGrubu);
            Controls.Add(label2);
            Controls.Add(panelFooter);
            Controls.Add(projeKod);
            Controls.Add(panelHeader);
            Controls.Add(panelFilter);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ProjeDosyalari";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ProjeDosyalari";
            Load += form_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStokKart).EndInit();
            panelFilter.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFooter.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewStokKart;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton roundedButton3;
        private CustomControls.RoundedButton roundedButton2;
        private CustomControls.RoundedButton roundedButton1;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomComboListBox projeKod;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomComboListBox parcaGrubu;
        private CustomControls.CustomComboListBox parcaAltGrubu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBox textBoxParcaAdi;
        private System.Windows.Forms.CheckBox chkSatinalma;
        private System.Windows.Forms.CheckBox chkPdf;
        private System.Windows.Forms.CheckBox chkDxf;
        private System.Windows.Forms.CheckBox chkStep;
        private System.Windows.Forms.CheckBox chkSec;
        private CustomControls.RoundedButton roundedButton4;
        private System.Windows.Forms.CheckBox selectAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem seçiliKalemlerİçinSaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokKartınıGörüntüleToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sec;
        private System.Windows.Forms.DataGridViewTextBoxColumn proje_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn proje_kod;
        private System.Windows.Forms.DataGridViewTextBoxColumn kod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn parcaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn boyut;
        private System.Windows.Forms.DataGridViewTextBoxColumn uzunluk;
        private System.Windows.Forms.DataGridViewTextBoxColumn malzeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn aciklama;
        private System.Windows.Forms.DataGridViewTextBoxColumn agirlik;
        private System.Windows.Forms.DataGridViewTextBoxColumn miktar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPdf;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDxf;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn parcaAltGrup_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn parcaAltGrup_ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn parcaGrup_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn olcuBirimId;
        private System.Windows.Forms.DataGridViewTextBoxColumn boy;
        private System.Windows.Forms.DataGridViewTextBoxColumn en;
        private System.Windows.Forms.DataGridViewTextBoxColumn yukseklik;
        private System.Windows.Forms.DataGridViewTextBoxColumn cap;
        private System.Windows.Forms.DataGridViewTextBoxColumn etKalinligi;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokTipId;
        private System.Windows.Forms.DataGridViewTextBoxColumn logoKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn malzemeStandartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn profilTipId;
        private System.Windows.Forms.DataGridViewTextBoxColumn parcaGrup_ad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSatinalma;
        private System.Windows.Forms.DataGridViewImageColumn Pdf;
        private System.Windows.Forms.DataGridViewImageColumn Dxf;
        private System.Windows.Forms.DataGridViewImageColumn Step;
        private System.Windows.Forms.DataGridViewImageColumn guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
        private System.Windows.Forms.Label lblToplamKayitSayisi;
        private System.Windows.Forms.Label lblSecilmisKayitSayisi;
        private System.Windows.Forms.Label lblKayitSayisi;
    }
}