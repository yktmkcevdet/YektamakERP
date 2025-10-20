using System.Drawing;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Genel
{
    partial class StokGrupTanimFormu
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
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            ctbStokGrupId = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            label3 = new System.Windows.Forms.Label();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            label1 = new System.Windows.Forms.Label();
            ctbStokGrupAd = new YektamakDesktop.CustomControls.CustomTextBox();
            label2 = new System.Windows.Forms.Label();
            ctbStokGrupKod = new YektamakDesktop.CustomControls.CustomTextBox();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            ctxMenu = new System.Windows.Forms.ContextMenuStrip(components);
            stokGrubunuSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ctxMenu.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Stok Grup Tanımlama";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(579, 25);
            headerPanel1.TabIndex = 0;
            // 
            // ctbStokGrupId
            // 
            ctbStokGrupId.BackColor = System.Drawing.Color.White;
            ctbStokGrupId.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbStokGrupId.ForeColor = System.Drawing.Color.Black;
            ctbStokGrupId.Location = new System.Drawing.Point(113, 47);
            ctbStokGrupId.Margin = new System.Windows.Forms.Padding(1);
            ctbStokGrupId.Name = "ctbStokGrupId";
            ctbStokGrupId.OndalikBasamak = 0;
            ctbStokGrupId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbStokGrupId.Size = new System.Drawing.Size(63, 25);
            ctbStokGrupId.TabIndex = 1;
            ctbStokGrupId.TextCustom = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(17, 52);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(18, 13);
            label3.TabIndex = 2;
            label3.Text = "ID";
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(12, 130);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(555, 232);
            universalGrid1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(17, 79);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(80, 13);
            label1.TabIndex = 5;
            label1.Text = "Stok Grup Adı";
            // 
            // ctbStokGrupAd
            // 
            ctbStokGrupAd.BackColor = System.Drawing.Color.White;
            ctbStokGrupAd.BorderColor = System.Drawing.Color.Silver;
            ctbStokGrupAd.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbStokGrupAd.BorderSize = 1;
            ctbStokGrupAd.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbStokGrupAd.ForeColor = System.Drawing.Color.Black;
            ctbStokGrupAd.Location = new System.Drawing.Point(113, 74);
            ctbStokGrupAd.Margin = new System.Windows.Forms.Padding(1);
            ctbStokGrupAd.Multiline = false;
            ctbStokGrupAd.Name = "ctbStokGrupAd";
            ctbStokGrupAd.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbStokGrupAd.PasswordChar = false;
            ctbStokGrupAd.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbStokGrupAd.PlaceholderText = "";
            ctbStokGrupAd.ReadOnly = false;
            ctbStokGrupAd.SelectionStart = 0;
            ctbStokGrupAd.Size = new System.Drawing.Size(262, 25);
            ctbStokGrupAd.TabIndex = 4;
            ctbStokGrupAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbStokGrupAd.TextCustom = "";
            ctbStokGrupAd.UnderlinedStyle = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(17, 106);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(90, 13);
            label2.TabIndex = 7;
            label2.Text = "Stok Grup Kodu";
            // 
            // ctbStokGrupKod
            // 
            ctbStokGrupKod.BackColor = System.Drawing.Color.White;
            ctbStokGrupKod.BorderColor = System.Drawing.Color.Silver;
            ctbStokGrupKod.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbStokGrupKod.BorderSize = 1;
            ctbStokGrupKod.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbStokGrupKod.ForeColor = System.Drawing.Color.Black;
            ctbStokGrupKod.Location = new System.Drawing.Point(113, 101);
            ctbStokGrupKod.Margin = new System.Windows.Forms.Padding(1);
            ctbStokGrupKod.Multiline = false;
            ctbStokGrupKod.Name = "ctbStokGrupKod";
            ctbStokGrupKod.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbStokGrupKod.PasswordChar = false;
            ctbStokGrupKod.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbStokGrupKod.PlaceholderText = "";
            ctbStokGrupKod.ReadOnly = false;
            ctbStokGrupKod.SelectionStart = 0;
            ctbStokGrupKod.Size = new System.Drawing.Size(134, 25);
            ctbStokGrupKod.TabIndex = 6;
            ctbStokGrupKod.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbStokGrupKod.TextCustom = "";
            ctbStokGrupKod.UnderlinedStyle = false;
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(461, 368);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 8;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
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
            roundedButton1.Location = new System.Drawing.Point(12, 374);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(125, 40);
            roundedButton1.TabIndex = 9;
            roundedButton1.Text = "YENİ KAYIT";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // ctxMenu
            // 
            ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { stokGrubunuSilToolStripMenuItem });
            ctxMenu.Name = "ctxMenu";
            ctxMenu.Size = new System.Drawing.Size(163, 26);
            // 
            // stokGrubunuSilToolStripMenuItem
            // 
            stokGrubunuSilToolStripMenuItem.Name = "stokGrubunuSilToolStripMenuItem";
            stokGrubunuSilToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            stokGrubunuSilToolStripMenuItem.Text = "Stok Grubunu Sil";
            stokGrubunuSilToolStripMenuItem.Click += stokGrubunuSilToolStripMenuItem_Click;
            // 
            // StokGrupTanimFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(579, 421);
            Controls.Add(roundedButton1);
            Controls.Add(customButtonSave1);
            Controls.Add(label2);
            Controls.Add(ctbStokGrupKod);
            Controls.Add(label1);
            Controls.Add(ctbStokGrupAd);
            Controls.Add(universalGrid1);
            Controls.Add(label3);
            Controls.Add(ctbStokGrupId);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "StokGrupTanimFormu";
            Text = "StokGrupTanimFormu";
            FormClosed += StokGrupTanimFormu_FormClosing;
            ctxMenu.ResumeLayout(false);
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
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBoxSayisal ctbStokGrupId;
        private System.Windows.Forms.Label label3;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomTextBox ctbStokGrupAd;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomTextBox ctbStokGrupKod;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.RoundedButton roundedButton1;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem stokGrubunuSilToolStripMenuItem;
    }
}