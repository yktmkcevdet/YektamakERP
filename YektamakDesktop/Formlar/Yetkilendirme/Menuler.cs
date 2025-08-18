using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class Menuler : Form
    {
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        
        CustomDataGrid<DataControlMenu> customDataGrid;
        private Point offset;
        public Menuler()
        {
            
        }
        public Menuler(IKullaniciYetkiService kullaniciYetkiService)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
            InitializeComponent();
            var dataC=new DataControlMenu(new Menu());
            customDataGrid = new CustomDataGrid<DataControlMenu>(2, 30, new Point(10, 100), new Size(650, 300), dataC);
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
}
