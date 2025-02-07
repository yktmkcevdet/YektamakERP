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
            buttonClose = new RoundedButton();
            panelHeader = new System.Windows.Forms.Panel();
            buttonHelp = new RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            labelUyariKullaniciAdi = new System.Windows.Forms.Label();
            labelUyariSifre = new System.Windows.Forms.Label();
            customTextBoxKullaniciAdi = new CustomTextBox();
            customTextBoxSifre = new CustomTextBox();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // roundedButtonLogin
            // 
            roundedButtonLogin.BackColor = Color.FromArgb(128, 64, 64);
            roundedButtonLogin.BackgroundColor = Color.FromArgb(128, 64, 64);
            roundedButtonLogin.BorderColor = SystemColors.InactiveBorder;
            roundedButtonLogin.BorderRadius = 20;
            roundedButtonLogin.BorderSize = 3;
            roundedButtonLogin.FlatAppearance.BorderSize = 0;
            roundedButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButtonLogin.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            roundedButtonLogin.ForeColor = Color.White;
            roundedButtonLogin.Location = new Point(131, 137);
            roundedButtonLogin.Name = "roundedButtonLogin";
            roundedButtonLogin.Size = new Size(135, 39);
            roundedButtonLogin.TabIndex = 22;
            roundedButtonLogin.Text = "GİRİŞ";
            roundedButtonLogin.TextColor = Color.White;
            roundedButtonLogin.UseVisualStyleBackColor = false;
            roundedButtonLogin.Click += roundedButtonLogin_Click;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.Red;
            buttonClose.BackgroundColor = Color.Red;
            buttonClose.BorderColor = Color.LavenderBlush;
            buttonClose.BorderRadius = 10;
            buttonClose.BorderSize = 2;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClose.ForeColor = Color.White;
            buttonClose.Location = new Point(380, 2);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new Size(35, 39);
            buttonClose.TabIndex = 98;
            buttonClose.Text = "x";
            buttonClose.TextAlign = ContentAlignment.TopCenter;
            buttonClose.TextColor = Color.White;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Red;
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(423, 45);
            panelHeader.TabIndex = 99;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // buttonHelp
            // 
            buttonHelp.BackColor = Color.Red;
            buttonHelp.BackgroundColor = Color.Red;
            buttonHelp.BorderColor = Color.LavenderBlush;
            buttonHelp.BorderRadius = 10;
            buttonHelp.BorderSize = 2;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonHelp.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonHelp.ForeColor = Color.White;
            buttonHelp.Location = new Point(340, 3);
            buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonHelp.Size = new Size(40, 38);
            buttonHelp.TabIndex = 103;
            buttonHelp.Text = "?";
            buttonHelp.TextColor = Color.White;
            buttonHelp.UseVisualStyleBackColor = false;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = Color.Red;
            labelHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeader.ForeColor = SystemColors.ControlLightLight;
            labelHeader.Location = new Point(7, 10);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(44, 21);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Giriş";
            labelHeader.TextAlign = ContentAlignment.MiddleLeft;
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
            // customTextBoxKullaniciAdi
            // 
            customTextBoxKullaniciAdi.BackColor = Color.White;
            customTextBoxKullaniciAdi.BorderColor = Color.Silver;
            customTextBoxKullaniciAdi.BorderFocusColor = Color.HotPink;
            customTextBoxKullaniciAdi.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            customTextBoxKullaniciAdi.ForeColor = Color.Black;
            customTextBoxKullaniciAdi.isPlaceHolder = true;
            customTextBoxKullaniciAdi.Location = new Point(55, 61);
            customTextBoxKullaniciAdi.Multiline = false;
            customTextBoxKullaniciAdi.Name = "customTextBoxKullaniciAdi";
            customTextBoxKullaniciAdi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxKullaniciAdi.PasswordChar = false;
            customTextBoxKullaniciAdi.PlaceholderColor = Color.DarkGray;
            customTextBoxKullaniciAdi.PlaceholderText = "Kullanıcı Adı";
            customTextBoxKullaniciAdi.ReadOnly = false;
            customTextBoxKullaniciAdi.SelectionStart = 0;
            customTextBoxKullaniciAdi.Size = new Size(290, 32);
            customTextBoxKullaniciAdi.TabIndex = 103;
            customTextBoxKullaniciAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxKullaniciAdi.TextCustom = "";
            customTextBoxKullaniciAdi.UnderlinedStyle = false;
            customTextBoxKullaniciAdi.KeyPress += KullaniciGiris_KeyPress;
            // 
            // customTextBoxSifre
            // 
            customTextBoxSifre.BackColor = Color.White;
            customTextBoxSifre.BorderColor = Color.Silver;
            customTextBoxSifre.BorderFocusColor = Color.HotPink;
            customTextBoxSifre.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            customTextBoxSifre.ForeColor = Color.Black;
            customTextBoxSifre.isPlaceHolder = true;
            customTextBoxSifre.Location = new Point(55, 99);
            customTextBoxSifre.Multiline = false;
            customTextBoxSifre.Name = "customTextBoxSifre";
            customTextBoxSifre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxSifre.PasswordChar = true;
            customTextBoxSifre.PlaceholderColor = Color.DarkGray;
            customTextBoxSifre.PlaceholderText = "Şifre";
            customTextBoxSifre.ReadOnly = false;
            customTextBoxSifre.SelectionStart = 0;
            customTextBoxSifre.Size = new Size(290, 32);
            customTextBoxSifre.TabIndex = 104;
            customTextBoxSifre.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxSifre.TextCustom = "";
            customTextBoxSifre.UnderlinedStyle = false;
            customTextBoxSifre.KeyPress += KullaniciGiris_KeyPress;
            // 
            // UserLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(421, 202);
            Controls.Add(customTextBoxSifre);
            Controls.Add(customTextBoxKullaniciAdi);
            Controls.Add(labelUyariSifre);
            Controls.Add(labelUyariKullaniciAdi);
            Controls.Add(panelHeader);
            Controls.Add(roundedButtonLogin);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserLogin";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "KullaniciGiris";
            Load += UserLogin_Load;
            KeyPress += KullaniciGiris_KeyPress;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CustomControls.RoundedButton roundedButtonLogin;
        private CustomControls.RoundedButton buttonClose;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton buttonHelp;
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
			customTextBoxYeniSifre.Location = new Point(customTextBoxSifre.Location.X, customTextBoxSifre.Location.Y + 42);
			customTextBoxYeniSifre.Width = customTextBoxSifre.Width;
			customTextBoxYeniSifre.TextChanged += PasswordChar;
			this.Controls.Add(customTextBoxYeniSifre);

			customTextBoxYeniSifreTekrar.PlaceholderText = "Yeni Şifre tekrar";
			customTextBoxYeniSifreTekrar.Location = new Point(customTextBoxYeniSifre.Location.X, customTextBoxYeniSifre.Location.Y + 42);
			customTextBoxYeniSifreTekrar.Width = customTextBoxSifre.Width;
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

        private CustomTextBox customTextBoxKullaniciAdi;
        private CustomTextBox customTextBoxSifre;
    }
    
}