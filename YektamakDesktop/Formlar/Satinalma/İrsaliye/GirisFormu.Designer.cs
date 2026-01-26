namespace YektamakDesktop.Formlar.Satinalma.İrsaliye
{
    partial class GirisFormu
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
            fcbFirma = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbProjeKodu = new YektamakDesktop.CustomControls.FilterableComboBox();
            filterableComboBox3 = new YektamakDesktop.CustomControls.FilterableComboBox();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Malzeme Giriş Formu";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1013, 25);
            headerPanel1.TabIndex = 0;
            // 
            // fcbFirma
            // 
            fcbFirma.BorderColor = System.Drawing.Color.Silver;
            fcbFirma.BorderRadius = 8;
            fcbFirma.BorderSize = 1;
            fcbFirma.DisplayMember = "ad";
            fcbFirma.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbFirma.Location = new System.Drawing.Point(172, 61);
            fcbFirma.Margin = new System.Windows.Forms.Padding(1);
            fcbFirma.Name = "fcbFirma";
            fcbFirma.Padding = new System.Windows.Forms.Padding(3);
            fcbFirma.PlaceholderText = "Seçiniz...";
            fcbFirma.ReadOnly = false;
            fcbFirma.Size = new System.Drawing.Size(213, 25);
            fcbFirma.TabIndex = 3;
            fcbFirma.ValueMember = "Id";
            // 
            // fcbProjeKodu
            // 
            fcbProjeKodu.BorderColor = System.Drawing.Color.Silver;
            fcbProjeKodu.BorderRadius = 8;
            fcbProjeKodu.BorderSize = 1;
            fcbProjeKodu.DisplayMember = "ad";
            fcbProjeKodu.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbProjeKodu.Location = new System.Drawing.Point(172, 88);
            fcbProjeKodu.Margin = new System.Windows.Forms.Padding(1);
            fcbProjeKodu.Name = "fcbProjeKodu";
            fcbProjeKodu.Padding = new System.Windows.Forms.Padding(3);
            fcbProjeKodu.PlaceholderText = "Seçiniz...";
            fcbProjeKodu.ReadOnly = false;
            fcbProjeKodu.Size = new System.Drawing.Size(213, 25);
            fcbProjeKodu.TabIndex = 4;
            fcbProjeKodu.ValueMember = "Id";
            // 
            // filterableComboBox3
            // 
            filterableComboBox3.BorderColor = System.Drawing.Color.Silver;
            filterableComboBox3.BorderRadius = 8;
            filterableComboBox3.BorderSize = 1;
            filterableComboBox3.DisplayMember = "ad";
            filterableComboBox3.Font = new System.Drawing.Font("Segoe UI", 8F);
            filterableComboBox3.Location = new System.Drawing.Point(172, 115);
            filterableComboBox3.Margin = new System.Windows.Forms.Padding(1);
            filterableComboBox3.Name = "filterableComboBox3";
            filterableComboBox3.Padding = new System.Windows.Forms.Padding(3);
            filterableComboBox3.PlaceholderText = "Seçiniz...";
            filterableComboBox3.ReadOnly = false;
            filterableComboBox3.Size = new System.Drawing.Size(213, 25);
            filterableComboBox3.TabIndex = 5;
            filterableComboBox3.ValueMember = "Id";
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(12, 162);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(989, 431);
            universalGrid1.TabIndex = 6;
            // 
            // GirisFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1013, 597);
            Controls.Add(universalGrid1);
            Controls.Add(filterableComboBox3);
            Controls.Add(fcbProjeKodu);
            Controls.Add(fcbFirma);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "GirisFormu";
            Text = "GirisFormu";
            Load += GirisFormu_Load;
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.FilterableComboBox fcbFirma;
        private CustomControls.FilterableComboBox fcbProjeKodu;
        private CustomControls.FilterableComboBox filterableComboBox3;
        private CustomControls.UniversalGrid universalGrid1;
    }
}