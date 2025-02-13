using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Satinalma;
using YektamakDesktop.Formlar.Satinalma.DataControl;
using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class Menuler : Form
    {
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
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            DataSet dataSet = jsonConverter.JsonStringToDataSet(WebMethods.GetMenu());
            List<DataControlMenu> menuList = new List<DataControlMenu>();

            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                IDataTableHelper dataTableConverter = new DataTableHelper();
                DataRow dataRow = dataSet.Tables[0].Rows[i];
                menuList.Add(dataTableConverter.DataRowToModel<DataControlMenu>(dataRow));
                menuList[i].newRec = false;
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
