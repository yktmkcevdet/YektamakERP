using ApiService.Implementations;
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
            components = new Container();
            ctbId = new CustomTextBox();
            ctbKod = new CustomTextBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            ctbStokAd = new CustomTextBox();
            lblStokGrup = new Label();
            lblMalzemeStandart = new Label();
            lblMalzemeGrup = new Label();
            label8 = new Label();
            label9 = new Label();
            lblBoy = new Label();
            ctbBoy = new CustomTextBoxSayisal();
            ctbEn = new CustomTextBoxSayisal();
            lblEn = new Label();
            ctbYukseklik = new CustomTextBoxSayisal();
            lblYukseklik = new Label();
            ctbCap = new CustomTextBoxSayisal();
            lblCap = new Label();
            ctbUzunluk = new CustomTextBoxSayisal();
            lblUzunluk = new Label();
            ctbEtKalinlik = new CustomTextBoxSayisal();
            lblEtKalinlik = new Label();
            label20 = new Label();
            ctbAciklama = new CustomTextBox();
            label21 = new Label();
            lblMalzemeAltGrup = new Label();
            lblMalzemeAltGrup2 = new Label();
            panel1 = new Panel();
            ctbAgirlik = new CustomTextBoxSayisal();
            lblAgirlik = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label22 = new Label();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            lblBoyut = new Label();
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
            lblProjeAdet = new Label();
            fcbBoyut = new FilterableComboBox();
            ctxSagClickMenu = new ContextMenuStrip(components);
            stokGrupTanımlamaToolStripMenuItem = new ToolStripMenuItem();
            malzemeGrupTanımlarıToolStripMenuItem = new ToolStripMenuItem();
            malzemeAltGrupTanımlamaToolStripMenuItem = new ToolStripMenuItem();
            malzemeAltGrup2TanımlamaToolStripMenuItem = new ToolStripMenuItem();
            ctxMalzeme = new ContextMenuStrip(components);
            ctbTedarikciKod = new CustomTextBox();
            label30 = new Label();
            label31 = new Label();
            ctbStokKartId = new CustomTextBox();
            ctbStokKartNo = new CustomTextBox();
            label3 = new Label();
            chkTalasli = new CheckBox();
            chkBukum = new CheckBox();
            customButtonNewRecord1 = new CustomButtonNewRecord();
            roundedButton1 = new RoundedButton();
            ctb_internalReference = new CustomTextBox();
            label5 = new Label();
            button1 = new Button();
            ctxSagClickMenu.SuspendLayout();
            SuspendLayout();
            // 
            // ctbId
            // 
            ctbId.BackColor = Color.White;
            ctbId.BorderColor = Color.Silver;
            ctbId.BorderFocusColor = Color.HotPink;
            ctbId.BorderSize = 1;
            ctbId.Enabled = false;
            ctbId.Font = new Font("Segoe UI", 8F);
            ctbId.ForeColor = Color.Black;
            ctbId.Location = new Point(113, 35);
            ctbId.Margin = new Padding(1);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new Padding(3);
            ctbId.PasswordChar = false;
            ctbId.PlaceholderColor = Color.DarkGray;
            ctbId.PlaceholderText = "";
            ctbId.ReadOnly = false;
            ctbId.SelectionStart = 0;
            ctbId.Size = new Size(94, 25);
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
            ctbKod.BorderSize = 1;
            ctbKod.Font = new Font("Segoe UI", 8F);
            ctbKod.ForeColor = Color.Black;
            ctbKod.Location = new Point(113, 170);
            ctbKod.Margin = new Padding(1);
            ctbKod.Multiline = false;
            ctbKod.Name = "ctbKod";
            ctbKod.Padding = new Padding(3);
            ctbKod.PasswordChar = false;
            ctbKod.PlaceholderColor = Color.DarkGray;
            ctbKod.PlaceholderText = "";
            ctbKod.ReadOnly = false;
            ctbKod.SelectionStart = 0;
            ctbKod.Size = new Size(259, 25);
            ctbKod.TabIndex = 3;
            ctbKod.TextAlignment = HorizontalAlignment.Left;
            ctbKod.TextCustom = "";
            ctbKod.UnderlinedStyle = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(22, 42);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 9;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(22, 176);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 10;
            label2.Text = "Parça Kodu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(22, 203);
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
            ctbStokAd.BorderSize = 1;
            ctbStokAd.Font = new Font("Segoe UI", 8F);
            ctbStokAd.ForeColor = Color.Black;
            ctbStokAd.Location = new Point(113, 197);
            ctbStokAd.Margin = new Padding(1);
            ctbStokAd.Multiline = false;
            ctbStokAd.Name = "ctbStokAd";
            ctbStokAd.Padding = new Padding(3);
            ctbStokAd.PasswordChar = false;
            ctbStokAd.PlaceholderColor = Color.DarkGray;
            ctbStokAd.PlaceholderText = "";
            ctbStokAd.ReadOnly = false;
            ctbStokAd.SelectionStart = 0;
            ctbStokAd.Size = new Size(362, 25);
            ctbStokAd.TabIndex = 4;
            ctbStokAd.TextAlignment = HorizontalAlignment.Left;
            ctbStokAd.TextCustom = "";
            ctbStokAd.UnderlinedStyle = false;
            // 
            // lblStokGrup
            // 
            lblStokGrup.AutoSize = true;
            lblStokGrup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStokGrup.Location = new Point(514, 44);
            lblStokGrup.Name = "lblStokGrup";
            lblStokGrup.Size = new Size(71, 15);
            lblStokGrup.TabIndex = 16;
            lblStokGrup.Text = "Stok Grubu";
            lblStokGrup.Click += label5_Click;
            // 
            // lblMalzemeStandart
            // 
            lblMalzemeStandart.AutoSize = true;
            lblMalzemeStandart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMalzemeStandart.Location = new Point(514, 179);
            lblMalzemeStandart.Name = "lblMalzemeStandart";
            lblMalzemeStandart.Size = new Size(76, 15);
            lblMalzemeStandart.TabIndex = 18;
            lblMalzemeStandart.Text = "Malzme Std.";
            // 
            // lblMalzemeGrup
            // 
            lblMalzemeGrup.AutoSize = true;
            lblMalzemeGrup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMalzemeGrup.Location = new Point(514, 71);
            lblMalzemeGrup.Name = "lblMalzemeGrup";
            lblMalzemeGrup.Size = new Size(96, 15);
            lblMalzemeGrup.TabIndex = 20;
            lblMalzemeGrup.Text = "Malzeme Grubu";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(22, 258);
            label8.Name = "label8";
            label8.Size = new Size(68, 15);
            label8.TabIndex = 22;
            label8.Text = "Ölçü Birimi";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(22, 149);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 24;
            label9.Text = "Proje Kodu";
            // 
            // lblBoy
            // 
            lblBoy.AutoSize = true;
            lblBoy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBoy.Location = new Point(136, 344);
            lblBoy.Name = "lblBoy";
            lblBoy.Size = new Size(28, 15);
            lblBoy.TabIndex = 34;
            lblBoy.Text = "Boy";
            // 
            // ctbBoy
            // 
            ctbBoy.BackColor = Color.White;
            ctbBoy.Font = new Font("Segoe UI", 8F);
            ctbBoy.ForeColor = Color.Black;
            ctbBoy.Location = new Point(136, 362);
            ctbBoy.Margin = new Padding(1);
            ctbBoy.Name = "ctbBoy";
            ctbBoy.OndalikBasamak = 0;
            ctbBoy.Padding = new Padding(3);
            ctbBoy.Size = new Size(71, 25);
            ctbBoy.TabIndex = 16;
            ctbBoy.TextCustom = "0";
            // 
            // ctbEn
            // 
            ctbEn.BackColor = Color.White;
            ctbEn.Font = new Font("Segoe UI", 8F);
            ctbEn.ForeColor = Color.Black;
            ctbEn.Location = new Point(258, 362);
            ctbEn.Margin = new Padding(1);
            ctbEn.Name = "ctbEn";
            ctbEn.OndalikBasamak = 0;
            ctbEn.Padding = new Padding(3);
            ctbEn.Size = new Size(71, 25);
            ctbEn.TabIndex = 17;
            ctbEn.TextCustom = "0";
            // 
            // lblEn
            // 
            lblEn.AutoSize = true;
            lblEn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEn.Location = new Point(258, 344);
            lblEn.Name = "lblEn";
            lblEn.Size = new Size(20, 15);
            lblEn.TabIndex = 36;
            lblEn.Text = "En";
            // 
            // ctbYukseklik
            // 
            ctbYukseklik.BackColor = Color.White;
            ctbYukseklik.Font = new Font("Segoe UI", 8F);
            ctbYukseklik.ForeColor = Color.Black;
            ctbYukseklik.Location = new Point(379, 362);
            ctbYukseklik.Margin = new Padding(1);
            ctbYukseklik.Name = "ctbYukseklik";
            ctbYukseklik.OndalikBasamak = 0;
            ctbYukseklik.Padding = new Padding(3);
            ctbYukseklik.Size = new Size(71, 25);
            ctbYukseklik.TabIndex = 18;
            ctbYukseklik.TextCustom = "0";
            // 
            // lblYukseklik
            // 
            lblYukseklik.AutoSize = true;
            lblYukseklik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblYukseklik.Location = new Point(379, 344);
            lblYukseklik.Name = "lblYukseklik";
            lblYukseklik.Size = new Size(59, 15);
            lblYukseklik.TabIndex = 38;
            lblYukseklik.Text = "Yükseklik";
            // 
            // ctbCap
            // 
            ctbCap.BackColor = Color.White;
            ctbCap.Font = new Font("Segoe UI", 8F);
            ctbCap.ForeColor = Color.Black;
            ctbCap.Location = new Point(524, 362);
            ctbCap.Margin = new Padding(1);
            ctbCap.Name = "ctbCap";
            ctbCap.OndalikBasamak = 0;
            ctbCap.Padding = new Padding(3);
            ctbCap.Size = new Size(71, 25);
            ctbCap.TabIndex = 19;
            ctbCap.TextCustom = "0";
            // 
            // lblCap
            // 
            lblCap.AutoSize = true;
            lblCap.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCap.Location = new Point(524, 344);
            lblCap.Name = "lblCap";
            lblCap.Size = new Size(27, 15);
            lblCap.TabIndex = 40;
            lblCap.Text = "Çap";
            // 
            // ctbUzunluk
            // 
            ctbUzunluk.BackColor = Color.White;
            ctbUzunluk.Font = new Font("Segoe UI", 8F);
            ctbUzunluk.ForeColor = Color.Black;
            ctbUzunluk.Location = new Point(647, 362);
            ctbUzunluk.Margin = new Padding(1);
            ctbUzunluk.Name = "ctbUzunluk";
            ctbUzunluk.OndalikBasamak = 0;
            ctbUzunluk.Padding = new Padding(3);
            ctbUzunluk.Size = new Size(71, 25);
            ctbUzunluk.TabIndex = 20;
            ctbUzunluk.TextCustom = "0";
            // 
            // lblUzunluk
            // 
            lblUzunluk.AutoSize = true;
            lblUzunluk.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUzunluk.Location = new Point(647, 344);
            lblUzunluk.Name = "lblUzunluk";
            lblUzunluk.Size = new Size(53, 15);
            lblUzunluk.TabIndex = 42;
            lblUzunluk.Text = "Uzunluk";
            // 
            // ctbEtKalinlik
            // 
            ctbEtKalinlik.BackColor = Color.White;
            ctbEtKalinlik.Font = new Font("Segoe UI", 8F);
            ctbEtKalinlik.ForeColor = Color.Black;
            ctbEtKalinlik.Location = new Point(771, 362);
            ctbEtKalinlik.Margin = new Padding(1);
            ctbEtKalinlik.Name = "ctbEtKalinlik";
            ctbEtKalinlik.OndalikBasamak = 0;
            ctbEtKalinlik.Padding = new Padding(3);
            ctbEtKalinlik.Size = new Size(71, 25);
            ctbEtKalinlik.TabIndex = 21;
            ctbEtKalinlik.TextCustom = "0";
            // 
            // lblEtKalinlik
            // 
            lblEtKalinlik.AutoSize = true;
            lblEtKalinlik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEtKalinlik.Location = new Point(771, 344);
            lblEtKalinlik.Name = "lblEtKalinlik";
            lblEtKalinlik.Size = new Size(64, 15);
            lblEtKalinlik.TabIndex = 44;
            lblEtKalinlik.Text = "Et Kalınlığı";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label20.Location = new Point(22, 282);
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
            ctbAciklama.BorderSize = 1;
            ctbAciklama.Font = new Font("Segoe UI", 8F);
            ctbAciklama.ForeColor = Color.Black;
            ctbAciklama.Location = new Point(113, 277);
            ctbAciklama.Margin = new Padding(1);
            ctbAciklama.Multiline = true;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new Padding(7, 5, 7, 5);
            ctbAciklama.PasswordChar = false;
            ctbAciklama.PlaceholderColor = Color.DarkGray;
            ctbAciklama.PlaceholderText = "";
            ctbAciklama.ReadOnly = false;
            ctbAciklama.SelectionStart = 0;
            ctbAciklama.Size = new Size(362, 60);
            ctbAciklama.TabIndex = 7;
            ctbAciklama.TextAlignment = HorizontalAlignment.Left;
            ctbAciklama.TextCustom = "";
            ctbAciklama.UnderlinedStyle = false;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label21.Location = new Point(22, 122);
            label21.Name = "label21";
            label21.Size = new Size(56, 15);
            label21.TabIndex = 49;
            label21.Text = "Stok Tipi";
            // 
            // lblMalzemeAltGrup
            // 
            lblMalzemeAltGrup.AutoSize = true;
            lblMalzemeAltGrup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMalzemeAltGrup.Location = new Point(514, 98);
            lblMalzemeAltGrup.Name = "lblMalzemeAltGrup";
            lblMalzemeAltGrup.Size = new Size(115, 15);
            lblMalzemeAltGrup.TabIndex = 54;
            lblMalzemeAltGrup.Text = "Malzeme Alt Grubu";
            // 
            // lblMalzemeAltGrup2
            // 
            lblMalzemeAltGrup2.AutoSize = true;
            lblMalzemeAltGrup2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMalzemeAltGrup2.Location = new Point(514, 125);
            lblMalzemeAltGrup2.Name = "lblMalzemeAltGrup2";
            lblMalzemeAltGrup2.Size = new Size(125, 15);
            lblMalzemeAltGrup2.TabIndex = 56;
            lblMalzemeAltGrup2.Text = "Malzeme Alt Grubu 2";
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(20, 411);
            panel1.Name = "panel1";
            panel1.Size = new Size(855, 205);
            panel1.TabIndex = 57;
            panel1.DragDrop += panel1_DragDrop;
            panel1.DragEnter += panel1_DragEnter;
            // 
            // ctbAgirlik
            // 
            ctbAgirlik.BackColor = Color.White;
            ctbAgirlik.Font = new Font("Segoe UI", 8F);
            ctbAgirlik.ForeColor = Color.Black;
            ctbAgirlik.Location = new Point(22, 362);
            ctbAgirlik.Margin = new Padding(1);
            ctbAgirlik.Name = "ctbAgirlik";
            ctbAgirlik.OndalikBasamak = 2;
            ctbAgirlik.Padding = new Padding(3);
            ctbAgirlik.Size = new Size(71, 25);
            ctbAgirlik.TabIndex = 15;
            ctbAgirlik.TextCustom = "0,00";
            // 
            // lblAgirlik
            // 
            lblAgirlik.AutoSize = true;
            lblAgirlik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAgirlik.Location = new Point(22, 344);
            lblAgirlik.Name = "lblAgirlik";
            lblAgirlik.Size = new Size(43, 15);
            lblAgirlik.TabIndex = 58;
            lblAgirlik.Text = "Ağırlık";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(18, 393);
            label11.Name = "label11";
            label11.Size = new Size(54, 15);
            label11.TabIndex = 60;
            label11.Text = "Dosyalar";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(97, 368);
            label12.Name = "label12";
            label12.Size = new Size(20, 15);
            label12.TabIndex = 61;
            label12.Text = "kg";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(211, 367);
            label13.Name = "label13";
            label13.Size = new Size(29, 15);
            label13.TabIndex = 62;
            label13.Text = "mm";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(333, 369);
            label22.Name = "label22";
            label22.Size = new Size(29, 15);
            label22.TabIndex = 63;
            label22.Text = "mm";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(454, 369);
            label25.Name = "label25";
            label25.Size = new Size(29, 15);
            label25.TabIndex = 64;
            label25.Text = "mm";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(599, 369);
            label26.Name = "label26";
            label26.Size = new Size(29, 15);
            label26.TabIndex = 65;
            label26.Text = "mm";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(722, 369);
            label27.Name = "label27";
            label27.Size = new Size(29, 15);
            label27.TabIndex = 66;
            label27.Text = "mm";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(846, 369);
            label28.Name = "label28";
            label28.Size = new Size(29, 15);
            label28.TabIndex = 67;
            label28.Text = "mm";
            // 
            // lblBoyut
            // 
            lblBoyut.AutoSize = true;
            lblBoyut.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBoyut.Location = new Point(514, 206);
            lblBoyut.Name = "lblBoyut";
            lblBoyut.Size = new Size(40, 15);
            lblBoyut.TabIndex = 69;
            lblBoyut.Text = "Boyut";
            // 
            // ctbBoyut
            // 
            ctbBoyut.BackColor = Color.White;
            ctbBoyut.BorderColor = Color.Silver;
            ctbBoyut.BorderFocusColor = Color.HotPink;
            ctbBoyut.BorderSize = 1;
            ctbBoyut.Font = new Font("Segoe UI", 8F);
            ctbBoyut.ForeColor = Color.Black;
            ctbBoyut.Location = new Point(650, 228);
            ctbBoyut.Margin = new Padding(1);
            ctbBoyut.Multiline = false;
            ctbBoyut.Name = "ctbBoyut";
            ctbBoyut.Padding = new Padding(3);
            ctbBoyut.PasswordChar = false;
            ctbBoyut.PlaceholderColor = Color.DarkGray;
            ctbBoyut.PlaceholderText = "";
            ctbBoyut.ReadOnly = false;
            ctbBoyut.SelectionStart = 0;
            ctbBoyut.Size = new Size(185, 25);
            ctbBoyut.TabIndex = 22;
            ctbBoyut.TextAlignment = HorizontalAlignment.Left;
            ctbBoyut.TextCustom = "";
            ctbBoyut.UnderlinedStyle = false;
            // 
            // checkBoxIsSatinalma
            // 
            checkBoxIsSatinalma.AutoSize = true;
            checkBoxIsSatinalma.Location = new Point(659, 312);
            checkBoxIsSatinalma.Name = "checkBoxIsSatinalma";
            checkBoxIsSatinalma.Size = new Size(15, 14);
            checkBoxIsSatinalma.TabIndex = 70;
            checkBoxIsSatinalma.UseVisualStyleBackColor = true;
            checkBoxIsSatinalma.Visible = false;
            // 
            // checkBoxIsPdf
            // 
            checkBoxIsPdf.AutoSize = true;
            checkBoxIsPdf.Location = new Point(680, 312);
            checkBoxIsPdf.Name = "checkBoxIsPdf";
            checkBoxIsPdf.Size = new Size(15, 14);
            checkBoxIsPdf.TabIndex = 71;
            checkBoxIsPdf.UseVisualStyleBackColor = true;
            checkBoxIsPdf.Visible = false;
            // 
            // checkBoxIsFromExcel
            // 
            checkBoxIsFromExcel.AutoSize = true;
            checkBoxIsFromExcel.Location = new Point(701, 312);
            checkBoxIsFromExcel.Name = "checkBoxIsFromExcel";
            checkBoxIsFromExcel.Size = new Size(15, 14);
            checkBoxIsFromExcel.TabIndex = 72;
            checkBoxIsFromExcel.UseVisualStyleBackColor = true;
            checkBoxIsFromExcel.Visible = false;
            // 
            // checkBoxIsStep
            // 
            checkBoxIsStep.AutoSize = true;
            checkBoxIsStep.Location = new Point(722, 312);
            checkBoxIsStep.Name = "checkBoxIsStep";
            checkBoxIsStep.Size = new Size(15, 14);
            checkBoxIsStep.TabIndex = 73;
            checkBoxIsStep.UseVisualStyleBackColor = true;
            checkBoxIsStep.Visible = false;
            // 
            // checkBoxIsDxf
            // 
            checkBoxIsDxf.AutoSize = true;
            checkBoxIsDxf.Location = new Point(749, 312);
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
            headerPanel1.Baslik = "Stok Kart Tanımı";
            headerPanel1.Location = new Point(0, 0);
            headerPanel1.Margin = new Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new Padding(1);
            headerPanel1.Size = new Size(891, 25);
            headerPanel1.TabIndex = 75;
            // 
            // rButtonKaydet
            // 
            rButtonKaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            rButtonKaydet.BackColor = Color.Transparent;
            rButtonKaydet.BorderColor = Color.Black;
            rButtonKaydet.BorderSize = 0;
            rButtonKaydet.CornerRadius = 6;
            rButtonKaydet.GradientColor1 = Color.DodgerBlue;
            rButtonKaydet.GradientColor2 = Color.MidnightBlue;
            rButtonKaydet.HoverColor1 = Color.RoyalBlue;
            rButtonKaydet.HoverColor2 = Color.Navy;
            rButtonKaydet.Location = new Point(769, 624);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new Size(36, 36);
            rButtonKaydet.TabIndex = 76;
            rButtonKaydet.SaveButtonClick += rButtonKaydet_Click;
            // 
            // clbProjeKod
            // 
            clbProjeKod.BorderColor = Color.Silver;
            clbProjeKod.BorderRadius = 8;
            clbProjeKod.BorderSize = 1;
            clbProjeKod.DisplayMember = "kod";
            clbProjeKod.Font = new Font("Segoe UI", 8F);
            clbProjeKod.Location = new Point(113, 143);
            clbProjeKod.Margin = new Padding(1);
            clbProjeKod.Name = "clbProjeKod";
            clbProjeKod.Padding = new Padding(6, 4, 6, 4);
            clbProjeKod.PlaceholderText = "Seçiniz...";
            clbProjeKod.ReadOnly = false;
            clbProjeKod.Size = new Size(138, 25);
            clbProjeKod.TabIndex = 2;
            clbProjeKod.ValueMember = "Id";
            clbProjeKod.SelectedIndexChanged += clbProjeKod_SelectedIndexChanged;
            // 
            // clbStokTip
            // 
            clbStokTip.BorderColor = Color.Silver;
            clbStokTip.BorderRadius = 8;
            clbStokTip.BorderSize = 1;
            clbStokTip.DisplayMember = "ad";
            clbStokTip.Font = new Font("Segoe UI", 8F);
            clbStokTip.Location = new Point(113, 116);
            clbStokTip.Margin = new Padding(1);
            clbStokTip.Name = "clbStokTip";
            clbStokTip.Padding = new Padding(6, 4, 6, 4);
            clbStokTip.PlaceholderText = "Seçiniz...";
            clbStokTip.ReadOnly = false;
            clbStokTip.Size = new Size(138, 25);
            clbStokTip.TabIndex = 1;
            clbStokTip.ValueMember = "Id";
            clbStokTip.SelectedIndexChanged += clbStokTip_SelectedIndexChanged;
            // 
            // clbOlcuBirim
            // 
            clbOlcuBirim.BorderColor = Color.Silver;
            clbOlcuBirim.BorderRadius = 8;
            clbOlcuBirim.BorderSize = 1;
            clbOlcuBirim.DisplayMember = "ad";
            clbOlcuBirim.Font = new Font("Segoe UI", 8F);
            clbOlcuBirim.Location = new Point(113, 250);
            clbOlcuBirim.Margin = new Padding(1);
            clbOlcuBirim.Name = "clbOlcuBirim";
            clbOlcuBirim.Padding = new Padding(6, 4, 6, 4);
            clbOlcuBirim.PlaceholderText = "Seçiniz...";
            clbOlcuBirim.ReadOnly = false;
            clbOlcuBirim.Size = new Size(102, 25);
            clbOlcuBirim.TabIndex = 6;
            clbOlcuBirim.ValueMember = "Id";
            // 
            // clbMalzemeStandart
            // 
            clbMalzemeStandart.BorderColor = Color.Silver;
            clbMalzemeStandart.BorderRadius = 8;
            clbMalzemeStandart.BorderSize = 1;
            clbMalzemeStandart.DisplayMember = "ad";
            clbMalzemeStandart.Font = new Font("Segoe UI", 8F);
            clbMalzemeStandart.Location = new Point(650, 174);
            clbMalzemeStandart.Margin = new Padding(1);
            clbMalzemeStandart.Name = "clbMalzemeStandart";
            clbMalzemeStandart.Padding = new Padding(6, 4, 6, 4);
            clbMalzemeStandart.PlaceholderText = "Seçiniz...";
            clbMalzemeStandart.ReadOnly = false;
            clbMalzemeStandart.Size = new Size(159, 25);
            clbMalzemeStandart.TabIndex = 13;
            clbMalzemeStandart.ValueMember = "Id";
            // 
            // clbStokGrup
            // 
            clbStokGrup.BorderColor = Color.Silver;
            clbStokGrup.BorderRadius = 8;
            clbStokGrup.BorderSize = 1;
            clbStokGrup.DisplayMember = "ad";
            clbStokGrup.Font = new Font("Segoe UI", 8F);
            clbStokGrup.Location = new Point(650, 39);
            clbStokGrup.Margin = new Padding(1);
            clbStokGrup.Name = "clbStokGrup";
            clbStokGrup.Padding = new Padding(6, 4, 6, 4);
            clbStokGrup.PlaceholderText = "Seçiniz...";
            clbStokGrup.ReadOnly = false;
            clbStokGrup.Size = new Size(159, 25);
            clbStokGrup.TabIndex = 8;
            clbStokGrup.ValueMember = "Id";
            clbStokGrup.SelectedIndexChanged += cbxStokGrup_SelectedIndexChanged;
            // 
            // clbMalzemeGrup
            // 
            clbMalzemeGrup.BorderColor = Color.Silver;
            clbMalzemeGrup.BorderRadius = 8;
            clbMalzemeGrup.BorderSize = 1;
            clbMalzemeGrup.DisplayMember = "ad";
            clbMalzemeGrup.Font = new Font("Segoe UI", 8F);
            clbMalzemeGrup.Location = new Point(650, 66);
            clbMalzemeGrup.Margin = new Padding(1);
            clbMalzemeGrup.Name = "clbMalzemeGrup";
            clbMalzemeGrup.Padding = new Padding(6, 4, 6, 4);
            clbMalzemeGrup.PlaceholderText = "Seçiniz...";
            clbMalzemeGrup.ReadOnly = false;
            clbMalzemeGrup.Size = new Size(159, 25);
            clbMalzemeGrup.TabIndex = 9;
            clbMalzemeGrup.ValueMember = "Id";
            clbMalzemeGrup.SelectedIndexChanged += cbxMalzemeGrup_SelectedIndexChanged;
            clbMalzemeGrup.MouseClick += clbMalzemeGrup_MouseClick;
            // 
            // clbMalzemeAltGrup
            // 
            clbMalzemeAltGrup.BorderColor = Color.Silver;
            clbMalzemeAltGrup.BorderRadius = 8;
            clbMalzemeAltGrup.BorderSize = 1;
            clbMalzemeAltGrup.DisplayMember = "ad";
            clbMalzemeAltGrup.Font = new Font("Segoe UI", 8F);
            clbMalzemeAltGrup.Location = new Point(650, 93);
            clbMalzemeAltGrup.Margin = new Padding(1);
            clbMalzemeAltGrup.Name = "clbMalzemeAltGrup";
            clbMalzemeAltGrup.Padding = new Padding(6, 4, 6, 4);
            clbMalzemeAltGrup.PlaceholderText = "Seçiniz...";
            clbMalzemeAltGrup.ReadOnly = false;
            clbMalzemeAltGrup.Size = new Size(159, 25);
            clbMalzemeAltGrup.TabIndex = 10;
            clbMalzemeAltGrup.ValueMember = "Id";
            clbMalzemeAltGrup.SelectedIndexChanged += cbxMalzemeAltGrup_SelectedIndexChanged;
            // 
            // clbMalzemeAltGrup2
            // 
            clbMalzemeAltGrup2.BorderColor = Color.Silver;
            clbMalzemeAltGrup2.BorderRadius = 8;
            clbMalzemeAltGrup2.BorderSize = 1;
            clbMalzemeAltGrup2.DisplayMember = "ad";
            clbMalzemeAltGrup2.Font = new Font("Segoe UI", 8F);
            clbMalzemeAltGrup2.Location = new Point(650, 120);
            clbMalzemeAltGrup2.Margin = new Padding(1);
            clbMalzemeAltGrup2.Name = "clbMalzemeAltGrup2";
            clbMalzemeAltGrup2.Padding = new Padding(6, 4, 6, 4);
            clbMalzemeAltGrup2.PlaceholderText = "Seçiniz...";
            clbMalzemeAltGrup2.ReadOnly = false;
            clbMalzemeAltGrup2.Size = new Size(159, 25);
            clbMalzemeAltGrup2.TabIndex = 11;
            clbMalzemeAltGrup2.ValueMember = "Id";
            // 
            // ctbProjeAdet
            // 
            ctbProjeAdet.BackColor = Color.White;
            ctbProjeAdet.Font = new Font("Segoe UI", 8F);
            ctbProjeAdet.ForeColor = Color.Black;
            ctbProjeAdet.Location = new Point(650, 147);
            ctbProjeAdet.Margin = new Padding(1);
            ctbProjeAdet.Name = "ctbProjeAdet";
            ctbProjeAdet.OndalikBasamak = 0;
            ctbProjeAdet.Padding = new Padding(3);
            ctbProjeAdet.Size = new Size(92, 25);
            ctbProjeAdet.TabIndex = 12;
            ctbProjeAdet.TextCustom = "0";
            // 
            // lblProjeAdet
            // 
            lblProjeAdet.AutoSize = true;
            lblProjeAdet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProjeAdet.Location = new Point(514, 152);
            lblProjeAdet.Name = "lblProjeAdet";
            lblProjeAdet.Size = new Size(95, 15);
            lblProjeAdet.TabIndex = 86;
            lblProjeAdet.Text = "Proje 1Set Adet";
            // 
            // fcbBoyut
            // 
            fcbBoyut.BorderColor = Color.Silver;
            fcbBoyut.BorderRadius = 8;
            fcbBoyut.BorderSize = 1;
            fcbBoyut.DisplayMember = "ad";
            fcbBoyut.Font = new Font("Segoe UI", 8F);
            fcbBoyut.Location = new Point(650, 201);
            fcbBoyut.Margin = new Padding(1);
            fcbBoyut.Name = "fcbBoyut";
            fcbBoyut.Padding = new Padding(6, 4, 6, 4);
            fcbBoyut.PlaceholderText = "Seçiniz...";
            fcbBoyut.ReadOnly = false;
            fcbBoyut.Size = new Size(159, 25);
            fcbBoyut.TabIndex = 14;
            fcbBoyut.ValueMember = "Id";
            // 
            // ctxSagClickMenu
            // 
            ctxSagClickMenu.Items.AddRange(new ToolStripItem[] { stokGrupTanımlamaToolStripMenuItem, malzemeGrupTanımlarıToolStripMenuItem, malzemeAltGrupTanımlamaToolStripMenuItem, malzemeAltGrup2TanımlamaToolStripMenuItem });
            ctxSagClickMenu.Name = "contextMenuStrip1";
            ctxSagClickMenu.Size = new Size(227, 92);
            // 
            // stokGrupTanımlamaToolStripMenuItem
            // 
            stokGrupTanımlamaToolStripMenuItem.Name = "stokGrupTanımlamaToolStripMenuItem";
            stokGrupTanımlamaToolStripMenuItem.Size = new Size(226, 22);
            stokGrupTanımlamaToolStripMenuItem.Text = "Stok Grup Tanımları";
            stokGrupTanımlamaToolStripMenuItem.Click += stokGrupTanımlamaToolStripMenuItem_Click;
            // 
            // malzemeGrupTanımlarıToolStripMenuItem
            // 
            malzemeGrupTanımlarıToolStripMenuItem.Name = "malzemeGrupTanımlarıToolStripMenuItem";
            malzemeGrupTanımlarıToolStripMenuItem.Size = new Size(226, 22);
            malzemeGrupTanımlarıToolStripMenuItem.Text = "Malzeme Grup Tanımları";
            malzemeGrupTanımlarıToolStripMenuItem.Click += malzemeGrupTanımlarıToolStripMenuItem_Click;
            // 
            // malzemeAltGrupTanımlamaToolStripMenuItem
            // 
            malzemeAltGrupTanımlamaToolStripMenuItem.Name = "malzemeAltGrupTanımlamaToolStripMenuItem";
            malzemeAltGrupTanımlamaToolStripMenuItem.Size = new Size(226, 22);
            malzemeAltGrupTanımlamaToolStripMenuItem.Text = "Malzeme Alt Grup Tanımları";
            malzemeAltGrupTanımlamaToolStripMenuItem.Click += malzemeAltGrupTanımlamaToolStripMenuItem_Click;
            // 
            // malzemeAltGrup2TanımlamaToolStripMenuItem
            // 
            malzemeAltGrup2TanımlamaToolStripMenuItem.Name = "malzemeAltGrup2TanımlamaToolStripMenuItem";
            malzemeAltGrup2TanımlamaToolStripMenuItem.Size = new Size(226, 22);
            malzemeAltGrup2TanımlamaToolStripMenuItem.Text = "Malzeme Alt Grup2 Tanımları";
            malzemeAltGrup2TanımlamaToolStripMenuItem.Click += malzemeAltGrup2TanımlamaToolStripMenuItem_Click;
            // 
            // ctxMalzeme
            // 
            ctxMalzeme.Name = "ctxMalzeme";
            ctxMalzeme.Size = new Size(61, 4);
            // 
            // ctbTedarikciKod
            // 
            ctbTedarikciKod.BackColor = Color.White;
            ctbTedarikciKod.BorderColor = Color.Silver;
            ctbTedarikciKod.BorderFocusColor = Color.HotPink;
            ctbTedarikciKod.BorderSize = 1;
            ctbTedarikciKod.Font = new Font("Segoe UI", 8F);
            ctbTedarikciKod.ForeColor = Color.Black;
            ctbTedarikciKod.Location = new Point(113, 223);
            ctbTedarikciKod.Margin = new Padding(1);
            ctbTedarikciKod.Multiline = false;
            ctbTedarikciKod.Name = "ctbTedarikciKod";
            ctbTedarikciKod.Padding = new Padding(3);
            ctbTedarikciKod.PasswordChar = false;
            ctbTedarikciKod.PlaceholderColor = Color.DarkGray;
            ctbTedarikciKod.PlaceholderText = "";
            ctbTedarikciKod.ReadOnly = false;
            ctbTedarikciKod.SelectionStart = 0;
            ctbTedarikciKod.Size = new Size(262, 25);
            ctbTedarikciKod.TabIndex = 5;
            ctbTedarikciKod.TextAlignment = HorizontalAlignment.Left;
            ctbTedarikciKod.TextCustom = "";
            ctbTedarikciKod.UnderlinedStyle = false;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label30.Location = new Point(22, 229);
            label30.Name = "label30";
            label30.Size = new Size(89, 15);
            label30.TabIndex = 90;
            label30.Text = "Tedarikçi Kodu";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label31.Location = new Point(22, 67);
            label31.Name = "label31";
            label31.Size = new Size(74, 15);
            label31.TabIndex = 92;
            label31.Text = "Stok Kart Id";
            // 
            // ctbStokKartId
            // 
            ctbStokKartId.BackColor = Color.White;
            ctbStokKartId.BorderColor = Color.Silver;
            ctbStokKartId.BorderFocusColor = Color.HotPink;
            ctbStokKartId.BorderSize = 1;
            ctbStokKartId.Enabled = false;
            ctbStokKartId.Font = new Font("Segoe UI", 8F);
            ctbStokKartId.ForeColor = Color.Black;
            ctbStokKartId.Location = new Point(113, 62);
            ctbStokKartId.Margin = new Padding(1);
            ctbStokKartId.Multiline = false;
            ctbStokKartId.Name = "ctbStokKartId";
            ctbStokKartId.Padding = new Padding(3);
            ctbStokKartId.PasswordChar = false;
            ctbStokKartId.PlaceholderColor = Color.DarkGray;
            ctbStokKartId.PlaceholderText = "";
            ctbStokKartId.ReadOnly = false;
            ctbStokKartId.SelectionStart = 0;
            ctbStokKartId.Size = new Size(94, 25);
            ctbStokKartId.TabIndex = 91;
            ctbStokKartId.TextAlignment = HorizontalAlignment.Left;
            ctbStokKartId.TextCustom = "";
            ctbStokKartId.UnderlinedStyle = false;
            // 
            // ctbStokKartNo
            // 
            ctbStokKartNo.BackColor = Color.White;
            ctbStokKartNo.BorderColor = Color.Silver;
            ctbStokKartNo.BorderFocusColor = Color.HotPink;
            ctbStokKartNo.BorderSize = 1;
            ctbStokKartNo.Enabled = false;
            ctbStokKartNo.Font = new Font("Segoe UI", 8F);
            ctbStokKartNo.ForeColor = Color.Black;
            ctbStokKartNo.Location = new Point(113, 89);
            ctbStokKartNo.Margin = new Padding(1);
            ctbStokKartNo.Multiline = false;
            ctbStokKartNo.Name = "ctbStokKartNo";
            ctbStokKartNo.Padding = new Padding(3);
            ctbStokKartNo.PasswordChar = false;
            ctbStokKartNo.PlaceholderColor = Color.DarkGray;
            ctbStokKartNo.PlaceholderText = "";
            ctbStokKartNo.ReadOnly = false;
            ctbStokKartNo.SelectionStart = 0;
            ctbStokKartNo.Size = new Size(94, 25);
            ctbStokKartNo.TabIndex = 93;
            ctbStokKartNo.TextAlignment = HorizontalAlignment.Left;
            ctbStokKartNo.TextCustom = "";
            ctbStokKartNo.UnderlinedStyle = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(22, 94);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 94;
            label3.Text = "Stok Kart No";
            // 
            // chkTalasli
            // 
            chkTalasli.AutoSize = true;
            chkTalasli.Location = new Point(653, 258);
            chkTalasli.Name = "chkTalasli";
            chkTalasli.Size = new Size(57, 19);
            chkTalasli.TabIndex = 95;
            chkTalasli.Text = "Talaşlı";
            chkTalasli.UseVisualStyleBackColor = true;
            // 
            // chkBukum
            // 
            chkBukum.AutoSize = true;
            chkBukum.Location = new Point(653, 282);
            chkBukum.Name = "chkBukum";
            chkBukum.Size = new Size(64, 19);
            chkBukum.TabIndex = 96;
            chkBukum.Text = "Büküm";
            chkBukum.UseVisualStyleBackColor = true;
            // 
            // customButtonNewRecord1
            // 
            customButtonNewRecord1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            customButtonNewRecord1.BorderColor = Color.Black;
            customButtonNewRecord1.BorderSize = 0;
            customButtonNewRecord1.CornerRadius = 6;
            customButtonNewRecord1.ForeColor = Color.White;
            customButtonNewRecord1.GradientColor1 = Color.DodgerBlue;
            customButtonNewRecord1.GradientColor2 = Color.MidnightBlue;
            customButtonNewRecord1.HoverColor1 = Color.RoyalBlue;
            customButtonNewRecord1.HoverColor2 = Color.Navy;
            customButtonNewRecord1.Location = new Point(40, 624);
            customButtonNewRecord1.Margin = new Padding(0);
            customButtonNewRecord1.Name = "customButtonNewRecord1";
            customButtonNewRecord1.Size = new Size(36, 36);
            customButtonNewRecord1.TabIndex = 97;
            customButtonNewRecord1.Click += roundedButton1_Click;
            // 
            // roundedButton1
            // 
            roundedButton1.BackgroundColor = Color.Firebrick;
            roundedButton1.BorderColor = Color.Black;
            roundedButton1.BorderSize = 0;
            roundedButton1.CornerRadius = 10;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.ForeColor = Color.White;
            roundedButton1.GradientColor1 = Color.DodgerBlue;
            roundedButton1.GradientColor2 = Color.MidnightBlue;
            roundedButton1.HoverColor1 = Color.RoyalBlue;
            roundedButton1.HoverColor2 = Color.Navy;
            roundedButton1.Icon = null;
            roundedButton1.IconAlign = ContentAlignment.MiddleLeft;
            roundedButton1.Location = new Point(364, 624);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(111, 40);
            roundedButton1.TabIndex = 98;
            roundedButton1.Text = "Ham Excel Verisi";
            roundedButton1.TextColor = Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click_1;
            // 
            // ctb_internalReference
            // 
            ctb_internalReference.BackColor = Color.White;
            ctb_internalReference.BorderColor = Color.Silver;
            ctb_internalReference.BorderFocusColor = Color.HotPink;
            ctb_internalReference.BorderSize = 1;
            ctb_internalReference.Font = new Font("Segoe UI", 8F);
            ctb_internalReference.ForeColor = Color.Black;
            ctb_internalReference.Location = new Point(310, 35);
            ctb_internalReference.Margin = new Padding(1);
            ctb_internalReference.Multiline = false;
            ctb_internalReference.Name = "ctb_internalReference";
            ctb_internalReference.Padding = new Padding(3);
            ctb_internalReference.PasswordChar = false;
            ctb_internalReference.PlaceholderColor = Color.DarkGray;
            ctb_internalReference.PlaceholderText = "";
            ctb_internalReference.ReadOnly = false;
            ctb_internalReference.SelectionStart = 0;
            ctb_internalReference.Size = new Size(165, 25);
            ctb_internalReference.TabIndex = 99;
            ctb_internalReference.TextAlignment = HorizontalAlignment.Left;
            ctb_internalReference.TextCustom = "";
            ctb_internalReference.UnderlinedStyle = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(250, 42);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 100;
            label5.Text = "LOGO ID";
            // 
            // button1
            // 
            button1.Location = new Point(587, 636);
            button1.Name = "button1";
            button1.Size = new Size(76, 28);
            button1.TabIndex = 101;
            button1.Text = "Logo'ya Kaydet";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // StokKartKayitFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 698);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(ctb_internalReference);
            Controls.Add(roundedButton1);
            Controls.Add(customButtonNewRecord1);
            Controls.Add(chkBukum);
            Controls.Add(chkTalasli);
            Controls.Add(label3);
            Controls.Add(ctbStokKartNo);
            Controls.Add(label31);
            Controls.Add(ctbStokKartId);
            Controls.Add(label30);
            Controls.Add(ctbTedarikciKod);
            Controls.Add(fcbBoyut);
            Controls.Add(lblProjeAdet);
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
            Controls.Add(lblBoyut);
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
            Controls.Add(lblAgirlik);
            Controls.Add(panel1);
            Controls.Add(lblMalzemeAltGrup2);
            Controls.Add(lblMalzemeAltGrup);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(ctbAciklama);
            Controls.Add(ctbEtKalinlik);
            Controls.Add(lblEtKalinlik);
            Controls.Add(ctbUzunluk);
            Controls.Add(lblUzunluk);
            Controls.Add(ctbCap);
            Controls.Add(lblCap);
            Controls.Add(ctbYukseklik);
            Controls.Add(lblYukseklik);
            Controls.Add(ctbEn);
            Controls.Add(lblEn);
            Controls.Add(ctbBoy);
            Controls.Add(lblBoy);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(lblMalzemeGrup);
            Controls.Add(lblMalzemeStandart);
            Controls.Add(lblStokGrup);
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
            MouseClick += StokKartKayitFormu_MouseClick;
            ctxSagClickMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.Black, 1, ButtonBorderStyle.Solid,
                Color.Black, 1, ButtonBorderStyle.Solid,
                Color.Black, 1, ButtonBorderStyle.Solid,
                Color.Black, 1, ButtonBorderStyle.Solid);
        }
        private CustomControls.CustomTextBox ctbId;
        private CustomControls.CustomTextBox ctbKod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBox ctbStokAd;
        private System.Windows.Forms.Label lblStokGrup;
        private System.Windows.Forms.Label lblMalzemeStandart;
        private System.Windows.Forms.Label lblMalzemeGrup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBoy;
        private CustomControls.CustomTextBoxSayisal ctbBoy;
        private CustomControls.CustomTextBoxSayisal ctbEn;
        private System.Windows.Forms.Label lblEn;
        private CustomControls.CustomTextBoxSayisal ctbYukseklik;
        private System.Windows.Forms.Label lblYukseklik;
        private CustomControls.CustomTextBoxSayisal ctbCap;
        private System.Windows.Forms.Label lblCap;
        private CustomControls.CustomTextBoxSayisal ctbUzunluk;
        private System.Windows.Forms.Label lblUzunluk;
        private CustomControls.CustomTextBoxSayisal ctbEtKalinlik;
        private System.Windows.Forms.Label lblEtKalinlik;
        private System.Windows.Forms.Label label20;
        private CustomControls.CustomTextBox ctbAciklama;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblMalzemeAltGrup;
        private System.Windows.Forms.Label lblMalzemeAltGrup2;
        CustomDataGrid<DataControlStokKartDosya> customDataGrid;
        

        private System.Windows.Forms.Panel panel1;
        private CustomTextBoxSayisal ctbAgirlik;
        private Label lblAgirlik;
        private Label label12;
        private Label label13;
        private Label label22;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label lblBoyut;
        private CustomTextBox ctbBoyut;
        private CheckBox checkBoxIsSatinalma;
        private CheckBox checkBoxIsPdf;
        private CheckBox checkBoxIsFromExcel;
        private CheckBox checkBoxIsStep;
        private CheckBox checkBoxIsDxf;
        public HeaderPanel headerPanel1;
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
        private Label lblProjeAdet;
        private FilterableComboBox fcbBoyut;
        private ContextMenuStrip ctxSagClickMenu;
        private ToolStripMenuItem malzemeGrupTanımlarıToolStripMenuItem;
        private ContextMenuStrip ctxMalzeme;
        private ToolStripMenuItem stokGrupTanımlamaToolStripMenuItem;
        private ToolStripMenuItem malzemeAltGrupTanımlamaToolStripMenuItem;
        private ToolStripMenuItem malzemeAltGrup2TanımlamaToolStripMenuItem;
        private CustomTextBox ctbTedarikciKod;
        private Label label30;
        private Label label31;
        private CustomTextBox ctbStokKartId;
        private CustomTextBox ctbStokKartNo;
        private Label label3;
        private CheckBox chkTalasli;
        private CheckBox chkBukum;
        private CustomButtonNewRecord customButtonNewRecord1;
        private RoundedButton roundedButton1;
        private CustomTextBox ctb_internalReference;
        private Label label5;
        private Button button1;
    }
}