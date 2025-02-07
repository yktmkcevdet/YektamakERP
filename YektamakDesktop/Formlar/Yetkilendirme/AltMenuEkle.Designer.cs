namespace YektamakDesktop.Formlar.Yetkilendirme
{
    partial class AltMenuEkle
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
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            comboListBoxAnaMenu = new CustomControls.CustomComboListBox();
            comboListBoxForm = new CustomControls.CustomComboListBox();
            customTextBoxMenuAdi = new CustomControls.CustomTextBox();
            rButtonKaydet = new CustomControls.RoundedButton();
            rButtonKapat = new CustomControls.RoundedButton();
            label2 = new System.Windows.Forms.Label();
            labelAnaMenu = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            labelForm = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            labelMenuAdi = new System.Windows.Forms.Label();
            labelUyariAnaMenu = new System.Windows.Forms.Label();
            labelUyariFormAdi = new System.Windows.Forms.Label();
            labelUyariMenuAdi = new System.Windows.Forms.Label();
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
            panelHeader.Location = new System.Drawing.Point(1, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(671, 56);
            panelHeader.TabIndex = 2;
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
            buttonClose.Location = new System.Drawing.Point(624, 9);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(40, 38);
            buttonClose.TabIndex = 103;
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
            buttonHelp.Location = new System.Drawing.Point(544, 9);
            buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonHelp.Size = new System.Drawing.Size(40, 38);
            buttonHelp.TabIndex = 102;
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
            buttomMinimize.Location = new System.Drawing.Point(584, 9);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(40, 38);
            buttomMinimize.TabIndex = 101;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = System.Drawing.Color.Red;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(3, 10);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(151, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Alt Menü Ekle";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboListBoxAnaMenu
            // 
            comboListBoxAnaMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxAnaMenu.ListBoxVisualSize = 5;
            comboListBoxAnaMenu.Location = new System.Drawing.Point(177, 89);
            comboListBoxAnaMenu.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxAnaMenu.Name = "comboListBoxAnaMenu";
            comboListBoxAnaMenu.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxAnaMenu.Size = new System.Drawing.Size(188, 36);
            comboListBoxAnaMenu.TabIndex = 54;
            // 
            // comboListBoxForm
            // 
            comboListBoxForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxForm.ListBoxVisualSize = 5;
            comboListBoxForm.Location = new System.Drawing.Point(177, 127);
            comboListBoxForm.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxForm.Name = "comboListBoxForm";
            comboListBoxForm.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxForm.Size = new System.Drawing.Size(294, 36);
            comboListBoxForm.TabIndex = 55;
            // 
            // customTextBoxMenuAdi
            // 
            customTextBoxMenuAdi.BackColor = System.Drawing.Color.White;
            customTextBoxMenuAdi.BorderColor = System.Drawing.Color.MediumSlateBlue;
            customTextBoxMenuAdi.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxMenuAdi.BorderRadius = 0;
            customTextBoxMenuAdi.BorderSize = 2;
            customTextBoxMenuAdi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            customTextBoxMenuAdi.ForeColor = System.Drawing.Color.Black;
            customTextBoxMenuAdi.Location = new System.Drawing.Point(179, 163);
            customTextBoxMenuAdi.Multiline = false;
            customTextBoxMenuAdi.Name = "customTextBoxMenuAdi";
            customTextBoxMenuAdi.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            customTextBoxMenuAdi.PasswordChar = false;
            customTextBoxMenuAdi.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxMenuAdi.PlaceholderText = "";
            customTextBoxMenuAdi.ReadOnly = false;
            customTextBoxMenuAdi.SelectionStart = 0;
            customTextBoxMenuAdi.Size = new System.Drawing.Size(250, 32);
            customTextBoxMenuAdi.TabIndex = 56;
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
            rButtonKaydet.Location = new System.Drawing.Point(13, 228);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new System.Drawing.Size(150, 66);
            rButtonKaydet.TabIndex = 57;
            rButtonKaydet.Text = "KAYDET";
            rButtonKaydet.TextColor = System.Drawing.Color.White;
            rButtonKaydet.UseVisualStyleBackColor = false;
            rButtonKaydet.Click += rButtonKaydet_Click;
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
            rButtonKapat.Location = new System.Drawing.Point(279, 228);
            rButtonKapat.Name = "rButtonKapat";
            rButtonKapat.Size = new System.Drawing.Size(150, 66);
            rButtonKapat.TabIndex = 58;
            rButtonKapat.Text = "KAPAT";
            rButtonKapat.TextColor = System.Drawing.Color.White;
            rButtonKapat.UseVisualStyleBackColor = false;
            rButtonKapat.Click += rButtonKapat_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(155, 89);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(18, 30);
            label2.TabIndex = 60;
            label2.Text = ":";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAnaMenu
            // 
            labelAnaMenu.AutoSize = true;
            labelAnaMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelAnaMenu.Location = new System.Drawing.Point(13, 89);
            labelAnaMenu.Name = "labelAnaMenu";
            labelAnaMenu.Size = new System.Drawing.Size(110, 30);
            labelAnaMenu.TabIndex = 59;
            labelAnaMenu.Text = "Ana Menü";
            labelAnaMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(155, 127);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(18, 30);
            label1.TabIndex = 62;
            label1.Text = ":";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            labelForm.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelForm.Location = new System.Drawing.Point(13, 127);
            labelForm.Name = "labelForm";
            labelForm.Size = new System.Drawing.Size(102, 30);
            labelForm.TabIndex = 61;
            labelForm.Text = "Form Adı";
            labelForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(155, 163);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(18, 30);
            label4.TabIndex = 64;
            label4.Text = ":";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMenuAdi
            // 
            labelMenuAdi.AutoSize = true;
            labelMenuAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelMenuAdi.Location = new System.Drawing.Point(13, 163);
            labelMenuAdi.Name = "labelMenuAdi";
            labelMenuAdi.Size = new System.Drawing.Size(105, 30);
            labelMenuAdi.TabIndex = 63;
            labelMenuAdi.Text = "Menü Adı";
            labelMenuAdi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUyariAnaMenu
            // 
            labelUyariAnaMenu.AutoSize = true;
            labelUyariAnaMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariAnaMenu.ForeColor = System.Drawing.Color.Red;
            labelUyariAnaMenu.Location = new System.Drawing.Point(482, 93);
            labelUyariAnaMenu.Name = "labelUyariAnaMenu";
            labelUyariAnaMenu.Size = new System.Drawing.Size(0, 15);
            labelUyariAnaMenu.TabIndex = 91;
            // 
            // labelUyariFormAdi
            // 
            labelUyariFormAdi.AutoSize = true;
            labelUyariFormAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariFormAdi.ForeColor = System.Drawing.Color.Red;
            labelUyariFormAdi.Location = new System.Drawing.Point(482, 135);
            labelUyariFormAdi.Name = "labelUyariFormAdi";
            labelUyariFormAdi.Size = new System.Drawing.Size(0, 15);
            labelUyariFormAdi.TabIndex = 92;
            // 
            // labelUyariMenuAdi
            // 
            labelUyariMenuAdi.AutoSize = true;
            labelUyariMenuAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariMenuAdi.ForeColor = System.Drawing.Color.Red;
            labelUyariMenuAdi.Location = new System.Drawing.Point(482, 172);
            labelUyariMenuAdi.Name = "labelUyariMenuAdi";
            labelUyariMenuAdi.Size = new System.Drawing.Size(0, 15);
            labelUyariMenuAdi.TabIndex = 93;
            // 
            // AltMenuEkle
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(672, 310);
            Controls.Add(labelUyariMenuAdi);
            Controls.Add(labelUyariFormAdi);
            Controls.Add(labelUyariAnaMenu);
            Controls.Add(label4);
            Controls.Add(labelMenuAdi);
            Controls.Add(label1);
            Controls.Add(labelForm);
            Controls.Add(label2);
            Controls.Add(labelAnaMenu);
            Controls.Add(rButtonKapat);
            Controls.Add(rButtonKaydet);
            Controls.Add(customTextBoxMenuAdi);
            Controls.Add(comboListBoxForm);
            Controls.Add(comboListBoxAnaMenu);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "AltMenuEkle";
            Text = "AltMenuEkle";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.CustomComboListBox comboListBoxAnaMenu;
        private CustomControls.CustomComboListBox comboListBoxForm;
        private CustomControls.CustomTextBox customTextBoxMenuAdi;
        private CustomControls.RoundedButton rButtonKaydet;
        private CustomControls.RoundedButton rButtonKapat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAnaMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelForm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelMenuAdi;
        private System.Windows.Forms.Label labelUyariAnaMenu;
        private System.Windows.Forms.Label labelUyariFormAdi;
        private System.Windows.Forms.Label labelUyariMenuAdi;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
    }
}