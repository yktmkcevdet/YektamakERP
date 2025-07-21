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
            textBoxParcaAdi = new CustomTextBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cbxMalzemeAltGrup = new CustomComboListBox();
            label1 = new System.Windows.Forms.Label();
            cbxMalzemeGrup = new CustomComboListBox();
            label2 = new System.Windows.Forms.Label();
            projeKodu = new CustomComboListBox();
            buttonSatisSiparisTeklifTalepEkle = new System.Windows.Forms.Button();
            lblToplamKayitSayisi = new System.Windows.Forms.Label();
            lblSecilmisKayitSayisi = new System.Windows.Forms.Label();
            lblKayitSayisi = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            cbxMalzemeAltGrup2 = new CustomComboListBox();
            label6 = new System.Windows.Forms.Label();
            cbxStokGrup = new CustomComboListBox();
            cbxStokTip = new CustomComboListBox();
            headerPanel1 = new HeaderPanel();
            universalGrid1 = new UniversalGrid();
            SuspendLayout();
            // 
            // textBoxParcaAdi
            // 
            textBoxParcaAdi.BackColor = System.Drawing.Color.White;
            textBoxParcaAdi.BorderColor = System.Drawing.Color.Silver;
            textBoxParcaAdi.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxParcaAdi.BorderRadius = 5;
            textBoxParcaAdi.BorderSize = 1;
            textBoxParcaAdi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxParcaAdi.ForeColor = System.Drawing.Color.Black;
            textBoxParcaAdi.isPlaceHolder = false;
            textBoxParcaAdi.Location = new System.Drawing.Point(143, 238);
            textBoxParcaAdi.Multiline = false;
            textBoxParcaAdi.Name = "textBoxParcaAdi";
            textBoxParcaAdi.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            textBoxParcaAdi.PasswordChar = false;
            textBoxParcaAdi.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxParcaAdi.PlaceholderText = "";
            textBoxParcaAdi.ReadOnly = false;
            textBoxParcaAdi.SelectionStart = 0;
            textBoxParcaAdi.Size = new System.Drawing.Size(250, 28);
            textBoxParcaAdi.TabIndex = 116;
            textBoxParcaAdi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxParcaAdi.TextCustom = "";
            textBoxParcaAdi.UnderlinedStyle = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(24, 244);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 15);
            label4.TabIndex = 115;
            label4.Text = "Parça Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(24, 168);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(109, 15);
            label3.TabIndex = 114;
            label3.Text = "Malzeme Alt Grubu";
            // 
            // cbxMalzemeAltGrup
            // 
            cbxMalzemeAltGrup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxMalzemeAltGrup.ListBoxVisualSize = 5;
            cbxMalzemeAltGrup.Location = new System.Drawing.Point(143, 162);
            cbxMalzemeAltGrup.Margin = new System.Windows.Forms.Padding(1);
            cbxMalzemeAltGrup.Name = "cbxMalzemeAltGrup";
            cbxMalzemeAltGrup.Padding = new System.Windows.Forms.Padding(1);
            cbxMalzemeAltGrup.selectedDataRowId = null;
            cbxMalzemeAltGrup.Size = new System.Drawing.Size(251, 36);
            cbxMalzemeAltGrup.TabIndex = 113;
            cbxMalzemeAltGrup.SelectedIndexChanged += cbxMalzemeAltGrup_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(24, 136);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 15);
            label1.TabIndex = 112;
            label1.Text = "Malzeme Grubu";
            // 
            // cbxMalzemeGrup
            // 
            cbxMalzemeGrup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxMalzemeGrup.ListBoxVisualSize = 5;
            cbxMalzemeGrup.Location = new System.Drawing.Point(143, 130);
            cbxMalzemeGrup.Margin = new System.Windows.Forms.Padding(1);
            cbxMalzemeGrup.Name = "cbxMalzemeGrup";
            cbxMalzemeGrup.Padding = new System.Windows.Forms.Padding(1);
            cbxMalzemeGrup.selectedDataRowId = null;
            cbxMalzemeGrup.Size = new System.Drawing.Size(251, 36);
            cbxMalzemeGrup.TabIndex = 111;
            cbxMalzemeGrup.SelectedIndexChanged += malzemeGrubu_SelectedIndexChanged;
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
            // projeKodu
            // 
            projeKodu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            projeKodu.ListBoxVisualSize = 5;
            projeKodu.Location = new System.Drawing.Point(143, 60);
            projeKodu.Margin = new System.Windows.Forms.Padding(1);
            projeKodu.Name = "projeKodu";
            projeKodu.Padding = new System.Windows.Forms.Padding(1);
            projeKodu.selectedDataRowId = null;
            projeKodu.Size = new System.Drawing.Size(251, 36);
            projeKodu.TabIndex = 109;
            projeKodu.SelectedIndexChanged += projeKodu_SelectedIndexChanged;
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
            buttonSatisSiparisTeklifTalepEkle.Location = new System.Drawing.Point(461, 233);
            buttonSatisSiparisTeklifTalepEkle.Name = "buttonSatisSiparisTeklifTalepEkle";
            buttonSatisSiparisTeklifTalepEkle.Size = new System.Drawing.Size(42, 35);
            buttonSatisSiparisTeklifTalepEkle.TabIndex = 118;
            buttonSatisSiparisTeklifTalepEkle.UseVisualStyleBackColor = false;
            buttonSatisSiparisTeklifTalepEkle.Click += buttonEkle_Click;
            // 
            // lblToplamKayitSayisi
            // 
            lblToplamKayitSayisi.AutoSize = true;
            lblToplamKayitSayisi.Location = new System.Drawing.Point(891, 60);
            lblToplamKayitSayisi.Name = "lblToplamKayitSayisi";
            lblToplamKayitSayisi.Size = new System.Drawing.Size(13, 15);
            lblToplamKayitSayisi.TabIndex = 121;
            lblToplamKayitSayisi.Text = "0";
            // 
            // lblSecilmisKayitSayisi
            // 
            lblSecilmisKayitSayisi.AutoSize = true;
            lblSecilmisKayitSayisi.Location = new System.Drawing.Point(891, 102);
            lblSecilmisKayitSayisi.Name = "lblSecilmisKayitSayisi";
            lblSecilmisKayitSayisi.Size = new System.Drawing.Size(13, 15);
            lblSecilmisKayitSayisi.TabIndex = 120;
            lblSecilmisKayitSayisi.Text = "0";
            // 
            // lblKayitSayisi
            // 
            lblKayitSayisi.AutoSize = true;
            lblKayitSayisi.Location = new System.Drawing.Point(891, 81);
            lblKayitSayisi.Name = "lblKayitSayisi";
            lblKayitSayisi.Size = new System.Drawing.Size(13, 15);
            lblKayitSayisi.TabIndex = 119;
            lblKayitSayisi.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(24, 208);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(118, 15);
            label5.TabIndex = 124;
            label5.Text = "Malzeme Alt Grubu 2";
            // 
            // cbxMalzemeAltGrup2
            // 
            cbxMalzemeAltGrup2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxMalzemeAltGrup2.ListBoxVisualSize = 5;
            cbxMalzemeAltGrup2.Location = new System.Drawing.Point(143, 201);
            cbxMalzemeAltGrup2.Margin = new System.Windows.Forms.Padding(1);
            cbxMalzemeAltGrup2.Name = "cbxMalzemeAltGrup2";
            cbxMalzemeAltGrup2.Padding = new System.Windows.Forms.Padding(1);
            cbxMalzemeAltGrup2.selectedDataRowId = null;
            cbxMalzemeAltGrup2.Size = new System.Drawing.Size(251, 36);
            cbxMalzemeAltGrup2.TabIndex = 123;
            cbxMalzemeAltGrup2.DoubleClick += cbxMalzemeAltGrup2_DoubleClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(24, 102);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(66, 15);
            label6.TabIndex = 126;
            label6.Text = "Stok Grubu";
            // 
            // cbxStokGrup
            // 
            cbxStokGrup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxStokGrup.ListBoxVisualSize = 5;
            cbxStokGrup.Location = new System.Drawing.Point(143, 96);
            cbxStokGrup.Margin = new System.Windows.Forms.Padding(1);
            cbxStokGrup.Name = "cbxStokGrup";
            cbxStokGrup.Padding = new System.Windows.Forms.Padding(1);
            cbxStokGrup.selectedDataRowId = null;
            cbxStokGrup.Size = new System.Drawing.Size(251, 36);
            cbxStokGrup.TabIndex = 125;
            cbxStokGrup.SelectedIndexChanged += cbxStokGrup_SelectedIndexChanged;
            // 
            // cbxStokTip
            // 
            cbxStokTip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxStokTip.ListBoxVisualSize = 5;
            cbxStokTip.Location = new System.Drawing.Point(514, 96);
            cbxStokTip.Margin = new System.Windows.Forms.Padding(1);
            cbxStokTip.Name = "cbxStokTip";
            cbxStokTip.Padding = new System.Windows.Forms.Padding(1);
            cbxStokTip.selectedDataRowId = null;
            cbxStokTip.Size = new System.Drawing.Size(249, 36);
            cbxStokTip.TabIndex = 127;
            cbxStokTip.SelectedIndexChanged += cbxStokTip_SelectedIndexChanged;
            // 
            // headerPanel1
            // 
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
            universalGrid1.kullanici = null;
            universalGrid1.Location = new System.Drawing.Point(12, 289);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1062, 503);
            universalGrid1.TabIndex = 129;
            // 
            // StokKartGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1086, 804);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            Controls.Add(cbxStokTip);
            Controls.Add(label6);
            Controls.Add(cbxStokGrup);
            Controls.Add(label5);
            Controls.Add(cbxMalzemeAltGrup2);
            Controls.Add(lblToplamKayitSayisi);
            Controls.Add(lblSecilmisKayitSayisi);
            Controls.Add(lblKayitSayisi);
            Controls.Add(buttonSatisSiparisTeklifTalepEkle);
            Controls.Add(textBoxParcaAdi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbxMalzemeAltGrup);
            Controls.Add(label1);
            Controls.Add(cbxMalzemeGrup);
            Controls.Add(label2);
            Controls.Add(projeKodu);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "StokKartGridForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "SatinalmaTalepGridForm";
            FormClosing += StokKartGridForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private CustomControls.CustomTextBox textBoxParcaAdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private CustomControls.CustomComboListBox cbxMalzemeAltGrup;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomComboListBox cbxMalzemeGrup;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomComboListBox projeKodu;
        private System.Windows.Forms.Button buttonSatisSiparisTeklifTalepEkle;
        private System.Windows.Forms.Label lblToplamKayitSayisi;
        private System.Windows.Forms.Label lblSecilmisKayitSayisi;
        private System.Windows.Forms.Label lblKayitSayisi;
        private System.Windows.Forms.Label label5;
        private CustomControls.CustomComboListBox cbxMalzemeAltGrup2;
        private System.Windows.Forms.Label label6;
        private CustomControls.CustomComboListBox cbxStokGrup;
        private CustomControls.CustomComboListBox cbxStokTip;
        private CustomControls.HeaderPanel headerPanel1;
        private UniversalGrid universalGrid1;
    }
}