using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YektamakDesktop.Formlar.Projemodul
{
    public partial class ProjeBelgeRedSebep
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
        private void InitializeComponent()
        {
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            ctbRedSebep = new YektamakDesktop.CustomControls.CustomTextBox();
            label1 = new System.Windows.Forms.Label();
            btnOk = new YektamakDesktop.CustomControls.RoundedButton();
            customTextBox2 = new YektamakDesktop.CustomControls.CustomTextBox();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Red Sebebi";
            headerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(582, 25);
            headerPanel1.TabIndex = 0;
            // 
            // ctbRedSebep
            // 
            ctbRedSebep.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ctbRedSebep.BackColor = System.Drawing.Color.White;
            ctbRedSebep.BorderColor = System.Drawing.Color.Silver;
            ctbRedSebep.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbRedSebep.BorderSize = 1;
            ctbRedSebep.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbRedSebep.ForeColor = System.Drawing.Color.Black;
            ctbRedSebep.Location = new System.Drawing.Point(134, 69);
            ctbRedSebep.Margin = new System.Windows.Forms.Padding(1);
            ctbRedSebep.Multiline = true;
            ctbRedSebep.Name = "ctbRedSebep";
            ctbRedSebep.Padding = new System.Windows.Forms.Padding(3);
            ctbRedSebep.PasswordChar = false;
            ctbRedSebep.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbRedSebep.PlaceholderText = "";
            ctbRedSebep.ReadOnly = false;
            ctbRedSebep.SelectionStart = 0;
            ctbRedSebep.Size = new System.Drawing.Size(417, 110);
            ctbRedSebep.TabIndex = 1;
            ctbRedSebep.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbRedSebep.TextCustom = "";
            ctbRedSebep.UnderlinedStyle = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(12, 69);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(110, 15);
            label1.TabIndex = 2;
            label1.Text = "Red Sebebini Girin";
            // 
            // btnOk
            // 
            btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnOk.BackgroundColor = System.Drawing.Color.Firebrick;
            btnOk.BorderColor = System.Drawing.Color.Black;
            btnOk.BorderSize = 0;
            btnOk.CornerRadius = 10;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnOk.ForeColor = System.Drawing.Color.White;
            btnOk.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnOk.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnOk.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnOk.HoverColor2 = System.Drawing.Color.Navy;
            btnOk.Icon = null;
            btnOk.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnOk.Location = new System.Drawing.Point(465, 230);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(86, 40);
            btnOk.TabIndex = 3;
            btnOk.Text = "GÖNDER";
            btnOk.TextColor = System.Drawing.Color.White;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // customTextBox2
            // 
            customTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            customTextBox2.BackColor = System.Drawing.Color.White;
            customTextBox2.BorderColor = System.Drawing.Color.Silver;
            customTextBox2.BorderFocusColor = System.Drawing.Color.HotPink;
            customTextBox2.BorderSize = 1;
            customTextBox2.Font = new System.Drawing.Font("Segoe UI", 8F);
            customTextBox2.ForeColor = System.Drawing.Color.Black;
            customTextBox2.Location = new System.Drawing.Point(134, 42);
            customTextBox2.Margin = new System.Windows.Forms.Padding(1);
            customTextBox2.Multiline = false;
            customTextBox2.Name = "customTextBox2";
            customTextBox2.Padding = new System.Windows.Forms.Padding(3);
            customTextBox2.PasswordChar = false;
            customTextBox2.PlaceholderColor = System.Drawing.Color.DarkGray;
            customTextBox2.PlaceholderText = "";
            customTextBox2.ReadOnly = false;
            customTextBox2.SelectionStart = 0;
            customTextBox2.Size = new System.Drawing.Size(416, 25);
            customTextBox2.TabIndex = 4;
            customTextBox2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            customTextBox2.TextCustom = "";
            customTextBox2.UnderlinedStyle = false;
            // 
            // ProjeBelgeRedSebep
            // 
            ClientSize = new System.Drawing.Size(582, 301);
            Controls.Add(customTextBox2);
            Controls.Add(btnOk);
            Controls.Add(label1);
            Controls.Add(ctbRedSebep);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ProjeBelgeRedSebep";
            ResumeLayout(false);
            PerformLayout();

        }
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBox ctbRedSebep;
        private System.Windows.Forms.Label label1;
        private CustomControls.RoundedButton btnOk;
        private CustomControls.CustomTextBox customTextBox2;
    }
}
