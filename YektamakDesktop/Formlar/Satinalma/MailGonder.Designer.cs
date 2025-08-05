namespace YektamakDesktop.Formlar.Satinalma
{
    partial class MailGonder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailGonder));
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            rtbBody = new System.Windows.Forms.RichTextBox();
            btnSendMail = new YektamakDesktop.CustomControls.RoundedIconButton();
            tbxMailTo = new YektamakDesktop.CustomControls.CustomTextBox();
            tsMain = new System.Windows.Forms.ToolStrip();
            tsbBold = new System.Windows.Forms.ToolStripButton();
            tsbItalic = new System.Windows.Forms.ToolStripButton();
            tsbUnderLine = new System.Windows.Forms.ToolStripButton();
            tscFontSize = new System.Windows.Forms.ToolStripComboBox();
            tsbForeColor = new System.Windows.Forms.ToolStripButton();
            tsbBackcolor = new System.Windows.Forms.ToolStripButton();
            toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            tbxMailCc = new YektamakDesktop.CustomControls.CustomTextBox();
            tbxMailBcc = new YektamakDesktop.CustomControls.CustomTextBox();
            tbxKonu = new YektamakDesktop.CustomControls.CustomTextBox();
            btnTo = new YektamakDesktop.CustomControls.RoundedIconButton();
            btnCc = new YektamakDesktop.CustomControls.RoundedIconButton();
            btnBcc = new YektamakDesktop.CustomControls.RoundedIconButton();
            label2 = new System.Windows.Forms.Label();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            cmsColors = new System.Windows.Forms.ContextMenuStrip(components);
            redItem = new System.Windows.Forms.ToolStripMenuItem();
            blueItem = new System.Windows.Forms.ToolStripMenuItem();
            yellowItem = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            görüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ekleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            btnAttach = new YektamakDesktop.CustomControls.RoundedIconButton();
            tsMain.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            cmsColors.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Mail Gönder";
            headerPanel1.Location = new System.Drawing.Point(-2, -1);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1020, 32);
            headerPanel1.TabIndex = 0;
            // 
            // rtbBody
            // 
            rtbBody.Location = new System.Drawing.Point(6, 379);
            rtbBody.Name = "rtbBody";
            rtbBody.Size = new System.Drawing.Size(993, 334);
            rtbBody.TabIndex = 1;
            rtbBody.Text = "";
            // 
            // btnSendMail
            // 
            btnSendMail.BackColor = System.Drawing.SystemColors.Control;
            btnSendMail.BorderColor = System.Drawing.Color.Black;
            btnSendMail.BorderSize = 0;
            btnSendMail.CornerRadius = 20;
            btnSendMail.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSendMail.FlatAppearance.BorderSize = 0;
            btnSendMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSendMail.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            btnSendMail.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnSendMail.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnSendMail.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnSendMail.HoverColor2 = System.Drawing.Color.Navy;
            btnSendMail.IconChar = FontAwesome.Sharp.IconChar.MailBulk;
            btnSendMail.IconColor = System.Drawing.Color.DeepSkyBlue;
            btnSendMail.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSendMail.IconSize = 24;
            btnSendMail.Location = new System.Drawing.Point(954, 719);
            btnSendMail.Name = "btnSendMail";
            btnSendMail.Size = new System.Drawing.Size(45, 40);
            btnSendMail.TabIndex = 2;
            btnSendMail.UseVisualStyleBackColor = false;
            btnSendMail.Click += btnSendMail_Click;
            // 
            // tbxMailTo
            // 
            tbxMailTo.BackColor = System.Drawing.Color.White;
            tbxMailTo.BorderColor = System.Drawing.Color.Silver;
            tbxMailTo.BorderFocusColor = System.Drawing.Color.HotPink;
            tbxMailTo.BorderRadius = 5;
            tbxMailTo.BorderSize = 1;
            tbxMailTo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbxMailTo.ForeColor = System.Drawing.Color.Black;
            tbxMailTo.isPlaceHolder = false;
            tbxMailTo.Location = new System.Drawing.Point(82, 53);
            tbxMailTo.Multiline = false;
            tbxMailTo.Name = "tbxMailTo";
            tbxMailTo.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            tbxMailTo.PasswordChar = false;
            tbxMailTo.PlaceholderColor = System.Drawing.Color.DarkGray;
            tbxMailTo.PlaceholderText = "";
            tbxMailTo.ReadOnly = false;
            tbxMailTo.SelectionStart = 0;
            tbxMailTo.Size = new System.Drawing.Size(777, 28);
            tbxMailTo.TabIndex = 3;
            tbxMailTo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            tbxMailTo.TextCustom = "";
            tbxMailTo.UnderlinedStyle = false;
            // 
            // tsMain
            // 
            tsMain.Dock = System.Windows.Forms.DockStyle.None;
            tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsbBold, tsbItalic, tsbUnderLine, tscFontSize, tsbForeColor, tsbBackcolor });
            tsMain.Location = new System.Drawing.Point(-2, 343);
            tsMain.Name = "tsMain";
            tsMain.Size = new System.Drawing.Size(204, 25);
            tsMain.TabIndex = 4;
            tsMain.Text = "toolStrip1";
            // 
            // tsbBold
            // 
            tsbBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbBold.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tsbBold.Image = (System.Drawing.Image)resources.GetObject("tsbBold.Image");
            tsbBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbBold.Name = "tsbBold";
            tsbBold.Size = new System.Drawing.Size(23, 22);
            tsbBold.Text = "toolStripButton1";
            tsbBold.ToolTipText = "Bold";
            tsbBold.Click += tsBold_Click;
            // 
            // tsbItalic
            // 
            tsbItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbItalic.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            tsbItalic.Image = (System.Drawing.Image)resources.GetObject("tsbItalic.Image");
            tsbItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbItalic.Name = "tsbItalic";
            tsbItalic.Size = new System.Drawing.Size(23, 22);
            tsbItalic.Text = "toolStripButton1";
            tsbItalic.ToolTipText = "İtalik";
            tsbItalic.Click += tsItalic_Click;
            // 
            // tsbUnderLine
            // 
            tsbUnderLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbUnderLine.Image = (System.Drawing.Image)resources.GetObject("tsbUnderLine.Image");
            tsbUnderLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbUnderLine.Name = "tsbUnderLine";
            tsbUnderLine.Size = new System.Drawing.Size(23, 22);
            tsbUnderLine.Text = "toolStripButton1";
            tsbUnderLine.ToolTipText = "UnderLine";
            tsbUnderLine.Click += tsUnderLine_Click;
            // 
            // tscFontSize
            // 
            tscFontSize.Items.AddRange(new object[] { "8", "9", "10", "12", "14", "16", "18", "20" });
            tscFontSize.Name = "tscFontSize";
            tscFontSize.Size = new System.Drawing.Size(75, 25);
            tscFontSize.Tag = "9";
            tscFontSize.ToolTipText = "Font Size";
            tscFontSize.SelectedIndexChanged += tscFontSize_SelectedIndexChanged;
            // 
            // tsbForeColor
            // 
            tsbForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbForeColor.Image = (System.Drawing.Image)resources.GetObject("tsbForeColor.Image");
            tsbForeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbForeColor.Name = "tsbForeColor";
            tsbForeColor.Size = new System.Drawing.Size(23, 22);
            tsbForeColor.Text = "toolStripButton1";
            tsbForeColor.ToolTipText = "Yazır Rengi";
            tsbForeColor.Click += tsbForeColor_Click;
            // 
            // tsbBackcolor
            // 
            tsbBackcolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbBackcolor.Image = (System.Drawing.Image)resources.GetObject("tsbBackcolor.Image");
            tsbBackcolor.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbBackcolor.Name = "tsbBackcolor";
            tsbBackcolor.Size = new System.Drawing.Size(23, 22);
            tsbBackcolor.Text = "toolStripButton1";
            tsbBackcolor.ToolTipText = "Arka Plan Rengi";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(818, 5);
            toolStripContainer1.Location = new System.Drawing.Point(6, 343);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new System.Drawing.Size(818, 30);
            toolStripContainer1.TabIndex = 5;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // tbxMailCc
            // 
            tbxMailCc.BackColor = System.Drawing.Color.White;
            tbxMailCc.BorderColor = System.Drawing.Color.Silver;
            tbxMailCc.BorderFocusColor = System.Drawing.Color.HotPink;
            tbxMailCc.BorderRadius = 5;
            tbxMailCc.BorderSize = 1;
            tbxMailCc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbxMailCc.ForeColor = System.Drawing.Color.Black;
            tbxMailCc.isPlaceHolder = false;
            tbxMailCc.Location = new System.Drawing.Point(82, 87);
            tbxMailCc.Multiline = false;
            tbxMailCc.Name = "tbxMailCc";
            tbxMailCc.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            tbxMailCc.PasswordChar = false;
            tbxMailCc.PlaceholderColor = System.Drawing.Color.DarkGray;
            tbxMailCc.PlaceholderText = "";
            tbxMailCc.ReadOnly = false;
            tbxMailCc.SelectionStart = 0;
            tbxMailCc.Size = new System.Drawing.Size(777, 28);
            tbxMailCc.TabIndex = 6;
            tbxMailCc.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            tbxMailCc.TextCustom = "";
            tbxMailCc.UnderlinedStyle = false;
            // 
            // tbxMailBcc
            // 
            tbxMailBcc.BackColor = System.Drawing.Color.White;
            tbxMailBcc.BorderColor = System.Drawing.Color.Silver;
            tbxMailBcc.BorderFocusColor = System.Drawing.Color.HotPink;
            tbxMailBcc.BorderRadius = 5;
            tbxMailBcc.BorderSize = 1;
            tbxMailBcc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbxMailBcc.ForeColor = System.Drawing.Color.Black;
            tbxMailBcc.isPlaceHolder = false;
            tbxMailBcc.Location = new System.Drawing.Point(82, 121);
            tbxMailBcc.Multiline = false;
            tbxMailBcc.Name = "tbxMailBcc";
            tbxMailBcc.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            tbxMailBcc.PasswordChar = false;
            tbxMailBcc.PlaceholderColor = System.Drawing.Color.DarkGray;
            tbxMailBcc.PlaceholderText = "";
            tbxMailBcc.ReadOnly = false;
            tbxMailBcc.SelectionStart = 0;
            tbxMailBcc.Size = new System.Drawing.Size(777, 28);
            tbxMailBcc.TabIndex = 9;
            tbxMailBcc.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            tbxMailBcc.TextCustom = "";
            tbxMailBcc.UnderlinedStyle = false;
            // 
            // tbxKonu
            // 
            tbxKonu.BackColor = System.Drawing.Color.White;
            tbxKonu.BorderColor = System.Drawing.Color.Silver;
            tbxKonu.BorderFocusColor = System.Drawing.Color.HotPink;
            tbxKonu.BorderRadius = 5;
            tbxKonu.BorderSize = 1;
            tbxKonu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbxKonu.ForeColor = System.Drawing.Color.Black;
            tbxKonu.isPlaceHolder = false;
            tbxKonu.Location = new System.Drawing.Point(82, 155);
            tbxKonu.Multiline = false;
            tbxKonu.Name = "tbxKonu";
            tbxKonu.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            tbxKonu.PasswordChar = false;
            tbxKonu.PlaceholderColor = System.Drawing.Color.DarkGray;
            tbxKonu.PlaceholderText = "";
            tbxKonu.ReadOnly = false;
            tbxKonu.SelectionStart = 0;
            tbxKonu.Size = new System.Drawing.Size(777, 28);
            tbxKonu.TabIndex = 14;
            tbxKonu.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            tbxKonu.TextCustom = "";
            tbxKonu.UnderlinedStyle = false;
            // 
            // btnTo
            // 
            btnTo.BackColor = System.Drawing.Color.Transparent;
            btnTo.BorderColor = System.Drawing.Color.Black;
            btnTo.BorderSize = 0;
            btnTo.CornerRadius = 10;
            btnTo.FlatAppearance.BorderSize = 0;
            btnTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            btnTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTo.ForeColor = System.Drawing.Color.White;
            btnTo.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnTo.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnTo.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnTo.HoverColor2 = System.Drawing.Color.Navy;
            btnTo.IconChar = FontAwesome.Sharp.IconChar.None;
            btnTo.IconColor = System.Drawing.Color.Black;
            btnTo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTo.IconSize = 24;
            btnTo.Location = new System.Drawing.Point(34, 53);
            btnTo.Name = "btnTo";
            btnTo.Size = new System.Drawing.Size(46, 23);
            btnTo.TabIndex = 16;
            btnTo.Text = "To";
            btnTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnTo.UseVisualStyleBackColor = true;
            // 
            // btnCc
            // 
            btnCc.BackColor = System.Drawing.Color.Transparent;
            btnCc.BorderColor = System.Drawing.Color.Black;
            btnCc.BorderSize = 0;
            btnCc.CornerRadius = 10;
            btnCc.FlatAppearance.BorderSize = 0;
            btnCc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            btnCc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCc.ForeColor = System.Drawing.Color.White;
            btnCc.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnCc.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnCc.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnCc.HoverColor2 = System.Drawing.Color.Navy;
            btnCc.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCc.IconColor = System.Drawing.Color.Black;
            btnCc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCc.IconSize = 24;
            btnCc.Location = new System.Drawing.Point(34, 82);
            btnCc.Name = "btnCc";
            btnCc.Size = new System.Drawing.Size(46, 23);
            btnCc.TabIndex = 17;
            btnCc.Text = "Cc";
            btnCc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnCc.UseVisualStyleBackColor = true;
            // 
            // btnBcc
            // 
            btnBcc.BackColor = System.Drawing.Color.Transparent;
            btnBcc.BorderColor = System.Drawing.Color.Black;
            btnBcc.BorderSize = 0;
            btnBcc.CornerRadius = 10;
            btnBcc.FlatAppearance.BorderSize = 0;
            btnBcc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            btnBcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBcc.ForeColor = System.Drawing.Color.White;
            btnBcc.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnBcc.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnBcc.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnBcc.HoverColor2 = System.Drawing.Color.Navy;
            btnBcc.IconChar = FontAwesome.Sharp.IconChar.None;
            btnBcc.IconColor = System.Drawing.Color.Black;
            btnBcc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBcc.IconSize = 24;
            btnBcc.Location = new System.Drawing.Point(34, 121);
            btnBcc.Name = "btnBcc";
            btnBcc.Size = new System.Drawing.Size(46, 23);
            btnBcc.TabIndex = 18;
            btnBcc.Text = "Bcc";
            btnBcc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnBcc.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(37, 160);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(35, 15);
            label2.TabIndex = 20;
            label2.Text = "Konu";
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // cmsColors
            // 
            cmsColors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { redItem, blueItem, yellowItem });
            cmsColors.Name = "cmsColors";
            cmsColors.Size = new System.Drawing.Size(68, 70);
            // 
            // redItem
            // 
            redItem.BackColor = System.Drawing.Color.Red;
            redItem.Name = "redItem";
            redItem.Size = new System.Drawing.Size(67, 22);
            redItem.Click += redItem_Click;
            // 
            // blueItem
            // 
            blueItem.BackColor = System.Drawing.Color.Blue;
            blueItem.Name = "blueItem";
            blueItem.Size = new System.Drawing.Size(67, 22);
            blueItem.Click += blueItem_Click;
            // 
            // yellowItem
            // 
            yellowItem.BackColor = System.Drawing.Color.Yellow;
            yellowItem.ForeColor = System.Drawing.SystemColors.ControlText;
            yellowItem.Name = "yellowItem";
            yellowItem.Size = new System.Drawing.Size(67, 22);
            yellowItem.Click += yellowItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { görüntüleToolStripMenuItem, ekleToolStripMenuItem, silToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(128, 70);
            // 
            // görüntüleToolStripMenuItem
            // 
            görüntüleToolStripMenuItem.Name = "görüntüleToolStripMenuItem";
            görüntüleToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            görüntüleToolStripMenuItem.Text = "Görüntüle";
            görüntüleToolStripMenuItem.Click += görüntüleToolStripMenuItem_Click;
            // 
            // ekleToolStripMenuItem
            // 
            ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            ekleToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            ekleToolStripMenuItem.Text = "Ekle";
            // 
            // silToolStripMenuItem
            // 
            silToolStripMenuItem.Name = "silToolStripMenuItem";
            silToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            silToolStripMenuItem.Text = "Sil";
            // 
            // btnAttach
            // 
            btnAttach.BackColor = System.Drawing.Color.Transparent;
            btnAttach.BorderColor = System.Drawing.Color.Black;
            btnAttach.BorderSize = 0;
            btnAttach.CornerRadius = 20;
            btnAttach.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAttach.FlatAppearance.BorderSize = 0;
            btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAttach.ForeColor = System.Drawing.Color.White;
            btnAttach.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnAttach.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnAttach.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnAttach.HoverColor2 = System.Drawing.Color.Navy;
            btnAttach.IconChar = FontAwesome.Sharp.IconChar.Paperclip;
            btnAttach.IconColor = System.Drawing.Color.Black;
            btnAttach.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAttach.IconSize = 24;
            btnAttach.Location = new System.Drawing.Point(5, 153);
            btnAttach.Name = "btnAttach";
            btnAttach.Size = new System.Drawing.Size(28, 28);
            btnAttach.TabIndex = 22;
            btnAttach.UseVisualStyleBackColor = false;
            btnAttach.Click += btnAttach_Click;
            // 
            // MailGonder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(1017, 782);
            Controls.Add(btnAttach);
            Controls.Add(label2);
            Controls.Add(btnBcc);
            Controls.Add(btnCc);
            Controls.Add(btnTo);
            Controls.Add(tbxKonu);
            Controls.Add(tbxMailBcc);
            Controls.Add(tbxMailCc);
            Controls.Add(tsMain);
            Controls.Add(toolStripContainer1);
            Controls.Add(tbxMailTo);
            Controls.Add(btnSendMail);
            Controls.Add(rtbBody);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "MailGonder";
            Text = "MailGonder";
            Load += MailGonder_Load;
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            cmsColors.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private System.Windows.Forms.RichTextBox rtbBody;
        private CustomControls.RoundedIconButton btnSendMail;
        private CustomControls.CustomTextBox tbxMailTo;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripButton tsbBold;
        private System.Windows.Forms.ToolStripButton tsbItalic;
        private CustomControls.CustomTextBox tbxMailCc;
        private System.Windows.Forms.ToolStripButton tsbUnderLine;
        private CustomControls.CustomTextBox tbxMailBcc;
        private System.Windows.Forms.ToolStripComboBox tscFontSize;
        private CustomControls.CustomTextBox tbxKonu;
        private CustomControls.RoundedIconButton btnTo;
        private CustomControls.RoundedIconButton btnCc;
        private CustomControls.RoundedIconButton btnBcc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripButton tsbForeColor;
        private System.Windows.Forms.ToolStripButton tsbBackcolor;
        private System.Windows.Forms.ContextMenuStrip cmsColors;
        private System.Windows.Forms.ToolStripMenuItem redItem;
        private System.Windows.Forms.ToolStripMenuItem blueItem;
        private System.Windows.Forms.ToolStripMenuItem yellowItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem görüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ekleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private CustomControls.RoundedIconButton btnAttach;
    }
}