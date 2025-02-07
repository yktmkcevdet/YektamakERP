namespace YektamakDesktop.Formlar.Finans
{
    partial class TaksitliOdemeKayitFormu
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
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            customTextBoxOdemeTanimi = new CustomControls.CustomTextBox();
            labelProjeKodu = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            customComboListBoxCariId = new CustomControls.CustomComboListBox();
            radioButtonKrediTaksidi = new CustomControls.CustomRadioButton();
            radioButtonKrediKartiTaksidi = new CustomControls.CustomRadioButton();
            customTextBoxTaksitTutari = new CustomControls.CustomTextBox();
            customTextBoxAciklama = new CustomControls.CustomTextBox();
            customComboListBoxTaksitDovizId = new CustomControls.CustomComboListBox();
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            rButtonTaksitEkle = new CustomControls.RoundedButton();
            rButtonOtomatikTaksitlendir = new CustomControls.RoundedButton();
            dataGridViewTaksitOdemesi = new System.Windows.Forms.DataGridView();
            taksitOdemesiId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            taksitliOdemeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            taksitNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            sonOdemeTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dovizId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dovizSembol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odemeGerceklesenTarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            odendiMi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            rButtonKapat = new CustomControls.RoundedButton();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            customComboListBoxToplamTutarDovizId = new CustomControls.CustomComboListBox();
            rButtonGuncelle = new CustomControls.RoundedButton();
            rButtonKaydet = new CustomControls.RoundedButton();
            labelUyariOdemeTanimi = new System.Windows.Forms.Label();
            labelUyariCariId = new System.Windows.Forms.Label();
            labelUyariToplamTutar = new System.Windows.Forms.Label();
            labelUyariTaksitliOdemeTuru = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            labelUyariIslemTarihi = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            customTextBoxIslemTarihi = new CustomControls.CustomTextBoxTarih();
            customTextBoxSonOdemeTarihi = new CustomControls.CustomTextBoxTarih();
            customTextBoxToplamTutar = new CustomControls.CustomTextBoxSayisal();
            customTextBoxGirilenTaksitToplami = new CustomControls.CustomTextBoxSayisal();
            customTextBoxGirilecekTaksitToplami = new CustomControls.CustomTextBoxSayisal();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTaksitOdemesi).BeginInit();
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
            panelHeader.Size = new System.Drawing.Size(1016, 56);
            panelHeader.TabIndex = 2;
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
            buttonClose.Location = new System.Drawing.Point(967, 9);
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
            buttonHelp.Location = new System.Drawing.Point(887, 9);
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
            buttomMinimize.Location = new System.Drawing.Point(927, 9);
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
            labelHeader.Size = new System.Drawing.Size(218, 30);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Taksitli İşlem Oluştur";
            // 
            // customTextBoxOdemeTanimi
            // 
            customTextBoxOdemeTanimi.BackColor = System.Drawing.Color.White;
            customTextBoxOdemeTanimi.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxOdemeTanimi.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxOdemeTanimi.BorderRadius = 0;
            customTextBoxOdemeTanimi.BorderSize = 2;
            customTextBoxOdemeTanimi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxOdemeTanimi.ForeColor = System.Drawing.Color.Black;
            customTextBoxOdemeTanimi.isPlaceHolder = false;
            customTextBoxOdemeTanimi.Location = new System.Drawing.Point(226, 90);
            customTextBoxOdemeTanimi.Multiline = false;
            customTextBoxOdemeTanimi.Name = "customTextBoxOdemeTanimi";
            customTextBoxOdemeTanimi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxOdemeTanimi.PasswordChar = false;
            customTextBoxOdemeTanimi.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxOdemeTanimi.PlaceholderText = "";
            customTextBoxOdemeTanimi.ReadOnly = false;
            customTextBoxOdemeTanimi.SelectionStart = 0;
            customTextBoxOdemeTanimi.Size = new System.Drawing.Size(250, 32);
            customTextBoxOdemeTanimi.TabIndex = 3;
            customTextBoxOdemeTanimi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxOdemeTanimi.TextCustom = "";
            customTextBoxOdemeTanimi.UnderlinedStyle = false;
            // 
            // labelProjeKodu
            // 
            labelProjeKodu.AutoSize = true;
            labelProjeKodu.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelProjeKodu.Location = new System.Drawing.Point(27, 90);
            labelProjeKodu.Name = "labelProjeKodu";
            labelProjeKodu.Size = new System.Drawing.Size(151, 30);
            labelProjeKodu.TabIndex = 43;
            labelProjeKodu.Text = "Ödeme Tanımı";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label11.Location = new System.Drawing.Point(200, 92);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(18, 30);
            label11.TabIndex = 61;
            label11.Text = ":";
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(200, 126);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(18, 30);
            label2.TabIndex = 64;
            label2.Text = ":";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(27, 126);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 30);
            label3.TabIndex = 63;
            label3.Text = "Firma";
            // 
            // customComboListBoxCariId
            // 
            customComboListBoxCariId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxCariId.ListBoxVisualSize = 5;
            customComboListBoxCariId.Location = new System.Drawing.Point(226, 126);
            customComboListBoxCariId.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxCariId.Name = "customComboListBoxCariId";
            customComboListBoxCariId.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxCariId.Size = new System.Drawing.Size(380, 36);
            customComboListBoxCariId.TabIndex = 62;
            // 
            // radioButtonKrediTaksidi
            // 
            radioButtonKrediTaksidi.AutoSize = true;
            radioButtonKrediTaksidi.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            radioButtonKrediTaksidi.Location = new System.Drawing.Point(179, 62);
            radioButtonKrediTaksidi.MinimumSize = new System.Drawing.Size(0, 21);
            radioButtonKrediTaksidi.Name = "radioButtonKrediTaksidi";
            radioButtonKrediTaksidi.Size = new System.Drawing.Size(102, 21);
            radioButtonKrediTaksidi.TabIndex = 65;
            radioButtonKrediTaksidi.TabStop = true;
            radioButtonKrediTaksidi.Text = "Kredi Taksidi";
            radioButtonKrediTaksidi.UnCheckedColor = System.Drawing.Color.Gray;
            radioButtonKrediTaksidi.UseVisualStyleBackColor = true;
            // 
            // radioButtonKrediKartiTaksidi
            // 
            radioButtonKrediKartiTaksidi.AutoSize = true;
            radioButtonKrediKartiTaksidi.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            radioButtonKrediKartiTaksidi.Location = new System.Drawing.Point(27, 62);
            radioButtonKrediKartiTaksidi.MinimumSize = new System.Drawing.Size(0, 21);
            radioButtonKrediKartiTaksidi.Name = "radioButtonKrediKartiTaksidi";
            radioButtonKrediKartiTaksidi.Size = new System.Drawing.Size(129, 21);
            radioButtonKrediKartiTaksidi.TabIndex = 66;
            radioButtonKrediKartiTaksidi.TabStop = true;
            radioButtonKrediKartiTaksidi.Text = "Kredi Kartı Taksidi";
            radioButtonKrediKartiTaksidi.UnCheckedColor = System.Drawing.Color.Gray;
            radioButtonKrediKartiTaksidi.UseVisualStyleBackColor = true;
            // 
            // customTextBoxTaksitTutari
            // 
            customTextBoxTaksitTutari.BackColor = System.Drawing.Color.White;
            customTextBoxTaksitTutari.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxTaksitTutari.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxTaksitTutari.BorderRadius = 0;
            customTextBoxTaksitTutari.BorderSize = 2;
            customTextBoxTaksitTutari.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxTaksitTutari.ForeColor = System.Drawing.Color.Black;
            customTextBoxTaksitTutari.isPlaceHolder = false;
            customTextBoxTaksitTutari.Location = new System.Drawing.Point(133, 269);
            customTextBoxTaksitTutari.Multiline = false;
            customTextBoxTaksitTutari.Name = "customTextBoxTaksitTutari";
            customTextBoxTaksitTutari.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxTaksitTutari.PasswordChar = false;
            customTextBoxTaksitTutari.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxTaksitTutari.PlaceholderText = "";
            customTextBoxTaksitTutari.ReadOnly = false;
            customTextBoxTaksitTutari.SelectionStart = 0;
            customTextBoxTaksitTutari.Size = new System.Drawing.Size(114, 32);
            customTextBoxTaksitTutari.TabIndex = 68;
            customTextBoxTaksitTutari.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxTaksitTutari.TextCustom = "";
            customTextBoxTaksitTutari.UnderlinedStyle = false;
            // 
            // customTextBoxAciklama
            // 
            customTextBoxAciklama.BackColor = System.Drawing.Color.White;
            customTextBoxAciklama.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxAciklama.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxAciklama.BorderRadius = 0;
            customTextBoxAciklama.BorderSize = 2;
            customTextBoxAciklama.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxAciklama.ForeColor = System.Drawing.Color.Black;
            customTextBoxAciklama.isPlaceHolder = false;
            customTextBoxAciklama.Location = new System.Drawing.Point(318, 269);
            customTextBoxAciklama.Multiline = false;
            customTextBoxAciklama.Name = "customTextBoxAciklama";
            customTextBoxAciklama.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxAciklama.PasswordChar = false;
            customTextBoxAciklama.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxAciklama.PlaceholderText = "";
            customTextBoxAciklama.ReadOnly = false;
            customTextBoxAciklama.SelectionStart = 0;
            customTextBoxAciklama.Size = new System.Drawing.Size(226, 32);
            customTextBoxAciklama.TabIndex = 69;
            customTextBoxAciklama.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxAciklama.TextCustom = "";
            customTextBoxAciklama.UnderlinedStyle = false;
            // 
            // customComboListBoxTaksitDovizId
            // 
            customComboListBoxTaksitDovizId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxTaksitDovizId.ListBoxVisualSize = 5;
            customComboListBoxTaksitDovizId.Location = new System.Drawing.Point(251, 271);
            customComboListBoxTaksitDovizId.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxTaksitDovizId.Name = "customComboListBoxTaksitDovizId";
            customComboListBoxTaksitDovizId.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxTaksitDovizId.Size = new System.Drawing.Size(59, 36);
            customComboListBoxTaksitDovizId.TabIndex = 70;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(31, 246);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(37, 17);
            label1.TabIndex = 71;
            label1.Text = "Vade";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(133, 246);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(39, 17);
            label4.TabIndex = 72;
            label4.Text = "Tutar";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(318, 246);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(62, 17);
            label5.TabIndex = 73;
            label5.Text = "Açıklama";
            // 
            // rButtonTaksitEkle
            // 
            rButtonTaksitEkle.BackColor = System.Drawing.Color.Olive;
            rButtonTaksitEkle.BackgroundColor = System.Drawing.Color.Olive;
            rButtonTaksitEkle.BorderColor = System.Drawing.Color.LimeGreen;
            rButtonTaksitEkle.BorderRadius = 20;
            rButtonTaksitEkle.BorderSize = 2;
            rButtonTaksitEkle.FlatAppearance.BorderSize = 0;
            rButtonTaksitEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonTaksitEkle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonTaksitEkle.ForeColor = System.Drawing.Color.White;
            rButtonTaksitEkle.Location = new System.Drawing.Point(563, 261);
            rButtonTaksitEkle.Name = "rButtonTaksitEkle";
            rButtonTaksitEkle.Size = new System.Drawing.Size(90, 40);
            rButtonTaksitEkle.TabIndex = 74;
            rButtonTaksitEkle.Text = "Taksit Ekle";
            rButtonTaksitEkle.TextColor = System.Drawing.Color.White;
            rButtonTaksitEkle.UseVisualStyleBackColor = false;
            rButtonTaksitEkle.Click += rButtonTaksitEkle_Click;
            // 
            // rButtonOtomatikTaksitlendir
            // 
            rButtonOtomatikTaksitlendir.BackColor = System.Drawing.Color.Olive;
            rButtonOtomatikTaksitlendir.BackgroundColor = System.Drawing.Color.Olive;
            rButtonOtomatikTaksitlendir.BorderColor = System.Drawing.Color.LimeGreen;
            rButtonOtomatikTaksitlendir.BorderRadius = 20;
            rButtonOtomatikTaksitlendir.BorderSize = 2;
            rButtonOtomatikTaksitlendir.FlatAppearance.BorderSize = 0;
            rButtonOtomatikTaksitlendir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonOtomatikTaksitlendir.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonOtomatikTaksitlendir.ForeColor = System.Drawing.Color.White;
            rButtonOtomatikTaksitlendir.Location = new System.Drawing.Point(768, 261);
            rButtonOtomatikTaksitlendir.Name = "rButtonOtomatikTaksitlendir";
            rButtonOtomatikTaksitlendir.Size = new System.Drawing.Size(150, 40);
            rButtonOtomatikTaksitlendir.TabIndex = 75;
            rButtonOtomatikTaksitlendir.Text = "Otomatik Taksitlendir";
            rButtonOtomatikTaksitlendir.TextColor = System.Drawing.Color.White;
            rButtonOtomatikTaksitlendir.UseVisualStyleBackColor = false;
            rButtonOtomatikTaksitlendir.Click += rButtonOtomatikTaksitlendir_Click;
            // 
            // dataGridViewTaksitOdemesi
            // 
            dataGridViewTaksitOdemesi.AllowUserToAddRows = false;
            dataGridViewTaksitOdemesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTaksitOdemesi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { taksitOdemesiId, taksitliOdemeId, taksitNo, sonOdemeTarihi, tutar, dovizId, dovizSembol, aciklama, odemeGerceklesenTarih, odendiMi });
            dataGridViewTaksitOdemesi.Location = new System.Drawing.Point(26, 307);
            dataGridViewTaksitOdemesi.Name = "dataGridViewTaksitOdemesi";
            dataGridViewTaksitOdemesi.ReadOnly = true;
            dataGridViewTaksitOdemesi.RowTemplate.Height = 25;
            dataGridViewTaksitOdemesi.Size = new System.Drawing.Size(967, 551);
            dataGridViewTaksitOdemesi.TabIndex = 76;
            dataGridViewTaksitOdemesi.RowsAdded += dataGridViewTaksitOdemesi_RowsAdded;
            dataGridViewTaksitOdemesi.RowsRemoved += dataGridViewTaksitOdemesi_RowsRemoved;
            // 
            // taksitOdemesiId
            // 
            taksitOdemesiId.HeaderText = "TaksitOdemesiId";
            taksitOdemesiId.Name = "taksitOdemesiId";
            taksitOdemesiId.ReadOnly = true;
            taksitOdemesiId.Visible = false;
            // 
            // taksitliOdemeId
            // 
            taksitliOdemeId.HeaderText = "TaksitliOdemeId";
            taksitliOdemeId.Name = "taksitliOdemeId";
            taksitliOdemeId.ReadOnly = true;
            taksitliOdemeId.Visible = false;
            // 
            // taksitNo
            // 
            taksitNo.HeaderText = "Taksit No";
            taksitNo.Name = "taksitNo";
            taksitNo.ReadOnly = true;
            taksitNo.Width = 50;
            // 
            // sonOdemeTarihi
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            sonOdemeTarihi.DefaultCellStyle = dataGridViewCellStyle1;
            sonOdemeTarihi.HeaderText = "Vade";
            sonOdemeTarihi.Name = "sonOdemeTarihi";
            sonOdemeTarihi.ReadOnly = true;
            // 
            // tutar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            tutar.DefaultCellStyle = dataGridViewCellStyle2;
            tutar.HeaderText = "Tutar";
            tutar.Name = "tutar";
            tutar.ReadOnly = true;
            // 
            // dovizId
            // 
            dovizId.HeaderText = "DovizId";
            dovizId.Name = "dovizId";
            dovizId.ReadOnly = true;
            dovizId.Visible = false;
            // 
            // dovizSembol
            // 
            dovizSembol.HeaderText = "Döviz Birimi";
            dovizSembol.Name = "dovizSembol";
            dovizSembol.ReadOnly = true;
            dovizSembol.Width = 50;
            // 
            // aciklama
            // 
            aciklama.HeaderText = "Açıklama";
            aciklama.Name = "aciklama";
            aciklama.ReadOnly = true;
            aciklama.Width = 150;
            // 
            // odemeGerceklesenTarih
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            odemeGerceklesenTarih.DefaultCellStyle = dataGridViewCellStyle3;
            odemeGerceklesenTarih.HeaderText = "Ödeme Gerçekleşme Tarihi";
            odemeGerceklesenTarih.Name = "odemeGerceklesenTarih";
            odemeGerceklesenTarih.ReadOnly = true;
            // 
            // odendiMi
            // 
            odendiMi.HeaderText = "Ödendi Mi";
            odendiMi.Name = "odendiMi";
            odendiMi.ReadOnly = true;
            odendiMi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            odendiMi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            rButtonKapat.Location = new System.Drawing.Point(323, 901);
            rButtonKapat.Name = "rButtonKapat";
            rButtonKapat.Size = new System.Drawing.Size(152, 59);
            rButtonKapat.TabIndex = 77;
            rButtonKapat.Text = "KAPAT";
            rButtonKapat.TextColor = System.Drawing.Color.White;
            rButtonKapat.UseVisualStyleBackColor = false;
            rButtonKapat.Click += rButtonKapat_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(200, 167);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(18, 30);
            label6.TabIndex = 80;
            label6.Text = ":";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(27, 165);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(139, 30);
            label7.TabIndex = 79;
            label7.Text = "Toplam Tutar";
            // 
            // customComboListBoxToplamTutarDovizId
            // 
            customComboListBoxToplamTutarDovizId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxToplamTutarDovizId.ListBoxVisualSize = 5;
            customComboListBoxToplamTutarDovizId.Location = new System.Drawing.Point(366, 164);
            customComboListBoxToplamTutarDovizId.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxToplamTutarDovizId.Name = "customComboListBoxToplamTutarDovizId";
            customComboListBoxToplamTutarDovizId.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxToplamTutarDovizId.Size = new System.Drawing.Size(65, 36);
            customComboListBoxToplamTutarDovizId.TabIndex = 81;
            // 
            // rButtonGuncelle
            // 
            rButtonGuncelle.BackColor = System.Drawing.Color.CornflowerBlue;
            rButtonGuncelle.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            rButtonGuncelle.BorderColor = System.Drawing.Color.RoyalBlue;
            rButtonGuncelle.BorderRadius = 40;
            rButtonGuncelle.BorderSize = 5;
            rButtonGuncelle.FlatAppearance.BorderSize = 0;
            rButtonGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonGuncelle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonGuncelle.ForeColor = System.Drawing.Color.White;
            rButtonGuncelle.Location = new System.Drawing.Point(49, 901);
            rButtonGuncelle.Name = "rButtonGuncelle";
            rButtonGuncelle.Size = new System.Drawing.Size(152, 59);
            rButtonGuncelle.TabIndex = 82;
            rButtonGuncelle.Text = "GÜNCELLE";
            rButtonGuncelle.TextColor = System.Drawing.Color.White;
            rButtonGuncelle.UseVisualStyleBackColor = false;
            // 
            // rButtonKaydet
            // 
            rButtonKaydet.BackColor = System.Drawing.Color.LimeGreen;
            rButtonKaydet.BackgroundColor = System.Drawing.Color.LimeGreen;
            rButtonKaydet.BorderColor = System.Drawing.Color.MediumSeaGreen;
            rButtonKaydet.BorderRadius = 40;
            rButtonKaydet.BorderSize = 5;
            rButtonKaydet.FlatAppearance.BorderSize = 0;
            rButtonKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonKaydet.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonKaydet.ForeColor = System.Drawing.Color.White;
            rButtonKaydet.Location = new System.Drawing.Point(49, 901);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new System.Drawing.Size(152, 59);
            rButtonKaydet.TabIndex = 83;
            rButtonKaydet.Text = "KAYDET";
            rButtonKaydet.TextColor = System.Drawing.Color.White;
            rButtonKaydet.UseVisualStyleBackColor = false;
            rButtonKaydet.Click += rButtonKaydet_Click;
            // 
            // labelUyariOdemeTanimi
            // 
            labelUyariOdemeTanimi.AutoSize = true;
            labelUyariOdemeTanimi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariOdemeTanimi.ForeColor = System.Drawing.Color.Red;
            labelUyariOdemeTanimi.Location = new System.Drawing.Point(482, 97);
            labelUyariOdemeTanimi.Name = "labelUyariOdemeTanimi";
            labelUyariOdemeTanimi.Size = new System.Drawing.Size(0, 15);
            labelUyariOdemeTanimi.TabIndex = 84;
            // 
            // labelUyariCariId
            // 
            labelUyariCariId.AutoSize = true;
            labelUyariCariId.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariCariId.ForeColor = System.Drawing.Color.Red;
            labelUyariCariId.Location = new System.Drawing.Point(482, 135);
            labelUyariCariId.Name = "labelUyariCariId";
            labelUyariCariId.Size = new System.Drawing.Size(0, 15);
            labelUyariCariId.TabIndex = 85;
            // 
            // labelUyariToplamTutar
            // 
            labelUyariToplamTutar.AutoSize = true;
            labelUyariToplamTutar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariToplamTutar.ForeColor = System.Drawing.Color.Red;
            labelUyariToplamTutar.Location = new System.Drawing.Point(435, 177);
            labelUyariToplamTutar.Name = "labelUyariToplamTutar";
            labelUyariToplamTutar.Size = new System.Drawing.Size(0, 15);
            labelUyariToplamTutar.TabIndex = 86;
            // 
            // labelUyariTaksitliOdemeTuru
            // 
            labelUyariTaksitliOdemeTuru.AutoSize = true;
            labelUyariTaksitliOdemeTuru.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariTaksitliOdemeTuru.ForeColor = System.Drawing.Color.Red;
            labelUyariTaksitliOdemeTuru.Location = new System.Drawing.Point(293, 65);
            labelUyariTaksitliOdemeTuru.Name = "labelUyariTaksitliOdemeTuru";
            labelUyariTaksitliOdemeTuru.Size = new System.Drawing.Size(0, 15);
            labelUyariTaksitliOdemeTuru.TabIndex = 87;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label17.Location = new System.Drawing.Point(200, 206);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(18, 30);
            label17.TabIndex = 104;
            label17.Text = ":";
            label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label18.Location = new System.Drawing.Point(27, 204);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(120, 30);
            label18.TabIndex = 103;
            label18.Text = "İşlem Tarihi";
            // 
            // labelUyariIslemTarihi
            // 
            labelUyariIslemTarihi.AutoSize = true;
            labelUyariIslemTarihi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariIslemTarihi.ForeColor = System.Drawing.Color.Red;
            labelUyariIslemTarihi.Location = new System.Drawing.Point(369, 218);
            labelUyariIslemTarihi.Name = "labelUyariIslemTarihi";
            labelUyariIslemTarihi.Size = new System.Drawing.Size(0, 15);
            labelUyariIslemTarihi.TabIndex = 105;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label19.Location = new System.Drawing.Point(49, 871);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(135, 17);
            label19.TabIndex = 107;
            label19.Text = "Girilen Taksit Toplamı";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label20.Location = new System.Drawing.Point(358, 871);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(147, 17);
            label20.TabIndex = 109;
            label20.Text = "Girilecek Taksit Toplamı";
            // 
            // customTextBoxIslemTarihi
            // 
            customTextBoxIslemTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customTextBoxIslemTarihi.Location = new System.Drawing.Point(226, 206);
            customTextBoxIslemTarihi.Margin = new System.Windows.Forms.Padding(1);
            customTextBoxIslemTarihi.Name = "customTextBoxIslemTarihi";
            customTextBoxIslemTarihi.Padding = new System.Windows.Forms.Padding(1);
            customTextBoxIslemTarihi.Size = new System.Drawing.Size(103, 30);
            customTextBoxIslemTarihi.TabIndex = 110;
            customTextBoxIslemTarihi.TextCustom = "";
            // 
            // customTextBoxSonOdemeTarihi
            // 
            customTextBoxSonOdemeTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customTextBoxSonOdemeTarihi.Location = new System.Drawing.Point(27, 271);
            customTextBoxSonOdemeTarihi.Margin = new System.Windows.Forms.Padding(1);
            customTextBoxSonOdemeTarihi.Name = "customTextBoxSonOdemeTarihi";
            customTextBoxSonOdemeTarihi.Padding = new System.Windows.Forms.Padding(1);
            customTextBoxSonOdemeTarihi.Size = new System.Drawing.Size(104, 29);
            customTextBoxSonOdemeTarihi.TabIndex = 111;
            customTextBoxSonOdemeTarihi.TextCustom = "";
            // 
            // customTextBoxToplamTutar
            // 
            customTextBoxToplamTutar.BackColor = System.Drawing.Color.White;
            customTextBoxToplamTutar.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxToplamTutar.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxToplamTutar.BorderRadius = 0;
            customTextBoxToplamTutar.BorderSize = 2;
            customTextBoxToplamTutar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxToplamTutar.ForeColor = System.Drawing.Color.Black;
            customTextBoxToplamTutar.Location = new System.Drawing.Point(224, 165);
            customTextBoxToplamTutar.Multiline = false;
            customTextBoxToplamTutar.Name = "customTextBoxToplamTutar";
            customTextBoxToplamTutar.OndalikBasamak = 2;
            customTextBoxToplamTutar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxToplamTutar.PasswordChar = false;
            customTextBoxToplamTutar.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxToplamTutar.PlaceholderText = "";
            customTextBoxToplamTutar.ReadOnly = false;
            customTextBoxToplamTutar.SelectionStart = 0;
            customTextBoxToplamTutar.Size = new System.Drawing.Size(138, 32);
            customTextBoxToplamTutar.TabIndex = 112;
            customTextBoxToplamTutar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            customTextBoxToplamTutar.TextCustom = "0,00";
            customTextBoxToplamTutar.UnderlinedStyle = false;
            // 
            // customTextBoxGirilenTaksitToplami
            // 
            customTextBoxGirilenTaksitToplami.BackColor = System.Drawing.Color.WhiteSmoke;
            customTextBoxGirilenTaksitToplami.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxGirilenTaksitToplami.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxGirilenTaksitToplami.BorderRadius = 0;
            customTextBoxGirilenTaksitToplami.BorderSize = 2;
            customTextBoxGirilenTaksitToplami.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxGirilenTaksitToplami.ForeColor = System.Drawing.Color.Black;
            customTextBoxGirilenTaksitToplami.Location = new System.Drawing.Point(190, 864);
            customTextBoxGirilenTaksitToplami.Multiline = false;
            customTextBoxGirilenTaksitToplami.Name = "customTextBoxGirilenTaksitToplami";
            customTextBoxGirilenTaksitToplami.OndalikBasamak = 2;
            customTextBoxGirilenTaksitToplami.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxGirilenTaksitToplami.PasswordChar = false;
            customTextBoxGirilenTaksitToplami.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxGirilenTaksitToplami.PlaceholderText = "";
            customTextBoxGirilenTaksitToplami.ReadOnly = true;
            customTextBoxGirilenTaksitToplami.SelectionStart = 0;
            customTextBoxGirilenTaksitToplami.Size = new System.Drawing.Size(103, 32);
            customTextBoxGirilenTaksitToplami.TabIndex = 113;
            customTextBoxGirilenTaksitToplami.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            customTextBoxGirilenTaksitToplami.TextCustom = "0,00";
            customTextBoxGirilenTaksitToplami.UnderlinedStyle = false;
            customTextBoxGirilenTaksitToplami.TextChanged += customTextBoxGirilenTaksitToplami_TextChanged;
            // 
            // customTextBoxGirilecekTaksitToplami
            // 
            customTextBoxGirilecekTaksitToplami.BackColor = System.Drawing.Color.WhiteSmoke;
            customTextBoxGirilecekTaksitToplami.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxGirilecekTaksitToplami.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxGirilecekTaksitToplami.BorderRadius = 0;
            customTextBoxGirilecekTaksitToplami.BorderSize = 2;
            customTextBoxGirilecekTaksitToplami.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxGirilecekTaksitToplami.ForeColor = System.Drawing.Color.Black;
            customTextBoxGirilecekTaksitToplami.Location = new System.Drawing.Point(511, 864);
            customTextBoxGirilecekTaksitToplami.Multiline = false;
            customTextBoxGirilecekTaksitToplami.Name = "customTextBoxGirilecekTaksitToplami";
            customTextBoxGirilecekTaksitToplami.OndalikBasamak = 2;
            customTextBoxGirilecekTaksitToplami.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxGirilecekTaksitToplami.PasswordChar = false;
            customTextBoxGirilecekTaksitToplami.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxGirilecekTaksitToplami.PlaceholderText = "";
            customTextBoxGirilecekTaksitToplami.ReadOnly = true;
            customTextBoxGirilecekTaksitToplami.SelectionStart = 0;
            customTextBoxGirilecekTaksitToplami.Size = new System.Drawing.Size(108, 32);
            customTextBoxGirilecekTaksitToplami.TabIndex = 114;
            customTextBoxGirilecekTaksitToplami.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            customTextBoxGirilecekTaksitToplami.TextCustom = "0,00";
            customTextBoxGirilecekTaksitToplami.UnderlinedStyle = false;
            // 
            // TaksitliOdemeKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1014, 972);
            Controls.Add(customTextBoxGirilecekTaksitToplami);
            Controls.Add(customTextBoxGirilenTaksitToplami);
            Controls.Add(customTextBoxToplamTutar);
            Controls.Add(customTextBoxSonOdemeTarihi);
            Controls.Add(customTextBoxIslemTarihi);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(labelUyariIslemTarihi);
            Controls.Add(label17);
            Controls.Add(label18);
            Controls.Add(label1);
            Controls.Add(customTextBoxTaksitTutari);
            Controls.Add(label4);
            Controls.Add(customComboListBoxTaksitDovizId);
            Controls.Add(customTextBoxAciklama);
            Controls.Add(label5);
            Controls.Add(rButtonTaksitEkle);
            Controls.Add(labelUyariTaksitliOdemeTuru);
            Controls.Add(labelUyariToplamTutar);
            Controls.Add(labelUyariCariId);
            Controls.Add(labelUyariOdemeTanimi);
            Controls.Add(rButtonKaydet);
            Controls.Add(rButtonGuncelle);
            Controls.Add(customComboListBoxToplamTutarDovizId);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(rButtonKapat);
            Controls.Add(dataGridViewTaksitOdemesi);
            Controls.Add(rButtonOtomatikTaksitlendir);
            Controls.Add(radioButtonKrediKartiTaksidi);
            Controls.Add(radioButtonKrediTaksidi);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(customComboListBoxCariId);
            Controls.Add(label11);
            Controls.Add(labelProjeKodu);
            Controls.Add(customTextBoxOdemeTanimi);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "TaksitliOdemeKayitFormu";
            Text = "TaksitliIslemKayitFormu";
            Load += TaksitliIslemKayitFormu_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTaksitOdemesi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.CustomTextBox customTextBoxOdemeTanimi;
        private System.Windows.Forms.Label labelProjeKodu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomControls.CustomComboListBox customComboListBoxCariId;
        private CustomControls.CustomRadioButton radioButtonKrediTaksidi;
        private CustomControls.CustomRadioButton radioButtonKrediKartiTaksidi;
        private CustomControls.CustomTextBox customTextBoxTaksitTutari;
        private CustomControls.CustomTextBox customTextBoxAciklama;
        private CustomControls.CustomComboListBox customComboListBoxTaksitDovizId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewTaksitOdemesi;
        private CustomControls.RoundedButton rButtonKapat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CustomControls.CustomComboListBox customComboListBoxToplamTutarDovizId;
        private CustomControls.RoundedButton rButtonGuncelle;
        private CustomControls.RoundedButton rButtonKaydet;
        private System.Windows.Forms.Label labelUyariOdemeTanimi;
        private System.Windows.Forms.Label labelUyariCariId;
        private System.Windows.Forms.Label labelUyariToplamTutar;
        private System.Windows.Forms.Label labelUyariTaksitliOdemeTuru;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label labelUyariIslemTarihi;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridViewTextBoxColumn taksitOdemesiId;
        private System.Windows.Forms.DataGridViewTextBoxColumn taksitliOdemeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn taksitNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sonOdemeTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dovizId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dovizSembol;
        private System.Windows.Forms.DataGridViewTextBoxColumn aciklama;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeGerceklesenTarih;
        private System.Windows.Forms.DataGridViewCheckBoxColumn odendiMi;
        private CustomControls.RoundedButton rButtonTaksitEkle;
        private CustomControls.RoundedButton rButtonOtomatikTaksitlendir;
        private CustomControls.CustomTextBoxTarih customTextBoxIslemTarihi;
        private CustomControls.CustomTextBoxTarih customTextBoxSonOdemeTarihi;
        private CustomControls.CustomTextBoxSayisal customTextBoxToplamTutar;
        private CustomControls.CustomTextBoxSayisal customTextBoxGirilenTaksitToplami;
        private CustomControls.CustomTextBoxSayisal customTextBoxGirilecekTaksitToplami;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
    }
}