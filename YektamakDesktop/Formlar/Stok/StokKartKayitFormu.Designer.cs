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
            roundedButton1 = new RoundedButton();
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
            ctxSagClickMenu.SuspendLayout();
            SuspendLayout();
            // 
            // ctbId
            // 
            ctbId.BackColor = Color.White;
            ctbId.Enabled = false;
            ctbId.Font = new Font("Segoe UI", 9.5F);
            ctbId.ForeColor = Color.Black;
            ctbId.Location = new Point(113, 55);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new Padding(7, 5, 7, 5);
            ctbId.Size = new Size(94, 28);
            ctbId.TabIndex = 0;
            // 
            // ctbKod
            // 
            ctbKod.BackColor = Color.White;
            ctbKod.Font = new Font("Segoe UI", 9.5F);
            ctbKod.ForeColor = Color.Black;
            ctbKod.Location = new Point(113, 193);
            ctbKod.Multiline = false;
            ctbKod.Name = "ctbKod";
            ctbKod.Padding = new Padding(7, 5, 7, 5);
            ctbKod.Size = new Size(259, 28);
            ctbKod.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(20, 63);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 9;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(20, 200);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 10;
            label2.Text = "Parça Kodu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(20, 233);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 14;
            label4.Text = "Stok Adı";
            // 
            // ctbStokAd
            // 
            ctbStokAd.BackColor = Color.White;
            ctbStokAd.Font = new Font("Segoe UI", 9.5F);
            ctbStokAd.ForeColor = Color.Black;
            ctbStokAd.Location = new Point(113, 227);
            ctbStokAd.Multiline = false;
            ctbStokAd.Name = "ctbStokAd";
            ctbStokAd.Padding = new Padding(7, 5, 7, 5);
            ctbStokAd.Size = new Size(362, 28);
            ctbStokAd.TabIndex = 4;
            // 
            // lblStokGrup
            // 
            lblStokGrup.AutoSize = true;
            lblStokGrup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStokGrup.Location = new Point(526, 68);
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
            lblMalzemeStandart.Location = new Point(526, 326);
            lblMalzemeStandart.Name = "lblMalzemeStandart";
            lblMalzemeStandart.Size = new Size(76, 15);
            lblMalzemeStandart.TabIndex = 18;
            lblMalzemeStandart.Text = "Malzme Std.";
            // 
            // lblMalzemeGrup
            // 
            lblMalzemeGrup.AutoSize = true;
            lblMalzemeGrup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMalzemeGrup.Location = new Point(526, 121);
            lblMalzemeGrup.Name = "lblMalzemeGrup";
            lblMalzemeGrup.Size = new Size(96, 15);
            lblMalzemeGrup.TabIndex = 20;
            lblMalzemeGrup.Text = "Malzeme Grubu";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(20, 304);
            label8.Name = "label8";
            label8.Size = new Size(68, 15);
            label8.TabIndex = 22;
            label8.Text = "Ölçü Birimi";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(20, 165);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 24;
            label9.Text = "Proje Kodu";
            // 
            // lblBoy
            // 
            lblBoy.AutoSize = true;
            lblBoy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBoy.Location = new Point(774, 115);
            lblBoy.Name = "lblBoy";
            lblBoy.Size = new Size(28, 15);
            lblBoy.TabIndex = 34;
            lblBoy.Text = "Boy";
            // 
            // ctbBoy
            // 
            ctbBoy.BackColor = Color.White;
            ctbBoy.Font = new Font("Segoe UI", 9.5F);
            ctbBoy.ForeColor = Color.Black;
            ctbBoy.Location = new Point(774, 133);
            ctbBoy.Name = "ctbBoy";
            ctbBoy.OndalikBasamak = 0;
            ctbBoy.Padding = new Padding(10, 7, 10, 7);
            ctbBoy.Size = new Size(71, 32);
            ctbBoy.TabIndex = 16;
            ctbBoy.TextCustom = "0";
            // 
            // ctbEn
            // 
            ctbEn.BackColor = Color.White;
            ctbEn.Font = new Font("Segoe UI", 9.5F);
            ctbEn.ForeColor = Color.Black;
            ctbEn.Location = new Point(774, 186);
            ctbEn.Name = "ctbEn";
            ctbEn.OndalikBasamak = 0;
            ctbEn.Padding = new Padding(10, 7, 10, 7);
            ctbEn.Size = new Size(71, 32);
            ctbEn.TabIndex = 17;
            ctbEn.TextCustom = "0";
            // 
            // lblEn
            // 
            lblEn.AutoSize = true;
            lblEn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEn.Location = new Point(774, 168);
            lblEn.Name = "lblEn";
            lblEn.Size = new Size(20, 15);
            lblEn.TabIndex = 36;
            lblEn.Text = "En";
            // 
            // ctbYukseklik
            // 
            ctbYukseklik.BackColor = Color.White;
            ctbYukseklik.Font = new Font("Segoe UI", 9.5F);
            ctbYukseklik.ForeColor = Color.Black;
            ctbYukseklik.Location = new Point(774, 241);
            ctbYukseklik.Name = "ctbYukseklik";
            ctbYukseklik.OndalikBasamak = 0;
            ctbYukseklik.Padding = new Padding(10, 7, 10, 7);
            ctbYukseklik.Size = new Size(71, 32);
            ctbYukseklik.TabIndex = 18;
            ctbYukseklik.TextCustom = "0";
            // 
            // lblYukseklik
            // 
            lblYukseklik.AutoSize = true;
            lblYukseklik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblYukseklik.Location = new Point(774, 223);
            lblYukseklik.Name = "lblYukseklik";
            lblYukseklik.Size = new Size(59, 15);
            lblYukseklik.TabIndex = 38;
            lblYukseklik.Text = "Yükseklik";
            // 
            // ctbCap
            // 
            ctbCap.BackColor = Color.White;
            ctbCap.Font = new Font("Segoe UI", 9.5F);
            ctbCap.ForeColor = Color.Black;
            ctbCap.Location = new Point(774, 293);
            ctbCap.Name = "ctbCap";
            ctbCap.OndalikBasamak = 0;
            ctbCap.Padding = new Padding(10, 7, 10, 7);
            ctbCap.Size = new Size(71, 32);
            ctbCap.TabIndex = 19;
            ctbCap.TextCustom = "0";
            // 
            // lblCap
            // 
            lblCap.AutoSize = true;
            lblCap.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCap.Location = new Point(774, 275);
            lblCap.Name = "lblCap";
            lblCap.Size = new Size(27, 15);
            lblCap.TabIndex = 40;
            lblCap.Text = "Çap";
            // 
            // ctbUzunluk
            // 
            ctbUzunluk.BackColor = Color.White;
            ctbUzunluk.Font = new Font("Segoe UI", 9.5F);
            ctbUzunluk.ForeColor = Color.Black;
            ctbUzunluk.Location = new Point(774, 353);
            ctbUzunluk.Name = "ctbUzunluk";
            ctbUzunluk.OndalikBasamak = 0;
            ctbUzunluk.Padding = new Padding(10, 7, 10, 7);
            ctbUzunluk.Size = new Size(71, 32);
            ctbUzunluk.TabIndex = 20;
            ctbUzunluk.TextCustom = "0";
            // 
            // lblUzunluk
            // 
            lblUzunluk.AutoSize = true;
            lblUzunluk.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUzunluk.Location = new Point(774, 335);
            lblUzunluk.Name = "lblUzunluk";
            lblUzunluk.Size = new Size(53, 15);
            lblUzunluk.TabIndex = 42;
            lblUzunluk.Text = "Uzunluk";
            // 
            // ctbEtKalinlik
            // 
            ctbEtKalinlik.BackColor = Color.White;
            ctbEtKalinlik.Font = new Font("Segoe UI", 9.5F);
            ctbEtKalinlik.ForeColor = Color.Black;
            ctbEtKalinlik.Location = new Point(774, 413);
            ctbEtKalinlik.Name = "ctbEtKalinlik";
            ctbEtKalinlik.OndalikBasamak = 0;
            ctbEtKalinlik.Padding = new Padding(10, 7, 10, 7);
            ctbEtKalinlik.Size = new Size(71, 32);
            ctbEtKalinlik.TabIndex = 21;
            ctbEtKalinlik.TextCustom = "0";
            // 
            // lblEtKalinlik
            // 
            lblEtKalinlik.AutoSize = true;
            lblEtKalinlik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEtKalinlik.Location = new Point(774, 395);
            lblEtKalinlik.Name = "lblEtKalinlik";
            lblEtKalinlik.Size = new Size(64, 15);
            lblEtKalinlik.TabIndex = 44;
            lblEtKalinlik.Text = "Et Kalınlığı";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label20.Location = new Point(22, 338);
            label20.Name = "label20";
            label20.Size = new Size(57, 15);
            label20.TabIndex = 47;
            label20.Text = "Açıklama";
            // 
            // ctbAciklama
            // 
            ctbAciklama.BackColor = Color.White;
            ctbAciklama.Font = new Font("Segoe UI", 9.5F);
            ctbAciklama.ForeColor = Color.Black;
            ctbAciklama.Location = new Point(113, 330);
            ctbAciklama.Multiline = true;
            ctbAciklama.Name = "ctbAciklama";
            ctbAciklama.Padding = new Padding(7, 5, 7, 5);
            ctbAciklama.Size = new Size(362, 60);
            ctbAciklama.TabIndex = 7;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label21.Location = new Point(20, 130);
            label21.Name = "label21";
            label21.Size = new Size(56, 15);
            label21.TabIndex = 49;
            label21.Text = "Stok Tipi";
            // 
            // lblMalzemeAltGrup
            // 
            lblMalzemeAltGrup.AutoSize = true;
            lblMalzemeAltGrup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMalzemeAltGrup.Location = new Point(526, 173);
            lblMalzemeAltGrup.Name = "lblMalzemeAltGrup";
            lblMalzemeAltGrup.Size = new Size(115, 15);
            lblMalzemeAltGrup.TabIndex = 54;
            lblMalzemeAltGrup.Text = "Malzeme Alt Grubu";
            // 
            // lblMalzemeAltGrup2
            // 
            lblMalzemeAltGrup2.AutoSize = true;
            lblMalzemeAltGrup2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMalzemeAltGrup2.Location = new Point(526, 225);
            lblMalzemeAltGrup2.Name = "lblMalzemeAltGrup2";
            lblMalzemeAltGrup2.Size = new Size(125, 15);
            lblMalzemeAltGrup2.TabIndex = 56;
            lblMalzemeAltGrup2.Text = "Malzeme Alt Grubu 2";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(20, 462);
            panel1.Name = "panel1";
            panel1.Size = new Size(785, 207);
            panel1.TabIndex = 57;
            // 
            // ctbAgirlik
            // 
            ctbAgirlik.BackColor = Color.White;
            ctbAgirlik.Font = new Font("Segoe UI", 9.5F);
            ctbAgirlik.ForeColor = Color.Black;
            ctbAgirlik.Location = new Point(774, 83);
            ctbAgirlik.Name = "ctbAgirlik";
            ctbAgirlik.OndalikBasamak = 0;
            ctbAgirlik.Padding = new Padding(10, 7, 10, 7);
            ctbAgirlik.Size = new Size(71, 32);
            ctbAgirlik.TabIndex = 15;
            ctbAgirlik.TextCustom = "0";
            // 
            // lblAgirlik
            // 
            lblAgirlik.AutoSize = true;
            lblAgirlik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAgirlik.Location = new Point(774, 65);
            lblAgirlik.Name = "lblAgirlik";
            lblAgirlik.Size = new Size(43, 15);
            lblAgirlik.TabIndex = 58;
            lblAgirlik.Text = "Ağırlık";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(20, 444);
            label11.Name = "label11";
            label11.Size = new Size(54, 15);
            label11.TabIndex = 60;
            label11.Text = "Dosyalar";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(849, 94);
            label12.Name = "label12";
            label12.Size = new Size(20, 15);
            label12.TabIndex = 61;
            label12.Text = "kg";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(849, 136);
            label13.Name = "label13";
            label13.Size = new Size(29, 15);
            label13.TabIndex = 62;
            label13.Text = "mm";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(849, 198);
            label22.Name = "label22";
            label22.Size = new Size(29, 15);
            label22.TabIndex = 63;
            label22.Text = "mm";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(849, 253);
            label25.Name = "label25";
            label25.Size = new Size(29, 15);
            label25.TabIndex = 64;
            label25.Text = "mm";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(849, 305);
            label26.Name = "label26";
            label26.Size = new Size(29, 15);
            label26.TabIndex = 65;
            label26.Text = "mm";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(849, 365);
            label27.Name = "label27";
            label27.Size = new Size(29, 15);
            label27.TabIndex = 66;
            label27.Text = "mm";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(849, 425);
            label28.Name = "label28";
            label28.Size = new Size(29, 15);
            label28.TabIndex = 67;
            label28.Text = "mm";
            // 
            // lblBoyut
            // 
            lblBoyut.AutoSize = true;
            lblBoyut.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBoyut.Location = new Point(526, 376);
            lblBoyut.Name = "lblBoyut";
            lblBoyut.Size = new Size(40, 15);
            lblBoyut.TabIndex = 69;
            lblBoyut.Text = "Boyut";
            // 
            // ctbBoyut
            // 
            ctbBoyut.BackColor = Color.White;
            ctbBoyut.Enabled = false;
            ctbBoyut.Font = new Font("Segoe UI", 9.5F);
            ctbBoyut.ForeColor = Color.Black;
            ctbBoyut.Location = new Point(526, 428);
            ctbBoyut.Multiline = false;
            ctbBoyut.Name = "ctbBoyut";
            ctbBoyut.Padding = new Padding(7, 5, 7, 5);
            ctbBoyut.Size = new Size(185, 28);
            ctbBoyut.TabIndex = 22;
            // 
            // checkBoxIsSatinalma
            // 
            checkBoxIsSatinalma.AutoSize = true;
            checkBoxIsSatinalma.Location = new Point(12, 36);
            checkBoxIsSatinalma.Name = "checkBoxIsSatinalma";
            checkBoxIsSatinalma.Size = new Size(15, 14);
            checkBoxIsSatinalma.TabIndex = 70;
            checkBoxIsSatinalma.UseVisualStyleBackColor = true;
            checkBoxIsSatinalma.Visible = false;
            // 
            // checkBoxIsPdf
            // 
            checkBoxIsPdf.AutoSize = true;
            checkBoxIsPdf.Location = new Point(33, 36);
            checkBoxIsPdf.Name = "checkBoxIsPdf";
            checkBoxIsPdf.Size = new Size(15, 14);
            checkBoxIsPdf.TabIndex = 71;
            checkBoxIsPdf.UseVisualStyleBackColor = true;
            checkBoxIsPdf.Visible = false;
            // 
            // checkBoxIsFromExcel
            // 
            checkBoxIsFromExcel.AutoSize = true;
            checkBoxIsFromExcel.Location = new Point(54, 36);
            checkBoxIsFromExcel.Name = "checkBoxIsFromExcel";
            checkBoxIsFromExcel.Size = new Size(15, 14);
            checkBoxIsFromExcel.TabIndex = 72;
            checkBoxIsFromExcel.UseVisualStyleBackColor = true;
            checkBoxIsFromExcel.Visible = false;
            // 
            // checkBoxIsStep
            // 
            checkBoxIsStep.AutoSize = true;
            checkBoxIsStep.Location = new Point(75, 36);
            checkBoxIsStep.Name = "checkBoxIsStep";
            checkBoxIsStep.Size = new Size(15, 14);
            checkBoxIsStep.TabIndex = 73;
            checkBoxIsStep.UseVisualStyleBackColor = true;
            checkBoxIsStep.Visible = false;
            // 
            // checkBoxIsDxf
            // 
            checkBoxIsDxf.AutoSize = true;
            checkBoxIsDxf.Location = new Point(102, 36);
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
            headerPanel1.Size = new Size(946, 32);
            headerPanel1.TabIndex = 75;
            // 
            // rButtonKaydet
            // 
            rButtonKaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            rButtonKaydet.BackColor = Color.Transparent;
            rButtonKaydet.Location = new Point(811, 623);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new Size(106, 46);
            rButtonKaydet.TabIndex = 76;
            rButtonKaydet.SaveButtonClick += rButtonKaydet_Click;
            // 
            // clbProjeKod
            // 
            clbProjeKod.BorderColor = Color.Silver;
            clbProjeKod.BorderSize = 1;
            clbProjeKod.DisplayMember = "kod";
            clbProjeKod.Location = new Point(113, 158);
            clbProjeKod.Name = "clbProjeKod";
            clbProjeKod.Padding = new Padding(7, 5, 7, 5);
            clbProjeKod.PlaceholderText = "Seçiniz...";
            clbProjeKod.Size = new Size(161, 29);
            clbProjeKod.TabIndex = 2;
            clbProjeKod.ValueMember = "Id";
            clbProjeKod.SelectedIndexChanged += clbProjeKod_SelectedIndexChanged;
            // 
            // clbStokTip
            // 
            clbStokTip.BorderColor = Color.Silver;
            clbStokTip.BorderSize = 1;
            clbStokTip.DisplayMember = "ad";
            clbStokTip.Location = new Point(113, 123);
            clbStokTip.Name = "clbStokTip";
            clbStokTip.Padding = new Padding(7, 5, 7, 5);
            clbStokTip.PlaceholderText = "Seçiniz...";
            clbStokTip.Size = new Size(161, 29);
            clbStokTip.TabIndex = 1;
            clbStokTip.ValueMember = "Id";
            clbStokTip.SelectedIndexChanged += clbStokTip_SelectedIndexChanged;
            // 
            // clbOlcuBirim
            // 
            clbOlcuBirim.BorderColor = Color.Silver;
            clbOlcuBirim.BorderSize = 1;
            clbOlcuBirim.DisplayMember = "ad";
            clbOlcuBirim.Location = new Point(113, 295);
            clbOlcuBirim.Name = "clbOlcuBirim";
            clbOlcuBirim.Padding = new Padding(7, 5, 7, 5);
            clbOlcuBirim.PlaceholderText = "Seçiniz...";
            clbOlcuBirim.Size = new Size(119, 29);
            clbOlcuBirim.TabIndex = 6;
            clbOlcuBirim.ValueMember = "Id";
            // 
            // clbMalzemeStandart
            // 
            clbMalzemeStandart.BorderColor = Color.Silver;
            clbMalzemeStandart.BorderSize = 1;
            clbMalzemeStandart.DisplayMember = "ad";
            clbMalzemeStandart.Location = new Point(526, 344);
            clbMalzemeStandart.Name = "clbMalzemeStandart";
            clbMalzemeStandart.Padding = new Padding(7, 5, 7, 5);
            clbMalzemeStandart.PlaceholderText = "Seçiniz...";
            clbMalzemeStandart.Size = new Size(185, 29);
            clbMalzemeStandart.TabIndex = 13;
            clbMalzemeStandart.ValueMember = "Id";
            // 
            // clbStokGrup
            // 
            clbStokGrup.BorderColor = Color.Silver;
            clbStokGrup.BorderSize = 1;
            clbStokGrup.DisplayMember = "ad";
            clbStokGrup.Location = new Point(526, 86);
            clbStokGrup.Name = "clbStokGrup";
            clbStokGrup.Padding = new Padding(7, 5, 7, 5);
            clbStokGrup.PlaceholderText = "Seçiniz...";
            clbStokGrup.Size = new Size(185, 29);
            clbStokGrup.TabIndex = 8;
            clbStokGrup.ValueMember = "Id";
            clbStokGrup.SelectedIndexChanged += cbxStokGrup_SelectedIndexChanged;
            // 
            // clbMalzemeGrup
            // 
            clbMalzemeGrup.BorderColor = Color.Silver;
            clbMalzemeGrup.BorderSize = 1;
            clbMalzemeGrup.DisplayMember = "ad";
            clbMalzemeGrup.Location = new Point(526, 139);
            clbMalzemeGrup.Name = "clbMalzemeGrup";
            clbMalzemeGrup.Padding = new Padding(7, 5, 7, 5);
            clbMalzemeGrup.PlaceholderText = "Seçiniz...";
            clbMalzemeGrup.Size = new Size(185, 29);
            clbMalzemeGrup.TabIndex = 9;
            clbMalzemeGrup.ValueMember = "Id";
            clbMalzemeGrup.SelectedIndexChanged += cbxMalzemeGrup_SelectedIndexChanged;
            clbMalzemeGrup.MouseClick += clbMalzemeGrup_MouseClick;
            // 
            // clbMalzemeAltGrup
            // 
            clbMalzemeAltGrup.BorderColor = Color.Silver;
            clbMalzemeAltGrup.BorderSize = 1;
            clbMalzemeAltGrup.DisplayMember = "ad";
            clbMalzemeAltGrup.Location = new Point(526, 191);
            clbMalzemeAltGrup.Name = "clbMalzemeAltGrup";
            clbMalzemeAltGrup.Padding = new Padding(7, 5, 7, 5);
            clbMalzemeAltGrup.PlaceholderText = "Seçiniz...";
            clbMalzemeAltGrup.Size = new Size(185, 29);
            clbMalzemeAltGrup.TabIndex = 10;
            clbMalzemeAltGrup.ValueMember = "Id";
            clbMalzemeAltGrup.SelectedIndexChanged += cbxMalzemeAltGrup_SelectedIndexChanged;
            // 
            // clbMalzemeAltGrup2
            // 
            clbMalzemeAltGrup2.BorderColor = Color.Silver;
            clbMalzemeAltGrup2.BorderSize = 1;
            clbMalzemeAltGrup2.DisplayMember = "ad";
            clbMalzemeAltGrup2.Location = new Point(526, 243);
            clbMalzemeAltGrup2.Name = "clbMalzemeAltGrup2";
            clbMalzemeAltGrup2.Padding = new Padding(7, 5, 7, 5);
            clbMalzemeAltGrup2.PlaceholderText = "Seçiniz...";
            clbMalzemeAltGrup2.Size = new Size(185, 29);
            clbMalzemeAltGrup2.TabIndex = 11;
            clbMalzemeAltGrup2.ValueMember = "Id";
            // 
            // ctbProjeAdet
            // 
            ctbProjeAdet.BackColor = Color.White;
            ctbProjeAdet.Font = new Font("Segoe UI", 9.5F);
            ctbProjeAdet.ForeColor = Color.Black;
            ctbProjeAdet.Location = new Point(526, 297);
            ctbProjeAdet.Name = "ctbProjeAdet";
            ctbProjeAdet.OndalikBasamak = 0;
            ctbProjeAdet.Padding = new Padding(7, 5, 7, 5);
            ctbProjeAdet.Size = new Size(92, 26);
            ctbProjeAdet.TabIndex = 12;
            ctbProjeAdet.TextCustom = "0";
            // 
            // lblProjeAdet
            // 
            lblProjeAdet.AutoSize = true;
            lblProjeAdet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProjeAdet.Location = new Point(526, 279);
            lblProjeAdet.Name = "lblProjeAdet";
            lblProjeAdet.Size = new Size(95, 15);
            lblProjeAdet.TabIndex = 86;
            lblProjeAdet.Text = "Proje 1Set Adet";
            // 
            // fcbBoyut
            // 
            fcbBoyut.BorderColor = Color.Silver;
            fcbBoyut.BorderSize = 1;
            fcbBoyut.DisplayMember = "ad";
            fcbBoyut.Location = new Point(526, 394);
            fcbBoyut.Name = "fcbBoyut";
            fcbBoyut.Padding = new Padding(7, 5, 7, 5);
            fcbBoyut.PlaceholderText = "Seçiniz...";
            fcbBoyut.Size = new Size(185, 29);
            fcbBoyut.TabIndex = 14;
            fcbBoyut.ValueMember = "Id";
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.ForeColor = Color.White;
            roundedButton1.Location = new Point(811, 484);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(117, 40);
            roundedButton1.TabIndex = 88;
            roundedButton1.Text = "YENİ KAYIT";
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click;
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
            ctbTedarikciKod.BackColor = SystemColors.Window;
            ctbTedarikciKod.Font = new Font("Segoe UI", 9.5F);
            ctbTedarikciKod.ForeColor = Color.DimGray;
            ctbTedarikciKod.Location = new Point(113, 261);
            ctbTedarikciKod.Multiline = false;
            ctbTedarikciKod.Name = "ctbTedarikciKod";
            ctbTedarikciKod.Padding = new Padding(7, 5, 7, 5);
            ctbTedarikciKod.Size = new Size(262, 28);
            ctbTedarikciKod.TabIndex = 5;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label30.Location = new Point(20, 268);
            label30.Name = "label30";
            label30.Size = new Size(89, 15);
            label30.TabIndex = 90;
            label30.Text = "Tedarikçi Kodu";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label31.Location = new Point(20, 97);
            label31.Name = "label31";
            label31.Size = new Size(74, 15);
            label31.TabIndex = 92;
            label31.Text = "Stok Kart Id";
            // 
            // ctbStokKartId
            // 
            ctbStokKartId.BackColor = Color.White;
            ctbStokKartId.Enabled = false;
            ctbStokKartId.Font = new Font("Segoe UI", 9.5F);
            ctbStokKartId.ForeColor = Color.Black;
            ctbStokKartId.Location = new Point(113, 89);
            ctbStokKartId.Multiline = false;
            ctbStokKartId.Name = "ctbStokKartId";
            ctbStokKartId.Padding = new Padding(7, 5, 7, 5);
            ctbStokKartId.Size = new Size(94, 28);
            ctbStokKartId.TabIndex = 91;
            // 
            // StokKartKayitFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 681);
            Controls.Add(label31);
            Controls.Add(ctbStokKartId);
            Controls.Add(label30);
            Controls.Add(ctbTedarikciKod);
            Controls.Add(roundedButton1);
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
                if (!String.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(jsonResult);
                }
            }
            private async void ButtonDosyaGoruntule_Click(object sender, EventArgs e)
            {
                if(string.IsNullOrWhiteSpace(stokKartIdControl.TextCustom))
                    return;
                StokKart stokKart = new StokKart() { Id = int.Parse(stokKartIdControl.TextCustom) };
                string jsonResult = await _stokService.GetStokKartPdf(stokKart);
                if (!String.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    stokKart = JsonConvert.DeserializeObject<List<StokKart>>(jsonResult)[0];
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
        private Label lblProjeAdet;
        private FilterableComboBox fcbBoyut;
        private RoundedButton roundedButton1;
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
    }
}