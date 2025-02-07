using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using YektamakDesktop.Formlar.Ortak;
using YektamakDesktop.CustomControls;
using System.Linq;
using System.Windows.Media.Animation;
using System.Reflection;
using YektamakDesktop.Formlar.Genel;
using YektamakDesktop.Formlar.Finans;
using ApiService;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class SatisProjeGridForm : Form, IForm, IGridForm<SatisProje>
    {
        private static SatisProjeGridForm _satisProjeGridForm;
        public static SatisProjeGridForm satisProjeGridForm
        {
            get
            {
                if (_satisProjeGridForm == null)
                {
                    _satisProjeGridForm = new SatisProjeGridForm();
                    GlobalData.Yetki(ref _satisProjeGridForm);
                }
                return _satisProjeGridForm;
            }
        }



        #region Controls and Properties

        private List<Control> _controlsToDisable;

        public List<Control> controlsToDisable
        {
            get => _controlsToDisable;
            set => _controlsToDisable = value;
        }

        private bool _activeForm;

        public bool activeForm
        {
            get => _activeForm;
            set => _activeForm = value;
        }

        private DataTable _dataTable;

        private DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable=GlobalData.FillDataTable(WebMethods.GetFilteredSatisProje,satisProjeFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }

        #endregion
        public SatisProjeGridForm()
        {
            InitializeComponent();
            SetToolTips();
            _controlsToDisable = new List<Control>
            {
                buttonFiltre,
                buttonEkle,
                buttonTumKayitlariGetir,
                dataGridViewProje,
                rButtonCikis,
            };

        }
        #region ToolTip

        private ToolTip buttonFiltreToolTip;

        #endregion

        #region MouseDrag
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
        #endregion MouseDrag

        /// <summary>
        /// Form kontrollerinin ToolTip ayarlarını yapar
        /// </summary>
        public void SetToolTips()
        {
            buttonFiltreToolTip = new ToolTip();
            buttonFiltreToolTip.ToolTipTitle = "Proje Filtreleme";
            buttonFiltreToolTip.SetToolTip(buttonFiltre, "Sol taraftaki ifadeleri içeren filtrelenmiş sonuçları getirir");
            buttonFiltreToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonFiltreToolTip.AutoPopDelay = 20000;
        }

        
        
        public SatisProje satisProjeFilter
        {
            get
            {
                return GlobalData.GridFilter<SatisProje>(panelFilter);
            }
        }
        
        

        public void AddNewRow(SatisProje satisProje)
        {
            dataTable.Rows.Add(
                satisProje.projeId,
                satisProje.projeAd,
                satisProje.projeAciklama,
                satisProje.musteri.id,
                satisProje.musteri.unvan,
                satisProje.projeKod.Id,
                satisProje.projeKod.no,
                satisProje.projeKod.marka.markaId,
                satisProje.projeKod.marka.markaAltGrup.altGrupId,
                satisProje.satisSorumlusu.Id,
                satisProje.projeKod.kod);
        }
        public void UpdateRow(SatisProje satisProje)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, satisProje.projeId);
            if(i == -1)
            {
                AddNewRow(satisProje);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, satisProje, i);
            }
        }

        public void form_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridViewProje, panelFilter);
        }

        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewProje, satisProjeFilter);
        }

        public void buttonEkle_Click(object sender, EventArgs e)
        {
            SatisProjeKayitFormu satisProjeKayitFormu = SatisProjeKayitFormu.satisProjeKayitFormu;
            if (satisProjeKayitFormu != null)
            {
                satisProjeKayitFormu.Show();
                satisProjeKayitFormu.SaveMode();
            }
        }

        public void CloseForm()
        {
            GlobalData.CloseForm(ref _satisProjeGridForm);
        }

        public void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalData.DataGridViewCellClick<SatisProje>(ref _dataTable, dataGridViewProje, e);
        }

        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewProje, satisProjeFilter);
        }

        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewProje, satisProjeFilter);
        }

        public void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridViewProje, panelFilter);
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
            GlobalData.AdjustControlsOnScroll(dataGridViewProje, panelFilter, e, ref oldScrollOffset);
        }
    }
}