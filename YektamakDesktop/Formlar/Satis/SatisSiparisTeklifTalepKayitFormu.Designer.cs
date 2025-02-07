using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Yetkilendirme;
using Models;
using YektamakDesktop.Properties;

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatisSiparisTeklifTalepKayitFormu));
            textBoxTeklifTalepTarihi = new CustomTextBoxTarih();
            label14 = new Label();
            label15 = new Label();
            comboListBoxSatisSorumlusu = new CustomComboListBox();
            satisSiparisBindingSource = new BindingSource(components);
            labelHeader = new Label();
            rButtonKapat = new RoundedButton();
            rButtonGuncelle = new RoundedButton();
            buttonKaydet = new RoundedButton();
            label7 = new Label();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panelHeader = new Panel();
            buttonClose = new RoundedButton();
            buttonHelp = new RoundedButton();
            buttomMinimize = new RoundedButton();
            satisSiparisBindingSource1 = new BindingSource(components);
            comboListBoxMarka = new CustomComboListBox();
            comboListBoxMusteri = new CustomComboListBox();
            textBoxTeklifKonusu = new CustomTextBox();
            comboListBoxAltGrup = new CustomComboListBox();
            label9 = new Label();
            label10 = new Label();
            comboListBoxReferansKaynagi = new CustomComboListBox();
            label11 = new Label();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)satisSiparisBindingSource).BeginInit();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)satisSiparisBindingSource1).BeginInit();
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
            comboListBoxSatisSorumlusu.Size = new Size(251, 32);
            comboListBoxSatisSorumlusu.TabIndex = 0;
            // 
            // satisSiparisBindingSource
            // 
            satisSiparisBindingSource.DataSource = typeof(SatisSiparis);
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.FlatStyle = FlatStyle.Flat;
            labelHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeader.ForeColor = SystemColors.ButtonHighlight;
            labelHeader.Location = new Point(16, 11);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(225, 20);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Satış Sipariş Teklif Talep Formu";
            // 
            // rButtonKapat
            // 
            rButtonKapat.BackColor = Color.Brown;
            rButtonKapat.BackgroundColor = Color.Brown;
            rButtonKapat.BorderColor = Color.Crimson;
            rButtonKapat.BorderRadius = 20;
            rButtonKapat.BorderSize = 2;
            rButtonKapat.FlatAppearance.BorderSize = 0;
            rButtonKapat.FlatStyle = FlatStyle.Flat;
            rButtonKapat.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            rButtonKapat.ForeColor = Color.White;
            rButtonKapat.Location = new Point(446, 687);
            rButtonKapat.Name = "rButtonKapat";
            rButtonKapat.Size = new Size(120, 50);
            rButtonKapat.TabIndex = 21;
            rButtonKapat.Text = "KAPAT";
            rButtonKapat.TextColor = Color.White;
            rButtonKapat.UseVisualStyleBackColor = false;
            rButtonKapat.Click += rButtonKapat_Click;
            // 
            // rButtonGuncelle
            // 
            rButtonGuncelle.BackColor = Color.CornflowerBlue;
            rButtonGuncelle.BackgroundColor = Color.CornflowerBlue;
            rButtonGuncelle.BorderColor = Color.RoyalBlue;
            rButtonGuncelle.BorderRadius = 20;
            rButtonGuncelle.BorderSize = 2;
            rButtonGuncelle.FlatAppearance.BorderSize = 0;
            rButtonGuncelle.FlatStyle = FlatStyle.Flat;
            rButtonGuncelle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            rButtonGuncelle.ForeColor = Color.White;
            rButtonGuncelle.Location = new Point(106, 687);
            rButtonGuncelle.Name = "rButtonGuncelle";
            rButtonGuncelle.Size = new Size(120, 50);
            rButtonGuncelle.TabIndex = 20;
            rButtonGuncelle.Text = "GÜNCELLE";
            rButtonGuncelle.TextColor = Color.White;
            rButtonGuncelle.UseVisualStyleBackColor = false;
            rButtonGuncelle.Click += rButtonGuncelle_Click;
            // 
            // buttonKaydet
            // 
            buttonKaydet.BackColor = Color.LimeGreen;
            buttonKaydet.BackgroundColor = Color.LimeGreen;
            buttonKaydet.BorderColor = Color.MediumSeaGreen;
            buttonKaydet.BorderRadius = 20;
            buttonKaydet.BorderSize = 2;
            buttonKaydet.FlatAppearance.BorderSize = 0;
            buttonKaydet.FlatStyle = FlatStyle.Flat;
            buttonKaydet.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            buttonKaydet.ForeColor = Color.White;
            buttonKaydet.Location = new Point(106, 687);
            buttonKaydet.Name = "buttonKaydet";
            buttonKaydet.Size = new Size(120, 50);
            buttonKaydet.TabIndex = 19;
            buttonKaydet.Text = "KAYDET";
            buttonKaydet.TextColor = Color.White;
            buttonKaydet.UseVisualStyleBackColor = false;
            buttonKaydet.Click += buttonKaydet_Click;
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Red;
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(946, 41);
            panelHeader.TabIndex = 86;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.Red;
            buttonClose.BackgroundColor = Color.Red;
            buttonClose.BorderColor = Color.LavenderBlush;
            buttonClose.BorderRadius = 10;
            buttonClose.BorderSize = 1;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClose.ForeColor = Color.White;
            buttonClose.Location = new Point(891, 4);
            buttonClose.Margin = new Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new Padding(3, 0, 0, 0);
            buttonClose.Size = new Size(34, 30);
            buttonClose.TabIndex = 106;
            buttonClose.Text = "x";
            buttonClose.TextColor = Color.White;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.BackColor = Color.Red;
            buttonHelp.BackgroundColor = Color.Red;
            buttonHelp.BorderColor = Color.LavenderBlush;
            buttonHelp.BorderRadius = 10;
            buttonHelp.BorderSize = 1;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = FlatStyle.Flat;
            buttonHelp.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            buttonHelp.ForeColor = Color.White;
            buttonHelp.Location = new Point(823, 4);
            buttonHelp.Margin = new Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new Padding(3, 0, 0, 0);
            buttonHelp.Size = new Size(34, 30);
            buttonHelp.TabIndex = 105;
            buttonHelp.Text = "?";
            buttonHelp.TextColor = Color.White;
            buttonHelp.UseVisualStyleBackColor = false;
            // 
            // buttomMinimize
            // 
            buttomMinimize.BackColor = Color.Red;
            buttomMinimize.BackgroundColor = Color.Red;
            buttomMinimize.BorderColor = Color.LavenderBlush;
            buttomMinimize.BorderRadius = 10;
            buttomMinimize.BorderSize = 1;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = FlatStyle.Flat;
            buttomMinimize.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            buttomMinimize.ForeColor = Color.White;
            buttomMinimize.Location = new Point(857, 4);
            buttomMinimize.Margin = new Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new Padding(3, 0, 0, 0);
            buttomMinimize.Size = new Size(34, 30);
            buttomMinimize.TabIndex = 104;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // satisSiparisBindingSource1
            // 
            satisSiparisBindingSource1.DataSource = typeof(SatisSiparis);
            // 
            // comboListBoxMarka
            // 
            comboListBoxMarka.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboListBoxMarka.ListBoxVisualSize = 5;
            comboListBoxMarka.Location = new Point(234, 237);
            comboListBoxMarka.Margin = new Padding(1);
            comboListBoxMarka.Name = "comboListBoxMarka";
            comboListBoxMarka.Padding = new Padding(1);
            comboListBoxMarka.Size = new Size(251, 32);
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
            comboListBoxMusteri.Size = new Size(538, 32);
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
            comboListBoxAltGrup.Size = new Size(251, 32);
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
            comboListBoxReferansKaynagi.Size = new Size(251, 32);
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
            // SatisSiparisTeklifTalepKayitFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(946, 786);
            Controls.Add(comboListBoxReferansKaynagi);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(comboListBoxAltGrup);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(textBoxTeklifKonusu);
            Controls.Add(comboListBoxMusteri);
            Controls.Add(comboListBoxMarka);
            Controls.Add(rButtonKapat);
            Controls.Add(panelHeader);
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
            Controls.Add(buttonKaydet);
            Controls.Add(rButtonGuncelle);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SatisSiparisTeklifTalepKayitFormu";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Satış Sipariş Kayıt";
            TransparencyKey = Color.Yellow;
            ((System.ComponentModel.ISupportInitialize)satisSiparisBindingSource).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)satisSiparisBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public class DataControlTeklifTalepDosya : Abstracts.DataControl, IEntity
        {
            private CustomTextBox _teklifTalepDosyaId;
            public CustomTextBox teklifTalepDosyaId { get { if (_teklifTalepDosyaId == null) _teklifTalepDosyaId = new(); return _teklifTalepDosyaId; } set { _teklifTalepDosyaId = value; } }
            
            private CustomTextBox _teklifTalepBelgeAdi;
            public CustomTextBox teklifTalepBelgeAdi { get { if (_teklifTalepBelgeAdi == null) _teklifTalepBelgeAdi = new(); return _teklifTalepBelgeAdi; } set { _teklifTalepBelgeAdi = value; } }
            
            private CustomTextBox _teklifTalepDosyaAdi;
            public CustomTextBox teklifTalepDosyaAdi { get { if (_teklifTalepDosyaAdi == null) _teklifTalepDosyaAdi = new(); return _teklifTalepDosyaAdi; } set { _teklifTalepDosyaAdi = value; } }
            
            private CustomTextBox _boyut;
            public CustomTextBox boyut{ get { if (_boyut == null) { _boyut = new(); } return _boyut; } set { _boyut = value; } }
            
            private RoundedButton _iconButton;
            public RoundedButton iconButton{ get {if (_iconButton == null) {_iconButton = new(); } return _iconButton; } set { _iconButton = value; } }
            public DataControlTeklifTalepDosya()
            {
                teklifTalepDosyaId = new() { TabIndex = 1, Width = 0, Visible = false, Tag = "TeklifTalepDosyaId" };
                teklifTalepBelgeAdi = new() { TabIndex = 2, Width = 200, Tag = "Belge Adı" };
                teklifTalepDosyaAdi = new() { TabIndex = 3, Width = 200, Tag = "Dosya Adı" };
                boyut = new() { TabIndex = 4, Width = 100, Tag = "Boyut(MB)" };
                iconButton = new() { TabIndex = 5, Width = 35, Height = 28, Tag = " Ekle", BackgroundImage = Resources.Plus_Symbol_PNG_Image_HD, BackColor = Color.Transparent, BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom };
                iconButton.Click += ButtonDosyaEkle_Click;
                
            }

            private void ButtonDosyaEkle_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if(openFileDialog.ShowDialog()==DialogResult.OK)
                {
                    _teklifTalepBelgeAdi.TextCustom = Path.GetFileName(openFileDialog.FileName);
                    _teklifTalepDosyaAdi.TextCustom = openFileDialog.FileName;
                    _boyut.TextCustom = (openFileDialog.OpenFile().Length / 1024.0 / 1024.0).ToString("N2");
                }
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
        private CustomControls.RoundedButton buttonKaydet;
        private System.Windows.Forms.Label labelHeader;
        public CustomControls.CustomComboListBox comboListBoxProjeAsamalari;
        public CustomControls.CustomComboListBox comboListBoxSatisSorumlusu;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private CustomControls.CustomTextBoxTarih textBoxTeklifTalepTarihi;
        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.BindingSource satisSiparisBindingSource;
        private System.Windows.Forms.BindingSource satisSiparisBindingSource1;
        public CustomControls.CustomComboListBox comboListBoxMarka;
        public CustomControls.CustomComboListBox comboListBoxMusteri;
        private CustomControls.CustomTextBox textBoxTeklifKonusu;
        public CustomControls.CustomComboListBox comboListBoxAltGrup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public CustomControls.CustomComboListBox comboListBoxReferansKaynagi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}