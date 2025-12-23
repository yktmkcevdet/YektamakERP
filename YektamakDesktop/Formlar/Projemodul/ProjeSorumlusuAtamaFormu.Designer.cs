namespace YektamakDesktop.Formlar.Projemodul
{
    partial class ProjeSorumlusuAtamaFormu
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
            fcbProje = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbPersonel = new YektamakDesktop.CustomControls.FilterableComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            ctbId = new YektamakDesktop.CustomControls.CustomTextBox();
            label3 = new System.Windows.Forms.Label();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            customButtonNewRecord1 = new YektamakDesktop.CustomControls.CustomButtonNewRecord();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Proje Sorumlusu Tanımlama";
            headerPanel1.Location = new System.Drawing.Point(-1, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(485, 25);
            headerPanel1.TabIndex = 0;
            // 
            // fcbProje
            // 
            fcbProje.BorderColor = System.Drawing.Color.Silver;
            fcbProje.BorderRadius = 8;
            fcbProje.BorderSize = 1;
            fcbProje.DisplayMember = "ad";
            fcbProje.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbProje.Location = new System.Drawing.Point(135, 100);
            fcbProje.Margin = new System.Windows.Forms.Padding(1);
            fcbProje.Name = "fcbProje";
            fcbProje.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbProje.PlaceholderText = "Seçiniz...";
            fcbProje.ReadOnly = false;
            fcbProje.Size = new System.Drawing.Size(204, 25);
            fcbProje.TabIndex = 1;
            fcbProje.ValueMember = "Id";
            // 
            // fcbPersonel
            // 
            fcbPersonel.BorderColor = System.Drawing.Color.Silver;
            fcbPersonel.BorderRadius = 8;
            fcbPersonel.BorderSize = 1;
            fcbPersonel.DisplayMember = "ad";
            fcbPersonel.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbPersonel.Location = new System.Drawing.Point(135, 135);
            fcbPersonel.Margin = new System.Windows.Forms.Padding(1);
            fcbPersonel.Name = "fcbPersonel";
            fcbPersonel.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbPersonel.PlaceholderText = "Seçiniz...";
            fcbPersonel.ReadOnly = false;
            fcbPersonel.Size = new System.Drawing.Size(204, 25);
            fcbPersonel.TabIndex = 2;
            fcbPersonel.ValueMember = "Id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(73, 105);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(34, 15);
            label1.TabIndex = 3;
            label1.Text = "Proje";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(73, 140);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 15);
            label2.TabIndex = 4;
            label2.Text = "Personel";
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(1, 243);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(482, 369);
            universalGrid1.TabIndex = 6;
            // 
            // ctbId
            // 
            ctbId.BackColor = System.Drawing.Color.White;
            ctbId.BorderColor = System.Drawing.Color.Silver;
            ctbId.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbId.BorderSize = 1;
            ctbId.Enabled = false;
            ctbId.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbId.ForeColor = System.Drawing.Color.Black;
            ctbId.Location = new System.Drawing.Point(135, 66);
            ctbId.Margin = new System.Windows.Forms.Padding(1);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbId.PasswordChar = false;
            ctbId.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbId.PlaceholderText = "";
            ctbId.ReadOnly = false;
            ctbId.SelectionStart = 0;
            ctbId.Size = new System.Drawing.Size(110, 29);
            ctbId.TabIndex = 7;
            ctbId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbId.TextCustom = "";
            ctbId.UnderlinedStyle = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(73, 72);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(17, 15);
            label3.TabIndex = 8;
            label3.Text = "Id";
            // 
            // customButtonSave1
            // 
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.BorderColor = System.Drawing.Color.Black;
            customButtonSave1.BorderSize = 0;
            customButtonSave1.CornerRadius = 6;
            customButtonSave1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            customButtonSave1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            customButtonSave1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            customButtonSave1.HoverColor2 = System.Drawing.Color.Navy;
            customButtonSave1.Location = new System.Drawing.Point(303, 191);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(36, 36);
            customButtonSave1.TabIndex = 10;
            // 
            // customButtonNewRecord1
            // 
            customButtonNewRecord1.BorderColor = System.Drawing.Color.Empty;
            customButtonNewRecord1.BorderSize = 0;
            customButtonNewRecord1.CausesValidation = false;
            customButtonNewRecord1.CornerRadius = 6;
            customButtonNewRecord1.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
            customButtonNewRecord1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            customButtonNewRecord1.GradientColor2 = System.Drawing.Color.FromArgb(192, 64, 0);
            customButtonNewRecord1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            customButtonNewRecord1.HoverColor2 = System.Drawing.Color.Navy;
            customButtonNewRecord1.Location = new System.Drawing.Point(42, 191);
            customButtonNewRecord1.Margin = new System.Windows.Forms.Padding(0);
            customButtonNewRecord1.Name = "customButtonNewRecord1";
            customButtonNewRecord1.Size = new System.Drawing.Size(36, 36);
            customButtonNewRecord1.TabIndex = 11;
            customButtonNewRecord1.Click += RoundedButton1_Click;
            // 
            // ProjeSorumlusuAtamaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(484, 614);
            Controls.Add(customButtonNewRecord1);
            Controls.Add(customButtonSave1);
            Controls.Add(label3);
            Controls.Add(ctbId);
            Controls.Add(universalGrid1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fcbPersonel);
            Controls.Add(fcbProje);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ProjeSorumlusuAtamaFormu";
            Text = "ProjeSorumlusuAtamaFormu";
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.FilterableComboBox fcbProje;
        private CustomControls.FilterableComboBox fcbPersonel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.CustomTextBox ctbId;
        private System.Windows.Forms.Label label3;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.CustomButtonNewRecord customButtonNewRecord1;
    }
}