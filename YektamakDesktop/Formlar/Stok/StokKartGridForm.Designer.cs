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
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            buttonSatisSiparisTeklifTalepEkle = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            headerPanel1 = new HeaderPanel();
            universalGrid1 = new UniversalGrid();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            stokKartınıGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            stokKartınıSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fcbProjeKodu = new FilterableComboBox();
            fcbStokGrup = new FilterableComboBox();
            fcbMalzemeGrup = new FilterableComboBox();
            fcbMalzemeAltGrup = new FilterableComboBox();
            fcbMalzemeAltGrup2 = new FilterableComboBox();
            fcbStokTip = new FilterableComboBox();
            label7 = new System.Windows.Forms.Label();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ctbParcaAdi
            // 
            ctbParcaAdi.BackColor = System.Drawing.Color.White;
            ctbParcaAdi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbParcaAdi.ForeColor = System.Drawing.Color.Black;
            ctbParcaAdi.Location = new System.Drawing.Point(143, 165);
            ctbParcaAdi.Multiline = false;
            ctbParcaAdi.Name = "ctbParcaAdi";
            ctbParcaAdi.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbParcaAdi.Size = new System.Drawing.Size(176, 28);
            ctbParcaAdi.TabIndex = 116;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(24, 171);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 15);
            label4.TabIndex = 115;
            label4.Text = "Parça Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(367, 98);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(109, 15);
            label3.TabIndex = 114;
            label3.Text = "Malzeme Alt Grubu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(367, 66);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 15);
            label1.TabIndex = 112;
            label1.Text = "Malzeme Grubu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(24, 69);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 110;
            label2.Text = "Proje Kodu";
            // 
            // buttonSatisSiparisTeklifTalepEkle
            // 
            buttonSatisSiparisTeklifTalepEkle.BackColor = System.Drawing.Color.Transparent;
            buttonSatisSiparisTeklifTalepEkle.BackgroundImage = Properties.Resources.ekle45x45;
            buttonSatisSiparisTeklifTalepEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonSatisSiparisTeklifTalepEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonSatisSiparisTeklifTalepEkle.FlatAppearance.BorderSize = 0;
            buttonSatisSiparisTeklifTalepEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSatisSiparisTeklifTalepEkle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            buttonSatisSiparisTeklifTalepEkle.ForeColor = System.Drawing.SystemColors.Window;
            buttonSatisSiparisTeklifTalepEkle.Location = new System.Drawing.Point(620, 165);
            buttonSatisSiparisTeklifTalepEkle.Name = "buttonSatisSiparisTeklifTalepEkle";
            buttonSatisSiparisTeklifTalepEkle.Size = new System.Drawing.Size(42, 35);
            buttonSatisSiparisTeklifTalepEkle.TabIndex = 118;
            buttonSatisSiparisTeklifTalepEkle.UseVisualStyleBackColor = false;
            buttonSatisSiparisTeklifTalepEkle.Click += buttonEkle_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(367, 138);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(118, 15);
            label5.TabIndex = 124;
            label5.Text = "Malzeme Alt Grubu 2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(24, 137);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(66, 15);
            label6.TabIndex = 126;
            label6.Text = "Stok Grubu";
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Stok Kartları";
            headerPanel1.Location = new System.Drawing.Point(-2, -1);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1089, 32);
            headerPanel1.TabIndex = 128;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(12, 212);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1062, 580);
            universalGrid1.TabIndex = 129;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { stokKartınıGörüntüleToolStripMenuItem, stokKartınıSilToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(229, 48);
            // 
            // stokKartınıGörüntüleToolStripMenuItem
            // 
            stokKartınıGörüntüleToolStripMenuItem.Name = "stokKartınıGörüntüleToolStripMenuItem";
            stokKartınıGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            stokKartınıGörüntüleToolStripMenuItem.Text = "Stok Kartı Görüntüle & Düzenle";
            stokKartınıGörüntüleToolStripMenuItem.Click += stokKartınıGörüntüleToolStripMenuItem_Click;
            // 
            // stokKartınıSilToolStripMenuItem
            // 
            stokKartınıSilToolStripMenuItem.Name = "stokKartınıSilToolStripMenuItem";
            stokKartınıSilToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            stokKartınıSilToolStripMenuItem.Text = "Seçili Stok Kartlarını Sil";
            // 
            // projeKodu
            // 
            fcbProjeKodu.BorderColor = System.Drawing.Color.Silver;
            fcbProjeKodu.BorderSize = 1;
            fcbProjeKodu.DisplayMember = "kod";
            fcbProjeKodu.Location = new System.Drawing.Point(143, 60);
            fcbProjeKodu.Name = "projeKodu";
            fcbProjeKodu.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbProjeKodu.PlaceholderText = "Seçiniz...";
            fcbProjeKodu.Size = new System.Drawing.Size(176, 29);
            fcbProjeKodu.TabIndex = 130;
            fcbProjeKodu.ValueMember = "Id";
            // 
            // clbStokGrup
            // 
            fcbStokGrup.BorderColor = System.Drawing.Color.Silver;
            fcbStokGrup.BorderSize = 1;
            fcbStokGrup.DisplayMember = "ad";
            fcbStokGrup.Location = new System.Drawing.Point(143, 130);
            fcbStokGrup.Name = "clbStokGrup";
            fcbStokGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbStokGrup.PlaceholderText = "Seçiniz...";
            fcbStokGrup.Size = new System.Drawing.Size(176, 29);
            fcbStokGrup.TabIndex = 131;
            fcbStokGrup.ValueMember = "Id";
            fcbStokGrup.SelectedIndexChanged += cbxStokGrup_SelectedIndexChanged;
            // 
            // clbMalzemeGrup
            // 
            fcbMalzemeGrup.BorderColor = System.Drawing.Color.Silver;
            fcbMalzemeGrup.BorderSize = 1;
            fcbMalzemeGrup.DisplayMember = "ad";
            fcbMalzemeGrup.Location = new System.Drawing.Point(486, 60);
            fcbMalzemeGrup.Name = "clbMalzemeGrup";
            fcbMalzemeGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMalzemeGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeGrup.Size = new System.Drawing.Size(176, 29);
            fcbMalzemeGrup.TabIndex = 132;
            fcbMalzemeGrup.ValueMember = "Id";
            fcbMalzemeGrup.SelectedIndexChanged += malzemeGrubu_SelectedIndexChanged;
            // 
            // cbxMalzemeAltGrup
            // 
            fcbMalzemeAltGrup.BorderColor = System.Drawing.Color.Silver;
            fcbMalzemeAltGrup.BorderSize = 1;
            fcbMalzemeAltGrup.DisplayMember = "ad";
            fcbMalzemeAltGrup.Location = new System.Drawing.Point(486, 95);
            fcbMalzemeAltGrup.Name = "cbxMalzemeAltGrup";
            fcbMalzemeAltGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMalzemeAltGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeAltGrup.Size = new System.Drawing.Size(176, 29);
            fcbMalzemeAltGrup.TabIndex = 133;
            fcbMalzemeAltGrup.ValueMember = "Id";
            fcbMalzemeAltGrup.SelectedIndexChanged += cbxMalzemeAltGrup_SelectedIndexChanged;
            // 
            // clbMalzemeAltGrup2
            // 
            fcbMalzemeAltGrup2.BorderColor = System.Drawing.Color.Silver;
            fcbMalzemeAltGrup2.BorderSize = 1;
            fcbMalzemeAltGrup2.DisplayMember = "ad";
            fcbMalzemeAltGrup2.Location = new System.Drawing.Point(486, 130);
            fcbMalzemeAltGrup2.Name = "clbMalzemeAltGrup2";
            fcbMalzemeAltGrup2.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMalzemeAltGrup2.PlaceholderText = "Seçiniz...";
            fcbMalzemeAltGrup2.Size = new System.Drawing.Size(176, 29);
            fcbMalzemeAltGrup2.TabIndex = 134;
            fcbMalzemeAltGrup2.ValueMember = "Id";
            fcbMalzemeAltGrup2.MouseDoubleClick += cbxMalzemeAltGrup2_DoubleClick;
            // 
            // cbxStokTip
            // 
            fcbStokTip.BorderColor = System.Drawing.Color.Silver;
            fcbStokTip.BorderSize = 1;
            fcbStokTip.DisplayMember = "ad";
            fcbStokTip.Location = new System.Drawing.Point(143, 95);
            fcbStokTip.Name = "cbxStokTip";
            fcbStokTip.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbStokTip.PlaceholderText = "Seçiniz...";
            fcbStokTip.Size = new System.Drawing.Size(176, 29);
            fcbStokTip.TabIndex = 135;
            fcbStokTip.ValueMember = "Id";
            fcbStokTip.SelectedIndexChanged += cbxStokTip_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(24, 100);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(52, 15);
            label7.TabIndex = 136;
            label7.Text = "Stok Tipi";
            // 
            // StokKartGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1086, 804);
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
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "StokKartGridForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "SatinalmaTalepGridForm";
            FormClosing += StokKartGridForm_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private CustomControls.CustomTextBox ctbParcaAdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSatisSiparisTeklifTalepEkle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CustomControls.HeaderPanel headerPanel1;
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