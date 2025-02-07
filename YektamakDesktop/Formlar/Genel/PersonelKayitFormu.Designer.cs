namespace YektamakDesktop.Formlar.Genel
{
    partial class PersonelKayitFormu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelKayitFormu));
            buttonResimSec = new System.Windows.Forms.Button();
            pictureBoxPersonel = new System.Windows.Forms.PictureBox();
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            buttonKapat = new CustomControls.RoundedButton();
            buttonPersonelGuncelle = new CustomControls.RoundedButton();
            buttonPersonelKaydet = new CustomControls.RoundedButton();
            textBoxPozisyon = new CustomControls.CustomTextBox();
            label12 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            textBoxEmail = new CustomControls.CustomTextBox();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            textBoxTelefon = new CustomControls.CustomTextBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            textBoxSoyisim = new CustomControls.CustomTextBox();
            textBoxIsim = new CustomControls.CustomTextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            openFileDialogResim = new System.Windows.Forms.OpenFileDialog();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            comboListBoxFirma = new CustomControls.CustomComboListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPersonel).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // buttonResimSec
            // 
            buttonResimSec.Location = new System.Drawing.Point(12, 242);
            buttonResimSec.Name = "buttonResimSec";
            buttonResimSec.Size = new System.Drawing.Size(170, 23);
            buttonResimSec.TabIndex = 35;
            buttonResimSec.Text = "Resim Yükle";
            buttonResimSec.UseVisualStyleBackColor = true;
            buttonResimSec.Click += buttonResimSec_Click;
            // 
            // pictureBoxPersonel
            // 
            pictureBoxPersonel.BackColor = System.Drawing.SystemColors.ControlLight;
            pictureBoxPersonel.Location = new System.Drawing.Point(12, 53);
            pictureBoxPersonel.Name = "pictureBoxPersonel";
            pictureBoxPersonel.Size = new System.Drawing.Size(170, 180);
            pictureBoxPersonel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxPersonel.TabIndex = 34;
            pictureBoxPersonel.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelHeader.BackColor = System.Drawing.Color.Red;
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1073, 47);
            panelHeader.TabIndex = 22;
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
            buttonClose.Location = new System.Drawing.Point(1011, 4);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(41, 38);
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
            buttonHelp.Location = new System.Drawing.Point(931, 4);
            buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonHelp.Size = new System.Drawing.Size(41, 38);
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
            buttomMinimize.Location = new System.Drawing.Point(971, 4);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(41, 38);
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
            labelHeader.Location = new System.Drawing.Point(45, 8);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(152, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Personel Kayıt";
            // 
            // buttonKapat
            // 
            buttonKapat.BackColor = System.Drawing.Color.Brown;
            buttonKapat.BackgroundColor = System.Drawing.Color.Brown;
            buttonKapat.BorderColor = System.Drawing.Color.Crimson;
            buttonKapat.BorderRadius = 40;
            buttonKapat.BorderSize = 5;
            buttonKapat.FlatAppearance.BorderSize = 0;
            buttonKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonKapat.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonKapat.ForeColor = System.Drawing.Color.White;
            buttonKapat.Location = new System.Drawing.Point(361, 345);
            buttonKapat.Name = "buttonKapat";
            buttonKapat.Size = new System.Drawing.Size(150, 66);
            buttonKapat.TabIndex = 21;
            buttonKapat.Text = "KAPAT";
            buttonKapat.TextColor = System.Drawing.Color.White;
            buttonKapat.UseVisualStyleBackColor = false;
            buttonKapat.Click += buttonKapat_Click;
            // 
            // buttonPersonelGuncelle
            // 
            buttonPersonelGuncelle.BackColor = System.Drawing.Color.CornflowerBlue;
            buttonPersonelGuncelle.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            buttonPersonelGuncelle.BorderColor = System.Drawing.Color.RoyalBlue;
            buttonPersonelGuncelle.BorderRadius = 40;
            buttonPersonelGuncelle.BorderSize = 5;
            buttonPersonelGuncelle.FlatAppearance.BorderSize = 0;
            buttonPersonelGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonPersonelGuncelle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonPersonelGuncelle.ForeColor = System.Drawing.Color.White;
            buttonPersonelGuncelle.Location = new System.Drawing.Point(205, 345);
            buttonPersonelGuncelle.Name = "buttonPersonelGuncelle";
            buttonPersonelGuncelle.Size = new System.Drawing.Size(150, 66);
            buttonPersonelGuncelle.TabIndex = 20;
            buttonPersonelGuncelle.Text = "GÜNCELLE";
            buttonPersonelGuncelle.TextColor = System.Drawing.Color.White;
            buttonPersonelGuncelle.UseVisualStyleBackColor = false;
            buttonPersonelGuncelle.Click += buttonPersonelKaydet_Click;
            // 
            // buttonPersonelKaydet
            // 
            buttonPersonelKaydet.BackColor = System.Drawing.Color.LimeGreen;
            buttonPersonelKaydet.BackgroundColor = System.Drawing.Color.LimeGreen;
            buttonPersonelKaydet.BorderColor = System.Drawing.Color.MediumSeaGreen;
            buttonPersonelKaydet.BorderRadius = 40;
            buttonPersonelKaydet.BorderSize = 5;
            buttonPersonelKaydet.FlatAppearance.BorderSize = 0;
            buttonPersonelKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonPersonelKaydet.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonPersonelKaydet.ForeColor = System.Drawing.Color.White;
            buttonPersonelKaydet.Location = new System.Drawing.Point(205, 345);
            buttonPersonelKaydet.Name = "buttonPersonelKaydet";
            buttonPersonelKaydet.Size = new System.Drawing.Size(150, 66);
            buttonPersonelKaydet.TabIndex = 19;
            buttonPersonelKaydet.Text = "KAYDET";
            buttonPersonelKaydet.TextColor = System.Drawing.Color.White;
            buttonPersonelKaydet.UseVisualStyleBackColor = false;
            buttonPersonelKaydet.Click += buttonPersonelKaydet_Click;
            // 
            // textBoxPozisyon
            // 
            textBoxPozisyon.BackColor = System.Drawing.Color.White;
            textBoxPozisyon.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxPozisyon.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxPozisyon.BorderRadius = 0;
            textBoxPozisyon.BorderSize = 2;
            textBoxPozisyon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxPozisyon.ForeColor = System.Drawing.Color.Black;
            textBoxPozisyon.isPlaceHolder = false;
            textBoxPozisyon.Location = new System.Drawing.Point(485, 242);
            textBoxPozisyon.Multiline = false;
            textBoxPozisyon.Name = "textBoxPozisyon";
            textBoxPozisyon.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxPozisyon.PasswordChar = false;
            textBoxPozisyon.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxPozisyon.PlaceholderText = "";
            textBoxPozisyon.ReadOnly = false;
            textBoxPozisyon.SelectionStart = 0;
            textBoxPozisyon.Size = new System.Drawing.Size(250, 32);
            textBoxPozisyon.TabIndex = 17;
            textBoxPozisyon.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxPozisyon.TextCustom = "";
            textBoxPozisyon.UnderlinedStyle = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label12.Location = new System.Drawing.Point(461, 242);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(18, 30);
            label12.TabIndex = 15;
            label12.Text = ":";
            label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label10.Location = new System.Drawing.Point(195, 242);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(97, 30);
            label10.TabIndex = 13;
            label10.Text = "Pozisyon";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxEmail
            // 
            textBoxEmail.BackColor = System.Drawing.Color.White;
            textBoxEmail.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxEmail.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxEmail.BorderRadius = 0;
            textBoxEmail.BorderSize = 2;
            textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxEmail.ForeColor = System.Drawing.Color.Black;
            textBoxEmail.isPlaceHolder = false;
            textBoxEmail.Location = new System.Drawing.Point(485, 196);
            textBoxEmail.Multiline = false;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxEmail.PasswordChar = false;
            textBoxEmail.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxEmail.PlaceholderText = "";
            textBoxEmail.ReadOnly = false;
            textBoxEmail.SelectionStart = 0;
            textBoxEmail.Size = new System.Drawing.Size(250, 32);
            textBoxEmail.TabIndex = 11;
            textBoxEmail.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxEmail.TextCustom = "";
            textBoxEmail.UnderlinedStyle = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(461, 197);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(18, 30);
            label7.TabIndex = 10;
            label7.Text = ":";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(195, 196);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(72, 30);
            label8.TabIndex = 9;
            label8.Text = "e-Mail";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxTelefon
            // 
            textBoxTelefon.BackColor = System.Drawing.Color.White;
            textBoxTelefon.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxTelefon.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxTelefon.BorderRadius = 0;
            textBoxTelefon.BorderSize = 2;
            textBoxTelefon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxTelefon.ForeColor = System.Drawing.Color.Black;
            textBoxTelefon.isPlaceHolder = false;
            textBoxTelefon.Location = new System.Drawing.Point(485, 157);
            textBoxTelefon.Multiline = false;
            textBoxTelefon.Name = "textBoxTelefon";
            textBoxTelefon.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxTelefon.PasswordChar = false;
            textBoxTelefon.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxTelefon.PlaceholderText = "";
            textBoxTelefon.ReadOnly = false;
            textBoxTelefon.SelectionStart = 0;
            textBoxTelefon.Size = new System.Drawing.Size(250, 32);
            textBoxTelefon.TabIndex = 8;
            textBoxTelefon.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxTelefon.TextCustom = "";
            textBoxTelefon.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(461, 157);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(18, 30);
            label6.TabIndex = 7;
            label6.Text = ":";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(195, 151);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(82, 30);
            label5.TabIndex = 6;
            label5.Text = "Telefon";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxSoyisim
            // 
            textBoxSoyisim.BackColor = System.Drawing.Color.White;
            textBoxSoyisim.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxSoyisim.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxSoyisim.BorderRadius = 0;
            textBoxSoyisim.BorderSize = 2;
            textBoxSoyisim.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxSoyisim.ForeColor = System.Drawing.Color.Black;
            textBoxSoyisim.isPlaceHolder = false;
            textBoxSoyisim.Location = new System.Drawing.Point(485, 109);
            textBoxSoyisim.Multiline = false;
            textBoxSoyisim.Name = "textBoxSoyisim";
            textBoxSoyisim.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxSoyisim.PasswordChar = false;
            textBoxSoyisim.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxSoyisim.PlaceholderText = "";
            textBoxSoyisim.ReadOnly = false;
            textBoxSoyisim.SelectionStart = 0;
            textBoxSoyisim.Size = new System.Drawing.Size(250, 32);
            textBoxSoyisim.TabIndex = 5;
            textBoxSoyisim.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxSoyisim.TextCustom = "";
            textBoxSoyisim.UnderlinedStyle = false;
            // 
            // textBoxIsim
            // 
            textBoxIsim.BackColor = System.Drawing.Color.White;
            textBoxIsim.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxIsim.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxIsim.BorderRadius = 0;
            textBoxIsim.BorderSize = 2;
            textBoxIsim.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxIsim.ForeColor = System.Drawing.Color.Black;
            textBoxIsim.isPlaceHolder = false;
            textBoxIsim.Location = new System.Drawing.Point(485, 64);
            textBoxIsim.Multiline = false;
            textBoxIsim.Name = "textBoxIsim";
            textBoxIsim.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBoxIsim.PasswordChar = false;
            textBoxIsim.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxIsim.PlaceholderText = "";
            textBoxIsim.ReadOnly = false;
            textBoxIsim.SelectionStart = 0;
            textBoxIsim.Size = new System.Drawing.Size(250, 32);
            textBoxIsim.TabIndex = 4;
            textBoxIsim.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxIsim.TextCustom = "";
            textBoxIsim.UnderlinedStyle = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(461, 109);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(18, 30);
            label3.TabIndex = 3;
            label3.Text = ":";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(195, 106);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 30);
            label4.TabIndex = 2;
            label4.Text = "Soyisim";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(461, 61);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(18, 30);
            label2.TabIndex = 1;
            label2.Text = ":";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(195, 61);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 30);
            label1.TabIndex = 0;
            label1.Text = "İsim";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialogResim
            // 
            openFileDialogResim.Filter = "Image Files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            openFileDialogResim.FileOk += openFileDialogResim_FileOk;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label13.Location = new System.Drawing.Point(461, 287);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(18, 30);
            label13.TabIndex = 37;
            label13.Text = ":";
            label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label14.Location = new System.Drawing.Point(195, 287);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(67, 30);
            label14.TabIndex = 36;
            label14.Text = "Firma";
            label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboListBoxFirma
            // 
            comboListBoxFirma.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxFirma.ListBoxVisualSize = 5;
            comboListBoxFirma.Location = new System.Drawing.Point(485, 287);
            comboListBoxFirma.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxFirma.Name = "comboListBoxFirma";
            comboListBoxFirma.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxFirma.Size = new System.Drawing.Size(361, 36);
            comboListBoxFirma.TabIndex = 38;
            // 
            // PersonelKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(1073, 426);
            Controls.Add(comboListBoxFirma);
            Controls.Add(label13);
            Controls.Add(label14);
            Controls.Add(panelHeader);
            Controls.Add(buttonResimSec);
            Controls.Add(buttonKapat);
            Controls.Add(pictureBoxPersonel);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(buttonPersonelGuncelle);
            Controls.Add(label3);
            Controls.Add(buttonPersonelKaydet);
            Controls.Add(textBoxIsim);
            Controls.Add(textBoxPozisyon);
            Controls.Add(textBoxSoyisim);
            Controls.Add(label12);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label10);
            Controls.Add(textBoxTelefon);
            Controls.Add(label8);
            Controls.Add(textBoxEmail);
            Controls.Add(label7);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "PersonelKayitFormu";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PersonelKayit";
            Load += PersonelKayitFormu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxPersonel).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private CustomControls.RoundedButton buttonKapat;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        public CustomControls.CustomTextBox textBoxIsim;
        public CustomControls.CustomTextBox textBoxSoyisim;
        public CustomControls.CustomTextBox textBoxTelefon;
        public CustomControls.CustomTextBox textBoxEmail;
        public CustomControls.CustomTextBox textBoxPozisyon;
        public CustomControls.RoundedButton buttonPersonelGuncelle;
        public CustomControls.RoundedButton buttonPersonelKaydet;
        private System.Windows.Forms.Button buttonResimSec;
        private System.Windows.Forms.PictureBox pictureBoxPersonel;
        private System.Windows.Forms.OpenFileDialog openFileDialogResim;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private CustomControls.CustomComboListBox comboListBoxFirma;
    }
}