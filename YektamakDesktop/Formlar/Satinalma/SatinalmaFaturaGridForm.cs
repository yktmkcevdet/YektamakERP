using YektamakDesktop.Formlar.Satinalma;
using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class SatinalmaFaturaGridForm : Form, IForm, IGridForm<SatinalmaFatura>
    {

        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private ToolTip buttonFiltreToolTip;
        private DataTable _dataTable;
        private DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable = GlobalData.FillDataTable(WebMethods.GetFilteredSatinalmaFatura, satinalmaFaturaFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }
        private static SatinalmaFaturaGridForm _satinalmaFaturaGridForm;
        public static SatinalmaFaturaGridForm satinalmaFaturaGridForm
        {
            get
            {
                if (_satinalmaFaturaGridForm == null)
                {
                    _satinalmaFaturaGridForm = new SatinalmaFaturaGridForm();
                    GlobalData.Yetki(ref _satinalmaFaturaGridForm);
                }
                return _satinalmaFaturaGridForm;
            }
        }
        /// <summary>
        /// Satınalma grid formunun yapıcı nesnesidir. Form nesnelerini oluşturur.
        /// </summary>
        public SatinalmaFaturaGridForm()
        {
            InitializeComponent();
            SetToolTips();
            controlsToDisable = new List<Control>();
            foreach (Control control in this.Controls)
            {
                if (control.Name != "panelHeader")//panelheader hariç diğer nesneleri disable edilecek nesneler içine ekler.
                {
                    controlsToDisable.Add(control);
                }
            }
        }
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
            buttonFiltreToolTip.ToolTipTitle = "Satınalma Faturaları Filtreleme";
            buttonFiltreToolTip.SetToolTip(buttonFiltre, "Sol taraftaki ifadeleri içeren filtrelenmiş sonuçları getirir");
            buttonFiltreToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonFiltreToolTip.AutoPopDelay = 20000;
        }

        /// <summary>
        /// Grid üzerinde update ve delete hücrelerine tıklatıldığında ilgili işlevi gerçekleştirir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalData.DataGridViewCellClick<SatinalmaFatura>(ref _dataTable, dataGridViewSatinalmaFatura, e);
        }
        
        private SatinalmaFatura satinalmaFaturaFilter
        {
            get
            {
                return GlobalData.GridFilter<SatinalmaFatura>(panelFilter);
            }
        }
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewSatinalmaFatura, satinalmaFaturaFilter);
        }

        public void rButtonCikis_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewSatinalmaFatura, satinalmaFaturaFilter);
        }
        public void SatinalmaFaturaGridForm_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridViewSatinalmaFatura, panelFilter);
        }

        public void dataGridViewSatinalmaFatura_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridViewSatinalmaFatura, panelFilter);
        }

        public void buttonEkle_Click(object sender, EventArgs e)
        {
            SatinalmaFaturaKayitFormu satinalmaFaturaKayitFormu = SatinalmaFaturaKayitFormu.satinalmaFaturaKayitFormu;
            satinalmaFaturaKayitFormu.Show();
            satinalmaFaturaKayitFormu.SaveMode();
        }

        public void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        public void CloseForm()
        {
            GlobalData.CloseForm(ref _satinalmaFaturaGridForm);
        }

        public void buttomMinimize_Click(object sender, EventArgs e)
        {
            satinalmaFaturaGridForm.WindowState = FormWindowState.Minimized;
        }

        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewSatinalmaFatura, satinalmaFaturaFilter);
        }

        public void UpdateRow(SatinalmaFatura satinalmaFatura)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, satinalmaFatura.satinalmaFaturaId);
            if (i == -1)
            {
                AddNewRow(satinalmaFatura);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, satinalmaFatura, i);
            }
        }

        public void AddNewRow(SatinalmaFatura model)
        {
            dataTable.Rows.Add(
                );
        }

        public void form_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridViewSatinalmaFatura, panelFilter);
        }

        public void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridViewSatinalmaFatura, panelFilter);
        }
        int oldScrollOffset = 0;
        public void dataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            GlobalData.AdjustControlsOnScroll(dataGridViewSatinalmaFatura, panelFilter, e, ref oldScrollOffset);
        }
    }
}

