namespace YektamakDesktop.Formlar.Genel
{
    partial class DosyalamaParametreleri
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
            fcbStokGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbMalzemeGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbMalzemeAltGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbBoyut = new YektamakDesktop.CustomControls.FilterableComboBox();
            ctbPath = new YektamakDesktop.CustomControls.CustomTextBox();
            ctbKlasor = new YektamakDesktop.CustomControls.CustomTextBox();
            chkPdf = new System.Windows.Forms.CheckBox();
            chkDxf = new System.Windows.Forms.CheckBox();
            chkStep = new System.Windows.Forms.CheckBox();
            btnSave = new YektamakDesktop.CustomControls.CustomButtonSave();
            btnNew = new YektamakDesktop.CustomControls.RoundedButton();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ctbId = new YektamakDesktop.CustomControls.CustomTextBox();
            chkBukum = new System.Windows.Forms.CheckBox();
            chkTalasli = new System.Windows.Forms.CheckBox();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Dosyalama Parametreleri";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(863, 25);
            headerPanel1.TabIndex = 0;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(12, 247);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(819, 385);
            universalGrid1.TabIndex = 1;
            // 
            // fcbStokGrup
            // 
            fcbStokGrup.BorderColor = System.Drawing.Color.Silver;
            fcbStokGrup.BorderRadius = 8;
            fcbStokGrup.BorderSize = 1;
            fcbStokGrup.DisplayMember = "ad";
            fcbStokGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbStokGrup.Location = new System.Drawing.Point(84, 93);
            fcbStokGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbStokGrup.Name = "fcbStokGrup";
            fcbStokGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbStokGrup.PlaceholderText = "Stok Grup";
            fcbStokGrup.Size = new System.Drawing.Size(166, 25);
            fcbStokGrup.TabIndex = 2;
            fcbStokGrup.ValueMember = "Id";
            // 
            // fcbMalzemeGrup
            // 
            fcbMalzemeGrup.BorderColor = System.Drawing.Color.Silver;
            fcbMalzemeGrup.BorderRadius = 8;
            fcbMalzemeGrup.BorderSize = 1;
            fcbMalzemeGrup.DisplayMember = "ad";
            fcbMalzemeGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMalzemeGrup.Location = new System.Drawing.Point(84, 128);
            fcbMalzemeGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbMalzemeGrup.Name = "fcbMalzemeGrup";
            fcbMalzemeGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMalzemeGrup.PlaceholderText = "Malzeme Grup";
            fcbMalzemeGrup.Size = new System.Drawing.Size(166, 25);
            fcbMalzemeGrup.TabIndex = 3;
            fcbMalzemeGrup.ValueMember = "Id";
            // 
            // fcbMalzemeAltGrup
            // 
            fcbMalzemeAltGrup.BorderColor = System.Drawing.Color.Silver;
            fcbMalzemeAltGrup.BorderRadius = 8;
            fcbMalzemeAltGrup.BorderSize = 1;
            fcbMalzemeAltGrup.DisplayMember = "ad";
            fcbMalzemeAltGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMalzemeAltGrup.Location = new System.Drawing.Point(84, 163);
            fcbMalzemeAltGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbMalzemeAltGrup.Name = "fcbMalzemeAltGrup";
            fcbMalzemeAltGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbMalzemeAltGrup.PlaceholderText = "Malzeme Alt Grup";
            fcbMalzemeAltGrup.Size = new System.Drawing.Size(166, 25);
            fcbMalzemeAltGrup.TabIndex = 4;
            fcbMalzemeAltGrup.ValueMember = "Id";
            // 
            // fcbBoyut
            // 
            fcbBoyut.BorderColor = System.Drawing.Color.Silver;
            fcbBoyut.BorderRadius = 8;
            fcbBoyut.BorderSize = 1;
            fcbBoyut.DisplayMember = "ad";
            fcbBoyut.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbBoyut.Location = new System.Drawing.Point(339, 58);
            fcbBoyut.Margin = new System.Windows.Forms.Padding(1);
            fcbBoyut.Name = "fcbBoyut";
            fcbBoyut.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbBoyut.PlaceholderText = "Boyut";
            fcbBoyut.Size = new System.Drawing.Size(262, 25);
            fcbBoyut.TabIndex = 5;
            fcbBoyut.ValueMember = "Id";
            // 
            // ctbPath
            // 
            ctbPath.BackColor = System.Drawing.Color.White;
            ctbPath.BorderColor = System.Drawing.Color.Silver;
            ctbPath.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbPath.BorderSize = 1;
            ctbPath.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbPath.ForeColor = System.Drawing.Color.Black;
            ctbPath.Location = new System.Drawing.Point(339, 93);
            ctbPath.Margin = new System.Windows.Forms.Padding(1);
            ctbPath.Multiline = false;
            ctbPath.Name = "ctbPath";
            ctbPath.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbPath.PasswordChar = false;
            ctbPath.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbPath.PlaceholderText = "Klasör Yolu";
            ctbPath.ReadOnly = false;
            ctbPath.SelectionStart = 0;
            ctbPath.Size = new System.Drawing.Size(262, 33);
            ctbPath.TabIndex = 6;
            ctbPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbPath.TextCustom = "";
            ctbPath.UnderlinedStyle = false;
            // 
            // ctbKlasor
            // 
            ctbKlasor.BackColor = System.Drawing.Color.White;
            ctbKlasor.BorderColor = System.Drawing.Color.Silver;
            ctbKlasor.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbKlasor.BorderSize = 1;
            ctbKlasor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbKlasor.ForeColor = System.Drawing.Color.Black;
            ctbKlasor.Location = new System.Drawing.Point(339, 128);
            ctbKlasor.Margin = new System.Windows.Forms.Padding(1);
            ctbKlasor.Multiline = false;
            ctbKlasor.Name = "ctbKlasor";
            ctbKlasor.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbKlasor.PasswordChar = false;
            ctbKlasor.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbKlasor.PlaceholderText = "Klasör";
            ctbKlasor.ReadOnly = false;
            ctbKlasor.SelectionStart = 0;
            ctbKlasor.Size = new System.Drawing.Size(262, 33);
            ctbKlasor.TabIndex = 7;
            ctbKlasor.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbKlasor.TextCustom = "";
            ctbKlasor.UnderlinedStyle = false;
            // 
            // chkPdf
            // 
            chkPdf.AutoSize = true;
            chkPdf.Location = new System.Drawing.Point(339, 200);
            chkPdf.Name = "chkPdf";
            chkPdf.Size = new System.Drawing.Size(44, 19);
            chkPdf.TabIndex = 8;
            chkPdf.Text = "Pdf";
            chkPdf.UseVisualStyleBackColor = true;
            // 
            // chkDxf
            // 
            chkDxf.AutoSize = true;
            chkDxf.Location = new System.Drawing.Point(439, 200);
            chkDxf.Name = "chkDxf";
            chkDxf.Size = new System.Drawing.Size(44, 19);
            chkDxf.TabIndex = 9;
            chkDxf.Text = "Dxf";
            chkDxf.UseVisualStyleBackColor = true;
            // 
            // chkStep
            // 
            chkStep.AutoSize = true;
            chkStep.Location = new System.Drawing.Point(528, 200);
            chkStep.Name = "chkStep";
            chkStep.Size = new System.Drawing.Size(49, 19);
            chkStep.TabIndex = 10;
            chkStep.Text = "Step";
            chkStep.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.Transparent;
            btnSave.Location = new System.Drawing.Point(711, 173);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(106, 46);
            btnSave.TabIndex = 11;
            btnSave.SaveButtonClick += btnSave_SaveButtonClick;
            // 
            // btnNew
            // 
            btnNew.BackgroundColor = System.Drawing.Color.Firebrick;
            btnNew.BorderColor = System.Drawing.Color.Black;
            btnNew.BorderSize = 0;
            btnNew.CornerRadius = 10;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNew.ForeColor = System.Drawing.Color.White;
            btnNew.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnNew.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnNew.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnNew.HoverColor2 = System.Drawing.Color.Navy;
            btnNew.Icon = null;
            btnNew.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnNew.Location = new System.Drawing.Point(711, 59);
            btnNew.Name = "btnNew";
            btnNew.Size = new System.Drawing.Size(106, 40);
            btnNew.TabIndex = 12;
            btnNew.Text = "YENİ KAYIT";
            btnNew.TextColor = System.Drawing.Color.White;
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { silToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(87, 26);
            // 
            // silToolStripMenuItem
            // 
            silToolStripMenuItem.Name = "silToolStripMenuItem";
            silToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            silToolStripMenuItem.Text = "Sil";
            silToolStripMenuItem.Click += silToolStripMenuItem_Click;
            // 
            // ctbId
            // 
            ctbId.BackColor = System.Drawing.Color.White;
            ctbId.BorderColor = System.Drawing.Color.Silver;
            ctbId.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbId.BorderSize = 1;
            ctbId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbId.ForeColor = System.Drawing.Color.Black;
            ctbId.Location = new System.Drawing.Point(84, 58);
            ctbId.Margin = new System.Windows.Forms.Padding(1);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbId.PasswordChar = false;
            ctbId.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbId.PlaceholderText = "Id";
            ctbId.ReadOnly = false;
            ctbId.SelectionStart = 0;
            ctbId.Size = new System.Drawing.Size(60, 33);
            ctbId.TabIndex = 13;
            ctbId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbId.TextCustom = "";
            ctbId.UnderlinedStyle = false;
            // 
            // chkBukum
            // 
            chkBukum.AutoSize = true;
            chkBukum.Location = new System.Drawing.Point(340, 165);
            chkBukum.Name = "chkBukum";
            chkBukum.Size = new System.Drawing.Size(64, 19);
            chkBukum.TabIndex = 14;
            chkBukum.Text = "Büküm";
            chkBukum.UseVisualStyleBackColor = true;
            // 
            // chkTalasli
            // 
            chkTalasli.AutoSize = true;
            chkTalasli.Location = new System.Drawing.Point(452, 165);
            chkTalasli.Name = "chkTalasli";
            chkTalasli.Size = new System.Drawing.Size(57, 19);
            chkTalasli.TabIndex = 15;
            chkTalasli.Text = "Talaşlı";
            chkTalasli.UseVisualStyleBackColor = true;
            // 
            // DosyalamaParametreleri
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(863, 644);
            Controls.Add(chkTalasli);
            Controls.Add(chkBukum);
            Controls.Add(ctbId);
            Controls.Add(btnNew);
            Controls.Add(btnSave);
            Controls.Add(chkStep);
            Controls.Add(chkDxf);
            Controls.Add(chkPdf);
            Controls.Add(ctbKlasor);
            Controls.Add(ctbPath);
            Controls.Add(fcbBoyut);
            Controls.Add(fcbMalzemeAltGrup);
            Controls.Add(fcbMalzemeGrup);
            Controls.Add(fcbStokGrup);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "DosyalamaParametreleri";
            Text = "DosyalamaParametreleri";
            FormClosing += DosyalamaParametreleri_FormClosing;
            Load += DosyalamaParametreleri_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.FilterableComboBox fcbStokGrup;
        private CustomControls.FilterableComboBox fcbMalzemeGrup;
        private CustomControls.FilterableComboBox fcbMalzemeAltGrup;
        private CustomControls.FilterableComboBox fcbBoyut;
        private CustomControls.CustomTextBox ctbPath;
        private CustomControls.CustomTextBox ctbKlasor;
        private System.Windows.Forms.CheckBox chkPdf;
        private System.Windows.Forms.CheckBox chkDxf;
        private System.Windows.Forms.CheckBox chkStep;
        private CustomControls.CustomButtonSave btnSave;
        private CustomControls.RoundedButton btnNew;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private CustomControls.CustomTextBox ctbId;
        private System.Windows.Forms.CheckBox chkBukum;
        private System.Windows.Forms.CheckBox chkTalasli;
    }
}