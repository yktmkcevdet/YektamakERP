namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTalepTeklifFormu
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
            btnTeklif = new YektamakDesktop.CustomControls.RoundedIconButton();
            cbxStokGrupId = new YektamakDesktop.CustomControls.CustomComboListBox();
            cbxMalzemeGrupId = new YektamakDesktop.CustomControls.CustomComboListBox();
            ctxBeginTeslimTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            ctxEndTeslimTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            cbxMalzemeAltGrupId = new YektamakDesktop.CustomControls.CustomComboListBox();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            parçaListesiniGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ctbBeginTalepTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            ctbEndTalepTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            panel1 = new System.Windows.Forms.Panel();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Satınalma Teklif İsteme Formu";
            headerPanel1.Location = new System.Drawing.Point(-2, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1009, 32);
            headerPanel1.TabIndex = 0;
            // 
            // universalGrid1
            // 
            universalGrid1.kullanici = null;
            universalGrid1.Location = new System.Drawing.Point(0, 240);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1007, 372);
            universalGrid1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnTeklif
            // 
            btnTeklif.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
            btnTeklif.CornerRadius = 10;
            btnTeklif.Cursor = System.Windows.Forms.Cursors.Hand;
            btnTeklif.FlatAppearance.BorderSize = 0;
            btnTeklif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTeklif.ForeColor = System.Drawing.SystemColors.ControlText;
            btnTeklif.IconChar = FontAwesome.Sharp.IconChar.CommentDollar;
            btnTeklif.IconColor = System.Drawing.Color.Black;
            btnTeklif.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnTeklif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnTeklif.Location = new System.Drawing.Point(481, 200);
            btnTeklif.Name = "btnTeklif";
            btnTeklif.Size = new System.Drawing.Size(149, 34);
            btnTeklif.TabIndex = 4;
            btnTeklif.Text = "teklif iste";
            btnTeklif.UseVisualStyleBackColor = false;
            btnTeklif.Click += btnTeklif_Click;
            // 
            // cbxStokGrupId
            // 
            cbxStokGrupId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxStokGrupId.ListBoxVisualSize = 5;
            cbxStokGrupId.Location = new System.Drawing.Point(49, 38);
            cbxStokGrupId.Margin = new System.Windows.Forms.Padding(1);
            cbxStokGrupId.Name = "cbxStokGrupId";
            cbxStokGrupId.Padding = new System.Windows.Forms.Padding(1);
            cbxStokGrupId.Size = new System.Drawing.Size(250, 36);
            cbxStokGrupId.TabIndex = 5;
            cbxStokGrupId.SelectedIndexChanged += cbxStokGrupId_SelectedIndexChanged;
            // 
            // cbxMalzemeGrupId
            // 
            cbxMalzemeGrupId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxMalzemeGrupId.ListBoxVisualSize = 5;
            cbxMalzemeGrupId.Location = new System.Drawing.Point(49, 76);
            cbxMalzemeGrupId.Margin = new System.Windows.Forms.Padding(1);
            cbxMalzemeGrupId.Name = "cbxMalzemeGrupId";
            cbxMalzemeGrupId.Padding = new System.Windows.Forms.Padding(1);
            cbxMalzemeGrupId.Size = new System.Drawing.Size(250, 36);
            cbxMalzemeGrupId.TabIndex = 6;
            cbxMalzemeGrupId.SelectedIndexChanged += cbxMalzemeGrupId_SelectedIndexChanged;
            // 
            // ctxBeginTeslimTarihi
            // 
            ctxBeginTeslimTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctxBeginTeslimTarihi.Location = new System.Drawing.Point(49, 200);
            ctxBeginTeslimTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctxBeginTeslimTarihi.Name = "ctxBeginTeslimTarihi";
            ctxBeginTeslimTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctxBeginTeslimTarihi.Size = new System.Drawing.Size(145, 32);
            ctxBeginTeslimTarihi.TabIndex = 9;
            ctxBeginTeslimTarihi.TextCustom = null;
            ctxBeginTeslimTarihi.Guncelle += ctxBeginTeslimTarihi_Guncelle;
            // 
            // ctxEndTeslimTarihi
            // 
            ctxEndTeslimTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctxEndTeslimTarihi.Location = new System.Drawing.Point(196, 200);
            ctxEndTeslimTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctxEndTeslimTarihi.Name = "ctxEndTeslimTarihi";
            ctxEndTeslimTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctxEndTeslimTarihi.Size = new System.Drawing.Size(145, 32);
            ctxEndTeslimTarihi.TabIndex = 10;
            ctxEndTeslimTarihi.TextCustom = null;
            ctxEndTeslimTarihi.Guncelle += ctxEndTeslimTarihi_Guncelle;
            // 
            // cbxMalzemeAltGrupId
            // 
            cbxMalzemeAltGrupId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxMalzemeAltGrupId.ListBoxVisualSize = 5;
            cbxMalzemeAltGrupId.Location = new System.Drawing.Point(49, 114);
            cbxMalzemeAltGrupId.Margin = new System.Windows.Forms.Padding(1);
            cbxMalzemeAltGrupId.Name = "cbxMalzemeAltGrupId";
            cbxMalzemeAltGrupId.Padding = new System.Windows.Forms.Padding(1);
            cbxMalzemeAltGrupId.Size = new System.Drawing.Size(250, 36);
            cbxMalzemeAltGrupId.TabIndex = 11;
            cbxMalzemeAltGrupId.SelectedIndexChanged += cbxMalzemeAltGrupId_SelectedIndexChanged;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { parçaListesiniGösterToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new System.Drawing.Size(186, 26);
            // 
            // parçaListesiniGösterToolStripMenuItem
            // 
            parçaListesiniGösterToolStripMenuItem.Name = "parçaListesiniGösterToolStripMenuItem";
            parçaListesiniGösterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            parçaListesiniGösterToolStripMenuItem.Text = "Parça Listesini Göster";
            parçaListesiniGösterToolStripMenuItem.Click += parçaListesiniGösterToolStripMenuItem_Click;
            // 
            // ctbBeginTalepTarihi
            // 
            ctbBeginTalepTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbBeginTalepTarihi.Location = new System.Drawing.Point(49, 161);
            ctbBeginTalepTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbBeginTalepTarihi.Name = "ctbBeginTalepTarihi";
            ctbBeginTalepTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbBeginTalepTarihi.Size = new System.Drawing.Size(145, 32);
            ctbBeginTalepTarihi.TabIndex = 12;
            ctbBeginTalepTarihi.TextCustom = null;
            ctbBeginTalepTarihi.Guncelle += ctxBeginTalepTarihi_Guncelle;
            // 
            // ctbEndTalepTarihi
            // 
            ctbEndTalepTarihi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbEndTalepTarihi.Location = new System.Drawing.Point(196, 161);
            ctbEndTalepTarihi.Margin = new System.Windows.Forms.Padding(1);
            ctbEndTalepTarihi.Name = "ctbEndTalepTarihi";
            ctbEndTalepTarihi.Padding = new System.Windows.Forms.Padding(1);
            ctbEndTalepTarihi.Size = new System.Drawing.Size(145, 32);
            ctbEndTalepTarihi.TabIndex = 13;
            ctbEndTalepTarihi.TextCustom = null;
            ctbEndTalepTarihi.Guncelle += ctxEndTalepTarihi_Guncelle;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new System.Drawing.Point(470, 40);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(495, 150);
            panel1.TabIndex = 14;
            // 
            // SatinalmaTalepTeklifFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1007, 650);
            Controls.Add(panel1);
            Controls.Add(ctbEndTalepTarihi);
            Controls.Add(ctbBeginTalepTarihi);
            Controls.Add(cbxMalzemeAltGrupId);
            Controls.Add(ctxEndTeslimTarihi);
            Controls.Add(ctxBeginTeslimTarihi);
            Controls.Add(cbxMalzemeGrupId);
            Controls.Add(cbxStokGrupId);
            Controls.Add(btnTeklif);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepTeklifFormu";
            Text = "SatinalmaTalepTeklifFormu";
            FormClosing += SatinalmaTalepTeklifFormu_FormClosing;
            Load += SatinalmaTalepTeklifFormu_Load;
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private CustomControls.RoundedIconButton btnTeklif;
        private CustomControls.CustomComboListBox cbxStokGrupId;
        private CustomControls.CustomComboListBox cbxMalzemeGrupId;
        private CustomControls.CustomTextBoxTarih ctxBeginTeslimTarihi;
        private CustomControls.CustomTextBoxTarih ctxEndTeslimTarihi;
        private CustomControls.CustomComboListBox cbxMalzemeAltGrupId;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem parçaListesiniGösterToolStripMenuItem;
        private CustomControls.CustomTextBoxTarih ctbBeginTalepTarihi;
        private CustomControls.CustomTextBoxTarih ctbEndTalepTarihi;
        private System.Windows.Forms.Panel panel1;
    }
}