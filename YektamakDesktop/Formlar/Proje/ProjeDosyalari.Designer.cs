using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Proje
{
    partial class ProjeDosyalari
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
            components = new System.ComponentModel.Container();
            label2 = new System.Windows.Forms.Label();
            panelFooter = new System.Windows.Forms.Panel();
            roundedButton4 = new RoundedButton();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ctbParcaAdi = new CustomTextBox();
            chkSatinalma = new System.Windows.Forms.CheckBox();
            chkPdf = new System.Windows.Forms.CheckBox();
            chkDxf = new System.Windows.Forms.CheckBox();
            chkStep = new System.Windows.Forms.CheckBox();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            seçiliKalemlerİçinSaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            stokKartınıGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            roundedIconButton1 = new RoundedIconButton();
            headerPanel1 = new HeaderPanel();
            universalGrid1 = new UniversalGrid();
            roundedIconButton2 = new RoundedIconButton();
            fcbProjeKod = new FilterableComboBox();
            clbStokGrup = new FilterableComboBox();
            clbMalzemeGrup = new FilterableComboBox();
            clbMalzemeAltGrup = new FilterableComboBox();
            clbMalzemeAltGrup2 = new FilterableComboBox();
            panelFooter.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 54);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 26;
            label2.Text = "Proje Kodu";
            // 
            // panelFooter
            // 
            panelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFooter.Controls.Add(roundedButton4);
            panelFooter.Location = new System.Drawing.Point(0, 741);
            panelFooter.Margin = new System.Windows.Forms.Padding(0);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1284, 65);
            panelFooter.TabIndex = 101;
            // 
            // roundedButton4
            // 
            roundedButton4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton4.BackColor = System.Drawing.Color.SteelBlue;
            roundedButton4.BackgroundColor = System.Drawing.Color.DodgerBlue;
            roundedButton4.BorderColor = System.Drawing.Color.MediumSeaGreen;
            roundedButton4.BorderSize = 0;
            roundedButton4.CornerRadius = 20;
            roundedButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            roundedButton4.FlatAppearance.BorderSize = 0;
            roundedButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton4.ForeColor = System.Drawing.Color.White;
            roundedButton4.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedButton4.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedButton4.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedButton4.HoverColor2 = System.Drawing.Color.Navy;
            roundedButton4.Icon = null;
            roundedButton4.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton4.Location = new System.Drawing.Point(1079, 2);
            roundedButton4.Name = "roundedButton4";
            roundedButton4.Size = new System.Drawing.Size(152, 59);
            roundedButton4.TabIndex = 2;
            roundedButton4.Text = "Satınalma Talebi Oluştur =>";
            roundedButton4.TextColor = System.Drawing.Color.White;
            roundedButton4.UseVisualStyleBackColor = false;
            roundedButton4.Click += roundedButton4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 84);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(66, 15);
            label1.TabIndex = 103;
            label1.Text = "Stok Grubu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(9, 116);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(91, 15);
            label3.TabIndex = 105;
            label3.Text = "Malzeme Grubu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(9, 223);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 15);
            label4.TabIndex = 107;
            label4.Text = "Parça Adı";
            // 
            // ctbParcaAdi
            // 
            ctbParcaAdi.BackColor = System.Drawing.Color.White;
            ctbParcaAdi.BorderColor = System.Drawing.Color.Silver;
            ctbParcaAdi.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbParcaAdi.BorderRadius = 5;
            ctbParcaAdi.BorderSize = 1;
            ctbParcaAdi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbParcaAdi.ForeColor = System.Drawing.Color.Black;
            ctbParcaAdi.isPlaceHolder = false;
            ctbParcaAdi.Location = new System.Drawing.Point(128, 217);
            ctbParcaAdi.Multiline = false;
            ctbParcaAdi.Name = "ctbParcaAdi";
            ctbParcaAdi.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbParcaAdi.PasswordChar = false;
            ctbParcaAdi.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbParcaAdi.PlaceholderText = "";
            ctbParcaAdi.ReadOnly = false;
            ctbParcaAdi.SelectionStart = 0;
            ctbParcaAdi.Size = new System.Drawing.Size(250, 28);
            ctbParcaAdi.TabIndex = 108;
            ctbParcaAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbParcaAdi.TextCustom = "";
            ctbParcaAdi.UnderlinedStyle = false;
            // 
            // chkSatinalma
            // 
            chkSatinalma.AutoSize = true;
            chkSatinalma.Checked = true;
            chkSatinalma.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            chkSatinalma.Location = new System.Drawing.Point(713, 218);
            chkSatinalma.Name = "chkSatinalma";
            chkSatinalma.Size = new System.Drawing.Size(107, 19);
            chkSatinalma.TabIndex = 109;
            chkSatinalma.Text = "Satınalma talep";
            chkSatinalma.ThreeState = true;
            chkSatinalma.UseVisualStyleBackColor = true;
            // 
            // chkPdf
            // 
            chkPdf.AutoSize = true;
            chkPdf.Checked = true;
            chkPdf.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            chkPdf.Location = new System.Drawing.Point(444, 217);
            chkPdf.Name = "chkPdf";
            chkPdf.Size = new System.Drawing.Size(47, 19);
            chkPdf.TabIndex = 110;
            chkPdf.Text = "PDF";
            chkPdf.ThreeState = true;
            chkPdf.UseVisualStyleBackColor = true;
            // 
            // chkDxf
            // 
            chkDxf.AutoSize = true;
            chkDxf.Checked = true;
            chkDxf.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            chkDxf.Location = new System.Drawing.Point(525, 218);
            chkDxf.Name = "chkDxf";
            chkDxf.Size = new System.Drawing.Size(47, 19);
            chkDxf.TabIndex = 111;
            chkDxf.Text = "DXF";
            chkDxf.ThreeState = true;
            chkDxf.UseVisualStyleBackColor = true;
            // 
            // chkStep
            // 
            chkStep.AutoSize = true;
            chkStep.Checked = true;
            chkStep.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            chkStep.Location = new System.Drawing.Point(612, 218);
            chkStep.Name = "chkStep";
            chkStep.Size = new System.Drawing.Size(51, 19);
            chkStep.TabIndex = 112;
            chkStep.Text = "STEP";
            chkStep.ThreeState = true;
            chkStep.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { seçiliKalemlerİçinSaToolStripMenuItem, stokKartınıGörüntüleToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(303, 48);
            // 
            // seçiliKalemlerİçinSaToolStripMenuItem
            // 
            seçiliKalemlerİçinSaToolStripMenuItem.Name = "seçiliKalemlerİçinSaToolStripMenuItem";
            seçiliKalemlerİçinSaToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            seçiliKalemlerİçinSaToolStripMenuItem.Text = "Seçili Kalemler İçin Satınalma Talebi Oluştur";
            seçiliKalemlerİçinSaToolStripMenuItem.Click += seçiliKalemlerİçinSaToolStripMenuItem_Click;
            // 
            // stokKartınıGörüntüleToolStripMenuItem
            // 
            stokKartınıGörüntüleToolStripMenuItem.Name = "stokKartınıGörüntüleToolStripMenuItem";
            stokKartınıGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            stokKartınıGörüntüleToolStripMenuItem.Text = "Stok Kartını Görüntüle";
            stokKartınıGörüntüleToolStripMenuItem.Click += stokKartınıGörüntüleToolStripMenuItem_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(8, 151);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(109, 15);
            label5.TabIndex = 119;
            label5.Text = "Malzeme Alt Grubu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(9, 189);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(118, 15);
            label6.TabIndex = 121;
            label6.Text = "Malzeme Alt Grubu 2";
            // 
            // roundedIconButton1
            // 
            roundedIconButton1.BackColor = System.Drawing.Color.Cyan;
            roundedIconButton1.BorderColor = System.Drawing.Color.Black;
            roundedIconButton1.BorderSize = 0;
            roundedIconButton1.CornerRadius = 10;
            roundedIconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            roundedIconButton1.FlatAppearance.BorderSize = 0;
            roundedIconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedIconButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedIconButton1.ForeColor = System.Drawing.Color.Purple;
            roundedIconButton1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedIconButton1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedIconButton1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedIconButton1.HoverColor2 = System.Drawing.Color.Navy;
            roundedIconButton1.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            roundedIconButton1.IconColor = System.Drawing.Color.Purple;
            roundedIconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            roundedIconButton1.IconSize = 24;
            roundedIconButton1.Location = new System.Drawing.Point(1112, 54);
            roundedIconButton1.Name = "roundedIconButton1";
            roundedIconButton1.Size = new System.Drawing.Size(119, 35);
            roundedIconButton1.TabIndex = 122;
            roundedIconButton1.Text = "Excelden Al";
            roundedIconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            roundedIconButton1.UseVisualStyleBackColor = false;
            roundedIconButton1.Click += roundedIconButton1_Click;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Proje Dosyaları";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1287, 32);
            headerPanel1.TabIndex = 123;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.kullanici = null;
            universalGrid1.Location = new System.Drawing.Point(8, 270);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1273, 474);
            universalGrid1.TabIndex = 124;
            universalGrid1.MouseDown1 += universalGrid1_MouseClick;
            // 
            // roundedIconButton2
            // 
            roundedIconButton2.BackColor = System.Drawing.Color.DodgerBlue;
            roundedIconButton2.BorderColor = System.Drawing.Color.Black;
            roundedIconButton2.BorderSize = 0;
            roundedIconButton2.CornerRadius = 5;
            roundedIconButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            roundedIconButton2.FlatAppearance.BorderSize = 0;
            roundedIconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedIconButton2.ForeColor = System.Drawing.Color.White;
            roundedIconButton2.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedIconButton2.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedIconButton2.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedIconButton2.HoverColor2 = System.Drawing.Color.Navy;
            roundedIconButton2.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            roundedIconButton2.IconColor = System.Drawing.Color.White;
            roundedIconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            roundedIconButton2.IconSize = 36;
            roundedIconButton2.Location = new System.Drawing.Point(409, 49);
            roundedIconButton2.Name = "roundedIconButton2";
            roundedIconButton2.Size = new System.Drawing.Size(45, 32);
            roundedIconButton2.TabIndex = 125;
            roundedIconButton2.UseVisualStyleBackColor = false;
            // 
            // fcbProjeKod
            // 
            fcbProjeKod.BorderColor = System.Drawing.Color.Silver;
            fcbProjeKod.BorderSize = 1;
            fcbProjeKod.DataSource = null;
            fcbProjeKod.DisplayMember = "kod";
            fcbProjeKod.ForeColor = System.Drawing.Color.Gray;
            fcbProjeKod.Location = new System.Drawing.Point(128, 48);
            fcbProjeKod.Name = "fcbProjeKod";
            fcbProjeKod.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbProjeKod.PlaceholderText = "Seçiniz...";
            fcbProjeKod.SelectedIndex = -1;
            fcbProjeKod.SelectedItem = null;
            fcbProjeKod.SelectedValue = null;
            fcbProjeKod.Size = new System.Drawing.Size(189, 29);
            fcbProjeKod.TabIndex = 126;
            fcbProjeKod.UnderlinedStyle = false;
            fcbProjeKod.ValueMember = "Id";
            fcbProjeKod.SelectedIndexChanged += fcbProjeKod_SelectedIndexChanged;
            // 
            // clbStokGrup
            // 
            clbStokGrup.BorderColor = System.Drawing.Color.Silver;
            clbStokGrup.BorderSize = 1;
            clbStokGrup.DataSource = null;
            clbStokGrup.DisplayMember = "ad";
            clbStokGrup.ForeColor = System.Drawing.Color.Gray;
            clbStokGrup.Location = new System.Drawing.Point(128, 80);
            clbStokGrup.Name = "clbStokGrup";
            clbStokGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbStokGrup.PlaceholderText = "Seçiniz...";
            clbStokGrup.SelectedIndex = -1;
            clbStokGrup.SelectedItem = null;
            clbStokGrup.SelectedValue = null;
            clbStokGrup.Size = new System.Drawing.Size(189, 29);
            clbStokGrup.TabIndex = 127;
            clbStokGrup.UnderlinedStyle = false;
            clbStokGrup.ValueMember = "Id";
            // 
            // clbMalzemeGrup
            // 
            clbMalzemeGrup.BorderColor = System.Drawing.Color.Silver;
            clbMalzemeGrup.BorderSize = 1;
            clbMalzemeGrup.DataSource = null;
            clbMalzemeGrup.DisplayMember = "ad";
            clbMalzemeGrup.ForeColor = System.Drawing.Color.Gray;
            clbMalzemeGrup.Location = new System.Drawing.Point(128, 113);
            clbMalzemeGrup.Name = "clbMalzemeGrup";
            clbMalzemeGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbMalzemeGrup.PlaceholderText = "Seçiniz...";
            clbMalzemeGrup.SelectedIndex = -1;
            clbMalzemeGrup.SelectedItem = null;
            clbMalzemeGrup.SelectedValue = null;
            clbMalzemeGrup.Size = new System.Drawing.Size(189, 29);
            clbMalzemeGrup.TabIndex = 128;
            clbMalzemeGrup.UnderlinedStyle = false;
            clbMalzemeGrup.ValueMember = "Id";
            // 
            // clbMalzemeAltGrup
            // 
            clbMalzemeAltGrup.BorderColor = System.Drawing.Color.Silver;
            clbMalzemeAltGrup.BorderSize = 1;
            clbMalzemeAltGrup.DataSource = null;
            clbMalzemeAltGrup.DisplayMember = "ad";
            clbMalzemeAltGrup.ForeColor = System.Drawing.Color.Gray;
            clbMalzemeAltGrup.Location = new System.Drawing.Point(128, 148);
            clbMalzemeAltGrup.Name = "clbMalzemeAltGrup";
            clbMalzemeAltGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbMalzemeAltGrup.PlaceholderText = "Seçiniz...";
            clbMalzemeAltGrup.SelectedIndex = -1;
            clbMalzemeAltGrup.SelectedItem = null;
            clbMalzemeAltGrup.SelectedValue = null;
            clbMalzemeAltGrup.Size = new System.Drawing.Size(189, 29);
            clbMalzemeAltGrup.TabIndex = 129;
            clbMalzemeAltGrup.UnderlinedStyle = false;
            clbMalzemeAltGrup.ValueMember = "Id";
            // 
            // clbMalzemeAltGrup2
            // 
            clbMalzemeAltGrup2.BorderColor = System.Drawing.Color.Silver;
            clbMalzemeAltGrup2.BorderSize = 1;
            clbMalzemeAltGrup2.DataSource = null;
            clbMalzemeAltGrup2.DisplayMember = "ad";
            clbMalzemeAltGrup2.ForeColor = System.Drawing.Color.Gray;
            clbMalzemeAltGrup2.Location = new System.Drawing.Point(128, 184);
            clbMalzemeAltGrup2.Name = "clbMalzemeAltGrup2";
            clbMalzemeAltGrup2.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbMalzemeAltGrup2.PlaceholderText = "Seçiniz...";
            clbMalzemeAltGrup2.SelectedIndex = -1;
            clbMalzemeAltGrup2.SelectedItem = null;
            clbMalzemeAltGrup2.SelectedValue = null;
            clbMalzemeAltGrup2.Size = new System.Drawing.Size(189, 29);
            clbMalzemeAltGrup2.TabIndex = 130;
            clbMalzemeAltGrup2.UnderlinedStyle = false;
            clbMalzemeAltGrup2.ValueMember = "Id";
            // 
            // ProjeDosyalari
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1287, 807);
            Controls.Add(clbMalzemeAltGrup2);
            Controls.Add(clbMalzemeAltGrup);
            Controls.Add(clbMalzemeGrup);
            Controls.Add(clbStokGrup);
            Controls.Add(fcbProjeKod);
            Controls.Add(roundedIconButton2);
            Controls.Add(headerPanel1);
            Controls.Add(roundedIconButton1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(chkStep);
            Controls.Add(chkDxf);
            Controls.Add(chkPdf);
            Controls.Add(chkSatinalma);
            Controls.Add(ctbParcaAdi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(panelFooter);
            Controls.Add(universalGrid1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ProjeDosyalari";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ProjeDosyalari";
            panelFooter.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBox ctbParcaAdi;
        private System.Windows.Forms.CheckBox chkSatinalma;
        private System.Windows.Forms.CheckBox chkPdf;
        private System.Windows.Forms.CheckBox chkDxf;
        private System.Windows.Forms.CheckBox chkStep;
        private CustomControls.RoundedButton roundedButton4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem seçiliKalemlerİçinSaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokKartınıGörüntüleToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CustomControls.RoundedIconButton roundedIconButton1;
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.RoundedIconButton roundedIconButton2;
        private FilterableComboBox fcbProjeKod;
        private FilterableComboBox clbStokGrup;
        private FilterableComboBox clbMalzemeGrup;
        private FilterableComboBox clbMalzemeAltGrup;
        private FilterableComboBox clbMalzemeAltGrup2;
    }
}