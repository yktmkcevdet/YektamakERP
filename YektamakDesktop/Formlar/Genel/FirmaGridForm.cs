using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using ApiService.Interfaces;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class FirmaGridForm : Form
    {
        private readonly IDataGridHelper _dataGridHelper; 
        private readonly IFirmaService _firmaService;
        public FirmaGridForm(IDataGridHelper dataGridHelper, IFirmaService firmaService)
        {
            _dataGridHelper = dataGridHelper;
            _firmaService = firmaService;
            InitializeComponent();
            SetToolTips();
        }
        
        private DataTable _dataTable;

        public DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable = _dataGridHelper.FillDataTable(_firmaService.GetFirma, firmaFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, firmaFilter);
        }



        ToolTip buttonFiltreToolTip;

        /// <summary>
        /// Form kontrollerinin ToolTip ayarlarını yapar
        /// </summary>
        public void SetToolTips()
        {
            buttonFiltreToolTip = new ToolTip();
            buttonFiltreToolTip.ToolTipTitle = "Firma Filtreleme";
            buttonFiltreToolTip.SetToolTip(buttonFiltre, "Sol taraftaki ifadeleri içeren filtrelenmiş sonuçları getirir");
            buttonFiltreToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonFiltreToolTip.AutoPopDelay = 20000;
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
        /// Firmaları grid'e getirir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, firmaFilter);
        }


        /// <summary>
        /// Grid'de seçilen firmayı güncellemek için firma formunu açar ya da silme işlemini yapar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalData.DataGridViewCellClick<Firma>(ref _dataTable, dataGridView, e);
        }

        
        /// <summary>
        /// Kayıt formunda yapılan değişiklikler datatable'da güncellenir.
        /// Yeni kayıtsa datatable'a eklenir.
        /// datatable'da yapılan değişiklikler grid'de de otomatik güncellenir.
        /// </summary>
        /// <param name="firma"></param>
        public void UpdateRow(Firma firma)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, firma.Id??0);
            if (i == -1)
            {
                AddNewRow(firma);
            }
            else
            {
                GlobalData.UpdateDataRow(ref _dataTable, firma, i);
            }
        }
        /// <summary>
        /// Yeni kaydı datatable'a satır olarak ekler.
        /// datatable'da yapılan değişiklikler grid'de de otomatik güncellenir.
        /// </summary>
        /// <param name="firma"></param>
        public void AddNewRow(Firma firma)
        {
            dataTable.Rows.Add(
                firma.Id,
                firma.ad,
                firma.adres.acikAdres,
                firma.adres.ulke,
                firma.adres.postaKodu,
                firma.vergiDairesi,
                firma.vergiNumarasi,
                firma.telefon,
                firma.faks,
                firma.mail,
                firma.adres.sehir,
                JsonConvert.SerializeObject(firma.sektorIdList)
                );
        }
        /// <summary>
        /// Yeni kayıt ekleme formunu açar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonEkle_Click(object sender, EventArgs e)
        {
            FirmaKayitFormu firmaKayitFormu = FirmaKayitFormu.firmaKayitFormu;
            if (firmaKayitFormu != null)
            {
                firmaKayitFormu.Show();
                firmaKayitFormu.SaveMode();
            }
        }

        /// <summary>
        /// Filtre alanlarına girilmiş değerlere uyan kayıtları gridde gösterir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, firmaFilter);
        }
        private Firma firmaFilter
        {
            get
            {
                return GlobalData.GridFilter<Firma>(panelFilter);
            }
        }
        
    }
}