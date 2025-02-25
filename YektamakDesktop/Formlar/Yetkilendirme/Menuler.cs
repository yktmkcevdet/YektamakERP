using ApiService;
using ApiService.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class Menuler : Form
    {
        private static ICache _cache;
        private static IDataTableHelper _dataTableHelper;
        private static IJsonConvertHelper _jsonConvertHelper;
        private static Menuler _menuler;
        public static Menuler menuler { get { if (_menuler == null) { _menuler = new(); GlobalData.Yetki(ref _menuler); } return _menuler; } set { _menuler = value; } }
        
        CustomDataGrid<DataControlMenu> customDataGrid;
        private bool mouseDown;
        private Point offset;
        public Menuler()
        {
            InitializeComponent();
            customDataGrid = new CustomDataGrid<DataControlMenu>(2, 30, new Point(10, 100), new Size(650, 300));
            this.Controls.Add(customDataGrid.headerPanel);
            this.Controls.Add(customDataGrid.detailPanel);
        }
        public Menuler(ICache cache, IDataTableHelper dataTableHelper, IJsonConvertHelper jsonConvertHelper)
        {
            _cache = cache;
            _dataTableHelper = dataTableHelper;
            _jsonConvertHelper = jsonConvertHelper;
        }

        #region mouseDrag
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreepPos = PointToScreen(e.Location);
                Location = new Point(currentScreepPos.X - offset.X, currentScreepPos.Y - offset.Y);
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion mouseDrag
        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            this.Close();
            menuler = null;
            GlobalData.RemoveLastForm();
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Menuler_Load(object sender, EventArgs e)
        {
            DataSet dataSet = _jsonConvertHelper.JsonStringToDataSet(WebMethods.GetMenu());
            List<DataControlMenu> menuList = new List<DataControlMenu>();

            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                DataControlMenu menu = new DataControlMenu();
                menu.menuAdi.TextCustom = dataRow["ad"].ToString();
                menu.menuId.TextCustom = dataRow["Id"].ToString();
                menu.formAdi.TextCustom = dataRow["formAdi"].ToString();
                menu.icon.TextCustom = dataRow["icon"].ToString();
                menuList.Add(menu);
                menu.newRec = false;
            }
            customDataGrid.dataSource = menuList;
        }

        private void iconButtonAdd_Click(object sender, EventArgs e)
        {
            EkranEkle.menu = null;
            EkranEkle ekranEkle = EkranEkle.ekranEkle;
            if (ekranEkle != null)
            {
                ekranEkle.Show();
            }
        }
    }
}
