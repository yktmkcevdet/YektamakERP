namespace YektamakDesktop.Formlar.Proje
{
    partial class ExceldenVeriAlmaFormu
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
            customTextBoxDosyaYolu = new CustomControls.CustomTextBox();
            customComboListProjeKodu = new CustomControls.CustomComboListBox();
            verileriAktar = new System.Windows.Forms.PictureBox();
            kapat = new System.Windows.Forms.PictureBox();
            dosyaSec = new System.Windows.Forms.PictureBox();
            transferredCount = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            totalCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)verileriAktar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kapat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dosyaSec).BeginInit();
            SuspendLayout();
            // 
            // customTextBoxDosyaYolu
            // 
            customTextBoxDosyaYolu.BackColor = System.Drawing.Color.White;
            customTextBoxDosyaYolu.BorderColor = System.Drawing.Color.Silver;
            customTextBoxDosyaYolu.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBoxDosyaYolu.BorderRadius = 5;
            customTextBoxDosyaYolu.BorderSize = 1;
            customTextBoxDosyaYolu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            customTextBoxDosyaYolu.ForeColor = System.Drawing.Color.Black;
            customTextBoxDosyaYolu.isPlaceHolder = false;
            customTextBoxDosyaYolu.Location = new System.Drawing.Point(145, 142);
            customTextBoxDosyaYolu.Multiline = false;
            customTextBoxDosyaYolu.Name = "customTextBoxDosyaYolu";
            customTextBoxDosyaYolu.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            customTextBoxDosyaYolu.PasswordChar = false;
            customTextBoxDosyaYolu.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBoxDosyaYolu.PlaceholderText = "";
            customTextBoxDosyaYolu.ReadOnly = false;
            customTextBoxDosyaYolu.SelectionStart = 0;
            customTextBoxDosyaYolu.Size = new System.Drawing.Size(388, 28);
            customTextBoxDosyaYolu.TabIndex = 0;
            customTextBoxDosyaYolu.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBoxDosyaYolu.TextCustom = "";
            customTextBoxDosyaYolu.UnderlinedStyle = false;
            // 
            // customComboListProjeKodu
            // 
            customComboListProjeKodu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customComboListProjeKodu.ListBoxVisualSize = 5;
            customComboListProjeKodu.Location = new System.Drawing.Point(145, 100);
            customComboListProjeKodu.Margin = new System.Windows.Forms.Padding(1);
            customComboListProjeKodu.Name = "customComboListProjeKodu";
            customComboListProjeKodu.Padding = new System.Windows.Forms.Padding(1);
            customComboListProjeKodu.Size = new System.Drawing.Size(306, 36);
            customComboListProjeKodu.TabIndex = 2;
            // 
            // verileriAktar
            // 
            verileriAktar.Image = Properties.Resources.aktar2;
            verileriAktar.Location = new System.Drawing.Point(255, 194);
            verileriAktar.Name = "verileriAktar";
            verileriAktar.Size = new System.Drawing.Size(35, 33);
            verileriAktar.TabIndex = 5;
            verileriAktar.TabStop = false;
            verileriAktar.Click += verileriAktar_Click;
            verileriAktar.MouseLeave += verileriAktar_MouseLeave;
            verileriAktar.MouseHover += verileriAktar_MouseHover;
            // 
            // kapat
            // 
            kapat.Image = Properties.Resources.close;
            kapat.Location = new System.Drawing.Point(619, 12);
            kapat.Name = "kapat";
            kapat.Size = new System.Drawing.Size(35, 33);
            kapat.TabIndex = 101;
            kapat.TabStop = false;
            kapat.Click += kapat_Click;
            kapat.MouseLeave += kapat_MouseLeave;
            kapat.MouseHover += kapat_MouseHover;
            // 
            // dosyaSec
            // 
            dosyaSec.Image = Properties.Resources.fromExcelButton2;
            dosyaSec.Location = new System.Drawing.Point(539, 142);
            dosyaSec.Name = "dosyaSec";
            dosyaSec.Size = new System.Drawing.Size(35, 33);
            dosyaSec.TabIndex = 102;
            dosyaSec.TabStop = false;
            dosyaSec.Click += dosyaSec_Click;
            dosyaSec.MouseLeave += dosyaSec_MouseLeave;
            dosyaSec.MouseHover += dosyaSec_MouseHover;
            // 
            // transferredCount
            // 
            transferredCount.AutoSize = true;
            transferredCount.Location = new System.Drawing.Point(143, 241);
            transferredCount.Name = "transferredCount";
            transferredCount.Size = new System.Drawing.Size(0, 15);
            transferredCount.TabIndex = 103;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(187, 241);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(12, 15);
            label2.TabIndex = 103;
            label2.Text = "/";
            // 
            // totalCount
            // 
            totalCount.AutoSize = true;
            totalCount.Location = new System.Drawing.Point(205, 241);
            totalCount.Name = "totalCount";
            totalCount.Size = new System.Drawing.Size(0, 15);
            totalCount.TabIndex = 103;
            // 
            // ExceldenVeriAlmaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.formBg;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(687, 266);
            Controls.Add(totalCount);
            Controls.Add(label2);
            Controls.Add(transferredCount);
            Controls.Add(dosyaSec);
            Controls.Add(kapat);
            Controls.Add(verileriAktar);
            Controls.Add(customComboListProjeKodu);
            Controls.Add(customTextBoxDosyaYolu);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ExceldenVeriAlmaFormu";
            Text = "ExceldenVeriAlmaFormu";
            ((System.ComponentModel.ISupportInitialize)verileriAktar).EndInit();
            ((System.ComponentModel.ISupportInitialize)kapat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dosyaSec).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.CustomTextBox customTextBoxDosyaYolu;
        private CustomControls.CustomComboListBox customComboListProjeKodu;
        private System.Windows.Forms.PictureBox verileriAktar;
        private System.Windows.Forms.PictureBox kapat;
        private System.Windows.Forms.PictureBox dosyaSec;
        private System.Windows.Forms.Label transferredCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalCount;
    }
}