namespace YektamakDesktop.Formlar.Satis
{
    partial class SatisFaturaKayitFormu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatisFaturaKayitFormu));
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            textBoxFaturalandirilmamisTutar = new CustomControls.CustomTextBoxSayisal();
            customTextBoxSatisTutari = new CustomControls.CustomTextBoxSayisal();
            textBoxFaturaTutari = new CustomControls.CustomTextBoxSayisal();
            textBoxFaturaTarihi = new CustomControls.CustomTextBoxTarih();
            comboListBoxDovizCinsi = new CustomControls.CustomComboListBox();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            comboListBoxCariKartId = new CustomControls.CustomComboListBox();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            labelFaturaTutariUyari = new System.Windows.Forms.Label();
            comboListBoxkdv = new CustomControls.CustomComboListBox();
            comboListBoxProjeKodu = new CustomControls.CustomComboListBox();
            rButtonKapat = new CustomControls.RoundedButton();
            rButtonGuncelle = new CustomControls.RoundedButton();
            rButtonKaydet = new CustomControls.RoundedButton();
            label11 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            textBoxFaturaNo = new CustomControls.CustomTextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            panelHeader.SuspendLayout();
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
            panelHeader.Size = new System.Drawing.Size(957, 47);
            panelHeader.TabIndex = 23;
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
            buttonClose.Location = new System.Drawing.Point(891, 4);
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
            buttonHelp.Location = new System.Drawing.Point(811, 4);
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
            buttomMinimize.Location = new System.Drawing.Point(851, 4);
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
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            labelHeader.Location = new System.Drawing.Point(31, 8);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(267, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Satış Faturası Kayıt Formu";
            // 
            // textBoxFaturalandirilmamisTutar
            // 
            textBoxFaturalandirilmamisTutar.BackColor = System.Drawing.Color.WhiteSmoke;
            textBoxFaturalandirilmamisTutar.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxFaturalandirilmamisTutar.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxFaturalandirilmamisTutar.BorderRadius = 0;
            textBoxFaturalandirilmamisTutar.BorderSize = 2;
            textBoxFaturalandirilmamisTutar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFaturalandirilmamisTutar.ForeColor = System.Drawing.Color.Black;
            textBoxFaturalandirilmamisTutar.Location = new System.Drawing.Point(324, 316);
            textBoxFaturalandirilmamisTutar.Multiline = false;
            textBoxFaturalandirilmamisTutar.Name = "textBoxFaturalandirilmamisTutar";
            textBoxFaturalandirilmamisTutar.OndalikBasamak = 2;
            textBoxFaturalandirilmamisTutar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxFaturalandirilmamisTutar.PasswordChar = false;
            textBoxFaturalandirilmamisTutar.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxFaturalandirilmamisTutar.PlaceholderText = "";
            textBoxFaturalandirilmamisTutar.ReadOnly = true;
            textBoxFaturalandirilmamisTutar.SelectionStart = 0;
            textBoxFaturalandirilmamisTutar.Size = new System.Drawing.Size(139, 32);
            textBoxFaturalandirilmamisTutar.TabIndex = 107;
            textBoxFaturalandirilmamisTutar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            textBoxFaturalandirilmamisTutar.TextCustom = "0,00";
            textBoxFaturalandirilmamisTutar.UnderlinedStyle = false;
            // 
            // customTextBoxSatisTutari
            // 
            customTextBoxSatisTutari.BackColor = System.Drawing.Color.White;
            customTextBoxSatisTutari.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxSatisTutari.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxSatisTutari.BorderRadius = 0;
            customTextBoxSatisTutari.BorderSize = 2;
            customTextBoxSatisTutari.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxSatisTutari.ForeColor = System.Drawing.Color.Black;
            customTextBoxSatisTutari.Location = new System.Drawing.Point(324, 278);
            customTextBoxSatisTutari.Multiline = false;
            customTextBoxSatisTutari.Name = "customTextBoxSatisTutari";
            customTextBoxSatisTutari.OndalikBasamak = 2;
            customTextBoxSatisTutari.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxSatisTutari.PasswordChar = false;
            customTextBoxSatisTutari.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxSatisTutari.PlaceholderText = "";
            customTextBoxSatisTutari.ReadOnly = false;
            customTextBoxSatisTutari.SelectionStart = 0;
            customTextBoxSatisTutari.Size = new System.Drawing.Size(139, 32);
            customTextBoxSatisTutari.TabIndex = 106;
            customTextBoxSatisTutari.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            customTextBoxSatisTutari.TextCustom = "0,00";
            customTextBoxSatisTutari.UnderlinedStyle = false;
            // 
            // textBoxFaturaTutari
            // 
            textBoxFaturaTutari.BackColor = System.Drawing.Color.White;
            textBoxFaturaTutari.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxFaturaTutari.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxFaturaTutari.BorderRadius = 0;
            textBoxFaturaTutari.BorderSize = 2;
            textBoxFaturaTutari.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFaturaTutari.ForeColor = System.Drawing.Color.Black;
            textBoxFaturaTutari.Location = new System.Drawing.Point(324, 240);
            textBoxFaturaTutari.Multiline = false;
            textBoxFaturaTutari.Name = "textBoxFaturaTutari";
            textBoxFaturaTutari.OndalikBasamak = 2;
            textBoxFaturaTutari.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxFaturaTutari.PasswordChar = false;
            textBoxFaturaTutari.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxFaturaTutari.PlaceholderText = "";
            textBoxFaturaTutari.ReadOnly = false;
            textBoxFaturaTutari.SelectionStart = 0;
            textBoxFaturaTutari.Size = new System.Drawing.Size(139, 32);
            textBoxFaturaTutari.TabIndex = 105;
            textBoxFaturaTutari.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            textBoxFaturaTutari.TextCustom = "0,00";
            textBoxFaturaTutari.UnderlinedStyle = false;
            // 
            // textBoxFaturaTarihi
            // 
            textBoxFaturaTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            textBoxFaturaTarihi.Location = new System.Drawing.Point(318, 203);
            textBoxFaturaTarihi.Margin = new System.Windows.Forms.Padding(1);
            textBoxFaturaTarihi.Name = "textBoxFaturaTarihi";
            textBoxFaturaTarihi.Padding = new System.Windows.Forms.Padding(1);
            textBoxFaturaTarihi.Size = new System.Drawing.Size(139, 32);
            textBoxFaturaTarihi.TabIndex = 104;
            textBoxFaturaTarihi.TextCustom = "";
            // 
            // comboListBoxDovizCinsi
            // 
            comboListBoxDovizCinsi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxDovizCinsi.ListBoxVisualSize = 5;
            comboListBoxDovizCinsi.Location = new System.Drawing.Point(467, 240);
            comboListBoxDovizCinsi.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxDovizCinsi.Name = "comboListBoxDovizCinsi";
            comboListBoxDovizCinsi.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxDovizCinsi.Size = new System.Drawing.Size(72, 36);
            comboListBoxDovizCinsi.TabIndex = 103;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label19.Location = new System.Drawing.Point(300, 316);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(18, 30);
            label19.TabIndex = 102;
            label19.Text = ":";
            label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label20.Location = new System.Drawing.Point(34, 323);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(267, 20);
            label20.TabIndex = 101;
            label20.Text = "Faturalandırılmamış Kalan Tutar (NET)";
            label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label10.Location = new System.Drawing.Point(300, 278);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(18, 30);
            label10.TabIndex = 100;
            label10.Text = ":";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label12.Location = new System.Drawing.Point(34, 278);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(176, 30);
            label12.TabIndex = 99;
            label12.Text = "Satış Tutarı (NET)";
            label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label17.Location = new System.Drawing.Point(300, 240);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(18, 30);
            label17.TabIndex = 98;
            label17.Text = ":";
            label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label18.Location = new System.Drawing.Point(34, 240);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(133, 30);
            label18.TabIndex = 97;
            label18.Text = "Fatura Tutarı";
            label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label15.Location = new System.Drawing.Point(300, 202);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(18, 30);
            label15.TabIndex = 96;
            label15.Text = ":";
            label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label16.Location = new System.Drawing.Point(34, 202);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(130, 30);
            label16.TabIndex = 95;
            label16.Text = "Fatura Tarihi";
            label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboListBoxCariKartId
            // 
            comboListBoxCariKartId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxCariKartId.ListBoxVisualSize = 5;
            comboListBoxCariKartId.Location = new System.Drawing.Point(324, 163);
            comboListBoxCariKartId.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxCariKartId.Name = "comboListBoxCariKartId";
            comboListBoxCariKartId.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxCariKartId.Size = new System.Drawing.Size(447, 36);
            comboListBoxCariKartId.TabIndex = 94;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label13.Location = new System.Drawing.Point(300, 162);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(18, 30);
            label13.TabIndex = 93;
            label13.Text = ":";
            label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label14.Location = new System.Drawing.Point(34, 162);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(85, 30);
            label14.TabIndex = 92;
            label14.Text = "Müşteri";
            label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFaturaTutariUyari
            // 
            labelFaturaTutariUyari.AutoSize = true;
            labelFaturaTutariUyari.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelFaturaTutariUyari.ForeColor = System.Drawing.Color.Red;
            labelFaturaTutariUyari.Location = new System.Drawing.Point(643, 247);
            labelFaturaTutariUyari.Name = "labelFaturaTutariUyari";
            labelFaturaTutariUyari.Size = new System.Drawing.Size(0, 15);
            labelFaturaTutariUyari.TabIndex = 91;
            // 
            // comboListBoxkdv
            // 
            comboListBoxkdv.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxkdv.Enabled = false;
            comboListBoxkdv.ListBoxVisualSize = 5;
            comboListBoxkdv.Location = new System.Drawing.Point(324, 352);
            comboListBoxkdv.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxkdv.Name = "comboListBoxkdv";
            comboListBoxkdv.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxkdv.Size = new System.Drawing.Size(72, 36);
            comboListBoxkdv.TabIndex = 90;
            // 
            // comboListBoxProjeKodu
            // 
            comboListBoxProjeKodu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxProjeKodu.ListBoxVisualSize = 5;
            comboListBoxProjeKodu.Location = new System.Drawing.Point(324, 86);
            comboListBoxProjeKodu.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxProjeKodu.Name = "comboListBoxProjeKodu";
            comboListBoxProjeKodu.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxProjeKodu.Size = new System.Drawing.Size(251, 36);
            comboListBoxProjeKodu.TabIndex = 89;
            comboListBoxProjeKodu.SelectedIndexChanged += comboListBoxProjeKodu_SelectedIndexChanged;
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
            rButtonKapat.Location = new System.Drawing.Point(192, 483);
            rButtonKapat.Name = "rButtonKapat";
            rButtonKapat.Size = new System.Drawing.Size(150, 66);
            rButtonKapat.TabIndex = 88;
            rButtonKapat.Text = "KAPAT";
            rButtonKapat.TextColor = System.Drawing.Color.White;
            rButtonKapat.UseVisualStyleBackColor = false;
            rButtonKapat.Click += rButtonKapat_Click;
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
            rButtonGuncelle.Location = new System.Drawing.Point(31, 483);
            rButtonGuncelle.Name = "rButtonGuncelle";
            rButtonGuncelle.Size = new System.Drawing.Size(150, 66);
            rButtonGuncelle.TabIndex = 87;
            rButtonGuncelle.Text = "GÜNCELLE";
            rButtonGuncelle.TextColor = System.Drawing.Color.White;
            rButtonGuncelle.UseVisualStyleBackColor = false;
            rButtonGuncelle.Click += rButtonGuncelle_Click;
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
            rButtonKaydet.Location = new System.Drawing.Point(31, 483);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new System.Drawing.Size(150, 66);
            rButtonKaydet.TabIndex = 86;
            rButtonKaydet.Text = "KAYDET";
            rButtonKaydet.TextColor = System.Drawing.Color.White;
            rButtonKaydet.UseVisualStyleBackColor = false;
            rButtonKaydet.Click += rButtonKaydet_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label11.Location = new System.Drawing.Point(300, 86);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(18, 30);
            label11.TabIndex = 85;
            label11.Text = ":";
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label9.Location = new System.Drawing.Point(34, 86);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(119, 30);
            label9.TabIndex = 84;
            label9.Text = "Proje Kodu";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(300, 352);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(18, 30);
            label6.TabIndex = 83;
            label6.Text = ":";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(34, 352);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(54, 30);
            label5.TabIndex = 82;
            label5.Text = "KDV";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxFaturaNo
            // 
            textBoxFaturaNo.BackColor = System.Drawing.Color.White;
            textBoxFaturaNo.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxFaturaNo.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxFaturaNo.BorderRadius = 0;
            textBoxFaturaNo.BorderSize = 2;
            textBoxFaturaNo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFaturaNo.ForeColor = System.Drawing.Color.Black;
            textBoxFaturaNo.isPlaceHolder = false;
            textBoxFaturaNo.Location = new System.Drawing.Point(324, 126);
            textBoxFaturaNo.Multiline = false;
            textBoxFaturaNo.Name = "textBoxFaturaNo";
            textBoxFaturaNo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxFaturaNo.PasswordChar = false;
            textBoxFaturaNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxFaturaNo.PlaceholderText = "";
            textBoxFaturaNo.ReadOnly = false;
            textBoxFaturaNo.SelectionStart = 0;
            textBoxFaturaNo.Size = new System.Drawing.Size(185, 32);
            textBoxFaturaNo.TabIndex = 81;
            textBoxFaturaNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxFaturaNo.TextCustom = "";
            textBoxFaturaNo.UnderlinedStyle = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(300, 126);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(18, 30);
            label2.TabIndex = 80;
            label2.Text = ":";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(34, 126);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(170, 30);
            label1.TabIndex = 79;
            label1.Text = "Fatura Numarası";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SatisFaturaKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(957, 584);
            Controls.Add(textBoxFaturalandirilmamisTutar);
            Controls.Add(customTextBoxSatisTutari);
            Controls.Add(textBoxFaturaTutari);
            Controls.Add(textBoxFaturaTarihi);
            Controls.Add(comboListBoxDovizCinsi);
            Controls.Add(label19);
            Controls.Add(label20);
            Controls.Add(label10);
            Controls.Add(label12);
            Controls.Add(label17);
            Controls.Add(label18);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(comboListBoxCariKartId);
            Controls.Add(label13);
            Controls.Add(label14);
            Controls.Add(labelFaturaTutariUyari);
            Controls.Add(comboListBoxkdv);
            Controls.Add(comboListBoxProjeKodu);
            Controls.Add(rButtonKapat);
            Controls.Add(rButtonGuncelle);
            Controls.Add(rButtonKaydet);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBoxFaturaNo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "SatisFaturaKayitFormu";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FaturaKayit";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.CustomTextBoxSayisal textBoxFaturalandirilmamisTutar;
        private CustomControls.CustomTextBoxSayisal customTextBoxSatisTutari;
        private CustomControls.CustomTextBoxSayisal textBoxFaturaTutari;
        private CustomControls.CustomTextBoxTarih textBoxFaturaTarihi;
        private CustomControls.CustomComboListBox comboListBoxDovizCinsi;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private CustomControls.CustomComboListBox comboListBoxCariKartId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelFaturaTutariUyari;
        private CustomControls.CustomComboListBox comboListBoxkdv;
        private CustomControls.CustomComboListBox comboListBoxProjeKodu;
        private CustomControls.RoundedButton rButtonKapat;
        private CustomControls.RoundedButton rButtonGuncelle;
        private CustomControls.RoundedButton rButtonKaydet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public CustomControls.CustomTextBox textBoxFaturaNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}