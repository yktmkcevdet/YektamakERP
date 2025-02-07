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
            panelHeader = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            customComboListBoxFormlar = new CustomControls.CustomComboListBox();
            customTextBoxMenuAdi = new CustomControls.CustomTextBox();
            rButtonKaydet = new CustomControls.RoundedButton();
            label9 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            customComboListBoxIcon = new CustomControls.CustomComboListBox();
            label3 = new System.Windows.Forms.Label();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Red;
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(514, 38);
            panelHeader.TabIndex = 3;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Red;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label1.Location = new System.Drawing.Point(37, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(89, 21);
            label1.TabIndex = 107;
            label1.Text = "Ekran Ekle";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = System.Drawing.Color.Red;
            buttonClose.BackgroundColor = System.Drawing.Color.Red;
            buttonClose.BorderColor = System.Drawing.Color.LavenderBlush;
            buttonClose.BorderRadius = 30;
            buttonClose.BorderSize = 2;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonClose.ForeColor = System.Drawing.Color.White;
            buttonClose.Location = new System.Drawing.Point(472, 0);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(30, 30);
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
            buttonHelp.BorderRadius = 30;
            buttonHelp.BorderSize = 2;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonHelp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonHelp.ForeColor = System.Drawing.Color.White;
            buttonHelp.Location = new System.Drawing.Point(404, 0);
            buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonHelp.Size = new System.Drawing.Size(30, 30);
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
            buttomMinimize.BorderRadius = 30;
            buttomMinimize.BorderSize = 2;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttomMinimize.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttomMinimize.ForeColor = System.Drawing.Color.White;
            buttomMinimize.Location = new System.Drawing.Point(438, 0);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(30, 30);
            buttomMinimize.TabIndex = 104;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = System.Drawing.Color.Red;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(40, -23);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(74, 21);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Menuler";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customComboListBoxFormlar
            // 
            customComboListBoxFormlar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxFormlar.ListBoxVisualSize = 5;
            customComboListBoxFormlar.Location = new System.Drawing.Point(183, 87);
            customComboListBoxFormlar.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxFormlar.Name = "customComboListBoxFormlar";
            customComboListBoxFormlar.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxFormlar.Size = new System.Drawing.Size(251, 36);
            customComboListBoxFormlar.TabIndex = 4;
            // 
            // customTextBoxMenuAdi
            // 
            customTextBoxMenuAdi.BackColor = System.Drawing.Color.White;
            customTextBoxMenuAdi.BorderColor = System.Drawing.Color.Silver;
            customTextBoxMenuAdi.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxMenuAdi.BorderRadius = 5;
            customTextBoxMenuAdi.BorderSize = 2;
            customTextBoxMenuAdi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxMenuAdi.ForeColor = System.Drawing.Color.Black;
            customTextBoxMenuAdi.isPlaceHolder = false;
            customTextBoxMenuAdi.Location = new System.Drawing.Point(184, 129);
            customTextBoxMenuAdi.Multiline = false;
            customTextBoxMenuAdi.Name = "customTextBoxMenuAdi";
            customTextBoxMenuAdi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxMenuAdi.PasswordChar = false;
            customTextBoxMenuAdi.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxMenuAdi.PlaceholderText = "";
            customTextBoxMenuAdi.ReadOnly = false;
            customTextBoxMenuAdi.SelectionStart = 0;
            customTextBoxMenuAdi.Size = new System.Drawing.Size(250, 32);
            customTextBoxMenuAdi.TabIndex = 5;
            customTextBoxMenuAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxMenuAdi.TextCustom = "";
            customTextBoxMenuAdi.UnderlinedStyle = false;
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
            rButtonKaydet.Location = new System.Drawing.Point(247, 229);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new System.Drawing.Size(102, 45);
            rButtonKaydet.TabIndex = 20;
            rButtonKaydet.Text = "KAYDET";
            rButtonKaydet.TextColor = System.Drawing.Color.White;
            rButtonKaydet.UseVisualStyleBackColor = false;
            rButtonKaydet.Click += rButtonKaydet_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label9.Location = new System.Drawing.Point(30, 87);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(102, 30);
            label9.TabIndex = 21;
            label9.Text = "Form Adı";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(30, 131);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 30);
            label2.TabIndex = 22;
            label2.Text = "Ekran Adı";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customComboListBoxIcon
            // 
            customComboListBoxIcon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListBoxIcon.ListBoxVisualSize = 5;
            customComboListBoxIcon.Location = new System.Drawing.Point(184, 165);
            customComboListBoxIcon.Margin = new System.Windows.Forms.Padding(1);
            customComboListBoxIcon.Name = "customComboListBoxIcon";
            customComboListBoxIcon.Padding = new System.Windows.Forms.Padding(1);
            customComboListBoxIcon.Size = new System.Drawing.Size(251, 36);
            customComboListBoxIcon.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(30, 173);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(54, 30);
            label3.TabIndex = 24;
            label3.Text = "Icon";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EkranEkle
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(514, 297);
            Controls.Add(label3);
            Controls.Add(customComboListBoxIcon);
            Controls.Add(label2);
            Controls.Add(label9);
            Controls.Add(rButtonKaydet);
            Controls.Add(customTextBoxMenuAdi);
            Controls.Add(customComboListBoxFormlar);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "EkranEkle";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "EkranEkle";
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
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomComboListBox customComboListBoxFormlar;
        private CustomControls.CustomTextBox customTextBoxMenuAdi;
        private CustomControls.RoundedButton rButtonKaydet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomComboListBox customComboListBoxIcon;
        private System.Windows.Forms.Label label3;
    }
}