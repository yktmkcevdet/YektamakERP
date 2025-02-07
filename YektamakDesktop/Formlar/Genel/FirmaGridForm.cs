using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class FirmaGridForm : Form, IForm,IGridForm<Firma>
    {
        public FirmaGridForm()
        {
            InitializeComponent();
            SetToolTips();
            controlsToDisable = new List<Control>
            {
                buttonFiltre,
                buttonFirmaEkle,
                buttonTumKayitlariGetir,
                dataGridView,
                rButtonCikis
            };

        }
        private static FirmaGridForm _firmaGridForm;

        public static FirmaGridForm firmaGridForm
        {
            get
            {
                if (_firmaGridForm == null)
                {
                    _firmaGridForm = new FirmaGridForm();
                    GlobalData.Yetki(ref _firmaGridForm);
                }
                return _firmaGridForm;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private DataTable _dataTable;

        public DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable = GlobalData.FillDataTable(WebMethods.GetFilteredFirma, firmaFilter);
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
            int i = GlobalData.IndexOfDataSet(dataTable, firma.id);
            if (i == -1)
            {
                AddNewRow(firma);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, firma, i);
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
                firma.id,
                firma.unvan,
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
        public void CloseForm()
        {
            GlobalData.CloseForm(ref _firmaGridForm);
        }

        public void form_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridView,panelFilter);
        }

        public void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
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
    }
}