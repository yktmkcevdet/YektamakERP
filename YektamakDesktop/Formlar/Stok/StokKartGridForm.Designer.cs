using System.Drawing;
using System.Windows.Forms;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Stok
{
    partial class StokKartGridForm
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
            ctbParcaAdi = new CustomTextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            buttonSatisSiparisTeklifTalepEkle = new Button();
            label5 = new Label();
            label6 = new Label();
            headerPanel1 = new HeaderPanel();
            universalGrid1 = new UniversalGrid();
            contextMenuStrip1 = new ContextMenuStrip(components);
            stokKartınıGörüntüleToolStripMenuItem = new ToolStripMenuItem();
            stokKartınıSilToolStripMenuItem = new ToolStripMenuItem();
            fcbProjeKodu = new FilterableComboBox();
            fcbStokGrup = new FilterableComboBox();
            fcbMalzemeGrup = new FilterableComboBox();
            fcbMalzemeAltGrup = new FilterableComboBox();
            fcbMalzemeAltGrup2 = new FilterableComboBox();
            fcbStokTip = new FilterableComboBox();
            label7 = new Label();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ctbParcaAdi
            // 
            ctbParcaAdi.BackColor = Color.White;
            ctbParcaAdi.BorderColor = Color.Silver;
            ctbParcaAdi.BorderFocusColor = Color.HotPink;
            ctbParcaAdi.BorderSize = 1;
            ctbParcaAdi.Font = new Font("Segoe UI", 8F);
            ctbParcaAdi.ForeColor = Color.Black;
            ctbParcaAdi.Location = new Point(143, 119);
            ctbParcaAdi.Margin = new Padding(1);
            ctbParcaAdi.Multiline = false;
            ctbParcaAdi.Name = "ctbParcaAdi";
            ctbParcaAdi.Padding = new Padding(7, 5, 7, 5);
            ctbParcaAdi.PasswordChar = false;
            ctbParcaAdi.PlaceholderColor = Color.DarkGray;
            ctbParcaAdi.PlaceholderText = "";
            ctbParcaAdi.ReadOnly = false;
            ctbParcaAdi.SelectionStart = 0;
            ctbParcaAdi.Size = new Size(176, 29);
            ctbParcaAdi.TabIndex = 116;
            ctbParcaAdi.TextAlignment = HorizontalAlignment.Left;
            ctbParcaAdi.TextCustom = "";
            ctbParcaAdi.UnderlinedStyle = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label4.Location = new Point(24, 124);
            label4.Name = "label4";
            label4.Size = new Size(56, 13);
            label4.TabIndex = 115;
            label4.Text = "Parça Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label3.Location = new Point(367, 71);
            label3.Name = "label3";
            label3.Size = new Size(108, 13);
            label3.TabIndex = 114;
            label3.Text = "Malzeme Alt Grubu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label1.Location = new Point(367, 44);
            label1.Name = "label1";
            label1.Size = new Size(90, 13);
            label1.TabIndex = 112;
            label1.Text = "Malzeme Grubu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label2.Location = new Point(24, 43);
            label2.Name = "label2";
            label2.Size = new Size(65, 13);
            label2.TabIndex = 110;
            label2.Text = "Proje Kodu";
            // 
            // buttonSatisSiparisTeklifTalepEkle
            // 
            buttonSatisSiparisTeklifTalepEkle.BackColor = Color.Transparent;
            buttonSatisSiparisTeklifTalepEkle.BackgroundImage = Properties.Resources.ekle45x45;
            buttonSatisSiparisTeklifTalepEkle.BackgroundImageLayout = ImageLayout.Zoom;
            buttonSatisSiparisTeklifTalepEkle.Cursor = Cursors.Hand;
            buttonSatisSiparisTeklifTalepEkle.FlatAppearance.BorderSize = 0;
            buttonSatisSiparisTeklifTalepEkle.FlatStyle = FlatStyle.Flat;
            buttonSatisSiparisTeklifTalepEkle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonSatisSiparisTeklifTalepEkle.ForeColor = SystemColors.Window;
            buttonSatisSiparisTeklifTalepEkle.Location = new Point(729, 57);
            buttonSatisSiparisTeklifTalepEkle.Name = "buttonSatisSiparisTeklifTalepEkle";
            buttonSatisSiparisTeklifTalepEkle.Size = new Size(42, 30);
            buttonSatisSiparisTeklifTalepEkle.TabIndex = 118;
            buttonSatisSiparisTeklifTalepEkle.UseVisualStyleBackColor = false;
            buttonSatisSiparisTeklifTalepEkle.Click += buttonEkle_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label5.Location = new Point(367, 98);
            label5.Name = "label5";
            label5.Size = new Size(117, 13);
            label5.TabIndex = 124;
            label5.Text = "Malzeme Alt Grubu 2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label6.Location = new Point(24, 97);
            label6.Name = "label6";
            label6.Size = new Size(66, 13);
            label6.TabIndex = 126;
            label6.Text = "Stok Grubu";
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = Color.Firebrick;
            headerPanel1.Baslik = "Stok Kartları";
            headerPanel1.Location = new Point(-2, -1);
            headerPanel1.Margin = new Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new Padding(1);
            headerPanel1.Size = new Size(1089, 25);
            headerPanel1.TabIndex = 128;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new Point(12, 148);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(1062, 539);
            universalGrid1.TabIndex = 129;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { stokKartınıGörüntüleToolStripMenuItem, stokKartınıSilToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(229, 48);
            // 
            // stokKartınıGörüntüleToolStripMenuItem
            // 
            stokKartınıGörüntüleToolStripMenuItem.Name = "stokKartınıGörüntüleToolStripMenuItem";
            stokKartınıGörüntüleToolStripMenuItem.Size = new Size(228, 22);
            stokKartınıGörüntüleToolStripMenuItem.Text = "Stok Kartı Görüntüle & Düzenle";
            stokKartınıGörüntüleToolStripMenuItem.Click += stokKartınıGörüntüleToolStripMenuItem_Click;
            // 
            // stokKartınıSilToolStripMenuItem
            // 
            stokKartınıSilToolStripMenuItem.Name = "stokKartınıSilToolStripMenuItem";
            stokKartınıSilToolStripMenuItem.Size = new Size(228, 22);
            stokKartınıSilToolStripMenuItem.Text = "Seçili Stok Kartlarını Sil";
            // 
            // fcbProjeKodu
            // 
            fcbProjeKodu.BorderColor = Color.Silver;
            fcbProjeKodu.BorderRadius = 8;
            fcbProjeKodu.BorderSize = 1;
            fcbProjeKodu.DisplayMember = "kod";
            fcbProjeKodu.Font = new Font("Segoe UI", 8F);
            fcbProjeKodu.Location = new Point(143, 38);
            fcbProjeKodu.Margin = new Padding(1);
            fcbProjeKodu.Name = "fcbProjeKodu";
            fcbProjeKodu.Padding = new Padding(7, 4, 7, 4);
            fcbProjeKodu.PlaceholderText = "Seçiniz...";
            fcbProjeKodu.Size = new Size(176, 25);
            fcbProjeKodu.TabIndex = 130;
            fcbProjeKodu.ValueMember = "Id";
            // 
            // fcbStokGrup
            // 
            fcbStokGrup.BorderColor = Color.Silver;
            fcbStokGrup.BorderRadius = 8;
            fcbStokGrup.BorderSize = 1;
            fcbStokGrup.DisplayMember = "ad";
            fcbStokGrup.Font = new Font("Segoe UI", 8F);
            fcbStokGrup.Location = new Point(143, 92);
            fcbStokGrup.Margin = new Padding(1);
            fcbStokGrup.Name = "fcbStokGrup";
            fcbStokGrup.Padding = new Padding(7, 4, 7, 4);
            fcbStokGrup.PlaceholderText = "Seçiniz...";
            fcbStokGrup.Size = new Size(176, 25);
            fcbStokGrup.TabIndex = 131;
            fcbStokGrup.ValueMember = "Id";
            fcbStokGrup.SelectedIndexChanged += cbxStokGrup_SelectedIndexChanged;
            // 
            // fcbMalzemeGrup
            // 
            fcbMalzemeGrup.BorderColor = Color.Silver;
            fcbMalzemeGrup.BorderRadius = 8;
            fcbMalzemeGrup.BorderSize = 1;
            fcbMalzemeGrup.DisplayMember = "ad";
            fcbMalzemeGrup.Font = new Font("Segoe UI", 8F);
            fcbMalzemeGrup.Location = new Point(486, 38);
            fcbMalzemeGrup.Margin = new Padding(1);
            fcbMalzemeGrup.Name = "fcbMalzemeGrup";
            fcbMalzemeGrup.Padding = new Padding(7, 4, 7, 4);
            fcbMalzemeGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeGrup.Size = new Size(176, 25);
            fcbMalzemeGrup.TabIndex = 132;
            fcbMalzemeGrup.ValueMember = "Id";
            fcbMalzemeGrup.SelectedIndexChanged += malzemeGrubu_SelectedIndexChanged;
            // 
            // fcbMalzemeAltGrup
            // 
            fcbMalzemeAltGrup.BorderColor = Color.Silver;
            fcbMalzemeAltGrup.BorderRadius = 8;
            fcbMalzemeAltGrup.BorderSize = 1;
            fcbMalzemeAltGrup.DisplayMember = "ad";
            fcbMalzemeAltGrup.Font = new Font("Segoe UI", 8F);
            fcbMalzemeAltGrup.Location = new Point(486, 65);
            fcbMalzemeAltGrup.Margin = new Padding(1);
            fcbMalzemeAltGrup.Name = "fcbMalzemeAltGrup";
            fcbMalzemeAltGrup.Padding = new Padding(7, 4, 7, 4);
            fcbMalzemeAltGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeAltGrup.Size = new Size(176, 25);
            fcbMalzemeAltGrup.TabIndex = 133;
            fcbMalzemeAltGrup.ValueMember = "Id";
            fcbMalzemeAltGrup.SelectedIndexChanged += cbxMalzemeAltGrup_SelectedIndexChanged;
            // 
            // fcbMalzemeAltGrup2
            // 
            fcbMalzemeAltGrup2.BorderColor = Color.Silver;
            fcbMalzemeAltGrup2.BorderRadius = 8;
            fcbMalzemeAltGrup2.BorderSize = 1;
            fcbMalzemeAltGrup2.DisplayMember = "ad";
            fcbMalzemeAltGrup2.Font = new Font("Segoe UI", 8F);
            fcbMalzemeAltGrup2.Location = new Point(486, 92);
            fcbMalzemeAltGrup2.Margin = new Padding(1);
            fcbMalzemeAltGrup2.Name = "fcbMalzemeAltGrup2";
            fcbMalzemeAltGrup2.Padding = new Padding(7, 4, 7, 4);
            fcbMalzemeAltGrup2.PlaceholderText = "Seçiniz...";
            fcbMalzemeAltGrup2.Size = new Size(176, 25);
            fcbMalzemeAltGrup2.TabIndex = 134;
            fcbMalzemeAltGrup2.ValueMember = "Id";
            fcbMalzemeAltGrup2.MouseDoubleClick += cbxMalzemeAltGrup2_DoubleClick;
            // 
            // fcbStokTip
            // 
            fcbStokTip.BorderColor = Color.Silver;
            fcbStokTip.BorderRadius = 8;
            fcbStokTip.BorderSize = 1;
            fcbStokTip.DisplayMember = "ad";
            fcbStokTip.Font = new Font("Segoe UI", 8F);
            fcbStokTip.Location = new Point(143, 65);
            fcbStokTip.Margin = new Padding(1);
            fcbStokTip.Name = "fcbStokTip";
            fcbStokTip.Padding = new Padding(7, 4, 7, 4);
            fcbStokTip.PlaceholderText = "Seçiniz...";
            fcbStokTip.Size = new Size(176, 25);
            fcbStokTip.TabIndex = 135;
            fcbStokTip.ValueMember = "Id";
            fcbStokTip.SelectedIndexChanged += cbxStokTip_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label7.Location = new Point(24, 70);
            label7.Name = "label7";
            label7.Size = new Size(52, 13);
            label7.TabIndex = 136;
            label7.Text = "Stok Tipi";
            // 
            // StokKartGridForm
            // 
            AutoScaleDimensions = new SizeF(7F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 697);
            Controls.Add(label7);
            Controls.Add(fcbStokTip);
            Controls.Add(fcbMalzemeAltGrup2);
            Controls.Add(fcbMalzemeAltGrup);
            Controls.Add(fcbMalzemeGrup);
            Controls.Add(fcbStokGrup);
            Controls.Add(fcbProjeKodu);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(buttonSatisSiparisTeklifTalepEkle);
            Controls.Add(ctbParcaAdi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StokKartGridForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SatinalmaTalepGridForm";
            FormClosing += StokKartGridForm_FormClosing;
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
        private CustomControls.CustomTextBox ctbParcaAdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSatisSiparisTeklifTalepEkle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public CustomControls.HeaderPanel headerPanel1;
        private UniversalGrid universalGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stokKartınıGörüntüleToolStripMenuItem;
        private FilterableComboBox fcbProjeKodu;
        private FilterableComboBox fcbStokGrup;
        private FilterableComboBox fcbMalzemeGrup;
        private FilterableComboBox fcbMalzemeAltGrup;
        private FilterableComboBox fcbMalzemeAltGrup2;
        private FilterableComboBox fcbStokTip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem stokKartınıSilToolStripMenuItem;
    }
}