using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class CekKayitlariGridForm : Form, IForm,IGridForm<Cek>
    {
        
        private static CekKayitlariGridForm _cekKayitlariGridForm;
        public static CekKayitlariGridForm cekKayitlariGridForm
        {
            get
            {
                if (_cekKayitlariGridForm == null || _cekKayitlariGridForm.IsDisposed)
                {
                    _cekKayitlariGridForm = new CekKayitlariGridForm();
                    GlobalData.Yetki(ref _cekKayitlariGridForm);
                }
                return _cekKayitlariGridForm;
            }
            set
            {
                _cekKayitlariGridForm = value;
            }
        }
        private DataTable _dataTable;
        public DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable = GlobalData.FillDataTable(WebMethods.GetFilteredCek, cekFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public CekKayitlariGridForm()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>();
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

        public void UpdateRow(Cek cek)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, cek.cekId);
            if (i == -1)
            {
                AddNewRow(cek);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, cek, i);
            }
        }

        public void AddNewRow(Cek cek)
        {
            dataTable.Rows.Add(
                cek.cekId,
                cek.cekNumarasi,
                cek.cekDurumu.cekDurumId,
                cek.cekDurumu.cekDurumAdi,
                cek.tutar.tutar,
                cek.tutar.dovizCinsi.id,
                cek.tutar.dovizCinsi.sembol,
                cek.vadeTarihi,
                cek.cekiVerenFirma.Id,
                cek.cekiVerenFirma.ad,
                cek.cekiAlanFirma.Id,
                cek.cekiAlanFirma.ad,
                cek.cekSahibiBanka.Id,
                cek.cekSahibiBanka.ad,
                cek.cekinVerildigiTarih,
                cek.cekResim.id
                );
        }

        public void form_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridViewCek, panelFilter);
        }
        public Cek cekFilter
        {
            get
            {
                return GlobalData.GridFilter<Cek>(panelFilter);
            }
        }
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewCek, cekFilter);
        }

        public void buttonEkle_Click(object sender, EventArgs e)
        {
            CekKayitFormu cekKayitFormu= CekKayitFormu.cekKayitFormu;
            if (cekKayitFormu != null)
            {
                cekKayitFormu.Show();
                cekKayitFormu.SaveMode();
            }
        }

        public void CloseForm()
        {
            GlobalData.CloseForm(ref _cekKayitlariGridForm);
        }

        public void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalData.DataGridViewCellClick<Cek>(ref _dataTable, dataGridViewCek, e);
        }

        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            _dataTable=GlobalData.FillDataTable(WebMethods.GetFilteredCek, cekFilter);
            GlobalData.FillDataGrid(dataTable, dataGridViewCek, cekFilter);
        }

        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewCek, cekFilter);
        }

        public void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridViewCek, panelFilter);
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
            GlobalData.AdjustControlsOnScroll(dataGridViewCek, panelFilter, e, ref oldScrollOffset);
        }
        


    }
}

