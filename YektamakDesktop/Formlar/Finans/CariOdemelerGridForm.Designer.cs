namespace YektamakDesktop.Formlar.Finans
{
    partial class CariOdemelerGridForm
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
            buttonCikis = new CustomControls.RoundedButton();
            roundedButton2 = new CustomControls.RoundedButton();
            buttonMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            panelFilter = new System.Windows.Forms.Panel();
            buttonKayitEkle = new CustomControls.RoundedIconButton();
            buttonTumKayitlariGetir = new CustomControls.RoundedIconButton();
            buttonFiltre = new CustomControls.RoundedIconButton();
            dataGridView = new System.Windows.Forms.DataGridView();
            panelFooter = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            cariOdemeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cariKart_cariKartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cariKart_cariAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_dovizCinsi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar_dovizCinsi_sembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            mahsupEdilenTutar_tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            mahsupEdilenTutar_dovizCinsi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            mahsupEdilenTutar_dovizCinsi_sembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeYonu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeSekli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cek_cekId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cek_cekNumarasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            krediKarti_krediKartiId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            krediKarti_kartSahibi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            taksitOdemesi_taksitOdemesiId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeninCiktigiKasa_kasaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeninCiktigiKasa_kasaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeninGirdigiKasa_kasaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeninGirdigiKasa_kasaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeYapilanCariKart_cariKartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeYapilanCariKart_cariAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            projeKod_projeKodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            projeKod_projeKodString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeTanimi_odemeTanimiId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeTanimi_odemeTanimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            panelHeader.Controls.Add(buttonCikis);
            panelHeader.Controls.Add(roundedButton2);
            panelHeader.Controls.Add(buttonMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1085, 56);
            panelHeader.TabIndex = 0;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // buttonCikis
            // 
            buttonCikis.BackColor = System.Drawing.Color.Red;
            buttonCikis.BackgroundColor = System.Drawing.Color.Red;
            buttonCikis.BorderColor = System.Drawing.Color.LavenderBlush;
            buttonCikis.BorderRadius = 10;
            buttonCikis.BorderSize = 2;
            buttonCikis.FlatAppearance.BorderSize = 0;
            buttonCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCikis.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCikis.ForeColor = System.Drawing.Color.White;
            buttonCikis.Location = new System.Drawing.Point(1036, 9);
            buttonCikis.Margin = new System.Windows.Forms.Padding(0);
            buttonCikis.Name = "buttonCikis";
            buttonCikis.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonCikis.Size = new System.Drawing.Size(40, 38);
            buttonCikis.TabIndex = 100;
            buttonCikis.Text = "x";
            buttonCikis.TextColor = System.Drawing.Color.White;
            buttonCikis.UseVisualStyleBackColor = false;
            buttonCikis.Click += buttonClose_Click;
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
            roundedButton2.Location = new System.Drawing.Point(956, 9);
            roundedButton2.Margin = new System.Windows.Forms.Padding(0);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton2.Size = new System.Drawing.Size(40, 38);
            roundedButton2.TabIndex = 99;
            roundedButton2.Text = "?";
            roundedButton2.TextColor = System.Drawing.Color.White;
            roundedButton2.UseVisualStyleBackColor = false;
            // 
            // buttonMinimize
            // 
            buttonMinimize.BackColor = System.Drawing.Color.Red;
            buttonMinimize.BackgroundColor = System.Drawing.Color.Red;
            buttonMinimize.BorderColor = System.Drawing.Color.LavenderBlush;
            buttonMinimize.BorderRadius = 10;
            buttonMinimize.BorderSize = 2;
            buttonMinimize.FlatAppearance.BorderSize = 0;
            buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonMinimize.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonMinimize.ForeColor = System.Drawing.Color.White;
            buttonMinimize.Location = new System.Drawing.Point(996, 9);
            buttonMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttonMinimize.Name = "buttonMinimize";
            buttonMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonMinimize.Size = new System.Drawing.Size(40, 38);
            buttonMinimize.TabIndex = 98;
            buttonMinimize.Text = "-";
            buttonMinimize.TextColor = System.Drawing.Color.White;
            buttonMinimize.UseVisualStyleBackColor = false;
            buttonMinimize.Click += buttomMinimize_Click;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(12, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(152, 30);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Cari Ödemeler";
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(buttonKayitEkle);
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(buttonFiltre);
            panelFilter.Controls.Add(dataGridView);
            panelFilter.Location = new System.Drawing.Point(0, 56);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1085, 634);
            panelFilter.TabIndex = 1;
            // 
            // buttonKayitEkle
            // 
            buttonKayitEkle.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonKayitEkle.CornerRadius = 15;
            buttonKayitEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonKayitEkle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonKayitEkle.ForeColor = System.Drawing.Color.Gainsboro;
            buttonKayitEkle.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            buttonKayitEkle.IconColor = System.Drawing.Color.Gainsboro;
            buttonKayitEkle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonKayitEkle.IconSize = 25;
            buttonKayitEkle.Location = new System.Drawing.Point(983, 6);
            buttonKayitEkle.Name = "buttonKayitEkle";
            buttonKayitEkle.Size = new System.Drawing.Size(93, 46);
            buttonKayitEkle.TabIndex = 22;
            buttonKayitEkle.Text = "Kayıt Ekle";
            buttonKayitEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonKayitEkle.UseVisualStyleBackColor = false;
            buttonKayitEkle.Click += buttonEkle_Click;
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
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(828, 6);
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
            buttonFiltre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonFiltre.ForeColor = System.Drawing.Color.Gainsboro;
            buttonFiltre.IconChar = FontAwesome.Sharp.IconChar.Filter;
            buttonFiltre.IconColor = System.Drawing.Color.Gainsboro;
            buttonFiltre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonFiltre.IconSize = 25;
            buttonFiltre.Location = new System.Drawing.Point(740, 6);
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
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { cariOdemeId, cariKart_cariKartId, cariKart_cariAdi, odemeTarihi, tutar_tutar, tutar_dovizCinsi_id, tutar_dovizCinsi_sembol, mahsupEdilenTutar_tutar, mahsupEdilenTutar_dovizCinsi_id, mahsupEdilenTutar_dovizCinsi_sembol, odemeYonu, odemeTuru, odemeSekli, cek_cekId, cek_cekNumarasi, krediKarti_krediKartiId, krediKarti_kartSahibi, taksitOdemesi_taksitOdemesiId, odemeninCiktigiKasa_kasaId, odemeninCiktigiKasa_kasaAdi, odemeninGirdigiKasa_kasaId, odemeninGirdigiKasa_kasaAdi, odemeYapilanCariKart_cariKartId, odemeYapilanCariKart_cariAdi, projeKod_projeKodId, projeKod_projeKodString, odemeTanimi_odemeTanimiId, odemeTanimi_odemeTanimi, aciklama, Guncelle, Sil });
            dataGridView.Location = new System.Drawing.Point(-3, 97);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new System.Drawing.Size(1085, 537);
            dataGridView.TabIndex = 3;
            dataGridView.CellClick += dataGridView_CellClick;
            dataGridView.ColumnWidthChanged += dataGridView_ColumnWidthChanged;
            dataGridView.Scroll += dataGridView_Scroll;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(buttonClose);
            panelFooter.Location = new System.Drawing.Point(0, 689);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1085, 65);
            panelFooter.TabIndex = 2;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = System.Drawing.Color.Brown;
            buttonClose.BackgroundColor = System.Drawing.Color.Brown;
            buttonClose.BorderColor = System.Drawing.Color.Crimson;
            buttonClose.BorderRadius = 40;
            buttonClose.BorderSize = 5;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonClose.ForeColor = System.Drawing.Color.White;
            buttonClose.Location = new System.Drawing.Point(30, 7);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new System.Drawing.Size(152, 59);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "KAPAT";
            buttonClose.TextColor = System.Drawing.Color.White;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // cariOdemeId
            // 
            cariOdemeId.HeaderText = "CariOdemeId";
            cariOdemeId.Name = "cariOdemeId";
            cariOdemeId.ReadOnly = true;
            cariOdemeId.Visible = false;
            // 
            // cariKart_cariKartId
            // 
            cariKart_cariKartId.HeaderText = "CariKartId";
            cariKart_cariKartId.Name = "cariKart_cariKartId";
            cariKart_cariKartId.ReadOnly = true;
            cariKart_cariKartId.Visible = false;
            // 
            // cariKart_cariAdi
            // 
            cariKart_cariAdi.DataPropertyName = "filtre";
            cariKart_cariAdi.HeaderText = "Cari Adı";
            cariKart_cariAdi.Name = "cariKart_cariAdi";
            cariKart_cariAdi.ReadOnly = true;
            cariKart_cariAdi.Width = 150;
            // 
            // odemeTarihi
            // 
            odemeTarihi.DataPropertyName = "filtre";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            odemeTarihi.DefaultCellStyle = dataGridViewCellStyle1;
            odemeTarihi.HeaderText = "Ödeme Tarihi";
            odemeTarihi.Name = "odemeTarihi";
            odemeTarihi.ReadOnly = true;
            // 
            // tutar_tutar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            tutar_tutar.DefaultCellStyle = dataGridViewCellStyle2;
            tutar_tutar.HeaderText = "Tutar";
            tutar_tutar.Name = "tutar_tutar";
            tutar_tutar.ReadOnly = true;
            // 
            // tutar_dovizCinsi_id
            // 
            tutar_dovizCinsi_id.HeaderText = "DovizId";
            tutar_dovizCinsi_id.Name = "tutar_dovizCinsi_id";
            tutar_dovizCinsi_id.ReadOnly = true;
            tutar_dovizCinsi_id.Visible = false;
            // 
            // tutar_dovizCinsi_sembol
            // 
            tutar_dovizCinsi_sembol.HeaderText = "";
            tutar_dovizCinsi_sembol.Name = "tutar_dovizCinsi_sembol";
            tutar_dovizCinsi_sembol.ReadOnly = true;
            tutar_dovizCinsi_sembol.Width = 20;
            // 
            // mahsupEdilenTutar_tutar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            mahsupEdilenTutar_tutar.DefaultCellStyle = dataGridViewCellStyle3;
            mahsupEdilenTutar_tutar.HeaderText = "Mahsup Edilen Tutar";
            mahsupEdilenTutar_tutar.Name = "mahsupEdilenTutar_tutar";
            mahsupEdilenTutar_tutar.ReadOnly = true;
            // 
            // mahsupEdilenTutar_dovizCinsi_id
            // 
            mahsupEdilenTutar_dovizCinsi_id.HeaderText = "mahsupEdilenTutarDovizId";
            mahsupEdilenTutar_dovizCinsi_id.Name = "mahsupEdilenTutar_dovizCinsi_id";
            mahsupEdilenTutar_dovizCinsi_id.ReadOnly = true;
            mahsupEdilenTutar_dovizCinsi_id.Visible = false;
            // 
            // mahsupEdilenTutar_dovizCinsi_sembol
            // 
            mahsupEdilenTutar_dovizCinsi_sembol.HeaderText = "";
            mahsupEdilenTutar_dovizCinsi_sembol.Name = "mahsupEdilenTutar_dovizCinsi_sembol";
            mahsupEdilenTutar_dovizCinsi_sembol.ReadOnly = true;
            mahsupEdilenTutar_dovizCinsi_sembol.Width = 20;
            // 
            // odemeYonu
            // 
            odemeYonu.HeaderText = "OdemeYonu";
            odemeYonu.Name = "odemeYonu";
            odemeYonu.ReadOnly = true;
            // 
            // odemeTuru
            // 
            odemeTuru.HeaderText = "Ödeme Türü";
            odemeTuru.Name = "odemeTuru";
            odemeTuru.ReadOnly = true;
            // 
            // odemeSekli
            // 
            odemeSekli.HeaderText = "Ödeme Şekli";
            odemeSekli.Name = "odemeSekli";
            odemeSekli.ReadOnly = true;
            // 
            // cek_cekId
            // 
            cek_cekId.HeaderText = "CekId";
            cek_cekId.Name = "cek_cekId";
            cek_cekId.ReadOnly = true;
            cek_cekId.Visible = false;
            // 
            // cek_cekNumarasi
            // 
            cek_cekNumarasi.HeaderText = "Çek Numarası";
            cek_cekNumarasi.Name = "cek_cekNumarasi";
            cek_cekNumarasi.ReadOnly = true;
            // 
            // krediKarti_krediKartiId
            // 
            krediKarti_krediKartiId.HeaderText = "KrediKartiId";
            krediKarti_krediKartiId.Name = "krediKarti_krediKartiId";
            krediKarti_krediKartiId.ReadOnly = true;
            krediKarti_krediKartiId.Visible = false;
            // 
            // krediKarti_kartSahibi
            // 
            krediKarti_kartSahibi.HeaderText = "Kart Sahibi";
            krediKarti_kartSahibi.Name = "krediKarti_kartSahibi";
            krediKarti_kartSahibi.ReadOnly = true;
            // 
            // taksitOdemesi_taksitOdemesiId
            // 
            taksitOdemesi_taksitOdemesiId.HeaderText = "taksitOdemesiId";
            taksitOdemesi_taksitOdemesiId.Name = "taksitOdemesi_taksitOdemesiId";
            taksitOdemesi_taksitOdemesiId.ReadOnly = true;
            // 
            // odemeninCiktigiKasa_kasaId
            // 
            odemeninCiktigiKasa_kasaId.HeaderText = "odemeninCiktigiKasaId";
            odemeninCiktigiKasa_kasaId.Name = "odemeninCiktigiKasa_kasaId";
            odemeninCiktigiKasa_kasaId.ReadOnly = true;
            odemeninCiktigiKasa_kasaId.Visible = false;
            // 
            // odemeninCiktigiKasa_kasaAdi
            // 
            odemeninCiktigiKasa_kasaAdi.HeaderText = "Ödemenin Çıktığı Kasa";
            odemeninCiktigiKasa_kasaAdi.Name = "odemeninCiktigiKasa_kasaAdi";
            odemeninCiktigiKasa_kasaAdi.ReadOnly = true;
            // 
            // odemeninGirdigiKasa_kasaId
            // 
            odemeninGirdigiKasa_kasaId.HeaderText = "odemeninGirdigiKasaId";
            odemeninGirdigiKasa_kasaId.Name = "odemeninGirdigiKasa_kasaId";
            odemeninGirdigiKasa_kasaId.ReadOnly = true;
            odemeninGirdigiKasa_kasaId.Visible = false;
            // 
            // odemeninGirdigiKasa_kasaAdi
            // 
            odemeninGirdigiKasa_kasaAdi.HeaderText = "Ödeme Giriş Kasa";
            odemeninGirdigiKasa_kasaAdi.Name = "odemeninGirdigiKasa_kasaAdi";
            odemeninGirdigiKasa_kasaAdi.ReadOnly = true;
            // 
            // odemeYapilanCariKart_cariKartId
            // 
            odemeYapilanCariKart_cariKartId.HeaderText = "odemeYapilanCariKart_cariKartId";
            odemeYapilanCariKart_cariKartId.Name = "odemeYapilanCariKart_cariKartId";
            odemeYapilanCariKart_cariKartId.ReadOnly = true;
            odemeYapilanCariKart_cariKartId.Visible = false;
            // 
            // odemeYapilanCariKart_cariAdi
            // 
            odemeYapilanCariKart_cariAdi.HeaderText = "Cari Adı";
            odemeYapilanCariKart_cariAdi.Name = "odemeYapilanCariKart_cariAdi";
            odemeYapilanCariKart_cariAdi.ReadOnly = true;
            // 
            // projeKod_projeKodId
            // 
            projeKod_projeKodId.HeaderText = "projeKod_projeKodId";
            projeKod_projeKodId.Name = "projeKod_projeKodId";
            projeKod_projeKodId.ReadOnly = true;
            projeKod_projeKodId.Visible = false;
            // 
            // projeKod_projeKodString
            // 
            projeKod_projeKodString.HeaderText = "Proje Kodu";
            projeKod_projeKodString.Name = "projeKod_projeKodString";
            projeKod_projeKodString.ReadOnly = true;
            // 
            // odemeTanimi_odemeTanimiId
            // 
            odemeTanimi_odemeTanimiId.HeaderText = "odemeTanimiId";
            odemeTanimi_odemeTanimiId.Name = "odemeTanimi_odemeTanimiId";
            odemeTanimi_odemeTanimiId.ReadOnly = true;
            odemeTanimi_odemeTanimiId.Visible = false;
            // 
            // odemeTanimi_odemeTanimi
            // 
            odemeTanimi_odemeTanimi.HeaderText = "Ödeme Tanımı";
            odemeTanimi_odemeTanimi.Name = "odemeTanimi_odemeTanimi";
            odemeTanimi_odemeTanimi.ReadOnly = true;
            // 
            // aciklama
            // 
            aciklama.HeaderText = "açıklama";
            aciklama.Name = "aciklama";
            aciklama.ReadOnly = true;
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
            // 
            // Sil
            // 
            Sil.HeaderText = "Sİl";
            Sil.Image = Properties.Resources.delete_icon;
            Sil.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
            Sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Sil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CariOdemelerGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1083, 755);
            Controls.Add(panelFooter);
            Controls.Add(panelFilter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "CariOdemelerGridForm";
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
        private CustomControls.RoundedButton buttonClose;
        private System.Windows.Forms.Button buttonTumKaytilariGetir;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton buttonCikis;
        private CustomControls.RoundedButton roundedButton2;
        private CustomControls.RoundedButton buttonMinimize;
        private CustomControls.RoundedIconButton buttonKayitEkle;
        private CustomControls.RoundedIconButton buttonTumKayitlariGetir;
        private CustomControls.RoundedIconButton buttonFiltre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariOdemeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariKart_cariKartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariKart_cariAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_dovizCinsi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar_dovizCinsi_sembol;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahsupEdilenTutar_tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahsupEdilenTutar_dovizCinsi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahsupEdilenTutar_dovizCinsi_sembol;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeYonu;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeSekli;
        private System.Windows.Forms.DataGridViewTextBoxColumn cek_cekId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cek_cekNumarasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn krediKarti_krediKartiId;
        private System.Windows.Forms.DataGridViewTextBoxColumn krediKarti_kartSahibi;
        private System.Windows.Forms.DataGridViewTextBoxColumn taksitOdemesi_taksitOdemesiId;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeninCiktigiKasa_kasaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeninCiktigiKasa_kasaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeninGirdigiKasa_kasaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeninGirdigiKasa_kasaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeYapilanCariKart_cariKartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeYapilanCariKart_cariAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn projeKod_projeKodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn projeKod_projeKodString;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeTanimi_odemeTanimiId;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeTanimi_odemeTanimi;
        private System.Windows.Forms.DataGridViewTextBoxColumn aciklama;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}