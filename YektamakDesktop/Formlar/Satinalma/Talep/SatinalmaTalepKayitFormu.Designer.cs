using System;

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
            ctbTeslimTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ctbAciklama = new YektamakDesktop.CustomControls.CustomTextBox();
            label4 = new System.Windows.Forms.Label();
            roundedButton4 = new YektamakDesktop.CustomControls.RoundedButton();
            clbProjeKodu = new YektamakDesktop.CustomControls.CustomComboListBox();
            clbMalzemeGrubu = new YektamakDesktop.CustomControls.CustomComboListBox();
            label5 = new System.Windows.Forms.Label();
            clbKullaniciId = new YektamakDesktop.CustomControls.CustomComboListBox();
            ctbTalepNo = new YektamakDesktop.CustomControls.CustomTextBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ctbTalepTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            ctbSetAdet = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            label8 = new System.Windows.Forms.Label();
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
            label2.Location = new System.Drawing.Point(35, 156);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 16;
            label2.Text = "Proje Kodu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(35, 191);
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
            ctbAciklama.Location = new System.Drawing.Point(729, 165);
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
            label4.Location = new System.Drawing.Point(667, 170);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(56, 15);
            label4.TabIndex = 19;
            label4.Text = "Açıklama";
            // 
            // roundedButton4
            // 
            roundedButton4.BackColor = System.Drawing.Color.YellowGreen;
            roundedButton4.BackgroundColor = System.Drawing.Color.YellowGreen;
            roundedButton4.BorderColor = System.Drawing.Color.GreenYellow;
            roundedButton4.BorderSize = 5;
            roundedButton4.CornerRadius = 20;
            roundedButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            roundedButton4.FlatAppearance.BorderSize = 0;
            roundedButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton4.ForeColor = System.Drawing.Color.White;
            roundedButton4.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedButton4.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedButton4.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedButton4.HoverColor2 = System.Drawing.Color.Navy;
            roundedButton4.Icon = null;
            roundedButton4.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton4.Location = new System.Drawing.Point(1067, 767);
            roundedButton4.Name = "roundedButton4";
            roundedButton4.Size = new System.Drawing.Size(152, 59);
            roundedButton4.TabIndex = 20;
            roundedButton4.Text = "Satınalma Talebi Oluştur";
            roundedButton4.TextColor = System.Drawing.Color.White;
            roundedButton4.UseVisualStyleBackColor = false;
            roundedButton4.Click += roundedButton4_Click;
            // 
            // clbProjeKodu
            // 
            clbProjeKodu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbProjeKodu.ListBoxVisualSize = 5;
            clbProjeKodu.Location = new System.Drawing.Point(148, 149);
            clbProjeKodu.Margin = new System.Windows.Forms.Padding(1);
            clbProjeKodu.Name = "clbProjeKodu";
            clbProjeKodu.Padding = new System.Windows.Forms.Padding(1);
            clbProjeKodu.selectedDataRowId = null;
            clbProjeKodu.selectedDataRowValue = null;
            clbProjeKodu.Size = new System.Drawing.Size(168, 36);
            clbProjeKodu.TabIndex = 21;
            // 
            // clbMalzemeGrubu
            // 
            clbMalzemeGrubu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbMalzemeGrubu.ListBoxVisualSize = 5;
            clbMalzemeGrubu.Location = new System.Drawing.Point(150, 186);
            clbMalzemeGrubu.Margin = new System.Windows.Forms.Padding(1);
            clbMalzemeGrubu.Name = "clbMalzemeGrubu";
            clbMalzemeGrubu.Padding = new System.Windows.Forms.Padding(1);
            clbMalzemeGrubu.selectedDataRowId = null;
            clbMalzemeGrubu.selectedDataRowValue = null;
            clbMalzemeGrubu.Size = new System.Drawing.Size(168, 36);
            clbMalzemeGrubu.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(35, 233);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(111, 15);
            label5.TabIndex = 24;
            label5.Text = "Talep Eden Kullanıcı";
            // 
            // clbKullaniciId
            // 
            clbKullaniciId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbKullaniciId.ListBoxVisualSize = 5;
            clbKullaniciId.Location = new System.Drawing.Point(150, 224);
            clbKullaniciId.Margin = new System.Windows.Forms.Padding(1);
            clbKullaniciId.Name = "clbKullaniciId";
            clbKullaniciId.Padding = new System.Windows.Forms.Padding(1);
            clbKullaniciId.selectedDataRowId = null;
            clbKullaniciId.selectedDataRowValue = null;
            clbKullaniciId.Size = new System.Drawing.Size(250, 36);
            clbKullaniciId.TabIndex = 25;
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
            universalGrid1.kullanici = null;
            universalGrid1.Location = new System.Drawing.Point(12, 264);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1262, 487);
            universalGrid1.TabIndex = 30;
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
            ctbSetAdet.Location = new System.Drawing.Point(470, 224);
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
            label8.Location = new System.Drawing.Point(470, 207);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(51, 15);
            label8.TabIndex = 33;
            label8.Text = "Set Adet";
            // 
            // SatinalmaTalepKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(1286, 838);
            Controls.Add(label8);
            Controls.Add(ctbSetAdet);
            Controls.Add(headerPanel1);
            Controls.Add(universalGrid1);
            Controls.Add(label7);
            Controls.Add(ctbTalepTarihi);
            Controls.Add(label6);
            Controls.Add(ctbTalepNo);
            Controls.Add(clbKullaniciId);
            Controls.Add(label5);
            Controls.Add(clbMalzemeGrubu);
            Controls.Add(clbProjeKodu);
            Controls.Add(roundedButton4);
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
            FormClosing += SatinalmaTalepKayitFormu_FormClosing;
            Load += SatinalmaTalepKayitFormu_Load;
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
        private CustomControls.RoundedButton roundedButton4;
        private CustomControls.CustomComboListBox clbProjeKodu;
        private CustomControls.CustomComboListBox clbMalzemeGrubu;
        private System.Windows.Forms.Label label5;
        private CustomControls.CustomComboListBox clbKullaniciId;
        private CustomControls.CustomTextBox ctbTalepNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CustomControls.CustomTextBoxTarih ctbTalepTarihi;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBoxSayisal ctbSetAdet;
        private System.Windows.Forms.Label label8;
    }
}