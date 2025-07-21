using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Satinalma;
using YektamakDesktop.Formlar.Stok;

namespace YektamakDesktop.Formlar.Proje
{
    public partial class ProjeDosyalari : Form, IForm
    {
        private readonly ICache _cache;
        private readonly IJsonConverter _jsonConvertHelper;
        private readonly IDataTableMapper _dataTableMapper;
        private readonly IStokService _stokService;
        private readonly IProjeService _projeService;
        public ProjeDosyalari(ICache cache, IJsonConverter jsonConvertHelper, IDataTableMapper dataTableMapper, IStokService stokService, IProjeService projeService)
        {
            _cache = cache;
            _jsonConvertHelper = jsonConvertHelper;
            _dataTableMapper = dataTableMapper;
            _stokService = stokService;
            _projeService = projeService;
            InitializeComponent();
            
            universalGrid1.kullanici = _cache.kullanici;
            universalGrid1.Grid.CellClick += Grid_CellClick;
        }
        private ProjeStokKart _projeStokKartFilter;
        private ProjeStokKart projeStokKartFilter
        {
            get
            {
                if (_projeStokKartFilter == null)
                {
                    _projeStokKartFilter = new ProjeStokKart();
                }
                return _projeStokKartFilter;
            }
            set
            {
                _projeStokKartFilter = value;
            }
        }
        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public bool _activeForm;
        public bool activeForm
        {
            get { return _activeForm; }
            set
            {
                if (value == true)
                {
                    //dataTable = GlobalData.FillDataTableAsync(_stokService.GetStokKart, stokKartFilter).Result;
                    //if (dataTable.Rows.Count > 0) DataRefresh();
                }
                _activeForm = value;
            }
        }

        private List<ProjeStokKartDTO> _projeStokKartDTOs;
        public List<ProjeStokKartDTO> projeStokKartDTOs
        {
            get
            {
                if (_projeStokKartDTOs == null)
                {
                    _projeStokKartDTOs = new();
                }
                return _projeStokKartDTOs;
            }
            set
            {
                _projeStokKartDTOs = value;
            }
        }
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                universalGrid1.Grid.Rows[e.RowIndex].Selected = true;
                if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)
                {
                    if (universalGrid1.Grid.Rows[e.RowIndex].Cells[1].Value == null)
                        return;


                    if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)//Update
                    {
                        var projeStokKartDTO = (ProjeStokKartDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
                        ProjeStokKart projeStokKart = ConvertHelper.ToEntity<ProjeStokKart>(projeStokKartDTO);
                        StokKartKayitFormu stokKartKayitFormu = FormFactory.CreateForm<StokKartKayitFormu>();
                        stokKartKayitFormu.UpdateMode(projeStokKart.stokKart);
                        stokKartKayitFormu.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
        public void form_Load(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupKod(_cache.projes.Where(x => x.personel.Id == _cache.kullanici.personel.Id).ToList(), ref clbProjeKodu);
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref clbStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref clbMalzemeGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups, ref clbMalzemeAltGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List, ref clbMalzemeAltGrup2);
            Binding();
        }

        private void Binding()
        {
            clbProjeKodu.DataBindings.Clear();
            clbStokGrup.DataBindings.Clear();
            clbMalzemeGrup.DataBindings.Clear();
            clbMalzemeAltGrup.DataBindings.Clear();
            clbMalzemeAltGrup2.DataBindings.Clear();
            chkPdf.DataBindings.Clear();
            chkDxf.DataBindings.Clear();
            chkSatinalma.DataBindings.Clear();
            clbProjeKodu.DataBindings.Add("selectedDataRowId", projeStokKartFilter, $"{nameof(projeStokKartFilter.proje)}.{nameof(projeStokKartFilter.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbStokGrup.DataBindings.Add("selectedDataRowId", projeStokKartFilter, $"{nameof(projeStokKartFilter.stokKart)}.{nameof(projeStokKartFilter.stokKart.stokGrup)}.{nameof(projeStokKartFilter.stokKart.stokGrup.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeGrup.DataBindings.Add("selectedDataRowId", projeStokKartFilter, $"{nameof(projeStokKartFilter.stokKart)}.{nameof(projeStokKartFilter.stokKart.malzemeGrup)}.{nameof(projeStokKartFilter.stokKart.malzemeGrup.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeAltGrup.DataBindings.Add("selectedDataRowId", projeStokKartFilter, $"{nameof(projeStokKartFilter.stokKart)}.{nameof(projeStokKartFilter.stokKart.malzemeAltGrup)}.{nameof(projeStokKartFilter.stokKart.malzemeAltGrup.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeAltGrup2.DataBindings.Add("selectedDataRowId", projeStokKartFilter, $"{nameof(projeStokKartFilter.stokKart)}.{nameof(projeStokKartFilter.stokKart.malzemeAltGrup2)}.{nameof(projeStokKartFilter.stokKart.malzemeAltGrup2.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            chkPdf.DataBindings.Add("CheckState", projeStokKartFilter, $"{nameof(projeStokKartFilter.stokKart)}.{nameof(projeStokKartFilter.stokKart.isPdf)}", true, DataSourceUpdateMode.OnPropertyChanged);
            chkDxf.DataBindings.Add("CheckState", projeStokKartFilter, $"{nameof(projeStokKartFilter.stokKart)}.{nameof(projeStokKartFilter.stokKart.isDxf)}", true, DataSourceUpdateMode.OnPropertyChanged);
            chkSatinalma.DataBindings.Add("CheckState", projeStokKartFilter, $"{nameof(projeStokKartFilter.stokKart)}.{nameof(projeStokKartFilter.stokKart.isSatinalma)}", true, DataSourceUpdateMode.OnPropertyChanged);
            universalGrid1.SetData(projeStokKartDTOs, this.Name, true, false, true);
        }

        private async Task GridDoldur()
        {
            this.Enabled = false;
            projeStokKartDTOs.Clear();
            string jsonResult = await _projeService.GetProjeStokKart(projeStokKartFilter);
            Result result = _jsonConvertHelper.DeserializeToModelList<Result>(jsonResult)[0];
            if (result.result != null)
            {
                List<ProjeStokKart> projeStokKarts = JsonConvert.DeserializeObject<List<ProjeStokKart>>(result.result);
                List<ProjeStokKartDTO> pskDTOs = new List<ProjeStokKartDTO>();
                foreach (var psk in projeStokKarts)
                {
                    pskDTOs.Add(ConvertHelper.ToDTO<ProjeStokKartDTO>(psk));
                }
                projeStokKartDTOs = pskDTOs;
            }
            else
            {
                projeStokKartDTOs = null;
            }
            universalGrid1.SetData(projeStokKartDTOs, this.Name, true);
            this.Enabled = true;
        }
        private async Task GridYenile()
        {
            try
            {
                bool isValid = ValidationFilterFields();

                if (!isValid)
                {
                    return;
                }
                this.Enabled = false;
                ProjeStokKartDTO projeStokKartDTO = ConvertHelper.ToDTO<ProjeStokKartDTO>(projeStokKartFilter);
                universalGrid1.Filtrele(projeStokKartDTO, this.Name);
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Enabled = true;
            }
        }
        private async void projeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            projeStokKartFilter.proje.Id = clbProjeKodu.selectedDataRowId;
            await GridDoldur();
        }
        private async void parcaGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            projeStokKartFilter.stokKart.stokGrup.Id = clbStokGrup.selectedDataRowId;
            clbMalzemeGrup.SelectDataRowId(null);
            clbMalzemeAltGrup.SelectDataRowId(null);
            clbMalzemeAltGrup2.SelectDataRowId(null);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(c => c.stokGrup.Id == clbStokGrup.selectedDataRowId).ToList(), ref clbMalzemeGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(c => c.malzemeGrup.stokGrup.Id == clbStokGrup.selectedDataRowId).ToList(), ref clbMalzemeAltGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(c => c.malzemeAltGrup.malzemeGrup.stokGrup.Id == clbStokGrup.selectedDataRowId).ToList(), ref clbMalzemeAltGrup2);
            await GridYenile();
        }
        private async void parcaAltGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            projeStokKartFilter.stokKart.malzemeGrup.Id = clbMalzemeGrup.selectedDataRowId;
            clbMalzemeAltGrup.SelectDataRowId(null);
            clbMalzemeAltGrup2.SelectDataRowId(null);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(c => c.malzemeGrup.Id == clbMalzemeGrup.selectedDataRowId).ToList(), ref clbMalzemeAltGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(c => c.malzemeAltGrup.malzemeGrup.Id == clbMalzemeGrup.selectedDataRowId).ToList(), ref clbMalzemeAltGrup2);
            await GridYenile();
        }
        private async void parcaAdi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter tuşuna basıldı mı kontrolü
            {
                await GridYenile();
            }
        }
        private async void chkSatinalma_CheckedChanged(object sender, EventArgs e)
        {
            await GridYenile();
        }
        private async void chkPdf_CheckStateChanged(object sender, EventArgs e)
        {
            chkPdf.DataBindings["CheckState"].WriteValue();
            if (chkPdf.CheckState == CheckState.Checked)
            {
                chkPdf.Text = "PDF Dosyası Olanlar";
            }
            else if (chkPdf.CheckState == CheckState.Unchecked)
            {
                chkPdf.Text = "PDF Dosyası Olmayanlar";
            }
            else if (chkPdf.CheckState == CheckState.Indeterminate)
            {
                chkPdf.Text = "PDF";
            }
            await GridYenile();
        }
        private async void chkStep_CheckedChanged(object sender, EventArgs e)
        {
            await GridYenile();
        }
        private void roundedButton4_Click(object sender, EventArgs e)
        {
            bool result = true;
            result = GlobalData.CheckField("Stok grubu seçilmelidir", this, clbStokGrup) && result;
            result = GlobalData.CheckField("Malzeme grubu seçilmelidir", this, clbMalzemeGrup) && result;
            if (result) CreateSatinalmaTalep(sender, e);
        }
        private void CreateSatinalmaTalep(object sender, EventArgs e)
        {
            var talepList = universalGrid1.GetCheckedRows<ProjeStokKartDTO>();
            if (ValidateForm(talepList))
            {
                List<SatinalmaTalepDetay> satinalmaTalepDetayList = new List<SatinalmaTalepDetay>();
                foreach (var item in talepList)
                {
                    item.Id = null; //projestokKartId satinalmaTalepDetayId olarak aktarılmaması için null yapılıyor
                    SatinalmaTalepDetay satinalmaTalepdetay = new();
                    SatinalmaTalepSatirDetayDTO satinalmaTalepSatirDetay = new SatinalmaTalepSatirDetayDTO();
                    // Eğer stok kartının hammaddeId'si varsa, satınalma talep detay listesine hammadde olarak ekle
                    if (item.stokKarthammaddeId != null)
                    {
                        //Hammadde ise listeye daha önce eklenmiş mi kontrol et, eklenmişse miktarını güncelle
                        if (satinalmaTalepDetayList.Any(x => x.stokKart.Id == item.stokKarthammaddeId))
                        {
                            satinalmaTalepdetay = satinalmaTalepDetayList.FirstOrDefault(x => x.stokKart.Id == item.stokKarthammaddeId);
                            satinalmaTalepdetay.miktar += item.miktar;
                            satinalmaTalepdetay.agirlik += item.miktar * item.stokKartagirlik;
                            satinalmaTalepdetay.satinalmaTalepSatirDetays.Add(
                                ConvertHelper.ToEntity<SatinalmaTalepSatirDetay>(item));
                        }
                        // Eğer hammadde olarak eklenmemişse, yeni bir hammadde olarak ekle
                        else
                        {
                            satinalmaTalepdetay.miktar = item.miktar;
                            satinalmaTalepdetay.agirlik = item.miktar * item.stokKartagirlik;
                            satinalmaTalepdetay.satinalmaTalepSatirDetays.Add(ConvertHelper.ToEntity<SatinalmaTalepSatirDetay>(item));
                            satinalmaTalepdetay.stokKart.Id = item.stokKarthammaddeId;
                            satinalmaTalepdetay.stokKart.kod = item.stokKarthammaddekod;
                            satinalmaTalepdetay.stokKart.ad = item.stokKarthammaddead;
                            satinalmaTalepDetayList.Add(satinalmaTalepdetay);
                        }
                    }
                    // Eğer stok kartının hammaddeId'si yoksa, satınalma talep detay listesine normal stok kartı olarak ekle
                    else
                    {
                        satinalmaTalepdetay = ConvertHelper.ToEntity<SatinalmaTalepDetay>(item);
                        satinalmaTalepdetay.miktar = item.miktar;
                        satinalmaTalepdetay.agirlik = item.miktar * item.stokKartagirlik;
                        satinalmaTalepDetayList.Add(satinalmaTalepdetay);
                    }
                }
                SatinalmaTalep satinalmaTalep = new SatinalmaTalep
                {
                    proje = { Id = clbProjeKodu.selectedDataRowId },
                    malzemeGrup = new MalzemeGrup { Id = clbMalzemeGrup.selectedDataRowId },
                    talepTarihi = DateTime.Today,
                    teslimTarihi = null,
                    aciklama = "Otomatik oluşturulan satınalma talebi",
                    talepEdenKullanici = _cache.kullanici,
                    satinalmaTalepDetays = satinalmaTalepDetayList
                };
                SatinalmaTalepKayitFormu satinalmaTalepKayitFormu = FormFactory.CreateForm<SatinalmaTalepKayitFormu>();
                satinalmaTalepKayitFormu.UpdateMode(satinalmaTalep);
                satinalmaTalepKayitFormu.ShowDialog();
            }
        }
        private bool ValidateForm(List<ProjeStokKartDTO> stokKarts)
        {
            // Formdaki gerekli alanların dolu olup olmadığını kontrol et
            if (!stokKarts.Any())
            {
                MessageBox.Show("Satınalma talebi oluşturulacak satırlar seçilmelidir.");
                return false;
            }
            //if (stokKarts.Any(x => x.stokKartisPdf == false))
            //{
            //    MessageBox.Show("PDF dosyası olmayan kayıtlar seçilemez.");
            //    return false;
            //}
            if (stokKarts.Any(x => x.stokKartisDxf == false))
            {
                MessageBox.Show("DXF dosyası olmayan kayıtlar seçilemez.");
                return false;
            }
            if (stokKarts.Any(x => x.stokKartisSatinalma == true))
            {
                MessageBox.Show("Satınalma talebi açılmış kayıtlar seçilemez.");
                return false;
            }
            return true;
        }
        private void stokKartınıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private async void cbxMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            projeStokKartFilter.stokKart.malzemeAltGrup.Id = clbMalzemeAltGrup.selectedDataRowId;
            clbMalzemeAltGrup2.SelectDataRowId(null);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(c => c.malzemeAltGrup.Id == clbMalzemeAltGrup.selectedDataRowId).ToList(), ref clbMalzemeAltGrup2);
            await GridYenile();
        }
        private async void cbxMalzemeAltGrup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            projeStokKartFilter.stokKart.malzemeAltGrup2.Id = clbMalzemeAltGrup2.selectedDataRowId;
            await GridYenile();
        }
        private async void textBoxParcaAdi_TextChanged(object sender, EventArgs e)
        {
            projeStokKartFilter.stokKart.parcaAdi = ctbParcaAdi.TextCustom;
            await GridYenile();
        }
        private void roundedIconButton1_Click(object sender, EventArgs e)
        {
            ExceldenVeriAlmaFormu exceldenVeriAlmaFormu = FormFactory.CreateForm<ExceldenVeriAlmaFormu>();
            exceldenVeriAlmaFormu.ShowDialog();
        }


        private void ProjeDosyalari_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private bool ValidationFilterFields()
        {
            bool result = false;
            result = GlobalData.CheckField("", this, clbProjeKodu) || result;
            return result;
        }

        private async void chkDxf_CheckedChanged(object sender, EventArgs e)
        {
            chkDxf.DataBindings["CheckState"].WriteValue();
            if (chkDxf.CheckState == CheckState.Checked)
            {
                chkDxf.Text = "DXF Dosyası Olanlar";
            }
            else if (chkDxf.CheckState == CheckState.Unchecked)
            {
                chkDxf.Text = "DXF Dosyası Olmayanlar";
            }
            else if (chkDxf.CheckState == CheckState.Indeterminate)
            {
                chkDxf.Text = "DXF";
            }
            await GridYenile();
        }

        private async void roundedIconButton2_Click(object sender, EventArgs e)
        {
            if (clbProjeKodu.selectedDataRowId == null)
            {
                MessageBox.Show("Lütfen bir proje seçiniz.");
                return;
            }
            else
            {
                await GridDoldur();
            }
        }
    }
}