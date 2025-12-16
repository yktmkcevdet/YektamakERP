namespace YektamakDesktop.Formlar.Genel
{
    partial class MailAyarlarim
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
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            ctbMailId = new YektamakDesktop.CustomControls.CustomTextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ctbKullaniciAdi = new YektamakDesktop.CustomControls.CustomTextBox();
            label3 = new System.Windows.Forms.Label();
            ctbSifre = new YektamakDesktop.CustomControls.CustomTextBox();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            label4 = new System.Windows.Forms.Label();
            ctbSmtpServer = new YektamakDesktop.CustomControls.CustomTextBox();
            label5 = new System.Windows.Forms.Label();
            ctbPort = new YektamakDesktop.CustomControls.CustomTextBox();
            chkSSL = new System.Windows.Forms.CheckBox();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Mail Ayarlarım";
            headerPanel1.Location = new System.Drawing.Point(-1, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(484, 25);
            headerPanel1.TabIndex = 0;
            // 
            // ctbMailId
            // 
            ctbMailId.BackColor = System.Drawing.Color.White;
            ctbMailId.BorderColor = System.Drawing.Color.Silver;
            ctbMailId.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbMailId.BorderSize = 1;
            ctbMailId.Enabled = false;
            ctbMailId.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbMailId.ForeColor = System.Drawing.Color.Black;
            ctbMailId.Location = new System.Drawing.Point(143, 74);
            ctbMailId.Margin = new System.Windows.Forms.Padding(1);
            ctbMailId.Multiline = false;
            ctbMailId.Name = "ctbMailId";
            ctbMailId.Padding = new System.Windows.Forms.Padding(3);
            ctbMailId.PasswordChar = false;
            ctbMailId.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbMailId.PlaceholderText = "";
            ctbMailId.ReadOnly = false;
            ctbMailId.SelectionStart = 0;
            ctbMailId.Size = new System.Drawing.Size(262, 25);
            ctbMailId.TabIndex = 1;
            ctbMailId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbMailId.TextCustom = "";
            ctbMailId.UnderlinedStyle = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(67, 77);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 15);
            label1.TabIndex = 2;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(67, 104);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(73, 15);
            label2.TabIndex = 4;
            label2.Text = "Kullanıcı Adı";
            // 
            // ctbKullaniciAdi
            // 
            ctbKullaniciAdi.BackColor = System.Drawing.Color.White;
            ctbKullaniciAdi.BorderColor = System.Drawing.Color.Silver;
            ctbKullaniciAdi.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbKullaniciAdi.BorderSize = 1;
            ctbKullaniciAdi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbKullaniciAdi.ForeColor = System.Drawing.Color.Black;
            ctbKullaniciAdi.Location = new System.Drawing.Point(143, 101);
            ctbKullaniciAdi.Margin = new System.Windows.Forms.Padding(1);
            ctbKullaniciAdi.Multiline = false;
            ctbKullaniciAdi.Name = "ctbKullaniciAdi";
            ctbKullaniciAdi.Padding = new System.Windows.Forms.Padding(3);
            ctbKullaniciAdi.PasswordChar = false;
            ctbKullaniciAdi.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbKullaniciAdi.PlaceholderText = "";
            ctbKullaniciAdi.ReadOnly = false;
            ctbKullaniciAdi.SelectionStart = 0;
            ctbKullaniciAdi.Size = new System.Drawing.Size(262, 25);
            ctbKullaniciAdi.TabIndex = 3;
            ctbKullaniciAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbKullaniciAdi.TextCustom = "";
            ctbKullaniciAdi.UnderlinedStyle = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(67, 131);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(30, 15);
            label3.TabIndex = 6;
            label3.Text = "Şifre";
            // 
            // ctbSifre
            // 
            ctbSifre.BackColor = System.Drawing.Color.White;
            ctbSifre.BorderColor = System.Drawing.Color.Silver;
            ctbSifre.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbSifre.BorderSize = 1;
            ctbSifre.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbSifre.ForeColor = System.Drawing.Color.Black;
            ctbSifre.Location = new System.Drawing.Point(143, 128);
            ctbSifre.Margin = new System.Windows.Forms.Padding(1);
            ctbSifre.Multiline = false;
            ctbSifre.Name = "ctbSifre";
            ctbSifre.Padding = new System.Windows.Forms.Padding(3);
            ctbSifre.PasswordChar = false;
            ctbSifre.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbSifre.PlaceholderText = "";
            ctbSifre.ReadOnly = false;
            ctbSifre.SelectionStart = 0;
            ctbSifre.Size = new System.Drawing.Size(262, 25);
            ctbSifre.TabIndex = 5;
            ctbSifre.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbSifre.TextCustom = "";
            ctbSifre.UnderlinedStyle = false;
            // 
            // customButtonSave1
            // 
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(278, 231);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 7;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(67, 158);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(34, 15);
            label4.TabIndex = 9;
            label4.Text = "smtp";
            // 
            // ctbSmtpServer
            // 
            ctbSmtpServer.BackColor = System.Drawing.Color.White;
            ctbSmtpServer.BorderColor = System.Drawing.Color.Silver;
            ctbSmtpServer.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbSmtpServer.BorderSize = 1;
            ctbSmtpServer.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbSmtpServer.ForeColor = System.Drawing.Color.Black;
            ctbSmtpServer.Location = new System.Drawing.Point(143, 155);
            ctbSmtpServer.Margin = new System.Windows.Forms.Padding(1);
            ctbSmtpServer.Multiline = false;
            ctbSmtpServer.Name = "ctbSmtpServer";
            ctbSmtpServer.Padding = new System.Windows.Forms.Padding(3);
            ctbSmtpServer.PasswordChar = false;
            ctbSmtpServer.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbSmtpServer.PlaceholderText = "";
            ctbSmtpServer.ReadOnly = false;
            ctbSmtpServer.SelectionStart = 0;
            ctbSmtpServer.Size = new System.Drawing.Size(262, 25);
            ctbSmtpServer.TabIndex = 8;
            ctbSmtpServer.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbSmtpServer.TextCustom = "smtp-mail.outlook.com";
            ctbSmtpServer.UnderlinedStyle = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(67, 185);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(29, 15);
            label5.TabIndex = 11;
            label5.Text = "port";
            // 
            // ctbPort
            // 
            ctbPort.BackColor = System.Drawing.Color.White;
            ctbPort.BorderColor = System.Drawing.Color.Silver;
            ctbPort.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbPort.BorderSize = 1;
            ctbPort.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbPort.ForeColor = System.Drawing.Color.Black;
            ctbPort.Location = new System.Drawing.Point(143, 182);
            ctbPort.Margin = new System.Windows.Forms.Padding(1);
            ctbPort.Multiline = false;
            ctbPort.Name = "ctbPort";
            ctbPort.Padding = new System.Windows.Forms.Padding(3);
            ctbPort.PasswordChar = false;
            ctbPort.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbPort.PlaceholderText = "";
            ctbPort.ReadOnly = false;
            ctbPort.SelectionStart = 0;
            ctbPort.Size = new System.Drawing.Size(262, 25);
            ctbPort.TabIndex = 10;
            ctbPort.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbPort.TextCustom = "587";
            ctbPort.UnderlinedStyle = false;
            // 
            // chkSSL
            // 
            chkSSL.AutoSize = true;
            chkSSL.Checked = true;
            chkSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            chkSSL.Location = new System.Drawing.Point(143, 211);
            chkSSL.Name = "chkSSL";
            chkSSL.Size = new System.Drawing.Size(44, 19);
            chkSSL.TabIndex = 12;
            chkSSL.Text = "SSL";
            chkSSL.UseVisualStyleBackColor = true;
            // 
            // roundedButton1
            // 
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Black;
            roundedButton1.BorderSize = 0;
            roundedButton1.CornerRadius = 10;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedButton1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedButton1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedButton1.HoverColor2 = System.Drawing.Color.Navy;
            roundedButton1.Icon = null;
            roundedButton1.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton1.Location = new System.Drawing.Point(40, 248);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(150, 40);
            roundedButton1.TabIndex = 13;
            roundedButton1.Text = "Test";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            // 
            // MailAyarlarim
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(483, 318);
            Controls.Add(roundedButton1);
            Controls.Add(chkSSL);
            Controls.Add(label5);
            Controls.Add(ctbPort);
            Controls.Add(label4);
            Controls.Add(ctbSmtpServer);
            Controls.Add(customButtonSave1);
            Controls.Add(label3);
            Controls.Add(ctbSifre);
            Controls.Add(label2);
            Controls.Add(ctbKullaniciAdi);
            Controls.Add(label1);
            Controls.Add(ctbMailId);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "MailAyarlarim";
            Text = "MailAyarlarim";
            Load += async (s,e)=>await MailAyarlarim_Load(s,e);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBox ctbMailId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomTextBox ctbKullaniciAdi;
        private System.Windows.Forms.Label label3;
        private CustomControls.CustomTextBox ctbSifre;
        private CustomControls.CustomButtonSave customButtonSave1;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBox ctbSmtpServer;
        private System.Windows.Forms.Label label5;
        private CustomControls.CustomTextBox ctbPort;
        private System.Windows.Forms.CheckBox chkSSL;
        private CustomControls.RoundedButton roundedButton1;
    }
}