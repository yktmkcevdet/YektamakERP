using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Properties;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class Menuler : Form
    {
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        
        CustomDataGrid<DataControlMenu> customDataGrid;
        private Point offset;
       
        public Menuler(IKullaniciYetkiService kullaniciYetkiService)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
            InitializeComponent();
            var dataC=new DataControlMenu(new Menu());
            customDataGrid = new CustomDataGrid<DataControlMenu>(2, 30, new Point(10, 100), new Size(650, 300));
            this.Controls.Add(customDataGrid.headerPanel);
            this.Controls.Add(customDataGrid.detailPanel);
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Menuler_Load(object sender, EventArgs e)
        {
            string jsonResult = _kullaniciYetkiService.GetMenu(new Menu());
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Menüler yüklenemedi: " + jsonResult, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<Menu> menuList = JsonConvert.DeserializeObject<List<Menu>>(jsonResult);

            List<DataControlMenu> dataControlMenus = new List<DataControlMenu>();
            foreach (var menu in menuList)
            {
                DataControlMenu dataControlMenu = new DataControlMenu(menu);
                dataControlMenus.Add(dataControlMenu);
            }
            customDataGrid.dataSource = dataControlMenus;
        }

        private void iconButtonAdd_Click(object sender, EventArgs e)
        {
            EkranEkle ekranEkle = FormFactory.CreateForm<EkranEkle>();
            ekranEkle.Show();
        }
    }
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
        }
        public DataControlMenu(Menu menuCon)
        {
            Initialize();
            menu = menuCon;
        }
        private void Binding()
        {
            BindHelper.BindData(menuId, menu, nameof(menu.Id));
            BindHelper.BindData(menuAdi, menu, nameof(menu.ad));
            BindHelper.BindData(formAdi, menu, nameof(menu.formAd));
            BindHelper.BindData(icon, menu, nameof(menu.icon));
        }
        private void Initialize()
        {
            menuId = new() { TabIndex = 1, Width = 0, Visible = true, Tag = "Id" };
            menuAdi = new() { TabIndex = 2, Width = 200, Tag = "Menu Adı" };
            formAdi = new() { TabIndex = 3, Width = 200, Tag = "Form Adı" };
            icon = new() { TabIndex = 4, Width = 100, Tag = "İkon" };
            iconButton = new()
            {
                TabIndex = 5,
                Width = 35,
                Height = 28,
                Tag = "Güncelle",
                BackgroundImage = Resources.data_update_icon,
                BackColor = Color.Transparent,
                BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom,
                CornerRadius = 5
            };
            buttonSil.Click += ButtonSil_Click;
            iconButton.Click += IconButton_Click;
            Binding();
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
            if (menuId.TextCustom != "") menu.Id = Convert.ToInt32(menuId.TextCustom.Replace(".", ""));
            await _kullaniciYetkiService.DeleteMenu(menu);
        }
    }
}
