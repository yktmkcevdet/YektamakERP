using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTalepler
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
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            talebiOnaylaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            talebiReddetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            görüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            headerPanel1 = new HeaderPanel();
            universalGrid1 = new UniversalGrid();
            rbOnaylanmisTalepler = new System.Windows.Forms.RadioButton();
            rdOnayBekleyenTalepler = new System.Windows.Forms.RadioButton();
            rbReddedilenTalepler = new System.Windows.Forms.RadioButton();
            rbTumTalepler = new System.Windows.Forms.RadioButton();
            panel1 = new System.Windows.Forms.Panel();
            rbTumKullanic = new System.Windows.Forms.RadioButton();
            rbOnaylayacagimTalepler = new System.Windows.Forms.RadioButton();
            rbActigimTalepler = new System.Windows.Forms.RadioButton();
            panel2 = new System.Windows.Forms.Panel();
            roundedButton1 = new RoundedButton();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { talebiOnaylaToolStripMenuItem, talebiReddetToolStripMenuItem, görüntüleToolStripMenuItem, silToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(145, 92);
            // 
            // talebiOnaylaToolStripMenuItem
            // 
            talebiOnaylaToolStripMenuItem.Name = "talebiOnaylaToolStripMenuItem";
            talebiOnaylaToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            talebiOnaylaToolStripMenuItem.Text = "Talebi Onayla";
            talebiOnaylaToolStripMenuItem.Click += talebiOnaylaToolStripMenuItem_Click;
            // 
            // talebiReddetToolStripMenuItem
            // 
            talebiReddetToolStripMenuItem.Name = "talebiReddetToolStripMenuItem";
            talebiReddetToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            talebiReddetToolStripMenuItem.Text = "Talebi Reddet";
            talebiReddetToolStripMenuItem.Click += talebiReddetToolStripMenuItem_Click;
            // 
            // görüntüleToolStripMenuItem
            // 
            görüntüleToolStripMenuItem.Name = "görüntüleToolStripMenuItem";
            görüntüleToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            görüntüleToolStripMenuItem.Text = "Görüntüle";
            görüntüleToolStripMenuItem.Click += görüntüleToolStripMenuItem_Click;
            // 
            // silToolStripMenuItem
            // 
            silToolStripMenuItem.Name = "silToolStripMenuItem";
            silToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            silToolStripMenuItem.Text = "Sil";
            silToolStripMenuItem.Click += silToolStripMenuItem_Click;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Satınalma Talepleri";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1138, 25);
            headerPanel1.TabIndex = 12;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(0, 164);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1138, 424);
            universalGrid1.TabIndex = 13;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown1;
            // 
            // rbOnaylanmisTalepler
            // 
            rbOnaylanmisTalepler.AutoSize = true;
            rbOnaylanmisTalepler.Location = new System.Drawing.Point(46, 7);
            rbOnaylanmisTalepler.Name = "rbOnaylanmisTalepler";
            rbOnaylanmisTalepler.Size = new System.Drawing.Size(131, 19);
            rbOnaylanmisTalepler.TabIndex = 14;
            rbOnaylanmisTalepler.Text = "Onaylanmış Talepler";
            rbOnaylanmisTalepler.UseVisualStyleBackColor = true;
            rbOnaylanmisTalepler.CheckedChanged += rbOnaylanmisTalepler_CheckedChanged;
            // 
            // rdOnayBekleyenTalepler
            // 
            rdOnayBekleyenTalepler.AutoSize = true;
            rdOnayBekleyenTalepler.Location = new System.Drawing.Point(46, 32);
            rdOnayBekleyenTalepler.Name = "rdOnayBekleyenTalepler";
            rdOnayBekleyenTalepler.Size = new System.Drawing.Size(146, 19);
            rdOnayBekleyenTalepler.TabIndex = 15;
            rdOnayBekleyenTalepler.Text = "Onay Bekleyen Talepler";
            rdOnayBekleyenTalepler.UseVisualStyleBackColor = true;
            rdOnayBekleyenTalepler.CheckedChanged += rdOnayBekleyenTalepler_CheckedChanged;
            // 
            // rbReddedilenTalepler
            // 
            rbReddedilenTalepler.AutoSize = true;
            rbReddedilenTalepler.Location = new System.Drawing.Point(46, 57);
            rbReddedilenTalepler.Name = "rbReddedilenTalepler";
            rbReddedilenTalepler.Size = new System.Drawing.Size(127, 19);
            rbReddedilenTalepler.TabIndex = 16;
            rbReddedilenTalepler.Text = "Reddedilen Talepler";
            rbReddedilenTalepler.UseVisualStyleBackColor = true;
            rbReddedilenTalepler.CheckedChanged += rbReddedilenTalepler_CheckedChanged;
            // 
            // rbTumTalepler
            // 
            rbTumTalepler.AutoSize = true;
            rbTumTalepler.Checked = true;
            rbTumTalepler.Location = new System.Drawing.Point(46, 82);
            rbTumTalepler.Name = "rbTumTalepler";
            rbTumTalepler.Size = new System.Drawing.Size(56, 19);
            rbTumTalepler.TabIndex = 18;
            rbTumTalepler.TabStop = true;
            rbTumTalepler.Text = "Tümü";
            rbTumTalepler.UseVisualStyleBackColor = true;
            rbTumTalepler.CheckedChanged += rbTumTalepler_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(rbTumKullanic);
            panel1.Controls.Add(rbOnaylayacagimTalepler);
            panel1.Controls.Add(rbActigimTalepler);
            panel1.Location = new System.Drawing.Point(47, 47);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(256, 116);
            panel1.TabIndex = 19;
            // 
            // rbTumKullanic
            // 
            rbTumKullanic.AutoSize = true;
            rbTumKullanic.Checked = true;
            rbTumKullanic.Location = new System.Drawing.Point(15, 59);
            rbTumKullanic.Name = "rbTumKullanic";
            rbTumKullanic.Size = new System.Drawing.Size(56, 19);
            rbTumKullanic.TabIndex = 2;
            rbTumKullanic.TabStop = true;
            rbTumKullanic.Text = "Tümü";
            rbTumKullanic.UseVisualStyleBackColor = true;
            rbTumKullanic.CheckedChanged += rbTumKullanic_CheckedChanged;
            // 
            // rbOnaylayacagimTalepler
            // 
            rbOnaylayacagimTalepler.AutoSize = true;
            rbOnaylayacagimTalepler.Location = new System.Drawing.Point(15, 34);
            rbOnaylayacagimTalepler.Name = "rbOnaylayacagimTalepler";
            rbOnaylayacagimTalepler.Size = new System.Drawing.Size(150, 19);
            rbOnaylayacagimTalepler.TabIndex = 1;
            rbOnaylayacagimTalepler.Text = "Onaylayacağım Talepler";
            rbOnaylayacagimTalepler.UseVisualStyleBackColor = true;
            rbOnaylayacagimTalepler.CheckedChanged += rbOnaylayacagimTalepler_CheckedChanged;
            // 
            // rbActigimTalepler
            // 
            rbActigimTalepler.AutoSize = true;
            rbActigimTalepler.Location = new System.Drawing.Point(15, 9);
            rbActigimTalepler.Name = "rbActigimTalepler";
            rbActigimTalepler.Size = new System.Drawing.Size(110, 19);
            rbActigimTalepler.TabIndex = 0;
            rbActigimTalepler.Text = "Açtığım Talepler";
            rbActigimTalepler.UseVisualStyleBackColor = true;
            rbActigimTalepler.CheckedChanged += rbActigimTalepler_CheckedChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(rbTumTalepler);
            panel2.Controls.Add(rbOnaylanmisTalepler);
            panel2.Controls.Add(rdOnayBekleyenTalepler);
            panel2.Controls.Add(rbReddedilenTalepler);
            panel2.Location = new System.Drawing.Point(332, 47);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(255, 116);
            panel2.TabIndex = 20;
            // 
            // roundedButton1
            // 
            roundedButton1.BackgroundColor = System.Drawing.Color.White;
            roundedButton1.BorderColor = System.Drawing.Color.Black;
            roundedButton1.BorderSize = 0;
            roundedButton1.CornerRadius = 10;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.GradientColor1 = System.Drawing.Color.White;
            roundedButton1.GradientColor2 = System.Drawing.Color.White;
            roundedButton1.HoverColor1 = System.Drawing.Color.White;
            roundedButton1.HoverColor2 = System.Drawing.Color.White;
            roundedButton1.Icon = Properties.Resources.data_update_icon;
            roundedButton1.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton1.Location = new System.Drawing.Point(1017, 63);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(41, 35);
            roundedButton1.TabIndex = 21;
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // SatinalmaTalepler
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1138, 600);
            Controls.Add(roundedButton1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepler";
            Text = "Satınalma Talepleri";
            FormClosing += SatinalmaTalepler_FormClosing;
            Load += SatinalmaTalepler_Load;
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem talebiOnaylaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem talebiReddetToolStripMenuItem;
        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.ToolStripMenuItem görüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbOnaylanmisTalepler;
        private System.Windows.Forms.RadioButton rdOnayBekleyenTalepler;
        private System.Windows.Forms.RadioButton rbReddedilenTalepler;
        private System.Windows.Forms.RadioButton rbTumTalepler;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbTumKullanic;
        private System.Windows.Forms.RadioButton rbOnaylayacagimTalepler;
        private System.Windows.Forms.RadioButton rbActigimTalepler;
        private System.Windows.Forms.Panel panel2;
        private RoundedButton roundedButton1;
    }
}