using YektamakDesktop.CustomControls;
using System.Drawing;

namespace YektamakDesktop.Formlar
{
    partial class UserLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLogin));
            roundedButtonLogin = new RoundedButton();
            labelUyariKullaniciAdi = new System.Windows.Forms.Label();
            labelUyariSifre = new System.Windows.Forms.Label();
            ctbKullaniciAdi = new CustomTextBox();
            ctbSifre = new CustomTextBox();
            headerPanel1 = new HeaderPanel();
            btnSifreDegistir = new RoundedIconButton();
            SuspendLayout();
            // 
            // roundedButtonLogin
            // 
            roundedButtonLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            roundedButtonLogin.BackColor = Color.FromArgb(128, 64, 64);
            roundedButtonLogin.BackgroundColor = Color.FromArgb(128, 64, 64);
            roundedButtonLogin.BorderColor = SystemColors.InactiveBorder;
            roundedButtonLogin.BorderSize = 3;
            roundedButtonLogin.CornerRadius = 20;
            roundedButtonLogin.FlatAppearance.BorderSize = 0;
            roundedButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButtonLogin.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            roundedButtonLogin.ForeColor = Color.White;
            roundedButtonLogin.GradientColor1 = Color.DodgerBlue;
            roundedButtonLogin.GradientColor2 = Color.MidnightBlue;
            roundedButtonLogin.HoverColor1 = Color.RoyalBlue;
            roundedButtonLogin.HoverColor2 = Color.Navy;
            roundedButtonLogin.Icon = null;
            roundedButtonLogin.IconAlign = ContentAlignment.MiddleLeft;
            roundedButtonLogin.Location = new Point(131, 137);
            roundedButtonLogin.Name = "roundedButtonLogin";
            roundedButtonLogin.Size = new Size(135, 39);
            roundedButtonLogin.TabIndex = 22;
            roundedButtonLogin.Text = "GİRİŞ";
            roundedButtonLogin.TextColor = Color.White;
            roundedButtonLogin.UseVisualStyleBackColor = false;
            roundedButtonLogin.Click += roundedButtonLogin_Click;
            // 
            // labelUyariKullaniciAdi
            // 
            labelUyariKullaniciAdi.AutoSize = true;
            labelUyariKullaniciAdi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelUyariKullaniciAdi.ForeColor = Color.Red;
            labelUyariKullaniciAdi.Location = new Point(351, 71);
            labelUyariKullaniciAdi.Name = "labelUyariKullaniciAdi";
            labelUyariKullaniciAdi.Size = new Size(0, 15);
            labelUyariKullaniciAdi.TabIndex = 101;
            // 
            // labelUyariSifre
            // 
            labelUyariSifre.AutoSize = true;
            labelUyariSifre.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelUyariSifre.ForeColor = Color.Red;
            labelUyariSifre.Location = new Point(351, 108);
            labelUyariSifre.Name = "labelUyariSifre";
            labelUyariSifre.Size = new Size(0, 15);
            labelUyariSifre.TabIndex = 102;
            // 
            // ctbKullaniciAdi
            // 
            ctbKullaniciAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            ctbKullaniciAdi.BackColor = Color.White;
            ctbKullaniciAdi.BorderColor = Color.Silver;
            ctbKullaniciAdi.BorderFocusColor = Color.HotPink;
            ctbKullaniciAdi.BorderRadius = 5;
            ctbKullaniciAdi.BorderSize = 1;
            ctbKullaniciAdi.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbKullaniciAdi.ForeColor = Color.Black;
            ctbKullaniciAdi.isPlaceHolder = true;
            ctbKullaniciAdi.Location = new Point(55, 61);
            ctbKullaniciAdi.Multiline = false;
            ctbKullaniciAdi.Name = "ctbKullaniciAdi";
            ctbKullaniciAdi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbKullaniciAdi.PasswordChar = false;
            ctbKullaniciAdi.PlaceholderColor = Color.DarkGray;
            ctbKullaniciAdi.PlaceholderText = "Kullanıcı Adı";
            ctbKullaniciAdi.ReadOnly = false;
            ctbKullaniciAdi.SelectionStart = 0;
            ctbKullaniciAdi.Size = new Size(290, 32);
            ctbKullaniciAdi.TabIndex = 103;
            ctbKullaniciAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbKullaniciAdi.TextCustom = "";
            ctbKullaniciAdi.UnderlinedStyle = false;
            ctbKullaniciAdi.KeyPress += KullaniciGiris_KeyPress;
            // 
            // ctbSifre
            // 
            ctbSifre.Anchor = System.Windows.Forms.AnchorStyles.None;
            ctbSifre.BackColor = Color.White;
            ctbSifre.BorderColor = Color.Silver;
            ctbSifre.BorderFocusColor = Color.HotPink;
            ctbSifre.BorderRadius = 5;
            ctbSifre.BorderSize = 1;
            ctbSifre.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbSifre.ForeColor = Color.Black;
            ctbSifre.isPlaceHolder = true;
            ctbSifre.Location = new Point(55, 99);
            ctbSifre.Multiline = false;
            ctbSifre.Name = "ctbSifre";
            ctbSifre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbSifre.PasswordChar = true;
            ctbSifre.PlaceholderColor = Color.DarkGray;
            ctbSifre.PlaceholderText = "Şifre";
            ctbSifre.ReadOnly = false;
            ctbSifre.SelectionStart = 0;
            ctbSifre.Size = new Size(290, 32);
            ctbSifre.TabIndex = 104;
            ctbSifre.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbSifre.TextCustom = "";
            ctbSifre.UnderlinedStyle = false;
            ctbSifre.KeyPress += KullaniciGiris_KeyPress;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = Color.Firebrick;
            headerPanel1.Baslik = "Kullanıcı Giriş";
            headerPanel1.Location = new Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new Size(421, 32);
            headerPanel1.TabIndex = 105;
            // 
            // btnSifreDegistir
            // 
            btnSifreDegistir.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnSifreDegistir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnSifreDegistir.BackColor = Color.Transparent;
            btnSifreDegistir.BorderColor = Color.Black;
            btnSifreDegistir.BorderSize = 0;
            btnSifreDegistir.CornerRadius = 20;
            btnSifreDegistir.FlatAppearance.BorderSize = 0;
            btnSifreDegistir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSifreDegistir.ForeColor = Color.White;
            btnSifreDegistir.GradientColor1 = Color.DodgerBlue;
            btnSifreDegistir.GradientColor2 = Color.MidnightBlue;
            btnSifreDegistir.HoverColor1 = Color.RoyalBlue;
            btnSifreDegistir.HoverColor2 = Color.Navy;
            btnSifreDegistir.IconChar = FontAwesome.Sharp.IconChar.Key;
            btnSifreDegistir.IconColor = Color.White;
            btnSifreDegistir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSifreDegistir.IconSize = 36;
            btnSifreDegistir.Location = new Point(5, 36);
            btnSifreDegistir.Name = "btnSifreDegistir";
            btnSifreDegistir.Size = new Size(40, 38);
            btnSifreDegistir.TabIndex = 106;
            btnSifreDegistir.UseVisualStyleBackColor = false;
            btnSifreDegistir.Click += btnSifreDegistir_Click;
            // 
            // UserLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(421, 202);
            Controls.Add(btnSifreDegistir);
            Controls.Add(headerPanel1);
            Controls.Add(ctbSifre);
            Controls.Add(ctbKullaniciAdi);
            Controls.Add(labelUyariSifre);
            Controls.Add(labelUyariKullaniciAdi);
            Controls.Add(roundedButtonLogin);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserLogin";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "KullaniciGiris";
            Load += UserLogin_Load;
            KeyPress += KullaniciGiris_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CustomControls.RoundedButton roundedButtonLogin;
        private System.Windows.Forms.Label labelUyariSifre;
        private System.Windows.Forms.Label labelUyariKullaniciAdi;
		private CustomTextBox customTextBoxYeniSifre;
		private CustomTextBox customTextBoxYeniSifreTekrar;
		private System.Windows.Forms.Label labelUyariYeniSifre;
		private System.Windows.Forms.Label labelUyariYeniSifreTekrar;
		public void InitializeComponentsNewPassword()
		{
			customTextBoxYeniSifre = new CustomTextBox();
			customTextBoxYeniSifreTekrar = new CustomTextBox();
			labelUyariYeniSifre = new System.Windows.Forms.Label();
			labelUyariYeniSifreTekrar = new System.Windows.Forms.Label();
			newPasswordMode = true;
			this.Height = this.Height + 126;
			customTextBoxYeniSifre.PlaceholderText = "Yeni Şifre";
			customTextBoxYeniSifre.Location = new Point(ctbSifre.Location.X, ctbSifre.Location.Y + 42);
			customTextBoxYeniSifre.Width = ctbSifre.Width;
			customTextBoxYeniSifre.TextChanged += PasswordChar;
			this.Controls.Add(customTextBoxYeniSifre);

			customTextBoxYeniSifreTekrar.PlaceholderText = "Yeni Şifre tekrar";
			customTextBoxYeniSifreTekrar.Location = new Point(customTextBoxYeniSifre.Location.X, customTextBoxYeniSifre.Location.Y + 42);
			customTextBoxYeniSifreTekrar.Width = ctbSifre.Width;
			customTextBoxYeniSifreTekrar.TextChanged += PasswordChar;
			this.Controls.Add(customTextBoxYeniSifreTekrar);

			labelUyariYeniSifre.Location = new Point(customTextBoxYeniSifre.Location.X + customTextBoxYeniSifre.Width + 2, customTextBoxYeniSifre.Location.Y);
			labelUyariYeniSifre.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
			labelUyariYeniSifre.ForeColor = Color.Red;
			labelUyariYeniSifre.Width = 200;
			roundedButtonLogin.Location = new Point(roundedButtonLogin.Location.X, customTextBoxYeniSifreTekrar.Location.Y + 42);
			this.Controls.Add(labelUyariYeniSifre);

			labelUyariYeniSifreTekrar.Location = new Point(customTextBoxYeniSifreTekrar.Location.X + customTextBoxYeniSifre.Width + 2, customTextBoxYeniSifreTekrar.Location.Y);
			labelUyariYeniSifreTekrar.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
			labelUyariYeniSifreTekrar.ForeColor = Color.Red;
			labelUyariYeniSifreTekrar.Width = 200;
			roundedButtonLogin.Location = new Point(roundedButtonLogin.Location.X, customTextBoxYeniSifreTekrar.Location.Y + 42);
			this.Controls.Add(labelUyariYeniSifreTekrar);
        }

        private CustomTextBox ctbKullaniciAdi;
        private CustomTextBox ctbSifre;
        private HeaderPanel headerPanel1;
        private RoundedIconButton btnSifreDegistir;
    }
    
}