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
            projeKodu = new FilterableComboBox();
            clbStokGrup = new FilterableComboBox();
            clbMalzemeGrup = new FilterableComboBox();
            cbxMalzemeAltGrup = new FilterableComboBox();
            clbMalzemeAltGrup2 = new FilterableComboBox();
            cbxStokTip = new FilterableComboBox();
            label7 = new System.Windows.Forms.Label();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
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
            ctbParcaAdi.Location = new System.Drawing.Point(143, 165);
            ctbParcaAdi.Multiline = false;
            ctbParcaAdi.Name = "ctbParcaAdi";
            ctbParcaAdi.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbParcaAdi.PasswordChar = false;
            ctbParcaAdi.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbParcaAdi.PlaceholderText = "";
            ctbParcaAdi.ReadOnly = false;
            ctbParcaAdi.SelectionStart = 0;
            ctbParcaAdi.Size = new System.Drawing.Size(176, 28);
            ctbParcaAdi.TabIndex = 116;
            ctbParcaAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbParcaAdi.TextCustom = "";
            ctbParcaAdi.UnderlinedStyle = false;
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
            buttonSatisSiparisTeklifTalepEkle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            stokKartınıSilToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            stokKartınıSilToolStripMenuItem.Text = "Seçili Stok Kartlarını Sil";
            // 
            // projeKodu
            // 
            projeKodu.BorderColor = System.Drawing.Color.Silver;
            projeKodu.BorderSize = 1;
            projeKodu.DataSource = null;
            projeKodu.DisplayMember = "kod";
            projeKodu.Location = new System.Drawing.Point(143, 60);
            projeKodu.Name = "projeKodu";
            projeKodu.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            projeKodu.PlaceholderText = "Seçiniz...";
            projeKodu.SelectedIndex = -1;
            projeKodu.SelectedItem = null;
            projeKodu.SelectedValue = null;
            projeKodu.Size = new System.Drawing.Size(176, 29);
            projeKodu.TabIndex = 130;
            projeKodu.UnderlinedStyle = false;
            projeKodu.ValueMember = "Id";
            // 
            // clbStokGrup
            // 
            clbStokGrup.BorderColor = System.Drawing.Color.Silver;
            clbStokGrup.BorderSize = 1;
            clbStokGrup.DataSource = null;
            clbStokGrup.DisplayMember = "ad";
            clbStokGrup.Location = new System.Drawing.Point(143, 130);
            clbStokGrup.Name = "clbStokGrup";
            clbStokGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbStokGrup.PlaceholderText = "Seçiniz...";
            clbStokGrup.SelectedIndex = -1;
            clbStokGrup.SelectedItem = null;
            clbStokGrup.SelectedValue = null;
            clbStokGrup.Size = new System.Drawing.Size(176, 29);
            clbStokGrup.TabIndex = 131;
            clbStokGrup.UnderlinedStyle = false;
            clbStokGrup.ValueMember = "Id";
            clbStokGrup.SelectedIndexChanged += cbxStokGrup_SelectedIndexChanged;
            // 
            // clbMalzemeGrup
            // 
            clbMalzemeGrup.BorderColor = System.Drawing.Color.Silver;
            clbMalzemeGrup.BorderSize = 1;
            clbMalzemeGrup.DataSource = null;
            clbMalzemeGrup.DisplayMember = "ad";
            clbMalzemeGrup.Location = new System.Drawing.Point(486, 60);
            clbMalzemeGrup.Name = "clbMalzemeGrup";
            clbMalzemeGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbMalzemeGrup.PlaceholderText = "Seçiniz...";
            clbMalzemeGrup.SelectedIndex = -1;
            clbMalzemeGrup.SelectedItem = null;
            clbMalzemeGrup.SelectedValue = null;
            clbMalzemeGrup.Size = new System.Drawing.Size(176, 29);
            clbMalzemeGrup.TabIndex = 132;
            clbMalzemeGrup.UnderlinedStyle = false;
            clbMalzemeGrup.ValueMember = "Id";
            clbMalzemeGrup.SelectedIndexChanged += malzemeGrubu_SelectedIndexChanged;
            // 
            // cbxMalzemeAltGrup
            // 
            cbxMalzemeAltGrup.BorderColor = System.Drawing.Color.Silver;
            cbxMalzemeAltGrup.BorderSize = 1;
            cbxMalzemeAltGrup.DataSource = null;
            cbxMalzemeAltGrup.DisplayMember = "ad";
            cbxMalzemeAltGrup.Location = new System.Drawing.Point(486, 95);
            cbxMalzemeAltGrup.Name = "cbxMalzemeAltGrup";
            cbxMalzemeAltGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            cbxMalzemeAltGrup.PlaceholderText = "Seçiniz...";
            cbxMalzemeAltGrup.SelectedIndex = -1;
            cbxMalzemeAltGrup.SelectedItem = null;
            cbxMalzemeAltGrup.SelectedValue = null;
            cbxMalzemeAltGrup.Size = new System.Drawing.Size(176, 29);
            cbxMalzemeAltGrup.TabIndex = 133;
            cbxMalzemeAltGrup.UnderlinedStyle = false;
            cbxMalzemeAltGrup.ValueMember = "Id";
            cbxMalzemeAltGrup.SelectedIndexChanged += cbxMalzemeAltGrup_SelectedIndexChanged;
            // 
            // clbMalzemeAltGrup2
            // 
            clbMalzemeAltGrup2.BorderColor = System.Drawing.Color.Silver;
            clbMalzemeAltGrup2.BorderSize = 1;
            clbMalzemeAltGrup2.DataSource = null;
            clbMalzemeAltGrup2.DisplayMember = "ad";
            clbMalzemeAltGrup2.Location = new System.Drawing.Point(486, 130);
            clbMalzemeAltGrup2.Name = "clbMalzemeAltGrup2";
            clbMalzemeAltGrup2.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbMalzemeAltGrup2.PlaceholderText = "Seçiniz...";
            clbMalzemeAltGrup2.SelectedIndex = -1;
            clbMalzemeAltGrup2.SelectedItem = null;
            clbMalzemeAltGrup2.SelectedValue = null;
            clbMalzemeAltGrup2.Size = new System.Drawing.Size(176, 29);
            clbMalzemeAltGrup2.TabIndex = 134;
            clbMalzemeAltGrup2.UnderlinedStyle = false;
            clbMalzemeAltGrup2.ValueMember = "Id";
            clbMalzemeAltGrup2.MouseDoubleClick += cbxMalzemeAltGrup2_DoubleClick;
            // 
            // cbxStokTip
            // 
            cbxStokTip.BorderColor = System.Drawing.Color.Silver;
            cbxStokTip.BorderSize = 1;
            cbxStokTip.DataSource = null;
            cbxStokTip.DisplayMember = "ad";
            cbxStokTip.Location = new System.Drawing.Point(143, 95);
            cbxStokTip.Name = "cbxStokTip";
            cbxStokTip.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            cbxStokTip.PlaceholderText = "Seçiniz...";
            cbxStokTip.SelectedIndex = -1;
            cbxStokTip.SelectedItem = null;
            cbxStokTip.SelectedValue = null;
            cbxStokTip.Size = new System.Drawing.Size(176, 29);
            cbxStokTip.TabIndex = 135;
            cbxStokTip.UnderlinedStyle = false;
            cbxStokTip.ValueMember = "Id";
            cbxStokTip.SelectedIndexChanged += cbxStokTip_SelectedIndexChanged;
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
            Controls.Add(cbxStokTip);
            Controls.Add(clbMalzemeAltGrup2);
            Controls.Add(cbxMalzemeAltGrup);
            Controls.Add(clbMalzemeGrup);
            Controls.Add(clbStokGrup);
            Controls.Add(projeKodu);
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
        private FilterableComboBox projeKodu;
        private FilterableComboBox clbStokGrup;
        private FilterableComboBox clbMalzemeGrup;
        private FilterableComboBox cbxMalzemeAltGrup;
        private FilterableComboBox clbMalzemeAltGrup2;
        private FilterableComboBox cbxStokTip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem stokKartınıSilToolStripMenuItem;
    }
}