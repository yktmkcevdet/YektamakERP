using System;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Satis
{
    partial class TahsilatPlanKayitFormu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TahsilatPlanKayitFormu));
            personelKayitMainPanel = new Panel();
            labelOranVeKdvUyari = new Label();
            roundedProjeSafhalari = new CustomControls.RoundedButton();
            panelTahsilatAsama = new Panel();
            monthCalendarTahsilatTarihi = new MonthCalendar();
            textBoxAciklamalar = new TextBox();
            label15 = new Label();
            label16 = new Label();
            label1 = new Label();
            label2 = new Label();
            textBoxSatisTutari = new CustomControls.CustomTextBox();
            groupBoxKDVDahilMi = new GroupBox();
            customRadioButtonNetKdv = new CustomControls.CustomRadioButton();
            customRadioButtonToplam = new CustomControls.CustomRadioButton();
            numericTahsilatAsamaSayisi = new NumericUpDown();
            label14 = new Label();
            label13 = new Label();
            panelHeader = new Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new Label();
            rButtonKapat = new CustomControls.RoundedButton();
            rButtonGuncelle = new CustomControls.RoundedButton();
            label12 = new Label();
            label10 = new Label();
            textBoxProjeKodu = new CustomControls.CustomTextBox();
            rButtonKaydet = new CustomControls.RoundedButton();
            openFileDialogResim = new OpenFileDialog();
            personelKayitMainPanel.SuspendLayout();
            panelTahsilatAsama.SuspendLayout();
            groupBoxKDVDahilMi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericTahsilatAsamaSayisi).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // personelKayitMainPanel
            // 
            personelKayitMainPanel.AutoScroll = true;
            personelKayitMainPanel.AutoSize = true;
            personelKayitMainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            personelKayitMainPanel.Controls.Add(labelOranVeKdvUyari);
            personelKayitMainPanel.Controls.Add(roundedProjeSafhalari);
            personelKayitMainPanel.Controls.Add(panelTahsilatAsama);
            personelKayitMainPanel.Controls.Add(textBoxAciklamalar);
            personelKayitMainPanel.Controls.Add(label15);
            personelKayitMainPanel.Controls.Add(label16);
            personelKayitMainPanel.Controls.Add(label1);
            personelKayitMainPanel.Controls.Add(label2);
            personelKayitMainPanel.Controls.Add(textBoxSatisTutari);
            personelKayitMainPanel.Controls.Add(groupBoxKDVDahilMi);
            personelKayitMainPanel.Controls.Add(numericTahsilatAsamaSayisi);
            personelKayitMainPanel.Controls.Add(label14);
            personelKayitMainPanel.Controls.Add(label13);
            personelKayitMainPanel.Controls.Add(panelHeader);
            personelKayitMainPanel.Controls.Add(rButtonKapat);
            personelKayitMainPanel.Controls.Add(rButtonGuncelle);
            personelKayitMainPanel.Controls.Add(label12);
            personelKayitMainPanel.Controls.Add(label10);
            personelKayitMainPanel.Controls.Add(textBoxProjeKodu);
            personelKayitMainPanel.Controls.Add(rButtonKaydet);
            personelKayitMainPanel.Dock = DockStyle.Fill;
            personelKayitMainPanel.Location = new System.Drawing.Point(0, 0);
            personelKayitMainPanel.Name = "personelKayitMainPanel";
            personelKayitMainPanel.Size = new System.Drawing.Size(1107, 692);
            personelKayitMainPanel.TabIndex = 0;
            // 
            // labelOranVeKdvUyari
            // 
            labelOranVeKdvUyari.AutoSize = true;
            labelOranVeKdvUyari.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelOranVeKdvUyari.ForeColor = System.Drawing.Color.Red;
            labelOranVeKdvUyari.Location = new System.Drawing.Point(55, 561);
            labelOranVeKdvUyari.Name = "labelOranVeKdvUyari";
            labelOranVeKdvUyari.Size = new System.Drawing.Size(0, 15);
            labelOranVeKdvUyari.TabIndex = 32;
            // 
            // roundedProjeSafhalari
            // 
            roundedProjeSafhalari.BackColor = System.Drawing.Color.MediumSeaGreen;
            roundedProjeSafhalari.BackgroundColor = System.Drawing.Color.MediumSeaGreen;
            roundedProjeSafhalari.BorderColor = System.Drawing.Color.DarkCyan;
            roundedProjeSafhalari.BorderRadius = 40;
            roundedProjeSafhalari.BorderSize = 5;
            roundedProjeSafhalari.FlatAppearance.BorderSize = 0;
            roundedProjeSafhalari.FlatStyle = FlatStyle.Flat;
            roundedProjeSafhalari.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedProjeSafhalari.ForeColor = System.Drawing.Color.White;
            roundedProjeSafhalari.Location = new System.Drawing.Point(989, 77);
            roundedProjeSafhalari.Name = "roundedProjeSafhalari";
            roundedProjeSafhalari.Size = new System.Drawing.Size(106, 53);
            roundedProjeSafhalari.TabIndex = 48;
            roundedProjeSafhalari.Text = "PROJE SAFHALARI";
            roundedProjeSafhalari.TextColor = System.Drawing.Color.White;
            roundedProjeSafhalari.UseVisualStyleBackColor = false;
            roundedProjeSafhalari.Click += roundedProjeSafhalari_Click;
            // 
            // panelTahsilatAsama
            // 
            panelTahsilatAsama.AutoScroll = true;
            panelTahsilatAsama.Controls.Add(monthCalendarTahsilatTarihi);
            panelTahsilatAsama.Location = new System.Drawing.Point(3, 136);
            panelTahsilatAsama.Name = "panelTahsilatAsama";
            panelTahsilatAsama.Size = new System.Drawing.Size(1104, 422);
            panelTahsilatAsama.TabIndex = 47;
            // 
            // monthCalendarTahsilatTarihi
            // 
            monthCalendarTahsilatTarihi.Location = new System.Drawing.Point(657, 70);
            monthCalendarTahsilatTarihi.Name = "monthCalendarTahsilatTarihi";
            monthCalendarTahsilatTarihi.TabIndex = 1;
            monthCalendarTahsilatTarihi.Visible = false;
            monthCalendarTahsilatTarihi.DateSelected += monthCalendarTahsilatTarihi_DateSelected;
            monthCalendarTahsilatTarihi.MouseLeave += monthCalendarTahsilatTarihi_MouseLeave;
            // 
            // textBoxAciklamalar
            // 
            textBoxAciklamalar.Location = new System.Drawing.Point(496, 592);
            textBoxAciklamalar.MaxLength = 500;
            textBoxAciklamalar.Multiline = true;
            textBoxAciklamalar.Name = "textBoxAciklamalar";
            textBoxAciklamalar.ScrollBars = ScrollBars.Vertical;
            textBoxAciklamalar.Size = new System.Drawing.Size(599, 88);
            textBoxAciklamalar.TabIndex = 46;
            textBoxAciklamalar.TextChanged += textBoxAciklamalar_TextChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label15.Location = new System.Drawing.Point(708, 559);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(18, 30);
            label15.TabIndex = 45;
            label15.Text = ":";
            label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label16.Location = new System.Drawing.Point(493, 561);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(218, 30);
            label16.TabIndex = 44;
            label16.Text = "Açıklamalar ve Notlar";
            label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(445, 92);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(18, 30);
            label1.TabIndex = 42;
            label1.Text = ":";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(320, 92);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(117, 30);
            label2.TabIndex = 41;
            label2.Text = "Satış Tutarı";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxSatisTutari
            // 
            textBoxSatisTutari.BackColor = System.Drawing.Color.WhiteSmoke;
            textBoxSatisTutari.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxSatisTutari.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxSatisTutari.BorderRadius = 0;
            textBoxSatisTutari.BorderSize = 2;
            textBoxSatisTutari.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxSatisTutari.ForeColor = System.Drawing.Color.Black;
            textBoxSatisTutari.isPlaceHolder = false;
            textBoxSatisTutari.Location = new System.Drawing.Point(469, 90);
            textBoxSatisTutari.Multiline = false;
            textBoxSatisTutari.Name = "textBoxSatisTutari";
            textBoxSatisTutari.Padding = new Padding(10, 7, 10, 7);
            textBoxSatisTutari.PasswordChar = false;
            textBoxSatisTutari.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxSatisTutari.PlaceholderText = "";
            textBoxSatisTutari.ReadOnly = true;
            textBoxSatisTutari.SelectionStart = 0;
            textBoxSatisTutari.Size = new System.Drawing.Size(120, 32);
            textBoxSatisTutari.TabIndex = 40;
            textBoxSatisTutari.TextAlignment = HorizontalAlignment.Left;
            textBoxSatisTutari.TextCustom = "";
            textBoxSatisTutari.UnderlinedStyle = false;
            // 
            // groupBoxKDVDahilMi
            // 
            groupBoxKDVDahilMi.Controls.Add(customRadioButtonNetKdv);
            groupBoxKDVDahilMi.Controls.Add(customRadioButtonToplam);
            groupBoxKDVDahilMi.Location = new System.Drawing.Point(28, 50);
            groupBoxKDVDahilMi.Name = "groupBoxKDVDahilMi";
            groupBoxKDVDahilMi.Size = new System.Drawing.Size(200, 39);
            groupBoxKDVDahilMi.TabIndex = 39;
            groupBoxKDVDahilMi.TabStop = false;
            // 
            // customRadioButtonNetKdv
            // 
            customRadioButtonNetKdv.AutoSize = true;
            customRadioButtonNetKdv.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            customRadioButtonNetKdv.Location = new System.Drawing.Point(6, 11);
            customRadioButtonNetKdv.MinimumSize = new System.Drawing.Size(0, 21);
            customRadioButtonNetKdv.Name = "customRadioButtonNetKdv";
            customRadioButtonNetKdv.Size = new System.Drawing.Size(94, 21);
            customRadioButtonNetKdv.TabIndex = 37;
            customRadioButtonNetKdv.TabStop = true;
            customRadioButtonNetKdv.Text = "NET + KDV";
            customRadioButtonNetKdv.UnCheckedColor = System.Drawing.Color.Gray;
            customRadioButtonNetKdv.UseVisualStyleBackColor = true;
            customRadioButtonNetKdv.Click += customRadioButtonNetKdv_Click;
            // 
            // customRadioButtonToplam
            // 
            customRadioButtonToplam.AutoSize = true;
            customRadioButtonToplam.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            customRadioButtonToplam.Location = new System.Drawing.Point(111, 11);
            customRadioButtonToplam.MinimumSize = new System.Drawing.Size(0, 21);
            customRadioButtonToplam.Name = "customRadioButtonToplam";
            customRadioButtonToplam.Size = new System.Drawing.Size(83, 21);
            customRadioButtonToplam.TabIndex = 38;
            customRadioButtonToplam.TabStop = true;
            customRadioButtonToplam.Text = "TOPLAM";
            customRadioButtonToplam.UnCheckedColor = System.Drawing.Color.Gray;
            customRadioButtonToplam.UseVisualStyleBackColor = true;
            customRadioButtonToplam.Click += customRadioButtonToplam_Click;
            // 
            // numericTahsilatAsamaSayisi
            // 
            numericTahsilatAsamaSayisi.Location = new System.Drawing.Point(854, 99);
            numericTahsilatAsamaSayisi.Name = "numericTahsilatAsamaSayisi";
            numericTahsilatAsamaSayisi.Size = new System.Drawing.Size(68, 23);
            numericTahsilatAsamaSayisi.TabIndex = 35;
            numericTahsilatAsamaSayisi.ValueChanged += numericTahsilatAsamaSayisi_ValueChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label14.Location = new System.Drawing.Point(830, 92);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(18, 30);
            label14.TabIndex = 34;
            label14.Text = ":";
            label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label13.Location = new System.Drawing.Point(612, 92);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(212, 30);
            label13.TabIndex = 33;
            label13.Text = "Tahsilat Aşama Sayısı";
            label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Red;
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1107, 47);
            panelHeader.TabIndex = 22;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = System.Drawing.Color.Red;
            buttonClose.BackgroundColor = System.Drawing.Color.Red;
            buttonClose.BorderColor = System.Drawing.Color.LavenderBlush;
            buttonClose.BorderRadius = 10;
            buttonClose.BorderSize = 2;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonClose.ForeColor = System.Drawing.Color.White;
            buttonClose.Location = new System.Drawing.Point(1060, 4);
            buttonClose.Margin = new Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(40, 38);
            buttonClose.TabIndex = 106;
            buttonClose.Text = "x";
            buttonClose.TextColor = System.Drawing.Color.White;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.BackColor = System.Drawing.Color.Red;
            buttonHelp.BackgroundColor = System.Drawing.Color.Red;
            buttonHelp.BorderColor = System.Drawing.Color.LavenderBlush;
            buttonHelp.BorderRadius = 10;
            buttonHelp.BorderSize = 2;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = FlatStyle.Flat;
            buttonHelp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonHelp.ForeColor = System.Drawing.Color.White;
            buttonHelp.Location = new System.Drawing.Point(980, 4);
            buttonHelp.Margin = new Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new Padding(3, 0, 0, 0);
            buttonHelp.Size = new System.Drawing.Size(40, 38);
            buttonHelp.TabIndex = 105;
            buttonHelp.Text = "?";
            buttonHelp.TextColor = System.Drawing.Color.White;
            buttonHelp.UseVisualStyleBackColor = false;
            // 
            // buttomMinimize
            // 
            buttomMinimize.BackColor = System.Drawing.Color.Red;
            buttomMinimize.BackgroundColor = System.Drawing.Color.Red;
            buttomMinimize.BorderColor = System.Drawing.Color.LavenderBlush;
            buttomMinimize.BorderRadius = 10;
            buttomMinimize.BorderSize = 2;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = FlatStyle.Flat;
            buttomMinimize.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttomMinimize.ForeColor = System.Drawing.Color.White;
            buttomMinimize.Location = new System.Drawing.Point(1020, 4);
            buttomMinimize.Margin = new Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(40, 38);
            buttomMinimize.TabIndex = 104;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            labelHeader.Location = new System.Drawing.Point(3, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(142, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Tahsilat Planı";
            // 
            // rButtonKapat
            // 
            rButtonKapat.BackColor = System.Drawing.Color.Brown;
            rButtonKapat.BackgroundColor = System.Drawing.Color.Brown;
            rButtonKapat.BorderColor = System.Drawing.Color.Crimson;
            rButtonKapat.BorderRadius = 40;
            rButtonKapat.BorderSize = 5;
            rButtonKapat.FlatAppearance.BorderSize = 0;
            rButtonKapat.FlatStyle = FlatStyle.Flat;
            rButtonKapat.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonKapat.ForeColor = System.Drawing.Color.White;
            rButtonKapat.Location = new System.Drawing.Point(234, 592);
            rButtonKapat.Name = "rButtonKapat";
            rButtonKapat.Size = new System.Drawing.Size(150, 66);
            rButtonKapat.TabIndex = 21;
            rButtonKapat.Text = "KAPAT";
            rButtonKapat.TextColor = System.Drawing.Color.White;
            rButtonKapat.UseVisualStyleBackColor = false;
            rButtonKapat.Click += rButtonKapat_Click;
            // 
            // rButtonGuncelle
            // 
            rButtonGuncelle.BackColor = System.Drawing.Color.CornflowerBlue;
            rButtonGuncelle.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            rButtonGuncelle.BorderColor = System.Drawing.Color.RoyalBlue;
            rButtonGuncelle.BorderRadius = 40;
            rButtonGuncelle.BorderSize = 5;
            rButtonGuncelle.FlatAppearance.BorderSize = 0;
            rButtonGuncelle.FlatStyle = FlatStyle.Flat;
            rButtonGuncelle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonGuncelle.ForeColor = System.Drawing.Color.White;
            rButtonGuncelle.Location = new System.Drawing.Point(42, 592);
            rButtonGuncelle.Name = "rButtonGuncelle";
            rButtonGuncelle.Size = new System.Drawing.Size(150, 66);
            rButtonGuncelle.TabIndex = 20;
            rButtonGuncelle.Text = "GÜNCELLE";
            rButtonGuncelle.TextColor = System.Drawing.Color.White;
            rButtonGuncelle.UseVisualStyleBackColor = false;
            rButtonGuncelle.Click += buttonGuncelle_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label12.Location = new System.Drawing.Point(153, 92);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(18, 30);
            label12.TabIndex = 15;
            label12.Text = ":";
            label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label10.Location = new System.Drawing.Point(28, 92);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(119, 30);
            label10.TabIndex = 13;
            label10.Text = "Proje Kodu";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProjeKodu
            // 
            textBoxProjeKodu.BackColor = System.Drawing.Color.WhiteSmoke;
            textBoxProjeKodu.BorderColor = System.Drawing.Color.MediumSlateBlue;
            textBoxProjeKodu.BorderFocusColor = System.Drawing.Color.HotPink;
            textBoxProjeKodu.BorderRadius = 0;
            textBoxProjeKodu.BorderSize = 2;
            textBoxProjeKodu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxProjeKodu.ForeColor = System.Drawing.Color.Black;
            textBoxProjeKodu.isPlaceHolder = false;
            textBoxProjeKodu.Location = new System.Drawing.Point(177, 90);
            textBoxProjeKodu.Multiline = false;
            textBoxProjeKodu.Name = "textBoxProjeKodu";
            textBoxProjeKodu.Padding = new Padding(10, 7, 10, 7);
            textBoxProjeKodu.PasswordChar = false;
            textBoxProjeKodu.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBoxProjeKodu.PlaceholderText = "";
            textBoxProjeKodu.ReadOnly = true;
            textBoxProjeKodu.SelectionStart = 0;
            textBoxProjeKodu.Size = new System.Drawing.Size(120, 32);
            textBoxProjeKodu.TabIndex = 4;
            textBoxProjeKodu.TextAlignment = HorizontalAlignment.Left;
            textBoxProjeKodu.TextCustom = "";
            textBoxProjeKodu.UnderlinedStyle = false;
            // 
            // rButtonKaydet
            // 
            rButtonKaydet.BackColor = System.Drawing.Color.LimeGreen;
            rButtonKaydet.BackgroundColor = System.Drawing.Color.LimeGreen;
            rButtonKaydet.BorderColor = System.Drawing.Color.MediumSeaGreen;
            rButtonKaydet.BorderRadius = 40;
            rButtonKaydet.BorderSize = 5;
            rButtonKaydet.FlatAppearance.BorderSize = 0;
            rButtonKaydet.FlatStyle = FlatStyle.Flat;
            rButtonKaydet.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonKaydet.ForeColor = System.Drawing.Color.White;
            rButtonKaydet.Location = new System.Drawing.Point(42, 592);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new System.Drawing.Size(150, 66);
            rButtonKaydet.TabIndex = 49;
            rButtonKaydet.Text = "KAYDET";
            rButtonKaydet.TextColor = System.Drawing.Color.White;
            rButtonKaydet.UseVisualStyleBackColor = false;
            rButtonKaydet.Click += rButtonKaydet_Click;
            // 
            // TahsilatPlanKayitFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(1107, 692);
            Controls.Add(personelKayitMainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "TahsilatPlanKayitFormu";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PersonelKayit";
            FormClosing += TahsilatPlanKayitFormu_FormClosing;
            personelKayitMainPanel.ResumeLayout(false);
            personelKayitMainPanel.PerformLayout();
            panelTahsilatAsama.ResumeLayout(false);
            groupBoxKDVDahilMi.ResumeLayout(false);
            groupBoxKDVDahilMi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericTahsilatAsamaSayisi).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Panel personelKayitMainPanel;
        private Label label2;
        private Label label1;
        private Label label12;
        private Label label10;
        private CustomControls.RoundedButton rButtonKapat;
        private Panel panelHeader;
        private Label labelHeader;
        public CustomControls.CustomTextBox textBoxProjeKodu;
        public CustomControls.CustomTextBox textBoxSoyisim;
        public CustomControls.CustomTextBox textBoxTelefon;
        public CustomControls.CustomTextBox textBoxEmail;
        public CustomControls.CustomTextBox textBoxPozisyon;
        public CustomControls.RoundedButton rButtonGuncelle;
        public CustomControls.CustomTextBox textBoxFirma;
        private Label labelOranVeKdvUyari;
        private OpenFileDialog openFileDialogResim;
        private NumericUpDown numericTahsilatAsamaSayisi;
        private Label label14;
        private Label label13;
        private GroupBox groupBoxKDVDahilMi;
        private CustomControls.CustomRadioButton customRadioButtonNetKdv;
        private CustomControls.CustomRadioButton customRadioButtonToplam;
        public CustomControls.CustomTextBox textBoxSatisTutari;
        private TextBox textBoxAciklamalar;
        private Label label15;
        private Label label16;
        public Panel panelTahsilatAsama;
        private MonthCalendar monthCalendarTahsilatTarihi;
        public CustomControls.RoundedButton roundedProjeSafhalari;
        private CustomControls.RoundedButton rButtonKaydet;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
    }
}