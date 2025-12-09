using System.Drawing;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Genel
{
    partial class ExcelGrupParametreForm
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
            fcbKarsilastirmaOperator = new YektamakDesktop.CustomControls.FilterableComboBox();
            ctbAnahtarKelime = new YektamakDesktop.CustomControls.CustomTextBox();
            fcbStokGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbMalzemeGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbMalzemeAltGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbMalzemeAltGrup2 = new YektamakDesktop.CustomControls.FilterableComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            label8 = new Label();
            ctbId = new YektamakDesktop.CustomControls.CustomTextBox();
            label9 = new Label();
            fcbStokTip = new YektamakDesktop.CustomControls.FilterableComboBox();
            label10 = new Label();
            fcbMalzemeStandart = new YektamakDesktop.CustomControls.FilterableComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            koşuluSilToolStripMenuItem = new ToolStripMenuItem();
            chkTalasli = new CheckBox();
            button1 = new Button();
            ctbCount = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            chkBukum = new CheckBox();
            customButtonNewRecord1 = new YektamakDesktop.CustomControls.CustomButtonNewRecord();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            fcbExcelSutunAd = new YektamakDesktop.CustomControls.FilterableComboBox();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // fcbKarsilastirmaOperator
            // 
            fcbKarsilastirmaOperator.AutoValidate = AutoValidate.Disable;
            fcbKarsilastirmaOperator.BorderColor = Color.Silver;
            fcbKarsilastirmaOperator.BorderRadius = 8;
            fcbKarsilastirmaOperator.BorderSize = 1;
            fcbKarsilastirmaOperator.DisplayMember = "";
            fcbKarsilastirmaOperator.Font = new Font("Segoe UI", 8F);
            fcbKarsilastirmaOperator.Location = new Point(128, 84);
            fcbKarsilastirmaOperator.Margin = new Padding(1);
            fcbKarsilastirmaOperator.Name = "fcbKarsilastirmaOperator";
            fcbKarsilastirmaOperator.Padding = new Padding(6, 4, 6, 4);
            fcbKarsilastirmaOperator.PlaceholderText = "Seçiniz...";
            fcbKarsilastirmaOperator.ReadOnly = false;
            fcbKarsilastirmaOperator.Size = new Size(102, 25);
            fcbKarsilastirmaOperator.TabIndex = 2;
            fcbKarsilastirmaOperator.ValueMember = "";
            fcbKarsilastirmaOperator.SelectedIndexChanged += fcbKarsilastirmaOperator_SelectedIndexChanged;
            // 
            // ctbAnahtarKelime
            // 
            ctbAnahtarKelime.BackColor = Color.White;
            ctbAnahtarKelime.BorderColor = Color.Silver;
            ctbAnahtarKelime.BorderFocusColor = Color.HotPink;
            ctbAnahtarKelime.BorderSize = 1;
            ctbAnahtarKelime.Font = new Font("Segoe UI", 8F);
            ctbAnahtarKelime.ForeColor = Color.Black;
            ctbAnahtarKelime.Location = new Point(128, 111);
            ctbAnahtarKelime.Margin = new Padding(1);
            ctbAnahtarKelime.Multiline = false;
            ctbAnahtarKelime.Name = "ctbAnahtarKelime";
            ctbAnahtarKelime.Padding = new Padding(3);
            ctbAnahtarKelime.PasswordChar = false;
            ctbAnahtarKelime.PlaceholderColor = Color.DarkGray;
            ctbAnahtarKelime.PlaceholderText = "";
            ctbAnahtarKelime.ReadOnly = false;
            ctbAnahtarKelime.SelectionStart = 0;
            ctbAnahtarKelime.Size = new Size(171, 25);
            ctbAnahtarKelime.TabIndex = 3;
            ctbAnahtarKelime.TextAlignment = HorizontalAlignment.Left;
            ctbAnahtarKelime.TextCustom = "";
            ctbAnahtarKelime.UnderlinedStyle = false;
            // 
            // fcbStokGrup
            // 
            fcbStokGrup.BorderColor = Color.Silver;
            fcbStokGrup.BorderRadius = 8;
            fcbStokGrup.BorderSize = 1;
            fcbStokGrup.DisplayMember = "ad";
            fcbStokGrup.Font = new Font("Segoe UI", 8F);
            fcbStokGrup.Location = new Point(423, 56);
            fcbStokGrup.Margin = new Padding(1);
            fcbStokGrup.Name = "fcbStokGrup";
            fcbStokGrup.Padding = new Padding(6, 4, 6, 4);
            fcbStokGrup.PlaceholderText = "Seçiniz...";
            fcbStokGrup.ReadOnly = false;
            fcbStokGrup.Size = new Size(172, 25);
            fcbStokGrup.TabIndex = 4;
            fcbStokGrup.ValueMember = "Id";
            fcbStokGrup.SelectedIndexChanged += fcbStokGrup_SelectedIndexChanged;
            // 
            // fcbMalzemeGrup
            // 
            fcbMalzemeGrup.BorderColor = Color.Silver;
            fcbMalzemeGrup.BorderRadius = 8;
            fcbMalzemeGrup.BorderSize = 1;
            fcbMalzemeGrup.DisplayMember = "ad";
            fcbMalzemeGrup.Enabled = false;
            fcbMalzemeGrup.Font = new Font("Segoe UI", 8F);
            fcbMalzemeGrup.Location = new Point(423, 83);
            fcbMalzemeGrup.Margin = new Padding(1);
            fcbMalzemeGrup.Name = "fcbMalzemeGrup";
            fcbMalzemeGrup.Padding = new Padding(6, 4, 6, 4);
            fcbMalzemeGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeGrup.ReadOnly = false;
            fcbMalzemeGrup.Size = new Size(172, 25);
            fcbMalzemeGrup.TabIndex = 5;
            fcbMalzemeGrup.ValueMember = "Id";
            fcbMalzemeGrup.SelectedIndexChanged += fcbMalzemeGrup_SelectedIndexChanged;
            // 
            // fcbMalzemeAltGrup
            // 
            fcbMalzemeAltGrup.BorderColor = Color.Silver;
            fcbMalzemeAltGrup.BorderRadius = 8;
            fcbMalzemeAltGrup.BorderSize = 1;
            fcbMalzemeAltGrup.DisplayMember = "ad";
            fcbMalzemeAltGrup.Enabled = false;
            fcbMalzemeAltGrup.Font = new Font("Segoe UI", 8F);
            fcbMalzemeAltGrup.Location = new Point(423, 110);
            fcbMalzemeAltGrup.Margin = new Padding(1);
            fcbMalzemeAltGrup.Name = "fcbMalzemeAltGrup";
            fcbMalzemeAltGrup.Padding = new Padding(6, 4, 6, 4);
            fcbMalzemeAltGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeAltGrup.ReadOnly = false;
            fcbMalzemeAltGrup.Size = new Size(172, 25);
            fcbMalzemeAltGrup.TabIndex = 6;
            fcbMalzemeAltGrup.ValueMember = "Id";
            fcbMalzemeAltGrup.SelectedIndexChanged += fcbMalzemeAltGrup_SelectedIndexChanged;
            // 
            // fcbMalzemeAltGrup2
            // 
            fcbMalzemeAltGrup2.BorderColor = Color.Silver;
            fcbMalzemeAltGrup2.BorderRadius = 8;
            fcbMalzemeAltGrup2.BorderSize = 1;
            fcbMalzemeAltGrup2.DisplayMember = "ad";
            fcbMalzemeAltGrup2.Enabled = false;
            fcbMalzemeAltGrup2.Font = new Font("Segoe UI", 8F);
            fcbMalzemeAltGrup2.Location = new Point(423, 137);
            fcbMalzemeAltGrup2.Margin = new Padding(1);
            fcbMalzemeAltGrup2.Name = "fcbMalzemeAltGrup2";
            fcbMalzemeAltGrup2.Padding = new Padding(6, 4, 6, 4);
            fcbMalzemeAltGrup2.PlaceholderText = "Seçiniz...";
            fcbMalzemeAltGrup2.ReadOnly = false;
            fcbMalzemeAltGrup2.Size = new Size(172, 25);
            fcbMalzemeAltGrup2.TabIndex = 7;
            fcbMalzemeAltGrup2.ValueMember = "Id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label1.Location = new Point(307, 63);
            label1.Name = "label1";
            label1.Size = new Size(66, 13);
            label1.TabIndex = 8;
            label1.Text = "Stok Grubu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label2.Location = new Point(13, 62);
            label2.Name = "label2";
            label2.Size = new Size(88, 13);
            label2.TabIndex = 9;
            label2.Text = "Excel Sütun Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label3.Location = new Point(13, 89);
            label3.Name = "label3";
            label3.Size = new Size(99, 13);
            label3.TabIndex = 10;
            label3.Text = "Karşılaştırma Oprt";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label4.Location = new Point(13, 116);
            label4.Name = "label4";
            label4.Size = new Size(87, 13);
            label4.TabIndex = 11;
            label4.Text = "Anahtar Kelime";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label5.Location = new Point(307, 144);
            label5.Name = "label5";
            label5.Size = new Size(114, 13);
            label5.TabIndex = 12;
            label5.Text = "Malzeme Alt Grubu2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label6.Location = new Point(307, 117);
            label6.Name = "label6";
            label6.Size = new Size(108, 13);
            label6.TabIndex = 13;
            label6.Text = "Malzeme Alt Grubu";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label7.Location = new Point(307, 90);
            label7.Name = "label7";
            label7.Size = new Size(90, 13);
            label7.TabIndex = 14;
            label7.Text = "Malzeme Grubu";
            // 
            // customButtonSave1
            // 
            customButtonSave1.BackColor = Color.Transparent;
            customButtonSave1.Location = new Point(646, 126);
            customButtonSave1.Margin = new Padding(4, 3, 4, 3);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new Size(36, 36);
            customButtonSave1.TabIndex = 15;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label8.Location = new Point(13, 35);
            label8.Name = "label8";
            label8.Size = new Size(17, 13);
            label8.TabIndex = 17;
            label8.Text = "Id";
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
            ctbId.Location = new Point(128, 30);
            ctbId.Margin = new Padding(1);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new Padding(3);
            ctbId.PasswordChar = false;
            ctbId.PlaceholderColor = Color.DarkGray;
            ctbId.PlaceholderText = "";
            ctbId.ReadOnly = false;
            ctbId.SelectionStart = 0;
            ctbId.Size = new Size(66, 25);
            ctbId.TabIndex = 16;
            ctbId.TextAlignment = HorizontalAlignment.Left;
            ctbId.TextCustom = "";
            ctbId.UnderlinedStyle = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label9.Location = new Point(307, 36);
            label9.Name = "label9";
            label9.Size = new Size(52, 13);
            label9.TabIndex = 19;
            label9.Text = "Stok Tipi";
            // 
            // fcbStokTip
            // 
            fcbStokTip.BorderColor = Color.Silver;
            fcbStokTip.BorderRadius = 8;
            fcbStokTip.BorderSize = 1;
            fcbStokTip.DisplayMember = "ad";
            fcbStokTip.Font = new Font("Segoe UI", 8F);
            fcbStokTip.Location = new Point(423, 29);
            fcbStokTip.Margin = new Padding(1);
            fcbStokTip.Name = "fcbStokTip";
            fcbStokTip.Padding = new Padding(6, 4, 6, 4);
            fcbStokTip.PlaceholderText = "Seçiniz...";
            fcbStokTip.ReadOnly = false;
            fcbStokTip.Size = new Size(172, 25);
            fcbStokTip.TabIndex = 18;
            fcbStokTip.ValueMember = "Id";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label10.Location = new Point(13, 143);
            label10.Name = "label10";
            label10.Size = new Size(101, 13);
            label10.TabIndex = 21;
            label10.Text = "Malzeme Standart";
            // 
            // fcbMalzemeStandart
            // 
            fcbMalzemeStandart.BorderColor = Color.Silver;
            fcbMalzemeStandart.BorderRadius = 8;
            fcbMalzemeStandart.BorderSize = 1;
            fcbMalzemeStandart.DisplayMember = "ad";
            fcbMalzemeStandart.Font = new Font("Segoe UI", 8F);
            fcbMalzemeStandart.Location = new Point(128, 138);
            fcbMalzemeStandart.Margin = new Padding(1);
            fcbMalzemeStandart.Name = "fcbMalzemeStandart";
            fcbMalzemeStandart.Padding = new Padding(6, 4, 6, 4);
            fcbMalzemeStandart.PlaceholderText = "Seçiniz...";
            fcbMalzemeStandart.ReadOnly = false;
            fcbMalzemeStandart.Size = new Size(172, 25);
            fcbMalzemeStandart.TabIndex = 20;
            fcbMalzemeStandart.ValueMember = "Id";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { koşuluSilToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(126, 26);
            // 
            // koşuluSilToolStripMenuItem
            // 
            koşuluSilToolStripMenuItem.Name = "koşuluSilToolStripMenuItem";
            koşuluSilToolStripMenuItem.Size = new Size(125, 22);
            koşuluSilToolStripMenuItem.Text = "Koşulu Sil";
            koşuluSilToolStripMenuItem.Click += koşuluSilToolStripMenuItem_Click;
            // 
            // chkTalasli
            // 
            chkTalasli.AutoSize = true;
            chkTalasli.Location = new Point(423, 166);
            chkTalasli.Name = "chkTalasli";
            chkTalasli.Size = new Size(57, 17);
            chkTalasli.TabIndex = 23;
            chkTalasli.Text = "Talaşlı";
            chkTalasli.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(269, 167);
            button1.Name = "button1";
            button1.Size = new Size(30, 20);
            button1.TabIndex = 24;
            button1.Text = "ve";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ctbCount
            // 
            ctbCount.BackColor = Color.White;
            ctbCount.Font = new Font("Segoe UI", 8F);
            ctbCount.ForeColor = Color.Black;
            ctbCount.Location = new Point(232, 84);
            ctbCount.Margin = new Padding(1);
            ctbCount.Name = "ctbCount";
            ctbCount.OndalikBasamak = 0;
            ctbCount.Padding = new Padding(3);
            ctbCount.Size = new Size(25, 25);
            ctbCount.TabIndex = 25;
            ctbCount.TextCustom = "0";
            ctbCount.Visible = false;
            // 
            // chkBukum
            // 
            chkBukum.AutoSize = true;
            chkBukum.Location = new Point(502, 167);
            chkBukum.Name = "chkBukum";
            chkBukum.Size = new Size(61, 17);
            chkBukum.TabIndex = 29;
            chkBukum.Text = "Büküm";
            chkBukum.UseVisualStyleBackColor = true;
            // 
            // customButtonNewRecord1
            // 
            customButtonNewRecord1.Location = new Point(646, 44);
            customButtonNewRecord1.Name = "customButtonNewRecord1";
            customButtonNewRecord1.Size = new Size(31, 31);
            customButtonNewRecord1.TabIndex = 30;
            customButtonNewRecord1.Click += roundedButton1_Click;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = Color.SteelBlue;
            headerPanel1.Baslik = "Excel Veri Alma Grup Parametreleri";
            headerPanel1.Location = new Point(0, 0);
            headerPanel1.Margin = new Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new Padding(1);
            headerPanel1.Size = new Size(865, 25);
            headerPanel1.TabIndex = 33;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new Point(20, 201);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(832, 261);
            universalGrid1.TabIndex = 34;
            // 
            // fcbExcelSutunAd
            // 
            fcbExcelSutunAd.BorderColor = Color.Silver;
            fcbExcelSutunAd.BorderRadius = 8;
            fcbExcelSutunAd.BorderSize = 1;
            fcbExcelSutunAd.DisplayMember = "";
            fcbExcelSutunAd.Font = new Font("Segoe UI", 8F);
            fcbExcelSutunAd.Location = new Point(128, 57);
            fcbExcelSutunAd.Margin = new Padding(1);
            fcbExcelSutunAd.Name = "fcbExcelSutunAd";
            fcbExcelSutunAd.Padding = new Padding(3);
            fcbExcelSutunAd.PlaceholderText = "Seçiniz...";
            fcbExcelSutunAd.ReadOnly = false;
            fcbExcelSutunAd.Size = new Size(129, 25);
            fcbExcelSutunAd.TabIndex = 35;
            fcbExcelSutunAd.ValueMember = "";
            // 
            // ExcelGrupParametreForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 474);
            Controls.Add(fcbExcelSutunAd);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            Controls.Add(customButtonNewRecord1);
            Controls.Add(chkBukum);
            Controls.Add(ctbCount);
            Controls.Add(button1);
            Controls.Add(chkTalasli);
            Controls.Add(label10);
            Controls.Add(fcbMalzemeStandart);
            Controls.Add(label9);
            Controls.Add(fcbStokTip);
            Controls.Add(label8);
            Controls.Add(ctbId);
            Controls.Add(customButtonSave1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fcbMalzemeAltGrup2);
            Controls.Add(fcbMalzemeAltGrup);
            Controls.Add(fcbMalzemeGrup);
            Controls.Add(fcbStokGrup);
            Controls.Add(ctbAnahtarKelime);
            Controls.Add(fcbKarsilastirmaOperator);
            Font = new Font("Segoe UI", 8F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ExcelGrupParametreForm";
            Text = "ExcelGrupParametreForm";
            FormClosing += ExcelGrupParametreForm_FormClosing;
            Load += ExcelGrupParametre_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CustomControls.FilterableComboBox fcbKarsilastirmaOperator;
        private CustomControls.CustomTextBox ctbAnahtarKelime;
        private CustomControls.FilterableComboBox fcbStokGrup;
        private CustomControls.FilterableComboBox fcbMalzemeGrup;
        private CustomControls.FilterableComboBox fcbMalzemeAltGrup;
        private CustomControls.FilterableComboBox fcbMalzemeAltGrup2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CustomControls.CustomButtonSave customButtonSave1;
        private System.Windows.Forms.Label label8;
        private CustomControls.CustomTextBox ctbId;
        private System.Windows.Forms.Label label9;
        private CustomControls.FilterableComboBox fcbStokTip;
        private System.Windows.Forms.Label label10;
        private CustomControls.FilterableComboBox fcbMalzemeStandart;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem koşuluSilToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkTalasli;
        private System.Windows.Forms.Button button1;
        private CustomControls.CustomTextBoxSayisal ctbCount;
        private CheckBox chkBukum;
        private CustomControls.CustomButtonNewRecord customButtonNewRecord1;
        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.FilterableComboBox fcbExcelSutunAd;
    }
}