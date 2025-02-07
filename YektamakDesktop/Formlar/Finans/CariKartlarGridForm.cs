using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace YektamakDesktop.Formlar.Finans
{
    public partial class CariKartlarGridForm : Form, IForm,IGridForm<CariKart>
    {

        #region declarations
        private static CariKartlarGridForm _cariKartlarGridForm;
        public static CariKartlarGridForm cariKartlarGridForm
        {
            get
            {
                if (_cariKartlarGridForm == null)
                {
                    _cariKartlarGridForm = new CariKartlarGridForm();
                    GlobalData.Yetki(ref _cariKartlarGridForm);
                }
                return _cariKartlarGridForm;
            }
        }
        private DataTable _dataTable;
        private DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable = GlobalData.FillDataTable(WebMethods.GetFilteredCariKartlar, cariKartFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }
        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        #endregion declarations
        public CariKartlarGridForm()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>()
            {
                rButtonKapat,
                buttonCariKartEkle,
                buttonTumKayitlariGetir,
                roundedIconButton2,
                buttonTumKayitlariGetir,
                dataGridViewCariKartlar
            };
        }
        #region mouseDrag
        bool mouseDown;
        private Point offset;
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
        public void AddNewRow(CariKart cariKart)
        {
            dataTable.Rows.Add(
                cariKart.cariKartId,
                cariKart.cariAdi,
                cariKart.cari.cariTuru,
                cariKart.cari.Id,
                cariKart.guncelCari.tutar,
                cariKart.guncelCari.dovizCinsi.id,
                cariKart.guncelCari.dovizCinsi.sembol
                );
        }
        public void UpdateRow(CariKart cariKart)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, cariKart.cariKartId);
            if (i == -1)
            {
                AddNewRow(cariKart);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, cariKart, i);
            }
        }
        
        private CariKart cariKartFilter
        {
            get
            {
                return GlobalData.GridFilter<CariKart>(panelFilter);
            }
        }
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewCariKartlar, cariKartFilter);
        }
        public void CloseForm()
        {
            GlobalData.CloseForm(ref _cariKartlarGridForm);
        }

        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewCariKartlar, cariKartFilter);
        }


        public void form_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridViewCariKartlar, panelFilter);
        }

        

        public void buttonEkle_Click(object sender, EventArgs e)
        {
            CariKartKayitFormu cariKartKayitFormu = CariKartKayitFormu.cariKartKayitFormu;
            if (cariKartKayitFormu != null)
            {
                cariKartKayitFormu.Show();
                cariKartKayitFormu.SaveMode();
            }
        }

        public void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalData.DataGridViewCellClick<CariKart>(ref _dataTable, dataGridViewCariKartlar, e);
        }

        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewCariKartlar, cariKartFilter);
        }

        public void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridViewCariKartlar, panelFilter);
        }

        public void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        public void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        int oldScrollOffset = 0;
        public void dataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            GlobalData.AdjustControlsOnScroll(dataGridViewCariKartlar, panelFilter, e, ref oldScrollOffset);
        }
    }
}
