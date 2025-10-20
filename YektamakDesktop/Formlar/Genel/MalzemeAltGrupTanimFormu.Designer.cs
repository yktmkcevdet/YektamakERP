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
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ctbMalzemeAltGrupAd = new YektamakDesktop.CustomControls.CustomTextBox();
            label2 = new System.Windows.Forms.Label();
            ctbMalzemeAltGrupKod = new YektamakDesktop.CustomControls.CustomTextBox();
            fcbStokGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            label4 = new System.Windows.Forms.Label();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            label5 = new System.Windows.Forms.Label();
            fcbMalzemeGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            malzemeGrubunuSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            formuTemizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // ctbMalzemeAltGrupId
            // 
            ctbMalzemeAltGrupId.BackColor = System.Drawing.Color.White;
            ctbMalzemeAltGrupId.Enabled = false;
            ctbMalzemeAltGrupId.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbMalzemeAltGrupId.ForeColor = System.Drawing.Color.Black;
            ctbMalzemeAltGrupId.Location = new System.Drawing.Point(153, 43);
            ctbMalzemeAltGrupId.Margin = new System.Windows.Forms.Padding(1);
            ctbMalzemeAltGrupId.Name = "ctbMalzemeAltGrupId";
            ctbMalzemeAltGrupId.OndalikBasamak = 0;
            ctbMalzemeAltGrupId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbMalzemeAltGrupId.Size = new System.Drawing.Size(63, 25);
            ctbMalzemeAltGrupId.TabIndex = 1;
            ctbMalzemeAltGrupId.TextCustom = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(33, 48);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(18, 13);
            label3.TabIndex = 2;
            label3.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(33, 75);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 13);
            label1.TabIndex = 5;
            label1.Text = "Malzeme Grup Adı";
            // 
            // ctbMalzemeAltGrupAd
            // 
            ctbMalzemeAltGrupAd.BackColor = System.Drawing.Color.White;
            ctbMalzemeAltGrupAd.BorderColor = System.Drawing.Color.Silver;
            ctbMalzemeAltGrupAd.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbMalzemeAltGrupAd.BorderSize = 1;
            ctbMalzemeAltGrupAd.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbMalzemeAltGrupAd.ForeColor = System.Drawing.Color.Black;
            ctbMalzemeAltGrupAd.Location = new System.Drawing.Point(153, 70);
            ctbMalzemeAltGrupAd.Margin = new System.Windows.Forms.Padding(1);
            ctbMalzemeAltGrupAd.Multiline = false;
            ctbMalzemeAltGrupAd.Name = "ctbMalzemeAltGrupAd";
            ctbMalzemeAltGrupAd.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbMalzemeAltGrupAd.PasswordChar = false;
            ctbMalzemeAltGrupAd.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbMalzemeAltGrupAd.PlaceholderText = "";
            ctbMalzemeAltGrupAd.ReadOnly = false;
            ctbMalzemeAltGrupAd.SelectionStart = 0;
            ctbMalzemeAltGrupAd.Size = new System.Drawing.Size(262, 25);
            ctbMalzemeAltGrupAd.TabIndex = 4;
            ctbMalzemeAltGrupAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbMalzemeAltGrupAd.TextCustom = "";
            ctbMalzemeAltGrupAd.UnderlinedStyle = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(33, 102);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(114, 13);
            label2.TabIndex = 7;
            label2.Text = "Malzeme Grup Kodu";
            // 
            // ctbMalzemeAltGrupKod
            // 
            ctbMalzemeAltGrupKod.BackColor = System.Drawing.Color.White;
            ctbMalzemeAltGrupKod.BorderColor = System.Drawing.Color.Silver;
            ctbMalzemeAltGrupKod.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbMalzemeAltGrupKod.BorderSize = 1;
            ctbMalzemeAltGrupKod.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbMalzemeAltGrupKod.ForeColor = System.Drawing.Color.Black;
            ctbMalzemeAltGrupKod.Location = new System.Drawing.Point(153, 97);
            ctbMalzemeAltGrupKod.Margin = new System.Windows.Forms.Padding(1);
            ctbMalzemeAltGrupKod.Multiline = false;
            ctbMalzemeAltGrupKod.Name = "ctbMalzemeAltGrupKod";
            ctbMalzemeAltGrupKod.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbMalzemeAltGrupKod.PasswordChar = false;
            ctbMalzemeAltGrupKod.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbMalzemeAltGrupKod.PlaceholderText = "";
            ctbMalzemeAltGrupKod.ReadOnly = false;
            ctbMalzemeAltGrupKod.SelectionStart = 0;
            ctbMalzemeAltGrupKod.Size = new System.Drawing.Size(134, 25);
            ctbMalzemeAltGrupKod.TabIndex = 6;
            ctbMalzemeAltGrupKod.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbMalzemeAltGrupKod.TextCustom = "";
            ctbMalzemeAltGrupKod.UnderlinedStyle = false;
            // 
            // fcbStokGrup
            // 
            fcbStokGrup.BorderColor = System.Drawing.Color.Silver;
            fcbStokGrup.BorderSize = 1;
            fcbStokGrup.DisplayMember = "ad";
            fcbStokGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbStokGrup.Location = new System.Drawing.Point(153, 124);
            fcbStokGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbStokGrup.Name = "fcbStokGrup";
            fcbStokGrup.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            fcbStokGrup.PlaceholderText = "Seçiniz...";
            fcbStokGrup.Size = new System.Drawing.Size(225, 25);
            fcbStokGrup.TabIndex = 8;
            fcbStokGrup.ValueMember = "Id";
            fcbStokGrup.SelectedIndexChanged += fcbStokGrup_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(33, 129);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 13);
            label4.TabIndex = 9;
            label4.Text = "Stok Grubu";
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(460, 527);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 10;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(33, 156);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(90, 13);
            label5.TabIndex = 12;
            label5.Text = "Malzeme Grubu";
            // 
            // fcbMalzemeGrup
            // 
            fcbMalzemeGrup.BorderColor = System.Drawing.Color.Silver;
            fcbMalzemeGrup.BorderSize = 1;
            fcbMalzemeGrup.DisplayMember = "ad";
            fcbMalzemeGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMalzemeGrup.Location = new System.Drawing.Point(153, 151);
            fcbMalzemeGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbMalzemeGrup.Name = "fcbMalzemeGrup";
            fcbMalzemeGrup.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            fcbMalzemeGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeGrup.Size = new System.Drawing.Size(225, 25);
            fcbMalzemeGrup.TabIndex = 11;
            fcbMalzemeGrup.ValueMember = "Id";
            fcbMalzemeGrup.SelectedIndexChanged += fcbMalzemeGrup_SelectedIndexChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { malzemeGrubunuSilToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(188, 26);
            // 
            // malzemeGrubunuSilToolStripMenuItem
            // 
            malzemeGrubunuSilToolStripMenuItem.Name = "malzemeGrubunuSilToolStripMenuItem";
            malzemeGrubunuSilToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            malzemeGrubunuSilToolStripMenuItem.Text = "Malzeme Grubunu Sil";
            malzemeGrubunuSilToolStripMenuItem.Click += malzemeGrubunuSilToolStripMenuItem_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { formuTemizleToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new System.Drawing.Size(152, 26);
            // 
            // formuTemizleToolStripMenuItem
            // 
            formuTemizleToolStripMenuItem.Name = "formuTemizleToolStripMenuItem";
            formuTemizleToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            formuTemizleToolStripMenuItem.Text = "Formu Temizle";
            formuTemizleToolStripMenuItem.Click += formuTemizleToolStripMenuItem_Click;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Malzeme Alt Grup Tanımlama";
            headerPanel1.Location = new System.Drawing.Point(-1, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(580, 25);
            headerPanel1.TabIndex = 13;
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Black;
            roundedButton1.BorderSize = 0;
            roundedButton1.CornerRadius = 10;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedButton1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedButton1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedButton1.HoverColor2 = System.Drawing.Color.Navy;
            roundedButton1.Icon = null;
            roundedButton1.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton1.Location = new System.Drawing.Point(33, 527);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(117, 40);
            roundedButton1.TabIndex = 14;
            roundedButton1.Text = "YENİ KAYIT";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(33, 185);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(533, 336);
            universalGrid1.TabIndex = 15;
            // 
            // MalzemeAltGrupTanimFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(578, 608);
            Controls.Add(universalGrid1);
            Controls.Add(roundedButton1);
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
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.UniversalGrid universalGrid1;
    }
}