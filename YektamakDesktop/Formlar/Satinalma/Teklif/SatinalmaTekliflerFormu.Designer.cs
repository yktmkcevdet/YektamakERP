namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTekliflerFormu
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
            teklifiSiparişeDönüştürToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clbPorjeKod = new YektamakDesktop.CustomControls.CustomComboListBox();
            clbStokGrup = new YektamakDesktop.CustomControls.CustomComboListBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            clbMalzemeGrup = new YektamakDesktop.CustomControls.CustomComboListBox();
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
            headerPanel1.Size = new System.Drawing.Size(959, 32);
            headerPanel1.TabIndex = 0;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(0, 200);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(959, 473);
            universalGrid1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { teklifiSiparişeDönüştürToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(200, 26);
            // 
            // teklifiSiparişeDönüştürToolStripMenuItem
            // 
            teklifiSiparişeDönüştürToolStripMenuItem.Name = "teklifiSiparişeDönüştürToolStripMenuItem";
            teklifiSiparişeDönüştürToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            teklifiSiparişeDönüştürToolStripMenuItem.Text = "Teklifi Siparişe Dönüştür";
            // 
            // clbPorjeKod
            // 
            clbPorjeKod.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbPorjeKod.ListBoxVisualSize = 5;
            clbPorjeKod.Location = new System.Drawing.Point(145, 44);
            clbPorjeKod.Margin = new System.Windows.Forms.Padding(1);
            clbPorjeKod.Name = "clbPorjeKod";
            clbPorjeKod.Padding = new System.Windows.Forms.Padding(1);
            clbPorjeKod.selectedDataRowId = null;
            clbPorjeKod.selectedDataRowValue = null;
            clbPorjeKod.Size = new System.Drawing.Size(243, 38);
            clbPorjeKod.TabIndex = 3;
            // 
            // clbStokGrup
            // 
            clbStokGrup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbStokGrup.ListBoxVisualSize = 5;
            clbStokGrup.Location = new System.Drawing.Point(145, 84);
            clbStokGrup.Margin = new System.Windows.Forms.Padding(1);
            clbStokGrup.Name = "clbStokGrup";
            clbStokGrup.Padding = new System.Windows.Forms.Padding(1);
            clbStokGrup.selectedDataRowId = null;
            clbStokGrup.selectedDataRowValue = null;
            clbStokGrup.Size = new System.Drawing.Size(243, 38);
            clbStokGrup.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(48, 53);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 15);
            label1.TabIndex = 5;
            label1.Text = "Proje Kodu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(48, 91);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 15);
            label2.TabIndex = 6;
            label2.Text = "Stok Grubu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(48, 131);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(91, 15);
            label3.TabIndex = 8;
            label3.Text = "Malzeme Grubu";
            // 
            // clbMalzemeGrup
            // 
            clbMalzemeGrup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbMalzemeGrup.ListBoxVisualSize = 5;
            clbMalzemeGrup.Location = new System.Drawing.Point(145, 124);
            clbMalzemeGrup.Margin = new System.Windows.Forms.Padding(1);
            clbMalzemeGrup.Name = "clbMalzemeGrup";
            clbMalzemeGrup.Padding = new System.Windows.Forms.Padding(1);
            clbMalzemeGrup.selectedDataRowId = null;
            clbMalzemeGrup.selectedDataRowValue = null;
            clbMalzemeGrup.Size = new System.Drawing.Size(243, 36);
            clbMalzemeGrup.TabIndex = 7;
            // 
            // SatinalmaTekliflerFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(959, 674);
            Controls.Add(label3);
            Controls.Add(clbMalzemeGrup);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(clbStokGrup);
            Controls.Add(clbPorjeKod);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTekliflerFormu";
            Text = "SatinalmaTeklifTaleplerFormu";
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem teklifiSiparişeDönüştürToolStripMenuItem;
        private CustomControls.CustomComboListBox clbPorjeKod;
        private CustomControls.CustomComboListBox clbStokGrup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomControls.CustomComboListBox clbMalzemeGrup;
    }
}