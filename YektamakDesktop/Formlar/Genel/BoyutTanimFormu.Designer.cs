namespace YektamakDesktop.Formlar.Genel
{
    partial class BoyutTanimFormu
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
            ctbId = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            ctbKod = new YektamakDesktop.CustomControls.CustomTextBox();
            ctbAd = new YektamakDesktop.CustomControls.CustomTextBox();
            fcbMalzemeGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbMalzemeAltGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbMalzemeAltGrup2 = new YektamakDesktop.CustomControls.FilterableComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            btnSave = new YektamakDesktop.CustomControls.CustomButtonSave();
            btnNew = new YektamakDesktop.CustomControls.CustomButtonNewRecord();
            ctbKlasor = new YektamakDesktop.CustomControls.CustomTextBox();
            ctbPath = new YektamakDesktop.CustomControls.CustomTextBox();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // ctbId
            // 
            ctbId.BackColor = System.Drawing.SystemColors.Window;
            ctbId.Enabled = false;
            ctbId.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbId.ForeColor = System.Drawing.Color.DimGray;
            ctbId.Location = new System.Drawing.Point(153, 51);
            ctbId.Margin = new System.Windows.Forms.Padding(1);
            ctbId.Name = "ctbId";
            ctbId.OndalikBasamak = 0;
            ctbId.Padding = new System.Windows.Forms.Padding(3);
            ctbId.Size = new System.Drawing.Size(65, 25);
            ctbId.TabIndex = 0;
            ctbId.TextCustom = "0";
            // 
            // ctbKod
            // 
            ctbKod.BackColor = System.Drawing.Color.White;
            ctbKod.BorderColor = System.Drawing.Color.Silver;
            ctbKod.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbKod.BorderSize = 1;
            ctbKod.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbKod.ForeColor = System.Drawing.Color.Black;
            ctbKod.Location = new System.Drawing.Point(153, 78);
            ctbKod.Margin = new System.Windows.Forms.Padding(1);
            ctbKod.Multiline = false;
            ctbKod.Name = "ctbKod";
            ctbKod.Padding = new System.Windows.Forms.Padding(3);
            ctbKod.PasswordChar = false;
            ctbKod.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbKod.PlaceholderText = "";
            ctbKod.ReadOnly = false;
            ctbKod.SelectionStart = 0;
            ctbKod.Size = new System.Drawing.Size(124, 25);
            ctbKod.TabIndex = 1;
            ctbKod.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbKod.TextCustom = "";
            ctbKod.UnderlinedStyle = false;
            // 
            // ctbAd
            // 
            ctbAd.BackColor = System.Drawing.Color.White;
            ctbAd.BorderColor = System.Drawing.Color.Silver;
            ctbAd.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbAd.BorderSize = 1;
            ctbAd.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbAd.ForeColor = System.Drawing.Color.Black;
            ctbAd.Location = new System.Drawing.Point(153, 105);
            ctbAd.Margin = new System.Windows.Forms.Padding(1);
            ctbAd.Multiline = false;
            ctbAd.Name = "ctbAd";
            ctbAd.Padding = new System.Windows.Forms.Padding(3);
            ctbAd.PasswordChar = false;
            ctbAd.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAd.PlaceholderText = "";
            ctbAd.ReadOnly = false;
            ctbAd.SelectionStart = 0;
            ctbAd.Size = new System.Drawing.Size(124, 25);
            ctbAd.TabIndex = 2;
            ctbAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbAd.TextCustom = "";
            ctbAd.UnderlinedStyle = false;
            // 
            // fcbMalzemeGrup
            // 
            fcbMalzemeGrup.BorderColor = System.Drawing.Color.Silver;
            fcbMalzemeGrup.BorderRadius = 8;
            fcbMalzemeGrup.BorderSize = 1;
            fcbMalzemeGrup.DisplayMember = "ad";
            fcbMalzemeGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMalzemeGrup.Location = new System.Drawing.Point(153, 132);
            fcbMalzemeGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbMalzemeGrup.Name = "fcbMalzemeGrup";
            fcbMalzemeGrup.Padding = new System.Windows.Forms.Padding(3);
            fcbMalzemeGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeGrup.ReadOnly = false;
            fcbMalzemeGrup.Size = new System.Drawing.Size(156, 25);
            fcbMalzemeGrup.TabIndex = 3;
            fcbMalzemeGrup.ValueMember = "Id";
            // 
            // fcbMalzemeAltGrup
            // 
            fcbMalzemeAltGrup.BorderColor = System.Drawing.Color.Silver;
            fcbMalzemeAltGrup.BorderRadius = 8;
            fcbMalzemeAltGrup.BorderSize = 1;
            fcbMalzemeAltGrup.DisplayMember = "ad";
            fcbMalzemeAltGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMalzemeAltGrup.Location = new System.Drawing.Point(153, 159);
            fcbMalzemeAltGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbMalzemeAltGrup.Name = "fcbMalzemeAltGrup";
            fcbMalzemeAltGrup.Padding = new System.Windows.Forms.Padding(3);
            fcbMalzemeAltGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeAltGrup.ReadOnly = false;
            fcbMalzemeAltGrup.Size = new System.Drawing.Size(156, 25);
            fcbMalzemeAltGrup.TabIndex = 4;
            fcbMalzemeAltGrup.ValueMember = "Id";
            // 
            // fcbMalzemeAltGrup2
            // 
            fcbMalzemeAltGrup2.BorderColor = System.Drawing.Color.Silver;
            fcbMalzemeAltGrup2.BorderRadius = 8;
            fcbMalzemeAltGrup2.BorderSize = 1;
            fcbMalzemeAltGrup2.DisplayMember = "ad";
            fcbMalzemeAltGrup2.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMalzemeAltGrup2.Location = new System.Drawing.Point(153, 186);
            fcbMalzemeAltGrup2.Margin = new System.Windows.Forms.Padding(1);
            fcbMalzemeAltGrup2.Name = "fcbMalzemeAltGrup2";
            fcbMalzemeAltGrup2.Padding = new System.Windows.Forms.Padding(3);
            fcbMalzemeAltGrup2.PlaceholderText = "Seçiniz...";
            fcbMalzemeAltGrup2.ReadOnly = false;
            fcbMalzemeAltGrup2.Size = new System.Drawing.Size(156, 25);
            fcbMalzemeAltGrup2.TabIndex = 5;
            fcbMalzemeAltGrup2.ValueMember = "Id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(26, 56);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(18, 15);
            label1.TabIndex = 6;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(26, 83);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(29, 15);
            label2.TabIndex = 7;
            label2.Text = "Kod";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(26, 110);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(22, 15);
            label3.TabIndex = 8;
            label3.Text = "Ad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(26, 137);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(96, 15);
            label4.TabIndex = 9;
            label4.Text = "Malzeme Grubu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(26, 164);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(115, 15);
            label5.TabIndex = 10;
            label5.Text = "Malzeme Alt Grubu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(26, 191);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(125, 15);
            label6.TabIndex = 11;
            label6.Text = "Malzeme Alt Grubu 2";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            label7.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label7.Location = new System.Drawing.Point(235, 9);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(310, 30);
            label7.TabIndex = 12;
            label7.Text = "BOYUT TANIMLAMA FORMU";
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(23, 251);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(790, 240);
            universalGrid1.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.Transparent;
            btnSave.Location = new System.Drawing.Point(362, 208);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(34, 37);
            btnSave.TabIndex = 14;
            btnSave.SaveButtonClick += btnSave_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new System.Drawing.Point(26, 208);
            btnNew.Name = "btnNew";
            btnNew.Size = new System.Drawing.Size(36, 36);
            btnNew.TabIndex = 15;
            btnNew.Click += btnNew_Click;
            // 
            // ctbKlasor
            // 
            ctbKlasor.BackColor = System.Drawing.Color.White;
            ctbKlasor.BorderColor = System.Drawing.Color.Silver;
            ctbKlasor.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbKlasor.BorderSize = 1;
            ctbKlasor.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbKlasor.ForeColor = System.Drawing.Color.Black;
            ctbKlasor.Location = new System.Drawing.Point(458, 105);
            ctbKlasor.Margin = new System.Windows.Forms.Padding(1);
            ctbKlasor.Multiline = false;
            ctbKlasor.Name = "ctbKlasor";
            ctbKlasor.Padding = new System.Windows.Forms.Padding(3);
            ctbKlasor.PasswordChar = false;
            ctbKlasor.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbKlasor.PlaceholderText = "";
            ctbKlasor.ReadOnly = false;
            ctbKlasor.SelectionStart = 0;
            ctbKlasor.Size = new System.Drawing.Size(178, 25);
            ctbKlasor.TabIndex = 16;
            ctbKlasor.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbKlasor.TextCustom = "";
            ctbKlasor.UnderlinedStyle = false;
            // 
            // ctbPath
            // 
            ctbPath.BackColor = System.Drawing.Color.White;
            ctbPath.BorderColor = System.Drawing.Color.Silver;
            ctbPath.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbPath.BorderSize = 1;
            ctbPath.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbPath.ForeColor = System.Drawing.Color.Black;
            ctbPath.Location = new System.Drawing.Point(458, 78);
            ctbPath.Margin = new System.Windows.Forms.Padding(1);
            ctbPath.Multiline = false;
            ctbPath.Name = "ctbPath";
            ctbPath.Padding = new System.Windows.Forms.Padding(3);
            ctbPath.PasswordChar = false;
            ctbPath.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbPath.PlaceholderText = "";
            ctbPath.ReadOnly = false;
            ctbPath.SelectionStart = 0;
            ctbPath.Size = new System.Drawing.Size(178, 25);
            ctbPath.TabIndex = 17;
            ctbPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbPath.TextCustom = "";
            ctbPath.UnderlinedStyle = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label8.Location = new System.Drawing.Point(387, 83);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(67, 15);
            label8.TabIndex = 18;
            label8.Text = "Klasör Yolu";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label9.Location = new System.Drawing.Point(387, 110);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(41, 15);
            label9.TabIndex = 19;
            label9.Text = "Klasör";
            // 
            // BoyutTanimFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(825, 491);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(ctbPath);
            Controls.Add(ctbKlasor);
            Controls.Add(btnNew);
            Controls.Add(btnSave);
            Controls.Add(universalGrid1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fcbMalzemeAltGrup2);
            Controls.Add(fcbMalzemeAltGrup);
            Controls.Add(fcbMalzemeGrup);
            Controls.Add(ctbAd);
            Controls.Add(ctbKod);
            Controls.Add(ctbId);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "BoyutTanimFormu";
            Text = "BoyutTanimFormu";
            Load += BoyutTanimFormu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.CustomTextBoxSayisal ctbId;
        private CustomControls.CustomTextBox ctbKod;
        private CustomControls.CustomTextBox ctbAd;
        private CustomControls.FilterableComboBox fcbMalzemeGrup;
        private CustomControls.FilterableComboBox fcbMalzemeAltGrup;
        private CustomControls.FilterableComboBox fcbMalzemeAltGrup2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.CustomButtonSave btnSave;
        private CustomControls.CustomButtonNewRecord btnNew;
        private CustomControls.CustomTextBox ctbKlasor;
        private CustomControls.CustomTextBox ctbPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}