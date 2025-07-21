using Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Genel;
using YektamakDesktop.Properties;

namespace YektamakDesktop.Formlar.Satis
{
    partial class SatisTeklifMaliyetKayitFormu
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
            panelHeader = new Panel();
            roundedButton4 = new RoundedButton();
            roundedButton5 = new RoundedButton();
            roundedButton6 = new RoundedButton();
            buttonClose = new RoundedButton();
            buttomMinimize = new RoundedButton();
            buttonHelp = new RoundedButton();
            roundedButton3 = new RoundedButton();
            label1 = new Label();
            roundedButton1 = new RoundedButton();
            roundedButton2 = new RoundedButton();
            teklifTalepId = new CustomTextBox();
            teklifTalepTarihi = new CustomTextBoxTarih();
            label5 = new Label();
            label6 = new Label();
            label2 = new Label();
            label3 = new Label();
            referansKaynakId = new CustomComboListBox();
            label11 = new Label();
            label12 = new Label();
            altGrupId = new CustomComboListBox();
            label9 = new Label();
            label10 = new Label();
            teklifKonusu = new CustomTextBox();
            musteriId = new CustomComboListBox();
            markaId = new CustomComboListBox();
            satisSorumlusuId = new CustomComboListBox();
            label4 = new Label();
            label7 = new Label();
            label8 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            panel1 = new Panel();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Firebrick;
            panelHeader.Controls.Add(roundedButton4);
            panelHeader.Controls.Add(roundedButton5);
            panelHeader.Controls.Add(roundedButton6);
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(roundedButton3);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(roundedButton1);
            panelHeader.Controls.Add(roundedButton2);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(817, 32);
            panelHeader.TabIndex = 13;
            // 
            // roundedButton4
            // 
            roundedButton4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            roundedButton4.BackColor = Color.Firebrick;
            roundedButton4.BackgroundColor = Color.Firebrick;
            roundedButton4.BorderColor = Color.Firebrick;
            roundedButton4.CornerRadius = 10;
            roundedButton4.BorderSize = 2;
            roundedButton4.FlatAppearance.BorderSize = 0;
            roundedButton4.FlatStyle = FlatStyle.Flat;
            roundedButton4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            roundedButton4.ForeColor = Color.White;
            roundedButton4.Location = new Point(783, 2);
            roundedButton4.Margin = new Padding(0);
            roundedButton4.Name = "roundedButton4";
            roundedButton4.Padding = new Padding(3, 0, 0, 0);
            roundedButton4.Size = new Size(29, 27);
            roundedButton4.TabIndex = 106;
            roundedButton4.Text = "X";
            roundedButton4.TextColor = Color.White;
            roundedButton4.UseVisualStyleBackColor = false;
            roundedButton4.Click += roundedButton4_Click;
            // 
            // roundedButton5
            // 
            roundedButton5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            roundedButton5.BackColor = Color.Firebrick;
            roundedButton5.BackgroundColor = Color.Firebrick;
            roundedButton5.BorderColor = Color.Firebrick;
            roundedButton5.CornerRadius = 10;
            roundedButton5.BorderSize = 2;
            roundedButton5.FlatAppearance.BorderSize = 0;
            roundedButton5.FlatStyle = FlatStyle.Flat;
            roundedButton5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            roundedButton5.ForeColor = Color.White;
            roundedButton5.Location = new Point(753, 2);
            roundedButton5.Margin = new Padding(0);
            roundedButton5.Name = "roundedButton5";
            roundedButton5.Padding = new Padding(3, 0, 0, 0);
            roundedButton5.Size = new Size(29, 27);
            roundedButton5.TabIndex = 104;
            roundedButton5.Text = "-";
            roundedButton5.TextColor = Color.White;
            roundedButton5.UseVisualStyleBackColor = false;
            roundedButton5.Click += roundedButton5_Click;
            // 
            // roundedButton6
            // 
            roundedButton6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            roundedButton6.BackColor = Color.Firebrick;
            roundedButton6.BackgroundColor = Color.Firebrick;
            roundedButton6.BorderColor = Color.Firebrick;
            roundedButton6.CornerRadius = 10;
            roundedButton6.BorderSize = 2;
            roundedButton6.FlatAppearance.BorderSize = 0;
            roundedButton6.FlatStyle = FlatStyle.Flat;
            roundedButton6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            roundedButton6.ForeColor = Color.White;
            roundedButton6.Location = new Point(723, 3);
            roundedButton6.Margin = new Padding(0);
            roundedButton6.Name = "roundedButton6";
            roundedButton6.Padding = new Padding(3, 0, 0, 0);
            roundedButton6.Size = new Size(29, 27);
            roundedButton6.TabIndex = 105;
            roundedButton6.Text = "?";
            roundedButton6.TextColor = Color.White;
            roundedButton6.UseVisualStyleBackColor = false;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClose.BackColor = Color.Firebrick;
            buttonClose.BackgroundColor = Color.Firebrick;
            buttonClose.BorderColor = Color.Firebrick;
            buttonClose.CornerRadius = 0;
            buttonClose.BorderSize = 2;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClose.ForeColor = Color.White;
            buttonClose.Location = new Point(1819, 2);
            buttonClose.Margin = new Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new Padding(3, 0, 0, 0);
            buttonClose.Size = new Size(29, 0);
            buttonClose.TabIndex = 103;
            buttonClose.Text = "X";
            buttonClose.TextColor = Color.White;
            buttonClose.UseVisualStyleBackColor = false;
            // 
            // buttomMinimize
            // 
            buttomMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttomMinimize.BackColor = Color.Firebrick;
            buttomMinimize.BackgroundColor = Color.Firebrick;
            buttomMinimize.BorderColor = Color.Firebrick;
            buttomMinimize.CornerRadius = 0;
            buttomMinimize.BorderSize = 2;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = FlatStyle.Flat;
            buttomMinimize.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttomMinimize.ForeColor = Color.White;
            buttomMinimize.Location = new Point(1779, 2);
            buttomMinimize.Margin = new Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new Padding(3, 0, 0, 0);
            buttomMinimize.Size = new Size(29, 0);
            buttomMinimize.TabIndex = 101;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            // 
            // buttonHelp
            // 
            buttonHelp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttonHelp.BackColor = Color.Firebrick;
            buttonHelp.BackgroundColor = Color.Firebrick;
            buttonHelp.BorderColor = Color.Firebrick;
            buttonHelp.CornerRadius = 0;
            buttonHelp.BorderSize = 2;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = FlatStyle.Flat;
            buttonHelp.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonHelp.ForeColor = Color.White;
            buttonHelp.Location = new Point(1740, 3);
            buttonHelp.Margin = new Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new Padding(3, 0, 0, 0);
            buttonHelp.Size = new Size(29, 0);
            buttonHelp.TabIndex = 102;
            buttonHelp.Text = "?";
            buttonHelp.TextColor = Color.White;
            buttonHelp.UseVisualStyleBackColor = false;
            // 
            // roundedButton3
            // 
            roundedButton3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            roundedButton3.BackColor = Color.Firebrick;
            roundedButton3.BackgroundColor = Color.Firebrick;
            roundedButton3.BorderColor = Color.Firebrick;
            roundedButton3.CornerRadius = 0;
            roundedButton3.BorderSize = 2;
            roundedButton3.FlatAppearance.BorderSize = 0;
            roundedButton3.FlatStyle = FlatStyle.Flat;
            roundedButton3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            roundedButton3.ForeColor = Color.White;
            roundedButton3.Location = new Point(2905, 1);
            roundedButton3.Margin = new Padding(0);
            roundedButton3.Name = "roundedButton3";
            roundedButton3.Padding = new Padding(3, 0, 0, 0);
            roundedButton3.Size = new Size(29, 0);
            roundedButton3.TabIndex = 100;
            roundedButton3.Text = "X";
            roundedButton3.TextColor = Color.White;
            roundedButton3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(169, 17);
            label1.TabIndex = 1;
            label1.Text = "Satış Teklif Maliyet Formu";
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            roundedButton1.BackColor = Color.Firebrick;
            roundedButton1.BackgroundColor = Color.Firebrick;
            roundedButton1.BorderColor = Color.Firebrick;
            roundedButton1.CornerRadius = 0;
            roundedButton1.BorderSize = 2;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            roundedButton1.ForeColor = Color.White;
            roundedButton1.Location = new Point(2865, 1);
            roundedButton1.Margin = new Padding(0);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new Padding(3, 0, 0, 0);
            roundedButton1.Size = new Size(29, 0);
            roundedButton1.TabIndex = 98;
            roundedButton1.Text = "-";
            roundedButton1.TextColor = Color.White;
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // roundedButton2
            // 
            roundedButton2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            roundedButton2.BackColor = Color.Firebrick;
            roundedButton2.BackgroundColor = Color.Firebrick;
            roundedButton2.BorderColor = Color.Firebrick;
            roundedButton2.CornerRadius = 0;
            roundedButton2.BorderSize = 2;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = FlatStyle.Flat;
            roundedButton2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            roundedButton2.ForeColor = Color.White;
            roundedButton2.Location = new Point(2826, 2);
            roundedButton2.Margin = new Padding(0);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Padding = new Padding(3, 0, 0, 0);
            roundedButton2.Size = new Size(29, 0);
            roundedButton2.TabIndex = 99;
            roundedButton2.Text = "?";
            roundedButton2.TextColor = Color.White;
            roundedButton2.UseVisualStyleBackColor = false;
            // 
            // teklifTalepId
            // 
            teklifTalepId.BackColor = Color.White;
            teklifTalepId.BorderColor = Color.Silver;
            teklifTalepId.BorderFocusColor = Color.HotPink;
            teklifTalepId.BorderRadius = 5;
            teklifTalepId.BorderSize = 1;
            teklifTalepId.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            teklifTalepId.ForeColor = Color.Black;
            teklifTalepId.isPlaceHolder = false;
            teklifTalepId.Location = new Point(239, 81);
            teklifTalepId.Multiline = false;
            teklifTalepId.Name = "teklifTalepId";
            teklifTalepId.Padding = new Padding(7, 5, 7, 5);
            teklifTalepId.PasswordChar = false;
            teklifTalepId.PlaceholderColor = Color.DarkGray;
            teklifTalepId.PlaceholderText = "";
            teklifTalepId.ReadOnly = false;
            teklifTalepId.SelectionStart = 0;
            teklifTalepId.Size = new Size(87, 28);
            teklifTalepId.TabIndex = 14;
            teklifTalepId.TextAlignment = HorizontalAlignment.Left;
            teklifTalepId.TextCustom = "";
            teklifTalepId.UnderlinedStyle = false;
            // 
            // teklifTalepTarihi
            // 
            teklifTalepTarihi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            teklifTalepTarihi.Location = new Point(239, 113);
            teklifTalepTarihi.Margin = new Padding(1);
            teklifTalepTarihi.Name = "teklifTalepTarihi";
            teklifTalepTarihi.Padding = new Padding(1);
            teklifTalepTarihi.Size = new Size(145, 32);
            teklifTalepTarihi.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(95, 120);
            label5.Name = "label5";
            label5.Size = new Size(81, 19);
            label5.TabIndex = 17;
            label5.Text = "Talep Tarihi";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(219, 119);
            label6.Name = "label6";
            label6.Size = new Size(13, 20);
            label6.TabIndex = 18;
            label6.Text = ":";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(95, 85);
            label2.Name = "label2";
            label2.Size = new Size(98, 19);
            label2.TabIndex = 19;
            label2.Text = "Teklif Talep ID";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(219, 84);
            label3.Name = "label3";
            label3.Size = new Size(13, 20);
            label3.TabIndex = 20;
            label3.Text = ":";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // referansKaynakId
            // 
            referansKaynakId.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            referansKaynakId.ListBoxVisualSize = 5;
            referansKaynakId.Location = new Point(239, 309);
            referansKaynakId.Margin = new Padding(1);
            referansKaynakId.Name = "referansKaynakId";
            referansKaynakId.Padding = new Padding(1);
            referansKaynakId.Size = new Size(251, 36);
            referansKaynakId.TabIndex = 113;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(214, 309);
            label11.Name = "label11";
            label11.Size = new Size(13, 20);
            label11.TabIndex = 112;
            label11.Text = ":";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(98, 310);
            label12.Name = "label12";
            label12.Size = new Size(117, 19);
            label12.TabIndex = 111;
            label12.Text = "Referans Kaynağı";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // altGrupId
            // 
            altGrupId.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            altGrupId.ListBoxVisualSize = 5;
            altGrupId.Location = new Point(239, 271);
            altGrupId.Margin = new Padding(1);
            altGrupId.Name = "altGrupId";
            altGrupId.Padding = new Padding(1);
            altGrupId.Size = new Size(251, 36);
            altGrupId.TabIndex = 110;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(214, 271);
            label9.Name = "label9";
            label9.Size = new Size(13, 20);
            label9.TabIndex = 109;
            label9.Text = ":";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(98, 272);
            label10.Name = "label10";
            label10.Size = new Size(62, 19);
            label10.TabIndex = 108;
            label10.Text = "Alt Grup";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // teklifKonusu
            // 
            teklifKonusu.BackColor = Color.White;
            teklifKonusu.BorderColor = Color.Silver;
            teklifKonusu.BorderFocusColor = Color.HotPink;
            teklifKonusu.BorderRadius = 5;
            teklifKonusu.BorderSize = 1;
            teklifKonusu.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            teklifKonusu.ForeColor = Color.Black;
            teklifKonusu.isPlaceHolder = false;
            teklifKonusu.Location = new Point(239, 195);
            teklifKonusu.Multiline = false;
            teklifKonusu.Name = "teklifKonusu";
            teklifKonusu.Padding = new Padding(10, 7, 10, 7);
            teklifKonusu.PasswordChar = false;
            teklifKonusu.PlaceholderColor = Color.DarkGray;
            teklifKonusu.PlaceholderText = "";
            teklifKonusu.ReadOnly = false;
            teklifKonusu.SelectionStart = 0;
            teklifKonusu.Size = new Size(538, 32);
            teklifKonusu.TabIndex = 107;
            teklifKonusu.TextAlignment = HorizontalAlignment.Left;
            teklifKonusu.TextCustom = "";
            teklifKonusu.UnderlinedStyle = false;
            // 
            // musteriId
            // 
            musteriId.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            musteriId.ListBoxVisualSize = 5;
            musteriId.Location = new Point(239, 155);
            musteriId.Margin = new Padding(1);
            musteriId.Name = "musteriId";
            musteriId.Padding = new Padding(1);
            musteriId.Size = new Size(538, 36);
            musteriId.TabIndex = 106;
            // 
            // markaId
            // 
            markaId.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            markaId.ListBoxVisualSize = 5;
            markaId.Location = new Point(239, 233);
            markaId.Margin = new Padding(1);
            markaId.Name = "markaId";
            markaId.Padding = new Padding(1);
            markaId.Size = new Size(251, 36);
            markaId.TabIndex = 105;
            // 
            // satisSorumlusuId
            // 
            satisSorumlusuId.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            satisSorumlusuId.ListBoxVisualSize = 5;
            satisSorumlusuId.Location = new Point(239, 347);
            satisSorumlusuId.Margin = new Padding(1);
            satisSorumlusuId.Name = "satisSorumlusuId";
            satisSorumlusuId.Padding = new Padding(1);
            satisSorumlusuId.Size = new Size(251, 36);
            satisSorumlusuId.TabIndex = 96;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(98, 348);
            label4.Name = "label4";
            label4.Size = new Size(110, 19);
            label4.TabIndex = 98;
            label4.Text = "Satış Sorumlusu";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(214, 347);
            label7.Name = "label7";
            label7.Size = new Size(13, 20);
            label7.TabIndex = 97;
            label7.Text = ":";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(95, 196);
            label8.Name = "label8";
            label8.Size = new Size(94, 19);
            label8.TabIndex = 99;
            label8.Text = "Teklif Konusu";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(214, 195);
            label13.Name = "label13";
            label13.Size = new Size(13, 20);
            label13.TabIndex = 100;
            label13.Text = ":";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(95, 153);
            label14.Name = "label14";
            label14.Size = new Size(57, 19);
            label14.TabIndex = 101;
            label14.Text = "Müşteri";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(214, 152);
            label15.Name = "label15";
            label15.Size = new Size(13, 20);
            label15.TabIndex = 102;
            label15.Text = ":";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(214, 233);
            label16.Name = "label16";
            label16.Size = new Size(13, 20);
            label16.TabIndex = 104;
            label16.Text = ":";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(98, 234);
            label17.Name = "label17";
            label17.Size = new Size(48, 19);
            label17.TabIndex = 103;
            label17.Text = "Marka";
            label17.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Location = new Point(95, 435);
            panel1.Name = "panel1";
            panel1.Size = new Size(664, 312);
            panel1.TabIndex = 114;
            // 
            // btnSave
            // 
            btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSave.BackColor = Color.Transparent;
            btnSave.BackgroundImage = Resources.kaydet;
            btnSave.BackgroundImageLayout = ImageLayout.Stretch;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseOverBackColor = SystemColors.ActiveBorder;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(719, 753);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(40, 36);
            btnSave.TabIndex = 115;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // SatisTeklifMaliyetKayitFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 791);
            Controls.Add(btnSave);
            Controls.Add(panel1);
            Controls.Add(referansKaynakId);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(altGrupId);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(teklifKonusu);
            Controls.Add(musteriId);
            Controls.Add(markaId);
            Controls.Add(satisSorumlusuId);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label13);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(label17);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(teklifTalepTarihi);
            Controls.Add(teklifTalepId);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SatisTeklifMaliyetKayitFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SatisTeklifMaliyetKayitFormu";
            Load += SatisTeklifMaliyetKayitFormu_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        CustomDataGrid<DataControlTeklifMaliyetDetay> customDataGrid;

        public class DataControlTeklifMaliyetDetay : Abstracts.DataControl, IEntity
        {
            private CustomTextBox _teklifTalepMaliyetId;
            public CustomTextBox teklifTalepMaliyetId { get { if (_teklifTalepMaliyetId == null) _teklifTalepMaliyetId = new(); return _teklifTalepMaliyetId; } set { _teklifTalepMaliyetId = value; } }
            private CustomTextBox _teklifTalepId;
            public CustomTextBox teklifTalepId { get { if (_teklifTalepId == null) _teklifTalepId = new(); return _teklifTalepId; } set { _teklifTalepId = value; } }
            private CustomComboListBox _teklifTalepMaliyetUnsurId;
            public CustomComboListBox teklifTalepMaliyetUnsurId { get { if (_teklifTalepMaliyetUnsurId == null) _teklifTalepMaliyetUnsurId = new(); return _teklifTalepMaliyetUnsurId; } set { _teklifTalepMaliyetUnsurId = value; } }

            private CustomComboListBox _teklifTalepMaliyetTespitKanalId;
            public CustomComboListBox teklifTalepMaliyetTespitKanalId
            {
                get { if (_teklifTalepMaliyetTespitKanalId == null) _teklifTalepMaliyetTespitKanalId = new(); return _teklifTalepMaliyetTespitKanalId; }
                set
                {
                    _teklifTalepMaliyetTespitKanalId = value;
                }
            }
            private CustomTextBox _ongorulenMaliyet;
            public CustomTextBox ongorulenMaliyet { get { if (_ongorulenMaliyet == null) { _ongorulenMaliyet = new(); } return _ongorulenMaliyet; } set { _ongorulenMaliyet = value; } }
            private CustomComboListBox _ongorulenMaliyetDovizCinsiId;
            public CustomComboListBox ongorulenMaliyetDovizCinsiId { get { if (_ongorulenMaliyetDovizCinsiId == null) { _ongorulenMaliyetDovizCinsiId = new(); } return _ongorulenMaliyetDovizCinsiId; } set { _ongorulenMaliyetDovizCinsiId = value; } }
            private byte[] _dosyaVeri;
            public byte[] dosyaVeri { get { return _dosyaVeri; } set { _dosyaVeri = value; } }

            private RoundedButton _iconButton;
            public RoundedButton iconButton { get { if (_iconButton == null) { _iconButton = new(); } return _iconButton; } set { _iconButton = value; } }
            private RoundedButton _iconButtonView;
            public RoundedButton iconButtonView { get { if (_iconButtonView == null) { _iconButtonView = new(); } return _iconButtonView; } set { _iconButtonView = value; } }
            public DataControlTeklifMaliyetDetay()
            {
                teklifTalepMaliyetId = new() { TabIndex = 1, Width = 0, Visible = false, Tag = "TeklifMaliyetId" };
                teklifTalepId = new() { TabIndex = 2, Width = 0, Visible = false, Tag = "TeklifTalepId" };
                teklifTalepMaliyetUnsurId = new() { TabIndex = 3, Width = 150, Tag = "Maliyet Unsuru" };
                teklifTalepMaliyetTespitKanalId = new() { TabIndex = 4, Width = 150, Tag = "Maliyet Tespit Kanalı" };
                ongorulenMaliyet = new() { TabIndex = 5, Width = 100, Tag = "Tutar" };
                ongorulenMaliyetDovizCinsiId = new() { TabIndex = 6, Width = 65, Tag = "Döviz Cinsi" };
                iconButton = new() { TabIndex = 7, Width = 35, Height = 28, Tag = " Ekle", BackgroundImage = Resources.ekle, BackColor = Color.Transparent, BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom };
                iconButton.Click += ButtonDosyaEkle_Click;
                iconButtonView = new() { TabIndex = 8, Width = 45, Height = 28, Tag = "Göster", BackgroundImage = Resources.pngegg, BackColor = Color.Transparent, BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom };
                iconButtonView.Click += ButtonDosyaGoruntule_Click;
                teklifTalepMaliyetUnsurId.DoubleClick += teklifTalepMaliyetUnsurId_DoubleClick;
                teklifTalepMaliyetTespitKanalId.DoubleClick += TeklifTalepMaliyetTespitKanalId_DoubleClick;
                dosyaVeri = new byte[0];
                ComboBoxListFill.GetLookupAd(_cache.dovizCinsiList, ref _ongorulenMaliyetDovizCinsiId);
                ComboBoxListFill.GetLookupAd(_cache.maliyetUnsurList, ref _teklifTalepMaliyetUnsurId);
                ComboBoxListFill.GetLookupAd(_cache.maliyetTespitKanalList, ref _teklifTalepMaliyetTespitKanalId);
            }

            private void TeklifTalepMaliyetTespitKanalId_DoubleClick(object sender, EventArgs e)
            {
                DIContainer.GetService<AnaVeriTanimlamaFormu<MaliyetTespitKanal>>();
                AnaVeriTanimlamaFormu<MaliyetTespitKanal> anaVeriTanimlamaFormu = AnaVeriTanimlamaFormu<MaliyetTespitKanal>.anaVeriTanimlamaFormu;
                if (anaVeriTanimlamaFormu != null) anaVeriTanimlamaFormu.Show();
            }

            private void ButtonDosyaEkle_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dosyaVeri = File.ReadAllBytes(openFileDialog.FileName);
                }
            }
            private void ButtonDosyaGoruntule_Click(object sender, EventArgs e)
            {
                string tempFilePath = Path.GetTempFileName() + "." + ongorulenMaliyet.TextCustom;
                using (MemoryStream ms = new MemoryStream(dosyaVeri))
                {
                    File.WriteAllBytes(tempFilePath, ms.ToArray());
                    Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
                }
            }
            private void teklifTalepMaliyetUnsurId_DoubleClick(object sender, EventArgs e)
            {
                DIContainer.GetService<AnaVeriTanimlamaFormu<MaliyetUnsur>>();
                AnaVeriTanimlamaFormu<MaliyetUnsur> anaVeriTanimlamaFormu = AnaVeriTanimlamaFormu<MaliyetUnsur>.anaVeriTanimlamaFormu;
                if(anaVeriTanimlamaFormu!=null)anaVeriTanimlamaFormu.Show();
            }
        }
        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttomMinimize;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton roundedButton3;
        private System.Windows.Forms.Label label1;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.RoundedButton roundedButton2;
        private CustomControls.RoundedButton roundedButton4;
        private CustomControls.RoundedButton roundedButton5;
        private CustomControls.RoundedButton roundedButton6;
        private CustomControls.CustomTextBox teklifTalepId;
        private CustomControls.CustomTextBoxTarih teklifTalepTarihi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public CustomControls.CustomComboListBox referansKaynakId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public CustomControls.CustomComboListBox altGrupId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private CustomControls.CustomTextBox teklifKonusu;
        public CustomControls.CustomComboListBox musteriId;
        public CustomControls.CustomComboListBox markaId;
        public CustomControls.CustomComboListBox satisSorumlusuId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel1;
        private Button btnSave;
    }
}