namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTalepSatirDetayForm
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
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            stokKartıGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pDFGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Satınalma Talep Parça Listesi Detay";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(739, 25);
            headerPanel1.TabIndex = 1;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(2, 36);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(736, 392);
            universalGrid1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { stokKartıGörüntüleToolStripMenuItem, pDFGösterToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // stokKartıGörüntüleToolStripMenuItem
            // 
            stokKartıGörüntüleToolStripMenuItem.Name = "stokKartıGörüntüleToolStripMenuItem";
            stokKartıGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            stokKartıGörüntüleToolStripMenuItem.Text = "Stok Kartı Görüntüle";
            stokKartıGörüntüleToolStripMenuItem.Click += stokKartıGörüntüleToolStripMenuItem_Click;
            // 
            // pDFGösterToolStripMenuItem
            // 
            pDFGösterToolStripMenuItem.Name = "pDFGösterToolStripMenuItem";
            pDFGösterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            pDFGösterToolStripMenuItem.Text = "PDF Göster";
            pDFGösterToolStripMenuItem.Click += pDFGösterToolStripMenuItem_Click;
            // 
            // SatinalmaTalepSatirDetayForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(739, 432);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepSatirDetayForm";
            Text = "Parça Listesi";
            FormClosing += SatinalmaTalepSatirDetayForm_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stokKartıGörüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFGösterToolStripMenuItem;
    }
}