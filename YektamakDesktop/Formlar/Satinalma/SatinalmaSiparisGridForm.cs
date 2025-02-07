using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaSiparisGridForm : Form, IForm, IGridForm<SatinalmaSiparis>
    {
        private static SatinalmaSiparisGridForm _satinalmaSiparisGridForm;
        public static SatinalmaSiparisGridForm satinalmaSiparisGridForm
        {
            get
            {
                if (_satinalmaSiparisGridForm == null)
                {
                    _satinalmaSiparisGridForm = new SatinalmaSiparisGridForm();
                    GlobalData.Yetki(ref _satinalmaSiparisGridForm);
                }
                return _satinalmaSiparisGridForm;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public List<SatisFatura> _satisFaturaList;
        public List<SatisFatura> satisFaturaList { get => _satisFaturaList; set => _satisFaturaList = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        /// <summary>
        /// dataSet ve grid içeriği aynı olmalı
        /// </summary>
        private DataSet _dataSet;
        public DataSet dataSet
        {
            get => _dataSet; set => _dataSet = value;
        }
        private DataTable _dataTable;
        private DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable = GlobalData.FillDataTable(WebMethods.GetFilteredSatinalmaSiparis, satinalmaSiparisFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }

        private ToolTip buttonFiltreToolTip;
        /// <summary>
        /// Form kontrollerinin ToolTip ayarlarını yapar
        /// </summary>
        public void SetToolTips()
        {
            buttonFiltreToolTip = new ToolTip();
            buttonFiltreToolTip.ToolTipTitle = "Satış Siparişleri Filtreleme";
            buttonFiltreToolTip.SetToolTip(buttonFiltre, "Sol taraftaki ifadeleri içeren filtrelenmiş sonuçları getirir");
            buttonFiltreToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonFiltreToolTip.AutoPopDelay = 20000;
        }
        public SatinalmaSiparisGridForm()
        {
            InitializeComponent();
            SetToolTips();
            controlsToDisable = new List<Control>();
            foreach (Control control in this.Controls)
            {
                if (control.Name != "panelHeader")
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
        /// Formu kapatır ve activeformstack listesinden siler. Form SatinalmaSiparisKayitFormu'ndan çağrılmış ise FaturaNo combolistini doldurur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rButtonCikis_Click(object sender, EventArgs e)
        {
            CloseForm();
        }


        public void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        public void AddNewRow(SatinalmaSiparis model)
        {
            dataTable.Rows.Add(
                satinalmaSiparisId,
                projeKod_projeKodId,
                projeKod_projeKodString,
                siparisTarihi,
                firma_id,
                firma_unvan,
                siparisAciklamasi,
                tutar_tutar,
                tutar_dovizCinsi_id,
                tutar_dovizCinsi_sembol,
                avans_tutar,
                avans_dovizCinsi_id,
                avans_dovizCinsi_sembol,
                termin,
                vade,
                satinalmaFatura_satinalmaFaturaId,
                satinalmaFatura_faturaNo,
                kdv_kdvId
                );
        }

        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, satinalmaSiparisFilter);
        }

        public void UpdateRowValues(SatinalmaSiparis satinalmaSiparis)
        {
            SatinalmaSiparisKayitFormuOld satinalmaSiparisKayitFormu = SatinalmaSiparisKayitFormuOld.satinalmaSiparisKayitFormu;
            if (satinalmaSiparisKayitFormu != null)
            {
                satinalmaSiparisKayitFormu.Show();
                satinalmaSiparisKayitFormu.UpdateMode(satinalmaSiparis);
            }
        }

        public void buttonEkle_Click(object sender, EventArgs e)
        {
            SatinalmaSiparisKayitFormu satinalmaSiparisKayitFormu = SatinalmaSiparisKayitFormu.satinalmaSiparisKayitFormu;
            if (satinalmaSiparisKayitFormu != null)
            {
                satinalmaSiparisKayitFormu.Show();
                satinalmaSiparisKayitFormu.SaveMode();
            }
        }

        public void CloseForm()
        {
            GlobalData.CloseForm(ref _satinalmaSiparisGridForm);
        }


        public void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalData.DataGridViewCellClick<SatinalmaSiparis>(ref _dataTable, dataGridView, e);
        }

        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, satinalmaSiparisFilter);
        }

        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, satinalmaSiparisFilter);
        }

        public void form_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridView, panelFilter);
        }

        public void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridView, panelFilter);
        }

        int oldScrollOffset = 0;
        public void dataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            GlobalData.AdjustControlsOnScroll(dataGridView, panelFilter, e, ref oldScrollOffset);
        }

        public void UpdateRow(SatinalmaSiparis satinalmaSiparis)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, satinalmaSiparis.satinalmaSiparisId);
            if (i == -1)
            {
                AddNewRow(satinalmaSiparis);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, satinalmaSiparis, i);
            }
        }

        public SatinalmaSiparis satinalmaSiparisFilter
        {
            get
            {
                return GlobalData.GridFilter<SatinalmaSiparis>(panelFilter);
            }
        }
    }
}