namespace YektamakDesktop.Formlar.Stok
{
    partial class StokKartGridForm
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
            dataGridViewStokKart = new System.Windows.Forms.DataGridView();
            panelHeader = new System.Windows.Forms.Panel();
            roundedButton4 = new YektamakDesktop.CustomControls.RoundedButton();
            roundedButton5 = new YektamakDesktop.CustomControls.RoundedButton();
            roundedButton6 = new YektamakDesktop.CustomControls.RoundedButton();
            roundedButton3 = new YektamakDesktop.CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            roundedButton2 = new YektamakDesktop.CustomControls.RoundedButton();
            textBoxParcaAdi = new YektamakDesktop.CustomControls.CustomTextBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cbxMalzemeAltGrup = new YektamakDesktop.CustomControls.CustomComboListBox();
            label1 = new System.Windows.Forms.Label();
            cbxMalzemeGrup = new YektamakDesktop.CustomControls.CustomComboListBox();
            label2 = new System.Windows.Forms.Label();
            projeKodu = new YektamakDesktop.CustomControls.CustomComboListBox();
            panelFooter = new System.Windows.Forms.Panel();
            label7 = new System.Windows.Forms.Label();
            buttonSatisSiparisTeklifTalepEkle = new System.Windows.Forms.Button();
            lblToplamKayitSayisi = new System.Windows.Forms.Label();
            lblSecilmisKayitSayisi = new System.Windows.Forms.Label();
            lblKayitSayisi = new System.Windows.Forms.Label();
            panelFilter = new System.Windows.Forms.Panel();
            label5 = new System.Windows.Forms.Label();
            cbxMalzemeAltGrup2 = new YektamakDesktop.CustomControls.CustomComboListBox();
            label6 = new System.Windows.Forms.Label();
            cbxStokGrup = new YektamakDesktop.CustomControls.CustomComboListBox();
            cbxStokTip = new YektamakDesktop.CustomControls.CustomComboListBox();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            kod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokGrupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokGrupAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            malzemeGrupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            malzemeGrupAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            malzemeAltGrupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            malzemeAltGrupAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            malzemeAltGrup2Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            malzemeAltGrup2Ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            boyut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStokKart).BeginInit();
            panelHeader.SuspendLayout();
            panelFooter.SuspendLayout();
            panelFilter.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewStokKart
            // 
            dataGridViewStokKart.AllowUserToAddRows = false;
            dataGridViewStokKart.AllowUserToDeleteRows = false;
            dataGridViewStokKart.AllowUserToOrderColumns = true;
            dataGridViewStokKart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            dataGridViewStokKart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStokKart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, kod, ad, stokGrupId, stokGrupAd, malzemeGrupId, malzemeGrupAd, malzemeAltGrupId, malzemeAltGrupAd, malzemeAltGrup2Id, malzemeAltGrup2Ad, boyut, Guncelle, Sil });
            dataGridViewStokKart.Location = new System.Drawing.Point(3, 3);
            dataGridViewStokKart.Name = "dataGridViewStokKart";
            dataGridViewStokKart.ReadOnly = true;
            dataGridViewStokKart.RowTemplate.Height = 25;
            dataGridViewStokKart.Size = new System.Drawing.Size(1077, 360);
            dataGridViewStokKart.TabIndex = 4;
            dataGridViewStokKart.CellClick += dataGridView_CellClick;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Firebrick;
            panelHeader.Controls.Add(roundedButton4);
            panelHeader.Controls.Add(roundedButton5);
            panelHeader.Controls.Add(roundedButton6);
            panelHeader.Controls.Add(roundedButton3);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Controls.Add(roundedButton1);
            panelHeader.Controls.Add(roundedButton2);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1086, 32);
            panelHeader.TabIndex = 8;
            // 
            // roundedButton4
            // 
            roundedButton4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton4.BackColor = System.Drawing.Color.Firebrick;
            roundedButton4.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton4.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton4.BorderRadius = 10;
            roundedButton4.BorderSize = 2;
            roundedButton4.FlatAppearance.BorderSize = 0;
            roundedButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton4.ForeColor = System.Drawing.Color.White;
            roundedButton4.Location = new System.Drawing.Point(1054, 2);
            roundedButton4.Margin = new System.Windows.Forms.Padding(0);
            roundedButton4.Name = "roundedButton4";
            roundedButton4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton4.Size = new System.Drawing.Size(29, 27);
            roundedButton4.TabIndex = 103;
            roundedButton4.Text = "X";
            roundedButton4.TextColor = System.Drawing.Color.White;
            roundedButton4.UseVisualStyleBackColor = false;
            roundedButton4.Click += buttonClose_Click;
            // 
            // roundedButton5
            // 
            roundedButton5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton5.BackColor = System.Drawing.Color.Firebrick;
            roundedButton5.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton5.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton5.BorderRadius = 10;
            roundedButton5.BorderSize = 2;
            roundedButton5.FlatAppearance.BorderSize = 0;
            roundedButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton5.ForeColor = System.Drawing.Color.White;
            roundedButton5.Location = new System.Drawing.Point(1014, 2);
            roundedButton5.Margin = new System.Windows.Forms.Padding(0);
            roundedButton5.Name = "roundedButton5";
            roundedButton5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton5.Size = new System.Drawing.Size(29, 27);
            roundedButton5.TabIndex = 101;
            roundedButton5.Text = "-";
            roundedButton5.TextColor = System.Drawing.Color.White;
            roundedButton5.UseVisualStyleBackColor = false;
            roundedButton5.Click += buttomMinimize_Click;
            // 
            // roundedButton6
            // 
            roundedButton6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton6.BackColor = System.Drawing.Color.Firebrick;
            roundedButton6.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton6.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton6.BorderRadius = 10;
            roundedButton6.BorderSize = 2;
            roundedButton6.FlatAppearance.BorderSize = 0;
            roundedButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton6.ForeColor = System.Drawing.Color.White;
            roundedButton6.Location = new System.Drawing.Point(975, 3);
            roundedButton6.Margin = new System.Windows.Forms.Padding(0);
            roundedButton6.Name = "roundedButton6";
            roundedButton6.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton6.Size = new System.Drawing.Size(29, 27);
            roundedButton6.TabIndex = 102;
            roundedButton6.Text = "?";
            roundedButton6.TextColor = System.Drawing.Color.White;
            roundedButton6.UseVisualStyleBackColor = false;
            // 
            // roundedButton3
            // 
            roundedButton3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton3.BackColor = System.Drawing.Color.Firebrick;
            roundedButton3.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton3.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton3.BorderRadius = 0;
            roundedButton3.BorderSize = 2;
            roundedButton3.FlatAppearance.BorderSize = 0;
            roundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton3.ForeColor = System.Drawing.Color.White;
            roundedButton3.Location = new System.Drawing.Point(2135, 1);
            roundedButton3.Margin = new System.Windows.Forms.Padding(0);
            roundedButton3.Name = "roundedButton3";
            roundedButton3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton3.Size = new System.Drawing.Size(29, 0);
            roundedButton3.TabIndex = 100;
            roundedButton3.Text = "X";
            roundedButton3.TextColor = System.Drawing.Color.White;
            roundedButton3.UseVisualStyleBackColor = false;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(12, 6);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(84, 17);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Stok Kartları";
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton1.BackColor = System.Drawing.Color.Firebrick;
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderRadius = 0;
            roundedButton1.BorderSize = 2;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.Location = new System.Drawing.Point(2095, 1);
            roundedButton1.Margin = new System.Windows.Forms.Padding(0);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton1.Size = new System.Drawing.Size(29, 0);
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
            roundedButton2.BorderRadius = 0;
            roundedButton2.BorderSize = 2;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton2.ForeColor = System.Drawing.Color.White;
            roundedButton2.Location = new System.Drawing.Point(2056, 2);
            roundedButton2.Margin = new System.Windows.Forms.Padding(0);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton2.Size = new System.Drawing.Size(29, 0);
            roundedButton2.TabIndex = 99;
            roundedButton2.Text = "?";
            roundedButton2.TextColor = System.Drawing.Color.White;
            roundedButton2.UseVisualStyleBackColor = false;
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
            textBoxParcaAdi.Location = new System.Drawing.Point(143, 238);
            textBoxParcaAdi.Multiline = false;
            textBoxParcaAdi.Name = "textBoxParcaAdi";
            textBoxParcaAdi.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            textBoxParcaAdi.PasswordChar = false;
            textBoxParcaAdi.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxParcaAdi.PlaceholderText = "";
            textBoxParcaAdi.ReadOnly = false;
            textBoxParcaAdi.SelectionStart = 0;
            textBoxParcaAdi.Size = new System.Drawing.Size(250, 28);
            textBoxParcaAdi.TabIndex = 116;
            textBoxParcaAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxParcaAdi.TextCustom = "";
            textBoxParcaAdi.UnderlinedStyle = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(24, 244);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 15);
            label4.TabIndex = 115;
            label4.Text = "Parça Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(24, 168);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(109, 15);
            label3.TabIndex = 114;
            label3.Text = "Malzeme Alt Grubu";
            // 
            // cbxMalzemeAltGrup
            // 
            cbxMalzemeAltGrup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxMalzemeAltGrup.ListBoxVisualSize = 5;
            cbxMalzemeAltGrup.Location = new System.Drawing.Point(143, 162);
            cbxMalzemeAltGrup.Margin = new System.Windows.Forms.Padding(1);
            cbxMalzemeAltGrup.Name = "cbxMalzemeAltGrup";
            cbxMalzemeAltGrup.Padding = new System.Windows.Forms.Padding(1);
            cbxMalzemeAltGrup.Size = new System.Drawing.Size(251, 36);
            cbxMalzemeAltGrup.TabIndex = 113;
            cbxMalzemeAltGrup.SelectedIndexChanged += cbxMalzemeAltGrup_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(24, 136);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 15);
            label1.TabIndex = 112;
            label1.Text = "Malzeme Grubu";
            // 
            // cbxMalzemeGrup
            // 
            cbxMalzemeGrup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxMalzemeGrup.ListBoxVisualSize = 5;
            cbxMalzemeGrup.Location = new System.Drawing.Point(143, 130);
            cbxMalzemeGrup.Margin = new System.Windows.Forms.Padding(1);
            cbxMalzemeGrup.Name = "cbxMalzemeGrup";
            cbxMalzemeGrup.Padding = new System.Windows.Forms.Padding(1);
            cbxMalzemeGrup.Size = new System.Drawing.Size(251, 36);
            cbxMalzemeGrup.TabIndex = 111;
            cbxMalzemeGrup.SelectedIndexChanged += malzemeGrubu_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(24, 69);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 110;
            label2.Text = "Proje Kodu";
            // 
            // projeKodu
            // 
            projeKodu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            projeKodu.ListBoxVisualSize = 5;
            projeKodu.Location = new System.Drawing.Point(143, 60);
            projeKodu.Margin = new System.Windows.Forms.Padding(1);
            projeKodu.Name = "projeKodu";
            projeKodu.Padding = new System.Windows.Forms.Padding(1);
            projeKodu.Size = new System.Drawing.Size(251, 36);
            projeKodu.TabIndex = 109;
            projeKodu.SelectedIndexChanged += projeKodu_SelectedIndexChanged;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            panelFooter.Controls.Add(label7);
            panelFooter.Location = new System.Drawing.Point(0, 737);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1086, 65);
            panelFooter.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(43, 22);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(38, 15);
            label7.TabIndex = 0;
            label7.Text = "label7";
            // 
            // buttonSatisSiparisTeklifTalepEkle
            // 
            buttonSatisSiparisTeklifTalepEkle.BackColor = System.Drawing.Color.Transparent;
            buttonSatisSiparisTeklifTalepEkle.BackgroundImage = Properties.Resources.ekle45x45;
            buttonSatisSiparisTeklifTalepEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonSatisSiparisTeklifTalepEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonSatisSiparisTeklifTalepEkle.FlatAppearance.BorderSize = 0;
            buttonSatisSiparisTeklifTalepEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSatisSiparisTeklifTalepEkle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSatisSiparisTeklifTalepEkle.ForeColor = System.Drawing.SystemColors.Window;
            buttonSatisSiparisTeklifTalepEkle.Location = new System.Drawing.Point(461, 233);
            buttonSatisSiparisTeklifTalepEkle.Name = "buttonSatisSiparisTeklifTalepEkle";
            buttonSatisSiparisTeklifTalepEkle.Size = new System.Drawing.Size(42, 35);
            buttonSatisSiparisTeklifTalepEkle.TabIndex = 118;
            buttonSatisSiparisTeklifTalepEkle.UseVisualStyleBackColor = false;
            buttonSatisSiparisTeklifTalepEkle.Click += buttonEkle_Click;
            // 
            // lblToplamKayitSayisi
            // 
            lblToplamKayitSayisi.AutoSize = true;
            lblToplamKayitSayisi.Location = new System.Drawing.Point(891, 60);
            lblToplamKayitSayisi.Name = "lblToplamKayitSayisi";
            lblToplamKayitSayisi.Size = new System.Drawing.Size(13, 15);
            lblToplamKayitSayisi.TabIndex = 121;
            lblToplamKayitSayisi.Text = "0";
            // 
            // lblSecilmisKayitSayisi
            // 
            lblSecilmisKayitSayisi.AutoSize = true;
            lblSecilmisKayitSayisi.Location = new System.Drawing.Point(891, 102);
            lblSecilmisKayitSayisi.Name = "lblSecilmisKayitSayisi";
            lblSecilmisKayitSayisi.Size = new System.Drawing.Size(13, 15);
            lblSecilmisKayitSayisi.TabIndex = 120;
            lblSecilmisKayitSayisi.Text = "0";
            // 
            // lblKayitSayisi
            // 
            lblKayitSayisi.AutoSize = true;
            lblKayitSayisi.Location = new System.Drawing.Point(891, 81);
            lblKayitSayisi.Name = "lblKayitSayisi";
            lblKayitSayisi.Size = new System.Drawing.Size(13, 15);
            lblKayitSayisi.TabIndex = 119;
            lblKayitSayisi.Text = "0";
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(dataGridViewStokKart);
            panelFilter.Location = new System.Drawing.Point(0, 327);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1083, 384);
            panelFilter.TabIndex = 122;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(24, 208);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(118, 15);
            label5.TabIndex = 124;
            label5.Text = "Malzeme Alt Grubu 2";
            // 
            // cbxMalzemeAltGrup2
            // 
            cbxMalzemeAltGrup2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxMalzemeAltGrup2.ListBoxVisualSize = 5;
            cbxMalzemeAltGrup2.Location = new System.Drawing.Point(143, 201);
            cbxMalzemeAltGrup2.Margin = new System.Windows.Forms.Padding(1);
            cbxMalzemeAltGrup2.Name = "cbxMalzemeAltGrup2";
            cbxMalzemeAltGrup2.Padding = new System.Windows.Forms.Padding(1);
            cbxMalzemeAltGrup2.Size = new System.Drawing.Size(251, 36);
            cbxMalzemeAltGrup2.TabIndex = 123;
            cbxMalzemeAltGrup2.DoubleClick += cbxMalzemeAltGrup2_DoubleClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(24, 102);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(66, 15);
            label6.TabIndex = 126;
            label6.Text = "Stok Grubu";
            // 
            // cbxStokGrup
            // 
            cbxStokGrup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxStokGrup.ListBoxVisualSize = 5;
            cbxStokGrup.Location = new System.Drawing.Point(143, 96);
            cbxStokGrup.Margin = new System.Windows.Forms.Padding(1);
            cbxStokGrup.Name = "cbxStokGrup";
            cbxStokGrup.Padding = new System.Windows.Forms.Padding(1);
            cbxStokGrup.Size = new System.Drawing.Size(251, 36);
            cbxStokGrup.TabIndex = 125;
            cbxStokGrup.SelectedIndexChanged += cbxStokGrup_SelectedIndexChanged;
            // 
            // cbxStokTip
            // 
            cbxStokTip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxStokTip.ListBoxVisualSize = 5;
            cbxStokTip.Location = new System.Drawing.Point(514, 96);
            cbxStokTip.Margin = new System.Windows.Forms.Padding(1);
            cbxStokTip.Name = "cbxStokTip";
            cbxStokTip.Padding = new System.Windows.Forms.Padding(1);
            cbxStokTip.Size = new System.Drawing.Size(249, 36);
            cbxStokTip.TabIndex = 127;
            cbxStokTip.SelectedIndexChanged += cbxStokTip_SelectedIndexChanged;
            // 
            // Id
            // 
            Id.HeaderText = "StokKartId";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // kod
            // 
            kod.HeaderText = "Parça Kodu";
            kod.Name = "kod";
            kod.ReadOnly = true;
            kod.Width = 150;
            // 
            // ad
            // 
            ad.HeaderText = "Stok Adı";
            ad.Name = "ad";
            ad.ReadOnly = true;
            ad.Width = 200;
            // 
            // stokGrupId
            // 
            stokGrupId.HeaderText = "StokGrupID";
            stokGrupId.Name = "stokGrupId";
            stokGrupId.ReadOnly = true;
            stokGrupId.Visible = false;
            // 
            // stokGrupAd
            // 
            stokGrupAd.HeaderText = "Stok Grup";
            stokGrupAd.Name = "stokGrupAd";
            stokGrupAd.ReadOnly = true;
            // 
            // malzemeGrupId
            // 
            malzemeGrupId.HeaderText = "MalzemeGrupID";
            malzemeGrupId.Name = "malzemeGrupId";
            malzemeGrupId.ReadOnly = true;
            malzemeGrupId.Visible = false;
            // 
            // malzemeGrupAd
            // 
            malzemeGrupAd.HeaderText = "Grup";
            malzemeGrupAd.Name = "malzemeGrupAd";
            malzemeGrupAd.ReadOnly = true;
            // 
            // malzemeAltGrupId
            // 
            malzemeAltGrupId.HeaderText = "MalzemeAltGrupID";
            malzemeAltGrupId.Name = "malzemeAltGrupId";
            malzemeAltGrupId.ReadOnly = true;
            malzemeAltGrupId.Visible = false;
            // 
            // malzemeAltGrupAd
            // 
            malzemeAltGrupAd.HeaderText = "Alt Grup";
            malzemeAltGrupAd.Name = "malzemeAltGrupAd";
            malzemeAltGrupAd.ReadOnly = true;
            // 
            // malzemeAltGrup2Id
            // 
            malzemeAltGrup2Id.HeaderText = "MalzemeAltGrup2ID";
            malzemeAltGrup2Id.Name = "malzemeAltGrup2Id";
            malzemeAltGrup2Id.ReadOnly = true;
            malzemeAltGrup2Id.Visible = false;
            // 
            // malzemeAltGrup2Ad
            // 
            malzemeAltGrup2Ad.HeaderText = "Alt Grup 2";
            malzemeAltGrup2Ad.Name = "malzemeAltGrup2Ad";
            malzemeAltGrup2Ad.ReadOnly = true;
            // 
            // boyut
            // 
            boyut.HeaderText = "Boyut";
            boyut.Name = "boyut";
            boyut.ReadOnly = true;
            // 
            // Guncelle
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "System.Drawing.Bitmap";
            Guncelle.DefaultCellStyle = dataGridViewCellStyle1;
            Guncelle.HeaderText = "Güncelle";
            Guncelle.Image = Properties.Resources.data_update_icon;
            Guncelle.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Guncelle.Name = "Guncelle";
            Guncelle.ReadOnly = true;
            Guncelle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Guncelle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            Guncelle.Width = 70;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.Image = Properties.Resources.sil1;
            Sil.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
            Sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Sil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            Sil.Width = 50;
            // 
            // StokKartGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1086, 804);
            Controls.Add(cbxStokTip);
            Controls.Add(label6);
            Controls.Add(cbxStokGrup);
            Controls.Add(label5);
            Controls.Add(cbxMalzemeAltGrup2);
            Controls.Add(panelFilter);
            Controls.Add(lblToplamKayitSayisi);
            Controls.Add(lblSecilmisKayitSayisi);
            Controls.Add(lblKayitSayisi);
            Controls.Add(buttonSatisSiparisTeklifTalepEkle);
            Controls.Add(textBoxParcaAdi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbxMalzemeAltGrup);
            Controls.Add(label1);
            Controls.Add(cbxMalzemeGrup);
            Controls.Add(label2);
            Controls.Add(projeKodu);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "StokKartGridForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "SatinalmaTalepGridForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewStokKart).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            panelFilter.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewStokKart;
        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton roundedButton3;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.RoundedButton roundedButton2;
        private CustomControls.RoundedButton roundedButton4;
        private CustomControls.RoundedButton roundedButton5;
        private CustomControls.RoundedButton roundedButton6;
        private CustomControls.CustomTextBox textBoxParcaAdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private CustomControls.CustomComboListBox cbxMalzemeAltGrup;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomComboListBox cbxMalzemeGrup;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomComboListBox projeKodu;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button buttonSatisSiparisTeklifTalepEkle;
        private System.Windows.Forms.Label lblToplamKayitSayisi;
        private System.Windows.Forms.Label lblSecilmisKayitSayisi;
        private System.Windows.Forms.Label lblKayitSayisi;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label label5;
        private CustomControls.CustomComboListBox cbxMalzemeAltGrup2;
        private System.Windows.Forms.Label label6;
        private CustomControls.CustomComboListBox cbxStokGrup;
        private CustomControls.CustomComboListBox cbxStokTip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn kod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokGrupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokGrupAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn malzemeGrupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn malzemeGrupAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn malzemeAltGrupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn malzemeAltGrupAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn malzemeAltGrup2Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn malzemeAltGrup2Ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn boyut;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}