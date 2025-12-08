using System.Drawing;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Genel
{
    partial class MalzemeAltGrupTanimFormu
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
            ctbMalzemeAltGrupId = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            label3 = new Label();
            label1 = new Label();
            ctbMalzemeAltGrupAd = new YektamakDesktop.CustomControls.CustomTextBox();
            label2 = new Label();
            ctbMalzemeAltGrupKod = new YektamakDesktop.CustomControls.CustomTextBox();
            fcbStokGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            label4 = new Label();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            label5 = new Label();
            fcbMalzemeGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            malzemeGrubunuSilToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            formuTemizleToolStripMenuItem = new ToolStripMenuItem();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            customButtonNewRecord1 = new YektamakDesktop.CustomControls.CustomButtonNewRecord();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // ctbMalzemeAltGrupId
            // 
            ctbMalzemeAltGrupId.BackColor = Color.White;
            ctbMalzemeAltGrupId.Enabled = false;
            ctbMalzemeAltGrupId.Font = new Font("Segoe UI", 8F);
            ctbMalzemeAltGrupId.ForeColor = Color.Black;
            ctbMalzemeAltGrupId.Location = new Point(153, 43);
            ctbMalzemeAltGrupId.Margin = new Padding(1);
            ctbMalzemeAltGrupId.Name = "ctbMalzemeAltGrupId";
            ctbMalzemeAltGrupId.OndalikBasamak = 0;
            ctbMalzemeAltGrupId.Padding = new Padding(3);
            ctbMalzemeAltGrupId.Size = new Size(63, 25);
            ctbMalzemeAltGrupId.TabIndex = 1;
            ctbMalzemeAltGrupId.TextCustom = "0";
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
            label1.Size = new Size(104, 13);
            label1.TabIndex = 5;
            label1.Text = "Malzeme Grup Adı";
            // 
            // ctbMalzemeAltGrupAd
            // 
            ctbMalzemeAltGrupAd.BackColor = Color.White;
            ctbMalzemeAltGrupAd.BorderColor = Color.Silver;
            ctbMalzemeAltGrupAd.BorderFocusColor = Color.HotPink;
            ctbMalzemeAltGrupAd.BorderSize = 1;
            ctbMalzemeAltGrupAd.Font = new Font("Segoe UI", 8F);
            ctbMalzemeAltGrupAd.ForeColor = Color.Black;
            ctbMalzemeAltGrupAd.Location = new Point(153, 70);
            ctbMalzemeAltGrupAd.Margin = new Padding(1);
            ctbMalzemeAltGrupAd.Multiline = false;
            ctbMalzemeAltGrupAd.Name = "ctbMalzemeAltGrupAd";
            ctbMalzemeAltGrupAd.Padding = new Padding(3);
            ctbMalzemeAltGrupAd.PasswordChar = false;
            ctbMalzemeAltGrupAd.PlaceholderColor = Color.DarkGray;
            ctbMalzemeAltGrupAd.PlaceholderText = "";
            ctbMalzemeAltGrupAd.ReadOnly = false;
            ctbMalzemeAltGrupAd.SelectionStart = 0;
            ctbMalzemeAltGrupAd.Size = new Size(262, 25);
            ctbMalzemeAltGrupAd.TabIndex = 4;
            ctbMalzemeAltGrupAd.TextAlignment = HorizontalAlignment.Left;
            ctbMalzemeAltGrupAd.TextCustom = "";
            ctbMalzemeAltGrupAd.UnderlinedStyle = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label2.Location = new Point(33, 102);
            label2.Name = "label2";
            label2.Size = new Size(114, 13);
            label2.TabIndex = 7;
            label2.Text = "Malzeme Grup Kodu";
            // 
            // ctbMalzemeAltGrupKod
            // 
            ctbMalzemeAltGrupKod.BackColor = Color.White;
            ctbMalzemeAltGrupKod.BorderColor = Color.Silver;
            ctbMalzemeAltGrupKod.BorderFocusColor = Color.HotPink;
            ctbMalzemeAltGrupKod.BorderSize = 1;
            ctbMalzemeAltGrupKod.Font = new Font("Segoe UI", 8F);
            ctbMalzemeAltGrupKod.ForeColor = Color.Black;
            ctbMalzemeAltGrupKod.Location = new Point(153, 97);
            ctbMalzemeAltGrupKod.Margin = new Padding(1);
            ctbMalzemeAltGrupKod.Multiline = false;
            ctbMalzemeAltGrupKod.Name = "ctbMalzemeAltGrupKod";
            ctbMalzemeAltGrupKod.Padding = new Padding(3);
            ctbMalzemeAltGrupKod.PasswordChar = false;
            ctbMalzemeAltGrupKod.PlaceholderColor = Color.DarkGray;
            ctbMalzemeAltGrupKod.PlaceholderText = "";
            ctbMalzemeAltGrupKod.ReadOnly = false;
            ctbMalzemeAltGrupKod.SelectionStart = 0;
            ctbMalzemeAltGrupKod.Size = new Size(134, 25);
            ctbMalzemeAltGrupKod.TabIndex = 6;
            ctbMalzemeAltGrupKod.TextAlignment = HorizontalAlignment.Left;
            ctbMalzemeAltGrupKod.TextCustom = "";
            ctbMalzemeAltGrupKod.UnderlinedStyle = false;
            // 
            // fcbStokGrup
            // 
            fcbStokGrup.BorderColor = Color.Silver;
            fcbStokGrup.BorderRadius = 8;
            fcbStokGrup.BorderSize = 1;
            fcbStokGrup.DisplayMember = "ad";
            fcbStokGrup.Font = new Font("Segoe UI", 8F);
            fcbStokGrup.Location = new Point(153, 124);
            fcbStokGrup.Margin = new Padding(1);
            fcbStokGrup.Name = "fcbStokGrup";
            fcbStokGrup.Padding = new Padding(6, 4, 6, 4);
            fcbStokGrup.PlaceholderText = "Seçiniz...";
            fcbStokGrup.ReadOnly = false;
            fcbStokGrup.Size = new Size(134, 25);
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
            customButtonSave1.Location = new Point(501, 124);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new Size(36, 36);
            customButtonSave1.TabIndex = 10;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label5.Location = new Point(33, 156);
            label5.Name = "label5";
            label5.Size = new Size(90, 13);
            label5.TabIndex = 12;
            label5.Text = "Malzeme Grubu";
            // 
            // fcbMalzemeGrup
            // 
            fcbMalzemeGrup.BorderColor = Color.Silver;
            fcbMalzemeGrup.BorderRadius = 8;
            fcbMalzemeGrup.BorderSize = 1;
            fcbMalzemeGrup.DisplayMember = "ad";
            fcbMalzemeGrup.Font = new Font("Segoe UI", 8F);
            fcbMalzemeGrup.Location = new Point(153, 151);
            fcbMalzemeGrup.Margin = new Padding(1);
            fcbMalzemeGrup.Name = "fcbMalzemeGrup";
            fcbMalzemeGrup.Padding = new Padding(6, 4, 6, 4);
            fcbMalzemeGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeGrup.ReadOnly = false;
            fcbMalzemeGrup.Size = new Size(134, 25);
            fcbMalzemeGrup.TabIndex = 11;
            fcbMalzemeGrup.ValueMember = "Id";
            fcbMalzemeGrup.SelectedIndexChanged += fcbMalzemeGrup_SelectedIndexChanged;
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
            malzemeGrubunuSilToolStripMenuItem.Click += malzemeGrubunuSilToolStripMenuItem_Click;
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
            // headerPanel1
            // 
            headerPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = Color.SteelBlue;
            headerPanel1.Baslik = "Malzeme Alt Grup Tanımlama";
            headerPanel1.Location = new Point(-1, 0);
            headerPanel1.Margin = new Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new Padding(1);
            headerPanel1.Size = new Size(580, 25);
            headerPanel1.TabIndex = 13;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new Point(33, 185);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(533, 215);
            universalGrid1.TabIndex = 15;
            // 
            // customButtonNewRecord1
            // 
            customButtonNewRecord1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            customButtonNewRecord1.Location = new Point(501, 43);
            customButtonNewRecord1.Name = "customButtonNewRecord1";
            customButtonNewRecord1.Size = new Size(36, 36);
            customButtonNewRecord1.TabIndex = 16;
            customButtonNewRecord1.Click += customButtonNewRecord1_Click;
            // 
            // MalzemeAltGrupTanimFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 412);
            Controls.Add(customButtonNewRecord1);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            Controls.Add(label5);
            Controls.Add(fcbMalzemeGrup);
            Controls.Add(customButtonSave1);
            Controls.Add(label4);
            Controls.Add(fcbStokGrup);
            Controls.Add(label2);
            Controls.Add(ctbMalzemeAltGrupKod);
            Controls.Add(label1);
            Controls.Add(ctbMalzemeAltGrupAd);
            Controls.Add(label3);
            Controls.Add(ctbMalzemeAltGrupId);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MalzemeAltGrupTanimFormu";
            Text = "MalzemeAltGrupTanimFormu";
            FormClosing += MalzemeAltGrupTanimFormu_FormClosing;
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
        private CustomControls.CustomTextBoxSayisal ctbMalzemeAltGrupId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomTextBox ctbMalzemeAltGrupAd;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomTextBox ctbMalzemeAltGrupKod;
        private CustomControls.FilterableComboBox fcbMalzemeGrup;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.FilterableComboBox fcbStokGrup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem malzemeGrubunuSilToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem formuTemizleToolStripMenuItem;
        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.CustomButtonNewRecord customButtonNewRecord1;
    }
}