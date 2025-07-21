namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTalepOnayFormu
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
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            talebiOnaylaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            talebiReddetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Onaylanacak Talepler";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1094, 32);
            headerPanel1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { talebiOnaylaToolStripMenuItem, talebiReddetToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(145, 48);
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
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.kullanici = null;
            universalGrid1.Location = new System.Drawing.Point(0, 125);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1094, 532);
            universalGrid1.TabIndex = 1;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown;
            // 
            // SatinalmaTalepOnayFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(1094, 657);
            ControlBox = false;
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            ForeColor = System.Drawing.SystemColors.ActiveCaption;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepOnayFormu";
            Text = "Onaylanacak Talepler";
            FormClosed += SatinalmaTalepOnayFormu_FormClosed;
            Load += SatinalmaTalepOnayFormu_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem talebiOnaylaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem talebiReddetToolStripMenuItem;
        private CustomControls.UniversalGrid universalGrid1;
    }
}