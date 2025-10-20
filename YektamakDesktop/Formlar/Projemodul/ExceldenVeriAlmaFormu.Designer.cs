namespace YektamakDesktop.Formlar.ProjeModul
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
            ctbDosyaYolu = new YektamakDesktop.CustomControls.CustomTextBox();
            verileriAktar = new System.Windows.Forms.PictureBox();
            dosyaSec = new System.Windows.Forms.PictureBox();
            transferredCount = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            totalCount = new System.Windows.Forms.Label();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            clbProjeKodu = new YektamakDesktop.CustomControls.FilterableComboBox();
            chkProjeDosyaSil = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)verileriAktar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dosyaSec).BeginInit();
            SuspendLayout();
            // 
            // ctbDosyaYolu
            // 
            ctbDosyaYolu.BackColor = System.Drawing.Color.White;
            ctbDosyaYolu.BorderColor = System.Drawing.Color.Silver;
            ctbDosyaYolu.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbDosyaYolu.BorderSize = 1;
            ctbDosyaYolu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbDosyaYolu.ForeColor = System.Drawing.Color.Black;
            ctbDosyaYolu.Location = new System.Drawing.Point(143, 135);
            ctbDosyaYolu.Margin = new System.Windows.Forms.Padding(1);
            ctbDosyaYolu.Multiline = false;
            ctbDosyaYolu.Name = "ctbDosyaYolu";
            ctbDosyaYolu.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbDosyaYolu.PasswordChar = false;
            ctbDosyaYolu.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbDosyaYolu.PlaceholderText = "Dosya Yolu";
            ctbDosyaYolu.ReadOnly = false;
            ctbDosyaYolu.SelectionStart = 0;
            ctbDosyaYolu.Size = new System.Drawing.Size(388, 33);
            ctbDosyaYolu.TabIndex = 0;
            ctbDosyaYolu.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbDosyaYolu.TextCustom = "";
            ctbDosyaYolu.UnderlinedStyle = false;
            // 
            // verileriAktar
            // 
            verileriAktar.Cursor = System.Windows.Forms.Cursors.Hand;
            verileriAktar.Image = Properties.Resources.aktar2;
            verileriAktar.Location = new System.Drawing.Point(261, 194);
            verileriAktar.Name = "verileriAktar";
            verileriAktar.Size = new System.Drawing.Size(35, 33);
            verileriAktar.TabIndex = 5;
            verileriAktar.TabStop = false;
            verileriAktar.Click += verileriAktar_Click;
            // 
            // dosyaSec
            // 
            dosyaSec.Cursor = System.Windows.Forms.Cursors.Hand;
            dosyaSec.Image = Properties.Resources.fromExcelButton2;
            dosyaSec.Location = new System.Drawing.Point(537, 135);
            dosyaSec.Name = "dosyaSec";
            dosyaSec.Size = new System.Drawing.Size(35, 33);
            dosyaSec.TabIndex = 102;
            dosyaSec.TabStop = false;
            dosyaSec.Click += dosyaSec_Click;
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
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Excelden Proje Dosyları Aktar";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(687, 25);
            headerPanel1.TabIndex = 104;
            // 
            // clbProjeKodu
            // 
            clbProjeKodu.BorderColor = System.Drawing.Color.Silver;
            clbProjeKodu.BorderRadius = 8;
            clbProjeKodu.BorderSize = 1;
            clbProjeKodu.DisplayMember = "kod";
            clbProjeKodu.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbProjeKodu.Location = new System.Drawing.Point(143, 100);
            clbProjeKodu.Margin = new System.Windows.Forms.Padding(1);
            clbProjeKodu.Name = "clbProjeKodu";
            clbProjeKodu.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbProjeKodu.PlaceholderText = "Proje Kodu";
            clbProjeKodu.Size = new System.Drawing.Size(211, 29);
            clbProjeKodu.TabIndex = 105;
            clbProjeKodu.ValueMember = "Id";
            // 
            // chkProjeDosyaSil
            // 
            chkProjeDosyaSil.AutoSize = true;
            chkProjeDosyaSil.Location = new System.Drawing.Point(145, 169);
            chkProjeDosyaSil.Name = "chkProjeDosyaSil";
            chkProjeDosyaSil.Size = new System.Drawing.Size(210, 19);
            chkProjeDosyaSil.TabIndex = 106;
            chkProjeDosyaSil.Text = "Projeye ait mevcut dosyalar silinsin";
            chkProjeDosyaSil.UseVisualStyleBackColor = true;
            // 
            // ExceldenVeriAlmaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(687, 266);
            Controls.Add(chkProjeDosyaSil);
            Controls.Add(clbProjeKodu);
            Controls.Add(headerPanel1);
            Controls.Add(totalCount);
            Controls.Add(label2);
            Controls.Add(transferredCount);
            Controls.Add(dosyaSec);
            Controls.Add(verileriAktar);
            Controls.Add(ctbDosyaYolu);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ExceldenVeriAlmaFormu";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ExceldenVeriAlmaFormu";
            ((System.ComponentModel.ISupportInitialize)verileriAktar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dosyaSec).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.CustomTextBox ctbDosyaYolu;
        private System.Windows.Forms.PictureBox verileriAktar;
        private System.Windows.Forms.PictureBox dosyaSec;
        private System.Windows.Forms.Label transferredCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalCount;
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.FilterableComboBox clbProjeKodu;
        private System.Windows.Forms.CheckBox chkProjeDosyaSil;
    }
}