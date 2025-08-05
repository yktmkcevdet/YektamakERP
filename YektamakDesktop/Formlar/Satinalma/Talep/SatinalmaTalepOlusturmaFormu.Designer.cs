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
            customButtonSave1 = new CustomButtonSave();
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
            headerPanel1.Size = new System.Drawing.Size(1060, 32);
            headerPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(46, 134);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 4;
            label2.Text = "Proej Kodu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(45, 172);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(52, 15);
            label3.TabIndex = 6;
            label3.Text = "Stok Tipi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(46, 212);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 15);
            label4.TabIndex = 9;
            label4.Text = "Stok Grubu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(46, 250);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(91, 15);
            label5.TabIndex = 10;
            label5.Text = "Malzeme Grubu";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new System.Drawing.Point(45, 292);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(991, 263);
            panel1.TabIndex = 15;
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(930, 561);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 16;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
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
            ctbAciklama.Location = new System.Drawing.Point(577, 176);
            ctbAciklama.Multiline = true;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new Padding(7, 5, 7, 5);
            ctbAciklama.PasswordChar = false;
            ctbAciklama.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAciklama.PlaceholderText = "";
            ctbAciklama.ReadOnly = false;
            ctbAciklama.SelectionStart = 0;
            ctbAciklama.Size = new System.Drawing.Size(390, 98);
            ctbAciklama.TabIndex = 17;
            ctbAciklama.TextAlignment = HorizontalAlignment.Left;
            ctbAciklama.TextCustom = "";
            ctbAciklama.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(453, 181);
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
            ctbTalepNo.BorderRadius = 5;
            ctbTalepNo.BorderSize = 1;
            ctbTalepNo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbTalepNo.ForeColor = System.Drawing.Color.Black;
            ctbTalepNo.isPlaceHolder = false;
            ctbTalepNo.Location = new System.Drawing.Point(165, 45);
            ctbTalepNo.Multiline = false;
            ctbTalepNo.Name = "ctbTalepNo";
            ctbTalepNo.Padding = new Padding(7, 5, 7, 5);
            ctbTalepNo.PasswordChar = false;
            ctbTalepNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbTalepNo.PlaceholderText = "";
            ctbTalepNo.ReadOnly = false;
            ctbTalepNo.SelectionStart = 0;
            ctbTalepNo.Size = new System.Drawing.Size(105, 28);
            ctbTalepNo.TabIndex = 19;
            ctbTalepNo.TextAlignment = HorizontalAlignment.Left;
            ctbTalepNo.TextCustom = "";
            ctbTalepNo.UnderlinedStyle = false;
            // 
            // ctbTeslimTarihi
            // 
            ctbTeslimTarihi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ctbTeslimTarihi.Location = new System.Drawing.Point(165, 81);
            ctbTeslimTarihi.Margin = new Padding(1);
            ctbTeslimTarihi.Name = "ctbTeslimTarihi";
            ctbTeslimTarihi.Padding = new Padding(1);
            ctbTeslimTarihi.Size = new System.Drawing.Size(145, 32);
            ctbTeslimTarihi.TabIndex = 20;
            ctbTeslimTarihi.TextCustom = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(46, 50);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 15);
            label1.TabIndex = 21;
            label1.Text = "Talep No";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(46, 90);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(73, 15);
            label7.TabIndex = 22;
            label7.Text = "İhtiyaç Tarihi";
            // 
            // fcbProjeKod
            // 
            fcbProjeKod.BorderColor = System.Drawing.Color.Silver;
            fcbProjeKod.BorderSize = 1;
            fcbProjeKod.DataSource = null;
            fcbProjeKod.DisplayMember = "kod";
            fcbProjeKod.Location = new System.Drawing.Point(165, 129);
            fcbProjeKod.Name = "fcbProjeKod";
            fcbProjeKod.Padding = new Padding(7, 5, 7, 5);
            fcbProjeKod.PlaceholderText = "Seçiniz...";
            fcbProjeKod.SelectedIndex = -1;
            fcbProjeKod.SelectedItem = null;
            fcbProjeKod.SelectedValue = null;
            fcbProjeKod.Size = new System.Drawing.Size(203, 29);
            fcbProjeKod.TabIndex = 23;
            fcbProjeKod.UnderlinedStyle = false;
            fcbProjeKod.ValueMember = "Id";
            fcbProjeKod.SelectedIndexChanged += fcbProjeKod_SelectedIndexChanged;
            // 
            // clbMalzemeGrup
            // 
            clbMalzemeGrup.BorderColor = System.Drawing.Color.Silver;
            clbMalzemeGrup.BorderSize = 1;
            clbMalzemeGrup.DataSource = null;
            clbMalzemeGrup.DisplayMember = "ad";
            clbMalzemeGrup.Location = new System.Drawing.Point(165, 245);
            clbMalzemeGrup.Name = "clbMalzemeGrup";
            clbMalzemeGrup.Padding = new Padding(7, 5, 7, 5);
            clbMalzemeGrup.PlaceholderText = "Seçiniz...";
            clbMalzemeGrup.SelectedIndex = -1;
            clbMalzemeGrup.SelectedItem = null;
            clbMalzemeGrup.SelectedValue = null;
            clbMalzemeGrup.Size = new System.Drawing.Size(203, 29);
            clbMalzemeGrup.TabIndex = 24;
            clbMalzemeGrup.UnderlinedStyle = false;
            clbMalzemeGrup.ValueMember = "Id";
            clbMalzemeGrup.SelectedIndexChanged += clbMalzemeGrup_SelectedIndexChanged;
            // 
            // clbStokTip
            // 
            clbStokTip.BorderColor = System.Drawing.Color.Silver;
            clbStokTip.BorderSize = 1;
            clbStokTip.DataSource = null;
            clbStokTip.DisplayMember = "ad";
            clbStokTip.Location = new System.Drawing.Point(165, 170);
            clbStokTip.Name = "clbStokTip";
            clbStokTip.Padding = new Padding(7, 5, 7, 5);
            clbStokTip.PlaceholderText = "Seçiniz...";
            clbStokTip.SelectedIndex = -1;
            clbStokTip.SelectedItem = null;
            clbStokTip.SelectedValue = null;
            clbStokTip.Size = new System.Drawing.Size(203, 29);
            clbStokTip.TabIndex = 25;
            clbStokTip.UnderlinedStyle = false;
            clbStokTip.ValueMember = "Id";
            clbStokTip.SelectedIndexChanged += clbStokTip_SelectedIndexChanged;
            // 
            // clbStokGrup
            // 
            clbStokGrup.BorderColor = System.Drawing.Color.Silver;
            clbStokGrup.BorderSize = 1;
            clbStokGrup.DataSource = null;
            clbStokGrup.DisplayMember = "ad";
            clbStokGrup.Location = new System.Drawing.Point(165, 210);
            clbStokGrup.Name = "clbStokGrup";
            clbStokGrup.Padding = new Padding(7, 5, 7, 5);
            clbStokGrup.PlaceholderText = "Seçiniz...";
            clbStokGrup.SelectedIndex = -1;
            clbStokGrup.SelectedItem = null;
            clbStokGrup.SelectedValue = null;
            clbStokGrup.Size = new System.Drawing.Size(203, 29);
            clbStokGrup.TabIndex = 26;
            clbStokGrup.UnderlinedStyle = false;
            clbStokGrup.ValueMember = "Id";
            clbStokGrup.SelectedIndexChanged += clbStokGrup_SelectedIndexChanged;
            // 
            // SatinalmaTalepOlusturmaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1059, 627);
            Controls.Add(clbStokGrup);
            Controls.Add(clbStokTip);
            Controls.Add(clbMalzemeGrup);
            Controls.Add(fcbProjeKod);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(ctbTeslimTarihi);
            Controls.Add(ctbTalepNo);
            Controls.Add(label6);
            Controls.Add(ctbAciklama);
            Controls.Add(customButtonSave1);
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
        private CustomButtonSave customButtonSave1;
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
    }
}