namespace YektamakDesktop.Formlar.Yetkilendirme
{
    partial class KullaniciKayitFormu
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
            roundedButton3 = new CustomControls.RoundedButton();
            roundedButton2 = new CustomControls.RoundedButton();
            roundedButton1 = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            rButtonKullaniciKaydet = new CustomControls.RoundedButton();
            textBoxKullaniciAdi = new CustomControls.CustomTextBox();
            label2 = new System.Windows.Forms.Label();
            labelKullaniciAdi = new System.Windows.Forms.Label();
            customTextBoxSifre = new CustomControls.CustomTextBox();
            label1 = new System.Windows.Forms.Label();
            labelSifre = new System.Windows.Forms.Label();
            customTextBoxSifreTekrar = new CustomControls.CustomTextBox();
            label3 = new System.Windows.Forms.Label();
            labelSifreTekrar = new System.Windows.Forms.Label();
            comboListBoxRol = new CustomControls.CustomComboListBox();
            label7 = new System.Windows.Forms.Label();
            labelPersonel = new System.Windows.Forms.Label();
            comboListBoxPersonel = new CustomControls.CustomComboListBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            KullaniciId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            KullaniciAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            PersonelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            PersonelAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            RolId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            RolAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            buttonFiltre = new System.Windows.Forms.Button();
            labelUyariKulllaniciAdi = new System.Windows.Forms.Label();
            labelUyariSifre = new System.Windows.Forms.Label();
            labelUyariSifreTekrar = new System.Windows.Forms.Label();
            labelUyariPersonel = new System.Windows.Forms.Label();
            labelUyariRol = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            panelHeader.Size = new System.Drawing.Size(923, 56);
            panelHeader.TabIndex = 1;
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
            roundedButton3.Location = new System.Drawing.Point(876, 9);
            roundedButton3.Margin = new System.Windows.Forms.Padding(0);
            roundedButton3.Name = "roundedButton3";
            roundedButton3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton3.Size = new System.Drawing.Size(40, 38);
            roundedButton3.TabIndex = 97;
            roundedButton3.Text = "x";
            roundedButton3.TextColor = System.Drawing.Color.White;
            roundedButton3.UseVisualStyleBackColor = false;
            roundedButton3.Click += roundedButton3_Click;
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
            roundedButton2.Location = new System.Drawing.Point(796, 9);
            roundedButton2.Margin = new System.Windows.Forms.Padding(0);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton2.Size = new System.Drawing.Size(40, 38);
            roundedButton2.TabIndex = 96;
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
            roundedButton1.Location = new System.Drawing.Point(836, 9);
            roundedButton1.Margin = new System.Windows.Forms.Padding(0);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton1.Size = new System.Drawing.Size(40, 38);
            roundedButton1.TabIndex = 95;
            roundedButton1.Text = "-";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = System.Drawing.Color.Red;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(3, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(221, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Kullanıcı Kayıt formu";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rButtonKullaniciKaydet
            // 
            rButtonKullaniciKaydet.BackColor = System.Drawing.Color.LimeGreen;
            rButtonKullaniciKaydet.BackgroundColor = System.Drawing.Color.LimeGreen;
            rButtonKullaniciKaydet.BorderColor = System.Drawing.Color.MediumSeaGreen;
            rButtonKullaniciKaydet.BorderRadius = 40;
            rButtonKullaniciKaydet.BorderSize = 5;
            rButtonKullaniciKaydet.FlatAppearance.BorderSize = 0;
            rButtonKullaniciKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonKullaniciKaydet.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonKullaniciKaydet.ForeColor = System.Drawing.Color.White;
            rButtonKullaniciKaydet.Location = new System.Drawing.Point(403, 285);
            rButtonKullaniciKaydet.Name = "rButtonKullaniciKaydet";
            rButtonKullaniciKaydet.Size = new System.Drawing.Size(150, 66);
            rButtonKullaniciKaydet.TabIndex = 24;
            rButtonKullaniciKaydet.Text = "KAYDET";
            rButtonKullaniciKaydet.TextColor = System.Drawing.Color.White;
            rButtonKullaniciKaydet.UseVisualStyleBackColor = false;
            rButtonKullaniciKaydet.Click += rButtonKullaniciKaydet_Click;
            // 
            // textBoxKullaniciAdi
            // 
            textBoxKullaniciAdi.BackColor = System.Drawing.Color.White;
            textBoxKullaniciAdi.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxKullaniciAdi.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxKullaniciAdi.BorderRadius = 0;
            textBoxKullaniciAdi.BorderSize = 2;
            textBoxKullaniciAdi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxKullaniciAdi.ForeColor = System.Drawing.Color.Black;
            textBoxKullaniciAdi.isPlaceHolder = false;
            textBoxKullaniciAdi.Location = new System.Drawing.Point(296, 81);
            textBoxKullaniciAdi.Multiline = false;
            textBoxKullaniciAdi.Name = "textBoxKullaniciAdi";
            textBoxKullaniciAdi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxKullaniciAdi.PasswordChar = false;
            textBoxKullaniciAdi.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxKullaniciAdi.PlaceholderText = "";
            textBoxKullaniciAdi.ReadOnly = false;
            textBoxKullaniciAdi.SelectionStart = 0;
            textBoxKullaniciAdi.Size = new System.Drawing.Size(268, 32);
            textBoxKullaniciAdi.TabIndex = 27;
            textBoxKullaniciAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxKullaniciAdi.TextCustom = "";
            textBoxKullaniciAdi.UnderlinedStyle = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(272, 82);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(18, 30);
            label2.TabIndex = 26;
            label2.Text = ":";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelKullaniciAdi
            // 
            labelKullaniciAdi.AutoSize = true;
            labelKullaniciAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelKullaniciAdi.Location = new System.Drawing.Point(6, 82);
            labelKullaniciAdi.Name = "labelKullaniciAdi";
            labelKullaniciAdi.Size = new System.Drawing.Size(129, 30);
            labelKullaniciAdi.TabIndex = 25;
            labelKullaniciAdi.Text = "Kullanıcı Adı";
            labelKullaniciAdi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customTextBoxSifre
            // 
            customTextBoxSifre.BackColor = System.Drawing.Color.White;
            customTextBoxSifre.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxSifre.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxSifre.BorderRadius = 0;
            customTextBoxSifre.BorderSize = 2;
            customTextBoxSifre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxSifre.ForeColor = System.Drawing.Color.Black;
            customTextBoxSifre.isPlaceHolder = false;
            customTextBoxSifre.Location = new System.Drawing.Point(296, 119);
            customTextBoxSifre.Multiline = false;
            customTextBoxSifre.Name = "customTextBoxSifre";
            customTextBoxSifre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxSifre.PasswordChar = true;
            customTextBoxSifre.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxSifre.PlaceholderText = "";
            customTextBoxSifre.ReadOnly = false;
            customTextBoxSifre.SelectionStart = 0;
            customTextBoxSifre.Size = new System.Drawing.Size(268, 32);
            customTextBoxSifre.TabIndex = 30;
            customTextBoxSifre.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxSifre.TextCustom = "";
            customTextBoxSifre.UnderlinedStyle = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(272, 120);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(18, 30);
            label1.TabIndex = 29;
            label1.Text = ":";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSifre
            // 
            labelSifre.AutoSize = true;
            labelSifre.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelSifre.Location = new System.Drawing.Point(6, 120);
            labelSifre.Name = "labelSifre";
            labelSifre.Size = new System.Drawing.Size(55, 30);
            labelSifre.TabIndex = 28;
            labelSifre.Text = "Şifre";
            labelSifre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customTextBoxSifreTekrar
            // 
            customTextBoxSifreTekrar.BackColor = System.Drawing.Color.White;
            customTextBoxSifreTekrar.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxSifreTekrar.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxSifreTekrar.BorderRadius = 0;
            customTextBoxSifreTekrar.BorderSize = 2;
            customTextBoxSifreTekrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxSifreTekrar.ForeColor = System.Drawing.Color.Black;
            customTextBoxSifreTekrar.isPlaceHolder = false;
            customTextBoxSifreTekrar.Location = new System.Drawing.Point(296, 155);
            customTextBoxSifreTekrar.Multiline = false;
            customTextBoxSifreTekrar.Name = "customTextBoxSifreTekrar";
            customTextBoxSifreTekrar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxSifreTekrar.PasswordChar = true;
            customTextBoxSifreTekrar.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxSifreTekrar.PlaceholderText = "";
            customTextBoxSifreTekrar.ReadOnly = false;
            customTextBoxSifreTekrar.SelectionStart = 0;
            customTextBoxSifreTekrar.Size = new System.Drawing.Size(268, 32);
            customTextBoxSifreTekrar.TabIndex = 33;
            customTextBoxSifreTekrar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxSifreTekrar.TextCustom = "";
            customTextBoxSifreTekrar.UnderlinedStyle = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(272, 156);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(18, 30);
            label3.TabIndex = 32;
            label3.Text = ":";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSifreTekrar
            // 
            labelSifreTekrar.AutoSize = true;
            labelSifreTekrar.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelSifreTekrar.Location = new System.Drawing.Point(6, 156);
            labelSifreTekrar.Name = "labelSifreTekrar";
            labelSifreTekrar.Size = new System.Drawing.Size(120, 30);
            labelSifreTekrar.TabIndex = 31;
            labelSifreTekrar.Text = "Şifre Tekrar";
            labelSifreTekrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboListBoxRol
            // 
            comboListBoxRol.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxRol.ListBoxVisualSize = 5;
            comboListBoxRol.Location = new System.Drawing.Point(296, 229);
            comboListBoxRol.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxRol.Name = "comboListBoxRol";
            comboListBoxRol.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxRol.Size = new System.Drawing.Size(204, 32);
            comboListBoxRol.TabIndex = 51;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(272, 230);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(18, 30);
            label7.TabIndex = 50;
            label7.Text = ":";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPersonel
            // 
            labelPersonel.AutoSize = true;
            labelPersonel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelPersonel.Location = new System.Drawing.Point(6, 230);
            labelPersonel.Name = "labelPersonel";
            labelPersonel.Size = new System.Drawing.Size(43, 30);
            labelPersonel.TabIndex = 49;
            labelPersonel.Text = "Rol";
            labelPersonel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboListBoxPersonel
            // 
            comboListBoxPersonel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxPersonel.ListBoxVisualSize = 5;
            comboListBoxPersonel.Location = new System.Drawing.Point(296, 191);
            comboListBoxPersonel.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxPersonel.Name = "comboListBoxPersonel";
            comboListBoxPersonel.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxPersonel.Size = new System.Drawing.Size(378, 32);
            comboListBoxPersonel.TabIndex = 54;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(272, 192);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(18, 30);
            label4.TabIndex = 53;
            label4.Text = ":";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(6, 192);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(93, 30);
            label5.TabIndex = 52;
            label5.Text = "Personel";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { KullaniciId, KullaniciAdi, PersonelId, PersonelAdi, RolId, RolAdi });
            dataGridView1.Location = new System.Drawing.Point(6, 377);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(683, 284);
            dataGridView1.TabIndex = 55;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // KullaniciId
            // 
            KullaniciId.HeaderText = "Id";
            KullaniciId.Name = "ad";
            KullaniciId.ReadOnly = true;
            KullaniciId.Visible = false;
            // 
            // KullaniciAdi
            // 
            KullaniciAdi.HeaderText = "Kullanicı Adı";
            KullaniciAdi.Name = "KullaniciAdi";
            KullaniciAdi.ReadOnly = true;
            KullaniciAdi.Width = 200;
            // 
            // PersonelId
            // 
            PersonelId.HeaderText = "PersonelId";
            PersonelId.Name = "PersonelId";
            PersonelId.ReadOnly = true;
            PersonelId.Visible = false;
            // 
            // PersonelAdi
            // 
            PersonelAdi.HeaderText = "Personel Adı";
            PersonelAdi.Name = "PersonelAdi";
            PersonelAdi.ReadOnly = true;
            // 
            // RolId
            // 
            RolId.HeaderText = "RolId";
            RolId.Name = "RolId";
            RolId.ReadOnly = true;
            RolId.Visible = false;
            // 
            // RolAdi
            // 
            RolAdi.HeaderText = "Rol";
            RolAdi.Name = "RolAdi";
            RolAdi.ReadOnly = true;
            RolAdi.Width = 150;
            // 
            // buttonFiltre
            // 
            buttonFiltre.BackgroundImage = Properties.Resources.DataReviewWithMagnifier5;
            buttonFiltre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            buttonFiltre.Location = new System.Drawing.Point(48, 328);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(61, 43);
            buttonFiltre.TabIndex = 56;
            buttonFiltre.UseVisualStyleBackColor = true;
            buttonFiltre.Click += buttonFiltre_Click;
            // 
            // labelUyariKulllaniciAdi
            // 
            labelUyariKulllaniciAdi.AutoSize = true;
            labelUyariKulllaniciAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariKulllaniciAdi.ForeColor = System.Drawing.Color.Red;
            labelUyariKulllaniciAdi.Location = new System.Drawing.Point(570, 90);
            labelUyariKulllaniciAdi.Name = "labelUyariKulllaniciAdi";
            labelUyariKulllaniciAdi.Size = new System.Drawing.Size(0, 15);
            labelUyariKulllaniciAdi.TabIndex = 91;
            // 
            // labelUyariSifre
            // 
            labelUyariSifre.AutoSize = true;
            labelUyariSifre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariSifre.ForeColor = System.Drawing.Color.Red;
            labelUyariSifre.Location = new System.Drawing.Point(570, 129);
            labelUyariSifre.Name = "labelUyariSifre";
            labelUyariSifre.Size = new System.Drawing.Size(0, 15);
            labelUyariSifre.TabIndex = 92;
            // 
            // labelUyariSifreTekrar
            // 
            labelUyariSifreTekrar.AutoSize = true;
            labelUyariSifreTekrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariSifreTekrar.ForeColor = System.Drawing.Color.Red;
            labelUyariSifreTekrar.Location = new System.Drawing.Point(570, 164);
            labelUyariSifreTekrar.Name = "labelUyariSifreTekrar";
            labelUyariSifreTekrar.Size = new System.Drawing.Size(0, 15);
            labelUyariSifreTekrar.TabIndex = 93;
            // 
            // labelUyariPersonel
            // 
            labelUyariPersonel.AutoSize = true;
            labelUyariPersonel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariPersonel.ForeColor = System.Drawing.Color.Red;
            labelUyariPersonel.Location = new System.Drawing.Point(678, 197);
            labelUyariPersonel.Name = "labelUyariPersonel";
            labelUyariPersonel.Size = new System.Drawing.Size(0, 15);
            labelUyariPersonel.TabIndex = 94;
            // 
            // labelUyariRol
            // 
            labelUyariRol.AutoSize = true;
            labelUyariRol.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariRol.ForeColor = System.Drawing.Color.Red;
            labelUyariRol.Location = new System.Drawing.Point(504, 235);
            labelUyariRol.Name = "labelUyariRol";
            labelUyariRol.Size = new System.Drawing.Size(0, 15);
            labelUyariRol.TabIndex = 95;
            // 
            // button1
            // 
            button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button1.Location = new System.Drawing.Point(12, 285);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(101, 28);
            button1.TabIndex = 96;
            button1.Text = "Formu Temizle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // KullaniciKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(924, 673);
            Controls.Add(button1);
            Controls.Add(labelUyariRol);
            Controls.Add(labelUyariPersonel);
            Controls.Add(labelUyariSifreTekrar);
            Controls.Add(labelUyariSifre);
            Controls.Add(labelUyariKulllaniciAdi);
            Controls.Add(buttonFiltre);
            Controls.Add(dataGridView1);
            Controls.Add(comboListBoxPersonel);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(comboListBoxRol);
            Controls.Add(label7);
            Controls.Add(labelPersonel);
            Controls.Add(customTextBoxSifreTekrar);
            Controls.Add(label3);
            Controls.Add(labelSifreTekrar);
            Controls.Add(customTextBoxSifre);
            Controls.Add(label1);
            Controls.Add(labelSifre);
            Controls.Add(textBoxKullaniciAdi);
            Controls.Add(label2);
            Controls.Add(labelKullaniciAdi);
            Controls.Add(rButtonKullaniciKaydet);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "KullaniciKayitFormu";
            Text = "KullaniciKayitFormu";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton rButtonKullaniciKaydet;
        public CustomControls.CustomTextBox textBoxKullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelKullaniciAdi;
        public CustomControls.CustomTextBox customTextBoxSifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSifre;
        public CustomControls.CustomTextBox customTextBoxSifreTekrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSifreTekrar;
        private CustomControls.CustomComboListBox comboListBoxRol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelPersonel;
        private CustomControls.CustomComboListBox comboListBoxPersonel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CustomControls.RoundedButton roundedButton2;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.RoundedButton roundedButton3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonFiltre;
        private System.Windows.Forms.DataGridViewTextBoxColumn KullaniciId;
        private System.Windows.Forms.DataGridViewTextBoxColumn KullaniciAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonelAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn RolId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RolAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonelId;
        private System.Windows.Forms.Label labelUyariKulllaniciAdi;
        private System.Windows.Forms.Label labelUyariSifre;
        private System.Windows.Forms.Label labelUyariSifreTekrar;
        private System.Windows.Forms.Label labelUyariPersonel;
        private System.Windows.Forms.Label labelUyariRol;
        private System.Windows.Forms.Button button1;
    }
}