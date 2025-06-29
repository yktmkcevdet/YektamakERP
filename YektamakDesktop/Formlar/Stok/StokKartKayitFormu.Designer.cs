using Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Properties;
using static YektamakDesktop.Formlar.Satis.SatisTeklifMaliyetKayitFormu;

namespace YektamakDesktop.Formlar.Stok
{
    partial class StokKartKayitFormu
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
            textBoxId = new CustomTextBox();
            textBoxkod = new CustomTextBox();
            roundedButton2 = new RoundedButton();
            panelHeader = new Panel();
            btnClose = new RoundedButton();
            btnMinimize = new RoundedButton();
            roundedButton3 = new RoundedButton();
            bntHelp = new RoundedButton();
            labelHeader = new Label();
            roundedButton1 = new RoundedButton();
            label1 = new Label();
            label2 = new Label();
            textBoxLogoKod = new CustomTextBox();
            label3 = new Label();
            label4 = new Label();
            ctbStokAd = new CustomTextBox();
            clbStokGrup = new CustomComboListBox();
            label5 = new Label();
            label6 = new Label();
            comboListBoxMalzemeStandart = new CustomComboListBox();
            label7 = new Label();
            clbMalzemeGrup = new CustomComboListBox();
            label8 = new Label();
            comboListBoxOlcuBirim = new CustomComboListBox();
            label9 = new Label();
            comboListBoxProjeKod = new CustomComboListBox();
            label14 = new Label();
            textBoxBoy = new CustomTextBoxSayisal();
            textBoxEn = new CustomTextBoxSayisal();
            label15 = new Label();
            textBoxYukseklik = new CustomTextBoxSayisal();
            label16 = new Label();
            textBoxCap = new CustomTextBoxSayisal();
            label17 = new Label();
            textBoxUzunluk = new CustomTextBoxSayisal();
            label18 = new Label();
            textBoxEtKalinlik = new CustomTextBoxSayisal();
            label19 = new Label();
            label20 = new Label();
            textBoxAciklama = new CustomTextBox();
            label21 = new Label();
            clbStokTip = new CustomComboListBox();
            rButtonKaydet = new RoundedButton();
            label23 = new Label();
            clbMalzemeAltGrup = new CustomComboListBox();
            label24 = new Label();
            clbMalzemeAltGrup2 = new CustomComboListBox();
            panel1 = new Panel();
            textBoxAgirlik = new CustomTextBoxSayisal();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label22 = new Label();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            label29 = new Label();
            textBoxBoyut = new CustomTextBox();
            checkBoxIsSatinalma = new CheckBox();
            checkBoxIsPdf = new CheckBox();
            checkBoxIsFromExcel = new CheckBox();
            checkBoxIsStep = new CheckBox();
            checkBoxIsDxf = new CheckBox();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxId
            // 
            textBoxId.BackColor = Color.White;
            textBoxId.BorderColor = Color.Silver;
            textBoxId.BorderFocusColor = Color.HotPink;
            textBoxId.BorderRadius = 5;
            textBoxId.BorderSize = 1;
            textBoxId.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxId.ForeColor = Color.Black;
            textBoxId.isPlaceHolder = false;
            textBoxId.Location = new Point(186, 61);
            textBoxId.Multiline = false;
            textBoxId.Name = "textBoxId";
            textBoxId.Padding = new Padding(7, 5, 7, 5);
            textBoxId.PasswordChar = false;
            textBoxId.PlaceholderColor = Color.DarkGray;
            textBoxId.PlaceholderText = "";
            textBoxId.ReadOnly = false;
            textBoxId.SelectionStart = 0;
            textBoxId.Size = new Size(94, 28);
            textBoxId.TabIndex = 0;
            textBoxId.TextAlignment = HorizontalAlignment.Left;
            textBoxId.TextCustom = "";
            textBoxId.UnderlinedStyle = false;
            // 
            // textBoxkod
            // 
            textBoxkod.BackColor = Color.White;
            textBoxkod.BorderColor = Color.Silver;
            textBoxkod.BorderFocusColor = Color.HotPink;
            textBoxkod.BorderRadius = 5;
            textBoxkod.BorderSize = 1;
            textBoxkod.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxkod.ForeColor = Color.Black;
            textBoxkod.isPlaceHolder = false;
            textBoxkod.Location = new Point(186, 172);
            textBoxkod.Multiline = false;
            textBoxkod.Name = "textBoxkod";
            textBoxkod.Padding = new Padding(7, 5, 7, 5);
            textBoxkod.PasswordChar = false;
            textBoxkod.PlaceholderColor = Color.DarkGray;
            textBoxkod.PlaceholderText = "";
            textBoxkod.ReadOnly = false;
            textBoxkod.SelectionStart = 0;
            textBoxkod.Size = new Size(259, 28);
            textBoxkod.TabIndex = 1;
            textBoxkod.TextAlignment = HorizontalAlignment.Left;
            textBoxkod.TextCustom = "";
            textBoxkod.UnderlinedStyle = false;
            // 
            // roundedButton2
            // 
            roundedButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roundedButton2.BackColor = Color.Firebrick;
            roundedButton2.BackgroundColor = Color.Firebrick;
            roundedButton2.BorderColor = Color.Firebrick;
            roundedButton2.BorderRadius = 10;
            roundedButton2.BorderSize = 2;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = FlatStyle.Flat;
            roundedButton2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            roundedButton2.ForeColor = Color.White;
            roundedButton2.Location = new Point(2009, 1);
            roundedButton2.Margin = new Padding(0);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Padding = new Padding(3, 0, 0, 0);
            roundedButton2.Size = new Size(29, 27);
            roundedButton2.TabIndex = 99;
            roundedButton2.Text = "?";
            roundedButton2.TextColor = Color.White;
            roundedButton2.UseVisualStyleBackColor = false;
            // 
            // panelHeader
            // 
            panelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelHeader.BackColor = Color.Firebrick;
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(btnMinimize);
            panelHeader.Controls.Add(roundedButton3);
            panelHeader.Controls.Add(bntHelp);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Controls.Add(roundedButton1);
            panelHeader.Controls.Add(roundedButton2);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1040, 32);
            panelHeader.TabIndex = 8;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Firebrick;
            btnClose.BackgroundColor = Color.Firebrick;
            btnClose.BorderColor = Color.Firebrick;
            btnClose.BorderRadius = 10;
            btnClose.BorderSize = 2;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1002, 2);
            btnClose.Margin = new Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(3, 0, 0, 0);
            btnClose.Size = new Size(29, 27);
            btnClose.TabIndex = 103;
            btnClose.Text = "X";
            btnClose.TextColor = Color.White;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.BackColor = Color.Firebrick;
            btnMinimize.BackgroundColor = Color.Firebrick;
            btnMinimize.BorderColor = Color.Firebrick;
            btnMinimize.BorderRadius = 10;
            btnMinimize.BorderSize = 2;
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(962, 2);
            btnMinimize.Margin = new Padding(0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Padding = new Padding(3, 0, 0, 0);
            btnMinimize.Size = new Size(29, 27);
            btnMinimize.TabIndex = 101;
            btnMinimize.Text = "-";
            btnMinimize.TextColor = Color.White;
            btnMinimize.UseVisualStyleBackColor = false;
            // 
            // roundedButton3
            // 
            roundedButton3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roundedButton3.BackColor = Color.Firebrick;
            roundedButton3.BackgroundColor = Color.Firebrick;
            roundedButton3.BorderColor = Color.Firebrick;
            roundedButton3.BorderRadius = 10;
            roundedButton3.BorderSize = 2;
            roundedButton3.FlatAppearance.BorderSize = 0;
            roundedButton3.FlatStyle = FlatStyle.Flat;
            roundedButton3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            roundedButton3.ForeColor = Color.White;
            roundedButton3.Location = new Point(2089, 1);
            roundedButton3.Margin = new Padding(0);
            roundedButton3.Name = "roundedButton3";
            roundedButton3.Padding = new Padding(3, 0, 0, 0);
            roundedButton3.Size = new Size(29, 27);
            roundedButton3.TabIndex = 100;
            roundedButton3.Text = "X";
            roundedButton3.TextColor = Color.White;
            roundedButton3.UseVisualStyleBackColor = false;
            // 
            // bntHelp
            // 
            bntHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bntHelp.BackColor = Color.Firebrick;
            bntHelp.BackgroundColor = Color.Firebrick;
            bntHelp.BorderColor = Color.Firebrick;
            bntHelp.BorderRadius = 10;
            bntHelp.BorderSize = 2;
            bntHelp.Cursor = Cursors.Hand;
            bntHelp.FlatAppearance.BorderSize = 0;
            bntHelp.FlatStyle = FlatStyle.Flat;
            bntHelp.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            bntHelp.ForeColor = Color.White;
            bntHelp.Location = new Point(922, 2);
            bntHelp.Margin = new Padding(0);
            bntHelp.Name = "bntHelp";
            bntHelp.Padding = new Padding(3, 0, 0, 0);
            bntHelp.Size = new Size(29, 27);
            bntHelp.TabIndex = 102;
            bntHelp.Text = "?";
            bntHelp.TextColor = Color.White;
            bntHelp.UseVisualStyleBackColor = false;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeader.ForeColor = SystemColors.ControlLightLight;
            labelHeader.Location = new Point(12, 6);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(110, 17);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Stok Kart Tanımı";
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roundedButton1.BackColor = Color.Firebrick;
            roundedButton1.BackgroundColor = Color.Firebrick;
            roundedButton1.BorderColor = Color.Firebrick;
            roundedButton1.BorderRadius = 10;
            roundedButton1.BorderSize = 2;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            roundedButton1.ForeColor = Color.White;
            roundedButton1.Location = new Point(2049, 1);
            roundedButton1.Margin = new Padding(0);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new Padding(3, 0, 0, 0);
            roundedButton1.Size = new Size(29, 27);
            roundedButton1.TabIndex = 98;
            roundedButton1.Text = "-";
            roundedButton1.TextColor = Color.White;
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(56, 67);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 9;
            label1.Text = "Stok Kart Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(56, 179);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 10;
            label2.Text = "Parça Kodu";
            // 
            // textBoxLogoKod
            // 
            textBoxLogoKod.BackColor = Color.White;
            textBoxLogoKod.BorderColor = Color.Silver;
            textBoxLogoKod.BorderFocusColor = Color.HotPink;
            textBoxLogoKod.BorderRadius = 5;
            textBoxLogoKod.BorderSize = 1;
            textBoxLogoKod.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLogoKod.ForeColor = Color.Black;
            textBoxLogoKod.isPlaceHolder = false;
            textBoxLogoKod.Location = new Point(186, 206);
            textBoxLogoKod.Multiline = false;
            textBoxLogoKod.Name = "textBoxLogoKod";
            textBoxLogoKod.Padding = new Padding(7, 5, 7, 5);
            textBoxLogoKod.PasswordChar = false;
            textBoxLogoKod.PlaceholderColor = Color.DarkGray;
            textBoxLogoKod.PlaceholderText = "";
            textBoxLogoKod.ReadOnly = false;
            textBoxLogoKod.SelectionStart = 0;
            textBoxLogoKod.Size = new Size(259, 28);
            textBoxLogoKod.TabIndex = 11;
            textBoxLogoKod.TextAlignment = HorizontalAlignment.Left;
            textBoxLogoKod.TextCustom = "";
            textBoxLogoKod.UnderlinedStyle = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(56, 213);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 12;
            label3.Text = "Logo Kodu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(56, 247);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 14;
            label4.Text = "Stok Adı";
            // 
            // ctxbStokAd
            // 
            ctbStokAd.BackColor = Color.White;
            ctbStokAd.BorderColor = Color.Silver;
            ctbStokAd.BorderFocusColor = Color.HotPink;
            ctbStokAd.BorderRadius = 5;
            ctbStokAd.BorderSize = 1;
            ctbStokAd.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbStokAd.ForeColor = Color.Black;
            ctbStokAd.isPlaceHolder = false;
            ctbStokAd.Location = new Point(186, 240);
            ctbStokAd.Multiline = false;
            ctbStokAd.Name = "ctxbStokAd";
            ctbStokAd.Padding = new Padding(7, 5, 7, 5);
            ctbStokAd.PasswordChar = false;
            ctbStokAd.PlaceholderColor = Color.DarkGray;
            ctbStokAd.PlaceholderText = "";
            ctbStokAd.ReadOnly = false;
            ctbStokAd.SelectionStart = 0;
            ctbStokAd.Size = new Size(575, 28);
            ctbStokAd.TabIndex = 13;
            ctbStokAd.TextAlignment = HorizontalAlignment.Left;
            ctbStokAd.TextCustom = "";
            ctbStokAd.UnderlinedStyle = false;
            // 
            // cbxStokGrup
            // 
            clbStokGrup.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            clbStokGrup.ListBoxVisualSize = 5;
            clbStokGrup.Location = new Point(56, 422);
            clbStokGrup.Margin = new Padding(1);
            clbStokGrup.Name = "cbxStokGrup";
            clbStokGrup.Padding = new Padding(1);
            clbStokGrup.Size = new Size(201, 36);
            clbStokGrup.TabIndex = 15;
            clbStokGrup.SelectedIndexChanged += cbxStokGrup_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(56, 398);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 16;
            label5.Text = "Stok Grubu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(56, 321);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 18;
            label6.Text = "Malzme Std.";
            // 
            // comboListBoxMalzemeStandart
            // 
            comboListBoxMalzemeStandart.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboListBoxMalzemeStandart.ListBoxVisualSize = 5;
            comboListBoxMalzemeStandart.Location = new Point(186, 313);
            comboListBoxMalzemeStandart.Margin = new Padding(1);
            comboListBoxMalzemeStandart.Name = "comboListBoxMalzemeStandart";
            comboListBoxMalzemeStandart.Padding = new Padding(1);
            comboListBoxMalzemeStandart.Size = new Size(172, 36);
            comboListBoxMalzemeStandart.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(262, 398);
            label7.Name = "label7";
            label7.Size = new Size(96, 15);
            label7.TabIndex = 20;
            label7.Text = "Malzeme Grubu";
            // 
            // cbxMalzemeGrup
            // 
            clbMalzemeGrup.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            clbMalzemeGrup.ListBoxVisualSize = 5;
            clbMalzemeGrup.Location = new Point(262, 422);
            clbMalzemeGrup.Margin = new Padding(1);
            clbMalzemeGrup.Name = "cbxMalzemeGrup";
            clbMalzemeGrup.Padding = new Padding(1);
            clbMalzemeGrup.Size = new Size(251, 36);
            clbMalzemeGrup.TabIndex = 19;
            clbMalzemeGrup.SelectedIndexChanged += cbxMalzemeGrup_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(56, 283);
            label8.Name = "label8";
            label8.Size = new Size(68, 15);
            label8.TabIndex = 22;
            label8.Text = "Ölçü Birimi";
            // 
            // comboListBoxOlcuBirim
            // 
            comboListBoxOlcuBirim.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboListBoxOlcuBirim.ListBoxVisualSize = 5;
            comboListBoxOlcuBirim.Location = new Point(186, 275);
            comboListBoxOlcuBirim.Margin = new Padding(1);
            comboListBoxOlcuBirim.Name = "comboListBoxOlcuBirim";
            comboListBoxOlcuBirim.Padding = new Padding(1);
            comboListBoxOlcuBirim.Size = new Size(138, 36);
            comboListBoxOlcuBirim.TabIndex = 21;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(56, 107);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 24;
            label9.Text = "Proje Kodu";
            // 
            // comboListBoxProjeKod
            // 
            comboListBoxProjeKod.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboListBoxProjeKod.ListBoxVisualSize = 5;
            comboListBoxProjeKod.Location = new Point(186, 99);
            comboListBoxProjeKod.Margin = new Padding(1);
            comboListBoxProjeKod.Name = "comboListBoxProjeKod";
            comboListBoxProjeKod.Padding = new Padding(1);
            comboListBoxProjeKod.Size = new Size(138, 36);
            comboListBoxProjeKod.TabIndex = 23;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(166, 456);
            label14.Name = "label14";
            label14.Size = new Size(28, 15);
            label14.TabIndex = 34;
            label14.Text = "Boy";
            // 
            // textBoxBoy
            // 
            textBoxBoy.BackColor = Color.White;
            textBoxBoy.BorderColor = Color.Silver;
            textBoxBoy.BorderFocusColor = Color.HotPink;
            textBoxBoy.BorderRadius = 5;
            textBoxBoy.BorderSize = 1;
            textBoxBoy.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxBoy.ForeColor = Color.Black;
            textBoxBoy.Location = new Point(166, 474);
            textBoxBoy.Multiline = false;
            textBoxBoy.Name = "textBoxBoy";
            textBoxBoy.OndalikBasamak = 0;
            textBoxBoy.Padding = new Padding(10, 7, 10, 7);
            textBoxBoy.PasswordChar = false;
            textBoxBoy.PlaceholderColor = Color.DarkGray;
            textBoxBoy.PlaceholderText = "";
            textBoxBoy.ReadOnly = false;
            textBoxBoy.SelectionStart = 0;
            textBoxBoy.Size = new Size(75, 32);
            textBoxBoy.TabIndex = 35;
            textBoxBoy.TextAlignment = HorizontalAlignment.Right;
            textBoxBoy.TextCustom = "0";
            textBoxBoy.UnderlinedStyle = false;
            // 
            // textBoxEn
            // 
            textBoxEn.BackColor = Color.White;
            textBoxEn.BorderColor = Color.Silver;
            textBoxEn.BorderFocusColor = Color.HotPink;
            textBoxEn.BorderRadius = 5;
            textBoxEn.BorderSize = 1;
            textBoxEn.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEn.ForeColor = Color.Black;
            textBoxEn.Location = new Point(287, 474);
            textBoxEn.Multiline = false;
            textBoxEn.Name = "textBoxEn";
            textBoxEn.OndalikBasamak = 0;
            textBoxEn.Padding = new Padding(10, 7, 10, 7);
            textBoxEn.PasswordChar = false;
            textBoxEn.PlaceholderColor = Color.DarkGray;
            textBoxEn.PlaceholderText = "";
            textBoxEn.ReadOnly = false;
            textBoxEn.SelectionStart = 0;
            textBoxEn.Size = new Size(71, 32);
            textBoxEn.TabIndex = 37;
            textBoxEn.TextAlignment = HorizontalAlignment.Right;
            textBoxEn.TextCustom = "0";
            textBoxEn.UnderlinedStyle = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(287, 456);
            label15.Name = "label15";
            label15.Size = new Size(20, 15);
            label15.TabIndex = 36;
            label15.Text = "En";
            // 
            // textBoxYukseklik
            // 
            textBoxYukseklik.BackColor = Color.White;
            textBoxYukseklik.BorderColor = Color.Silver;
            textBoxYukseklik.BorderFocusColor = Color.HotPink;
            textBoxYukseklik.BorderRadius = 5;
            textBoxYukseklik.BorderSize = 1;
            textBoxYukseklik.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxYukseklik.ForeColor = Color.Black;
            textBoxYukseklik.Location = new Point(404, 474);
            textBoxYukseklik.Multiline = false;
            textBoxYukseklik.Name = "textBoxYukseklik";
            textBoxYukseklik.OndalikBasamak = 0;
            textBoxYukseklik.Padding = new Padding(10, 7, 10, 7);
            textBoxYukseklik.PasswordChar = false;
            textBoxYukseklik.PlaceholderColor = Color.DarkGray;
            textBoxYukseklik.PlaceholderText = "";
            textBoxYukseklik.ReadOnly = false;
            textBoxYukseklik.SelectionStart = 0;
            textBoxYukseklik.Size = new Size(67, 32);
            textBoxYukseklik.TabIndex = 39;
            textBoxYukseklik.TextAlignment = HorizontalAlignment.Right;
            textBoxYukseklik.TextCustom = "0";
            textBoxYukseklik.UnderlinedStyle = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(404, 456);
            label16.Name = "label16";
            label16.Size = new Size(59, 15);
            label16.TabIndex = 38;
            label16.Text = "Yükseklik";
            // 
            // textBoxCap
            // 
            textBoxCap.BackColor = Color.White;
            textBoxCap.BorderColor = Color.Silver;
            textBoxCap.BorderFocusColor = Color.HotPink;
            textBoxCap.BorderRadius = 5;
            textBoxCap.BorderSize = 1;
            textBoxCap.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCap.ForeColor = Color.Black;
            textBoxCap.Location = new Point(521, 474);
            textBoxCap.Multiline = false;
            textBoxCap.Name = "textBoxCap";
            textBoxCap.OndalikBasamak = 0;
            textBoxCap.Padding = new Padding(10, 7, 10, 7);
            textBoxCap.PasswordChar = false;
            textBoxCap.PlaceholderColor = Color.DarkGray;
            textBoxCap.PlaceholderText = "";
            textBoxCap.ReadOnly = false;
            textBoxCap.SelectionStart = 0;
            textBoxCap.Size = new Size(73, 32);
            textBoxCap.TabIndex = 41;
            textBoxCap.TextAlignment = HorizontalAlignment.Right;
            textBoxCap.TextCustom = "0";
            textBoxCap.UnderlinedStyle = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(521, 456);
            label17.Name = "label17";
            label17.Size = new Size(27, 15);
            label17.TabIndex = 40;
            label17.Text = "Çap";
            // 
            // textBoxUzunluk
            // 
            textBoxUzunluk.BackColor = Color.White;
            textBoxUzunluk.BorderColor = Color.Silver;
            textBoxUzunluk.BorderFocusColor = Color.HotPink;
            textBoxUzunluk.BorderRadius = 5;
            textBoxUzunluk.BorderSize = 1;
            textBoxUzunluk.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUzunluk.ForeColor = Color.Black;
            textBoxUzunluk.Location = new Point(644, 474);
            textBoxUzunluk.Multiline = false;
            textBoxUzunluk.Name = "textBoxUzunluk";
            textBoxUzunluk.OndalikBasamak = 0;
            textBoxUzunluk.Padding = new Padding(10, 7, 10, 7);
            textBoxUzunluk.PasswordChar = false;
            textBoxUzunluk.PlaceholderColor = Color.DarkGray;
            textBoxUzunluk.PlaceholderText = "";
            textBoxUzunluk.ReadOnly = false;
            textBoxUzunluk.SelectionStart = 0;
            textBoxUzunluk.Size = new Size(67, 32);
            textBoxUzunluk.TabIndex = 43;
            textBoxUzunluk.TextAlignment = HorizontalAlignment.Right;
            textBoxUzunluk.TextCustom = "0";
            textBoxUzunluk.UnderlinedStyle = false;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(644, 456);
            label18.Name = "label18";
            label18.Size = new Size(53, 15);
            label18.TabIndex = 42;
            label18.Text = "Uzunluk";
            // 
            // textBoxEtKalinlik
            // 
            textBoxEtKalinlik.BackColor = Color.White;
            textBoxEtKalinlik.BorderColor = Color.Silver;
            textBoxEtKalinlik.BorderFocusColor = Color.HotPink;
            textBoxEtKalinlik.BorderRadius = 5;
            textBoxEtKalinlik.BorderSize = 1;
            textBoxEtKalinlik.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEtKalinlik.ForeColor = Color.Black;
            textBoxEtKalinlik.Location = new Point(769, 474);
            textBoxEtKalinlik.Multiline = false;
            textBoxEtKalinlik.Name = "textBoxEtKalinlik";
            textBoxEtKalinlik.OndalikBasamak = 0;
            textBoxEtKalinlik.Padding = new Padding(10, 7, 10, 7);
            textBoxEtKalinlik.PasswordChar = false;
            textBoxEtKalinlik.PlaceholderColor = Color.DarkGray;
            textBoxEtKalinlik.PlaceholderText = "";
            textBoxEtKalinlik.ReadOnly = false;
            textBoxEtKalinlik.SelectionStart = 0;
            textBoxEtKalinlik.Size = new Size(72, 32);
            textBoxEtKalinlik.TabIndex = 45;
            textBoxEtKalinlik.TextAlignment = HorizontalAlignment.Right;
            textBoxEtKalinlik.TextCustom = "0";
            textBoxEtKalinlik.UnderlinedStyle = false;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label19.Location = new Point(769, 456);
            label19.Name = "label19";
            label19.Size = new Size(64, 15);
            label19.TabIndex = 44;
            label19.Text = "Et Kalınlığı";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label20.Location = new Point(56, 530);
            label20.Name = "label20";
            label20.Size = new Size(57, 15);
            label20.TabIndex = 47;
            label20.Text = "Açıklama";
            // 
            // textBoxAciklama
            // 
            textBoxAciklama.BackColor = Color.White;
            textBoxAciklama.BorderColor = Color.Silver;
            textBoxAciklama.BorderFocusColor = Color.HotPink;
            textBoxAciklama.BorderRadius = 5;
            textBoxAciklama.BorderSize = 1;
            textBoxAciklama.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxAciklama.ForeColor = Color.Black;
            textBoxAciklama.isPlaceHolder = false;
            textBoxAciklama.Location = new Point(186, 523);
            textBoxAciklama.Multiline = false;
            textBoxAciklama.Name = "textBoxAciklama";
            textBoxAciklama.Padding = new Padding(7, 5, 7, 5);
            textBoxAciklama.PasswordChar = false;
            textBoxAciklama.PlaceholderColor = Color.DarkGray;
            textBoxAciklama.PlaceholderText = "";
            textBoxAciklama.ReadOnly = false;
            textBoxAciklama.SelectionStart = 0;
            textBoxAciklama.Size = new Size(845, 28);
            textBoxAciklama.TabIndex = 46;
            textBoxAciklama.TextAlignment = HorizontalAlignment.Left;
            textBoxAciklama.TextCustom = "";
            textBoxAciklama.UnderlinedStyle = false;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label21.Location = new Point(56, 145);
            label21.Name = "label21";
            label21.Size = new Size(56, 15);
            label21.TabIndex = 49;
            label21.Text = "Stok Tipi";
            // 
            // cbxStokTip
            // 
            clbStokTip.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            clbStokTip.ListBoxVisualSize = 5;
            clbStokTip.Location = new Point(186, 137);
            clbStokTip.Margin = new Padding(1);
            clbStokTip.Name = "cbxStokTip";
            clbStokTip.Padding = new Padding(1);
            clbStokTip.Size = new Size(251, 36);
            clbStokTip.TabIndex = 48;
            // 
            // rButtonKaydet
            // 
            rButtonKaydet.BackColor = Color.Transparent;
            rButtonKaydet.BackgroundColor = Color.Transparent;
            rButtonKaydet.BorderColor = Color.MediumSeaGreen;
            rButtonKaydet.BorderRadius = 20;
            rButtonKaydet.BorderSize = 2;
            rButtonKaydet.Cursor = Cursors.Hand;
            rButtonKaydet.FlatAppearance.BorderSize = 0;
            rButtonKaydet.FlatStyle = FlatStyle.Flat;
            rButtonKaydet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rButtonKaydet.ForeColor = Color.White;
            rButtonKaydet.Image = Resources.save;
            rButtonKaydet.Location = new Point(984, 761);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new Size(47, 49);
            rButtonKaydet.TabIndex = 52;
            rButtonKaydet.TextColor = Color.White;
            rButtonKaydet.TextImageRelation = TextImageRelation.ImageAboveText;
            rButtonKaydet.UseCompatibleTextRendering = true;
            rButtonKaydet.UseVisualStyleBackColor = false;
            rButtonKaydet.Click += rButtonKaydet_Click;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label23.Location = new Point(519, 398);
            label23.Name = "label23";
            label23.Size = new Size(115, 15);
            label23.TabIndex = 54;
            label23.Text = "Malzeme Alt Grubu";
            // 
            // cbxMalzemeAltGrup
            // 
            clbMalzemeAltGrup.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            clbMalzemeAltGrup.ListBoxVisualSize = 5;
            clbMalzemeAltGrup.Location = new Point(519, 422);
            clbMalzemeAltGrup.Margin = new Padding(1);
            clbMalzemeAltGrup.Name = "cbxMalzemeAltGrup";
            clbMalzemeAltGrup.Padding = new Padding(1);
            clbMalzemeAltGrup.Size = new Size(251, 36);
            clbMalzemeAltGrup.TabIndex = 53;
            clbMalzemeAltGrup.SelectedIndexChanged += cbxMalzemeAltGrup_SelectedIndexChanged;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label24.Location = new Point(783, 398);
            label24.Name = "label24";
            label24.Size = new Size(125, 15);
            label24.TabIndex = 56;
            label24.Text = "Malzeme Alt Grubu 2";
            // 
            // cbxMalzemeAltGrup2
            // 
            clbMalzemeAltGrup2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            clbMalzemeAltGrup2.ListBoxVisualSize = 5;
            clbMalzemeAltGrup2.Location = new Point(783, 422);
            clbMalzemeAltGrup2.Margin = new Padding(1);
            clbMalzemeAltGrup2.Name = "cbxMalzemeAltGrup2";
            clbMalzemeAltGrup2.Padding = new Padding(1);
            clbMalzemeAltGrup2.Size = new Size(251, 36);
            clbMalzemeAltGrup2.TabIndex = 55;
            clbMalzemeAltGrup2.SelectedIndexChanged += cbxMalzemeAltGrup2_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(56, 608);
            panel1.Name = "panel1";
            panel1.Size = new Size(714, 191);
            panel1.TabIndex = 57;
            // 
            // textBoxAgirlik
            // 
            textBoxAgirlik.BackColor = Color.White;
            textBoxAgirlik.BorderColor = Color.Silver;
            textBoxAgirlik.BorderFocusColor = Color.HotPink;
            textBoxAgirlik.BorderRadius = 5;
            textBoxAgirlik.BorderSize = 1;
            textBoxAgirlik.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxAgirlik.ForeColor = Color.Black;
            textBoxAgirlik.Location = new Point(56, 474);
            textBoxAgirlik.Multiline = false;
            textBoxAgirlik.Name = "textBoxAgirlik";
            textBoxAgirlik.OndalikBasamak = 3;
            textBoxAgirlik.Padding = new Padding(10, 7, 10, 7);
            textBoxAgirlik.PasswordChar = false;
            textBoxAgirlik.PlaceholderColor = Color.DarkGray;
            textBoxAgirlik.PlaceholderText = "";
            textBoxAgirlik.ReadOnly = false;
            textBoxAgirlik.SelectionStart = 0;
            textBoxAgirlik.Size = new Size(69, 32);
            textBoxAgirlik.TabIndex = 59;
            textBoxAgirlik.TextAlignment = HorizontalAlignment.Right;
            textBoxAgirlik.TextCustom = "0,000";
            textBoxAgirlik.UnderlinedStyle = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(56, 456);
            label10.Name = "label10";
            label10.Size = new Size(43, 15);
            label10.TabIndex = 58;
            label10.Text = "Ağırlık";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(56, 590);
            label11.Name = "label11";
            label11.Size = new Size(54, 15);
            label11.TabIndex = 60;
            label11.Text = "Dosyalar";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(126, 486);
            label12.Name = "label12";
            label12.Size = new Size(20, 15);
            label12.TabIndex = 61;
            label12.Text = "kg";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(241, 486);
            label13.Name = "label13";
            label13.Size = new Size(29, 15);
            label13.TabIndex = 62;
            label13.Text = "mm";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(359, 486);
            label22.Name = "label22";
            label22.Size = new Size(29, 15);
            label22.TabIndex = 63;
            label22.Text = "mm";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(472, 486);
            label25.Name = "label25";
            label25.Size = new Size(29, 15);
            label25.TabIndex = 64;
            label25.Text = "mm";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(595, 486);
            label26.Name = "label26";
            label26.Size = new Size(29, 15);
            label26.TabIndex = 65;
            label26.Text = "mm";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(712, 486);
            label27.Name = "label27";
            label27.Size = new Size(29, 15);
            label27.TabIndex = 66;
            label27.Text = "mm";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(841, 486);
            label28.Name = "label28";
            label28.Size = new Size(29, 15);
            label28.TabIndex = 67;
            label28.Text = "mm";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label29.Location = new Point(56, 360);
            label29.Name = "label29";
            label29.Size = new Size(40, 15);
            label29.TabIndex = 69;
            label29.Text = "Boyut";
            // 
            // textBoxBoyut
            // 
            textBoxBoyut.BackColor = Color.White;
            textBoxBoyut.BorderColor = Color.Silver;
            textBoxBoyut.BorderFocusColor = Color.HotPink;
            textBoxBoyut.BorderRadius = 5;
            textBoxBoyut.BorderSize = 1;
            textBoxBoyut.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxBoyut.ForeColor = Color.Black;
            textBoxBoyut.isPlaceHolder = false;
            textBoxBoyut.Location = new Point(186, 353);
            textBoxBoyut.Multiline = false;
            textBoxBoyut.Name = "textBoxBoyut";
            textBoxBoyut.Padding = new Padding(7, 5, 7, 5);
            textBoxBoyut.PasswordChar = false;
            textBoxBoyut.PlaceholderColor = Color.DarkGray;
            textBoxBoyut.PlaceholderText = "";
            textBoxBoyut.ReadOnly = false;
            textBoxBoyut.SelectionStart = 0;
            textBoxBoyut.Size = new Size(259, 28);
            textBoxBoyut.TabIndex = 68;
            textBoxBoyut.TextAlignment = HorizontalAlignment.Left;
            textBoxBoyut.TextCustom = "";
            textBoxBoyut.UnderlinedStyle = false;
            // 
            // checkBoxIsSatinalma
            // 
            checkBoxIsSatinalma.AutoSize = true;
            checkBoxIsSatinalma.Location = new Point(665, 313);
            checkBoxIsSatinalma.Name = "checkBoxIsSatinalma";
            checkBoxIsSatinalma.Size = new Size(15, 14);
            checkBoxIsSatinalma.TabIndex = 70;
            checkBoxIsSatinalma.UseVisualStyleBackColor = true;
            checkBoxIsSatinalma.Visible = false;
            // 
            // checkBoxIsPdf
            // 
            checkBoxIsPdf.AutoSize = true;
            checkBoxIsPdf.Location = new Point(686, 313);
            checkBoxIsPdf.Name = "checkBoxIsPdf";
            checkBoxIsPdf.Size = new Size(15, 14);
            checkBoxIsPdf.TabIndex = 71;
            checkBoxIsPdf.UseVisualStyleBackColor = true;
            checkBoxIsPdf.Visible = false;
            // 
            // checkBoxIsFromExcel
            // 
            checkBoxIsFromExcel.AutoSize = true;
            checkBoxIsFromExcel.Location = new Point(707, 313);
            checkBoxIsFromExcel.Name = "checkBoxIsFromExcel";
            checkBoxIsFromExcel.Size = new Size(15, 14);
            checkBoxIsFromExcel.TabIndex = 72;
            checkBoxIsFromExcel.UseVisualStyleBackColor = true;
            checkBoxIsFromExcel.Visible = false;
            // 
            // checkBoxIsStep
            // 
            checkBoxIsStep.AutoSize = true;
            checkBoxIsStep.Location = new Point(728, 313);
            checkBoxIsStep.Name = "checkBoxIsStep";
            checkBoxIsStep.Size = new Size(15, 14);
            checkBoxIsStep.TabIndex = 73;
            checkBoxIsStep.UseVisualStyleBackColor = true;
            checkBoxIsStep.Visible = false;
            // 
            // checkBoxIsDxf
            // 
            checkBoxIsDxf.AutoSize = true;
            checkBoxIsDxf.Location = new Point(755, 313);
            checkBoxIsDxf.Name = "checkBoxIsDxf";
            checkBoxIsDxf.Size = new Size(15, 14);
            checkBoxIsDxf.TabIndex = 74;
            checkBoxIsDxf.UseVisualStyleBackColor = true;
            checkBoxIsDxf.Visible = false;
            // 
            // StokKartKayitFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 822);
            Controls.Add(checkBoxIsDxf);
            Controls.Add(checkBoxIsStep);
            Controls.Add(checkBoxIsFromExcel);
            Controls.Add(checkBoxIsPdf);
            Controls.Add(checkBoxIsSatinalma);
            Controls.Add(label29);
            Controls.Add(textBoxBoyut);
            Controls.Add(label28);
            Controls.Add(label27);
            Controls.Add(label26);
            Controls.Add(label25);
            Controls.Add(label22);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(textBoxAgirlik);
            Controls.Add(label10);
            Controls.Add(panel1);
            Controls.Add(label24);
            Controls.Add(clbMalzemeAltGrup2);
            Controls.Add(label23);
            Controls.Add(clbMalzemeAltGrup);
            Controls.Add(rButtonKaydet);
            Controls.Add(label21);
            Controls.Add(clbStokTip);
            Controls.Add(label20);
            Controls.Add(textBoxAciklama);
            Controls.Add(textBoxEtKalinlik);
            Controls.Add(label19);
            Controls.Add(textBoxUzunluk);
            Controls.Add(label18);
            Controls.Add(textBoxCap);
            Controls.Add(label17);
            Controls.Add(textBoxYukseklik);
            Controls.Add(label16);
            Controls.Add(textBoxEn);
            Controls.Add(label15);
            Controls.Add(textBoxBoy);
            Controls.Add(label14);
            Controls.Add(label9);
            Controls.Add(comboListBoxProjeKod);
            Controls.Add(label8);
            Controls.Add(comboListBoxOlcuBirim);
            Controls.Add(label7);
            Controls.Add(clbMalzemeGrup);
            Controls.Add(label6);
            Controls.Add(comboListBoxMalzemeStandart);
            Controls.Add(label5);
            Controls.Add(clbStokGrup);
            Controls.Add(label4);
            Controls.Add(ctbStokAd);
            Controls.Add(label3);
            Controls.Add(textBoxLogoKod);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelHeader);
            Controls.Add(textBoxkod);
            Controls.Add(textBoxId);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StokKartKayitFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StokKartTanimlamaFormu";
            Load += StokKartTanimlamaFormu_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.CustomTextBox textBoxId;
        private CustomControls.CustomTextBox textBoxkod;
        private CustomControls.RoundedButton roundedButton2;
        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton roundedButton3;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.RoundedButton btnClose;
        private CustomControls.RoundedButton btnMinimize;
        private CustomControls.RoundedButton bntHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomTextBox textBoxLogoKod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBox ctbStokAd;
        private CustomControls.CustomComboListBox clbStokGrup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CustomControls.CustomComboListBox comboListBoxMalzemeStandart;
        private System.Windows.Forms.Label label7;
        private CustomControls.CustomComboListBox clbMalzemeGrup;
        private System.Windows.Forms.Label label8;
        private CustomControls.CustomComboListBox comboListBoxOlcuBirim;
        private System.Windows.Forms.Label label9;
        private CustomControls.CustomComboListBox comboListBoxProjeKod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private CustomControls.CustomTextBoxSayisal textBoxBoy;
        private CustomControls.CustomTextBoxSayisal textBoxEn;
        private System.Windows.Forms.Label label15;
        private CustomControls.CustomTextBoxSayisal textBoxYukseklik;
        private System.Windows.Forms.Label label16;
        private CustomControls.CustomTextBoxSayisal textBoxCap;
        private System.Windows.Forms.Label label17;
        private CustomControls.CustomTextBoxSayisal textBoxUzunluk;
        private System.Windows.Forms.Label label18;
        private CustomControls.CustomTextBoxSayisal textBoxEtKalinlik;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private CustomControls.CustomTextBox textBoxAciklama;
        private System.Windows.Forms.Label label21;
        private CustomControls.CustomComboListBox clbStokTip;
        private CustomControls.RoundedButton rButtonKaydet;
        private System.Windows.Forms.Label label23;
        private CustomControls.CustomComboListBox clbMalzemeAltGrup;
        private System.Windows.Forms.Label label24;
        private CustomControls.CustomComboListBox clbMalzemeAltGrup2;
        CustomDataGrid<DataControlStokKartDosyalar> customDataGrid;
        public class DataControlStokKartDosyalar : Abstracts.DataControl, IEntity
        {
            private CustomTextBox _Id;
            public CustomTextBox Id { get { if (_Id == null) _Id = new(); return _Id; } set { _Id = value; } }
            private CustomTextBox _stokKartId;
            public CustomTextBox stokKartId { get { if (_stokKartId == null) _stokKartId = new(); return _stokKartId; } set { _stokKartId = value; } }
            private CustomComboListBox _dosyaTip;
            public CustomComboListBox dosyaTip { get { if (_dosyaTip == null) { _dosyaTip = new(); } return _dosyaTip; } set { _dosyaTip = value; } }
            private CustomTextBox _dosyaAd;
            public CustomTextBox dosyaAd { get { if (_dosyaAd == null) _dosyaAd = new(); return _dosyaAd; } set { _dosyaAd = value; } }
            private CustomTextBox _dosyaUzanti;
            public CustomTextBox dosyaUzanti { get { if (_dosyaUzanti == null) _dosyaUzanti = new(); return _dosyaUzanti; } set { _dosyaUzanti = value; } }

            private byte[] _dosyaVeri;
            public byte[] dosyaVeri { get { return _dosyaVeri; } set { _dosyaVeri = value; } }

            private RoundedButton _iconButton;
            public RoundedButton iconButton { get { if (_iconButton == null) { _iconButton = new(); } return _iconButton; } set { _iconButton = value; } }
            private RoundedButton _iconButtonView;
            public RoundedButton iconButtonView { get { if (_iconButtonView == null) { _iconButtonView = new(); } return _iconButtonView; } set { _iconButtonView = value; } }
            public DataControlStokKartDosyalar()
            {
                Id = new() { TabIndex = 1, Width = 0, Visible = false, Tag = "Id" };
                stokKartId = new() { TabIndex = 2, Width = 0, Visible = false, Tag = "StokKartId" };
                dosyaTip = new() { TabIndex = 3, Width = 60, Visible = true, Tag = "DosyaTip" };
                dosyaAd = new() { TabIndex = 4, Width = 250, Tag = "Dosya Adı" };
                dosyaUzanti = new() { TabIndex = 5, Width = 50, Tag = "Dosya Uzantı" };
                iconButton = new() { TabIndex = 6, Width = 35, Height = 28, Tag = " Ekle", BackgroundImage = Resources.ekle, BackColor = Color.Transparent, BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom };
                iconButton.Click += ButtonDosyaEkle_Click;
                iconButtonView = new() { TabIndex = 7, Width = 35, Height = 28, Tag = "Göster", BackgroundImage = Resources.pngegg, BackColor = Color.Transparent, BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom };
                iconButtonView.Click += ButtonDosyaGoruntule_Click;
                dosyaVeri = new byte[0];
                ComboBoxListFill.GetLookupAd(_cache.dosyaTipList, ref _dosyaTip);
            }
            private void ButtonDosyaEkle_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dosyaVeri = File.ReadAllBytes(openFileDialog.FileName);
                    dosyaAd.TextCustom = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    dosyaUzanti.TextCustom = Path.GetExtension(openFileDialog.FileName).Replace(".", "");
                }
            }
            private void ButtonDosyaGoruntule_Click(object sender, EventArgs e)
            {
                string tempFilePath = Path.GetTempFileName() + "." + dosyaUzanti.TextCustom;
                if (dosyaVeri != null)
                {
                    using (MemoryStream ms = new MemoryStream(dosyaVeri))
                    {
                        File.WriteAllBytes(tempFilePath, ms.ToArray());
                        Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
                    }
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı.");
                }
            }
        }

        private System.Windows.Forms.Panel panel1;
        private CustomTextBoxSayisal textBoxAgirlik;
        private Label label10;
        private Label label12;
        private Label label13;
        private Label label22;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private CustomTextBox textBoxBoyut;
        private CheckBox checkBoxIsSatinalma;
        private CheckBox checkBoxIsPdf;
        private CheckBox checkBoxIsFromExcel;
        private CheckBox checkBoxIsStep;
        private CheckBox checkBoxIsDxf;
    }
}