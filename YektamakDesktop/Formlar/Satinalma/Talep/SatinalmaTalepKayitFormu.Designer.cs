using System;

namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTalepKayitFormu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            panelHeader = new System.Windows.Forms.Panel();
            roundedButton3 = new YektamakDesktop.CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            roundedButton2 = new YektamakDesktop.CustomControls.RoundedButton();
            lblKayitSayisi = new System.Windows.Forms.Label();
            dataGridViewSatinalma = new System.Windows.Forms.DataGridView();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartProjeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartProjekod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartKod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartboyut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartMalzeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartUzunluk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            agirlik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartAciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartMalzemeAltGrup2Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartMalzemeAltGrupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartMalzemeGrupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartStokGrupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            customTextBoxTeslimTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            customTextBoxAciklama = new YektamakDesktop.CustomControls.CustomTextBox();
            label4 = new System.Windows.Forms.Label();
            roundedButton4 = new YektamakDesktop.CustomControls.RoundedButton();
            cbxProjeKodu = new YektamakDesktop.CustomControls.CustomComboListBox();
            cbxMalzemeGrubu = new YektamakDesktop.CustomControls.CustomComboListBox();
            label5 = new System.Windows.Forms.Label();
            cbxKullaniciId = new YektamakDesktop.CustomControls.CustomComboListBox();
            customTextBoxTalepNo = new YektamakDesktop.CustomControls.CustomTextBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            customTextBoxTalepTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatinalma).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelHeader.BackColor = System.Drawing.Color.Firebrick;
            panelHeader.Controls.Add(roundedButton3);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Controls.Add(roundedButton1);
            panelHeader.Controls.Add(roundedButton2);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1286, 32);
            panelHeader.TabIndex = 8;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // roundedButton3
            // 
            roundedButton3.BackColor = System.Drawing.Color.Firebrick;
            roundedButton3.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton3.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton3.BorderRadius = 10;
            roundedButton3.BorderSize = 2;
            roundedButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            roundedButton3.FlatAppearance.BorderSize = 0;
            roundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton3.ForeColor = System.Drawing.Color.White;
            roundedButton3.Location = new System.Drawing.Point(1254, 1);
            roundedButton3.Margin = new System.Windows.Forms.Padding(0);
            roundedButton3.Name = "roundedButton3";
            roundedButton3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton3.Size = new System.Drawing.Size(29, 27);
            roundedButton3.TabIndex = 100;
            roundedButton3.Text = "X";
            roundedButton3.TextColor = System.Drawing.Color.White;
            roundedButton3.UseVisualStyleBackColor = false;
            roundedButton3.Click += roundedButton3_Click;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(12, 6);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(106, 17);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Satinalma Talep";
            // 
            // roundedButton1
            // 
            roundedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            roundedButton1.BackColor = System.Drawing.Color.Firebrick;
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderRadius = 10;
            roundedButton1.BorderSize = 2;
            roundedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.Location = new System.Drawing.Point(1220, 1);
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
            roundedButton2.BackColor = System.Drawing.Color.Firebrick;
            roundedButton2.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton2.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton2.BorderRadius = 10;
            roundedButton2.BorderSize = 2;
            roundedButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton2.ForeColor = System.Drawing.Color.White;
            roundedButton2.Location = new System.Drawing.Point(1190, 1);
            roundedButton2.Margin = new System.Windows.Forms.Padding(0);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton2.Size = new System.Drawing.Size(29, 27);
            roundedButton2.TabIndex = 99;
            roundedButton2.Text = "?";
            roundedButton2.TextColor = System.Drawing.Color.White;
            roundedButton2.UseVisualStyleBackColor = false;
            // 
            // lblKayitSayisi
            // 
            lblKayitSayisi.AutoSize = true;
            lblKayitSayisi.Location = new System.Drawing.Point(652, 754);
            lblKayitSayisi.Name = "lblKayitSayisi";
            lblKayitSayisi.Size = new System.Drawing.Size(108, 15);
            lblKayitSayisi.TabIndex = 10;
            lblKayitSayisi.Text = "Toplam kayıt sayısı:";
            // 
            // dataGridViewSatinalma
            // 
            dataGridViewSatinalma.AllowUserToAddRows = false;
            dataGridViewSatinalma.AllowUserToDeleteRows = false;
            dataGridViewSatinalma.AllowUserToOrderColumns = true;
            dataGridViewSatinalma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSatinalma.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, stokKartId, stokKartProjeId, stokKartProjekod, stokKartKod, stokKartAd, stokKartboyut, stokKartMalzeme, stokKartUzunluk, miktar, agirlik, stokKartAciklama, stokKartMalzemeAltGrup2Id, stokKartMalzemeAltGrupId, stokKartMalzemeGrupId, stokKartStokGrupId, guncelle, Sil });
            dataGridViewSatinalma.Location = new System.Drawing.Point(3, 311);
            dataGridViewSatinalma.Name = "dataGridViewSatinalma";
            dataGridViewSatinalma.RowTemplate.Height = 25;
            dataGridViewSatinalma.Size = new System.Drawing.Size(1279, 420);
            dataGridViewSatinalma.TabIndex = 11;
            dataGridViewSatinalma.CellClick += dataGridViewSatinalma_CellClick;
            dataGridViewSatinalma.CellMouseEnter += dataGridViewSatinalma_CellMouseEnter;
            dataGridViewSatinalma.CellMouseLeave += dataGridViewSatinalma_CellMouseLeave;
            dataGridViewSatinalma.CellValueChanged += dataGridViewSatinalma_CellValueChanged;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Visible = false;
            // 
            // stokKartId
            // 
            stokKartId.HeaderText = "stokKartId";
            stokKartId.Name = "stokKartId";
            stokKartId.Visible = false;
            // 
            // stokKartProjeId
            // 
            stokKartProjeId.DataPropertyName = "filtre";
            stokKartProjeId.HeaderText = "Proje Id";
            stokKartProjeId.Name = "stokKartProjeId";
            stokKartProjeId.Visible = false;
            // 
            // stokKartProjekod
            // 
            stokKartProjekod.HeaderText = "Proje Kodu";
            stokKartProjekod.Name = "stokKartProjekod";
            stokKartProjekod.ReadOnly = true;
            stokKartProjekod.Visible = false;
            // 
            // stokKartKod
            // 
            stokKartKod.HeaderText = "Stok Kodu";
            stokKartKod.Name = "stokKartKod";
            stokKartKod.ReadOnly = true;
            stokKartKod.Width = 150;
            // 
            // stokKartAd
            // 
            stokKartAd.DataPropertyName = "filtre";
            stokKartAd.HeaderText = "Stok Adı";
            stokKartAd.Name = "stokKartAd";
            stokKartAd.ReadOnly = true;
            stokKartAd.Width = 250;
            // 
            // stokKartboyut
            // 
            stokKartboyut.HeaderText = "Boyut";
            stokKartboyut.Name = "stokKartboyut";
            stokKartboyut.ReadOnly = true;
            // 
            // stokKartMalzeme
            // 
            stokKartMalzeme.HeaderText = "Malzeme";
            stokKartMalzeme.Name = "stokKartMalzeme";
            stokKartMalzeme.ReadOnly = true;
            // 
            // stokKartUzunluk
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            stokKartUzunluk.DefaultCellStyle = dataGridViewCellStyle1;
            stokKartUzunluk.HeaderText = "Uzunluk";
            stokKartUzunluk.Name = "stokKartUzunluk";
            stokKartUzunluk.ReadOnly = true;
            // 
            // miktar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            miktar.DefaultCellStyle = dataGridViewCellStyle2;
            miktar.HeaderText = "Miktar";
            miktar.Name = "miktar";
            // 
            // agirlik
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            agirlik.DefaultCellStyle = dataGridViewCellStyle3;
            agirlik.HeaderText = "Ağırlık";
            agirlik.Name = "agirlik";
            agirlik.ReadOnly = true;
            // 
            // stokKartAciklama
            // 
            stokKartAciklama.HeaderText = "Açıklama";
            stokKartAciklama.Name = "stokKartAciklama";
            stokKartAciklama.ReadOnly = true;
            // 
            // stokKartMalzemeAltGrup2Id
            // 
            stokKartMalzemeAltGrup2Id.DataPropertyName = "filtre";
            stokKartMalzemeAltGrup2Id.HeaderText = "malzemeAltGrup2Id";
            stokKartMalzemeAltGrup2Id.Name = "stokKartMalzemeAltGrup2Id";
            stokKartMalzemeAltGrup2Id.ReadOnly = true;
            stokKartMalzemeAltGrup2Id.Visible = false;
            // 
            // stokKartMalzemeAltGrupId
            // 
            stokKartMalzemeAltGrupId.HeaderText = "malzemeAltGrupId";
            stokKartMalzemeAltGrupId.Name = "stokKartMalzemeAltGrupId";
            stokKartMalzemeAltGrupId.ReadOnly = true;
            stokKartMalzemeAltGrupId.Visible = false;
            // 
            // stokKartMalzemeGrupId
            // 
            stokKartMalzemeGrupId.DataPropertyName = "filtre";
            stokKartMalzemeGrupId.HeaderText = "malzemeGrupId";
            stokKartMalzemeGrupId.Name = "stokKartMalzemeGrupId";
            stokKartMalzemeGrupId.ReadOnly = true;
            stokKartMalzemeGrupId.Visible = false;
            // 
            // stokKartStokGrupId
            // 
            stokKartStokGrupId.HeaderText = "stokGrupId";
            stokKartStokGrupId.Name = "stokKartStokGrupId";
            stokKartStokGrupId.ReadOnly = true;
            stokKartStokGrupId.Visible = false;
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
            // customTextBoxTeslimTarihi
            // 
            customTextBoxTeslimTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customTextBoxTeslimTarihi.Location = new System.Drawing.Point(150, 107);
            customTextBoxTeslimTarihi.Margin = new System.Windows.Forms.Padding(1);
            customTextBoxTeslimTarihi.Name = "customTextBoxTeslimTarihi";
            customTextBoxTeslimTarihi.Padding = new System.Windows.Forms.Padding(1);
            customTextBoxTeslimTarihi.Size = new System.Drawing.Size(145, 32);
            customTextBoxTeslimTarihi.TabIndex = 13;
            customTextBoxTeslimTarihi.TextCustom = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(35, 114);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(71, 15);
            label1.TabIndex = 15;
            label1.Text = "Teslim Tarihi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(35, 156);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 16;
            label2.Text = "Proje Kodu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(35, 191);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(91, 15);
            label3.TabIndex = 17;
            label3.Text = "Malzeme Grubu";
            // 
            // customTextBoxAciklama
            // 
            customTextBoxAciklama.BackColor = System.Drawing.Color.White;
            customTextBoxAciklama.BorderColor = System.Drawing.Color.Silver;
            customTextBoxAciklama.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxAciklama.BorderRadius = 5;
            customTextBoxAciklama.BorderSize = 1;
            customTextBoxAciklama.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxAciklama.ForeColor = System.Drawing.Color.Black;
            customTextBoxAciklama.isPlaceHolder = false;
            customTextBoxAciklama.Location = new System.Drawing.Point(729, 188);
            customTextBoxAciklama.Multiline = true;
            customTextBoxAciklama.Name = "customTextBoxAciklama";
            customTextBoxAciklama.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            customTextBoxAciklama.PasswordChar = false;
            customTextBoxAciklama.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxAciklama.PlaceholderText = "";
            customTextBoxAciklama.ReadOnly = false;
            customTextBoxAciklama.SelectionStart = 0;
            customTextBoxAciklama.Size = new System.Drawing.Size(402, 80);
            customTextBoxAciklama.TabIndex = 18;
            customTextBoxAciklama.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxAciklama.TextCustom = "";
            customTextBoxAciklama.UnderlinedStyle = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(614, 188);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(56, 15);
            label4.TabIndex = 19;
            label4.Text = "Açıklama";
            // 
            // roundedButton4
            // 
            roundedButton4.BackColor = System.Drawing.Color.YellowGreen;
            roundedButton4.BackgroundColor = System.Drawing.Color.YellowGreen;
            roundedButton4.BorderColor = System.Drawing.Color.GreenYellow;
            roundedButton4.BorderRadius = 40;
            roundedButton4.BorderSize = 5;
            roundedButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            roundedButton4.FlatAppearance.BorderSize = 0;
            roundedButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton4.ForeColor = System.Drawing.Color.White;
            roundedButton4.Location = new System.Drawing.Point(1067, 737);
            roundedButton4.Name = "roundedButton4";
            roundedButton4.Size = new System.Drawing.Size(152, 59);
            roundedButton4.TabIndex = 20;
            roundedButton4.Text = "Satınalma Talebi Oluştur";
            roundedButton4.TextColor = System.Drawing.Color.White;
            roundedButton4.UseVisualStyleBackColor = false;
            roundedButton4.Click += roundedButton4_Click;
            // 
            // cbxProjeKodu
            // 
            cbxProjeKodu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxProjeKodu.Enabled = false;
            cbxProjeKodu.ListBoxVisualSize = 5;
            cbxProjeKodu.Location = new System.Drawing.Point(148, 149);
            cbxProjeKodu.Margin = new System.Windows.Forms.Padding(1);
            cbxProjeKodu.Name = "cbxProjeKodu";
            cbxProjeKodu.Padding = new System.Windows.Forms.Padding(1);
            cbxProjeKodu.Size = new System.Drawing.Size(168, 36);
            cbxProjeKodu.TabIndex = 21;
            // 
            // cbxMalzemeGrubu
            // 
            cbxMalzemeGrubu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxMalzemeGrubu.Enabled = false;
            cbxMalzemeGrubu.ListBoxVisualSize = 5;
            cbxMalzemeGrubu.Location = new System.Drawing.Point(150, 186);
            cbxMalzemeGrubu.Margin = new System.Windows.Forms.Padding(1);
            cbxMalzemeGrubu.Name = "cbxMalzemeGrubu";
            cbxMalzemeGrubu.Padding = new System.Windows.Forms.Padding(1);
            cbxMalzemeGrubu.Size = new System.Drawing.Size(168, 36);
            cbxMalzemeGrubu.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(35, 233);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(111, 15);
            label5.TabIndex = 24;
            label5.Text = "Talep Eden Kullanıcı";
            // 
            // cbxKullaniciId
            // 
            cbxKullaniciId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxKullaniciId.ListBoxVisualSize = 5;
            cbxKullaniciId.Location = new System.Drawing.Point(150, 224);
            cbxKullaniciId.Margin = new System.Windows.Forms.Padding(1);
            cbxKullaniciId.Name = "cbxKullaniciId";
            cbxKullaniciId.Padding = new System.Windows.Forms.Padding(1);
            cbxKullaniciId.Size = new System.Drawing.Size(250, 36);
            cbxKullaniciId.TabIndex = 25;
            // 
            // customTextBoxTalepNo
            // 
            customTextBoxTalepNo.BackColor = System.Drawing.Color.White;
            customTextBoxTalepNo.BorderColor = System.Drawing.Color.Silver;
            customTextBoxTalepNo.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxTalepNo.BorderRadius = 5;
            customTextBoxTalepNo.BorderSize = 1;
            customTextBoxTalepNo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxTalepNo.ForeColor = System.Drawing.Color.Black;
            customTextBoxTalepNo.isPlaceHolder = false;
            customTextBoxTalepNo.Location = new System.Drawing.Point(150, 38);
            customTextBoxTalepNo.Multiline = false;
            customTextBoxTalepNo.Name = "customTextBoxTalepNo";
            customTextBoxTalepNo.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            customTextBoxTalepNo.PasswordChar = false;
            customTextBoxTalepNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxTalepNo.PlaceholderText = "";
            customTextBoxTalepNo.ReadOnly = false;
            customTextBoxTalepNo.SelectionStart = 0;
            customTextBoxTalepNo.Size = new System.Drawing.Size(166, 28);
            customTextBoxTalepNo.TabIndex = 26;
            customTextBoxTalepNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxTalepNo.TextCustom = "";
            customTextBoxTalepNo.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(35, 43);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(53, 15);
            label6.TabIndex = 27;
            label6.Text = "Talep No";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(35, 77);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(65, 15);
            label7.TabIndex = 29;
            label7.Text = "Talep Tarihi";
            // 
            // customTextBoxTalepTarihi
            // 
            customTextBoxTalepTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customTextBoxTalepTarihi.Location = new System.Drawing.Point(150, 70);
            customTextBoxTalepTarihi.Margin = new System.Windows.Forms.Padding(1);
            customTextBoxTalepTarihi.Name = "customTextBoxTalepTarihi";
            customTextBoxTalepTarihi.Padding = new System.Windows.Forms.Padding(1);
            customTextBoxTalepTarihi.Size = new System.Drawing.Size(145, 32);
            customTextBoxTalepTarihi.TabIndex = 28;
            // 
            // SatinalmaTalepKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(1286, 803);
            Controls.Add(label7);
            Controls.Add(customTextBoxTalepTarihi);
            Controls.Add(label6);
            Controls.Add(customTextBoxTalepNo);
            Controls.Add(cbxKullaniciId);
            Controls.Add(label5);
            Controls.Add(cbxMalzemeGrubu);
            Controls.Add(cbxProjeKodu);
            Controls.Add(roundedButton4);
            Controls.Add(label4);
            Controls.Add(customTextBoxAciklama);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(customTextBoxTeslimTarihi);
            Controls.Add(dataGridViewSatinalma);
            Controls.Add(lblKayitSayisi);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepKayitFormu";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "SatinalmaTalepOlusturma";
            Load += SatinalmaTalepOlusturma_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatinalma).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton roundedButton3;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.RoundedButton roundedButton2;
        private System.Windows.Forms.Label lblKayitSayisi;
        private System.Windows.Forms.DataGridView dataGridViewSatinalma;
        private CustomControls.CustomTextBoxTarih customTextBoxTeslimTarihi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomControls.CustomTextBox customTextBoxAciklama;
        private System.Windows.Forms.Label label4;
        private CustomControls.RoundedButton roundedButton4;
        private CustomControls.CustomComboListBox cbxProjeKodu;
        private CustomControls.CustomComboListBox cbxMalzemeGrubu;
        private System.Windows.Forms.Label label5;
        private CustomControls.CustomComboListBox cbxKullaniciId;
        private CustomControls.CustomTextBox customTextBoxTalepNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartProjeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartProjekod;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartboyut;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartMalzeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartUzunluk;
        private System.Windows.Forms.DataGridViewTextBoxColumn miktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn agirlik;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartAciklama;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartMalzemeAltGrup2Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartMalzemeAltGrupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartMalzemeGrupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartStokGrupId;
        private System.Windows.Forms.DataGridViewImageColumn guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
        private System.Windows.Forms.Label label7;
        private CustomControls.CustomTextBoxTarih customTextBoxTalepTarihi;
    }
}