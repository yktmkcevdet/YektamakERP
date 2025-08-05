using System;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTalepKayitFormu
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
            ctbTeslimTarihi = new CustomTextBoxTarih();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ctbAciklama = new CustomTextBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ctbTalepNo = new CustomTextBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ctbTalepTarihi = new CustomTextBoxTarih();
            universalGrid1 = new UniversalGrid();
            headerPanel1 = new HeaderPanel();
            ctbSetAdet = new CustomTextBoxSayisal();
            label8 = new System.Windows.Forms.Label();
            customButtonSave1 = new CustomButtonSave();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            yeniKayıtEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            görüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clbProjeKodu = new FilterableComboBox();
            clbKullaniciId = new FilterableComboBox();
            clbMalzemeGrubu = new FilterableComboBox();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ctbTeslimTarihi
            // 
            ctbTeslimTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbTeslimTarihi.Location = new System.Drawing.Point(150, 107);
            ctbTeslimTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbTeslimTarihi.Name = "ctbTeslimTarihi";
            ctbTeslimTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbTeslimTarihi.Size = new System.Drawing.Size(145, 32);
            ctbTeslimTarihi.TabIndex = 13;
            ctbTeslimTarihi.TextCustom = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(35, 114);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(71, 15);
            label1.TabIndex = 15;
            label1.Text = "Teslim Tarihi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(35, 149);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 16;
            label2.Text = "Proje Kodu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(35, 184);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(91, 15);
            label3.TabIndex = 17;
            label3.Text = "Malzeme Grubu";
            // 
            // ctbAciklama
            // 
            ctbAciklama.BackColor = System.Drawing.Color.White;
            ctbAciklama.BorderColor = System.Drawing.Color.Silver;
            ctbAciklama.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbAciklama.BorderRadius = 5;
            ctbAciklama.BorderSize = 1;
            ctbAciklama.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbAciklama.ForeColor = System.Drawing.Color.Black;
            ctbAciklama.isPlaceHolder = false;
            ctbAciklama.Location = new System.Drawing.Point(583, 162);
            ctbAciklama.Multiline = true;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbAciklama.PasswordChar = false;
            ctbAciklama.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAciklama.PlaceholderText = "";
            ctbAciklama.ReadOnly = false;
            ctbAciklama.SelectionStart = 0;
            ctbAciklama.Size = new System.Drawing.Size(402, 80);
            ctbAciklama.TabIndex = 18;
            ctbAciklama.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbAciklama.TextCustom = "";
            ctbAciklama.UnderlinedStyle = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(521, 162);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(56, 15);
            label4.TabIndex = 19;
            label4.Text = "Açıklama";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(35, 219);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(111, 15);
            label5.TabIndex = 24;
            label5.Text = "Talep Eden Kullanıcı";
            // 
            // ctbTalepNo
            // 
            ctbTalepNo.BackColor = System.Drawing.Color.White;
            ctbTalepNo.BorderColor = System.Drawing.Color.Silver;
            ctbTalepNo.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbTalepNo.BorderRadius = 5;
            ctbTalepNo.BorderSize = 1;
            ctbTalepNo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbTalepNo.ForeColor = System.Drawing.Color.Black;
            ctbTalepNo.isPlaceHolder = false;
            ctbTalepNo.Location = new System.Drawing.Point(150, 38);
            ctbTalepNo.Multiline = false;
            ctbTalepNo.Name = "ctbTalepNo";
            ctbTalepNo.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbTalepNo.PasswordChar = false;
            ctbTalepNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbTalepNo.PlaceholderText = "";
            ctbTalepNo.ReadOnly = false;
            ctbTalepNo.SelectionStart = 0;
            ctbTalepNo.Size = new System.Drawing.Size(166, 28);
            ctbTalepNo.TabIndex = 26;
            ctbTalepNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbTalepNo.TextCustom = "";
            ctbTalepNo.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(35, 43);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(53, 15);
            label6.TabIndex = 27;
            label6.Text = "Talep No";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(35, 77);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(65, 15);
            label7.TabIndex = 29;
            label7.Text = "Talep Tarihi";
            // 
            // ctbTalepTarihi
            // 
            ctbTalepTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbTalepTarihi.Location = new System.Drawing.Point(150, 70);
            ctbTalepTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbTalepTarihi.Name = "ctbTalepTarihi";
            ctbTalepTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbTalepTarihi.Size = new System.Drawing.Size(145, 32);
            ctbTalepTarihi.TabIndex = 28;
            ctbTalepTarihi.TextCustom = null;
            // 
            // universalGrid1
            // 
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.kullanici = null;
            universalGrid1.Location = new System.Drawing.Point(12, 264);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1262, 487);
            universalGrid1.TabIndex = 30;
            universalGrid1.MouseDown1 += universalGrid1_MouseClick;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Satınalma Talep Oluşturma";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1286, 32);
            headerPanel1.TabIndex = 31;
            // 
            // ctbSetAdet
            // 
            ctbSetAdet.BackColor = System.Drawing.Color.White;
            ctbSetAdet.BorderColor = System.Drawing.Color.Silver;
            ctbSetAdet.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbSetAdet.BorderRadius = 5;
            ctbSetAdet.BorderSize = 1;
            ctbSetAdet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbSetAdet.ForeColor = System.Drawing.Color.Black;
            ctbSetAdet.Location = new System.Drawing.Point(385, 210);
            ctbSetAdet.Margin = new System.Windows.Forms.Padding(0);
            ctbSetAdet.Multiline = false;
            ctbSetAdet.Name = "ctbSetAdet";
            ctbSetAdet.OndalikBasamak = 0;
            ctbSetAdet.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            ctbSetAdet.PasswordChar = false;
            ctbSetAdet.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbSetAdet.PlaceholderText = "";
            ctbSetAdet.ReadOnly = false;
            ctbSetAdet.SelectionStart = 0;
            ctbSetAdet.Size = new System.Drawing.Size(101, 32);
            ctbSetAdet.TabIndex = 32;
            ctbSetAdet.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            ctbSetAdet.TextCustom = "0";
            ctbSetAdet.UnderlinedStyle = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(385, 193);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(51, 15);
            label8.TabIndex = 33;
            label8.Text = "Set Adet";
            // 
            // customButtonSave1
            // 
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(1116, 766);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 34;
            customButtonSave1.SaveButtonClick += roundedButton4_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { yeniKayıtEkleToolStripMenuItem, görüntüleToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(150, 48);
            // 
            // yeniKayıtEkleToolStripMenuItem
            // 
            yeniKayıtEkleToolStripMenuItem.Name = "yeniKayıtEkleToolStripMenuItem";
            yeniKayıtEkleToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            yeniKayıtEkleToolStripMenuItem.Text = "Yeni Kayıt Ekle";
            yeniKayıtEkleToolStripMenuItem.Click += yeniKayıtEkleToolStripMenuItem_Click;
            // 
            // görüntüleToolStripMenuItem
            // 
            görüntüleToolStripMenuItem.Name = "görüntüleToolStripMenuItem";
            görüntüleToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            görüntüleToolStripMenuItem.Text = "Görüntüle";
            görüntüleToolStripMenuItem.Click += görüntüleToolStripMenuItem_Click;
            // 
            // clbProjeKodu
            // 
            clbProjeKodu.BorderColor = System.Drawing.Color.Silver;
            clbProjeKodu.BorderSize = 1;
            clbProjeKodu.DataSource = null;
            clbProjeKodu.DisplayMember = "kod";
            clbProjeKodu.Location = new System.Drawing.Point(150, 143);
            clbProjeKodu.Name = "clbProjeKodu";
            clbProjeKodu.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbProjeKodu.PlaceholderText = "Seçiniz...";
            clbProjeKodu.SelectedIndex = -1;
            clbProjeKodu.SelectedItem = null;
            clbProjeKodu.SelectedValue = null;
            clbProjeKodu.Size = new System.Drawing.Size(119, 29);
            clbProjeKodu.TabIndex = 35;
            clbProjeKodu.UnderlinedStyle = false;
            clbProjeKodu.ValueMember = "Id";
            // 
            // clbKullaniciId
            // 
            clbKullaniciId.BorderColor = System.Drawing.Color.Silver;
            clbKullaniciId.BorderSize = 1;
            clbKullaniciId.DataSource = null;
            clbKullaniciId.DisplayMember = "ad";
            clbKullaniciId.Location = new System.Drawing.Point(150, 213);
            clbKullaniciId.Name = "clbKullaniciId";
            clbKullaniciId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbKullaniciId.PlaceholderText = "Seçiniz...";
            clbKullaniciId.SelectedIndex = -1;
            clbKullaniciId.SelectedItem = null;
            clbKullaniciId.SelectedValue = null;
            clbKullaniciId.Size = new System.Drawing.Size(119, 29);
            clbKullaniciId.TabIndex = 36;
            clbKullaniciId.UnderlinedStyle = false;
            clbKullaniciId.ValueMember = "Id";
            // 
            // clbMalzemeGrubu
            // 
            clbMalzemeGrubu.BorderColor = System.Drawing.Color.Silver;
            clbMalzemeGrubu.BorderSize = 1;
            clbMalzemeGrubu.DataSource = null;
            clbMalzemeGrubu.DisplayMember = "ad";
            clbMalzemeGrubu.Location = new System.Drawing.Point(150, 178);
            clbMalzemeGrubu.Name = "clbMalzemeGrubu";
            clbMalzemeGrubu.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            clbMalzemeGrubu.PlaceholderText = "Seçiniz...";
            clbMalzemeGrubu.SelectedIndex = -1;
            clbMalzemeGrubu.SelectedItem = null;
            clbMalzemeGrubu.SelectedValue = null;
            clbMalzemeGrubu.Size = new System.Drawing.Size(119, 29);
            clbMalzemeGrubu.TabIndex = 37;
            clbMalzemeGrubu.UnderlinedStyle = false;
            clbMalzemeGrubu.ValueMember = "Id";
            clbMalzemeGrubu.SelectedIndexChanged += clbMalzemeGrubu_SelectedIndexChanged;
            // 
            // SatinalmaTalepKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(1286, 838);
            Controls.Add(clbMalzemeGrubu);
            Controls.Add(clbKullaniciId);
            Controls.Add(clbProjeKodu);
            Controls.Add(customButtonSave1);
            Controls.Add(label8);
            Controls.Add(ctbSetAdet);
            Controls.Add(headerPanel1);
            Controls.Add(universalGrid1);
            Controls.Add(label7);
            Controls.Add(ctbTalepTarihi);
            Controls.Add(label6);
            Controls.Add(ctbTalepNo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(ctbAciklama);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ctbTeslimTarihi);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepKayitFormu";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "SatinalmaTalepOlusturma";
            Load += SatinalmaTalepKayitFormu_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CustomControls.CustomTextBoxTarih ctbTeslimTarihi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomControls.CustomTextBox ctbAciklama;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CustomControls.FilterableComboBox clbKullaniciId;
        private CustomControls.CustomTextBox ctbTalepNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CustomControls.CustomTextBoxTarih ctbTalepTarihi;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBoxSayisal ctbSetAdet;
        private System.Windows.Forms.Label label8;
        private CustomControls.CustomButtonSave customButtonSave1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniKayıtEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem görüntüleToolStripMenuItem;
        private FilterableComboBox clbProjeKodu;
        private FilterableComboBox filterableComboBox2;
        private FilterableComboBox clbMalzemeGrubu;
    }
}