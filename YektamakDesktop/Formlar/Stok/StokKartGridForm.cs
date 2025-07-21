using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar.Genel;

namespace YektamakDesktop.Formlar.Stok
{
    public partial class StokKartGridForm : Form, IForm
    {
        private readonly IStokService _stokService;
        private readonly ICache _cache;
        private readonly IJsonConverter _jsonConverter;
        public StokKartGridForm(ICache cache, IJsonConverter jsonConvertHelper, IStokService stokService)
        {
            _stokService = stokService;
            _cache = cache;
            _jsonConverter = jsonConvertHelper;
            _stokService = stokService;
            InitializeComponent();
            ComboBoxListFill.GetLookupKod(_cache.projes, ref projeKodu);
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref cbxStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref cbxMalzemeGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List, ref cbxMalzemeAltGrup2);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups, ref cbxMalzemeAltGrup);
            ComboBoxListFill.GetLookupAd(_cache.stokTips, ref cbxStokTip);
            universalGrid1.kullanici = _cache.kullanici;
            universalGrid1.Grid.CellClick += Grid_CellClick;
            universalGrid1.SetData(stokKartDTOs, this.Name, true);
        }
        private List<StokKartDTO> _stokKartDTOs;
        public List<StokKartDTO> stokKartDTOs
        {
            get
            {
                if (_stokKartDTOs == null)
                {
                    _stokKartDTOs = new List<StokKartDTO>();
                }
                return _stokKartDTOs;
            }
            set
            {
                _stokKartDTOs = value;
            }
        }

        private List<StokKart> _stokKarts;
        private List<StokKart> stokKarts
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

        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public bool _activeForm;
        public bool activeForm
        {
            get { return _activeForm; }
            set
            {
                _activeForm = value;
            }
        }
        private async Task GridDoldur()
        {
            this.Enabled = false;
            stokKarts.Clear();
            string jsonResult = await _stokService.GetStokKart(stokKartFilter);
            Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult)[0];
            if (result.result != null)
            {
                List<StokKart> stokKarts = JsonConvert.DeserializeObject<List<StokKart>>(result.result);
                List<StokKartDTO> pskDTOs = new List<StokKartDTO>();
                foreach (var sk in stokKarts)
                {
                    pskDTOs.Add(ConvertHelper.ToDTO<StokKartDTO>(sk));
                }
                stokKartDTOs = pskDTOs;
            }
            else
            {
                stokKartDTOs = null;
            }
            universalGrid1.SetData(stokKartDTOs, this.Name, true);
            this.Enabled = true;
        }
        private void malzemeGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.malzemeGrup.Id = cbxMalzemeGrup.selectedDataRowId;
            StokKartDTO stokKartDTO = ConvertHelper.ToDTO<StokKartDTO>(stokKartFilter);
            universalGrid1.Filtrele(stokKartDTO, this.Name);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(x => x.malzemeGrup.Id == stokKartFilter.malzemeGrup.Id).ToList(), ref cbxMalzemeAltGrup);

        }

        public void buttonEkle_Click(object sender, EventArgs e)
        {
            StokKartKayitFormu stokKartTanimlamaFormu = FormFactory.CreateForm<StokKartKayitFormu>();
            stokKartTanimlamaFormu.stokKart.malzemeGrup.Id = cbxMalzemeGrup.selectedDataRowId;
            stokKartTanimlamaFormu.stokKart.malzemeAltGrup.Id = cbxMalzemeAltGrup.selectedDataRowId;
            stokKartTanimlamaFormu.stokKart.malzemeAltGrup2.Id = cbxMalzemeAltGrup2.selectedDataRowId;
            if (stokKartTanimlamaFormu != null)
            {
                stokKartTanimlamaFormu.Show();
            }
        }

        private async void projeKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GridDoldur();
        }

        private void cbxStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.stokGrup.Id = cbxStokGrup.selectedDataRowId;
            StokKartDTO stokKartDTO = ConvertHelper.ToDTO<StokKartDTO>(stokKartFilter);
            universalGrid1.Filtrele(stokKartDTO,this.Name);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(x => x.stokGrup.Id == stokKartFilter.stokGrup.Id).ToList(), ref cbxMalzemeGrup);
        }

        private void cbxMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.malzemeAltGrup.Id = cbxMalzemeAltGrup.selectedDataRowId;
            StokKartDTO stokKartDTO = ConvertHelper.ToDTO<StokKartDTO>(stokKartFilter);
            universalGrid1.Filtrele(stokKartDTO, this.Name);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(x => x.malzemeAltGrup.Id == stokKartFilter.malzemeAltGrup.Id).ToList(), ref cbxMalzemeAltGrup2);
        }

        private void cbxMalzemeAltGrup2_DoubleClick(object sender, EventArgs e)
        {
            DIContainer.GetService<AnaVeriTanimlamaFormu<MalzemeAltGrup2>>();
            AnaVeriTanimlamaFormu<MalzemeAltGrup2> anaVeriTanimlamaFormu = AnaVeriTanimlamaFormu<MalzemeAltGrup2>.anaVeriTanimlamaFormu;
            if (anaVeriTanimlamaFormu != null) anaVeriTanimlamaFormu.Show();
        }

        private void cbxStokTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.stokTip.Id = cbxStokTip.selectedDataRowId;
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
                        var stokKartDTO = (StokKartDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
                        StokKart stokKart = ConvertHelper.ToEntity<StokKart>(stokKartDTO);
                        StokKartKayitFormu stokKartKayitFormu = FormFactory.CreateForm<StokKartKayitFormu>();
                        stokKartKayitFormu.UpdateMode(stokKart);
                        stokKartKayitFormu.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void StokKartGridForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }
    }

}
