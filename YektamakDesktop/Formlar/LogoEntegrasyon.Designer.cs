namespace YektamakDesktop.Formlar
{
    partial class LogoEntegrasyon
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
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            kaydıAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ctbDefinition = new YektamakDesktop.CustomControls.CustomTextBox();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // universalGrid1
            // 
            universalGrid1.Location = new System.Drawing.Point(31, 196);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1124, 498);
            universalGrid1.TabIndex = 0;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Logo Entegrasyon";
            headerPanel1.Location = new System.Drawing.Point(-1, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1217, 25);
            headerPanel1.TabIndex = 1;
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Black;
            roundedButton1.BorderSize = 0;
            roundedButton1.CornerRadius = 10;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedButton1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedButton1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedButton1.HoverColor2 = System.Drawing.Color.Navy;
            roundedButton1.Icon = null;
            roundedButton1.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton1.Location = new System.Drawing.Point(995, 667);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(150, 40);
            roundedButton1.TabIndex = 2;
            roundedButton1.Text = "LOGO'dan Kayıtları Getir";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { kaydıAlToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(118, 26);
            // 
            // kaydıAlToolStripMenuItem
            // 
            kaydıAlToolStripMenuItem.Name = "kaydıAlToolStripMenuItem";
            kaydıAlToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            kaydıAlToolStripMenuItem.Text = "Kaydı Al";
            kaydıAlToolStripMenuItem.Click += kaydıAlToolStripMenuItem_Click;
            // 
            // ctbDefinition
            // 
            ctbDefinition.BackColor = System.Drawing.SystemColors.Window;
            ctbDefinition.BorderColor = System.Drawing.Color.Silver;
            ctbDefinition.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbDefinition.BorderSize = 1;
            ctbDefinition.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbDefinition.ForeColor = System.Drawing.Color.DimGray;
            ctbDefinition.Location = new System.Drawing.Point(31, 52);
            ctbDefinition.Margin = new System.Windows.Forms.Padding(1);
            ctbDefinition.Multiline = false;
            ctbDefinition.Name = "ctbDefinition";
            ctbDefinition.Padding = new System.Windows.Forms.Padding(3);
            ctbDefinition.PasswordChar = false;
            ctbDefinition.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbDefinition.PlaceholderText = "Firma Adı İle Ara";
            ctbDefinition.ReadOnly = false;
            ctbDefinition.SelectionStart = 0;
            ctbDefinition.Size = new System.Drawing.Size(481, 25);
            ctbDefinition.TabIndex = 3;
            ctbDefinition.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbDefinition.TextCustom = "";
            ctbDefinition.UnderlinedStyle = false;
            ctbDefinition.KeyDown += ctbDefinition_KeyDown;
            // 
            // LogoEntegrasyon
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1216, 719);
            Controls.Add(ctbDefinition);
            Controls.Add(roundedButton1);
            Controls.Add(headerPanel1);
            Controls.Add(universalGrid1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "LogoEntegrasyon";
            Text = "LogoEntegrasyon";
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.UniversalGrid universalGrid1;
        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.RoundedButton roundedButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kaydıAlToolStripMenuItem;
        private CustomControls.CustomTextBox ctbDefinition;
    }
}