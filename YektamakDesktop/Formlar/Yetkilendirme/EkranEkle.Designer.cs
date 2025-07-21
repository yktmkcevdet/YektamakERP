namespace YektamakDesktop.Formlar.Yetkilendirme
{
    partial class EkranEkle
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
            clbFormAd = new YektamakDesktop.CustomControls.CustomComboListBox();
            ctbMenuAd = new YektamakDesktop.CustomControls.CustomTextBox();
            clbIcon = new YektamakDesktop.CustomControls.CustomComboListBox();
            roundedIconButton1 = new YektamakDesktop.CustomControls.RoundedIconButton();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            rButtonKaydet = new YektamakDesktop.CustomControls.CustomButtonSave();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ctbDtoName = new YektamakDesktop.CustomControls.CustomTextBox();
            ID = new System.Windows.Forms.Label();
            ctbId = new YektamakDesktop.CustomControls.CustomTextBox();
            SuspendLayout();
            // 
            // clbFormAd
            // 
            clbFormAd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbFormAd.ListBoxVisualSize = 5;
            clbFormAd.Location = new System.Drawing.Point(126, 89);
            clbFormAd.Margin = new System.Windows.Forms.Padding(1);
            clbFormAd.Name = "clbFormAd";
            clbFormAd.Padding = new System.Windows.Forms.Padding(1);
            clbFormAd.selectedDataRowId = null;
            clbFormAd.selectedDataRowValue = null;
            clbFormAd.Size = new System.Drawing.Size(251, 36);
            clbFormAd.TabIndex = 4;
            // 
            // ctbMenuAd
            // 
            ctbMenuAd.BackColor = System.Drawing.Color.White;
            ctbMenuAd.BorderColor = System.Drawing.Color.Silver;
            ctbMenuAd.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbMenuAd.BorderRadius = 5;
            ctbMenuAd.BorderSize = 2;
            ctbMenuAd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbMenuAd.ForeColor = System.Drawing.Color.Black;
            ctbMenuAd.isPlaceHolder = false;
            ctbMenuAd.Location = new System.Drawing.Point(127, 131);
            ctbMenuAd.Multiline = false;
            ctbMenuAd.Name = "ctbMenuAd";
            ctbMenuAd.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbMenuAd.PasswordChar = false;
            ctbMenuAd.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbMenuAd.PlaceholderText = "";
            ctbMenuAd.ReadOnly = false;
            ctbMenuAd.SelectionStart = 0;
            ctbMenuAd.Size = new System.Drawing.Size(250, 32);
            ctbMenuAd.TabIndex = 5;
            ctbMenuAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbMenuAd.TextCustom = "";
            ctbMenuAd.UnderlinedStyle = false;
            // 
            // clbIcon
            // 
            clbIcon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbIcon.ListBoxVisualSize = 5;
            clbIcon.Location = new System.Drawing.Point(127, 167);
            clbIcon.Margin = new System.Windows.Forms.Padding(1);
            clbIcon.Name = "clbIcon";
            clbIcon.Padding = new System.Windows.Forms.Padding(1);
            clbIcon.selectedDataRowId = null;
            clbIcon.selectedDataRowValue = null;
            clbIcon.Size = new System.Drawing.Size(251, 36);
            clbIcon.TabIndex = 23;
            clbIcon.SelectedIndexChanged += customComboListBoxIcon_SelectedIndexChanged;
            // 
            // roundedIconButton1
            // 
            roundedIconButton1.BackColor = System.Drawing.Color.Transparent;
            roundedIconButton1.BorderColor = System.Drawing.Color.Black;
            roundedIconButton1.BorderSize = 0;
            roundedIconButton1.CornerRadius = 10;
            roundedIconButton1.FlatAppearance.BorderSize = 0;
            roundedIconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedIconButton1.ForeColor = System.Drawing.Color.White;
            roundedIconButton1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedIconButton1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedIconButton1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedIconButton1.HoverColor2 = System.Drawing.Color.Navy;
            roundedIconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            roundedIconButton1.IconColor = System.Drawing.Color.Black;
            roundedIconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            roundedIconButton1.IconSize = 24;
            roundedIconButton1.Location = new System.Drawing.Point(128, 245);
            roundedIconButton1.Name = "roundedIconButton1";
            roundedIconButton1.Size = new System.Drawing.Size(75, 40);
            roundedIconButton1.TabIndex = 25;
            roundedIconButton1.UseVisualStyleBackColor = true;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Ekran Ekle";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(422, 32);
            headerPanel1.TabIndex = 26;
            // 
            // rButtonKaydet
            // 
            rButtonKaydet.BackColor = System.Drawing.Color.Transparent;
            rButtonKaydet.Location = new System.Drawing.Point(272, 261);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new System.Drawing.Size(106, 46);
            rButtonKaydet.TabIndex = 27;
            rButtonKaydet.SaveButtonClick += rButtonKaydet_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(41, 97);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 15);
            label1.TabIndex = 28;
            label1.Text = "Form Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(41, 136);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 15);
            label2.TabIndex = 29;
            label2.Text = "Ekran Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(41, 173);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(30, 15);
            label3.TabIndex = 30;
            label3.Text = "Icon";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(41, 217);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(47, 15);
            label4.TabIndex = 32;
            label4.Text = "Dto Adı";
            // 
            // ctbDtoName
            // 
            ctbDtoName.BackColor = System.Drawing.Color.White;
            ctbDtoName.BorderColor = System.Drawing.Color.Silver;
            ctbDtoName.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbDtoName.BorderRadius = 5;
            ctbDtoName.BorderSize = 2;
            ctbDtoName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbDtoName.ForeColor = System.Drawing.Color.Black;
            ctbDtoName.isPlaceHolder = false;
            ctbDtoName.Location = new System.Drawing.Point(128, 207);
            ctbDtoName.Multiline = false;
            ctbDtoName.Name = "ctbDtoName";
            ctbDtoName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbDtoName.PasswordChar = false;
            ctbDtoName.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbDtoName.PlaceholderText = "";
            ctbDtoName.ReadOnly = false;
            ctbDtoName.SelectionStart = 0;
            ctbDtoName.Size = new System.Drawing.Size(250, 32);
            ctbDtoName.TabIndex = 31;
            ctbDtoName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbDtoName.TextCustom = "";
            ctbDtoName.UnderlinedStyle = false;
            // 
            // ID
            // 
            ID.AutoSize = true;
            ID.Location = new System.Drawing.Point(41, 63);
            ID.Name = "ID";
            ID.Size = new System.Drawing.Size(17, 15);
            ID.TabIndex = 34;
            ID.Text = "Id";
            // 
            // ctbId
            // 
            ctbId.BackColor = System.Drawing.Color.White;
            ctbId.BorderColor = System.Drawing.Color.Silver;
            ctbId.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbId.BorderRadius = 5;
            ctbId.BorderSize = 2;
            ctbId.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbId.ForeColor = System.Drawing.Color.Black;
            ctbId.isPlaceHolder = false;
            ctbId.Location = new System.Drawing.Point(128, 53);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbId.PasswordChar = false;
            ctbId.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbId.PlaceholderText = "";
            ctbId.ReadOnly = false;
            ctbId.SelectionStart = 0;
            ctbId.Size = new System.Drawing.Size(59, 32);
            ctbId.TabIndex = 33;
            ctbId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbId.TextCustom = "";
            ctbId.UnderlinedStyle = false;
            // 
            // EkranEkle
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(422, 319);
            Controls.Add(ID);
            Controls.Add(ctbId);
            Controls.Add(label4);
            Controls.Add(ctbDtoName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(rButtonKaydet);
            Controls.Add(headerPanel1);
            Controls.Add(roundedIconButton1);
            Controls.Add(clbIcon);
            Controls.Add(ctbMenuAd);
            Controls.Add(clbFormAd);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "EkranEkle";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "EkranEkle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CustomControls.CustomComboListBox clbFormAd;
        private CustomControls.CustomTextBox ctbMenuAd;
        private CustomControls.CustomComboListBox clbIcon;
        private CustomControls.RoundedIconButton roundedIconButton1;
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomButtonSave rButtonKaydet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBox ctbDtoName;
        private System.Windows.Forms.Label ID;
        private CustomControls.CustomTextBox ctbId;
    }
}