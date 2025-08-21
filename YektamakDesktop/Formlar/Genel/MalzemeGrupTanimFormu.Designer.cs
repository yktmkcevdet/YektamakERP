namespace YektamakDesktop.Formlar.Genel
{
    partial class MalzemeGrupTanimFormu
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
            ctbMalzemeGrupId = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ctbMalzemeGrupAd = new YektamakDesktop.CustomControls.CustomTextBox();
            label2 = new System.Windows.Forms.Label();
            ctbMalzemeGrupKod = new YektamakDesktop.CustomControls.CustomTextBox();
            fcbStokGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            label4 = new System.Windows.Forms.Label();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            malzemeGrubunuSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ctbMalzemeGrupId
            // 
            ctbMalzemeGrupId.BackColor = System.Drawing.Color.White;
            ctbMalzemeGrupId.Enabled = false;
            ctbMalzemeGrupId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbMalzemeGrupId.ForeColor = System.Drawing.Color.Black;
            ctbMalzemeGrupId.Location = new System.Drawing.Point(153, 43);
            ctbMalzemeGrupId.Name = "ctbMalzemeGrupId";
            ctbMalzemeGrupId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbMalzemeGrupId.Size = new System.Drawing.Size(63, 28);
            ctbMalzemeGrupId.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(33, 49);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(18, 15);
            label3.TabIndex = 2;
            label3.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(33, 83);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(105, 15);
            label1.TabIndex = 5;
            label1.Text = "Malzeme Grup Adı";
            // 
            // ctbMalzemeGrupAd
            // 
            ctbMalzemeGrupAd.BackColor = System.Drawing.Color.White;
            ctbMalzemeGrupAd.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbMalzemeGrupAd.ForeColor = System.Drawing.Color.Black;
            ctbMalzemeGrupAd.Location = new System.Drawing.Point(153, 77);
            ctbMalzemeGrupAd.Name = "ctbMalzemeGrupAd";
            ctbMalzemeGrupAd.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbMalzemeGrupAd.Size = new System.Drawing.Size(262, 28);
            ctbMalzemeGrupAd.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(33, 117);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(115, 15);
            label2.TabIndex = 7;
            label2.Text = "Malzeme Grup Kodu";
            // 
            // ctbMalzemeGrupKod
            // 
            ctbMalzemeGrupKod.BackColor = System.Drawing.Color.White;
            ctbMalzemeGrupKod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbMalzemeGrupKod.ForeColor = System.Drawing.Color.Black;
            ctbMalzemeGrupKod.Location = new System.Drawing.Point(153, 111);
            ctbMalzemeGrupKod.Name = "ctbMalzemeGrupKod";
            ctbMalzemeGrupKod.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbMalzemeGrupKod.Size = new System.Drawing.Size(134, 28);
            ctbMalzemeGrupKod.TabIndex = 6;
            // 
            // fcbStokGrup
            // 
            fcbStokGrup.Location = new System.Drawing.Point(153, 145);
            fcbStokGrup.Name = "fcbStokGrup";
            fcbStokGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbStokGrup.Size = new System.Drawing.Size(262, 29);
            fcbStokGrup.TabIndex = 8;
            fcbStokGrup.SelectedIndexChanged += fcbStokGrup_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(33, 152);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 15);
            label4.TabIndex = 9;
            label4.Text = "Stok Grubu";
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(418, 204);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 10;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.Location = new System.Drawing.Point(33, 204);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(105, 40);
            roundedButton1.TabIndex = 11;
            roundedButton1.Text = "YENİ KAYIT";
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // headerPanel2
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Location = new System.Drawing.Point(-1, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel2";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(578, 32);
            headerPanel1.TabIndex = 12;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(5, 256);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(565, 345);
            universalGrid1.TabIndex = 13;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { malzemeGrubunuSilToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(188, 26);
            // 
            // malzemeGrubunuSilToolStripMenuItem
            // 
            malzemeGrubunuSilToolStripMenuItem.Name = "malzemeGrubunuSilToolStripMenuItem";
            malzemeGrubunuSilToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            malzemeGrubunuSilToolStripMenuItem.Text = "Malzeme Grubunu Sil";
            malzemeGrubunuSilToolStripMenuItem.Click += malzemeGrubunuSilToolStripMenuItem_Click;
            // 
            // MalzemeGrupTanimFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(577, 606);
            Controls.Add(universalGrid1);
            Controls.Add(headerPanel1);
            Controls.Add(roundedButton1);
            Controls.Add(customButtonSave1);
            Controls.Add(label4);
            Controls.Add(fcbStokGrup);
            Controls.Add(label2);
            Controls.Add(ctbMalzemeGrupKod);
            Controls.Add(label1);
            Controls.Add(ctbMalzemeGrupAd);
            Controls.Add(label3);
            Controls.Add(ctbMalzemeGrupId);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "MalzemeGrupTanimFormu";
            Text = "MalzemeGrupTanimFormu";
            FormClosing += MalzemeGrupTanimFormu_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.CustomTextBoxSayisal ctbMalzemeGrupId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomTextBox ctbMalzemeGrupAd;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomTextBox ctbMalzemeGrupKod;
        private CustomControls.FilterableComboBox fcbStokGrup;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem malzemeGrubunuSilToolStripMenuItem;
    }
}