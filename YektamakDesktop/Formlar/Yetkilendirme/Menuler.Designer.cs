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

        public class DataControlMenu : Abstracts.DataControl, IEntity
        {
            private Menu _menu;
            private Menu menu
            {
                get
                {
                    if (_menu == null)
                    {
                        _menu = new Menu();
                    }
                    return _menu;
                }
                set
                {
                    _menu = value;
                    newRec = false;
                    Binding();
                }
            }
            private readonly IKullaniciYetkiService _kullaniciYetkiService;
            public DataControlMenu(IKullaniciYetkiService kullaniciYetkiService)
            {
                _kullaniciYetkiService = kullaniciYetkiService;
                Initialize();
                Binding();
            }
            public DataControlMenu(Menu menuCon)
            {
                Initialize();
                menu = menuCon;
                Binding();
            }
            public DataControlMenu()
            {
                Initialize();
                Binding();
            }
            private void Binding()
            {
                menuId.DataBindings.Clear();
                menuAdi.DataBindings.Clear();
                formAdi.DataBindings.Clear();
                icon.DataBindings.Clear();
                menuId.DataBindings.Add("TextCustom", menu, $"{nameof(menu.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
                menuAdi.DataBindings.Add("TextCustom", menu, $"{nameof(menu.ad)}", true, DataSourceUpdateMode.OnPropertyChanged);
                formAdi.DataBindings.Add("TextCustom", menu, $"{nameof(menu.formAd)}", true, DataSourceUpdateMode.OnPropertyChanged);
                icon.DataBindings.Add("TextCustom", menu, $"{nameof(menu.icon)}", true, DataSourceUpdateMode.OnPropertyChanged);
            }
            private void Initialize()
            {
                menuId = new() { TabIndex = 1, Width = 0, Visible = true, Tag = "Id" };
                menuAdi = new() { TabIndex = 2, Width = 200, Tag = "Menu Adı" };
                formAdi = new() { TabIndex = 3, Width = 200, Tag = "Form Adı" };
                icon = new() { TabIndex = 4, Width = 100, Tag = "İkon" };
                iconButton = new() { TabIndex = 5, Width = 35, Height = 28, Tag = "Güncelle", 
                    BackgroundImage = Resources.data_update_icon, BackColor = Color.Transparent, 
                    BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom, CornerRadius = 5 };
                buttonSil.Click += ButtonSil_Click;
                iconButton.Click += IconButton_Click;
            }

            public CustomTextBox menuId { get; set; }
            public CustomTextBox menuAdi { get; set; }
            public CustomTextBox formAdi { get; set; }
            public CustomTextBox icon { get; set; }
            public RoundedIconButton iconButton { get; set; }
            private void IconButton_Click(object sender, EventArgs e)
            {
                EkranEkle ekranEkle = FormFactory.CreateForm<EkranEkle>();
                ekranEkle.UpdateMode(menu);
                ekranEkle.Show();
            }

            private async void ButtonSil_Click(object sender, EventArgs e)
            {
                if(menuId.TextCustom!="")menu.Id = Convert.ToInt32(menuId.TextCustom.Replace(".",""));
                await DIContainer.GetService<Menuler>()._kullaniciYetkiService.DeleteMenu(menu);
            }
        }
        private IconButton iconButtonAdd;
        private HeaderPanel headerPanel1;
    }
}