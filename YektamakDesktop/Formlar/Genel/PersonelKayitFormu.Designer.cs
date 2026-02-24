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
            ctbId = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            buttonResimSec = new System.Windows.Forms.Button();
            pictureBoxPersonel = new System.Windows.Forms.PictureBox();
            openFileDialogResim = new System.Windows.Forms.OpenFileDialog();
            ctbPersonelAd = new YektamakDesktop.CustomControls.CustomTextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ctbPersonelSoyad = new YektamakDesktop.CustomControls.CustomTextBox();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            label3 = new System.Windows.Forms.Label();
            ctbTelefon = new YektamakDesktop.CustomControls.CustomTextBox();
            label4 = new System.Windows.Forms.Label();
            ctbMail = new YektamakDesktop.CustomControls.CustomTextBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            btnSave = new YektamakDesktop.CustomControls.CustomButtonSave();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            label8 = new System.Windows.Forms.Label();
            clbYonetici = new YektamakDesktop.CustomControls.FilterableComboBox();
            clbFirma = new YektamakDesktop.CustomControls.FilterableComboBox();
            clbPozisyon = new YektamakDesktop.CustomControls.FilterableComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPersonel).BeginInit();
            SuspendLayout();
            // 
            // ctbId
            // 
            ctbId.BackColor = System.Drawing.Color.White;
            ctbId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbId.ForeColor = System.Drawing.Color.Black;
            ctbId.Location = new System.Drawing.Point(325, 50);
            ctbId.Margin = new System.Windows.Forms.Padding(1);
            ctbId.Name = "ctbId";
            ctbId.OndalikBasamak = 0;
            ctbId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbId.Size = new System.Drawing.Size(69, 33);
            ctbId.TabIndex = 62;
            ctbId.TextCustom = "0";
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
            // openFileDialogResim
            // 
            openFileDialogResim.Filter = "Image Files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            openFileDialogResim.FileOk += openFileDialogResim_FileOk;
            // 
            // ctbPersonelAd
            // 
            ctbPersonelAd.BackColor = System.Drawing.Color.White;
            ctbPersonelAd.BorderColor = System.Drawing.Color.Silver;
            ctbPersonelAd.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbPersonelAd.BorderSize = 1;
            ctbPersonelAd.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbPersonelAd.ForeColor = System.Drawing.Color.Black;
            ctbPersonelAd.Location = new System.Drawing.Point(325, 82);
            ctbPersonelAd.Margin = new System.Windows.Forms.Padding(1);
            ctbPersonelAd.Multiline = false;
            ctbPersonelAd.Name = "ctbPersonelAd";
            ctbPersonelAd.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbPersonelAd.PasswordChar = false;
            ctbPersonelAd.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbPersonelAd.PlaceholderText = "";
            ctbPersonelAd.ReadOnly = false;
            ctbPersonelAd.SelectionStart = 0;
            ctbPersonelAd.Size = new System.Drawing.Size(240, 33);
            ctbPersonelAd.TabIndex = 36;
            ctbPersonelAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbPersonelAd.TextCustom = "";
            ctbPersonelAd.UnderlinedStyle = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(230, 87);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(22, 15);
            label1.TabIndex = 37;
            label1.Text = "Ad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(230, 121);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(39, 15);
            label2.TabIndex = 39;
            label2.Text = "Soyad";
            // 
            // ctbPersonelSoyad
            // 
            ctbPersonelSoyad.BackColor = System.Drawing.Color.White;
            ctbPersonelSoyad.BorderColor = System.Drawing.Color.Silver;
            ctbPersonelSoyad.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbPersonelSoyad.BorderSize = 1;
            ctbPersonelSoyad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbPersonelSoyad.ForeColor = System.Drawing.Color.Black;
            ctbPersonelSoyad.Location = new System.Drawing.Point(325, 116);
            ctbPersonelSoyad.Margin = new System.Windows.Forms.Padding(1);
            ctbPersonelSoyad.Multiline = false;
            ctbPersonelSoyad.Name = "ctbPersonelSoyad";
            ctbPersonelSoyad.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbPersonelSoyad.PasswordChar = false;
            ctbPersonelSoyad.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbPersonelSoyad.PlaceholderText = "";
            ctbPersonelSoyad.ReadOnly = false;
            ctbPersonelSoyad.SelectionStart = 0;
            ctbPersonelSoyad.Size = new System.Drawing.Size(240, 33);
            ctbPersonelSoyad.TabIndex = 38;
            ctbPersonelSoyad.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbPersonelSoyad.TextCustom = "";
            ctbPersonelSoyad.UnderlinedStyle = false;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Personel Tanımlama";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(992, 25);
            headerPanel1.TabIndex = 40;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(230, 155);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(45, 15);
            label3.TabIndex = 42;
            label3.Text = "Telefon";
            // 
            // ctbTelefon
            // 
            ctbTelefon.BackColor = System.Drawing.Color.White;
            ctbTelefon.BorderColor = System.Drawing.Color.Silver;
            ctbTelefon.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbTelefon.BorderSize = 1;
            ctbTelefon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbTelefon.ForeColor = System.Drawing.Color.Black;
            ctbTelefon.Location = new System.Drawing.Point(325, 150);
            ctbTelefon.Margin = new System.Windows.Forms.Padding(1);
            ctbTelefon.Multiline = false;
            ctbTelefon.Name = "ctbTelefon";
            ctbTelefon.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbTelefon.PasswordChar = false;
            ctbTelefon.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbTelefon.PlaceholderText = "";
            ctbTelefon.ReadOnly = false;
            ctbTelefon.SelectionStart = 0;
            ctbTelefon.Size = new System.Drawing.Size(240, 33);
            ctbTelefon.TabIndex = 41;
            ctbTelefon.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbTelefon.TextCustom = "";
            ctbTelefon.UnderlinedStyle = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(230, 189);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(30, 15);
            label4.TabIndex = 44;
            label4.Text = "Mail";
            // 
            // ctbMail
            // 
            ctbMail.BackColor = System.Drawing.Color.White;
            ctbMail.BorderColor = System.Drawing.Color.Silver;
            ctbMail.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbMail.BorderSize = 1;
            ctbMail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbMail.ForeColor = System.Drawing.Color.Black;
            ctbMail.Location = new System.Drawing.Point(325, 184);
            ctbMail.Margin = new System.Windows.Forms.Padding(1);
            ctbMail.Multiline = false;
            ctbMail.Name = "ctbMail";
            ctbMail.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbMail.PasswordChar = false;
            ctbMail.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbMail.PlaceholderText = "";
            ctbMail.ReadOnly = false;
            ctbMail.SelectionStart = 0;
            ctbMail.Size = new System.Drawing.Size(240, 33);
            ctbMail.TabIndex = 43;
            ctbMail.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbMail.TextCustom = "";
            ctbMail.UnderlinedStyle = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(230, 227);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(37, 15);
            label5.TabIndex = 46;
            label5.Text = "Firma";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(230, 263);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(54, 15);
            label6.TabIndex = 48;
            label6.Text = "Pozisyon";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(230, 299);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(49, 15);
            label7.TabIndex = 50;
            label7.Text = "Yönetici";
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.Transparent;
            btnSave.Location = new System.Drawing.Point(618, 303);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(107, 47);
            btnSave.TabIndex = 51;
            btnSave.SaveButtonClick += buttonPersonelKaydet_Click;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(0, 354);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(992, 352);
            universalGrid1.TabIndex = 55;
            // 
            // roundedButton1
            // 
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Black;
            roundedButton1.BorderSize = 0;
            roundedButton1.CornerRadius = 20;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedButton1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedButton1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedButton1.HoverColor2 = System.Drawing.Color.Navy;
            roundedButton1.Icon = null;
            roundedButton1.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton1.Location = new System.Drawing.Point(647, 58);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(78, 40);
            roundedButton1.TabIndex = 56;
            roundedButton1.Text = "Yeni Kayıt";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(230, 53);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(17, 15);
            label8.TabIndex = 58;
            label8.Text = "Id";
            // 
            // clbYonetici
            // 
            clbYonetici.BorderColor = System.Drawing.Color.Silver;
            clbYonetici.BorderRadius = 8;
            clbYonetici.BorderSize = 1;
            clbYonetici.DisplayMember = "adSoyad";
            clbYonetici.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbYonetici.Location = new System.Drawing.Point(325, 291);
            clbYonetici.Margin = new System.Windows.Forms.Padding(1);
            clbYonetici.Name = "clbYonetici";
            clbYonetici.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbYonetici.PlaceholderText = "Seçiniz...";
            clbYonetici.Size = new System.Drawing.Size(200, 29);
            clbYonetici.TabIndex = 59;
            clbYonetici.ValueMember = "Id";
            // 
            // clbFirma
            // 
            clbFirma.BorderColor = System.Drawing.Color.Silver;
            clbFirma.BorderRadius = 8;
            clbFirma.BorderSize = 1;
            clbFirma.DisplayMember = "ad";
            clbFirma.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbFirma.Location = new System.Drawing.Point(325, 218);
            clbFirma.Margin = new System.Windows.Forms.Padding(1);
            clbFirma.Name = "clbFirma";
            clbFirma.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbFirma.PlaceholderText = "Seçiniz...";
            clbFirma.Size = new System.Drawing.Size(364, 29);
            clbFirma.TabIndex = 60;
            clbFirma.ValueMember = "Id";
            // 
            // clbPozisyon
            // 
            clbPozisyon.BorderColor = System.Drawing.Color.Silver;
            clbPozisyon.BorderRadius = 8;
            clbPozisyon.BorderSize = 1;
            clbPozisyon.DisplayMember = "ad";
            clbPozisyon.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbPozisyon.Location = new System.Drawing.Point(325, 253);
            clbPozisyon.Margin = new System.Windows.Forms.Padding(1);
            clbPozisyon.Name = "clbPozisyon";
            clbPozisyon.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbPozisyon.PlaceholderText = "Seçiniz...";
            clbPozisyon.Size = new System.Drawing.Size(200, 29);
            clbPozisyon.TabIndex = 61;
            clbPozisyon.ValueMember = "Id";
            // 
            // PersonelKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(992, 707);
            Controls.Add(ctbId);
            Controls.Add(clbPozisyon);
            Controls.Add(clbFirma);
            Controls.Add(clbYonetici);
            Controls.Add(label8);
            Controls.Add(roundedButton1);
            Controls.Add(universalGrid1);
            Controls.Add(btnSave);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(ctbMail);
            Controls.Add(label3);
            Controls.Add(ctbTelefon);
            Controls.Add(headerPanel1);
            Controls.Add(label2);
            Controls.Add(ctbPersonelSoyad);
            Controls.Add(label1);
            Controls.Add(ctbPersonelAd);
            Controls.Add(buttonResimSec);
            Controls.Add(pictureBoxPersonel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "PersonelKayitFormu";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PersonelKayitFormu";
            FormClosing += PersonelKayitFormu_FormClosing;
            Load += PersonelKayitFormu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxPersonel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button buttonResimSec;
        private System.Windows.Forms.PictureBox pictureBoxPersonel;
        private System.Windows.Forms.OpenFileDialog openFileDialogResim;
        private CustomControls.CustomTextBox ctbPersonelAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomTextBox ctbPersonelSoyad;
        public CustomControls.HeaderPanel headerPanel1;
        private System.Windows.Forms.Label label3;
        private CustomControls.CustomTextBox ctbTelefon;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBox ctbMail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CustomControls.CustomButtonSave btnSave;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.RoundedButton roundedButton1;
        private System.Windows.Forms.Label label8;
        private CustomControls.CustomTextBoxSayisal ctbId;
        private CustomControls.FilterableComboBox clbYonetici;
        private CustomControls.FilterableComboBox clbFirma;
        private CustomControls.FilterableComboBox clbPozisyon;
    }
}