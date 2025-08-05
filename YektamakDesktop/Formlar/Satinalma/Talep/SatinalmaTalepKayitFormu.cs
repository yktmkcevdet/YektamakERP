using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Proje;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepKayitFormu : Form
    {
        private static ICache _cache;
        private static ISatinalmaTalepService _satinalmaTalepService;
        private static IJsonConverter _jsonConverter;
        public SatinalmaTalepKayitFormu(ICache cache, ISatinalmaTalepService satinalmaTalepService, IJsonConverter jsonConverter)
        {
            _cache = cache;
            _satinalmaTalepService = satinalmaTalepService;
            _jsonConverter = jsonConverter;
            InitializeComponent();
            universalGrid1.kullanici = _cache.kullanici;
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref clbMalzemeGrubu);
            ComboBoxListFill.GetLookupAd(_cache.kullaniciList, ref clbKullaniciId);
            ComboBoxListFill.GetLookupKod(_cache.projes, ref clbProjeKodu);
            FormClosing += async (s, e) => await SatinalmaTalepKayitFormu_FormClosing(s, e);
        }

        private SatinalmaTalep _satinalmaTalep;
        public SatinalmaTalep satinalmaTalep
        {
            get
            {
                if (_satinalmaTalep == null)
                {
                    _satinalmaTalep = new SatinalmaTalep();
                }
                return _satinalmaTalep;
            }
            set
            {
                _satinalmaTalep = value;
                Binding();
            }
        }

        private async Task Binding()
        {
            clbMalzemeGrubu.DataBindings.Clear();
            clbProjeKodu.DataBindings.Clear();
            clbKullaniciId.DataBindings.Clear();
            ctbTalepNo.DataBindings.Clear();
            ctbTalepTarihi.DataBindings.Clear();
            ctbTeslimTarihi.DataBindings.Clear();
            ctbAciklama.DataBindings.Clear();
            ctbSetAdet.DataBindings.Clear();
            clbMalzemeGrubu.DataBindings.Add("SelectedValue", satinalmaTalep, "malzemeGrup.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            clbProjeKodu.DataBindings.Add("SelectedValue", satinalmaTalep, "proje.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            clbKullaniciId.DataBindings.Add("SelectedValue", satinalmaTalep, "talepEdenKullanici.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTalepTarihi.DataBindings.Add("TextCustom", satinalmaTalep, "talepTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTeslimTarihi.DataBindings.Add("TextCustom", satinalmaTalep, "teslimTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTalepNo.DataBindings.Add("TextCustom", satinalmaTalep, "satinalmaTalepNo", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbAciklama.DataBindings.Add("TextCustom", satinalmaTalep, "aciklama", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbSetAdet.DataBindings.Add("TextCustom", satinalmaTalep, "setAdet", true, DataSourceUpdateMode.OnPropertyChanged);
            satinalmaTalep.talepTarihi = DateTime.Today;
            satinalmaTalep.talepEdenKullanici = _cache.kullanici;
            List<SatinalmaTalepDetayDTO> satinalmaTalepDetayList = new();
            foreach (var std in _satinalmaTalep.satinalmaTalepDetays)
            {
                satinalmaTalepDetayList.Add(ConvertHelper.ToDTO<SatinalmaTalepDetayDTO>(std));
            }
            await universalGrid1.SetData(satinalmaTalepDetayList, this.Name, false);
        }
        private async void roundedButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                    return;

                CreateSatinalmaTalep();
                string jsonResult = await _satinalmaTalepService.SaveSatinalmaTalep(satinalmaTalep);
                HandleSaveResult(jsonResult);
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
            isValid &= GlobalData.CheckField("Teslim tarihi girilmelidir", this, ctbTeslimTarihi);
            isValid &= GlobalData.CheckField("Parça Grubu seçilmelidir", this, clbMalzemeGrubu);
            isValid &= GlobalData.CheckField("Set Adet girilmelidir", this, ctbSetAdet);
            isValid &= GlobalData.CheckField("Teslim tarihi girilmelidir", this, ctbTeslimTarihi);
            isValid &= GlobalData.CheckField("Talep tarihi girilmelidir", this, ctbTalepTarihi);
            isValid &= GlobalData.CheckField("Proje kodu seçilmelidir", this, clbProjeKodu);
            isValid &= GlobalData.CheckField("Talep eden kullanıcı seçilmelidir", this, clbKullaniciId);
            return isValid;
        }
        private void CreateSatinalmaTalep()
        {
            _satinalmaTalep.satinalmaTalepDetays.Clear();
            foreach (var item in universalGrid1.binding.OfType<SatinalmaTalepDetayDTO>())
            {
                item.miktar = item.miktar * int.Parse(ctbSetAdet.TextCustom);
                item.agirlik = item.agirlik * int.Parse(ctbSetAdet.TextCustom);
                _satinalmaTalep.satinalmaTalepDetays.Add(ConvertHelper.ToEntity<SatinalmaTalepDetay>(item));
            }
        }
        private void HandleSaveResult(string jsonResult)
        {
            Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
            if (result.result == null || result.result.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Kaydetme işlemi başarısız oldu. {result.result}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Kaydetme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                satinalmaTalep = _jsonConverter.ToModelList<SatinalmaTalep>(result.result).FirstOrDefault();
            }
        }
        public void UpdateMode(SatinalmaTalep satinalmaTalepUpdate)
        {
            satinalmaTalep = satinalmaTalepUpdate;
        }

        private async Task SatinalmaTalepKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            await universalGrid1.SaveSettings();
        }

        private async void SatinalmaTalepKayitFormu_Load(object sender, EventArgs e)
        {
            await Binding();
        }

        private void clbMalzemeGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            var stokKart = new StokKart
            {
                malzemeGrup = new MalzemeGrup { Id = int.Parse(clbMalzemeGrubu.SelectedValue.ToString()) },
            };
            var yeniUrunListesi = _cache.stokKartList
                .Where(x => x.malzemeGrup.Id == stokKart.malzemeGrup.Id)
                .ToList();
            universalGrid1.SetComboColumnData("Stok Kart Id", yeniUrunListesi, "ad", "Id");
        }

        private void yeniKayıtEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<SatinalmaTalepDetayDTO> satinalmaTalepDetayList = universalGrid1.binding.OfType<SatinalmaTalepDetayDTO>().ToList();
            universalGrid1.AddRow(satinalmaTalepDetayList);
        }

        private void universalGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1.Grid, e.Location);
            }
        }

        private void görüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTalepDetayDTO = (SatinalmaTalepDetayDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            SatinalmaTalepDetay satinalmaTalepDetay = ConvertHelper.ToEntity<SatinalmaTalepDetay>(satinalmaTalepDetayDTO);
            SatinalmaTalepSatirDetayForm satinalmaTalepSatirDetayForm = FormFactory.CreateForm<SatinalmaTalepSatirDetayForm>();
            satinalmaTalepSatirDetayForm.UpdateMode(satinalmaTalepDetay.satinalmaTalepSatirDetays);
            satinalmaTalepSatirDetayForm.Show();
        }
    }
}
