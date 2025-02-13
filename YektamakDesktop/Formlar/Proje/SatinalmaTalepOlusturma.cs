using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Utilities.Interfaces;
using System.Linq;
using YektamakDesktop.Common;
using ApiService.Interfaces;
using System.Drawing;
using System.Reflection;

namespace YektamakDesktop.Formlar.Proje
{
    public partial class SatinalmaTalepOlusturma : Form, IForm
    {
        private static ICache _cache;
        private static ISatinalmaTalep _satinalmaTalep;
        public SatinalmaTalepOlusturma(ICache cache, ISatinalmaTalep satinalmaTalep)
        {
            _cache = cache;
            _satinalmaTalep = satinalmaTalep;
        }
        public SatinalmaTalepOlusturma()
        {
            InitializeComponent();

        }
        private SatinalmaTalepBaslik _satinalmaTalepBaslik;
        public SatinalmaTalepBaslik satinalmaTalepBaslik
        {
            get
            {
                if (_satinalmaTalepBaslik == null)
                {
                    _satinalmaTalepBaslik = new SatinalmaTalepBaslik();
                }
                return _satinalmaTalepBaslik;
            }
            set
            {
                _satinalmaTalepBaslik = value;
            }
        }
        private static List<StokKart> _stokKarts;
        public static List<StokKart> stokKarts
        {
            get
            {
                if (_stokKarts == null)
                {
                    _stokKarts = new List<StokKart>();
                }
                return _stokKarts;
            }
            set
            {
                _stokKarts = value;
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
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                if (_dataTable.Rows.Count == 0)
                {
                    _dataTable = Common.ConvertHelper.ToDataTable(stokKarts);
                }
                return _dataTable;
            }
            set
            {
                DataRefresh();
                _dataTable = value;
            }
        }
        private StokKart _stokKartFilter;
        private StokKart stokKartFilter
        {
            get
            {
                if (_stokKartFilter == null)
                {
                    _stokKartFilter = new StokKart();
                }
                return _stokKartFilter;
            }
            set { _stokKartFilter = value; }
        }
        private static SatinalmaTalepOlusturma _satinalmaTalepOlusturma;
        public static SatinalmaTalepOlusturma satinalmaTalepOlusturma
        {
            get
            {
                if (_satinalmaTalepOlusturma == null)
                {
                    _satinalmaTalepOlusturma = new SatinalmaTalepOlusturma();
                    GlobalData.Yetki(ref _satinalmaTalepOlusturma);
                }
                return _satinalmaTalepOlusturma;
            }
        }

        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public bool _activeForm;
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
        private void roundedButton3_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private async void roundedButton4_Click(object sender, EventArgs e)
        {
            bool chck;
            chck = GlobalData.CheckField("Teslim tarihi girilmelidir", this, customTextBoxTeslimTarihi);
            if (!chck) return;
            SatinalmaTalepBaslik satinalmaTalepBaslik = new SatinalmaTalepBaslik();
            satinalmaTalepBaslik.proje.Id = customComboListBoxProjeKodu.selectedDataRowId;
            satinalmaTalepBaslik.parcaGrupId = customComboListBoxParcaGrubu.selectedDataRowId;
            satinalmaTalepBaslik.talepTarihi = DateTime.Parse(DateTime.Now.ToShortDateString());
            foreach (DataGridViewRow row in dataGridViewSatinalma.Rows)
            {
                SatinalmaTalepDetay satinalmaTalepDetay = new SatinalmaTalepDetay();
                satinalmaTalepDetay.stokKart.Id = Convert.ToInt32(row.Cells["Id"].Value.ToString());
                satinalmaTalepDetay.miktar = Convert.ToDouble(row.Cells["miktar"].Value.ToString());
                satinalmaTalepBaslik.satinalmaTalepDetay.Add(satinalmaTalepDetay);
            }
            string result = await _satinalmaTalep.SaveSatinalmaTalep(satinalmaTalepBaslik);
            if (result == "0")
            {
                MessageBox.Show("Kayıt başarısız");
                return;
            }
            else
            {
                MessageBox.Show("Kayıt başarılı");

                this.Invoke(new Action(() =>
                {
                    GlobalData.CloseForm(ref _satinalmaTalepOlusturma);
                }));
            }
        }

        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public void SaveMode(SatinalmaTalepBaslik satinalmaTalepBaslik, List<StokKart> stokKarts)
        {
            _stokKarts = stokKarts;
            dataTable = ConvertHelper.ToDataTable(stokKarts);
            this.satinalmaTalepBaslik = satinalmaTalepBaslik;
            customComboListBoxParcaGrubu.SelectDataRowId(satinalmaTalepBaslik.parcaGrupId);
            customComboListBoxProjeKodu.SelectDataRowId(satinalmaTalepBaslik.proje.Id);
            lblKayitSayisi.Text = $"Toplam kayıt sayısı: {dataTable.Rows.Count}";
        }
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRefresh();
        }
        private void DataRefresh()
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewSatinalma, stokKartFilter);
            DataTable fa = _dataTable;
            lblKayitSayisi.Text = $"Toplam Kayıt Sayısı: {dataGridViewSatinalma.RowCount}";
        }
        private void CloseForm()
        {
            GlobalData.CloseForm(ref _satinalmaTalepOlusturma);
        }

        private void SatinalmaTalepOlusturma_Load(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupKod(_cache.projes.Where(x => x.personel.Id == _cache.kullanici.personel.Id).ToList(), ref customComboListBoxProjeKodu);
            ComboBoxListFill.GetLookupAd(_cache.parcaGrups, ref customComboListBoxParcaGrubu);
        }

        private void roundedButton3_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void roundedButton1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void roundedButton2_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void roundedButton4_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
    }
}
