using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTalepTeklifFormu
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
            headerPanel1 = new HeaderPanel();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            btnTeklif = new RoundedIconButton();
            ctxBeginTeslimTarihi = new CustomTextBoxTarih();
            ctxEndTeslimTarihi = new CustomTextBoxTarih();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            parçaListesiniGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            stokKartınıGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ctbBeginTalepTarihi = new CustomTextBoxTarih();
            ctbEndTalepTarihi = new CustomTextBoxTarih();
            panel1 = new System.Windows.Forms.Panel();
            universalGrid1 = new UniversalGrid();
            label1 = new System.Windows.Forms.Label();
            clbStokGrupId = new FilterableComboBox();
            clbMalzemeGrupId = new FilterableComboBox();
            clbProjeKod = new FilterableComboBox();
            fcbBoyut = new FilterableCheckedComboBox();
            isTeklif = new System.Windows.Forms.CheckBox();
            fccMalzemeAltGrupId = new FilterableCheckedComboBox();
            fccMalzemeAltGrup2 = new FilterableCheckedComboBox();
            dgv = new System.Windows.Forms.DataGridView();
            chkBukum = new System.Windows.Forms.CheckBox();
            roundedButton1 = new RoundedButton();
            contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Teklif Oluşturma Formu";
            headerPanel1.Location = new System.Drawing.Point(-2, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1098, 25);
            headerPanel1.TabIndex = 0;
            headerPanel1.Visible = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnTeklif
            // 
            btnTeklif.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
            btnTeklif.BorderColor = System.Drawing.Color.Black;
            btnTeklif.BorderSize = 0;
            btnTeklif.CornerRadius = 6;
            btnTeklif.Cursor = System.Windows.Forms.Cursors.Hand;
            btnTeklif.FlatAppearance.BorderSize = 0;
            btnTeklif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTeklif.ForeColor = System.Drawing.SystemColors.ControlText;
            btnTeklif.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnTeklif.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnTeklif.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnTeklif.HoverColor2 = System.Drawing.Color.Navy;
            btnTeklif.IconChar = FontAwesome.Sharp.IconChar.CommentDollar;
            btnTeklif.IconColor = System.Drawing.Color.Black;
            btnTeklif.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnTeklif.IconSize = 24;
            btnTeklif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnTeklif.Location = new System.Drawing.Point(564, 321);
            btnTeklif.Name = "btnTeklif";
            btnTeklif.Size = new System.Drawing.Size(149, 34);
            btnTeklif.TabIndex = 4;
            btnTeklif.Text = "teklif iste";
            btnTeklif.UseVisualStyleBackColor = false;
            btnTeklif.Click += btnTeklif_Click;
            // 
            // ctxBeginTeslimTarihi
            // 
            ctxBeginTeslimTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctxBeginTeslimTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctxBeginTeslimTarihi.Location = new System.Drawing.Point(776, 315);
            ctxBeginTeslimTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctxBeginTeslimTarihi.Name = "ctxBeginTeslimTarihi";
            ctxBeginTeslimTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctxBeginTeslimTarihi.Size = new System.Drawing.Size(145, 32);
            ctxBeginTeslimTarihi.TabIndex = 9;
            ctxBeginTeslimTarihi.Visible = false;
            // 
            // ctxEndTeslimTarihi
            // 
            ctxEndTeslimTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctxEndTeslimTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctxEndTeslimTarihi.Location = new System.Drawing.Point(923, 315);
            ctxEndTeslimTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctxEndTeslimTarihi.Name = "ctxEndTeslimTarihi";
            ctxEndTeslimTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctxEndTeslimTarihi.Size = new System.Drawing.Size(145, 32);
            ctxEndTeslimTarihi.TabIndex = 10;
            ctxEndTeslimTarihi.Visible = false;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { parçaListesiniGösterToolStripMenuItem, stokKartınıGörüntüleToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new System.Drawing.Size(191, 48);
            // 
            // parçaListesiniGösterToolStripMenuItem
            // 
            parçaListesiniGösterToolStripMenuItem.Name = "parçaListesiniGösterToolStripMenuItem";
            parçaListesiniGösterToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            parçaListesiniGösterToolStripMenuItem.Text = "Parça Listesini Göster";
            parçaListesiniGösterToolStripMenuItem.Click += parçaListesiniGösterToolStripMenuItem_Click;
            // 
            // stokKartınıGörüntüleToolStripMenuItem
            // 
            stokKartınıGörüntüleToolStripMenuItem.Name = "stokKartınıGörüntüleToolStripMenuItem";
            stokKartınıGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            stokKartınıGörüntüleToolStripMenuItem.Text = "Stok Kartını Görüntüle";
            stokKartınıGörüntüleToolStripMenuItem.Click += stokKartınıGörüntüleToolStripMenuItem_Click;
            // 
            // ctbBeginTalepTarihi
            // 
            ctbBeginTalepTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbBeginTalepTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbBeginTalepTarihi.Location = new System.Drawing.Point(776, 283);
            ctbBeginTalepTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbBeginTalepTarihi.Name = "ctbBeginTalepTarihi";
            ctbBeginTalepTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbBeginTalepTarihi.Size = new System.Drawing.Size(145, 32);
            ctbBeginTalepTarihi.TabIndex = 12;
            ctbBeginTalepTarihi.Visible = false;
            // 
            // ctbEndTalepTarihi
            // 
            ctbEndTalepTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbEndTalepTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbEndTalepTarihi.Location = new System.Drawing.Point(923, 283);
            ctbEndTalepTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbEndTalepTarihi.Name = "ctbEndTalepTarihi";
            ctbEndTalepTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbEndTalepTarihi.Size = new System.Drawing.Size(145, 32);
            ctbEndTalepTarihi.TabIndex = 13;
            ctbEndTalepTarihi.Visible = false;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Location = new System.Drawing.Point(306, 55);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(407, 255);
            panel1.TabIndex = 14;
            // 
            // universalGrid1
            // 
            universalGrid1.AutoScroll = true;
            universalGrid1.Location = new System.Drawing.Point(-2, 361);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1098, 386);
            universalGrid1.TabIndex = 15;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(306, 37);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(132, 15);
            label1.TabIndex = 16;
            label1.Text = "Teklif İstenecek Firmalar";
            // 
            // clbStokGrupId
            // 
            clbStokGrupId.AutoSize = true;
            clbStokGrupId.BorderColor = System.Drawing.Color.Silver;
            clbStokGrupId.BorderRadius = 8;
            clbStokGrupId.BorderSize = 1;
            clbStokGrupId.DisplayMember = "ad";
            clbStokGrupId.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbStokGrupId.Location = new System.Drawing.Point(37, 87);
            clbStokGrupId.Margin = new System.Windows.Forms.Padding(1);
            clbStokGrupId.Name = "clbStokGrupId";
            clbStokGrupId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbStokGrupId.PlaceholderText = "Stok Grubu";
            clbStokGrupId.ReadOnly = false;
            clbStokGrupId.Size = new System.Drawing.Size(250, 25);
            clbStokGrupId.TabIndex = 17;
            clbStokGrupId.ValueMember = "Id";
            clbStokGrupId.SelectedIndexChanged += cbxStokGrupId_SelectedIndexChanged;
            // 
            // clbMalzemeGrupId
            // 
            clbMalzemeGrupId.AutoScroll = true;
            clbMalzemeGrupId.BorderColor = System.Drawing.Color.Silver;
            clbMalzemeGrupId.BorderRadius = 8;
            clbMalzemeGrupId.BorderSize = 1;
            clbMalzemeGrupId.DisplayMember = "ad";
            clbMalzemeGrupId.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbMalzemeGrupId.Location = new System.Drawing.Point(37, 114);
            clbMalzemeGrupId.Margin = new System.Windows.Forms.Padding(1);
            clbMalzemeGrupId.Name = "clbMalzemeGrupId";
            clbMalzemeGrupId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbMalzemeGrupId.PlaceholderText = "Malzeme Grubu";
            clbMalzemeGrupId.ReadOnly = false;
            clbMalzemeGrupId.Size = new System.Drawing.Size(250, 25);
            clbMalzemeGrupId.TabIndex = 18;
            clbMalzemeGrupId.ValueMember = "Id";
            clbMalzemeGrupId.SelectedIndexChanged += cbxMalzemeGrupId_SelectedIndexChanged;
            // 
            // clbProjeKod
            // 
            clbProjeKod.AutoSize = true;
            clbProjeKod.BorderColor = System.Drawing.Color.Silver;
            clbProjeKod.BorderRadius = 8;
            clbProjeKod.BorderSize = 1;
            clbProjeKod.DisplayMember = "kod";
            clbProjeKod.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbProjeKod.Location = new System.Drawing.Point(37, 60);
            clbProjeKod.Margin = new System.Windows.Forms.Padding(1);
            clbProjeKod.Name = "clbProjeKod";
            clbProjeKod.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbProjeKod.PlaceholderText = "Proje Kodu";
            clbProjeKod.ReadOnly = false;
            clbProjeKod.Size = new System.Drawing.Size(250, 25);
            clbProjeKod.TabIndex = 20;
            clbProjeKod.ValueMember = "Id";
            clbProjeKod.SelectedIndexChanged += clbProjeKod_SelectedIndexChanged;
            // 
            // fcbBoyut
            // 
            fcbBoyut.AutoScroll = true;
            fcbBoyut.Location = new System.Drawing.Point(37, 239);
            fcbBoyut.Name = "fcbBoyut";
            fcbBoyut.Padding = new System.Windows.Forms.Padding(5);
            fcbBoyut.PlaceholderText = "Boyut";
            fcbBoyut.Size = new System.Drawing.Size(250, 42);
            fcbBoyut.TabIndex = 23;
            fcbBoyut.ItemsChanged += fcbBoyut_SelectedIndexChanged;
            // 
            // isTeklif
            // 
            isTeklif.AutoSize = true;
            isTeklif.Location = new System.Drawing.Point(38, 314);
            isTeklif.Name = "isTeklif";
            isTeklif.Size = new System.Drawing.Size(147, 19);
            isTeklif.TabIndex = 24;
            isTeklif.Text = "Teklif İstenenleri Göster";
            isTeklif.UseVisualStyleBackColor = true;
            
            // 
            // fccMalzemeAltGrupId
            // 
            fccMalzemeAltGrupId.AutoScroll = true;
            fccMalzemeAltGrupId.Location = new System.Drawing.Point(37, 143);
            fccMalzemeAltGrupId.Name = "fccMalzemeAltGrupId";
            fccMalzemeAltGrupId.Padding = new System.Windows.Forms.Padding(5);
            fccMalzemeAltGrupId.PlaceholderText = "Malzeme Alt Grubu";
            fccMalzemeAltGrupId.Size = new System.Drawing.Size(250, 42);
            fccMalzemeAltGrupId.TabIndex = 25;
            fccMalzemeAltGrupId.ItemsChanged += fccMalzemeAltGrupId_ItemsChanged;
            // 
            // fccMalzemeAltGrup2
            // 
            fccMalzemeAltGrup2.AutoScroll = true;
            fccMalzemeAltGrup2.Location = new System.Drawing.Point(37, 191);
            fccMalzemeAltGrup2.Name = "fccMalzemeAltGrup2";
            fccMalzemeAltGrup2.Padding = new System.Windows.Forms.Padding(5);
            fccMalzemeAltGrup2.PlaceholderText = "Malzeme Alt Grup2";
            fccMalzemeAltGrup2.Size = new System.Drawing.Size(250, 42);
            fccMalzemeAltGrup2.TabIndex = 26;
            fccMalzemeAltGrup2.ItemsChanged += fccMalzemeAltGrup2_ItemsChanged;
            // 
            // dgv
            // 
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new System.Drawing.Point(719, 55);
            dgv.Name = "dgv";
            dgv.Size = new System.Drawing.Size(371, 224);
            dgv.TabIndex = 27;
            // 
            // chkBukum
            // 
            chkBukum.AutoSize = true;
            chkBukum.Location = new System.Drawing.Point(38, 289);
            chkBukum.Name = "chkBukum";
            chkBukum.Size = new System.Drawing.Size(69, 19);
            chkBukum.TabIndex = 28;
            chkBukum.Text = "Büküm?";
            chkBukum.ThreeState = true;
            chkBukum.UseVisualStyleBackColor = true;
            chkBukum.CheckStateChanged += checkBox1_CheckedChanged;
            // 
            // roundedButton1
            // 
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Black;
            roundedButton1.BorderSize = 0;
            roundedButton1.CornerRadius = 10;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedButton1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedButton1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedButton1.HoverColor2 = System.Drawing.Color.Navy;
            roundedButton1.Icon = null;
            roundedButton1.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton1.Location = new System.Drawing.Point(358, 318);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(150, 40);
            roundedButton1.TabIndex = 29;
            roundedButton1.Text = "SİPARİŞ OLUŞTUR";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // SatinalmaTalepTeklifFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1096, 745);
            Controls.Add(roundedButton1);
            Controls.Add(chkBukum);
            Controls.Add(dgv);
            Controls.Add(fccMalzemeAltGrup2);
            Controls.Add(fccMalzemeAltGrupId);
            Controls.Add(isTeklif);
            Controls.Add(fcbBoyut);
            Controls.Add(clbProjeKod);
            Controls.Add(clbMalzemeGrupId);
            Controls.Add(clbStokGrupId);
            Controls.Add(label1);
            Controls.Add(universalGrid1);
            Controls.Add(panel1);
            Controls.Add(ctbEndTalepTarihi);
            Controls.Add(ctbBeginTalepTarihi);
            Controls.Add(ctxEndTeslimTarihi);
            Controls.Add(ctxBeginTeslimTarihi);
            Controls.Add(btnTeklif);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepTeklifFormu";
            Text = "SatinalmaTalepTeklifFormu";
            FormClosing += SatinalmaTalepTeklifFormu_FormClosing;
            contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public CustomControls.HeaderPanel headerPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private CustomControls.RoundedIconButton btnTeklif;
        private CustomControls.CustomTextBoxTarih ctxBeginTeslimTarihi;
        private CustomControls.CustomTextBoxTarih ctxEndTeslimTarihi;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem parçaListesiniGösterToolStripMenuItem;
        private CustomControls.CustomTextBoxTarih ctbBeginTalepTarihi;
        private CustomControls.CustomTextBoxTarih ctbEndTalepTarihi;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.Label label1;
        private FilterableComboBox clbStokGrupId;
        private FilterableComboBox clbMalzemeGrupId;
        private FilterableComboBox clbProjeKod;
        private FilterableCheckedComboBox fcbBoyut;
        private System.Windows.Forms.ToolStripMenuItem stokKartınıGörüntüleToolStripMenuItem;
        private System.Windows.Forms.CheckBox isTeklif;
        private FilterableCheckedComboBox fccMalzemeAltGrupId;
        private FilterableCheckedComboBox fccMalzemeAltGrup2;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.CheckBox chkBukum;
        private RoundedButton roundedButton1;
    }
}