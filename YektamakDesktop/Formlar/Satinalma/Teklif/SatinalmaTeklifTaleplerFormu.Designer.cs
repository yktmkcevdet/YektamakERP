namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTeklifTaleplerFormu
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
            teklifTalebiniSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            teklifTalebiniGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Teklif Talepleri";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(959, 25);
            headerPanel1.TabIndex = 0;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(0, 164);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(959, 509);
            universalGrid1.TabIndex = 1;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { teklifTalebiniSilToolStripMenuItem, teklifTalebiniGörüntüleToolStripMenuItem, toolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(201, 92);
            // 
            // teklifTalebiniSilToolStripMenuItem
            // 
            teklifTalebiniSilToolStripMenuItem.Name = "teklifTalebiniSilToolStripMenuItem";
            teklifTalebiniSilToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            teklifTalebiniSilToolStripMenuItem.Text = "Teklif Talebini Sil";
            teklifTalebiniSilToolStripMenuItem.Click += teklifTalebiniSilToolStripMenuItem_Click;
            // 
            // teklifTalebiniGörüntüleToolStripMenuItem
            // 
            teklifTalebiniGörüntüleToolStripMenuItem.Name = "teklifTalebiniGörüntüleToolStripMenuItem";
            teklifTalebiniGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            teklifTalebiniGörüntüleToolStripMenuItem.Text = "Teklif Talebini Görüntüle";
            teklifTalebiniGörüntüleToolStripMenuItem.Click += teklifTalebiniGörüntüleToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            toolStripMenuItem1.Text = "Teklifi Siparişe Dönüştür";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // SatinalmaTeklifTaleplerFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(959, 674);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTeklifTaleplerFormu";
            Text = "SatinalmaTeklifTaleplerFormu";
            FormClosing += SatinalmaTeklifTaleplerFormu_FormClosing;
            Load += SatinalmaTeklifTaleplerFormu_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem teklifTalebiniSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teklifTalebiniGörüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}