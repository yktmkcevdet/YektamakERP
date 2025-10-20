using ApiService.Interfaces;
using Models;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTalepOlusturmaFormu
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
            headerPanel1 = new HeaderPanel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            ctbAciklama = new CustomTextBox();
            label6 = new Label();
            ctbTalepNo = new CustomTextBox();
            ctbTeslimTarihi = new CustomTextBoxTarih();
            label1 = new Label();
            label7 = new Label();
            fcbProjeKod = new FilterableComboBox();
            clbMalzemeGrup = new FilterableComboBox();
            clbStokTip = new FilterableComboBox();
            clbStokGrup = new FilterableComboBox();
            fcbTalepNeden = new FilterableComboBox();
            label8 = new Label();
            customButtonSave1 = new RoundedButton();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Talep Oluşturma";
            headerPanel1.Location = new System.Drawing.Point(-1, 0);
            headerPanel1.Margin = new Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1060, 25);
            headerPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(45, 126);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 15);
            label2.TabIndex = 4;
            label2.Text = "Proej Kodu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(45, 153);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(56, 15);
            label3.TabIndex = 6;
            label3.Text = "Stok Tipi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(45, 180);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(71, 15);
            label4.TabIndex = 9;
            label4.Text = "Stok Grubu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(45, 207);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(96, 15);
            label5.TabIndex = 10;
            label5.Text = "Malzeme Grubu";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new System.Drawing.Point(45, 230);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(991, 325);
            panel1.TabIndex = 15;
            // 
            // ctbAciklama
            // 
            ctbAciklama.BackColor = System.Drawing.Color.White;
            ctbAciklama.BorderColor = System.Drawing.Color.Silver;
            ctbAciklama.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbAciklama.BorderSize = 1;
            ctbAciklama.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbAciklama.ForeColor = System.Drawing.Color.Black;
            ctbAciklama.Location = new System.Drawing.Point(501, 100);
            ctbAciklama.Margin = new Padding(1);
            ctbAciklama.Multiline = true;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new Padding(7, 5, 7, 5);
            ctbAciklama.PasswordChar = false;
            ctbAciklama.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAciklama.PlaceholderText = "";
            ctbAciklama.ReadOnly = false;
            ctbAciklama.SelectionStart = 0;
            ctbAciklama.Size = new System.Drawing.Size(390, 100);
            ctbAciklama.TabIndex = 17;
            ctbAciklama.TextAlignment = HorizontalAlignment.Left;
            ctbAciklama.TextCustom = "";
            ctbAciklama.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(425, 115);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(56, 15);
            label6.TabIndex = 18;
            label6.Text = "Açıklama";
            // 
            // ctbTalepNo
            // 
            ctbTalepNo.BackColor = System.Drawing.Color.White;
            ctbTalepNo.BorderColor = System.Drawing.Color.Silver;
            ctbTalepNo.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbTalepNo.BorderSize = 1;
            ctbTalepNo.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTalepNo.ForeColor = System.Drawing.Color.Black;
            ctbTalepNo.Location = new System.Drawing.Point(160, 36);
            ctbTalepNo.Margin = new Padding(1);
            ctbTalepNo.Multiline = false;
            ctbTalepNo.Name = "ctbTalepNo";
            ctbTalepNo.Padding = new Padding(7, 5, 7, 5);
            ctbTalepNo.PasswordChar = false;
            ctbTalepNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbTalepNo.PlaceholderText = "";
            ctbTalepNo.ReadOnly = false;
            ctbTalepNo.SelectionStart = 0;
            ctbTalepNo.Size = new System.Drawing.Size(105, 29);
            ctbTalepNo.TabIndex = 19;
            ctbTalepNo.TextAlignment = HorizontalAlignment.Left;
            ctbTalepNo.TextCustom = "";
            ctbTalepNo.UnderlinedStyle = false;
            // 
            // ctbTeslimTarihi
            // 
            ctbTeslimTarihi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ctbTeslimTarihi.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTeslimTarihi.Location = new System.Drawing.Point(160, 94);
            ctbTeslimTarihi.Margin = new Padding(1);
            ctbTeslimTarihi.Name = "ctbTeslimTarihi";
            ctbTeslimTarihi.Padding = new Padding(1);
            ctbTeslimTarihi.Size = new System.Drawing.Size(145, 32);
            ctbTeslimTarihi.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(45, 42);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 15);
            label1.TabIndex = 21;
            label1.Text = "Talep No";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(45, 100);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(77, 15);
            label7.TabIndex = 22;
            label7.Text = "İhtiyaç Tarihi";
            // 
            // fcbProjeKod
            // 
            fcbProjeKod.BorderColor = System.Drawing.Color.Silver;
            fcbProjeKod.BorderRadius = 8;
            fcbProjeKod.BorderSize = 1;
            fcbProjeKod.DisplayMember = "kod";
            fcbProjeKod.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbProjeKod.Location = new System.Drawing.Point(160, 120);
            fcbProjeKod.Margin = new Padding(1);
            fcbProjeKod.Name = "fcbProjeKod";
            fcbProjeKod.Padding = new Padding(7, 5, 7, 5);
            fcbProjeKod.PlaceholderText = "Seçiniz...";
            fcbProjeKod.Size = new System.Drawing.Size(203, 25);
            fcbProjeKod.TabIndex = 23;
            fcbProjeKod.ValueMember = "Id";
            fcbProjeKod.SelectedIndexChanged += fcbProjeKod_SelectedIndexChanged;
            // 
            // clbMalzemeGrup
            // 
            clbMalzemeGrup.BorderColor = System.Drawing.Color.Silver;
            clbMalzemeGrup.BorderRadius = 8;
            clbMalzemeGrup.BorderSize = 1;
            clbMalzemeGrup.DisplayMember = "ad";
            clbMalzemeGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbMalzemeGrup.Location = new System.Drawing.Point(160, 201);
            clbMalzemeGrup.Margin = new Padding(1);
            clbMalzemeGrup.Name = "clbMalzemeGrup";
            clbMalzemeGrup.Padding = new Padding(7, 5, 7, 5);
            clbMalzemeGrup.PlaceholderText = "Seçiniz...";
            clbMalzemeGrup.Size = new System.Drawing.Size(203, 25);
            clbMalzemeGrup.TabIndex = 24;
            clbMalzemeGrup.ValueMember = "Id";
            clbMalzemeGrup.SelectedIndexChanged += clbMalzemeGrup_SelectedIndexChanged;
            // 
            // clbStokTip
            // 
            clbStokTip.BorderColor = System.Drawing.Color.Silver;
            clbStokTip.BorderRadius = 8;
            clbStokTip.BorderSize = 1;
            clbStokTip.DisplayMember = "ad";
            clbStokTip.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbStokTip.Location = new System.Drawing.Point(160, 147);
            clbStokTip.Margin = new Padding(1);
            clbStokTip.Name = "clbStokTip";
            clbStokTip.Padding = new Padding(7, 5, 7, 5);
            clbStokTip.PlaceholderText = "Seçiniz...";
            clbStokTip.Size = new System.Drawing.Size(203, 25);
            clbStokTip.TabIndex = 25;
            clbStokTip.ValueMember = "Id";
            clbStokTip.SelectedIndexChanged += clbStokTip_SelectedIndexChanged;
            // 
            // clbStokGrup
            // 
            clbStokGrup.BorderColor = System.Drawing.Color.Silver;
            clbStokGrup.BorderRadius = 8;
            clbStokGrup.BorderSize = 1;
            clbStokGrup.DisplayMember = "ad";
            clbStokGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            clbStokGrup.Location = new System.Drawing.Point(160, 174);
            clbStokGrup.Margin = new Padding(1);
            clbStokGrup.Name = "clbStokGrup";
            clbStokGrup.Padding = new Padding(7, 5, 7, 5);
            clbStokGrup.PlaceholderText = "Seçiniz...";
            clbStokGrup.Size = new System.Drawing.Size(203, 25);
            clbStokGrup.TabIndex = 26;
            clbStokGrup.ValueMember = "Id";
            clbStokGrup.SelectedIndexChanged += clbStokGrup_SelectedIndexChanged;
            // 
            // fcbTalepNeden
            // 
            fcbTalepNeden.BorderColor = System.Drawing.Color.Silver;
            fcbTalepNeden.BorderRadius = 8;
            fcbTalepNeden.BorderSize = 1;
            fcbTalepNeden.DisplayMember = "ad";
            fcbTalepNeden.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbTalepNeden.Location = new System.Drawing.Point(160, 67);
            fcbTalepNeden.Margin = new Padding(1);
            fcbTalepNeden.Name = "fcbTalepNeden";
            fcbTalepNeden.Padding = new Padding(7, 5, 7, 5);
            fcbTalepNeden.PlaceholderText = "Seçiniz...";
            fcbTalepNeden.Size = new System.Drawing.Size(203, 25);
            fcbTalepNeden.TabIndex = 27;
            fcbTalepNeden.ValueMember = "Id";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label8.Location = new System.Drawing.Point(45, 73);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(79, 15);
            label8.TabIndex = 28;
            label8.Text = "Talep Nedeni";
            // 
            // customButtonSave1
            // 
            customButtonSave1.BackgroundColor = System.Drawing.Color.Firebrick;
            customButtonSave1.BorderColor = System.Drawing.Color.Black;
            customButtonSave1.BorderSize = 0;
            customButtonSave1.CornerRadius = 20;
            customButtonSave1.FlatAppearance.BorderSize = 0;
            customButtonSave1.FlatStyle = FlatStyle.Flat;
            customButtonSave1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            customButtonSave1.ForeColor = System.Drawing.Color.White;
            customButtonSave1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            customButtonSave1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            customButtonSave1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            customButtonSave1.HoverColor2 = System.Drawing.Color.Navy;
            customButtonSave1.Icon = null;
            customButtonSave1.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            customButtonSave1.Location = new System.Drawing.Point(907, 575);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(129, 40);
            customButtonSave1.TabIndex = 29;
            customButtonSave1.Text = "TALEP OLUŞTUR";
            customButtonSave1.TextColor = System.Drawing.Color.White;
            customButtonSave1.UseVisualStyleBackColor = true;
            customButtonSave1.Click += customButtonSave1_SaveButtonClick;
            // 
            // SatinalmaTalepOlusturmaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1059, 627);
            Controls.Add(customButtonSave1);
            Controls.Add(ctbAciklama);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(fcbTalepNeden);
            Controls.Add(clbStokGrup);
            Controls.Add(clbStokTip);
            Controls.Add(clbMalzemeGrup);
            Controls.Add(fcbProjeKod);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(ctbTeslimTarihi);
            Controls.Add(ctbTalepNo);
            Controls.Add(panel1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(headerPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SatinalmaTalepOlusturmaFormu";
            Text = "SatinalmaTalepOlusturmaFormu";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomComboListBox clbProjeKod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Panel panel1;
        private CustomTextBox ctbAciklama;
        private Label label6;
        private CustomTextBox ctbTalepNo;
        private CustomTextBoxTarih ctbTeslimTarihi;
        private Label label1;
        private Label label7;
        private FilterableComboBox fcbProjeKod;
        private FilterableComboBox clbMalzemeGrup;
        private FilterableComboBox clbStokTip;
        private FilterableComboBox clbStokGrup;
        private FilterableComboBox fcbTalepNeden;
        private Label label8;
        private RoundedButton customButtonSave1;
    }
}