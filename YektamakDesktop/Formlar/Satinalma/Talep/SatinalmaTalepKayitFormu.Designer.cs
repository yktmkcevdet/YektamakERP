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
            görüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            stokKartıGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            seçilenKayıtlarıBirleştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clbProjeKodu = new FilterableComboBox();
            clbKullaniciId = new FilterableComboBox();
            fcbTalepNeden = new FilterableComboBox();
            label3 = new System.Windows.Forms.Label();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ctbTeslimTarihi
            // 
            ctbTeslimTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbTeslimTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTeslimTarihi.Location = new System.Drawing.Point(154, 119);
            ctbTeslimTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbTeslimTarihi.Name = "ctbTeslimTarihi";
            ctbTeslimTarihi.Padding = new System.Windows.Forms.Padding(3);
            ctbTeslimTarihi.Size = new System.Drawing.Size(124, 25);
            ctbTeslimTarihi.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(37, 124);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 15);
            label1.TabIndex = 15;
            label1.Text = "İhtiyaç Tarihi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(37, 151);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 15);
            label2.TabIndex = 16;
            label2.Text = "Proje Kodu";
            // 
            // ctbAciklama
            // 
            ctbAciklama.BackColor = System.Drawing.Color.White;
            ctbAciklama.BorderColor = System.Drawing.Color.Silver;
            ctbAciklama.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbAciklama.BorderSize = 1;
            ctbAciklama.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbAciklama.ForeColor = System.Drawing.Color.Black;
            ctbAciklama.Location = new System.Drawing.Point(415, 38);
            ctbAciklama.Margin = new System.Windows.Forms.Padding(1);
            ctbAciklama.Multiline = true;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new System.Windows.Forms.Padding(3);
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
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(353, 38);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 15);
            label4.TabIndex = 19;
            label4.Text = "Açıklama";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(37, 178);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(115, 15);
            label5.TabIndex = 24;
            label5.Text = "Talep Eden Kullanıcı";
            // 
            // ctbTalepNo
            // 
            ctbTalepNo.BackColor = System.Drawing.Color.White;
            ctbTalepNo.BorderColor = System.Drawing.Color.Silver;
            ctbTalepNo.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbTalepNo.BorderSize = 1;
            ctbTalepNo.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTalepNo.ForeColor = System.Drawing.Color.Black;
            ctbTalepNo.Location = new System.Drawing.Point(154, 38);
            ctbTalepNo.Margin = new System.Windows.Forms.Padding(1);
            ctbTalepNo.Multiline = false;
            ctbTalepNo.Name = "ctbTalepNo";
            ctbTalepNo.Padding = new System.Windows.Forms.Padding(3);
            ctbTalepNo.PasswordChar = false;
            ctbTalepNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbTalepNo.PlaceholderText = "";
            ctbTalepNo.ReadOnly = false;
            ctbTalepNo.SelectionStart = 0;
            ctbTalepNo.Size = new System.Drawing.Size(119, 25);
            ctbTalepNo.TabIndex = 26;
            ctbTalepNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbTalepNo.TextCustom = "";
            ctbTalepNo.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(37, 43);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(55, 15);
            label6.TabIndex = 27;
            label6.Text = "Talep No";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(37, 70);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(69, 15);
            label7.TabIndex = 29;
            label7.Text = "Talep Tarihi";
            // 
            // ctbTalepTarihi
            // 
            ctbTalepTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbTalepTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTalepTarihi.Location = new System.Drawing.Point(154, 65);
            ctbTalepTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbTalepTarihi.Name = "ctbTalepTarihi";
            ctbTalepTarihi.Padding = new System.Windows.Forms.Padding(3);
            ctbTalepTarihi.Size = new System.Drawing.Size(107, 25);
            ctbTalepTarihi.TabIndex = 28;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(12, 231);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1262, 520);
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
            headerPanel1.Size = new System.Drawing.Size(1286, 25);
            headerPanel1.TabIndex = 31;
            // 
            // ctbSetAdet
            // 
            ctbSetAdet.BackColor = System.Drawing.Color.White;
            ctbSetAdet.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbSetAdet.ForeColor = System.Drawing.Color.Black;
            ctbSetAdet.Location = new System.Drawing.Point(154, 199);
            ctbSetAdet.Margin = new System.Windows.Forms.Padding(0);
            ctbSetAdet.Name = "ctbSetAdet";
            ctbSetAdet.OndalikBasamak = 0;
            ctbSetAdet.Padding = new System.Windows.Forms.Padding(3);
            ctbSetAdet.Size = new System.Drawing.Size(101, 25);
            ctbSetAdet.TabIndex = 32;
            ctbSetAdet.TextCustom = "1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label8.Location = new System.Drawing.Point(37, 204);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(56, 15);
            label8.TabIndex = 33;
            label8.Text = "Set Adet";
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(1116, 766);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 34;
            customButtonSave1.SaveButtonClick += roundedButton4_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { görüntüleToolStripMenuItem, stokKartıGörüntüleToolStripMenuItem, seçilenKayıtlarıBirleştirToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(199, 70);
            // 
            // görüntüleToolStripMenuItem
            // 
            görüntüleToolStripMenuItem.Name = "görüntüleToolStripMenuItem";
            görüntüleToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            görüntüleToolStripMenuItem.Text = "Parça Listesi Görüntüle";
            görüntüleToolStripMenuItem.Click += görüntüleToolStripMenuItem_Click;
            // 
            // stokKartıGörüntüleToolStripMenuItem
            // 
            stokKartıGörüntüleToolStripMenuItem.Name = "stokKartıGörüntüleToolStripMenuItem";
            stokKartıGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            stokKartıGörüntüleToolStripMenuItem.Text = "Stok Kartı Görüntüle";
            stokKartıGörüntüleToolStripMenuItem.Click += stokKartıGörüntüleToolStripMenuItem_Click;
            // 
            // seçilenKayıtlarıBirleştirToolStripMenuItem
            // 
            seçilenKayıtlarıBirleştirToolStripMenuItem.Name = "seçilenKayıtlarıBirleştirToolStripMenuItem";
            seçilenKayıtlarıBirleştirToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            seçilenKayıtlarıBirleştirToolStripMenuItem.Text = "Seçilen Kayıtları Birleştir";
            seçilenKayıtlarıBirleştirToolStripMenuItem.Click += seçilenKayıtlarıBirleştirToolStripMenuItem_Click;
            // 
            // clbProjeKodu
            // 
            clbProjeKodu.BorderColor = System.Drawing.Color.Silver;
            clbProjeKodu.BorderRadius = 8;
            clbProjeKodu.BorderSize = 1;
            clbProjeKodu.DisplayMember = "kod";
            clbProjeKodu.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbProjeKodu.Location = new System.Drawing.Point(154, 146);
            clbProjeKodu.Margin = new System.Windows.Forms.Padding(1);
            clbProjeKodu.Name = "clbProjeKodu";
            clbProjeKodu.Padding = new System.Windows.Forms.Padding(3);
            clbProjeKodu.PlaceholderText = "Seçiniz...";
            clbProjeKodu.ReadOnly = false;
            clbProjeKodu.Size = new System.Drawing.Size(119, 25);
            clbProjeKodu.TabIndex = 35;
            clbProjeKodu.ValueMember = "Id";
            clbProjeKodu.SelectedIndexChanged += clbProjeKodu_SelectedIndexChanged;
            // 
            // clbKullaniciId
            // 
            clbKullaniciId.BorderColor = System.Drawing.Color.Silver;
            clbKullaniciId.BorderRadius = 8;
            clbKullaniciId.BorderSize = 1;
            clbKullaniciId.DisplayMember = "ad";
            clbKullaniciId.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbKullaniciId.Location = new System.Drawing.Point(154, 173);
            clbKullaniciId.Margin = new System.Windows.Forms.Padding(1);
            clbKullaniciId.Name = "clbKullaniciId";
            clbKullaniciId.Padding = new System.Windows.Forms.Padding(3);
            clbKullaniciId.PlaceholderText = "Seçiniz...";
            clbKullaniciId.ReadOnly = false;
            clbKullaniciId.Size = new System.Drawing.Size(119, 25);
            clbKullaniciId.TabIndex = 36;
            clbKullaniciId.ValueMember = "Id";
            // 
            // fcbTalepNeden
            // 
            fcbTalepNeden.BorderColor = System.Drawing.Color.Silver;
            fcbTalepNeden.BorderRadius = 8;
            fcbTalepNeden.BorderSize = 1;
            fcbTalepNeden.DisplayMember = "ad";
            fcbTalepNeden.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbTalepNeden.Location = new System.Drawing.Point(154, 92);
            fcbTalepNeden.Margin = new System.Windows.Forms.Padding(1);
            fcbTalepNeden.Name = "fcbTalepNeden";
            fcbTalepNeden.Padding = new System.Windows.Forms.Padding(3);
            fcbTalepNeden.PlaceholderText = "Seçiniz...";
            fcbTalepNeden.ReadOnly = false;
            fcbTalepNeden.Size = new System.Drawing.Size(201, 25);
            fcbTalepNeden.TabIndex = 37;
            fcbTalepNeden.ValueMember = "Id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(37, 97);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 15);
            label3.TabIndex = 38;
            label3.Text = "Talep Nedeni";
            // 
            // SatinalmaTalepKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(1286, 838);
            Controls.Add(label3);
            Controls.Add(fcbTalepNeden);
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
        private System.Windows.Forms.ToolStripMenuItem görüntüleToolStripMenuItem;
        private FilterableComboBox clbProjeKodu;
        private FilterableComboBox filterableComboBox2;
        private FilterableComboBox fcbTalepNeden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem stokKartıGörüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seçilenKayıtlarıBirleştirToolStripMenuItem;
    }
}