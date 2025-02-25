using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Yetkilendirme;
using Models;
using YektamakDesktop.Properties;

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

namespace YektamakDesktop.Formlar.Satis
{
    partial class SatisSiparisTeklifTalepKayitFormu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatisSiparisTeklifTalepKayitFormu));
            textBoxTeklifTalepTarihi = new CustomTextBoxTarih();
            label14 = new Label();
            label15 = new Label();
            comboListBoxSatisSorumlusu = new CustomComboListBox();
            label7 = new Label();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboListBoxMarka = new CustomComboListBox();
            comboListBoxMusteri = new CustomComboListBox();
            textBoxTeklifKonusu = new CustomTextBox();
            comboListBoxAltGrup = new CustomComboListBox();
            label9 = new Label();
            label10 = new Label();
            comboListBoxReferansKaynagi = new CustomComboListBox();
            label11 = new Label();
            label12 = new Label();
            panelHeader = new Panel();
            buttonClose = new RoundedButton();
            buttomMinimize = new RoundedButton();
            btnClose = new RoundedButton();
            roundedButton6 = new RoundedButton();
            btnMinimize = new RoundedButton();
            roundedButton3 = new RoundedButton();
            bntHelp = new RoundedButton();
            label13 = new Label();
            roundedButton1 = new RoundedButton();
            roundedButton2 = new RoundedButton();
            buttonKaydet = new RoundedButton();
            panel2 = new Panel();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxTeklifTalepTarihi
            // 
            textBoxTeklifTalepTarihi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            textBoxTeklifTalepTarihi.Location = new Point(234, 115);
            textBoxTeklifTalepTarihi.Margin = new Padding(1);
            textBoxTeklifTalepTarihi.Name = "textBoxTeklifTalepTarihi";
            textBoxTeklifTalepTarihi.Padding = new Padding(1);
            textBoxTeklifTalepTarihi.Size = new Size(134, 32);
            textBoxTeklifTalepTarihi.TabIndex = 83;
            textBoxTeklifTalepTarihi.TextCustom = "";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(209, 237);
            label14.Name = "label14";
            label14.Size = new Size(13, 20);
            label14.TabIndex = 64;
            label14.Text = ":";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(93, 238);
            label15.Name = "label15";
            label15.Size = new Size(48, 19);
            label15.TabIndex = 63;
            label15.Text = "Marka";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboListBoxSatisSorumlusu
            // 
            comboListBoxSatisSorumlusu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboListBoxSatisSorumlusu.ListBoxVisualSize = 5;
            comboListBoxSatisSorumlusu.Location = new Point(234, 351);
            comboListBoxSatisSorumlusu.Margin = new Padding(1);
            comboListBoxSatisSorumlusu.Name = "comboListBoxSatisSorumlusu";
            comboListBoxSatisSorumlusu.Padding = new Padding(1);
            comboListBoxSatisSorumlusu.Size = new Size(251, 36);
            comboListBoxSatisSorumlusu.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(209, 156);
            label7.Name = "label7";
            label7.Size = new Size(13, 20);
            label7.TabIndex = 10;
            label7.Text = ":";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(90, 157);
            label8.Name = "label8";
            label8.Size = new Size(57, 19);
            label8.TabIndex = 9;
            label8.Text = "Müşteri";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(209, 114);
            label6.Name = "label6";
            label6.Size = new Size(13, 20);
            label6.TabIndex = 7;
            label6.Text = ":";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(90, 115);
            label5.Name = "label5";
            label5.Size = new Size(81, 19);
            label5.TabIndex = 6;
            label5.Text = "Talep Tarihi";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(209, 199);
            label3.Name = "label3";
            label3.Size = new Size(13, 20);
            label3.TabIndex = 3;
            label3.Text = ":";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(90, 200);
            label4.Name = "label4";
            label4.Size = new Size(94, 19);
            label4.TabIndex = 2;
            label4.Text = "Teklif Konusu";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(209, 351);
            label2.Name = "label2";
            label2.Size = new Size(13, 20);
            label2.TabIndex = 1;
            label2.Text = ":";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(93, 352);
            label1.Name = "label1";
            label1.Size = new Size(110, 19);
            label1.TabIndex = 1;
            label1.Text = "Satış Sorumlusu";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboListBoxMarka
            // 
            comboListBoxMarka.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboListBoxMarka.ListBoxVisualSize = 5;
            comboListBoxMarka.Location = new Point(234, 237);
            comboListBoxMarka.Margin = new Padding(1);
            comboListBoxMarka.Name = "comboListBoxMarka";
            comboListBoxMarka.Padding = new Padding(1);
            comboListBoxMarka.Size = new Size(251, 36);
            comboListBoxMarka.TabIndex = 87;
            // 
            // comboListBoxMusteri
            // 
            comboListBoxMusteri.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboListBoxMusteri.ListBoxVisualSize = 5;
            comboListBoxMusteri.Location = new Point(234, 159);
            comboListBoxMusteri.Margin = new Padding(1);
            comboListBoxMusteri.Name = "comboListBoxMusteri";
            comboListBoxMusteri.Padding = new Padding(1);
            comboListBoxMusteri.Size = new Size(538, 36);
            comboListBoxMusteri.TabIndex = 88;
            // 
            // textBoxTeklifKonusu
            // 
            textBoxTeklifKonusu.BackColor = Color.White;
            textBoxTeklifKonusu.BorderColor = Color.Silver;
            textBoxTeklifKonusu.BorderFocusColor = Color.HotPink;
            textBoxTeklifKonusu.BorderRadius = 5;
            textBoxTeklifKonusu.BorderSize = 1;
            textBoxTeklifKonusu.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTeklifKonusu.ForeColor = Color.Black;
            textBoxTeklifKonusu.isPlaceHolder = false;
            textBoxTeklifKonusu.Location = new Point(234, 199);
            textBoxTeklifKonusu.Multiline = false;
            textBoxTeklifKonusu.Name = "textBoxTeklifKonusu";
            textBoxTeklifKonusu.Padding = new Padding(10, 7, 10, 7);
            textBoxTeklifKonusu.PasswordChar = false;
            textBoxTeklifKonusu.PlaceholderColor = Color.DarkGray;
            textBoxTeklifKonusu.PlaceholderText = "";
            textBoxTeklifKonusu.ReadOnly = false;
            textBoxTeklifKonusu.SelectionStart = 0;
            textBoxTeklifKonusu.Size = new Size(538, 32);
            textBoxTeklifKonusu.TabIndex = 89;
            textBoxTeklifKonusu.TextAlignment = HorizontalAlignment.Left;
            textBoxTeklifKonusu.TextCustom = "";
            textBoxTeklifKonusu.UnderlinedStyle = false;
            // 
            // comboListBoxAltGrup
            // 
            comboListBoxAltGrup.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboListBoxAltGrup.ListBoxVisualSize = 5;
            comboListBoxAltGrup.Location = new Point(234, 275);
            comboListBoxAltGrup.Margin = new Padding(1);
            comboListBoxAltGrup.Name = "comboListBoxAltGrup";
            comboListBoxAltGrup.Padding = new Padding(1);
            comboListBoxAltGrup.Size = new Size(251, 36);
            comboListBoxAltGrup.TabIndex = 92;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(209, 275);
            label9.Name = "label9";
            label9.Size = new Size(13, 20);
            label9.TabIndex = 91;
            label9.Text = ":";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(93, 276);
            label10.Name = "label10";
            label10.Size = new Size(62, 19);
            label10.TabIndex = 90;
            label10.Text = "Alt Grup";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboListBoxReferansKaynagi
            // 
            comboListBoxReferansKaynagi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboListBoxReferansKaynagi.ListBoxVisualSize = 5;
            comboListBoxReferansKaynagi.Location = new Point(234, 313);
            comboListBoxReferansKaynagi.Margin = new Padding(1);
            comboListBoxReferansKaynagi.Name = "comboListBoxReferansKaynagi";
            comboListBoxReferansKaynagi.Padding = new Padding(1);
            comboListBoxReferansKaynagi.Size = new Size(251, 36);
            comboListBoxReferansKaynagi.TabIndex = 95;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(209, 313);
            label11.Name = "label11";
            label11.Size = new Size(13, 20);
            label11.TabIndex = 94;
            label11.Text = ":";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(93, 314);
            label12.Name = "label12";
            label12.Size = new Size(117, 19);
            label12.TabIndex = 93;
            label12.Text = "Referans Kaynağı";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelHeader
            // 
            panelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelHeader.BackColor = Color.Firebrick;
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(roundedButton6);
            panelHeader.Controls.Add(btnMinimize);
            panelHeader.Controls.Add(roundedButton3);
            panelHeader.Controls.Add(bntHelp);
            panelHeader.Controls.Add(label13);
            panelHeader.Controls.Add(roundedButton1);
            panelHeader.Controls.Add(roundedButton2);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(788, 32);
            panelHeader.TabIndex = 96;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClose.BackColor = Color.Firebrick;
            buttonClose.BackgroundColor = Color.Firebrick;
            buttonClose.BorderColor = Color.Firebrick;
            buttonClose.BorderRadius = 10;
            buttonClose.BorderSize = 2;
            buttonClose.Cursor = Cursors.Hand;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClose.ForeColor = Color.White;
            buttonClose.Location = new Point(750, 1);
            buttonClose.Margin = new Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new Padding(3, 0, 0, 0);
            buttonClose.Size = new Size(29, 27);
            buttonClose.TabIndex = 106;
            buttonClose.Text = "X";
            buttonClose.TextColor = Color.White;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttomMinimize
            // 
            buttomMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttomMinimize.BackColor = Color.Firebrick;
            buttomMinimize.BackgroundColor = Color.Firebrick;
            buttomMinimize.BorderColor = Color.Firebrick;
            buttomMinimize.BorderRadius = 10;
            buttomMinimize.BorderSize = 2;
            buttomMinimize.Cursor = Cursors.Hand;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = FlatStyle.Flat;
            buttomMinimize.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttomMinimize.ForeColor = Color.White;
            buttomMinimize.Location = new Point(710, 1);
            buttomMinimize.Margin = new Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new Padding(3, 0, 0, 0);
            buttomMinimize.Size = new Size(29, 27);
            buttomMinimize.TabIndex = 104;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
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
            btnClose.Location = new Point(1400, 2);
            btnClose.Margin = new Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(3, 0, 0, 0);
            btnClose.Size = new Size(29, 27);
            btnClose.TabIndex = 103;
            btnClose.Text = "X";
            btnClose.TextColor = Color.White;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // roundedButton6
            // 
            roundedButton6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roundedButton6.BackColor = Color.Firebrick;
            roundedButton6.BackgroundColor = Color.Firebrick;
            roundedButton6.BorderColor = Color.Firebrick;
            roundedButton6.BorderRadius = 10;
            roundedButton6.BorderSize = 2;
            roundedButton6.Cursor = Cursors.Hand;
            roundedButton6.FlatAppearance.BorderSize = 0;
            roundedButton6.FlatStyle = FlatStyle.Flat;
            roundedButton6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            roundedButton6.ForeColor = Color.White;
            roundedButton6.Location = new Point(670, 1);
            roundedButton6.Margin = new Padding(0);
            roundedButton6.Name = "roundedButton6";
            roundedButton6.Padding = new Padding(3, 0, 0, 0);
            roundedButton6.Size = new Size(29, 27);
            roundedButton6.TabIndex = 105;
            roundedButton6.Text = "?";
            roundedButton6.TextColor = Color.White;
            roundedButton6.UseVisualStyleBackColor = false;
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
            btnMinimize.Location = new Point(1360, 2);
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
            roundedButton3.Location = new Point(2487, 1);
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
            bntHelp.Location = new Point(1320, 2);
            bntHelp.Margin = new Padding(0);
            bntHelp.Name = "bntHelp";
            bntHelp.Padding = new Padding(3, 0, 0, 0);
            bntHelp.Size = new Size(29, 27);
            bntHelp.TabIndex = 102;
            bntHelp.Text = "?";
            bntHelp.TextColor = Color.White;
            bntHelp.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = SystemColors.ControlLightLight;
            label13.Location = new Point(12, 6);
            label13.Name = "label13";
            label13.Size = new Size(201, 17);
            label13.TabIndex = 1;
            label13.Text = "Satış Sipariş Teklif Talep Formu";
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
            roundedButton1.Location = new Point(2447, 1);
            roundedButton1.Margin = new Padding(0);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new Padding(3, 0, 0, 0);
            roundedButton1.Size = new Size(29, 27);
            roundedButton1.TabIndex = 98;
            roundedButton1.Text = "-";
            roundedButton1.TextColor = Color.White;
            roundedButton1.UseVisualStyleBackColor = false;
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
            roundedButton2.Location = new Point(2407, 1);
            roundedButton2.Margin = new Padding(0);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Padding = new Padding(3, 0, 0, 0);
            roundedButton2.Size = new Size(29, 27);
            roundedButton2.TabIndex = 99;
            roundedButton2.Text = "?";
            roundedButton2.TextColor = Color.White;
            roundedButton2.UseVisualStyleBackColor = false;
            // 
            // buttonKaydet
            // 
            buttonKaydet.BackColor = Color.Transparent;
            buttonKaydet.BackgroundColor = Color.Transparent;
            buttonKaydet.BorderColor = Color.MediumSeaGreen;
            buttonKaydet.BorderRadius = 20;
            buttonKaydet.BorderSize = 2;
            buttonKaydet.Cursor = Cursors.Hand;
            buttonKaydet.FlatAppearance.BorderSize = 0;
            buttonKaydet.FlatStyle = FlatStyle.Flat;
            buttonKaydet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonKaydet.ForeColor = Color.White;
            buttonKaydet.Image = Resources.kaydet;
            buttonKaydet.Location = new Point(725, 725);
            buttonKaydet.Name = "buttonKaydet";
            buttonKaydet.Size = new Size(47, 49);
            buttonKaydet.TabIndex = 107;
            buttonKaydet.TextColor = Color.White;
            buttonKaydet.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonKaydet.UseCompatibleTextRendering = true;
            buttonKaydet.UseVisualStyleBackColor = false;
            buttonKaydet.Click += buttonKaydet_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(93, 416);
            panel2.Name = "panel2";
            panel2.Size = new Size(637, 289);
            panel2.TabIndex = 108;
            // 
            // SatisSiparisTeklifTalepKayitFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(788, 786);
            Controls.Add(panel2);
            Controls.Add(buttonKaydet);
            Controls.Add(panelHeader);
            Controls.Add(comboListBoxReferansKaynagi);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(comboListBoxAltGrup);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(textBoxTeklifKonusu);
            Controls.Add(comboListBoxMusteri);
            Controls.Add(comboListBoxMarka);
            Controls.Add(textBoxTeklifTalepTarihi);
            Controls.Add(comboListBoxSatisSorumlusu);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label14);
            Controls.Add(label15);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SatisSiparisTeklifTalepKayitFormu";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Satış Sipariş Kayıt";
            TransparencyKey = Color.Yellow;
            Load += SatisSiparisTeklifTalepKayitFormu_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public class DataControlTeklifTalepDosya : Abstracts.DataControl, IEntity
        {
            private CustomTextBox _teklifTalepDosyaId;
            public CustomTextBox teklifTalepDosyaId { get { if (_teklifTalepDosyaId == null) _teklifTalepDosyaId = new(); return _teklifTalepDosyaId; } set { _teklifTalepDosyaId = value; } }
            private CustomTextBox _teklifTalepId;
            public CustomTextBox teklifTalepId { get { if (_teklifTalepId == null) _teklifTalepId = new(); return _teklifTalepId; } set { _teklifTalepId = value; } }
            private CustomTextBox _teklifTalepBelgeAdi;
            public CustomTextBox teklifTalepBelgeAd { get { if (_teklifTalepBelgeAdi == null) _teklifTalepBelgeAdi = new(); return _teklifTalepBelgeAdi; } set { _teklifTalepBelgeAdi = value; } }
            
            private CustomTextBox _teklifTalepDosyaAdi;
            public CustomTextBox teklifTalepDosyaAd { get { if (_teklifTalepDosyaAdi == null) _teklifTalepDosyaAdi = new(); return _teklifTalepDosyaAdi; } 
                set 
                {
                    _teklifTalepDosyaAdi = value;
                } 
            }
            private CustomTextBox _dosyaUzanti;
            public CustomTextBox dosyaUzanti { get { if (_dosyaUzanti == null) { _dosyaUzanti = new(); } return _dosyaUzanti; } set { _dosyaUzanti = value; } }
            private CustomTextBox _boyut;
            public CustomTextBox boyut{ get { if (_boyut == null) { _boyut = new(); } return _boyut; } set { _boyut = value; } }
            private byte[] _dosyaVeri;
            public byte[] dosyaVeri { get { return _dosyaVeri; } set { _dosyaVeri = value; } }

            private RoundedButton _iconButton;
            public RoundedButton iconButton{ get {if (_iconButton == null) {_iconButton = new(); } return _iconButton; } set { _iconButton = value; } }
            private RoundedButton _iconButtonView;
            public RoundedButton iconButtonView { get { if (_iconButtonView == null) { _iconButtonView = new(); } return _iconButtonView; } set { _iconButtonView = value; } }
            public DataControlTeklifTalepDosya()
            {
                teklifTalepDosyaId = new() { TabIndex = 1, Width = 0, Visible = false, Tag = "TeklifTalepDosyaId" };
                teklifTalepId = new() { TabIndex = 2, Width = 0, Visible = false, Tag = "TeklifTalepId" };
                teklifTalepBelgeAd = new() { TabIndex = 3, Width = 150, Tag = "Belge Adı" };
                teklifTalepDosyaAd = new() { TabIndex = 4, Width = 150, Tag = "Dosya Adı" };
                teklifTalepDosyaAd.TextChanged += teklifTalepDosyaAd_TextChanged;
                dosyaUzanti = new() { TabIndex = 5, Width = 50, Tag = "Uzantı" };
                boyut = new() { TabIndex = 6, Width = 100, Tag = "Boyut(MB)" };
                iconButton = new() { TabIndex = 7, Width = 35, Height = 28, Tag = " Ekle", BackgroundImage = Resources.Plus_Symbol_PNG_Image_HD, BackColor = Color.Transparent, BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom };
                iconButton.Click += ButtonDosyaEkle_Click;
                iconButtonView = new() { TabIndex = 8, Width = 45, Height = 28, Tag = "Göster", BackgroundImage = Resources.DataReviewWithMagnifier2, BackColor = Color.Transparent, BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom };
                iconButtonView.Click += ButtonDosyaGoruntule_Click;
                dosyaVeri = new byte[0];
            }

            private void ButtonDosyaEkle_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if(openFileDialog.ShowDialog()==DialogResult.OK)
                {
                    teklifTalepBelgeAd.TextCustom = Path.GetFileName(openFileDialog.FileName);
                    teklifTalepDosyaAd.TextCustom = openFileDialog.FileName;
                    dosyaVeri = File.ReadAllBytes(openFileDialog.FileName);
                    boyut.TextCustom = (openFileDialog.OpenFile().Length / 1024.0 / 1024.0).ToString("N2");
                }
            }
            private void ButtonDosyaGoruntule_Click(object sender, EventArgs e)
            {
                string tempFilePath = Path.GetTempFileName()+"."+dosyaUzanti.TextCustom;
                using (MemoryStream ms = new MemoryStream(dosyaVeri))
                {
                    File.WriteAllBytes(tempFilePath, ms.ToArray());
                    Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
                }
            }
            private void teklifTalepDosyaAd_TextChanged(object sender, EventArgs e)
            {
                dosyaUzanti.TextCustom = teklifTalepDosyaAd.TextCustom.Split('.').Last();
            }


        }
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private CustomControls.RoundedButton rButtonKapat;
        private CustomControls.RoundedButton rButtonGuncelle;
        private System.Windows.Forms.Label labelHeader;
        public CustomControls.CustomComboListBox comboListBoxProjeAsamalari;
        public CustomControls.CustomComboListBox comboListBoxSatisSorumlusu;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private CustomControls.CustomTextBoxTarih textBoxTeklifTalepTarihi;
        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        public CustomControls.CustomComboListBox comboListBoxMarka;
        public CustomControls.CustomComboListBox comboListBoxMusteri;
        private CustomControls.CustomTextBox textBoxTeklifKonusu;
        public CustomControls.CustomComboListBox comboListBoxAltGrup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public CustomControls.CustomComboListBox comboListBoxReferansKaynagi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Panel panel1;
        private RoundedButton btnClose;
        private RoundedButton btnMinimize;
        private RoundedButton roundedButton3;
        private RoundedButton bntHelp;
        private Label label13;
        private RoundedButton roundedButton1;
        private RoundedButton roundedButton2;
        private RoundedButton roundedButton4;
        private RoundedButton roundedButton6;
        private RoundedButton buttonKaydet;
        private Panel panel2;
    }
}