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
            label3 = new Label();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            label1 = new Label();
            ctbStokGrupAd = new YektamakDesktop.CustomControls.CustomTextBox();
            label2 = new Label();
            ctbStokGrupKod = new YektamakDesktop.CustomControls.CustomTextBox();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            ctxMenu = new ContextMenuStrip(components);
            stokGrubunuSilToolStripMenuItem = new ToolStripMenuItem();
            customButtonNewRecord1 = new YektamakDesktop.CustomControls.CustomButtonNewRecord();
            ctxMenu.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = Color.SteelBlue;
            headerPanel1.Baslik = "Stok Grup Tanımlama";
            headerPanel1.Location = new Point(0, 0);
            headerPanel1.Margin = new Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new Padding(1);
            headerPanel1.Size = new Size(579, 25);
            headerPanel1.TabIndex = 0;
            // 
            // ctbStokGrupId
            // 
            ctbStokGrupId.BackColor = Color.White;
            ctbStokGrupId.Font = new Font("Segoe UI", 8F);
            ctbStokGrupId.ForeColor = Color.Black;
            ctbStokGrupId.Location = new Point(113, 47);
            ctbStokGrupId.Margin = new Padding(1);
            ctbStokGrupId.Name = "ctbStokGrupId";
            ctbStokGrupId.OndalikBasamak = 0;
            ctbStokGrupId.Padding = new Padding(3);
            ctbStokGrupId.Size = new Size(63, 25);
            ctbStokGrupId.TabIndex = 1;
            ctbStokGrupId.TextCustom = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label3.Location = new Point(17, 52);
            label3.Name = "label3";
            label3.Size = new Size(18, 13);
            label3.TabIndex = 2;
            label3.Text = "ID";
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new Point(12, 130);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(555, 204);
            universalGrid1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label1.Location = new Point(17, 79);
            label1.Name = "label1";
            label1.Size = new Size(80, 13);
            label1.TabIndex = 5;
            label1.Text = "Stok Grup Adı";
            // 
            // ctbStokGrupAd
            // 
            ctbStokGrupAd.BackColor = Color.White;
            ctbStokGrupAd.BorderColor = Color.Silver;
            ctbStokGrupAd.BorderFocusColor = Color.HotPink;
            ctbStokGrupAd.BorderSize = 1;
            ctbStokGrupAd.Font = new Font("Segoe UI", 8F);
            ctbStokGrupAd.ForeColor = Color.Black;
            ctbStokGrupAd.Location = new Point(113, 74);
            ctbStokGrupAd.Margin = new Padding(1);
            ctbStokGrupAd.Multiline = false;
            ctbStokGrupAd.Name = "ctbStokGrupAd";
            ctbStokGrupAd.Padding = new Padding(3);
            ctbStokGrupAd.PasswordChar = false;
            ctbStokGrupAd.PlaceholderColor = Color.DarkGray;
            ctbStokGrupAd.PlaceholderText = "";
            ctbStokGrupAd.ReadOnly = false;
            ctbStokGrupAd.SelectionStart = 0;
            ctbStokGrupAd.Size = new Size(262, 25);
            ctbStokGrupAd.TabIndex = 4;
            ctbStokGrupAd.TextAlignment = HorizontalAlignment.Left;
            ctbStokGrupAd.TextCustom = "";
            ctbStokGrupAd.UnderlinedStyle = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label2.Location = new Point(17, 106);
            label2.Name = "label2";
            label2.Size = new Size(90, 13);
            label2.TabIndex = 7;
            label2.Text = "Stok Grup Kodu";
            // 
            // ctbStokGrupKod
            // 
            ctbStokGrupKod.BackColor = Color.White;
            ctbStokGrupKod.BorderColor = Color.Silver;
            ctbStokGrupKod.BorderFocusColor = Color.HotPink;
            ctbStokGrupKod.BorderSize = 1;
            ctbStokGrupKod.Font = new Font("Segoe UI", 8F);
            ctbStokGrupKod.ForeColor = Color.Black;
            ctbStokGrupKod.Location = new Point(113, 101);
            ctbStokGrupKod.Margin = new Padding(1);
            ctbStokGrupKod.Multiline = false;
            ctbStokGrupKod.Name = "ctbStokGrupKod";
            ctbStokGrupKod.Padding = new Padding(3);
            ctbStokGrupKod.PasswordChar = false;
            ctbStokGrupKod.PlaceholderColor = Color.DarkGray;
            ctbStokGrupKod.PlaceholderText = "";
            ctbStokGrupKod.ReadOnly = false;
            ctbStokGrupKod.SelectionStart = 0;
            ctbStokGrupKod.Size = new Size(134, 25);
            ctbStokGrupKod.TabIndex = 6;
            ctbStokGrupKod.TextAlignment = HorizontalAlignment.Left;
            ctbStokGrupKod.TextCustom = "";
            ctbStokGrupKod.UnderlinedStyle = false;
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            customButtonSave1.BackColor = Color.Transparent;
            customButtonSave1.Location = new Point(493, 83);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new Size(36, 36);
            customButtonSave1.TabIndex = 8;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // ctxMenu
            // 
            ctxMenu.Items.AddRange(new ToolStripItem[] { stokGrubunuSilToolStripMenuItem });
            ctxMenu.Name = "ctxMenu";
            ctxMenu.Size = new Size(163, 26);
            // 
            // stokGrubunuSilToolStripMenuItem
            // 
            stokGrubunuSilToolStripMenuItem.Name = "stokGrubunuSilToolStripMenuItem";
            stokGrubunuSilToolStripMenuItem.Size = new Size(162, 22);
            stokGrubunuSilToolStripMenuItem.Text = "Stok Grubunu Sil";
            stokGrubunuSilToolStripMenuItem.Click += stokGrubunuSilToolStripMenuItem_Click;
            // 
            // customButtonNewRecord1
            // 
            customButtonNewRecord1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            customButtonNewRecord1.Location = new Point(493, 29);
            customButtonNewRecord1.Name = "customButtonNewRecord1";
            customButtonNewRecord1.Size = new Size(36, 36);
            customButtonNewRecord1.TabIndex = 10;
            customButtonNewRecord1.Click += roundedButton1_Click;
            // 
            // StokGrupTanimFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 346);
            Controls.Add(customButtonNewRecord1);
            Controls.Add(customButtonSave1);
            Controls.Add(label2);
            Controls.Add(ctbStokGrupKod);
            Controls.Add(label1);
            Controls.Add(ctbStokGrupAd);
            Controls.Add(universalGrid1);
            Controls.Add(label3);
            Controls.Add(ctbStokGrupId);
            Controls.Add(headerPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StokGrupTanimFormu";
            Text = "StokGrupTanimFormu";
            FormClosing += StokGrupTanimFormu_FormClosing;
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
        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBoxSayisal ctbStokGrupId;
        private System.Windows.Forms.Label label3;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomTextBox ctbStokGrupAd;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomTextBox ctbStokGrupKod;
        private CustomControls.CustomButtonSave customButtonSave1;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem stokGrubunuSilToolStripMenuItem;
        private CustomControls.CustomButtonNewRecord customButtonNewRecord1;
    }
}