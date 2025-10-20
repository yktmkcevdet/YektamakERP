namespace YektamakDesktop.Formlar.Satinalma.Siparis
{
    partial class SatinalmaSiparisler
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
            fcbProjeKod = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbFirma = new YektamakDesktop.CustomControls.FilterableComboBox();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            siparişiGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            siparişiSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Satınalma Sipariş Listesi";
            headerPanel1.Location = new System.Drawing.Point(-1, -2);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1046, 25);
            headerPanel1.TabIndex = 0;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(12, 160);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1019, 451);
            universalGrid1.TabIndex = 1;
            // 
            // fcbProjeKod
            // 
            fcbProjeKod.BorderColor = System.Drawing.Color.Silver;
            fcbProjeKod.BorderRadius = 8;
            fcbProjeKod.BorderSize = 1;
            fcbProjeKod.DisplayMember = "ad";
            fcbProjeKod.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbProjeKod.Location = new System.Drawing.Point(52, 45);
            fcbProjeKod.Margin = new System.Windows.Forms.Padding(1);
            fcbProjeKod.Name = "fcbProjeKod";
            fcbProjeKod.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbProjeKod.PlaceholderText = "Proje Kodu";
            fcbProjeKod.Size = new System.Drawing.Size(270, 29);
            fcbProjeKod.TabIndex = 2;
            fcbProjeKod.ValueMember = "Id";
            // 
            // fcbFirma
            // 
            fcbFirma.BorderColor = System.Drawing.Color.Silver;
            fcbFirma.BorderRadius = 8;
            fcbFirma.BorderSize = 1;
            fcbFirma.DisplayMember = "ad";
            fcbFirma.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbFirma.Location = new System.Drawing.Point(52, 80);
            fcbFirma.Margin = new System.Windows.Forms.Padding(1);
            fcbFirma.Name = "fcbFirma";
            fcbFirma.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbFirma.PlaceholderText = "Firma";
            fcbFirma.Size = new System.Drawing.Size(270, 29);
            fcbFirma.TabIndex = 3;
            fcbFirma.ValueMember = "Id";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { siparişiGörüntüleToolStripMenuItem, siparişiSilToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(157, 48);
            // 
            // siparişiGörüntüleToolStripMenuItem
            // 
            siparişiGörüntüleToolStripMenuItem.Image = Properties.Resources.data_update_icon;
            siparişiGörüntüleToolStripMenuItem.Name = "siparişiGörüntüleToolStripMenuItem";
            siparişiGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            siparişiGörüntüleToolStripMenuItem.Text = "Siparişi Düzenle";
            siparişiGörüntüleToolStripMenuItem.Click += siparişiGörüntüleToolStripMenuItem_Click;
            // 
            // siparişiSilToolStripMenuItem
            // 
            siparişiSilToolStripMenuItem.Image = Properties.Resources.sil;
            siparişiSilToolStripMenuItem.Name = "siparişiSilToolStripMenuItem";
            siparişiSilToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            siparişiSilToolStripMenuItem.Text = "Siparişi Sil";
            siparişiSilToolStripMenuItem.Click += siparişiSilToolStripMenuItem_Click;
            // 
            // SatinalmaSiparisler
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1043, 610);
            Controls.Add(fcbFirma);
            Controls.Add(fcbProjeKod);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaSiparisler";
            Text = "SatinalmaSiparisler";
            Load += SatinalmaSiparisler_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.FilterableComboBox fcbProjeKod;
        private CustomControls.FilterableComboBox fcbFirma;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem siparişiGörüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siparişiSilToolStripMenuItem;
    }
}