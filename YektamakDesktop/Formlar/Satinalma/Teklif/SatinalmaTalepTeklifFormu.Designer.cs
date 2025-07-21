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
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            btnTeklif = new YektamakDesktop.CustomControls.RoundedIconButton();
            clbStokGrupId = new YektamakDesktop.CustomControls.CustomComboListBox();
            clbMalzemeGrupId = new YektamakDesktop.CustomControls.CustomComboListBox();
            ctxBeginTeslimTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            ctxEndTeslimTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            clbMalzemeAltGrupId = new YektamakDesktop.CustomControls.CustomComboListBox();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            parçaListesiniGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ctbBeginTalepTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            ctbEndTalepTarihi = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            panel1 = new System.Windows.Forms.Panel();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            label1 = new System.Windows.Forms.Label();
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnTeklif
            // 
            btnTeklif.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
            btnTeklif.BorderColor = System.Drawing.Color.Black;
            btnTeklif.BorderSize = 0;
            btnTeklif.CornerRadius = 10;
            btnTeklif.Cursor = System.Windows.Forms.Cursors.Hand;
            btnTeklif.FlatAppearance.BorderSize = 0;
            btnTeklif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTeklif.ForeColor = System.Drawing.SystemColors.ControlText;
            btnTeklif.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnTeklif.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnTeklif.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnTeklif.HoverColor2 = System.Drawing.Color.Navy;
            btnTeklif.IconChar = FontAwesome.Sharp.IconChar.CommentDollar;
            btnTeklif.IconColor = System.Drawing.Color.Black;
            btnTeklif.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnTeklif.IconSize = 24;
            btnTeklif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnTeklif.Location = new System.Drawing.Point(846, 200);
            btnTeklif.Name = "btnTeklif";
            btnTeklif.Size = new System.Drawing.Size(149, 34);
            btnTeklif.TabIndex = 4;
            btnTeklif.Text = "teklif iste";
            btnTeklif.UseVisualStyleBackColor = false;
            btnTeklif.Click += btnTeklif_Click;
            // 
            // clbStokGrupId
            // 
            clbStokGrupId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbStokGrupId.ListBoxVisualSize = 5;
            clbStokGrupId.Location = new System.Drawing.Point(49, 38);
            clbStokGrupId.Margin = new System.Windows.Forms.Padding(1);
            clbStokGrupId.Name = "clbStokGrupId";
            clbStokGrupId.Padding = new System.Windows.Forms.Padding(1);
            clbStokGrupId.selectedDataRowId = null;
            clbStokGrupId.selectedDataRowValue = null;
            clbStokGrupId.Size = new System.Drawing.Size(250, 36);
            clbStokGrupId.TabIndex = 5;
            clbStokGrupId.SelectedIndexChanged += cbxStokGrupId_SelectedIndexChanged;
            // 
            // clbMalzemeGrupId
            // 
            clbMalzemeGrupId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbMalzemeGrupId.ListBoxVisualSize = 5;
            clbMalzemeGrupId.Location = new System.Drawing.Point(49, 76);
            clbMalzemeGrupId.Margin = new System.Windows.Forms.Padding(1);
            clbMalzemeGrupId.Name = "clbMalzemeGrupId";
            clbMalzemeGrupId.Padding = new System.Windows.Forms.Padding(1);
            clbMalzemeGrupId.selectedDataRowId = null;
            clbMalzemeGrupId.selectedDataRowValue = null;
            clbMalzemeGrupId.Size = new System.Drawing.Size(250, 36);
            clbMalzemeGrupId.TabIndex = 6;
            clbMalzemeGrupId.SelectedIndexChanged += cbxMalzemeGrupId_SelectedIndexChanged;
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
            // 
            // clbMalzemeAltGrupId
            // 
            clbMalzemeAltGrupId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbMalzemeAltGrupId.ListBoxVisualSize = 5;
            clbMalzemeAltGrupId.Location = new System.Drawing.Point(49, 114);
            clbMalzemeAltGrupId.Margin = new System.Windows.Forms.Padding(1);
            clbMalzemeAltGrupId.Name = "clbMalzemeAltGrupId";
            clbMalzemeAltGrupId.Padding = new System.Windows.Forms.Padding(1);
            clbMalzemeAltGrupId.selectedDataRowId = null;
            clbMalzemeAltGrupId.selectedDataRowValue = null;
            clbMalzemeAltGrupId.Size = new System.Drawing.Size(250, 36);
            clbMalzemeAltGrupId.TabIndex = 11;
            clbMalzemeAltGrupId.SelectedIndexChanged += clbMalzemeAltGrupId_SelectedIndexChanged;
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
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new System.Drawing.Point(369, 57);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(471, 171);
            panel1.TabIndex = 14;
            // 
            // universalGrid1
            // 
            universalGrid1.kullanici = null;
            universalGrid1.Location = new System.Drawing.Point(-2, 252);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1009, 400);
            universalGrid1.TabIndex = 15;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(369, 38);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(132, 15);
            label1.TabIndex = 16;
            label1.Text = "Teklif İstenecek Firmalar";
            // 
            // SatinalmaTalepTeklifFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1007, 650);
            Controls.Add(label1);
            Controls.Add(universalGrid1);
            Controls.Add(panel1);
            Controls.Add(ctbEndTalepTarihi);
            Controls.Add(ctbBeginTalepTarihi);
            Controls.Add(clbMalzemeAltGrupId);
            Controls.Add(ctxEndTeslimTarihi);
            Controls.Add(ctxBeginTeslimTarihi);
            Controls.Add(clbMalzemeGrupId);
            Controls.Add(clbStokGrupId);
            Controls.Add(btnTeklif);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepTeklifFormu";
            Text = "SatinalmaTalepTeklifFormu";
            FormClosing += SatinalmaTalepTeklifFormu_FormClosing;
            Load += SatinalmaTalepTeklifFormu_Load;
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void UniversalGrid1_MouseDown1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private CustomControls.RoundedIconButton btnTeklif;
        private CustomControls.CustomComboListBox clbStokGrupId;
        private CustomControls.CustomComboListBox clbMalzemeGrupId;
        private CustomControls.CustomTextBoxTarih ctxBeginTeslimTarihi;
        private CustomControls.CustomTextBoxTarih ctxEndTeslimTarihi;
        private CustomControls.CustomComboListBox clbMalzemeAltGrupId;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem parçaListesiniGösterToolStripMenuItem;
        private CustomControls.CustomTextBoxTarih ctbBeginTalepTarihi;
        private CustomControls.CustomTextBoxTarih ctbEndTalepTarihi;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.Label label1;
    }
}