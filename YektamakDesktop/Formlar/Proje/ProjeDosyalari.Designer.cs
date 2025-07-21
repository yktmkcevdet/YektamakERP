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
            clbProjeKodu = new YektamakDesktop.CustomControls.CustomComboListBox();
            panelFooter = new System.Windows.Forms.Panel();
            roundedButton4 = new YektamakDesktop.CustomControls.RoundedButton();
            label1 = new System.Windows.Forms.Label();
            clbStokGrup = new YektamakDesktop.CustomControls.CustomComboListBox();
            clbMalzemeGrup = new YektamakDesktop.CustomControls.CustomComboListBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ctbParcaAdi = new YektamakDesktop.CustomControls.CustomTextBox();
            chkSatinalma = new System.Windows.Forms.CheckBox();
            chkPdf = new System.Windows.Forms.CheckBox();
            chkDxf = new System.Windows.Forms.CheckBox();
            chkStep = new System.Windows.Forms.CheckBox();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            seçiliKalemlerİçinSaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            stokKartınıGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label5 = new System.Windows.Forms.Label();
            clbMalzemeAltGrup = new YektamakDesktop.CustomControls.CustomComboListBox();
            label6 = new System.Windows.Forms.Label();
            clbMalzemeAltGrup2 = new YektamakDesktop.CustomControls.CustomComboListBox();
            roundedIconButton1 = new YektamakDesktop.CustomControls.RoundedIconButton();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            universalGrid1 = universalGrid1 = DIContainer.GetService<UniversalGrid>(); 
            roundedIconButton2 = new YektamakDesktop.CustomControls.RoundedIconButton();
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
            // clbProjeKodu
            // 
            clbProjeKodu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbProjeKodu.ListBoxVisualSize = 5;
            clbProjeKodu.Location = new System.Drawing.Point(128, 45);
            clbProjeKodu.Margin = new System.Windows.Forms.Padding(1);
            clbProjeKodu.Name = "clbProjeKodu";
            clbProjeKodu.Padding = new System.Windows.Forms.Padding(1);
            clbProjeKodu.selectedDataRowId = null;
            clbProjeKodu.selectedDataRowValue = null;
            clbProjeKodu.Size = new System.Drawing.Size(251, 36);
            clbProjeKodu.TabIndex = 24;
            clbProjeKodu.SelectedIndexChanged += projeKod_SelectedIndexChanged;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(roundedButton4);
            panelFooter.Location = new System.Drawing.Point(0, 741);
            panelFooter.Margin = new System.Windows.Forms.Padding(0);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1284, 65);
            panelFooter.TabIndex = 101;
            // 
            // roundedButton4
            // 
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
            // clbStokGrup
            // 
            clbStokGrup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbStokGrup.ListBoxVisualSize = 5;
            clbStokGrup.Location = new System.Drawing.Point(128, 75);
            clbStokGrup.Margin = new System.Windows.Forms.Padding(1);
            clbStokGrup.Name = "clbStokGrup";
            clbStokGrup.Padding = new System.Windows.Forms.Padding(1);
            clbStokGrup.selectedDataRowId = null;
            clbStokGrup.selectedDataRowValue = null;
            clbStokGrup.Size = new System.Drawing.Size(251, 36);
            clbStokGrup.TabIndex = 102;
            clbStokGrup.SelectedIndexChanged += parcaGrubu_SelectedIndexChanged;
            // 
            // clbMalzemeGrup
            // 
            clbMalzemeGrup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbMalzemeGrup.ListBoxVisualSize = 5;
            clbMalzemeGrup.Location = new System.Drawing.Point(128, 107);
            clbMalzemeGrup.Margin = new System.Windows.Forms.Padding(1);
            clbMalzemeGrup.Name = "clbMalzemeGrup";
            clbMalzemeGrup.Padding = new System.Windows.Forms.Padding(1);
            clbMalzemeGrup.selectedDataRowId = null;
            clbMalzemeGrup.selectedDataRowValue = null;
            clbMalzemeGrup.Size = new System.Drawing.Size(251, 36);
            clbMalzemeGrup.TabIndex = 104;
            clbMalzemeGrup.SelectedIndexChanged += parcaAltGrubu_SelectedIndexChanged;
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
            label4.Location = new System.Drawing.Point(9, 218);
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
            ctbParcaAdi.Location = new System.Drawing.Point(128, 212);
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
            ctbParcaAdi.TextChanged += textBoxParcaAdi_TextChanged;
            ctbParcaAdi.KeyDown += parcaAdi_KeyDown;
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
            chkSatinalma.CheckedChanged += chkSatinalma_CheckedChanged;
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
            chkPdf.CheckStateChanged += chkPdf_CheckStateChanged;
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
            chkDxf.CheckStateChanged += chkDxf_CheckedChanged;
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
            chkStep.CheckedChanged += chkStep_CheckedChanged;
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
            seçiliKalemlerİçinSaToolStripMenuItem.Click += CreateSatinalmaTalep;
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
            // clbMalzemeAltGrup
            // 
            clbMalzemeAltGrup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbMalzemeAltGrup.ListBoxVisualSize = 5;
            clbMalzemeAltGrup.Location = new System.Drawing.Point(127, 142);
            clbMalzemeAltGrup.Margin = new System.Windows.Forms.Padding(1);
            clbMalzemeAltGrup.Name = "clbMalzemeAltGrup";
            clbMalzemeAltGrup.Padding = new System.Windows.Forms.Padding(1);
            clbMalzemeAltGrup.selectedDataRowId = null;
            clbMalzemeAltGrup.selectedDataRowValue = null;
            clbMalzemeAltGrup.Size = new System.Drawing.Size(251, 36);
            clbMalzemeAltGrup.TabIndex = 118;
            clbMalzemeAltGrup.SelectedIndexChanged += cbxMalzemeAltGrup_SelectedIndexChanged;
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
            // clbMalzemeAltGrup2
            // 
            clbMalzemeAltGrup2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbMalzemeAltGrup2.ListBoxVisualSize = 5;
            clbMalzemeAltGrup2.Location = new System.Drawing.Point(128, 180);
            clbMalzemeAltGrup2.Margin = new System.Windows.Forms.Padding(1);
            clbMalzemeAltGrup2.Name = "clbMalzemeAltGrup2";
            clbMalzemeAltGrup2.Padding = new System.Windows.Forms.Padding(1);
            clbMalzemeAltGrup2.selectedDataRowId = null;
            clbMalzemeAltGrup2.selectedDataRowValue = null;
            clbMalzemeAltGrup2.Size = new System.Drawing.Size(251, 36);
            clbMalzemeAltGrup2.TabIndex = 120;
            clbMalzemeAltGrup2.SelectedIndexChanged += cbxMalzemeAltGrup2_SelectedIndexChanged;
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
            universalGrid1.Location = new System.Drawing.Point(8, 246);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1273, 498);
            universalGrid1.TabIndex = 124;
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
            roundedIconButton2.Click += roundedIconButton2_Click;
            // 
            // ProjeDosyalari
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1287, 807);
            Controls.Add(roundedIconButton2);
            Controls.Add(headerPanel1);
            Controls.Add(roundedIconButton1);
            Controls.Add(label6);
            Controls.Add(clbMalzemeAltGrup2);
            Controls.Add(label5);
            Controls.Add(clbMalzemeAltGrup);
            Controls.Add(chkStep);
            Controls.Add(chkDxf);
            Controls.Add(chkPdf);
            Controls.Add(chkSatinalma);
            Controls.Add(ctbParcaAdi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(clbMalzemeGrup);
            Controls.Add(label1);
            Controls.Add(clbStokGrup);
            Controls.Add(label2);
            Controls.Add(panelFooter);
            Controls.Add(clbProjeKodu);
            Controls.Add(universalGrid1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ProjeDosyalari";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ProjeDosyalari";
            FormClosing += ProjeDosyalari_FormClosing;
            Load += form_Load;
            panelFooter.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomComboListBox clbProjeKodu;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomComboListBox clbStokGrup;
        private CustomControls.CustomComboListBox clbMalzemeGrup;
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
        private CustomControls.CustomComboListBox clbMalzemeAltGrup;
        private System.Windows.Forms.Label label6;
        private CustomControls.CustomComboListBox clbMalzemeAltGrup2;
        private CustomControls.RoundedIconButton roundedIconButton1;
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.RoundedIconButton roundedIconButton2;
    }
}