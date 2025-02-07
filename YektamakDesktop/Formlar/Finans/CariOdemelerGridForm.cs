using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class CariOdemelerGridForm : Form, IForm, IGridForm<CariOdeme>
    {
        private static CariOdemelerGridForm _cariOdemelerGridForm;
        public static CariOdemelerGridForm cariOdemelerGridForm
        {
            get
            {
                if (_cariOdemelerGridForm == null)
                {
                    _cariOdemelerGridForm = new CariOdemelerGridForm();
                    GlobalData.Yetki(ref _cariOdemelerGridForm);
                }
                return _cariOdemelerGridForm;
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
                    _dataTable = GlobalData.FillDataTable(WebMethods.GetFilteredCariOdeme, cariOdemeFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }
        public CariOdemelerGridForm()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>()
            {
                buttonClose,
                buttonFiltre,
                buttonTumKayitlariGetir,
                buttonKayitEkle,
                dataGridView
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
        public void AddNewRow(CariOdeme cariOdeme)
        {
            dataTable.Rows.Add(
                cariOdeme.cariOdemeId,
                cariOdeme.cariKart.cariKartId,
                cariOdeme.cariKart.cariAdi,
                cariOdeme.tutar.tutar,
                cariOdeme.tutar.dovizCinsi.id,
                cariOdeme.tutar.dovizCinsi.sembol,
                cariOdeme.mahsupEdilenTutar.tutar,
                cariOdeme.mahsupEdilenTutar.dovizCinsi.id,
                cariOdeme.mahsupEdilenTutar.dovizCinsi.sembol,
                cariOdeme.odemeTarihi,
                cariOdeme.odemeYonu,
                cariOdeme.odemeTuru,
                cariOdeme.odemeSekli,
                cariOdeme.cek.cekId,
                cariOdeme.cek.cekNumarasi,
                cariOdeme.krediKarti.krediKartiId,
                cariOdeme.krediKarti.kartSahibi,
                cariOdeme.taksitOdemesi.taksitOdemesiId,
                cariOdeme.odemeninCiktigiKasa.kasaId,
                cariOdeme.odemeninCiktigiKasa.kasaAdi,
                cariOdeme.odemeninGirdigiKasa.kasaId,
                cariOdeme.odemeninGirdigiKasa.kasaAdi,
                cariOdeme.odemeYapilanCariKart.cariKartId,
                cariOdeme.odemeYapilanCariKart.cariAdi,
                cariOdeme.projeKod.Id,
                cariOdeme.projeKod.kod,
                cariOdeme.odemeTanimi.odemeTanimiId,
                cariOdeme.odemeTanimi.odemeTanimi,
                cariOdeme.aciklama
                );
        }
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, cariOdemeFilter);
        }
        public CariOdeme cariOdemeFilter
        {
            get
            {
                return GlobalData.GridFilter<CariOdeme>(panelFilter);
            }
        }
        /// <summary>
        /// Grid'de seçilen kaydı güncellemek için CariOdemeKayitFormu'nu açar, ya da silme işlemini yapar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalData.DataGridViewCellClick<CariOdeme>(ref _dataTable, dataGridView, e);
        }
        public void UpdateRowValues(CariOdeme cariOdeme)
        {
            CariOdemeKayitFormu cariOdemeKayitFormu = CariOdemeKayitFormu.cariOdemeKayitFormu;
            if (cariOdemeKayitFormu != null)
            {
                cariOdemeKayitFormu.Show();
                cariOdemeKayitFormu.UpdateMode(cariOdeme);
            }
        }

        public void CloseForm()
        {
            GlobalData.CloseForm(ref _cariOdemelerGridForm);
        }
        public void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        public void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, cariOdemeFilter);
        }
        public void buttonEkle_Click(object sender, EventArgs e)
        {
            CariOdemeKayitFormu cariOdemeKayitFormu = CariOdemeKayitFormu.cariOdemeKayitFormu;
            if (cariOdemeKayitFormu != null)
            {
                cariOdemeKayitFormu.Show();
                cariOdemeKayitFormu.SaveMode();
            }
        }
        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, cariOdemeFilter);
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

        public void UpdateRow(CariOdeme cariOdeme)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, cariOdeme.cariOdemeId);
            if (i == -1)
            {
                AddNewRow(cariOdeme);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, cariOdeme, i);
            }
        }
    }
}