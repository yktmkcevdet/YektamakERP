using YektamakDesktop.CustomControls;
using YektamakDesktop.Properties;
using FontAwesome.Sharp;
using Models;
using ApiService;
using System;
using System.Drawing;
using System.Windows.Forms;
using ApiService.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    partial class Menuler
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
            iconButtonAdd = new IconButton();
            headerPanel1 = new HeaderPanel();
            SuspendLayout();
            // 
            // iconButtonAdd
            // 
            iconButtonAdd.AutoEllipsis = true;
            iconButtonAdd.BackColor = SystemColors.ActiveCaption;
            iconButtonAdd.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
            iconButtonAdd.FlatAppearance.BorderSize = 5;
            iconButtonAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            iconButtonAdd.FlatAppearance.MouseOverBackColor = Color.Yellow;
            iconButtonAdd.FlatStyle = FlatStyle.Popup;
            iconButtonAdd.ForeColor = Color.FromArgb(192, 0, 192);
            iconButtonAdd.IconChar = IconChar.Plus;
            iconButtonAdd.IconColor = Color.OliveDrab;
            iconButtonAdd.IconFont = IconFont.Auto;
            iconButtonAdd.IconSize = 20;
            iconButtonAdd.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonAdd.Location = new Point(549, 56);
            iconButtonAdd.Name = "iconButtonAdd";
            iconButtonAdd.Size = new Size(57, 29);
            iconButtonAdd.TabIndex = 0;
            iconButtonAdd.Text = "EKLE";
            iconButtonAdd.TextAlign = ContentAlignment.MiddleRight;
            iconButtonAdd.UseVisualStyleBackColor = false;
            iconButtonAdd.Click += iconButtonAdd_Click;
            // 
            // headerPanel1
            // 
            headerPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = Color.Firebrick;
            headerPanel1.Baslik = "Menu Tanımlama";
            headerPanel1.Location = new Point(0, 0);
            headerPanel1.Margin = new Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new Padding(1);
            headerPanel1.Size = new Size(798, 25);
            headerPanel1.TabIndex = 1;
            // 
            // Menuler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 592);
            Controls.Add(headerPanel1);
            Controls.Add(iconButtonAdd);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menuler";
            Text = "Menuler";
            Load += Menuler_Load;
            ResumeLayout(false);
        }

        #endregion

        
        private IconButton iconButtonAdd;
        public HeaderPanel headerPanel1;
    }
}