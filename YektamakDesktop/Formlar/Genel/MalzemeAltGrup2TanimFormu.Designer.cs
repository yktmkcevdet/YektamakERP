using System.Drawing;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Genel
{
    partial class MalzemeAltGrup2TanimFormu
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
            ctbMalzemeAltGrup2Id = new YektamakDesktop.CustomControls.CustomTextBox();
            label3 = new Label();
            label1 = new Label();
            ctbMalzemeAltGrup2Ad = new YektamakDesktop.CustomControls.CustomTextBox();
            label2 = new Label();
            ctbMalzemeAltGrup2Kod = new YektamakDesktop.CustomControls.CustomTextBox();
            fcbStokGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            label4 = new Label();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            label5 = new Label();
            fcbMalzemeAltGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            malzemeGrubunuSilToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            formuTemizleToolStripMenuItem = new ToolStripMenuItem();
            label6 = new Label();
            fcbMalzemeGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            customButtonNewRecord1 = new YektamakDesktop.CustomControls.CustomButtonNewRecord();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // ctbMalzemeAltGrup2Id
            // 
            ctbMalzemeAltGrup2Id.BackColor = Color.White;
            ctbMalzemeAltGrup2Id.BorderColor = Color.Silver;
            ctbMalzemeAltGrup2Id.BorderFocusColor = Color.HotPink;
            ctbMalzemeAltGrup2Id.BorderSize = 1;
            ctbMalzemeAltGrup2Id.Enabled = false;
            ctbMalzemeAltGrup2Id.Font = new Font("Segoe UI", 8F);
            ctbMalzemeAltGrup2Id.ForeColor = Color.Black;
            ctbMalzemeAltGrup2Id.Location = new Point(170, 43);
            ctbMalzemeAltGrup2Id.Margin = new Padding(1);
            ctbMalzemeAltGrup2Id.Multiline = false;
            ctbMalzemeAltGrup2Id.Name = "ctbMalzemeAltGrup2Id";
            ctbMalzemeAltGrup2Id.Padding = new Padding(3);
            ctbMalzemeAltGrup2Id.PasswordChar = false;
            ctbMalzemeAltGrup2Id.PlaceholderColor = Color.DarkGray;
            ctbMalzemeAltGrup2Id.PlaceholderText = "";
            ctbMalzemeAltGrup2Id.ReadOnly = false;
            ctbMalzemeAltGrup2Id.SelectionStart = 0;
            ctbMalzemeAltGrup2Id.Size = new Size(63, 25);
            ctbMalzemeAltGrup2Id.TabIndex = 1;
            ctbMalzemeAltGrup2Id.TextAlignment = HorizontalAlignment.Left;
            ctbMalzemeAltGrup2Id.TextCustom = "";
            ctbMalzemeAltGrup2Id.UnderlinedStyle = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label3.Location = new Point(33, 48);
            label3.Name = "label3";
            label3.Size = new Size(18, 13);
            label3.TabIndex = 2;
            label3.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label1.Location = new Point(33, 75);
            label1.Name = "label1";
            label1.Size = new Size(128, 13);
            label1.TabIndex = 5;
            label1.Text = "Malzeme Alt Grup2 Adı";
            // 
            // ctbMalzemeAltGrup2Ad
            // 
            ctbMalzemeAltGrup2Ad.BackColor = Color.White;
            ctbMalzemeAltGrup2Ad.BorderColor = Color.Silver;
            ctbMalzemeAltGrup2Ad.BorderFocusColor = Color.HotPink;
            ctbMalzemeAltGrup2Ad.BorderSize = 1;
            ctbMalzemeAltGrup2Ad.Font = new Font("Segoe UI", 8F);
            ctbMalzemeAltGrup2Ad.ForeColor = Color.Black;
            ctbMalzemeAltGrup2Ad.Location = new Point(170, 70);
            ctbMalzemeAltGrup2Ad.Margin = new Padding(1);
            ctbMalzemeAltGrup2Ad.Multiline = false;
            ctbMalzemeAltGrup2Ad.Name = "ctbMalzemeAltGrup2Ad";
            ctbMalzemeAltGrup2Ad.Padding = new Padding(3);
            ctbMalzemeAltGrup2Ad.PasswordChar = false;
            ctbMalzemeAltGrup2Ad.PlaceholderColor = Color.DarkGray;
            ctbMalzemeAltGrup2Ad.PlaceholderText = "";
            ctbMalzemeAltGrup2Ad.ReadOnly = false;
            ctbMalzemeAltGrup2Ad.SelectionStart = 0;
            ctbMalzemeAltGrup2Ad.Size = new Size(262, 25);
            ctbMalzemeAltGrup2Ad.TabIndex = 4;
            ctbMalzemeAltGrup2Ad.TextAlignment = HorizontalAlignment.Left;
            ctbMalzemeAltGrup2Ad.TextCustom = "";
            ctbMalzemeAltGrup2Ad.UnderlinedStyle = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label2.Location = new Point(33, 102);
            label2.Name = "label2";
            label2.Size = new Size(138, 13);
            label2.TabIndex = 7;
            label2.Text = "Malzeme Alt Grup2 Kodu";
            // 
            // ctbMalzemeAltGrup2Kod
            // 
            ctbMalzemeAltGrup2Kod.BackColor = Color.White;
            ctbMalzemeAltGrup2Kod.BorderColor = Color.Silver;
            ctbMalzemeAltGrup2Kod.BorderFocusColor = Color.HotPink;
            ctbMalzemeAltGrup2Kod.BorderSize = 1;
            ctbMalzemeAltGrup2Kod.Font = new Font("Segoe UI", 8F);
            ctbMalzemeAltGrup2Kod.ForeColor = Color.Black;
            ctbMalzemeAltGrup2Kod.Location = new Point(170, 97);
            ctbMalzemeAltGrup2Kod.Margin = new Padding(1);
            ctbMalzemeAltGrup2Kod.Multiline = false;
            ctbMalzemeAltGrup2Kod.Name = "ctbMalzemeAltGrup2Kod";
            ctbMalzemeAltGrup2Kod.Padding = new Padding(3);
            ctbMalzemeAltGrup2Kod.PasswordChar = false;
            ctbMalzemeAltGrup2Kod.PlaceholderColor = Color.DarkGray;
            ctbMalzemeAltGrup2Kod.PlaceholderText = "";
            ctbMalzemeAltGrup2Kod.ReadOnly = false;
            ctbMalzemeAltGrup2Kod.SelectionStart = 0;
            ctbMalzemeAltGrup2Kod.Size = new Size(134, 25);
            ctbMalzemeAltGrup2Kod.TabIndex = 6;
            ctbMalzemeAltGrup2Kod.TextAlignment = HorizontalAlignment.Left;
            ctbMalzemeAltGrup2Kod.TextCustom = "";
            ctbMalzemeAltGrup2Kod.UnderlinedStyle = false;
            // 
            // fcbStokGrup
            // 
            fcbStokGrup.BorderColor = Color.Silver;
            fcbStokGrup.BorderRadius = 8;
            fcbStokGrup.BorderSize = 1;
            fcbStokGrup.DisplayMember = "ad";
            fcbStokGrup.Font = new Font("Segoe UI", 8F);
            fcbStokGrup.Location = new Point(170, 124);
            fcbStokGrup.Margin = new Padding(1);
            fcbStokGrup.Name = "fcbStokGrup";
            fcbStokGrup.Padding = new Padding(6, 4, 6, 4);
            fcbStokGrup.PlaceholderText = "Seçiniz...";
            fcbStokGrup.ReadOnly = false;
            fcbStokGrup.Size = new Size(225, 25);
            fcbStokGrup.TabIndex = 8;
            fcbStokGrup.ValueMember = "Id";
            fcbStokGrup.SelectedIndexChanged += fcbStokGrup_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label4.Location = new Point(33, 129);
            label4.Name = "label4";
            label4.Size = new Size(66, 13);
            label4.TabIndex = 9;
            label4.Text = "Stok Grubu";
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            customButtonSave1.BackColor = Color.Transparent;
            customButtonSave1.Location = new Point(479, 140);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new Size(36, 36);
            customButtonSave1.TabIndex = 10;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label5.Location = new Point(33, 183);
            label5.Name = "label5";
            label5.Size = new Size(108, 13);
            label5.TabIndex = 12;
            label5.Text = "Malzeme Alt Grubu";
            // 
            // fcbMalzemeAltGrup
            // 
            fcbMalzemeAltGrup.BorderColor = Color.Silver;
            fcbMalzemeAltGrup.BorderRadius = 8;
            fcbMalzemeAltGrup.BorderSize = 1;
            fcbMalzemeAltGrup.DisplayMember = "ad";
            fcbMalzemeAltGrup.Font = new Font("Segoe UI", 8F);
            fcbMalzemeAltGrup.Location = new Point(170, 178);
            fcbMalzemeAltGrup.Margin = new Padding(1);
            fcbMalzemeAltGrup.Name = "fcbMalzemeAltGrup";
            fcbMalzemeAltGrup.Padding = new Padding(6, 4, 6, 4);
            fcbMalzemeAltGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeAltGrup.ReadOnly = false;
            fcbMalzemeAltGrup.Size = new Size(225, 25);
            fcbMalzemeAltGrup.TabIndex = 11;
            fcbMalzemeAltGrup.ValueMember = "Id";
            fcbMalzemeAltGrup.SelectedIndexChanged += fcbMalzemeAltGrup_SelectedIndexChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { malzemeGrubunuSilToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(188, 26);
            // 
            // malzemeGrubunuSilToolStripMenuItem
            // 
            malzemeGrubunuSilToolStripMenuItem.Name = "malzemeGrubunuSilToolStripMenuItem";
            malzemeGrubunuSilToolStripMenuItem.Size = new Size(187, 22);
            malzemeGrubunuSilToolStripMenuItem.Text = "Malzeme Grubunu Sil";
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { formuTemizleToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(152, 26);
            // 
            // formuTemizleToolStripMenuItem
            // 
            formuTemizleToolStripMenuItem.Name = "formuTemizleToolStripMenuItem";
            formuTemizleToolStripMenuItem.Size = new Size(151, 22);
            formuTemizleToolStripMenuItem.Text = "Formu Temizle";
            formuTemizleToolStripMenuItem.Click += formuTemizleToolStripMenuItem_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label6.Location = new Point(33, 156);
            label6.Name = "label6";
            label6.Size = new Size(90, 13);
            label6.TabIndex = 14;
            label6.Text = "Malzeme Grubu";
            // 
            // fcbMalzemeGrup
            // 
            fcbMalzemeGrup.BorderColor = Color.Silver;
            fcbMalzemeGrup.BorderRadius = 8;
            fcbMalzemeGrup.BorderSize = 1;
            fcbMalzemeGrup.DisplayMember = "ad";
            fcbMalzemeGrup.Font = new Font("Segoe UI", 8F);
            fcbMalzemeGrup.Location = new Point(170, 151);
            fcbMalzemeGrup.Margin = new Padding(1);
            fcbMalzemeGrup.Name = "fcbMalzemeGrup";
            fcbMalzemeGrup.Padding = new Padding(6, 4, 6, 4);
            fcbMalzemeGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeGrup.ReadOnly = false;
            fcbMalzemeGrup.Size = new Size(225, 25);
            fcbMalzemeGrup.TabIndex = 13;
            fcbMalzemeGrup.ValueMember = "Id";
            fcbMalzemeGrup.SelectedIndexChanged += fcbMalzemeGrup_SelectedIndexChanged_1;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = Color.SteelBlue;
            headerPanel1.Baslik = "Malzeme Alt Grup2 Tanımı";
            headerPanel1.Location = new Point(0, 0);
            headerPanel1.Margin = new Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new Padding(1);
            headerPanel1.Size = new Size(558, 25);
            headerPanel1.TabIndex = 15;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new Point(33, 207);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(500, 218);
            universalGrid1.TabIndex = 16;
            // 
            // customButtonNewRecord1
            // 
            customButtonNewRecord1.Location = new Point(479, 51);
            customButtonNewRecord1.Name = "customButtonNewRecord1";
            customButtonNewRecord1.Size = new Size(36, 36);
            customButtonNewRecord1.TabIndex = 18;
            customButtonNewRecord1.Click += roundedButton1_Click;
            // 
            // MalzemeAltGrup2TanimFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 437);
            Controls.Add(customButtonNewRecord1);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            Controls.Add(label6);
            Controls.Add(fcbMalzemeGrup);
            Controls.Add(label5);
            Controls.Add(fcbMalzemeAltGrup);
            Controls.Add(customButtonSave1);
            Controls.Add(label4);
            Controls.Add(fcbStokGrup);
            Controls.Add(label2);
            Controls.Add(ctbMalzemeAltGrup2Kod);
            Controls.Add(label1);
            Controls.Add(ctbMalzemeAltGrup2Ad);
            Controls.Add(label3);
            Controls.Add(ctbMalzemeAltGrup2Id);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MalzemeAltGrup2TanimFormu";
            Text = "MalzemeAltGrupTanimFormu";
            FormClosing += MalzemeAltGrup2TanimFormu_FormClosing;
            MouseClick += MalzemeAltGrupTanimFormu_MouseClick;
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
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
        private CustomControls.CustomTextBox ctbMalzemeAltGrup2Id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomTextBox ctbMalzemeAltGrup2Ad;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomTextBox ctbMalzemeAltGrup2Kod;
        private CustomControls.FilterableComboBox fcbMalzemeAltGrup;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.FilterableComboBox fcbStokGrup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem malzemeGrubunuSilToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem formuTemizleToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private CustomControls.FilterableComboBox fcbMalzemeGrup;
        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.CustomButtonNewRecord customButtonNewRecord1;
    }
}