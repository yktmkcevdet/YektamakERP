using System.Drawing;
using System.Windows.Forms;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.ProjeModul
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
            label2 = new Label();
            panelFooter = new Panel();
            roundedButton4 = new RoundedButton();
            roundedButton1 = new RoundedButton();
            roundedButton2 = new RoundedButton();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            chkSatinalma = new CheckBox();
            chkPdf = new CheckBox();
            chkDxf = new CheckBox();
            chkStep = new CheckBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            seçiliKalemlerİçinSaToolStripMenuItem = new ToolStripMenuItem();
            stokKartınıGörüntüleToolStripMenuItem = new ToolStripMenuItem();
            seçilenKayıtlarıSilToolStripMenuItem = new ToolStripMenuItem();
            label5 = new Label();
            label6 = new Label();
            roundedIconButton1 = new RoundedIconButton();
            fcbProjeKod = new FilterableComboBox();
            fcbStokGrup = new FilterableComboBox();
            fcbMalzemeGrup = new FilterableComboBox();
            fcbMalzemeAltGrup = new FilterableComboBox();
            fcbMalzemeAltGrup2 = new FilterableComboBox();
            label8 = new Label();
            headerPanel1 = new HeaderPanel();
            universalGrid1 = new UniversalGrid();
            ctbParcaKod = new CustomTextBox();
            ctbParcaAd = new CustomTextBox();
            panelFooter.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label2.Location = new Point(8, 40);
            label2.Name = "label2";
            label2.Size = new Size(65, 13);
            label2.TabIndex = 26;
            label2.Text = "Proje Kodu";
            // 
            // panelFooter
            // 
            panelFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFooter.Controls.Add(roundedButton4);
            panelFooter.Controls.Add(roundedButton1);
            panelFooter.Controls.Add(roundedButton2);
            panelFooter.Location = new Point(0, 642);
            panelFooter.Margin = new Padding(0);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1101, 56);
            panelFooter.TabIndex = 101;
            // 
            // roundedButton4
            // 
            roundedButton4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            roundedButton4.BackColor = Color.SteelBlue;
            roundedButton4.BackgroundColor = Color.Firebrick;
            roundedButton4.BorderColor = Color.Black;
            roundedButton4.BorderSize = 0;
            roundedButton4.CornerRadius = 10;
            roundedButton4.Cursor = Cursors.Hand;
            roundedButton4.FlatAppearance.BorderSize = 0;
            roundedButton4.FlatStyle = FlatStyle.Flat;
            roundedButton4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            roundedButton4.ForeColor = Color.White;
            roundedButton4.GradientColor1 = Color.DodgerBlue;
            roundedButton4.GradientColor2 = Color.MidnightBlue;
            roundedButton4.HoverColor1 = Color.RoyalBlue;
            roundedButton4.HoverColor2 = Color.Navy;
            roundedButton4.Icon = null;
            roundedButton4.IconAlign = ContentAlignment.MiddleLeft;
            roundedButton4.Location = new Point(961, 2);
            roundedButton4.Name = "roundedButton4";
            roundedButton4.Size = new Size(130, 51);
            roundedButton4.TabIndex = 2;
            roundedButton4.Text = "Satınalma Talebi Oluştur =>";
            roundedButton4.TextColor = Color.White;
            roundedButton4.UseVisualStyleBackColor = false;
            roundedButton4.Click += roundedButton4_Click;
            // 
            // roundedButton1
            // 
            roundedButton1.BackgroundColor = Color.Firebrick;
            roundedButton1.BorderColor = Color.Black;
            roundedButton1.BorderSize = 0;
            roundedButton1.CornerRadius = 10;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.ForeColor = Color.White;
            roundedButton1.GradientColor1 = Color.DodgerBlue;
            roundedButton1.GradientColor2 = Color.MidnightBlue;
            roundedButton1.HoverColor1 = Color.RoyalBlue;
            roundedButton1.HoverColor2 = Color.Navy;
            roundedButton1.Icon = null;
            roundedButton1.IconAlign = ContentAlignment.MiddleLeft;
            roundedButton1.Location = new Point(435, 8);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(150, 40);
            roundedButton1.TabIndex = 137;
            roundedButton1.Text = "roundedButton1";
            roundedButton1.TextColor = Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Visible = false;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // roundedButton2
            // 
            roundedButton2.BackgroundColor = Color.Firebrick;
            roundedButton2.BorderColor = Color.Black;
            roundedButton2.BorderSize = 0;
            roundedButton2.CornerRadius = 10;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = FlatStyle.Flat;
            roundedButton2.ForeColor = Color.White;
            roundedButton2.GradientColor1 = Color.DodgerBlue;
            roundedButton2.GradientColor2 = Color.MidnightBlue;
            roundedButton2.HoverColor1 = Color.RoyalBlue;
            roundedButton2.HoverColor2 = Color.Navy;
            roundedButton2.Icon = null;
            roundedButton2.IconAlign = ContentAlignment.MiddleLeft;
            roundedButton2.Location = new Point(18, 8);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Size = new Size(91, 40);
            roundedButton2.TabIndex = 138;
            roundedButton2.Text = "Dosyaları Klasöre Aktar";
            roundedButton2.TextColor = Color.White;
            roundedButton2.UseVisualStyleBackColor = true;
            roundedButton2.Click += roundedButton2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label1.Location = new Point(10, 70);
            label1.Name = "label1";
            label1.Size = new Size(66, 13);
            label1.TabIndex = 103;
            label1.Text = "Stok Grubu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label3.Location = new Point(8, 95);
            label3.Name = "label3";
            label3.Size = new Size(90, 13);
            label3.TabIndex = 105;
            label3.Text = "Malzeme Grubu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label4.Location = new Point(308, 122);
            label4.Name = "label4";
            label4.Size = new Size(66, 13);
            label4.TabIndex = 107;
            label4.Text = "Parça Kodu";
            // 
            // chkSatinalma
            // 
            chkSatinalma.AutoSize = true;
            chkSatinalma.Checked = true;
            chkSatinalma.CheckState = CheckState.Indeterminate;
            chkSatinalma.Location = new Point(652, 97);
            chkSatinalma.Name = "chkSatinalma";
            chkSatinalma.Size = new Size(105, 17);
            chkSatinalma.TabIndex = 109;
            chkSatinalma.Text = "Satınalma talep";
            chkSatinalma.ThreeState = true;
            chkSatinalma.UseVisualStyleBackColor = true;
            // 
            // chkPdf
            // 
            chkPdf.AutoSize = true;
            chkPdf.Checked = true;
            chkPdf.CheckState = CheckState.Indeterminate;
            chkPdf.Location = new Point(652, 31);
            chkPdf.Name = "chkPdf";
            chkPdf.Size = new Size(46, 17);
            chkPdf.TabIndex = 110;
            chkPdf.Text = "PDF";
            chkPdf.ThreeState = true;
            chkPdf.UseVisualStyleBackColor = true;
            // 
            // chkDxf
            // 
            chkDxf.AutoSize = true;
            chkDxf.Checked = true;
            chkDxf.CheckState = CheckState.Indeterminate;
            chkDxf.Location = new Point(652, 52);
            chkDxf.Name = "chkDxf";
            chkDxf.Size = new Size(46, 17);
            chkDxf.TabIndex = 111;
            chkDxf.Text = "DXF";
            chkDxf.ThreeState = true;
            chkDxf.UseVisualStyleBackColor = true;
            // 
            // chkStep
            // 
            chkStep.AutoSize = true;
            chkStep.Checked = true;
            chkStep.CheckState = CheckState.Indeterminate;
            chkStep.Location = new Point(652, 74);
            chkStep.Name = "chkStep";
            chkStep.Size = new Size(50, 17);
            chkStep.TabIndex = 112;
            chkStep.Text = "STEP";
            chkStep.ThreeState = true;
            chkStep.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { seçiliKalemlerİçinSaToolStripMenuItem, stokKartınıGörüntüleToolStripMenuItem, seçilenKayıtlarıSilToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(303, 70);
            // 
            // seçiliKalemlerİçinSaToolStripMenuItem
            // 
            seçiliKalemlerİçinSaToolStripMenuItem.Name = "seçiliKalemlerİçinSaToolStripMenuItem";
            seçiliKalemlerİçinSaToolStripMenuItem.Size = new Size(302, 22);
            seçiliKalemlerİçinSaToolStripMenuItem.Text = "Seçili Kalemler İçin Satınalma Talebi Oluştur";
            seçiliKalemlerİçinSaToolStripMenuItem.Click += seçiliKalemlerİçinSaToolStripMenuItem_Click;
            // 
            // stokKartınıGörüntüleToolStripMenuItem
            // 
            stokKartınıGörüntüleToolStripMenuItem.Name = "stokKartınıGörüntüleToolStripMenuItem";
            stokKartınıGörüntüleToolStripMenuItem.Size = new Size(302, 22);
            stokKartınıGörüntüleToolStripMenuItem.Text = "Stok Kartını Görüntüle";
            stokKartınıGörüntüleToolStripMenuItem.Click += stokKartınıGörüntüleToolStripMenuItem_Click;
            // 
            // seçilenKayıtlarıSilToolStripMenuItem
            // 
            seçilenKayıtlarıSilToolStripMenuItem.Name = "seçilenKayıtlarıSilToolStripMenuItem";
            seçilenKayıtlarıSilToolStripMenuItem.Size = new Size(302, 22);
            seçilenKayıtlarıSilToolStripMenuItem.Text = "Seçilen Kayıtları Sil";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label5.Location = new Point(8, 122);
            label5.Name = "label5";
            label5.Size = new Size(108, 13);
            label5.TabIndex = 119;
            label5.Text = "Malzeme Alt Grubu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label6.Location = new Point(8, 148);
            label6.Name = "label6";
            label6.Size = new Size(117, 13);
            label6.TabIndex = 121;
            label6.Text = "Malzeme Alt Grubu 2";
            // 
            // roundedIconButton1
            // 
            roundedIconButton1.BackColor = Color.Cyan;
            roundedIconButton1.BorderColor = Color.Black;
            roundedIconButton1.BorderSize = 0;
            roundedIconButton1.CornerRadius = 6;
            roundedIconButton1.Cursor = Cursors.Hand;
            roundedIconButton1.FlatAppearance.BorderSize = 0;
            roundedIconButton1.FlatStyle = FlatStyle.Flat;
            roundedIconButton1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            roundedIconButton1.ForeColor = Color.Purple;
            roundedIconButton1.GradientColor1 = Color.DodgerBlue;
            roundedIconButton1.GradientColor2 = Color.MidnightBlue;
            roundedIconButton1.HoverColor1 = Color.RoyalBlue;
            roundedIconButton1.HoverColor2 = Color.Navy;
            roundedIconButton1.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            roundedIconButton1.IconColor = Color.Purple;
            roundedIconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            roundedIconButton1.IconSize = 24;
            roundedIconButton1.Location = new Point(292, 32);
            roundedIconButton1.Name = "roundedIconButton1";
            roundedIconButton1.Size = new Size(103, 29);
            roundedIconButton1.TabIndex = 122;
            roundedIconButton1.Text = "Excelden Al";
            roundedIconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            roundedIconButton1.UseVisualStyleBackColor = false;
            roundedIconButton1.Click += roundedIconButton1_Click;
            // 
            // fcbProjeKod
            // 
            fcbProjeKod.BorderColor = Color.Silver;
            fcbProjeKod.BorderRadius = 8;
            fcbProjeKod.BorderSize = 1;
            fcbProjeKod.DisplayMember = "kod";
            fcbProjeKod.Font = new Font("Segoe UI", 8F);
            fcbProjeKod.ForeColor = Color.Gray;
            fcbProjeKod.Location = new Point(125, 35);
            fcbProjeKod.Margin = new Padding(1);
            fcbProjeKod.Name = "fcbProjeKod";
            fcbProjeKod.Padding = new Padding(6, 4, 6, 4);
            fcbProjeKod.PlaceholderText = "Seçiniz...";
            fcbProjeKod.ReadOnly = false;
            fcbProjeKod.Size = new Size(162, 25);
            fcbProjeKod.TabIndex = 126;
            fcbProjeKod.ValueMember = "Id";
            // 
            // fcbStokGrup
            // 
            fcbStokGrup.BorderColor = Color.Silver;
            fcbStokGrup.BorderRadius = 8;
            fcbStokGrup.BorderSize = 1;
            fcbStokGrup.DisplayMember = "ad";
            fcbStokGrup.Font = new Font("Segoe UI", 8F);
            fcbStokGrup.ForeColor = Color.Gray;
            fcbStokGrup.Location = new Point(125, 62);
            fcbStokGrup.Margin = new Padding(1);
            fcbStokGrup.Name = "fcbStokGrup";
            fcbStokGrup.Padding = new Padding(6, 4, 6, 4);
            fcbStokGrup.PlaceholderText = "Seçiniz...";
            fcbStokGrup.ReadOnly = false;
            fcbStokGrup.Size = new Size(162, 25);
            fcbStokGrup.TabIndex = 127;
            fcbStokGrup.ValueMember = "Id";
            // 
            // fcbMalzemeGrup
            // 
            fcbMalzemeGrup.BorderColor = Color.Silver;
            fcbMalzemeGrup.BorderRadius = 8;
            fcbMalzemeGrup.BorderSize = 1;
            fcbMalzemeGrup.DisplayMember = "ad";
            fcbMalzemeGrup.Font = new Font("Segoe UI", 8F);
            fcbMalzemeGrup.ForeColor = Color.Gray;
            fcbMalzemeGrup.Location = new Point(125, 89);
            fcbMalzemeGrup.Margin = new Padding(1);
            fcbMalzemeGrup.Name = "fcbMalzemeGrup";
            fcbMalzemeGrup.Padding = new Padding(6, 4, 6, 4);
            fcbMalzemeGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeGrup.ReadOnly = false;
            fcbMalzemeGrup.Size = new Size(162, 25);
            fcbMalzemeGrup.TabIndex = 128;
            fcbMalzemeGrup.ValueMember = "Id";
            // 
            // fcbMalzemeAltGrup
            // 
            fcbMalzemeAltGrup.BorderColor = Color.Silver;
            fcbMalzemeAltGrup.BorderRadius = 8;
            fcbMalzemeAltGrup.BorderSize = 1;
            fcbMalzemeAltGrup.DisplayMember = "ad";
            fcbMalzemeAltGrup.Font = new Font("Segoe UI", 8F);
            fcbMalzemeAltGrup.ForeColor = Color.Gray;
            fcbMalzemeAltGrup.Location = new Point(125, 116);
            fcbMalzemeAltGrup.Margin = new Padding(1);
            fcbMalzemeAltGrup.Name = "fcbMalzemeAltGrup";
            fcbMalzemeAltGrup.Padding = new Padding(6, 4, 6, 4);
            fcbMalzemeAltGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeAltGrup.ReadOnly = false;
            fcbMalzemeAltGrup.Size = new Size(162, 25);
            fcbMalzemeAltGrup.TabIndex = 129;
            fcbMalzemeAltGrup.ValueMember = "Id";
            // 
            // fcbMalzemeAltGrup2
            // 
            fcbMalzemeAltGrup2.BorderColor = Color.Silver;
            fcbMalzemeAltGrup2.BorderRadius = 8;
            fcbMalzemeAltGrup2.BorderSize = 1;
            fcbMalzemeAltGrup2.DisplayMember = "ad";
            fcbMalzemeAltGrup2.Font = new Font("Segoe UI", 8F);
            fcbMalzemeAltGrup2.ForeColor = Color.Gray;
            fcbMalzemeAltGrup2.Location = new Point(125, 143);
            fcbMalzemeAltGrup2.Margin = new Padding(1);
            fcbMalzemeAltGrup2.Name = "fcbMalzemeAltGrup2";
            fcbMalzemeAltGrup2.Padding = new Padding(6, 4, 6, 4);
            fcbMalzemeAltGrup2.PlaceholderText = "Seçiniz...";
            fcbMalzemeAltGrup2.ReadOnly = false;
            fcbMalzemeAltGrup2.Size = new Size(162, 25);
            fcbMalzemeAltGrup2.TabIndex = 130;
            fcbMalzemeAltGrup2.ValueMember = "Id";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label8.Location = new Point(308, 149);
            label8.Name = "label8";
            label8.Size = new Size(56, 13);
            label8.TabIndex = 133;
            label8.Text = "Parça Adı";
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = Color.SteelBlue;
            headerPanel1.Baslik = "Proje Dosyaları";
            headerPanel1.Location = new Point(0, 0);
            headerPanel1.Margin = new Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new Padding(1);
            headerPanel1.Size = new Size(1103, 25);
            headerPanel1.TabIndex = 135;
            // 
            // universalGrid1
            // 
            universalGrid1.Location = new Point(2, 175);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(1098, 462);
            universalGrid1.TabIndex = 136;
            // 
            // ctbParcaKod
            // 
            ctbParcaKod.BackColor = SystemColors.Window;
            ctbParcaKod.BorderColor = Color.Silver;
            ctbParcaKod.BorderFocusColor = Color.HotPink;
            ctbParcaKod.BorderSize = 1;
            ctbParcaKod.Font = new Font("Segoe UI", 8F);
            ctbParcaKod.ForeColor = Color.DimGray;
            ctbParcaKod.Location = new Point(376, 116);
            ctbParcaKod.Margin = new Padding(1);
            ctbParcaKod.Multiline = false;
            ctbParcaKod.Name = "ctbParcaKod";
            ctbParcaKod.Padding = new Padding(3);
            ctbParcaKod.PasswordChar = false;
            ctbParcaKod.PlaceholderColor = Color.DarkGray;
            ctbParcaKod.PlaceholderText = "";
            ctbParcaKod.ReadOnly = false;
            ctbParcaKod.SelectionStart = 0;
            ctbParcaKod.Size = new Size(262, 25);
            ctbParcaKod.TabIndex = 137;
            ctbParcaKod.TextAlignment = HorizontalAlignment.Left;
            ctbParcaKod.TextCustom = "";
            ctbParcaKod.UnderlinedStyle = false;
            // 
            // ctbParcaAd
            // 
            ctbParcaAd.BackColor = SystemColors.Window;
            ctbParcaAd.BorderColor = Color.Silver;
            ctbParcaAd.BorderFocusColor = Color.HotPink;
            ctbParcaAd.BorderSize = 1;
            ctbParcaAd.Font = new Font("Segoe UI", 8F);
            ctbParcaAd.ForeColor = Color.DimGray;
            ctbParcaAd.Location = new Point(376, 143);
            ctbParcaAd.Margin = new Padding(1);
            ctbParcaAd.Multiline = false;
            ctbParcaAd.Name = "ctbParcaAd";
            ctbParcaAd.Padding = new Padding(3);
            ctbParcaAd.PasswordChar = false;
            ctbParcaAd.PlaceholderColor = Color.DarkGray;
            ctbParcaAd.PlaceholderText = "";
            ctbParcaAd.ReadOnly = false;
            ctbParcaAd.SelectionStart = 0;
            ctbParcaAd.Size = new Size(262, 25);
            ctbParcaAd.TabIndex = 138;
            ctbParcaAd.TextAlignment = HorizontalAlignment.Left;
            ctbParcaAd.TextCustom = "";
            ctbParcaAd.UnderlinedStyle = false;
            // 
            // ProjeDosyalari
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 699);
            Controls.Add(ctbParcaAd);
            Controls.Add(ctbParcaKod);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            Controls.Add(label8);
            Controls.Add(fcbMalzemeAltGrup2);
            Controls.Add(fcbMalzemeAltGrup);
            Controls.Add(fcbMalzemeGrup);
            Controls.Add(fcbStokGrup);
            Controls.Add(fcbProjeKod);
            Controls.Add(roundedIconButton1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(chkStep);
            Controls.Add(chkDxf);
            Controls.Add(chkPdf);
            Controls.Add(chkSatinalma);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(panelFooter);
            Font = new Font("Segoe UI", 8F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProjeDosyalari";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProjeDosyalari";
            Load += ProjeDosyalari_Load;
            panelFooter.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.Black, 1, ButtonBorderStyle.Solid,
                Color.Black, 1, ButtonBorderStyle.Solid,
                Color.Black, 1, ButtonBorderStyle.Solid,
                Color.Black, 1, ButtonBorderStyle.Solid);
        }
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
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
        private FilterableComboBox fcbProjeKod;
        private FilterableComboBox fcbStokGrup;
        private FilterableComboBox fcbMalzemeGrup;
        private FilterableComboBox fcbMalzemeAltGrup;
        private FilterableComboBox fcbMalzemeAltGrup2;
        private System.Windows.Forms.ToolStripMenuItem seçilenKayıtlarıSilToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        public HeaderPanel headerPanel1;
        private UniversalGrid universalGrid1;
        private RoundedButton roundedButton1;
        private RoundedButton roundedButton2;
        private CustomTextBox ctbParcaKod;
        private CustomTextBox ctbParcaAd;
    }
}