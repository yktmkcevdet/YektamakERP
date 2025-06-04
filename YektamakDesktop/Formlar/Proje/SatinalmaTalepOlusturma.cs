using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Proje
{
    public partial class SatinalmaTalepOlusturma : Form, IForm
    {
        private static ICache _cache;
        private static ISatinalmaService _satinalmaTalepService;
        private static IStokService _stokService;
        private static IJsonConverter _jsonConverter;
        private static IDataTableMapper _dataTableMapper;
        public SatinalmaTalepOlusturma(ICache cache, ISatinalmaService satinalmaTalep, IStokService stokService, IJsonConverter jsonConverter, IDataTableMapper dataTableMapper)
        {
            _cache = cache;
            _satinalmaTalepService = satinalmaTalep;
            _stokService = stokService;
            _jsonConverter = jsonConverter;
            _dataTableMapper = dataTableMapper;
        }
        public SatinalmaTalepOlusturma()
        {
            InitializeComponent();
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref cbxMalzemeGrubu);
            ComboBoxListFill.GetLookupAd(_cache.kullaniciList, ref cbxKullaniciId);
            ComboBoxListFill.GetLookupKod(_cache.projes, ref cbxProjeKodu);
        }
        private SatinalmaTalep _satinalmaTalepBaslik;
        public SatinalmaTalep satinalmaTalepBaslik
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
        private static List<SatinalmaTalepDetay> _satinalmaTalepDetays;
        public static List<SatinalmaTalepDetay> satinalmaTalepDetays
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
                    _dataTable = Common.ConvertHelper.ToDataTable(satinalmaTalepDetays);
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
            try
            {
                // Validasyon kontrollerini tek seferde yap
                if (!ValidateInputs())
                    return;

                // Satınalma talebini oluştur
                var satinalmaTalep = CreateSatinalmaTalep();

                // Kaydet ve sonucu kontrol et
                string result = await _satinalmaTalepService.SaveSatinalmaTalep(satinalmaTalep);

                HandleSaveResult(result);
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

        private SatinalmaTalep CreateSatinalmaTalep()
        {
            var satinalmaTalep = new SatinalmaTalep
            {
                proje = { Id = cbxProjeKodu.selectedDataRowId },
                malzemeGrupId = cbxMalzemeGrubu.selectedDataRowId,
                talepTarihi = DateTime.Today,
                talepEdenKullaniciId = cbxKullaniciId.selectedDataRowId,
                satinalmaTalepDetays = _satinalmaTalepDetays,
            };

            return satinalmaTalep;
        }

        private void HandleSaveResult(string result)
        {
            if (result == "0")
            {
                MessageBox.Show("Kayıt başarısız", "Hata",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataSet dataSet = _jsonConverter.DeserializeToDataSet(result);
                if (dataSet.Tables[0].Columns[0].ColumnName.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Kayıt başarısız: " + dataSet.Tables[0].Rows[0][0].ToString(), "Hata",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Kayıt başarılı", "Bilgi",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                // UI thread'de çalıştığımız için Invoke'a gerek yok
                DataRow dataRow = _jsonConverter.DeserializeToDataSet(result).Tables[0].Rows[0];
                _satinalmaTalepBaslik = _dataTableMapper.MapToEntity<SatinalmaTalep>(dataRow);
                dataTable = ConvertHelper.ToDataTable(_satinalmaTalepBaslik.satinalmaTalepDetays);
                //GlobalData.CloseForm(ref _satinalmaTalepOlusturma);
            }
        }

        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public void SaveMode(SatinalmaTalep satinalmaTalep)
        {
            _satinalmaTalepDetays = satinalmaTalep.satinalmaTalepDetays;
            dataTable = ConvertHelper.ToDataTable(satinalmaTalepDetays);
            cbxKullaniciId.SelectDataRowId(satinalmaTalep.talepEdenKullaniciId);
            cbxMalzemeGrubu.SelectDataRowId(satinalmaTalep.malzemeGrupId);
            cbxProjeKodu.SelectDataRowId(satinalmaTalep.proje.Id);
            this.satinalmaTalepBaslik = satinalmaTalep;
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

        private void dataGridViewSatinalma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridViewSatinalma_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewSatinalma.Rows[e.RowIndex];
                if (row.Cells["Id"].Value != null)
                {
                    SatinalmaTalepDetay satinalmaTalepDetay = new SatinalmaTalepDetay
                    {
                        Id = Convert.ToInt32(row.Cells["Id"].Value),
                    };
                    detayForm = new SatinalmaTalepSatirDetayForm(satinalmaTalepDetay);
                    detayForm.FormBorderStyle = FormBorderStyle.None;
                    detayForm.StartPosition = FormStartPosition.Manual;
                    detayForm.BackColor = Color.LightYellow;
                    detayForm.Location = Cursor.Position;

                    detayForm.Show();
                }
            }
        }
    }
}
