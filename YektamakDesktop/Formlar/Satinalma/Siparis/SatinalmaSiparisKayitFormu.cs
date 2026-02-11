using Models;
using System.Windows.Forms;
using System.ComponentModel;
using YektamakDesktop.Common;
using Utilities.Interfaces;
using YektamakDesktop.CustomControls;
using System.Linq;
using Models.DTO;
using ApiService.Interfaces;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using ApiService.Implementations;
using Utilities.Implementations;
using System.Threading.Tasks;

namespace YektamakDesktop.Formlar.Satinalma.Siparis
{
    public partial class SatinalmaSiparisKayitFormu : Form
    {
        private readonly ICache _cache;
        private readonly ISatinalmaSiparisService _saService;
        private readonly IProjeService _projeService;
        private readonly IJsonConverter _jsonConverter;
        private readonly IConvertHelper _convertHelper;
        private string _initialStateJson;
        public SatinalmaSiparisKayitFormu(ICache cache, ISatinalmaSiparisService saService, IProjeService projeService, IJsonConverter jsonConverter, IConvertHelper convertHelper)
        {
            _cache = cache;
            _saService = saService;
            _projeService = projeService;
            _jsonConverter = jsonConverter;
            _convertHelper = convertHelper;
            InitializeComponent();
            Initialize();
        }
        private async void Initialize()
        {
            int sizeX = universalGrid1.Size.Width;
            int sizeY = universalGrid1.Size.Height;
            int locationY = universalGrid1.Location.Y;
            int locationX = universalGrid1.Location.X;
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(sizeX, sizeY);
            universalGrid1.TabIndex = 13;
            Controls.Add(universalGrid1);
            universalGrid1.CellValueChanged += universalGrid1_CellEndEdit;
            fcbFirmaId.SetDataSource(_cache.firmaList);
            fcbKdv.SetDataSource(_cache.kdvList);
            fcbVadeId.SetDataSource(_cache.vadeList);
            fcbDovizCinsi.SetDataSource(_cache.dovizCinsiList);
            fcbProjeKod.SetDataSource(_cache.projeList);
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups);
            universalGrid1.SetData(new List<SatinalmaSiparisDetayDTO>(),this.Name);
            Binding();
        }
        private SatinalmaSiparisDTO _satinalmaSiparis;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SatinalmaSiparisDTO satinalmaSiparis
        {
            get
            {
                if (_satinalmaSiparis == null)
                {
                    _satinalmaSiparis = new();
                    _initialStateJson = JsonConvert.SerializeObject(satinalmaSiparis);
                }
                return _satinalmaSiparis;
            }
            set
            {
                _satinalmaSiparis = value;
                _initialStateJson = JsonConvert.SerializeObject(satinalmaSiparis);
                Binding();
            }
        }
        private async void Binding()
        {
            BindHelper.BindData(ctbId, satinalmaSiparis, nameof(satinalmaSiparis.Id));
            BindHelper.BindData(ctbSiparisNo, satinalmaSiparis, nameof(satinalmaSiparis.siparisNo));
            BindHelper.BindData(fcbProjeKod, satinalmaSiparis, nameof(satinalmaSiparis.projeId));
            BindHelper.BindData(fcbMalzemeGrup, satinalmaSiparis, nameof(satinalmaSiparis.malzemeGrupId));
            BindHelper.BindData(fcbFirmaId, satinalmaSiparis, nameof(satinalmaSiparis.firmaId));
            BindHelper.BindData(fcbKdv, satinalmaSiparis, nameof(satinalmaSiparis.kdvId));
            BindHelper.BindData(fcbVadeId, satinalmaSiparis, nameof(satinalmaSiparis.vadeId));
            BindHelper.BindData(ctbSiparisTarihi, satinalmaSiparis, nameof(satinalmaSiparis.siparisTarihi));
            BindHelper.BindData(ctbTeslimTarihi, satinalmaSiparis, nameof(satinalmaSiparis.teslimTarihi));
            BindHelper.BindData(ctbAciklama, satinalmaSiparis, nameof(satinalmaSiparis.aciklama));
            BindHelper.BindData(ctbTutar, satinalmaSiparis, nameof(satinalmaSiparis.tutar));
            BindHelper.BindData(fcbDovizCinsi, satinalmaSiparis, nameof(satinalmaSiparis.dovizCinsiId));
            if (satinalmaSiparis.satinalmaSiparisDetay == null)
            {
                satinalmaSiparis.satinalmaSiparisDetay = new List<SatinalmaSiparisDetay>();
            }
            List<SatinalmaSiparisDetayDTO> satinalmaSiparisDetayDTOs = new();
            foreach (var item in satinalmaSiparis.satinalmaSiparisDetay)
            {
                satinalmaSiparisDetayDTOs.Add(_convertHelper.ToDTO<SatinalmaSiparisDetayDTO>(item));
            }
            await universalGrid1.SetData(satinalmaSiparisDetayDTOs, this.Name);
        }
        public void UpdateMode(SatinalmaSiparisDTO satinalmaSiparisUpdate)
        {
            satinalmaSiparis = satinalmaSiparisUpdate;
        }

        private void SatinalmaSiparisKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveControl(e);
            universalGrid1.SaveGridSettings();
        }

        private async void customButtonSave1_SaveButtonClick(object sender, System.EventArgs e)
        {
            satinalmaSiparis.satinalmaSiparisDetay = ((SortableBindingList<SatinalmaSiparisDetayDTO>)universalGrid1.binding.DataSource).CastToEntity<SatinalmaSiparisDetay>(_convertHelper).ToList();
            string jsonResult = await _saService.SaveSatinalmaSiparis(_convertHelper.ToEntity<SatinalmaSiparis>(satinalmaSiparis));
            if (!string.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error",StringComparison.OrdinalIgnoreCase))
            {
                satinalmaSiparis = _jsonConverter.DeserializeObject<List<SatinalmaSiparis>>(jsonResult).CastToDTO<SatinalmaSiparisDTO>(_convertHelper).ToList()[0];
                MessageBox.Show("Kayıt işlemi başarılı.");
            }
            else
            {
                MessageBox.Show("Kayıt işlemi başarısız: " + jsonResult);
            }
        }
        private void universalGrid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == universalGrid1.Grid.Columns["Miktar"].Index ||
                e.ColumnIndex == universalGrid1.Grid.Columns["Birim fiyat"].Index)
            {
                var row = universalGrid1.Grid.Rows[e.RowIndex];
                HesaplaToplam();
            }
        }
        private void HesaplaToplam()
        {
            double toplam = 0;
            foreach (DataGridViewRow row in universalGrid1.Grid.Rows)
            {
                if (row.Cells["Birim fiyat"].Value != null)
                {
                    double.TryParse(row.Cells["Birim fiyat"].Value.ToString(), out double brFiyatValue);
                    double.TryParse(row.Cells["Miktar"].Value.ToString(), out double miktarValue);
                    toplam += brFiyatValue * miktarValue;
                }
            }

            ctbTutar.TextCustom = toplam.ToString();
        }
        private void SaveControl(FormClosingEventArgs e)
        {
            var currentData = JsonConvert.SerializeObject(satinalmaSiparis);
            bool isDirty = _initialStateJson != currentData;
            if (isDirty)
            {
                var result = MessageBox.Show("Yapılan değişiklikler kaydedilmedi. Kaydetmek ister misiniz?", "Değişiklikler Kaydedilmedi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    customButtonSave1_SaveButtonClick(this, EventArgs.Empty);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.No)
                {
                    //JsonConvert.PopulateObject(_initialStateJson, satinalmaSiparis);
                    CopyValues(_jsonConverter.DeserializeObject<SatinalmaSiparisDTO>(_initialStateJson), satinalmaSiparis);
                    //satinalmaSiparis = _jsonConverter.DeserializeObject<SatinalmaSiparisDTO>(_initialStateJson);
                }
            }
        }
        public static void CopyValues<T>(T source, T target)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if (!prop.CanRead || !prop.CanWrite) continue;
                prop.SetValue(target, prop.GetValue(source));
            }
        }
    }
}
