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
            universalGrid1.Grid.CellClick += Grid_CellClick;
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref clbMalzemeGrubu);
            ComboBoxListFill.GetLookupAd(_cache.kullaniciList, ref clbKullaniciId);
            ComboBoxListFill.GetLookupKod(_cache.projes, ref clbProjeKodu);
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                universalGrid1.Grid.Rows[e.RowIndex].Selected = true;
                if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex ||
                    e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
                {
                    if (universalGrid1.Grid.Rows[e.RowIndex].Cells[1].Value == null)
                        return;


                    if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)//Update
                    {
                        var satinalmaTalepDetayDTO = (SatinalmaTalepDetayDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
                        SatinalmaTalepDetay satinalmaTalepDetay = ConvertHelper.ToEntity<SatinalmaTalepDetay>(satinalmaTalepDetayDTO);
                        SatinalmaTalepSatirDetayForm satinalmaTalepSatirDetayForm = FormFactory.CreateForm<SatinalmaTalepSatirDetayForm>();
                        satinalmaTalepSatirDetayForm.UpdateMode(satinalmaTalepDetay.satinalmaTalepSatirDetays);
                        satinalmaTalepSatirDetayForm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
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
                //Binding();
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
            clbMalzemeGrubu.DataBindings.Add("selectedDataRowId", satinalmaTalep, "malzemeGrup.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            clbProjeKodu.DataBindings.Add("selectedDataRowId", satinalmaTalep, "proje.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            clbKullaniciId.DataBindings.Add("selectedDataRowId", satinalmaTalep, "talepEdenKullanici.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTalepTarihi.DataBindings.Add("TextCustom", satinalmaTalep, "talepTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTeslimTarihi.DataBindings.Add("TextCustom", satinalmaTalep, "teslimTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTalepNo.DataBindings.Add("TextCustom", satinalmaTalep, "satinalmaTalepNo", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbAciklama.DataBindings.Add("TextCustom", satinalmaTalep, "aciklama", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbSetAdet.DataBindings.Add("TextCustom", satinalmaTalep, "setAdet", true, DataSourceUpdateMode.OnPropertyChanged);
            List<SatinalmaTalepDetayDTO> satinalmaTalepDetayList = new();
            foreach (var std in _satinalmaTalep.satinalmaTalepDetays)
            {
                satinalmaTalepDetayList.Add(ConvertHelper.ToDTO<SatinalmaTalepDetayDTO>(std));
            }
            await universalGrid1.SetData(satinalmaTalepDetayList, this.Name, true, true, false);
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

        private void SatinalmaTalepKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private async void SatinalmaTalepKayitFormu_Load(object sender, EventArgs e)
        {
            await Binding();
        }
    }
}
