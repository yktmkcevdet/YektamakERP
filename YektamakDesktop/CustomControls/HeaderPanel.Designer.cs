namespace YektamakDesktop.CustomControls
{
    partial class HeaderPanel
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeaderPanel));
            pnlHdr = new System.Windows.Forms.Panel();
            btnFullScreen = new RoundedButton();
            pictureBoxLogo = new System.Windows.Forms.PictureBox();
            btnClose = new RoundedButton();
            btnMinimize = new RoundedButton();
            btnHelp = new RoundedButton();
            lblHdr = new System.Windows.Forms.Label();
            pnlHdr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlHdr
            // 
            pnlHdr.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlHdr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            pnlHdr.BackColor = System.Drawing.Color.SteelBlue;
            pnlHdr.Controls.Add(btnFullScreen);
            pnlHdr.Controls.Add(pictureBoxLogo);
            pnlHdr.Controls.Add(btnClose);
            pnlHdr.Controls.Add(btnMinimize);
            pnlHdr.Controls.Add(btnHelp);
            pnlHdr.Controls.Add(lblHdr);
            pnlHdr.Location = new System.Drawing.Point(0, 0);
            pnlHdr.Name = "pnlHdr";
            pnlHdr.Size = new System.Drawing.Size(418, 25);
            pnlHdr.TabIndex = 8;
            pnlHdr.MouseDown += panelHeader_MouseDown;
            pnlHdr.MouseMove += panelHeader_MouseMove;
            pnlHdr.MouseUp += panelHeader_MouseUp;
            // 
            // btnFullScreen
            // 
            btnFullScreen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnFullScreen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnFullScreen.BackColor = System.Drawing.Color.DodgerBlue;
            btnFullScreen.BackgroundColor = System.Drawing.Color.Firebrick;
            btnFullScreen.BorderColor = System.Drawing.Color.Black;
            btnFullScreen.BorderSize = 0;
            btnFullScreen.CornerRadius = 10;
            btnFullScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            btnFullScreen.FlatAppearance.BorderSize = 0;
            btnFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFullScreen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            btnFullScreen.ForeColor = System.Drawing.Color.White;
            btnFullScreen.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnFullScreen.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnFullScreen.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnFullScreen.HoverColor2 = System.Drawing.Color.Navy;
            btnFullScreen.Icon = null;
            btnFullScreen.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnFullScreen.Location = new System.Drawing.Point(351, 2);
            btnFullScreen.Margin = new System.Windows.Forms.Padding(0);
            btnFullScreen.Name = "btnFullScreen";
            btnFullScreen.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            btnFullScreen.Size = new System.Drawing.Size(20, 20);
            btnFullScreen.TabIndex = 105;
            btnFullScreen.Text = "■";
            btnFullScreen.TextColor = System.Drawing.Color.White;
            btnFullScreen.UseVisualStyleBackColor = false;
            btnFullScreen.Click += btnFullScreen_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBoxLogo.Image = (System.Drawing.Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new System.Drawing.Point(-2, 2);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new System.Drawing.Size(32, 21);
            pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 104;
            pictureBoxLogo.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.BackColor = System.Drawing.Color.DodgerBlue;
            btnClose.BackgroundColor = System.Drawing.Color.Firebrick;
            btnClose.BorderColor = System.Drawing.Color.Black;
            btnClose.BorderSize = 0;
            btnClose.CornerRadius = 10;
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnClose.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnClose.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnClose.HoverColor2 = System.Drawing.Color.Navy;
            btnClose.Icon = null;
            btnClose.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnClose.Location = new System.Drawing.Point(395, 2);
            btnClose.Margin = new System.Windows.Forms.Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            btnClose.Size = new System.Drawing.Size(20, 20);
            btnClose.TabIndex = 103;
            btnClose.Text = "X";
            btnClose.TextColor = System.Drawing.Color.White;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += roundedButton4_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnMinimize.BackColor = System.Drawing.Color.DodgerBlue;
            btnMinimize.BackgroundColor = System.Drawing.Color.Firebrick;
            btnMinimize.BorderColor = System.Drawing.Color.Black;
            btnMinimize.BorderSize = 0;
            btnMinimize.CornerRadius = 10;
            btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            btnMinimize.ForeColor = System.Drawing.Color.White;
            btnMinimize.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnMinimize.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnMinimize.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnMinimize.HoverColor2 = System.Drawing.Color.Navy;
            btnMinimize.Icon = null;
            btnMinimize.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnMinimize.Location = new System.Drawing.Point(373, 2);
            btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            btnMinimize.Size = new System.Drawing.Size(20, 20);
            btnMinimize.TabIndex = 101;
            btnMinimize.Text = "-";
            btnMinimize.TextColor = System.Drawing.Color.White;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnHelp
            // 
            btnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnHelp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnHelp.BackColor = System.Drawing.Color.DodgerBlue;
            btnHelp.BackgroundColor = System.Drawing.Color.Firebrick;
            btnHelp.BorderColor = System.Drawing.Color.Black;
            btnHelp.BorderSize = 0;
            btnHelp.CornerRadius = 10;
            btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnHelp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            btnHelp.ForeColor = System.Drawing.Color.White;
            btnHelp.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnHelp.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnHelp.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnHelp.HoverColor2 = System.Drawing.Color.Navy;
            btnHelp.Icon = null;
            btnHelp.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnHelp.Location = new System.Drawing.Point(329, 2);
            btnHelp.Margin = new System.Windows.Forms.Padding(0);
            btnHelp.Name = "btnHelp";
            btnHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            btnHelp.Size = new System.Drawing.Size(20, 20);
            btnHelp.TabIndex = 102;
            btnHelp.Text = "?";
            btnHelp.TextColor = System.Drawing.Color.White;
            btnHelp.UseVisualStyleBackColor = false;
            // 
            // lblHdr
            // 
            lblHdr.AutoSize = true;
            lblHdr.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            lblHdr.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lblHdr.Location = new System.Drawing.Point(29, 7);
            lblHdr.Name = "lblHdr";
            lblHdr.Size = new System.Drawing.Size(48, 13);
            lblHdr.TabIndex = 1;
            lblHdr.Text = "Caption";
            // 
            // HeaderPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(pnlHdr);
            Margin = new System.Windows.Forms.Padding(1);
            Name = "HeaderPanel";
            Padding = new System.Windows.Forms.Padding(1);
            Size = new System.Drawing.Size(418, 25);
            MouseDown += panelHeader_MouseDown;
            MouseMove += panelHeader_MouseMove;
            MouseUp += panelHeader_MouseUp;
            pnlHdr.ResumeLayout(false);
            pnlHdr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHdr;
        private System.Windows.Forms.Label lblHdr;
        private RoundedButton btnClose;
        private RoundedButton btnMinimize;
        private RoundedButton btnHelp;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private RoundedButton btnFullScreen;
    }
}
