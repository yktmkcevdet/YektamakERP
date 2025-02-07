namespace YektamakDesktop.Formlar.Ortak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceldenVeriAlmaFormu));
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            roundedButtonExcelDosyasiAc = new CustomControls.RoundedButton();
            panel1 = new System.Windows.Forms.Panel();
            panelHeader = new System.Windows.Forms.Panel();
            pictureBoxLogo = new System.Windows.Forms.PictureBox();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            roundedButtonVeriAlaniniBelirle = new CustomControls.RoundedButton();
            baslikDataGridView = new System.Windows.Forms.DataGridView();
            DataGridBaslik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DatagridBaslikName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ExcelBaslik = new System.Windows.Forms.DataGridViewComboBoxColumn();
            roundedButtonVerileriAktar = new CustomControls.RoundedButton();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)baslikDataGridView).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Excel Dosyaları|*.xls;*.xlsx";
            openFileDialog1.Title = "Excel Dosyasını Seçin";
            // 
            // roundedButtonExcelDosyasiAc
            // 
            roundedButtonExcelDosyasiAc.BackColor = System.Drawing.Color.SkyBlue;
            roundedButtonExcelDosyasiAc.BackgroundColor = System.Drawing.Color.SkyBlue;
            roundedButtonExcelDosyasiAc.BorderColor = System.Drawing.Color.DarkGreen;
            roundedButtonExcelDosyasiAc.BorderRadius = 10;
            roundedButtonExcelDosyasiAc.BorderSize = 3;
            roundedButtonExcelDosyasiAc.FlatAppearance.BorderSize = 0;
            roundedButtonExcelDosyasiAc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButtonExcelDosyasiAc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButtonExcelDosyasiAc.ForeColor = System.Drawing.Color.DarkSlateGray;
            roundedButtonExcelDosyasiAc.Location = new System.Drawing.Point(57, 52);
            roundedButtonExcelDosyasiAc.Name = "roundedButtonExcelDosyasiAc";
            roundedButtonExcelDosyasiAc.Size = new System.Drawing.Size(102, 58);
            roundedButtonExcelDosyasiAc.TabIndex = 0;
            roundedButtonExcelDosyasiAc.Text = "Excel Dosyası Aç";
            roundedButtonExcelDosyasiAc.TextColor = System.Drawing.Color.DarkSlateGray;
            roundedButtonExcelDosyasiAc.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new System.Drawing.Point(0, 117);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(967, 801);
            panel1.TabIndex = 1;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Red;
            panelHeader.Controls.Add(pictureBoxLogo);
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Location = new System.Drawing.Point(-1, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1329, 47);
            panelHeader.TabIndex = 2;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = (System.Drawing.Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new System.Drawing.Point(5, 8);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new System.Drawing.Size(30, 29);
            pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 125;
            pictureBoxLogo.TabStop = false;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = System.Drawing.Color.Transparent;
            buttonClose.BackgroundColor = System.Drawing.Color.Transparent;
            buttonClose.BorderColor = System.Drawing.Color.LavenderBlush;
            buttonClose.BorderRadius = 10;
            buttonClose.BorderSize = 2;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonClose.ForeColor = System.Drawing.Color.White;
            buttonClose.Location = new System.Drawing.Point(1277, 4);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(40, 38);
            buttonClose.TabIndex = 106;
            buttonClose.Text = "x";
            buttonClose.TextColor = System.Drawing.Color.White;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.BackColor = System.Drawing.Color.Transparent;
            buttonHelp.BackgroundColor = System.Drawing.Color.Transparent;
            buttonHelp.BorderColor = System.Drawing.Color.LavenderBlush;
            buttonHelp.BorderRadius = 10;
            buttonHelp.BorderSize = 2;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonHelp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonHelp.ForeColor = System.Drawing.Color.White;
            buttonHelp.Location = new System.Drawing.Point(1197, 4);
            buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonHelp.Size = new System.Drawing.Size(40, 38);
            buttonHelp.TabIndex = 105;
            buttonHelp.Text = "?";
            buttonHelp.TextColor = System.Drawing.Color.White;
            buttonHelp.UseVisualStyleBackColor = false;
            // 
            // buttomMinimize
            // 
            buttomMinimize.BackColor = System.Drawing.Color.Transparent;
            buttomMinimize.BackgroundColor = System.Drawing.Color.Transparent;
            buttomMinimize.BorderColor = System.Drawing.Color.LavenderBlush;
            buttomMinimize.BorderRadius = 10;
            buttomMinimize.BorderSize = 2;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttomMinimize.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttomMinimize.ForeColor = System.Drawing.Color.White;
            buttomMinimize.Location = new System.Drawing.Point(1237, 4);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(40, 38);
            buttomMinimize.TabIndex = 104;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.Color.White;
            labelHeader.Location = new System.Drawing.Point(33, 5);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(350, 30);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Satınalma Talep Excelden Aktarma";
            // 
            // roundedButtonVeriAlaniniBelirle
            // 
            roundedButtonVeriAlaniniBelirle.BackColor = System.Drawing.Color.SkyBlue;
            roundedButtonVeriAlaniniBelirle.BackgroundColor = System.Drawing.Color.SkyBlue;
            roundedButtonVeriAlaniniBelirle.BorderColor = System.Drawing.Color.DarkGreen;
            roundedButtonVeriAlaniniBelirle.BorderRadius = 10;
            roundedButtonVeriAlaniniBelirle.BorderSize = 3;
            roundedButtonVeriAlaniniBelirle.Enabled = false;
            roundedButtonVeriAlaniniBelirle.FlatAppearance.BorderSize = 0;
            roundedButtonVeriAlaniniBelirle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButtonVeriAlaniniBelirle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButtonVeriAlaniniBelirle.ForeColor = System.Drawing.Color.DarkSlateGray;
            roundedButtonVeriAlaniniBelirle.Location = new System.Drawing.Point(677, 54);
            roundedButtonVeriAlaniniBelirle.Name = "roundedButtonVeriAlaniniBelirle";
            roundedButtonVeriAlaniniBelirle.Size = new System.Drawing.Size(113, 57);
            roundedButtonVeriAlaniniBelirle.TabIndex = 3;
            roundedButtonVeriAlaniniBelirle.Text = "Seçili Alanı Belirle";
            roundedButtonVeriAlaniniBelirle.TextColor = System.Drawing.Color.DarkSlateGray;
            roundedButtonVeriAlaniniBelirle.UseVisualStyleBackColor = false;
            roundedButtonVeriAlaniniBelirle.Visible = false;
            // 
            // baslikDataGridView
            // 
            baslikDataGridView.AllowUserToAddRows = false;
            baslikDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            baslikDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { DataGridBaslik, DatagridBaslikName, ExcelBaslik });
            baslikDataGridView.Location = new System.Drawing.Point(997, 117);
            baslikDataGridView.Name = "baslikDataGridView";
            baslikDataGridView.RowTemplate.Height = 25;
            baslikDataGridView.Size = new System.Drawing.Size(319, 721);
            baslikDataGridView.TabIndex = 4;
            // 
            // DataGridBaslik
            // 
            DataGridBaslik.HeaderText = "DataGrid Başlık";
            DataGridBaslik.Name = "DataGridBaslik";
            // 
            // DatagridBaslikName
            // 
            DatagridBaslikName.HeaderText = "DatagridBaslikName";
            DatagridBaslikName.Name = "DatagridBaslikName";
            DatagridBaslikName.Visible = false;
            // 
            // ExcelBaslik
            // 
            ExcelBaslik.HeaderText = "Excel Başlık";
            ExcelBaslik.Name = "ExcelBaslik";
            ExcelBaslik.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            ExcelBaslik.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // roundedButtonVerileriAktar
            // 
            roundedButtonVerileriAktar.BackColor = System.Drawing.Color.SkyBlue;
            roundedButtonVerileriAktar.BackgroundColor = System.Drawing.Color.SkyBlue;
            roundedButtonVerileriAktar.BorderColor = System.Drawing.Color.DarkGreen;
            roundedButtonVerileriAktar.BorderRadius = 10;
            roundedButtonVerileriAktar.BorderSize = 3;
            roundedButtonVerileriAktar.Enabled = false;
            roundedButtonVerileriAktar.FlatAppearance.BorderSize = 0;
            roundedButtonVerileriAktar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButtonVerileriAktar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButtonVerileriAktar.ForeColor = System.Drawing.Color.DarkSlateGray;
            roundedButtonVerileriAktar.Location = new System.Drawing.Point(1097, 844);
            roundedButtonVerileriAktar.Name = "roundedButtonVerileriAktar";
            roundedButtonVerileriAktar.Size = new System.Drawing.Size(121, 62);
            roundedButtonVerileriAktar.TabIndex = 5;
            roundedButtonVerileriAktar.Text = "Seçili Verileri Aktar";
            roundedButtonVerileriAktar.TextColor = System.Drawing.Color.DarkSlateGray;
            roundedButtonVerileriAktar.UseVisualStyleBackColor = false;
            roundedButtonVerileriAktar.Visible = false;
            // 
            // ExceldenVeriAlmaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1328, 918);
            Controls.Add(roundedButtonVerileriAktar);
            Controls.Add(baslikDataGridView);
            Controls.Add(roundedButtonVeriAlaniniBelirle);
            Controls.Add(panelHeader);
            Controls.Add(roundedButtonExcelDosyasiAc);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ExceldenVeriAlmaFormu";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ExceldenVeriAlmaFormu";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)baslikDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private CustomControls.RoundedButton roundedButtonExcelDosyasiAc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton roundedButtonVeriAlaniniBelirle;
        private System.Windows.Forms.DataGridView baslikDataGridView;
        private CustomControls.RoundedButton roundedButtonVerileriAktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridBaslik;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatagridBaslikName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ExcelBaslik;
    }
}