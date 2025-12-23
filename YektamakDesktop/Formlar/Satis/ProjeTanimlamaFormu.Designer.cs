using Models;
using YektamakDesktop.Abstracts;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satis
{
    partial class ProjeTanimlamaFormu
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
            ctbId = new CustomTextBox();
            fcbProjeTip = new FilterableComboBox();
            fcbMarka = new FilterableComboBox();
            fcbMarkaAltGrup = new FilterableComboBox();
            Id = new System.Windows.Forms.Label();
            ctbAd = new CustomTextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ctbAciklama = new CustomTextBox();
            fcbMarkaAltGrupKategori = new FilterableComboBox();
            fcbMirasProje = new FilterableComboBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            customButtonSave1 = new CustomButtonSave();
            universalGrid1 = new UniversalGrid();
            ctbProjeNo = new CustomTextBox();
            label8 = new System.Windows.Forms.Label();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            projeSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1 = new System.Windows.Forms.Panel();
            ctbVersiyon = new CustomTextBox();
            customButtonNewRecord1 = new CustomButtonNewRecord();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Proje Tanımları";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(859, 22);
            headerPanel1.TabIndex = 0;
            // 
            // ctbId
            // 
            ctbId.AutoSize = true;
            ctbId.BackColor = System.Drawing.Color.White;
            ctbId.BorderColor = System.Drawing.Color.Silver;
            ctbId.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbId.BorderSize = 1;
            ctbId.Enabled = false;
            ctbId.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbId.ForeColor = System.Drawing.Color.Black;
            ctbId.Location = new System.Drawing.Point(150, 37);
            ctbId.Margin = new System.Windows.Forms.Padding(1);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbId.PasswordChar = false;
            ctbId.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbId.PlaceholderText = "";
            ctbId.ReadOnly = false;
            ctbId.SelectionStart = 0;
            ctbId.Size = new System.Drawing.Size(75, 29);
            ctbId.TabIndex = 1;
            ctbId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbId.TextCustom = "";
            ctbId.UnderlinedStyle = false;
            // 
            // fcbProjeTip
            // 
            fcbProjeTip.AutoSize = true;
            fcbProjeTip.BorderColor = System.Drawing.Color.Silver;
            fcbProjeTip.BorderRadius = 8;
            fcbProjeTip.BorderSize = 1;
            fcbProjeTip.DisplayMember = "ad";
            fcbProjeTip.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbProjeTip.Location = new System.Drawing.Point(150, 99);
            fcbProjeTip.Margin = new System.Windows.Forms.Padding(1);
            fcbProjeTip.Name = "fcbProjeTip";
            fcbProjeTip.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbProjeTip.PlaceholderText = "Seçiniz...";
            fcbProjeTip.ReadOnly = false;
            fcbProjeTip.Size = new System.Drawing.Size(163, 25);
            fcbProjeTip.TabIndex = 2;
            fcbProjeTip.ValueMember = "Id";
            // 
            // fcbMarka
            // 
            fcbMarka.AutoSize = true;
            fcbMarka.BorderColor = System.Drawing.Color.Silver;
            fcbMarka.BorderRadius = 8;
            fcbMarka.BorderSize = 1;
            fcbMarka.DisplayMember = "ad";
            fcbMarka.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMarka.Location = new System.Drawing.Point(150, 126);
            fcbMarka.Margin = new System.Windows.Forms.Padding(1);
            fcbMarka.Name = "fcbMarka";
            fcbMarka.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMarka.PlaceholderText = "Seçiniz...";
            fcbMarka.ReadOnly = false;
            fcbMarka.Size = new System.Drawing.Size(163, 25);
            fcbMarka.TabIndex = 3;
            fcbMarka.ValueMember = "Id";
            // 
            // fcbMarkaAltGrup
            // 
            fcbMarkaAltGrup.AutoSize = true;
            fcbMarkaAltGrup.BorderColor = System.Drawing.Color.Silver;
            fcbMarkaAltGrup.BorderRadius = 8;
            fcbMarkaAltGrup.BorderSize = 1;
            fcbMarkaAltGrup.DisplayMember = "ad";
            fcbMarkaAltGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMarkaAltGrup.Location = new System.Drawing.Point(150, 180);
            fcbMarkaAltGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbMarkaAltGrup.Name = "fcbMarkaAltGrup";
            fcbMarkaAltGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMarkaAltGrup.PlaceholderText = "Seçiniz...";
            fcbMarkaAltGrup.ReadOnly = false;
            fcbMarkaAltGrup.Size = new System.Drawing.Size(163, 25);
            fcbMarkaAltGrup.TabIndex = 5;
            fcbMarkaAltGrup.ValueMember = "Id";
            // 
            // Id
            // 
            Id.AutoSize = true;
            Id.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            Id.Location = new System.Drawing.Point(45, 44);
            Id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Id.Name = "Id";
            Id.Size = new System.Drawing.Size(17, 13);
            Id.TabIndex = 5;
            Id.Text = "Id";
            // 
            // ctbAd
            // 
            ctbAd.AutoSize = true;
            ctbAd.BackColor = System.Drawing.Color.White;
            ctbAd.BorderColor = System.Drawing.Color.Silver;
            ctbAd.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbAd.BorderSize = 1;
            ctbAd.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbAd.ForeColor = System.Drawing.Color.Black;
            ctbAd.Location = new System.Drawing.Point(408, 34);
            ctbAd.Margin = new System.Windows.Forms.Padding(1);
            ctbAd.Multiline = false;
            ctbAd.Name = "ctbAd";
            ctbAd.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbAd.PasswordChar = false;
            ctbAd.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAd.PlaceholderText = "";
            ctbAd.ReadOnly = false;
            ctbAd.SelectionStart = 0;
            ctbAd.Size = new System.Drawing.Size(428, 29);
            ctbAd.TabIndex = 7;
            ctbAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbAd.TextCustom = "";
            ctbAd.UnderlinedStyle = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(45, 106);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 13);
            label1.TabIndex = 7;
            label1.Text = "Proje Tipi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(45, 133);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(40, 13);
            label2.TabIndex = 8;
            label2.Text = "Marka";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(45, 187);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(85, 13);
            label3.TabIndex = 9;
            label3.Text = "Marka alt Grup";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(347, 42);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(55, 13);
            label4.TabIndex = 10;
            label4.Text = "Proje Adı";
            // 
            // ctbAciklama
            // 
            ctbAciklama.AutoSize = true;
            ctbAciklama.BackColor = System.Drawing.Color.White;
            ctbAciklama.BorderColor = System.Drawing.Color.Silver;
            ctbAciklama.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbAciklama.BorderSize = 1;
            ctbAciklama.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbAciklama.ForeColor = System.Drawing.Color.Black;
            ctbAciklama.Location = new System.Drawing.Point(408, 68);
            ctbAciklama.Margin = new System.Windows.Forms.Padding(1);
            ctbAciklama.Multiline = false;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbAciklama.PasswordChar = false;
            ctbAciklama.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAciklama.PlaceholderText = "";
            ctbAciklama.ReadOnly = false;
            ctbAciklama.SelectionStart = 0;
            ctbAciklama.Size = new System.Drawing.Size(428, 29);
            ctbAciklama.TabIndex = 8;
            ctbAciklama.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbAciklama.TextCustom = "";
            ctbAciklama.UnderlinedStyle = false;
            // 
            // fcbMarkaAltGrupKategori
            // 
            fcbMarkaAltGrupKategori.AutoSize = true;
            fcbMarkaAltGrupKategori.BorderColor = System.Drawing.Color.Silver;
            fcbMarkaAltGrupKategori.BorderRadius = 8;
            fcbMarkaAltGrupKategori.BorderSize = 1;
            fcbMarkaAltGrupKategori.DisplayMember = "ad";
            fcbMarkaAltGrupKategori.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMarkaAltGrupKategori.Location = new System.Drawing.Point(150, 207);
            fcbMarkaAltGrupKategori.Margin = new System.Windows.Forms.Padding(1);
            fcbMarkaAltGrupKategori.Name = "fcbMarkaAltGrupKategori";
            fcbMarkaAltGrupKategori.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMarkaAltGrupKategori.PlaceholderText = "Seçiniz...";
            fcbMarkaAltGrupKategori.ReadOnly = false;
            fcbMarkaAltGrupKategori.Size = new System.Drawing.Size(119, 25);
            fcbMarkaAltGrupKategori.TabIndex = 6;
            fcbMarkaAltGrupKategori.ValueMember = "Id";
            // 
            // fcbMirasProje
            // 
            fcbMirasProje.AutoSize = true;
            fcbMirasProje.BorderColor = System.Drawing.Color.Silver;
            fcbMirasProje.BorderRadius = 8;
            fcbMirasProje.BorderSize = 1;
            fcbMirasProje.DisplayMember = "kod";
            fcbMirasProje.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMirasProje.Location = new System.Drawing.Point(150, 153);
            fcbMirasProje.Margin = new System.Windows.Forms.Padding(1);
            fcbMirasProje.Name = "fcbMirasProje";
            fcbMirasProje.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMirasProje.PlaceholderText = "Seçiniz...";
            fcbMirasProje.ReadOnly = false;
            fcbMirasProje.Size = new System.Drawing.Size(119, 25);
            fcbMirasProje.TabIndex = 4;
            fcbMirasProje.ValueMember = "Id";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(348, 73);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(54, 13);
            label5.TabIndex = 14;
            label5.Text = "Açıklama";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(45, 214);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(51, 13);
            label6.TabIndex = 15;
            label6.Text = "Kategori";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(45, 160);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(103, 13);
            label7.TabIndex = 16;
            label7.Text = "Miras Alınan Proje";
            // 
            // customButtonSave1
            // 
            customButtonSave1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.BorderColor = System.Drawing.Color.Black;
            customButtonSave1.BorderSize = 0;
            customButtonSave1.CornerRadius = 6;
            customButtonSave1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            customButtonSave1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            customButtonSave1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            customButtonSave1.HoverColor2 = System.Drawing.Color.Navy;
            customButtonSave1.Location = new System.Drawing.Point(757, 248);
            customButtonSave1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(36, 38);
            customButtonSave1.TabIndex = 17;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(37, 292);
            universalGrid1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(799, 326);
            universalGrid1.TabIndex = 18;
            // 
            // ctbProjeNo
            // 
            ctbProjeNo.AutoSize = true;
            ctbProjeNo.BackColor = System.Drawing.Color.White;
            ctbProjeNo.BorderColor = System.Drawing.Color.Silver;
            ctbProjeNo.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbProjeNo.BorderSize = 1;
            ctbProjeNo.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbProjeNo.ForeColor = System.Drawing.Color.Black;
            ctbProjeNo.Location = new System.Drawing.Point(150, 68);
            ctbProjeNo.Margin = new System.Windows.Forms.Padding(1);
            ctbProjeNo.Multiline = false;
            ctbProjeNo.Name = "ctbProjeNo";
            ctbProjeNo.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbProjeNo.PasswordChar = false;
            ctbProjeNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbProjeNo.PlaceholderText = "";
            ctbProjeNo.ReadOnly = false;
            ctbProjeNo.SelectionStart = 0;
            ctbProjeNo.Size = new System.Drawing.Size(112, 29);
            ctbProjeNo.TabIndex = 19;
            ctbProjeNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbProjeNo.TextCustom = "";
            ctbProjeNo.UnderlinedStyle = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label8.Location = new System.Drawing.Point(45, 75);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(82, 13);
            label8.TabIndex = 20;
            label8.Text = "Proje No / Ver.";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { projeSilToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(117, 26);
            // 
            // projeSilToolStripMenuItem
            // 
            projeSilToolStripMenuItem.Name = "projeSilToolStripMenuItem";
            projeSilToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            projeSilToolStripMenuItem.Text = "Proje Sil";
            projeSilToolStripMenuItem.Click += projeSilToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Location = new System.Drawing.Point(348, 120);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(488, 112);
            panel1.TabIndex = 22;
            // 
            // ctbVersiyon
            // 
            ctbVersiyon.AutoSize = true;
            ctbVersiyon.BackColor = System.Drawing.Color.White;
            ctbVersiyon.BorderColor = System.Drawing.Color.Silver;
            ctbVersiyon.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbVersiyon.BorderSize = 1;
            ctbVersiyon.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbVersiyon.ForeColor = System.Drawing.Color.Black;
            ctbVersiyon.Location = new System.Drawing.Point(264, 68);
            ctbVersiyon.Margin = new System.Windows.Forms.Padding(1);
            ctbVersiyon.Multiline = false;
            ctbVersiyon.Name = "ctbVersiyon";
            ctbVersiyon.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbVersiyon.PasswordChar = false;
            ctbVersiyon.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbVersiyon.PlaceholderText = "";
            ctbVersiyon.ReadOnly = false;
            ctbVersiyon.SelectionStart = 0;
            ctbVersiyon.Size = new System.Drawing.Size(49, 29);
            ctbVersiyon.TabIndex = 23;
            ctbVersiyon.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbVersiyon.TextCustom = "";
            ctbVersiyon.UnderlinedStyle = false;
            // 
            // customButtonNewRecord1
            // 
            customButtonNewRecord1.BorderColor = System.Drawing.Color.Black;
            customButtonNewRecord1.BorderSize = 0;
            customButtonNewRecord1.CornerRadius = 6;
            customButtonNewRecord1.ForeColor = System.Drawing.Color.White;
            customButtonNewRecord1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            customButtonNewRecord1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            customButtonNewRecord1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            customButtonNewRecord1.HoverColor2 = System.Drawing.Color.Navy;
            customButtonNewRecord1.Location = new System.Drawing.Point(45, 250);
            customButtonNewRecord1.Margin = new System.Windows.Forms.Padding(0);
            customButtonNewRecord1.Name = "customButtonNewRecord1";
            customButtonNewRecord1.Size = new System.Drawing.Size(36, 36);
            customButtonNewRecord1.TabIndex = 24;
            customButtonNewRecord1.Click += roundedButton1_Click;
            // 
            // ProjeTanimlamaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(859, 630);
            Controls.Add(customButtonNewRecord1);
            Controls.Add(ctbVersiyon);
            Controls.Add(panel1);
            Controls.Add(label8);
            Controls.Add(ctbProjeNo);
            Controls.Add(universalGrid1);
            Controls.Add(customButtonSave1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(fcbMirasProje);
            Controls.Add(fcbMarkaAltGrupKategori);
            Controls.Add(ctbAciklama);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ctbAd);
            Controls.Add(Id);
            Controls.Add(fcbMarkaAltGrup);
            Controls.Add(fcbMarka);
            Controls.Add(fcbProjeTip);
            Controls.Add(ctbId);
            Controls.Add(headerPanel1);
            Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ProjeTanimlamaFormu";
            Text = "ProjeTanimlamaFormu";
            FormClosing += ProjeTanimlamaFormu_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBox ctbId;
        private CustomControls.FilterableComboBox fcbProjeTip;
        private CustomControls.FilterableComboBox fcbMarka;
        private CustomControls.FilterableComboBox fcbMarkaAltGrup;
        private System.Windows.Forms.Label Id;
        private CustomControls.CustomTextBox ctbAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBox ctbAciklama;
        private CustomControls.FilterableComboBox fcbMarkaAltGrupKategori;
        private CustomControls.FilterableComboBox fcbMirasProje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.CustomTextBox ctbProjeNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projeSilToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private CustomTextBox ctbVersiyon;
        private CustomButtonNewRecord customButtonNewRecord1;
    }
}