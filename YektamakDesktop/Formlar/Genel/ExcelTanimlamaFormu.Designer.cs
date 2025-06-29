namespace YektamakDesktop.Formlar.Genel
{
    partial class ExcelTanimlamaFormu
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
            ctxtFormAd = new YektamakDesktop.CustomControls.CustomTextBox();
            ctxtFilePath = new YektamakDesktop.CustomControls.CustomTextBox();
            btnDosyaSec = new YektamakDesktop.CustomControls.RoundedButton();
            btnSave = new YektamakDesktop.CustomControls.RoundedButton();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Excel Form Tanımlama";
            headerPanel1.Location = new System.Drawing.Point(-1, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(803, 32);
            headerPanel1.TabIndex = 0;
            // 
            // ctxtFormAd
            // 
            ctxtFormAd.BackColor = System.Drawing.Color.White;
            ctxtFormAd.BorderColor = System.Drawing.Color.Silver;
            ctxtFormAd.BorderFocusColor = System.Drawing.Color.HotPink;
            ctxtFormAd.BorderRadius = 5;
            ctxtFormAd.BorderSize = 1;
            ctxtFormAd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctxtFormAd.ForeColor = System.Drawing.Color.Black;
            ctxtFormAd.isPlaceHolder = false;
            ctxtFormAd.Location = new System.Drawing.Point(224, 91);
            ctxtFormAd.Multiline = false;
            ctxtFormAd.Name = "ctxtFormAd";
            ctxtFormAd.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctxtFormAd.PasswordChar = false;
            ctxtFormAd.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctxtFormAd.PlaceholderText = "";
            ctxtFormAd.ReadOnly = false;
            ctxtFormAd.SelectionStart = 0;
            ctxtFormAd.Size = new System.Drawing.Size(363, 28);
            ctxtFormAd.TabIndex = 1;
            ctxtFormAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctxtFormAd.TextCustom = "";
            ctxtFormAd.UnderlinedStyle = false;
            // 
            // ctxtFilePath
            // 
            ctxtFilePath.BackColor = System.Drawing.Color.White;
            ctxtFilePath.BorderColor = System.Drawing.Color.Silver;
            ctxtFilePath.BorderFocusColor = System.Drawing.Color.HotPink;
            ctxtFilePath.BorderRadius = 5;
            ctxtFilePath.BorderSize = 1;
            ctxtFilePath.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctxtFilePath.ForeColor = System.Drawing.Color.Black;
            ctxtFilePath.isPlaceHolder = false;
            ctxtFilePath.Location = new System.Drawing.Point(224, 139);
            ctxtFilePath.Multiline = false;
            ctxtFilePath.Name = "ctxtFilePath";
            ctxtFilePath.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctxtFilePath.PasswordChar = false;
            ctxtFilePath.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctxtFilePath.PlaceholderText = "";
            ctxtFilePath.ReadOnly = false;
            ctxtFilePath.SelectionStart = 0;
            ctxtFilePath.Size = new System.Drawing.Size(363, 28);
            ctxtFilePath.TabIndex = 2;
            ctxtFilePath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctxtFilePath.TextCustom = "";
            ctxtFilePath.UnderlinedStyle = false;
            // 
            // btnDosyaSec
            // 
            btnDosyaSec.BackColor = System.Drawing.Color.MediumSlateBlue;
            btnDosyaSec.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            btnDosyaSec.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnDosyaSec.BorderRadius = 8;
            btnDosyaSec.BorderSize = 0;
            btnDosyaSec.FlatAppearance.BorderSize = 0;
            btnDosyaSec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDosyaSec.ForeColor = System.Drawing.Color.White;
            btnDosyaSec.Location = new System.Drawing.Point(593, 139);
            btnDosyaSec.Name = "btnDosyaSec";
            btnDosyaSec.Size = new System.Drawing.Size(35, 28);
            btnDosyaSec.TabIndex = 3;
            btnDosyaSec.Text = "sec";
            btnDosyaSec.TextColor = System.Drawing.Color.White;
            btnDosyaSec.UseVisualStyleBackColor = false;
            btnDosyaSec.Click += btnDosyaSec_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.MediumSlateBlue;
            btnSave.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            btnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnSave.BorderRadius = 8;
            btnSave.BorderSize = 0;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(463, 274);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(96, 32);
            btnSave.TabIndex = 4;
            btnSave.Text = "Kaydet";
            btnSave.TextColor = System.Drawing.Color.White;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // ExcelTanimlamaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(btnDosyaSec);
            Controls.Add(ctxtFilePath);
            Controls.Add(ctxtFormAd);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ExcelTanimlamaFormu";
            Text = "ExcelTanimlamaFormu";
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBox ctxtFormAd;
        private CustomControls.CustomTextBox ctxtFilePath;
        private CustomControls.RoundedButton btnDosyaSec;
        private CustomControls.RoundedButton btnSave;
    }
}