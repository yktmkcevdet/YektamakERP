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
            headerPanel1 = new HeaderPanel();
            universalGrid1 = new UniversalGrid();
            silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { talebiOnaylaToolStripMenuItem, talebiReddetToolStripMenuItem, görüntüleToolStripMenuItem, silToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // talebiOnaylaToolStripMenuItem
            // 
            talebiOnaylaToolStripMenuItem.Name = "talebiOnaylaToolStripMenuItem";
            talebiOnaylaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            talebiOnaylaToolStripMenuItem.Text = "Talebi Onayla";
            talebiOnaylaToolStripMenuItem.Click += talebiOnaylaToolStripMenuItem_Click;
            // 
            // talebiReddetToolStripMenuItem
            // 
            talebiReddetToolStripMenuItem.Name = "talebiReddetToolStripMenuItem";
            talebiReddetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            talebiReddetToolStripMenuItem.Text = "Talebi Reddet";
            // 
            // görüntüleToolStripMenuItem
            // 
            görüntüleToolStripMenuItem.Name = "görüntüleToolStripMenuItem";
            görüntüleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            görüntüleToolStripMenuItem.Text = "Görüntüle";
            görüntüleToolStripMenuItem.Click += görüntüleToolStripMenuItem_Click;
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
            headerPanel1.Size = new System.Drawing.Size(1138, 32);
            headerPanel1.TabIndex = 12;
            // 
            // universalGrid1
            // 
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(0, 164);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1138, 424);
            universalGrid1.TabIndex = 13;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown1;
            // 
            // silToolStripMenuItem
            // 
            silToolStripMenuItem.Name = "silToolStripMenuItem";
            silToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            silToolStripMenuItem.Text = "Sil";
            silToolStripMenuItem.Click += silToolStripMenuItem_Click;
            // 
            // SatinalmaTalepler
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1138, 600);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepler";
            Text = "Satınalma Talepleri";
            FormClosing += SatinalmaTalepler_FormClosing;
            Load += SatinalmaTalepler_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem talebiOnaylaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem talebiReddetToolStripMenuItem;
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.ToolStripMenuItem görüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
    }
}