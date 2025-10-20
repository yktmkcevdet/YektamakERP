using System.Drawing;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Genel
{
    partial class MalzemeGrupTanimFormu
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
            ctbMalzemeGrupId = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            label3 = new Label();
            label1 = new Label();
            ctbMalzemeGrupAd = new YektamakDesktop.CustomControls.CustomTextBox();
            label2 = new Label();
            ctbMalzemeGrupKod = new YektamakDesktop.CustomControls.CustomTextBox();
            fcbStokGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            label4 = new Label();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            contextMenuStrip1 = new ContextMenuStrip(components);
            malzemeGrubunuSilToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ctbMalzemeGrupId
            // 
            ctbMalzemeGrupId.BackColor = Color.White;
            ctbMalzemeGrupId.Enabled = false;
            ctbMalzemeGrupId.Font = new Font("Segoe UI", 8F);
            ctbMalzemeGrupId.ForeColor = Color.Black;
            ctbMalzemeGrupId.Location = new Point(153, 43);
            ctbMalzemeGrupId.Margin = new Padding(1);
            ctbMalzemeGrupId.Name = "ctbMalzemeGrupId";
            ctbMalzemeGrupId.OndalikBasamak = 0;
            ctbMalzemeGrupId.Padding = new Padding(7, 5, 7, 5);
            ctbMalzemeGrupId.Size = new Size(63, 25);
            ctbMalzemeGrupId.TabIndex = 1;
            ctbMalzemeGrupId.TextCustom = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label3.Location = new Point(33, 49);
            label3.Name = "label3";
            label3.Size = new Size(18, 13);
            label3.TabIndex = 2;
            label3.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label1.Location = new Point(33, 76);
            label1.Name = "label1";
            label1.Size = new Size(104, 13);
            label1.TabIndex = 5;
            label1.Text = "Malzeme Grup Adı";
            // 
            // ctbMalzemeGrupAd
            // 
            ctbMalzemeGrupAd.BackColor = Color.White;
            ctbMalzemeGrupAd.BorderColor = Color.Silver;
            ctbMalzemeGrupAd.BorderFocusColor = Color.HotPink;
            ctbMalzemeGrupAd.BorderSize = 1;
            ctbMalzemeGrupAd.Font = new Font("Segoe UI", 8F);
            ctbMalzemeGrupAd.ForeColor = Color.Black;
            ctbMalzemeGrupAd.Location = new Point(153, 70);
            ctbMalzemeGrupAd.Margin = new Padding(1);
            ctbMalzemeGrupAd.Multiline = false;
            ctbMalzemeGrupAd.Name = "ctbMalzemeGrupAd";
            ctbMalzemeGrupAd.Padding = new Padding(7, 5, 7, 5);
            ctbMalzemeGrupAd.PasswordChar = false;
            ctbMalzemeGrupAd.PlaceholderColor = Color.DarkGray;
            ctbMalzemeGrupAd.PlaceholderText = "";
            ctbMalzemeGrupAd.ReadOnly = false;
            ctbMalzemeGrupAd.SelectionStart = 0;
            ctbMalzemeGrupAd.Size = new Size(262, 25);
            ctbMalzemeGrupAd.TabIndex = 4;
            ctbMalzemeGrupAd.TextAlignment = HorizontalAlignment.Left;
            ctbMalzemeGrupAd.TextCustom = "";
            ctbMalzemeGrupAd.UnderlinedStyle = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label2.Location = new Point(33, 103);
            label2.Name = "label2";
            label2.Size = new Size(114, 13);
            label2.TabIndex = 7;
            label2.Text = "Malzeme Grup Kodu";
            // 
            // ctbMalzemeGrupKod
            // 
            ctbMalzemeGrupKod.BackColor = Color.White;
            ctbMalzemeGrupKod.BorderColor = Color.Silver;
            ctbMalzemeGrupKod.BorderFocusColor = Color.HotPink;
            ctbMalzemeGrupKod.BorderSize = 1;
            ctbMalzemeGrupKod.Font = new Font("Segoe UI", 8F);
            ctbMalzemeGrupKod.ForeColor = Color.Black;
            ctbMalzemeGrupKod.Location = new Point(153, 97);
            ctbMalzemeGrupKod.Margin = new Padding(1);
            ctbMalzemeGrupKod.Multiline = false;
            ctbMalzemeGrupKod.Name = "ctbMalzemeGrupKod";
            ctbMalzemeGrupKod.Padding = new Padding(7, 5, 7, 5);
            ctbMalzemeGrupKod.PasswordChar = false;
            ctbMalzemeGrupKod.PlaceholderColor = Color.DarkGray;
            ctbMalzemeGrupKod.PlaceholderText = "";
            ctbMalzemeGrupKod.ReadOnly = false;
            ctbMalzemeGrupKod.SelectionStart = 0;
            ctbMalzemeGrupKod.Size = new Size(134, 25);
            ctbMalzemeGrupKod.TabIndex = 6;
            ctbMalzemeGrupKod.TextAlignment = HorizontalAlignment.Left;
            ctbMalzemeGrupKod.TextCustom = "";
            ctbMalzemeGrupKod.UnderlinedStyle = false;
            // 
            // fcbStokGrup
            // 
            fcbStokGrup.BorderColor = Color.Silver;
            fcbStokGrup.BorderSize = 1;
            fcbStokGrup.DisplayMember = "ad";
            fcbStokGrup.Font = new Font("Segoe UI", 8F);
            fcbStokGrup.Location = new Point(153, 126);
            fcbStokGrup.Margin = new Padding(1);
            fcbStokGrup.Name = "fcbStokGrup";
            fcbStokGrup.Padding = new Padding(6, 4, 6, 4);
            fcbStokGrup.PlaceholderText = "Seçiniz...";
            fcbStokGrup.Size = new Size(223, 25);
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
            customButtonSave1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            customButtonSave1.BackColor = Color.Transparent;
            customButtonSave1.Location = new Point(376, 488);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new Size(106, 46);
            customButtonSave1.TabIndex = 10;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            roundedButton1.Location = new Point(33, 488);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(105, 40);
            roundedButton1.TabIndex = 11;
            roundedButton1.Text = "YENİ KAYIT";
            roundedButton1.TextColor = Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = Color.SteelBlue;
            headerPanel1.Baslik = "Malzeme Grup Tanımlama";
            headerPanel1.Location = new Point(-1, 0);
            headerPanel1.Margin = new Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new Padding(1);
            headerPanel1.Size = new Size(528, 25);
            headerPanel1.TabIndex = 12;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new Point(33, 156);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(449, 326);
            universalGrid1.TabIndex = 13;
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
            // MalzemeGrupTanimFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 540);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            Controls.Add(roundedButton1);
            Controls.Add(customButtonSave1);
            Controls.Add(label4);
            Controls.Add(fcbStokGrup);
            Controls.Add(label2);
            Controls.Add(ctbMalzemeGrupKod);
            Controls.Add(label1);
            Controls.Add(ctbMalzemeGrupAd);
            Controls.Add(label3);
            Controls.Add(ctbMalzemeGrupId);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MalzemeGrupTanimFormu";
            Text = "MalzemeGrupTanimFormu";
            FormClosing += MalzemeGrupTanimFormu_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
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
        private CustomControls.CustomTextBoxSayisal ctbMalzemeGrupId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomTextBox ctbMalzemeGrupAd;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomTextBox ctbMalzemeGrupKod;
        private CustomControls.FilterableComboBox fcbStokGrup;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem malzemeGrubunuSilToolStripMenuItem;
    }
}