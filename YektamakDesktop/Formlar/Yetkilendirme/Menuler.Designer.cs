using YektamakDesktop.CustomControls;
using YektamakDesktop.Properties;
using FontAwesome.Sharp;
using Models;
using ApiService;
using System;
using System.Drawing;
using System.Windows.Forms;

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
            panelHeader = new Panel();
            buttonClose = new RoundedButton();
            buttonHelp = new RoundedButton();
            buttomMinimize = new RoundedButton();
            labelHeader = new Label();
            iconButtonAdd = new IconButton();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Red;
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(798, 38);
            panelHeader.TabIndex = 2;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.Red;
            buttonClose.BackgroundColor = Color.Red;
            buttonClose.BorderColor = Color.LavenderBlush;
            buttonClose.BorderRadius = 30;
            buttonClose.BorderSize = 2;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClose.ForeColor = Color.White;
            buttonClose.Location = new Point(757, 5);
            buttonClose.Margin = new Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new Padding(3, 0, 0, 0);
            buttonClose.Size = new Size(30, 30);
            buttonClose.TabIndex = 106;
            buttonClose.Text = "x";
            buttonClose.TextColor = Color.White;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.BackColor = Color.Red;
            buttonHelp.BackgroundColor = Color.Red;
            buttonHelp.BorderColor = Color.LavenderBlush;
            buttonHelp.BorderRadius = 30;
            buttonHelp.BorderSize = 2;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = FlatStyle.Flat;
            buttonHelp.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonHelp.ForeColor = Color.White;
            buttonHelp.Location = new Point(689, 5);
            buttonHelp.Margin = new Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new Padding(3, 0, 0, 0);
            buttonHelp.Size = new Size(30, 30);
            buttonHelp.TabIndex = 105;
            buttonHelp.Text = "?";
            buttonHelp.TextColor = Color.White;
            buttonHelp.UseVisualStyleBackColor = false;
            // 
            // buttomMinimize
            // 
            buttomMinimize.BackColor = Color.Red;
            buttomMinimize.BackgroundColor = Color.Red;
            buttomMinimize.BorderColor = Color.LavenderBlush;
            buttomMinimize.BorderRadius = 30;
            buttomMinimize.BorderSize = 2;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = FlatStyle.Flat;
            buttomMinimize.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttomMinimize.ForeColor = Color.White;
            buttomMinimize.Location = new Point(723, 5);
            buttomMinimize.Margin = new Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new Padding(3, 0, 0, 0);
            buttomMinimize.Size = new Size(30, 30);
            buttomMinimize.TabIndex = 104;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = Color.Red;
            labelHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeader.ForeColor = SystemColors.ControlLightLight;
            labelHeader.Location = new Point(40, 8);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(74, 21);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Menuler";
            labelHeader.TextAlign = ContentAlignment.MiddleLeft;
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
            iconButtonAdd.IconChar = IconChar.Add;
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
            // Menuler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 592);
            Controls.Add(iconButtonAdd);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menuler";
            Text = "Menuler";
            Load += Menuler_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public class DataControlMenu : Abstracts.DataControl, IEntity
        {
            private WebMethods _webMethods;
            private CustomTextBox _menuId;
            public CustomTextBox menuId { get { if (_menuId == null) _menuId = new(); return _menuId; } set { _menuId = value; } }
            private CustomTextBox _menuAdi;
            public CustomTextBox menuAdi { get { if (_menuAdi == null) _menuAdi = new(); return _menuAdi; } set { _menuAdi = value; } }
            private CustomTextBox _formAdi;
            public CustomTextBox formAdi 
            { 
                get 
                { 
                    if (_formAdi == null) _formAdi = new(); 
                    return _formAdi; 
                } 
                set 
                { 
                    _formAdi = value; 
                } 
            }

            private CustomTextBox _icon;
            public CustomTextBox icon 
            {
                get
                {
                    if (_icon == null)
                    {
                        _icon = new(); 
                    }
                    return _icon;
                }
                set
                {
                    _icon = value;
                } 
            }
            private RoundedButton _iconButton;
            public RoundedButton iconButton
            {
                get
                {
                    if(_iconButton == null)
                    {
                        _iconButton=new();
                    }
                    return _iconButton;
                }
                set
                {
                    _iconButton = value;
                }
            }
            public DataControlMenu()
            {
                menuId = new() { TabIndex=1,Width=0, Visible=false,Tag="Id"};
                menuAdi = new() { TabIndex = 2,Width = 200, Tag="Menu Adı" };
                formAdi = new() { TabIndex = 3,Width = 200, Tag="Form Adı" };
                icon = new() { TabIndex = 4, Width = 100, Tag = "İkon" };
                iconButton = new() { TabIndex = 5, Width = 35,Height=28, Tag = "Güncelle",BackgroundImage=Resources.update_icon,BackColor=Color.Transparent, BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom };
                buttonSil.Click += ButtonSil_Click;
                iconButton.Click += IconButton_Click;
            }

            public DataControlMenu(WebMethods webMethods)
            {
                _webMethods = webMethods;
            }

            private void IconButton_Click(object sender, EventArgs e)
            {
                Menu menu = new();
                menu.ad= menuAdi.TextCustom;
                menu.formAdi=formAdi.TextCustom;
                menu.Id=Convert.ToInt32(menuId.TextCustom);
                menu.icon=icon.TextCustom;
                EkranEkle.menu = menu;
                EkranEkle ekranEkle = EkranEkle.ekranEkle;
                ekranEkle.Show();
            }

            private async void ButtonSil_Click(object sender, EventArgs e)
            {
                Menu menu = new();
                menu.Id = Convert.ToInt32(menuId.TextCustom.Replace(".",""));
                await _webMethods.DeleteMenu(menu);
            }
        }

        private System.Windows.Forms.Panel panelHeader;
        private RoundedButton buttonClose;
        private RoundedButton buttonHelp;
        private RoundedButton buttomMinimize;
        private System.Windows.Forms.Label labelHeader;
        private IconButton iconButtonAdd;


    }
}