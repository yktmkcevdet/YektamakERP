using ApiService.Interfaces;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar.Proje;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepKayitFormu : Form, IForm
    {
        private static ICache _cache;
        private static ISatinalmaTalepService _satinalmaTalepService;
        private static IStokService _stokService;
        private static IJsonConverter _jsonConverter;
        private static IDataTableMapper _dataTableMapper;
        public SatinalmaTalepKayitFormu(ICache cache, ISatinalmaTalepService satinalmaTalep, IStokService stokService, IJsonConverter jsonConverter, IDataTableMapper dataTableMapper)
        {
            _cache = cache;
            _satinalmaTalepService = satinalmaTalep;
            _stokService = stokService;
            _jsonConverter = jsonConverter;
            _dataTableMapper = dataTableMapper;
        }
        public SatinalmaTalepKayitFormu()
        {
            InitializeComponent();
            controlsToDisable=new List<Control> { panelHeader};
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref cbxMalzemeGrubu);
            ComboBoxListFill.GetLookupAd(_cache.kullaniciList, ref cbxKullaniciId);
            ComboBoxListFill.GetLookupKod(_cache.projes, ref cbxProjeKodu);
        }
        private SatinalmaTalep _satinalmaTalepBaslik;
        public SatinalmaTalep satinalmaTalep
        {
            get
            {
                if (_satinalmaTalepBaslik == null)
                {
                    _satinalmaTalepBaslik = new SatinalmaTalep();
                }
                return _satinalmaTalepBaslik;
            }
            set
            {
                _satinalmaTalepBaslik = value;
            }
        }
        private List<SatinalmaTalepDetay> _satinalmaTalepDetays;
        public List<SatinalmaTalepDetay> satinalmaTalepDetays
        {
            get
            {
                if (_satinalmaTalepDetays == null)
                {
                    _satinalmaTalepDetays = new List<SatinalmaTalepDetay>();
                }
                return _satinalmaTalepDetays;
            }
            set
            {
                _satinalmaTalepDetays = value;
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
                    _dataTable = ConvertHelper.ToDataTable(satinalmaTalepDetays);
                }
                return _dataTable;
            }
            set
            {
                _dataTable = value;
                DataRefresh();
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
        private static SatinalmaTalepKayitFormu _satinalmaTalepKayitFormu;
        public static SatinalmaTalepKayitFormu satinalmaTalepKayitFormu
        {
            get
            {
                if (_satinalmaTalepKayitFormu == null)
                {
                    _satinalmaTalepKayitFormu = new SatinalmaTalepKayitFormu();
                    GlobalData.Yetki(ref _satinalmaTalepKayitFormu);
                }
                return _satinalmaTalepKayitFormu;
            }
        }

        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable 
        { 
            get { return _controlsToDisable; } 
            set { if (_controlsToDisable == null) { _controlsToDisable = new List<Control>(); } _controlsToDisable = value; } 
        }
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
            try
            {
                // Validasyon kontrollerini tek seferde yap
                if (!ValidateInputs())
                    return;

                // Satınalma talebini oluştur
                CreateSatinalmaTalep();

                // Kaydet ve sonucu kontrol et
                string result = await _satinalmaTalepService.SaveSatinalmaTalep(satinalmaTalep);
               
                HandleSaveResult(result);
                if (GlobalData.activeFormStack.Where(x=>x.Name== "SatinalmaTalepler").Count()>0) 
                {
                    SatinalmaTalepler.satinalmaTalepler.UpdateRow(satinalmaTalep);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}", "Hata",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            // Tüm validasyonları çalıştır, kısa devre yapmadan
            isValid &= GlobalData.CheckField("Teslim tarihi girilmelidir", this, customTextBoxTeslimTarihi);
            isValid &= GlobalData.CheckField("Parça Grubu seçilmelidir", this, cbxMalzemeGrubu);

            return isValid;
        }

        private void CreateSatinalmaTalep()
        {
            satinalmaTalep.proje.Id = cbxProjeKodu.selectedDataRowId;
            satinalmaTalep.malzemeGrup.Id = cbxMalzemeGrubu.selectedDataRowId;
            satinalmaTalep.talepTarihi = DateTime.Today;
            satinalmaTalep.teslimTarihi = Convert.ToDateTime(customTextBoxTeslimTarihi.TextCustom);
            satinalmaTalep.satinalmaTalepNo = customTextBoxTalepNo.TextCustom;
            satinalmaTalep.aciklama = customTextBoxAciklama.TextCustom;
            satinalmaTalep.talepEdenKullanici.Id = cbxKullaniciId.selectedDataRowId;
            satinalmaTalep.satinalmaTalepDetays = satinalmaTalepDetays = _dataTableMapper.MapToEntityList<SatinalmaTalepDetay>(dataTable);
        }

        private void HandleSaveResult(string result)
        {
            Result resultModel = _jsonConverter.DeserializeToModelList<Result>(result).FirstOrDefault();
            MessageBox.Show(resultModel.result);
        }

        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public void UpdateMode(SatinalmaTalep satinalmaTalep)
        {
            this.satinalmaTalep = satinalmaTalep;
            satinalmaTalepDetays = satinalmaTalep.satinalmaTalepDetays;
            dataTable = ConvertHelper.ToDataTable(satinalmaTalepDetays);
            customTextBoxTalepNo.TextCustom = satinalmaTalep.satinalmaTalepNo;
            customTextBoxTeslimTarihi.TextCustom = satinalmaTalep.teslimTarihi;
            customTextBoxTalepTarihi.TextCustom = satinalmaTalep.talepTarihi;
            cbxKullaniciId.SelectDataRowId(satinalmaTalep.talepEdenKullanici.Id ?? -1);
            cbxMalzemeGrubu.SelectDataRowId(satinalmaTalep.malzemeGrup.Id);
            cbxProjeKodu.SelectDataRowId(satinalmaTalep.proje.Id);
            customTextBoxAciklama.TextCustom = satinalmaTalep.aciklama;
            lblKayitSayisi.Text = $"Toplam kayıt sayısı: {dataTable.Rows.Count}";

        }
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRefresh();
        }
        private void DataRefresh()
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewSatinalma, stokKartFilter);
            lblKayitSayisi.Text = $"Toplam Kayıt Sayısı: {dataGridViewSatinalma.RowCount}";
        }
        private void CloseForm()
        {
            GlobalData.CloseForm(ref _satinalmaTalepKayitFormu);
        }

        private void SatinalmaTalepOlusturma_Load(object sender, EventArgs e)
        {
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
        private Form detayForm;

        private void dataGridViewSatinalma_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            detayForm?.Close();
            detayForm = null;
        }

        private void dataGridViewSatinalma_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewSatinalma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewSatinalma.Rows[e.RowIndex];
                if (row.Cells["stokKartId"].Value != null)
                {
                    detayForm = new SatinalmaTalepSatirDetayForm(_satinalmaTalepDetays.FirstOrDefault(x => x.stokKart.Id == Convert.ToInt32(row.Cells["stokKartId"].Value)).satinalmaTalepSatirDetays);
                    detayForm.FormBorderStyle = FormBorderStyle.None;
                    detayForm.StartPosition = FormStartPosition.Manual;
                    detayForm.BackColor = Color.LightYellow;
                    detayForm.Location = Cursor.Position;

                    detayForm.Show();
                }
            }
        }

        private void dataGridViewSatinalma_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Geçersiz indeks kontrolü

            string columnName = dataGridViewSatinalma.Columns[e.ColumnIndex].Name;
            // Değer değiştiğinde, dataTable'a güncelleme yap
            dataTable.Rows[e.RowIndex][columnName] = dataGridViewSatinalma.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }
    }
}
