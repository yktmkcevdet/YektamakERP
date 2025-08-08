using ApiService.Implementetions;
using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Properties;
using static YektamakDesktop.Formlar.Satis.SatisTeklifMaliyetKayitFormu;
using static YektamakDesktop.Formlar.Stok.StokKartKayitFormu;

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
            ctbId = new CustomTextBox();
            ctbKod = new CustomTextBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            ctbStokAd = new CustomTextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label14 = new Label();
            ctbBoy = new CustomTextBoxSayisal();
            ctbEn = new CustomTextBoxSayisal();
            label15 = new Label();
            ctbYukseklik = new CustomTextBoxSayisal();
            label16 = new Label();
            ctbCap = new CustomTextBoxSayisal();
            label17 = new Label();
            ctbUzunluk = new CustomTextBoxSayisal();
            label18 = new Label();
            ctbEtKalinlik = new CustomTextBoxSayisal();
            label19 = new Label();
            label20 = new Label();
            ctbAciklama = new CustomTextBox();
            label21 = new Label();
            label23 = new Label();
            label24 = new Label();
            panel1 = new Panel();
            ctbAgirlik = new CustomTextBoxSayisal();
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
            ctbBoyut = new CustomTextBox();
            checkBoxIsSatinalma = new CheckBox();
            checkBoxIsPdf = new CheckBox();
            checkBoxIsFromExcel = new CheckBox();
            checkBoxIsStep = new CheckBox();
            checkBoxIsDxf = new CheckBox();
            headerPanel1 = new HeaderPanel();
            rButtonKaydet = new CustomButtonSave();
            clbProjeKod = new FilterableComboBox();
            clbStokTip = new FilterableComboBox();
            clbOlcuBirim = new FilterableComboBox();
            clbMalzemeStandart = new FilterableComboBox();
            clbStokGrup = new FilterableComboBox();
            clbMalzemeGrup = new FilterableComboBox();
            clbMalzemeAltGrup = new FilterableComboBox();
            clbMalzemeAltGrup2 = new FilterableComboBox();
            ctbProjeAdet = new CustomTextBoxSayisal();
            label3 = new Label();
            SuspendLayout();
            // 
            // ctbId
            // 
            ctbId.BackColor = Color.White;
            ctbId.BorderColor = Color.Silver;
            ctbId.BorderFocusColor = Color.HotPink;
            ctbId.BorderRadius = 5;
            ctbId.BorderSize = 1;
            ctbId.Enabled = false;
            ctbId.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbId.ForeColor = Color.Black;
            ctbId.isPlaceHolder = false;
            ctbId.Location = new Point(186, 61);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new Padding(7, 5, 7, 5);
            ctbId.PasswordChar = false;
            ctbId.PlaceholderColor = Color.DarkGray;
            ctbId.PlaceholderText = "";
            ctbId.ReadOnly = false;
            ctbId.SelectionStart = 0;
            ctbId.Size = new Size(94, 28);
            ctbId.TabIndex = 0;
            ctbId.TextAlignment = HorizontalAlignment.Left;
            ctbId.TextCustom = "";
            ctbId.UnderlinedStyle = false;
            // 
            // ctbKod
            // 
            ctbKod.BackColor = Color.White;
            ctbKod.BorderColor = Color.Silver;
            ctbKod.BorderFocusColor = Color.HotPink;
            ctbKod.BorderRadius = 5;
            ctbKod.BorderSize = 1;
            ctbKod.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbKod.ForeColor = Color.Black;
            ctbKod.isPlaceHolder = false;
            ctbKod.Location = new Point(186, 172);
            ctbKod.Multiline = false;
            ctbKod.Name = "ctbKod";
            ctbKod.Padding = new Padding(7, 5, 7, 5);
            ctbKod.PasswordChar = false;
            ctbKod.PlaceholderColor = Color.DarkGray;
            ctbKod.PlaceholderText = "";
            ctbKod.ReadOnly = false;
            ctbKod.SelectionStart = 0;
            ctbKod.Size = new Size(259, 28);
            ctbKod.TabIndex = 1;
            ctbKod.TextAlignment = HorizontalAlignment.Left;
            ctbKod.TextCustom = "";
            ctbKod.UnderlinedStyle = false;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(56, 215);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 14;
            label4.Text = "Stok Adı";
            // 
            // ctbStokAd
            // 
            ctbStokAd.BackColor = Color.White;
            ctbStokAd.BorderColor = Color.Silver;
            ctbStokAd.BorderFocusColor = Color.HotPink;
            ctbStokAd.BorderRadius = 5;
            ctbStokAd.BorderSize = 1;
            ctbStokAd.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbStokAd.ForeColor = Color.Black;
            ctbStokAd.isPlaceHolder = false;
            ctbStokAd.Location = new Point(186, 208);
            ctbStokAd.Multiline = false;
            ctbStokAd.Name = "ctbStokAd";
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(56, 366);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 16;
            label5.Text = "Stok Grubu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(56, 283);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 18;
            label6.Text = "Malzme Std.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(262, 366);
            label7.Name = "label7";
            label7.Size = new Size(96, 15);
            label7.TabIndex = 20;
            label7.Text = "Malzeme Grubu";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(54, 248);
            label8.Name = "label8";
            label8.Size = new Size(68, 15);
            label8.TabIndex = 22;
            label8.Text = "Ölçü Birimi";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(54, 101);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 24;
            label9.Text = "Proje Kodu";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(166, 424);
            label14.Name = "label14";
            label14.Size = new Size(28, 15);
            label14.TabIndex = 34;
            label14.Text = "Boy";
            // 
            // ctbBoy
            // 
            ctbBoy.BackColor = Color.White;
            ctbBoy.BorderColor = Color.Silver;
            ctbBoy.BorderFocusColor = Color.HotPink;
            ctbBoy.BorderRadius = 5;
            ctbBoy.BorderSize = 1;
            ctbBoy.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbBoy.ForeColor = Color.Black;
            ctbBoy.Location = new Point(166, 442);
            ctbBoy.Multiline = false;
            ctbBoy.Name = "ctbBoy";
            ctbBoy.OndalikBasamak = 0;
            ctbBoy.Padding = new Padding(10, 7, 10, 7);
            ctbBoy.PasswordChar = false;
            ctbBoy.PlaceholderColor = Color.DarkGray;
            ctbBoy.PlaceholderText = "";
            ctbBoy.ReadOnly = false;
            ctbBoy.SelectionStart = 0;
            ctbBoy.Size = new Size(75, 32);
            ctbBoy.TabIndex = 35;
            ctbBoy.TextAlignment = HorizontalAlignment.Right;
            ctbBoy.TextCustom = "0";
            ctbBoy.UnderlinedStyle = false;
            // 
            // ctbEn
            // 
            ctbEn.BackColor = Color.White;
            ctbEn.BorderColor = Color.Silver;
            ctbEn.BorderFocusColor = Color.HotPink;
            ctbEn.BorderRadius = 5;
            ctbEn.BorderSize = 1;
            ctbEn.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbEn.ForeColor = Color.Black;
            ctbEn.Location = new Point(287, 442);
            ctbEn.Multiline = false;
            ctbEn.Name = "ctbEn";
            ctbEn.OndalikBasamak = 0;
            ctbEn.Padding = new Padding(10, 7, 10, 7);
            ctbEn.PasswordChar = false;
            ctbEn.PlaceholderColor = Color.DarkGray;
            ctbEn.PlaceholderText = "";
            ctbEn.ReadOnly = false;
            ctbEn.SelectionStart = 0;
            ctbEn.Size = new Size(71, 32);
            ctbEn.TabIndex = 37;
            ctbEn.TextAlignment = HorizontalAlignment.Right;
            ctbEn.TextCustom = "0";
            ctbEn.UnderlinedStyle = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(287, 424);
            label15.Name = "label15";
            label15.Size = new Size(20, 15);
            label15.TabIndex = 36;
            label15.Text = "En";
            // 
            // ctbYukseklik
            // 
            ctbYukseklik.BackColor = Color.White;
            ctbYukseklik.BorderColor = Color.Silver;
            ctbYukseklik.BorderFocusColor = Color.HotPink;
            ctbYukseklik.BorderRadius = 5;
            ctbYukseklik.BorderSize = 1;
            ctbYukseklik.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbYukseklik.ForeColor = Color.Black;
            ctbYukseklik.Location = new Point(404, 442);
            ctbYukseklik.Multiline = false;
            ctbYukseklik.Name = "ctbYukseklik";
            ctbYukseklik.OndalikBasamak = 0;
            ctbYukseklik.Padding = new Padding(10, 7, 10, 7);
            ctbYukseklik.PasswordChar = false;
            ctbYukseklik.PlaceholderColor = Color.DarkGray;
            ctbYukseklik.PlaceholderText = "";
            ctbYukseklik.ReadOnly = false;
            ctbYukseklik.SelectionStart = 0;
            ctbYukseklik.Size = new Size(67, 32);
            ctbYukseklik.TabIndex = 39;
            ctbYukseklik.TextAlignment = HorizontalAlignment.Right;
            ctbYukseklik.TextCustom = "0";
            ctbYukseklik.UnderlinedStyle = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(404, 424);
            label16.Name = "label16";
            label16.Size = new Size(59, 15);
            label16.TabIndex = 38;
            label16.Text = "Yükseklik";
            // 
            // ctbCap
            // 
            ctbCap.BackColor = Color.White;
            ctbCap.BorderColor = Color.Silver;
            ctbCap.BorderFocusColor = Color.HotPink;
            ctbCap.BorderRadius = 5;
            ctbCap.BorderSize = 1;
            ctbCap.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbCap.ForeColor = Color.Black;
            ctbCap.Location = new Point(521, 442);
            ctbCap.Multiline = false;
            ctbCap.Name = "ctbCap";
            ctbCap.OndalikBasamak = 0;
            ctbCap.Padding = new Padding(10, 7, 10, 7);
            ctbCap.PasswordChar = false;
            ctbCap.PlaceholderColor = Color.DarkGray;
            ctbCap.PlaceholderText = "";
            ctbCap.ReadOnly = false;
            ctbCap.SelectionStart = 0;
            ctbCap.Size = new Size(73, 32);
            ctbCap.TabIndex = 41;
            ctbCap.TextAlignment = HorizontalAlignment.Right;
            ctbCap.TextCustom = "0";
            ctbCap.UnderlinedStyle = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(521, 424);
            label17.Name = "label17";
            label17.Size = new Size(27, 15);
            label17.TabIndex = 40;
            label17.Text = "Çap";
            // 
            // ctbUzunluk
            // 
            ctbUzunluk.BackColor = Color.White;
            ctbUzunluk.BorderColor = Color.Silver;
            ctbUzunluk.BorderFocusColor = Color.HotPink;
            ctbUzunluk.BorderRadius = 5;
            ctbUzunluk.BorderSize = 1;
            ctbUzunluk.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbUzunluk.ForeColor = Color.Black;
            ctbUzunluk.Location = new Point(644, 442);
            ctbUzunluk.Multiline = false;
            ctbUzunluk.Name = "ctbUzunluk";
            ctbUzunluk.OndalikBasamak = 0;
            ctbUzunluk.Padding = new Padding(10, 7, 10, 7);
            ctbUzunluk.PasswordChar = false;
            ctbUzunluk.PlaceholderColor = Color.DarkGray;
            ctbUzunluk.PlaceholderText = "";
            ctbUzunluk.ReadOnly = false;
            ctbUzunluk.SelectionStart = 0;
            ctbUzunluk.Size = new Size(67, 32);
            ctbUzunluk.TabIndex = 43;
            ctbUzunluk.TextAlignment = HorizontalAlignment.Right;
            ctbUzunluk.TextCustom = "0";
            ctbUzunluk.UnderlinedStyle = false;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(644, 424);
            label18.Name = "label18";
            label18.Size = new Size(53, 15);
            label18.TabIndex = 42;
            label18.Text = "Uzunluk";
            // 
            // ctbEtKalinlik
            // 
            ctbEtKalinlik.BackColor = Color.White;
            ctbEtKalinlik.BorderColor = Color.Silver;
            ctbEtKalinlik.BorderFocusColor = Color.HotPink;
            ctbEtKalinlik.BorderRadius = 5;
            ctbEtKalinlik.BorderSize = 1;
            ctbEtKalinlik.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbEtKalinlik.ForeColor = Color.Black;
            ctbEtKalinlik.Location = new Point(769, 442);
            ctbEtKalinlik.Multiline = false;
            ctbEtKalinlik.Name = "ctbEtKalinlik";
            ctbEtKalinlik.OndalikBasamak = 0;
            ctbEtKalinlik.Padding = new Padding(10, 7, 10, 7);
            ctbEtKalinlik.PasswordChar = false;
            ctbEtKalinlik.PlaceholderColor = Color.DarkGray;
            ctbEtKalinlik.PlaceholderText = "";
            ctbEtKalinlik.ReadOnly = false;
            ctbEtKalinlik.SelectionStart = 0;
            ctbEtKalinlik.Size = new Size(72, 32);
            ctbEtKalinlik.TabIndex = 45;
            ctbEtKalinlik.TextAlignment = HorizontalAlignment.Right;
            ctbEtKalinlik.TextCustom = "0";
            ctbEtKalinlik.UnderlinedStyle = false;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label19.Location = new Point(769, 424);
            label19.Name = "label19";
            label19.Size = new Size(64, 15);
            label19.TabIndex = 44;
            label19.Text = "Et Kalınlığı";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label20.Location = new Point(56, 498);
            label20.Name = "label20";
            label20.Size = new Size(57, 15);
            label20.TabIndex = 47;
            label20.Text = "Açıklama";
            // 
            // ctbAciklama
            // 
            ctbAciklama.BackColor = Color.White;
            ctbAciklama.BorderColor = Color.Silver;
            ctbAciklama.BorderFocusColor = Color.HotPink;
            ctbAciklama.BorderRadius = 5;
            ctbAciklama.BorderSize = 1;
            ctbAciklama.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbAciklama.ForeColor = Color.Black;
            ctbAciklama.isPlaceHolder = false;
            ctbAciklama.Location = new Point(186, 491);
            ctbAciklama.Multiline = false;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new Padding(7, 5, 7, 5);
            ctbAciklama.PasswordChar = false;
            ctbAciklama.PlaceholderColor = Color.DarkGray;
            ctbAciklama.PlaceholderText = "";
            ctbAciklama.ReadOnly = false;
            ctbAciklama.SelectionStart = 0;
            ctbAciklama.Size = new Size(845, 28);
            ctbAciklama.TabIndex = 46;
            ctbAciklama.TextAlignment = HorizontalAlignment.Left;
            ctbAciklama.TextCustom = "";
            ctbAciklama.UnderlinedStyle = false;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label21.Location = new Point(56, 136);
            label21.Name = "label21";
            label21.Size = new Size(56, 15);
            label21.TabIndex = 49;
            label21.Text = "Stok Tipi";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label23.Location = new Point(519, 366);
            label23.Name = "label23";
            label23.Size = new Size(115, 15);
            label23.TabIndex = 54;
            label23.Text = "Malzeme Alt Grubu";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label24.Location = new Point(766, 366);
            label24.Name = "label24";
            label24.Size = new Size(125, 15);
            label24.TabIndex = 56;
            label24.Text = "Malzeme Alt Grubu 2";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(56, 576);
            panel1.Name = "panel1";
            panel1.Size = new Size(826, 191);
            panel1.TabIndex = 57;
            // 
            // ctbAgirlik
            // 
            ctbAgirlik.BackColor = Color.White;
            ctbAgirlik.BorderColor = Color.Silver;
            ctbAgirlik.BorderFocusColor = Color.HotPink;
            ctbAgirlik.BorderRadius = 5;
            ctbAgirlik.BorderSize = 1;
            ctbAgirlik.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbAgirlik.ForeColor = Color.Black;
            ctbAgirlik.Location = new Point(56, 442);
            ctbAgirlik.Multiline = false;
            ctbAgirlik.Name = "ctbAgirlik";
            ctbAgirlik.OndalikBasamak = 3;
            ctbAgirlik.Padding = new Padding(10, 7, 10, 7);
            ctbAgirlik.PasswordChar = false;
            ctbAgirlik.PlaceholderColor = Color.DarkGray;
            ctbAgirlik.PlaceholderText = "";
            ctbAgirlik.ReadOnly = false;
            ctbAgirlik.SelectionStart = 0;
            ctbAgirlik.Size = new Size(69, 32);
            ctbAgirlik.TabIndex = 59;
            ctbAgirlik.TextAlignment = HorizontalAlignment.Right;
            ctbAgirlik.TextCustom = "0,000";
            ctbAgirlik.UnderlinedStyle = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(56, 424);
            label10.Name = "label10";
            label10.Size = new Size(43, 15);
            label10.TabIndex = 58;
            label10.Text = "Ağırlık";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(56, 558);
            label11.Name = "label11";
            label11.Size = new Size(54, 15);
            label11.TabIndex = 60;
            label11.Text = "Dosyalar";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(126, 454);
            label12.Name = "label12";
            label12.Size = new Size(20, 15);
            label12.TabIndex = 61;
            label12.Text = "kg";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(241, 454);
            label13.Name = "label13";
            label13.Size = new Size(29, 15);
            label13.TabIndex = 62;
            label13.Text = "mm";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(359, 454);
            label22.Name = "label22";
            label22.Size = new Size(29, 15);
            label22.TabIndex = 63;
            label22.Text = "mm";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(472, 454);
            label25.Name = "label25";
            label25.Size = new Size(29, 15);
            label25.TabIndex = 64;
            label25.Text = "mm";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(595, 454);
            label26.Name = "label26";
            label26.Size = new Size(29, 15);
            label26.TabIndex = 65;
            label26.Text = "mm";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(712, 454);
            label27.Name = "label27";
            label27.Size = new Size(29, 15);
            label27.TabIndex = 66;
            label27.Text = "mm";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(841, 454);
            label28.Name = "label28";
            label28.Size = new Size(29, 15);
            label28.TabIndex = 67;
            label28.Text = "mm";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label29.Location = new Point(56, 328);
            label29.Name = "label29";
            label29.Size = new Size(40, 15);
            label29.TabIndex = 69;
            label29.Text = "Boyut";
            // 
            // ctbBoyut
            // 
            ctbBoyut.BackColor = Color.White;
            ctbBoyut.BorderColor = Color.Silver;
            ctbBoyut.BorderFocusColor = Color.HotPink;
            ctbBoyut.BorderRadius = 5;
            ctbBoyut.BorderSize = 1;
            ctbBoyut.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbBoyut.ForeColor = Color.Black;
            ctbBoyut.isPlaceHolder = false;
            ctbBoyut.Location = new Point(186, 321);
            ctbBoyut.Multiline = false;
            ctbBoyut.Name = "ctbBoyut";
            ctbBoyut.Padding = new Padding(7, 5, 7, 5);
            ctbBoyut.PasswordChar = false;
            ctbBoyut.PlaceholderColor = Color.DarkGray;
            ctbBoyut.PlaceholderText = "";
            ctbBoyut.ReadOnly = false;
            ctbBoyut.SelectionStart = 0;
            ctbBoyut.Size = new Size(259, 28);
            ctbBoyut.TabIndex = 68;
            ctbBoyut.TextAlignment = HorizontalAlignment.Left;
            ctbBoyut.TextCustom = "";
            ctbBoyut.UnderlinedStyle = false;
            // 
            // checkBoxIsSatinalma
            // 
            checkBoxIsSatinalma.AutoSize = true;
            checkBoxIsSatinalma.Location = new Point(665, 281);
            checkBoxIsSatinalma.Name = "checkBoxIsSatinalma";
            checkBoxIsSatinalma.Size = new Size(15, 14);
            checkBoxIsSatinalma.TabIndex = 70;
            checkBoxIsSatinalma.UseVisualStyleBackColor = true;
            checkBoxIsSatinalma.Visible = false;
            // 
            // checkBoxIsPdf
            // 
            checkBoxIsPdf.AutoSize = true;
            checkBoxIsPdf.Location = new Point(686, 281);
            checkBoxIsPdf.Name = "checkBoxIsPdf";
            checkBoxIsPdf.Size = new Size(15, 14);
            checkBoxIsPdf.TabIndex = 71;
            checkBoxIsPdf.UseVisualStyleBackColor = true;
            checkBoxIsPdf.Visible = false;
            // 
            // checkBoxIsFromExcel
            // 
            checkBoxIsFromExcel.AutoSize = true;
            checkBoxIsFromExcel.Location = new Point(707, 281);
            checkBoxIsFromExcel.Name = "checkBoxIsFromExcel";
            checkBoxIsFromExcel.Size = new Size(15, 14);
            checkBoxIsFromExcel.TabIndex = 72;
            checkBoxIsFromExcel.UseVisualStyleBackColor = true;
            checkBoxIsFromExcel.Visible = false;
            // 
            // checkBoxIsStep
            // 
            checkBoxIsStep.AutoSize = true;
            checkBoxIsStep.Location = new Point(728, 281);
            checkBoxIsStep.Name = "checkBoxIsStep";
            checkBoxIsStep.Size = new Size(15, 14);
            checkBoxIsStep.TabIndex = 73;
            checkBoxIsStep.UseVisualStyleBackColor = true;
            checkBoxIsStep.Visible = false;
            // 
            // checkBoxIsDxf
            // 
            checkBoxIsDxf.AutoSize = true;
            checkBoxIsDxf.Location = new Point(755, 281);
            checkBoxIsDxf.Name = "checkBoxIsDxf";
            checkBoxIsDxf.Size = new Size(15, 14);
            checkBoxIsDxf.TabIndex = 74;
            checkBoxIsDxf.UseVisualStyleBackColor = true;
            checkBoxIsDxf.Visible = false;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = Color.Firebrick;
            headerPanel1.Baslik = "Stok Kart Tanımlama";
            headerPanel1.Location = new Point(0, 0);
            headerPanel1.Margin = new Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new Padding(1);
            headerPanel1.Size = new Size(1040, 32);
            headerPanel1.TabIndex = 75;
            // 
            // rButtonKaydet
            // 
            rButtonKaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            rButtonKaydet.BackColor = Color.Transparent;
            rButtonKaydet.Location = new Point(922, 721);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new Size(106, 46);
            rButtonKaydet.TabIndex = 76;
            rButtonKaydet.SaveButtonClick += rButtonKaydet_Click;
            // 
            // clbProjeKod
            // 
            clbProjeKod.BorderColor = Color.Silver;
            clbProjeKod.BorderSize = 1;
            clbProjeKod.DataSource = null;
            clbProjeKod.DisplayMember = "kod";
            clbProjeKod.Location = new Point(186, 95);
            clbProjeKod.Name = "clbProjeKod";
            clbProjeKod.Padding = new Padding(7, 5, 7, 5);
            clbProjeKod.PlaceholderText = "Seçiniz...";
            clbProjeKod.SelectedIndex = -1;
            clbProjeKod.SelectedItem = null;
            clbProjeKod.SelectedValue = null;
            clbProjeKod.Size = new Size(161, 29);
            clbProjeKod.TabIndex = 77;
            clbProjeKod.UnderlinedStyle = false;
            clbProjeKod.ValueMember = "Id";
            // 
            // clbStokTip
            // 
            clbStokTip.BorderColor = Color.Silver;
            clbStokTip.BorderSize = 1;
            clbStokTip.DataSource = null;
            clbStokTip.DisplayMember = "kod";
            clbStokTip.Location = new Point(186, 130);
            clbStokTip.Name = "clbStokTip";
            clbStokTip.Padding = new Padding(7, 5, 7, 5);
            clbStokTip.PlaceholderText = "Seçiniz...";
            clbStokTip.SelectedIndex = -1;
            clbStokTip.SelectedItem = null;
            clbStokTip.SelectedValue = null;
            clbStokTip.Size = new Size(161, 29);
            clbStokTip.TabIndex = 78;
            clbStokTip.UnderlinedStyle = false;
            clbStokTip.ValueMember = "Id";
            // 
            // clbOlcuBirim
            // 
            clbOlcuBirim.BorderColor = Color.Silver;
            clbOlcuBirim.BorderSize = 1;
            clbOlcuBirim.DataSource = null;
            clbOlcuBirim.DisplayMember = "ad";
            clbOlcuBirim.Location = new Point(188, 242);
            clbOlcuBirim.Name = "clbOlcuBirim";
            clbOlcuBirim.Padding = new Padding(7, 5, 7, 5);
            clbOlcuBirim.PlaceholderText = "Seçiniz...";
            clbOlcuBirim.SelectedIndex = -1;
            clbOlcuBirim.SelectedItem = null;
            clbOlcuBirim.SelectedValue = null;
            clbOlcuBirim.Size = new Size(119, 29);
            clbOlcuBirim.TabIndex = 79;
            clbOlcuBirim.UnderlinedStyle = false;
            clbOlcuBirim.ValueMember = "Id";
            // 
            // clbMalzemeStandart
            // 
            clbMalzemeStandart.BorderColor = Color.Silver;
            clbMalzemeStandart.BorderSize = 1;
            clbMalzemeStandart.DataSource = null;
            clbMalzemeStandart.DisplayMember = "ad";
            clbMalzemeStandart.Location = new Point(188, 277);
            clbMalzemeStandart.Name = "clbMalzemeStandart";
            clbMalzemeStandart.Padding = new Padding(7, 5, 7, 5);
            clbMalzemeStandart.PlaceholderText = "Seçiniz...";
            clbMalzemeStandart.SelectedIndex = -1;
            clbMalzemeStandart.SelectedItem = null;
            clbMalzemeStandart.SelectedValue = null;
            clbMalzemeStandart.Size = new Size(200, 29);
            clbMalzemeStandart.TabIndex = 80;
            clbMalzemeStandart.UnderlinedStyle = false;
            clbMalzemeStandart.ValueMember = "Id";
            // 
            // clbStokGrup
            // 
            clbStokGrup.BorderColor = Color.Silver;
            clbStokGrup.BorderSize = 1;
            clbStokGrup.DataSource = null;
            clbStokGrup.DisplayMember = "ad";
            clbStokGrup.Location = new Point(56, 390);
            clbStokGrup.Name = "clbStokGrup";
            clbStokGrup.Padding = new Padding(7, 5, 7, 5);
            clbStokGrup.PlaceholderText = "Seçiniz...";
            clbStokGrup.SelectedIndex = -1;
            clbStokGrup.SelectedItem = null;
            clbStokGrup.SelectedValue = null;
            clbStokGrup.Size = new Size(185, 29);
            clbStokGrup.TabIndex = 81;
            clbStokGrup.UnderlinedStyle = false;
            clbStokGrup.ValueMember = "Id";
            clbStokGrup.SelectedIndexChanged += cbxStokGrup_SelectedIndexChanged;
            // 
            // clbMalzemeGrup
            // 
            clbMalzemeGrup.BorderColor = Color.Silver;
            clbMalzemeGrup.BorderSize = 1;
            clbMalzemeGrup.DataSource = null;
            clbMalzemeGrup.DisplayMember = "ad";
            clbMalzemeGrup.Location = new Point(262, 390);
            clbMalzemeGrup.Name = "clbMalzemeGrup";
            clbMalzemeGrup.Padding = new Padding(7, 5, 7, 5);
            clbMalzemeGrup.PlaceholderText = "Seçiniz...";
            clbMalzemeGrup.SelectedIndex = -1;
            clbMalzemeGrup.SelectedItem = null;
            clbMalzemeGrup.SelectedValue = null;
            clbMalzemeGrup.Size = new Size(209, 29);
            clbMalzemeGrup.TabIndex = 82;
            clbMalzemeGrup.UnderlinedStyle = false;
            clbMalzemeGrup.ValueMember = "Id";
            clbMalzemeGrup.SelectedIndexChanged += cbxMalzemeGrup_SelectedIndexChanged;
            // 
            // clbMalzemeAltGrup
            // 
            clbMalzemeAltGrup.BorderColor = Color.Silver;
            clbMalzemeAltGrup.BorderSize = 1;
            clbMalzemeAltGrup.DataSource = null;
            clbMalzemeAltGrup.DisplayMember = "ad";
            clbMalzemeAltGrup.Location = new Point(519, 390);
            clbMalzemeAltGrup.Name = "clbMalzemeAltGrup";
            clbMalzemeAltGrup.Padding = new Padding(7, 5, 7, 5);
            clbMalzemeAltGrup.PlaceholderText = "Seçiniz...";
            clbMalzemeAltGrup.SelectedIndex = -1;
            clbMalzemeAltGrup.SelectedItem = null;
            clbMalzemeAltGrup.SelectedValue = null;
            clbMalzemeAltGrup.Size = new Size(222, 29);
            clbMalzemeAltGrup.TabIndex = 83;
            clbMalzemeAltGrup.UnderlinedStyle = false;
            clbMalzemeAltGrup.ValueMember = "Id";
            clbMalzemeAltGrup.SelectedIndexChanged += cbxMalzemeAltGrup_SelectedIndexChanged;
            // 
            // clbMalzemeAltGrup2
            // 
            clbMalzemeAltGrup2.BorderColor = Color.Silver;
            clbMalzemeAltGrup2.BorderSize = 1;
            clbMalzemeAltGrup2.DataSource = null;
            clbMalzemeAltGrup2.DisplayMember = "ad";
            clbMalzemeAltGrup2.Location = new Point(766, 390);
            clbMalzemeAltGrup2.Name = "clbMalzemeAltGrup2";
            clbMalzemeAltGrup2.Padding = new Padding(7, 5, 7, 5);
            clbMalzemeAltGrup2.PlaceholderText = "Seçiniz...";
            clbMalzemeAltGrup2.SelectedIndex = -1;
            clbMalzemeAltGrup2.SelectedItem = null;
            clbMalzemeAltGrup2.SelectedValue = null;
            clbMalzemeAltGrup2.Size = new Size(245, 29);
            clbMalzemeAltGrup2.TabIndex = 84;
            clbMalzemeAltGrup2.UnderlinedStyle = false;
            clbMalzemeAltGrup2.ValueMember = "Id";
            // 
            // ctbProjeAdet
            // 
            ctbProjeAdet.BackColor = SystemColors.Window;
            ctbProjeAdet.BorderColor = Color.Silver;
            ctbProjeAdet.BorderFocusColor = Color.HotPink;
            ctbProjeAdet.BorderRadius = 5;
            ctbProjeAdet.BorderSize = 1;
            ctbProjeAdet.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ctbProjeAdet.ForeColor = Color.DimGray;
            ctbProjeAdet.Location = new Point(570, 98);
            ctbProjeAdet.Multiline = false;
            ctbProjeAdet.Name = "ctbProjeAdet";
            ctbProjeAdet.OndalikBasamak = 0;
            ctbProjeAdet.Padding = new Padding(7, 5, 7, 5);
            ctbProjeAdet.PasswordChar = false;
            ctbProjeAdet.PlaceholderColor = Color.DarkGray;
            ctbProjeAdet.PlaceholderText = "";
            ctbProjeAdet.ReadOnly = false;
            ctbProjeAdet.SelectionStart = 0;
            ctbProjeAdet.Size = new Size(92, 26);
            ctbProjeAdet.TabIndex = 85;
            ctbProjeAdet.TextAlignment = HorizontalAlignment.Right;
            ctbProjeAdet.TextCustom = "0";
            ctbProjeAdet.UnderlinedStyle = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(433, 101);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 86;
            label3.Text = "Proje Adet";
            // 
            // StokKartKayitFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 822);
            Controls.Add(label3);
            Controls.Add(ctbProjeAdet);
            Controls.Add(clbMalzemeAltGrup2);
            Controls.Add(clbMalzemeAltGrup);
            Controls.Add(clbMalzemeGrup);
            Controls.Add(clbStokGrup);
            Controls.Add(clbMalzemeStandart);
            Controls.Add(clbOlcuBirim);
            Controls.Add(clbStokTip);
            Controls.Add(clbProjeKod);
            Controls.Add(rButtonKaydet);
            Controls.Add(headerPanel1);
            Controls.Add(checkBoxIsDxf);
            Controls.Add(checkBoxIsStep);
            Controls.Add(checkBoxIsFromExcel);
            Controls.Add(checkBoxIsPdf);
            Controls.Add(checkBoxIsSatinalma);
            Controls.Add(label29);
            Controls.Add(ctbBoyut);
            Controls.Add(label28);
            Controls.Add(label27);
            Controls.Add(label26);
            Controls.Add(label25);
            Controls.Add(label22);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(ctbAgirlik);
            Controls.Add(label10);
            Controls.Add(panel1);
            Controls.Add(label24);
            Controls.Add(label23);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(ctbAciklama);
            Controls.Add(ctbEtKalinlik);
            Controls.Add(label19);
            Controls.Add(ctbUzunluk);
            Controls.Add(label18);
            Controls.Add(ctbCap);
            Controls.Add(label17);
            Controls.Add(ctbYukseklik);
            Controls.Add(label16);
            Controls.Add(ctbEn);
            Controls.Add(label15);
            Controls.Add(ctbBoy);
            Controls.Add(label14);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(ctbStokAd);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ctbKod);
            Controls.Add(ctbId);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StokKartKayitFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StokKartTanimlamaFormu";
            Load += StokKartTanimlamaFormu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.CustomTextBox ctbId;
        private CustomControls.CustomTextBox ctbKod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBox ctbStokAd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private CustomControls.CustomTextBoxSayisal ctbBoy;
        private CustomControls.CustomTextBoxSayisal ctbEn;
        private System.Windows.Forms.Label label15;
        private CustomControls.CustomTextBoxSayisal ctbYukseklik;
        private System.Windows.Forms.Label label16;
        private CustomControls.CustomTextBoxSayisal ctbCap;
        private System.Windows.Forms.Label label17;
        private CustomControls.CustomTextBoxSayisal ctbUzunluk;
        private System.Windows.Forms.Label label18;
        private CustomControls.CustomTextBoxSayisal ctbEtKalinlik;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private CustomControls.CustomTextBox ctbAciklama;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        CustomDataGrid<DataControlStokKartDosya> customDataGrid;
        public class DataControlStokKartDosya : DataControl, IEntity
        {
            private readonly ICache _cache;
            private readonly IStokService _stokService;
            private readonly IJsonConverter _jsonConverter;
            private StokKartDosya _stokKartDosya;
            public StokKartDosya stokKartDosya
            {
                get 
                { 
                    if (_stokKartDosya == null) 
                    { 
                        _stokKartDosya = new(); 
                    }  
                    return _stokKartDosya; 
                }
                set
                {
                    _stokKartDosya = value;
                    Binding();
                }
            }
            public DataControlStokKartDosya(ICache cache, IStokService stokService, IJsonConverter jsonConverter)
            {
                _cache = cache;
                _stokService = stokService;
                _jsonConverter = jsonConverter;
                InitializeComponents();
            }

            private void Binding()
            {
                IdControl.DataBindings.Clear();
                stokKartIdControl.DataBindings.Clear();
                dosyaUzantiControl.DataBindings.Clear();
                dosyaAdControl.DataBindings.Clear();
                dosyaTipControl.DataBindings.Clear();
                IdControl.DataBindings.Add(nameof(IdControl.TextCustom), stokKartDosya, nameof(stokKartDosya.Id), true, DataSourceUpdateMode.OnPropertyChanged);
                stokKartIdControl.DataBindings.Add(nameof(stokKartIdControl.TextCustom), stokKartDosya, nameof(stokKartDosya.stokKartId), true, DataSourceUpdateMode.OnPropertyChanged);
                dosyaUzantiControl.DataBindings.Add(nameof(dosyaUzantiControl.TextCustom), stokKartDosya, nameof(stokKartDosya.dosyaUzanti), true, DataSourceUpdateMode.OnPropertyChanged);
                dosyaAdControl.DataBindings.Add(nameof(dosyaAdControl.TextCustom), stokKartDosya, nameof(stokKartDosya.dosyaAd), true, DataSourceUpdateMode.OnPropertyChanged);
                dosyaTipControl.DataBindings.Add(nameof(dosyaTipControl.SelectedValue), stokKartDosya.dosyaTip, nameof(stokKartDosya.dosyaTip.Id), true, DataSourceUpdateMode.OnPropertyChanged);
            }

            public DataControlStokKartDosya()
            {
                InitializeComponents();
            }

            public CustomTextBox IdControl { get; set; }
            public CustomTextBox stokKartIdControl { get; set; }
            private FilterableComboBox _dosyaTipControl;
            public FilterableComboBox dosyaTipControl
            { get { if (_dosyaTipControl == null) { _dosyaTipControl = new(); } return _dosyaTipControl; } set { _dosyaTipControl = value; } }
            public CustomTextBox dosyaAdControl { get; set; }
            public CustomTextBox dosyaUzantiControl { get; set; }
            public byte[] dosyaVeri { get; set; }
            public RoundedIconButton iconButton { get; set; }
            public RoundedIconButton iconButtonView { get; set; }


            private void InitializeComponents()
            {
                IdControl = new() { TabIndex = 1, Width = 0, Visible = true, Tag = "Id" };
                stokKartIdControl = new() { TabIndex = 2, Width = 0, Visible = true, Tag = "StokKartId" };
                dosyaTipControl = new() { TabIndex = 3, Width = 60, Visible = true, Tag = "DosyaTip",DisplayMember="ad",ValueMember="Id" };
                dosyaAdControl = new() { TabIndex = 4, Width = 250, Tag = "Dosya Adı" };
                dosyaUzantiControl = new() { TabIndex = 5, Width = 50, Tag = "Dosya Uzantı"};
                iconButton = new() { TabIndex = 6, Width = 35, Height = 28, Tag = " Ekle", BackgroundImage = Resources.ekle, 
                    BackColor = Color.Transparent, BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom, CornerRadius = 5 };
                iconButton.Click += ButtonDosyaEkle_Click;
                iconButtonView = new() { TabIndex = 7, Width = 35, Height = 28, Tag = "Göster", BackgroundImage = Resources.pngegg, 
                    BackColor = Color.Transparent, BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom,CornerRadius=5 };
                iconButtonView.Click += ButtonDosyaGoruntule_Click;
                dosyaVeri = new byte[0];
                 
                buttonSil.Click += ButtonSil_Click;
                if(stokKartDosya == null)
                {
                    stokKartDosya = new StokKartDosya();
                }
                
                ComboBoxListFill.GetLookupAd(_cache.dosyaTipList, ref _dosyaTipControl);
            }

            private void ButtonDosyaEkle_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    stokKartDosya.dosya = File.ReadAllBytes(openFileDialog.FileName);
                    stokKartDosya.dosyaAd= Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    stokKartDosya.dosyaUzanti = Path.GetExtension(openFileDialog.FileName).Replace(".", "");
                    Binding();
                    //dosyaAdControl.TextCustom = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    //dosyaUzantiControl.TextCustom = Path.GetExtension(openFileDialog.FileName).Replace(".", "");
                }
            }
            private async void ButtonSil_Click(object sender, EventArgs e)
            {
                StokKartDosya stokKartDosya = new();
                if (IdControl.TextCustom != "") stokKartDosya.Id = Convert.ToInt32(IdControl.TextCustom.Replace(".", ""));
                string jsonResult = await _stokService.DeleteStokKartDosya(stokKartDosya);
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult)[0];
                if (result?.result != null)
                {
                    MessageBox.Show(result.result);
                }
            }
            private async void ButtonDosyaGoruntule_Click(object sender, EventArgs e)
            {
                if(string.IsNullOrWhiteSpace(stokKartIdControl.TextCustom))
                    return;
                StokKart stokKart = new StokKart() { Id = int.Parse(stokKartIdControl.TextCustom) };
                string jsonResult = await _stokService.GetStokKartPdf(stokKart);
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult)[0];
                if (result.result != null)
                {
                    stokKart = JsonConvert.DeserializeObject<List<StokKart>>(result.result)[0];
                }
                dosyaVeri = stokKart.dosyaList.First(d => d.Id == int.Parse(IdControl.TextCustom)).dosya;
                string tempFilePath = Path.GetTempFileName() + "." + dosyaUzantiControl.TextCustom;
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
            public bool Validate() 
            {
                bool isValid = true;
                isValid &= GlobalData.CheckField("Dosya Tipi seçilmelidir", dosyaTipControl);
                isValid &= GlobalData.CheckField("Dosya Adı boş olmamalıdır", dosyaAdControl);
                isValid &= GlobalData.CheckField("Dosya Uzantısı boş olmamalıdır", dosyaUzantiControl);
                return isValid;
            }
        }

        private System.Windows.Forms.Panel panel1;
        private CustomTextBoxSayisal ctbAgirlik;
        private Label label10;
        private Label label12;
        private Label label13;
        private Label label22;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private CustomTextBox ctbBoyut;
        private CheckBox checkBoxIsSatinalma;
        private CheckBox checkBoxIsPdf;
        private CheckBox checkBoxIsFromExcel;
        private CheckBox checkBoxIsStep;
        private CheckBox checkBoxIsDxf;
        private HeaderPanel headerPanel1;
        private CustomButtonSave rButtonKaydet;
        private FilterableComboBox clbProjeKod;
        private FilterableComboBox clbStokTip;
        private FilterableComboBox clbOlcuBirim;
        private FilterableComboBox clbMalzemeStandart;
        private FilterableComboBox clbStokGrup;
        private FilterableComboBox clbMalzemeGrup;
        private FilterableComboBox clbMalzemeAltGrup;
        private FilterableComboBox clbMalzemeAltGrup2;
        private CustomTextBoxSayisal ctbProjeAdet;
        private Label label3;
    }
}