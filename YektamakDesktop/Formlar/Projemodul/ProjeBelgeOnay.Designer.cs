namespace YektamakDesktop.Formlar.Projemodul
{
    partial class ProjeBelgeOnay
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
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            fcbStokGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbMalzemeGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbProjeKod = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbDosyaTip = new YektamakDesktop.CustomControls.FilterableComboBox();
            panel1 = new System.Windows.Forms.Panel();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            roundedButton2 = new YektamakDesktop.CustomControls.RoundedButton();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Proje Dosya Onay";
            headerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1279, 25);
            headerPanel1.TabIndex = 0;
            // 
            // universalGrid1
            // 
            universalGrid1.Location = new System.Drawing.Point(12, 140);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(433, 600);
            universalGrid1.TabIndex = 1;
            // 
            // fcbStokGrup
            // 
            fcbStokGrup.BorderColor = System.Drawing.Color.Silver;
            fcbStokGrup.BorderRadius = 8;
            fcbStokGrup.BorderSize = 1;
            fcbStokGrup.DisplayMember = "ad";
            fcbStokGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbStokGrup.Location = new System.Drawing.Point(24, 74);
            fcbStokGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbStokGrup.Name = "fcbStokGrup";
            fcbStokGrup.Padding = new System.Windows.Forms.Padding(3);
            fcbStokGrup.PlaceholderText = "Stok Grubu";
            fcbStokGrup.ReadOnly = false;
            fcbStokGrup.Size = new System.Drawing.Size(193, 25);
            fcbStokGrup.TabIndex = 2;
            fcbStokGrup.ValueMember = "Id";
            fcbStokGrup.SelectedIndexChanged += fcbStokGrup_SelectedIndexChanged;
            // 
            // fcbMalzemeGrup
            // 
            fcbMalzemeGrup.BorderColor = System.Drawing.Color.Silver;
            fcbMalzemeGrup.BorderRadius = 8;
            fcbMalzemeGrup.BorderSize = 1;
            fcbMalzemeGrup.DisplayMember = "ad";
            fcbMalzemeGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMalzemeGrup.Location = new System.Drawing.Point(24, 101);
            fcbMalzemeGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbMalzemeGrup.Name = "fcbMalzemeGrup";
            fcbMalzemeGrup.Padding = new System.Windows.Forms.Padding(3);
            fcbMalzemeGrup.PlaceholderText = "Malzeme Grubu";
            fcbMalzemeGrup.ReadOnly = false;
            fcbMalzemeGrup.Size = new System.Drawing.Size(193, 25);
            fcbMalzemeGrup.TabIndex = 3;
            fcbMalzemeGrup.ValueMember = "Id";
            // 
            // fcbProjeKod
            // 
            fcbProjeKod.BorderColor = System.Drawing.Color.Silver;
            fcbProjeKod.BorderRadius = 8;
            fcbProjeKod.BorderSize = 1;
            fcbProjeKod.DisplayMember = "kod";
            fcbProjeKod.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbProjeKod.Location = new System.Drawing.Point(24, 47);
            fcbProjeKod.Margin = new System.Windows.Forms.Padding(1);
            fcbProjeKod.Name = "fcbProjeKod";
            fcbProjeKod.Padding = new System.Windows.Forms.Padding(3);
            fcbProjeKod.PlaceholderText = "Proje Kodu";
            fcbProjeKod.ReadOnly = false;
            fcbProjeKod.Size = new System.Drawing.Size(193, 25);
            fcbProjeKod.TabIndex = 4;
            fcbProjeKod.ValueMember = "Id";
            fcbProjeKod.SelectedIndexChanged += fcbProjeKod_SelectedIndexChanged;
            // 
            // fcbDosyaTip
            // 
            fcbDosyaTip.BorderColor = System.Drawing.Color.Silver;
            fcbDosyaTip.BorderRadius = 8;
            fcbDosyaTip.BorderSize = 1;
            fcbDosyaTip.DisplayMember = "ad";
            fcbDosyaTip.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbDosyaTip.Location = new System.Drawing.Point(289, 47);
            fcbDosyaTip.Margin = new System.Windows.Forms.Padding(1);
            fcbDosyaTip.Name = "fcbDosyaTip";
            fcbDosyaTip.Padding = new System.Windows.Forms.Padding(3);
            fcbDosyaTip.PlaceholderText = "Dosya Tipi";
            fcbDosyaTip.ReadOnly = false;
            fcbDosyaTip.Size = new System.Drawing.Size(156, 25);
            fcbDosyaTip.TabIndex = 5;
            fcbDosyaTip.ValueMember = "Id";
            fcbDosyaTip.SelectedItemChanged += fcbDosyaTip_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.Location = new System.Drawing.Point(463, 101);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(807, 646);
            panel1.TabIndex = 6;
            // 
            // roundedButton1
            // 
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Black;
            roundedButton1.BorderSize = 0;
            roundedButton1.CornerRadius = 10;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.Font = new System.Drawing.Font("Segoe UI", 16F);
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.GradientColor1 = System.Drawing.Color.Green;
            roundedButton1.GradientColor2 = System.Drawing.Color.LimeGreen;
            roundedButton1.HoverColor1 = System.Drawing.Color.Green;
            roundedButton1.HoverColor2 = System.Drawing.Color.LimeGreen;
            roundedButton1.Icon = null;
            roundedButton1.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton1.Location = new System.Drawing.Point(537, 47);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(37, 35);
            roundedButton1.TabIndex = 7;
            roundedButton1.Text = "✓";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // roundedButton2
            // 
            roundedButton2.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton2.BorderColor = System.Drawing.Color.Black;
            roundedButton2.BorderSize = 0;
            roundedButton2.CornerRadius = 10;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton2.Font = new System.Drawing.Font("Segoe UI", 16F);
            roundedButton2.ForeColor = System.Drawing.Color.White;
            roundedButton2.GradientColor1 = System.Drawing.Color.FromArgb(192, 0, 0);
            roundedButton2.GradientColor2 = System.Drawing.Color.Red;
            roundedButton2.HoverColor1 = System.Drawing.Color.FromArgb(192, 64, 0);
            roundedButton2.HoverColor2 = System.Drawing.Color.FromArgb(192, 0, 0);
            roundedButton2.Icon = null;
            roundedButton2.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton2.Location = new System.Drawing.Point(1206, 47);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Size = new System.Drawing.Size(40, 40);
            roundedButton2.TabIndex = 8;
            roundedButton2.Text = "✗";
            roundedButton2.TextColor = System.Drawing.Color.White;
            roundedButton2.UseVisualStyleBackColor = true;
            // 
            // ProjeBelgeOnay
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1279, 768);
            Controls.Add(roundedButton2);
            Controls.Add(roundedButton1);
            Controls.Add(panel1);
            Controls.Add(fcbDosyaTip);
            Controls.Add(fcbProjeKod);
            Controls.Add(fcbMalzemeGrup);
            Controls.Add(fcbStokGrup);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ProjeBelgeOnay";
            Text = "ProjeBelgeOnay";
            FormClosing += ProjeBelgeOnay_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.FilterableComboBox fcbStokGrup;
        private CustomControls.FilterableComboBox fcbMalzemeGrup;
        private CustomControls.FilterableComboBox fcbProjeKod;
        private CustomControls.FilterableComboBox fcbDosyaTip;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.RoundedButton roundedButton2;
    }
}