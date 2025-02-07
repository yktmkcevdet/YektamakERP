using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class KasaTanimlariGridForm : Form, IForm,IGridForm<Kasa>
    {
        
        
        #region declarations
        private static KasaTanimlariGridForm _kasaTanimlariGridForm;
        public static KasaTanimlariGridForm kasaTanimlariGridForm
        {
            get
            {
                if (_kasaTanimlariGridForm == null)
                {
                    _kasaTanimlariGridForm = new KasaTanimlariGridForm();
                    GlobalData.Yetki(ref _kasaTanimlariGridForm);
                }
                return _kasaTanimlariGridForm;
            }
        }

        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private DataTable _dataTable;
        public DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable = GlobalData.FillDataTable(WebMethods.GetFilteredKasa, kasaFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }
        ToolTip buttonFiltreToolTip;
        #endregion declarations
        public KasaTanimlariGridForm()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>();
            SetToolTips();

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

        /// <summary>
        /// Form kontrollerinin ToolTip ayarlarını yapar
        /// </summary>
        public void SetToolTips()
        {
            buttonFiltreToolTip = new ToolTip();
            buttonFiltreToolTip.ToolTipTitle = "Kasa Filtreleme";
            buttonFiltreToolTip.SetToolTip(buttonFiltre, "Sol taraftaki ifadeleri içeren filtrelenmiş sonuçları getirir");
            buttonFiltreToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonFiltreToolTip.AutoPopDelay = 20000;
        }

        public void UpdateRow(Kasa kasa)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, kasa.kasaId);
            if (i == -1)
            {
                AddNewRow(kasa);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, kasa, i);
            }
        }

        public void AddNewRow(Kasa kasa)
        {
            dataTable.Rows.Add(
                kasa.kasaId,
                kasa.kasaAdi,
                kasa.bakiye.tutar,
                kasa.bakiye.dovizCinsi.id,
                kasa.bakiye.dovizCinsi.sembol,
                kasa.kasaTuru,
                kasa.bankaHesabi.hesapId,
                kasa.bankaHesabi.hesapAdi
                );
        }

        public void form_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridView, panelFilter);
        }

        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, kasaFilter);
        }

        public void buttonEkle_Click(object sender, EventArgs e)
        {
            KasaKayitFormu kasaKayitFormu= KasaKayitFormu.kasaKayitFormu;
            if (kasaKayitFormu != null)
            {
                kasaKayitFormu.Show();
                kasaKayitFormu.SaveMode();
            }
        }

        public void CloseForm()
        {
            GlobalData.CloseForm(ref _kasaTanimlariGridForm);
        }

        public void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalData.DataGridViewCellClick<Kasa>(ref _dataTable, dataGridView, e);
        }

        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, kasaFilter);
        }

        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, kasaFilter);
        }

        public void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridView, panelFilter);
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
            GlobalData.AdjustControlsOnScroll(dataGridView, panelFilter, e, ref oldScrollOffset);
        }

        public Kasa kasaFilter
        {
            get
            {
                return GlobalData.GridFilter<Kasa>(panelFilter);
            }
        }
    }
}
