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
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Genel;

namespace YektamakDesktop.Formlar.Stok
{
    public partial class StokKartGridForm : Form
    {
        private readonly IStokService _stokService;
        private readonly ICache _cache;
        private readonly IJsonConverter _jsonConverter;
        private readonly IProjeService _projeService;
        public StokKartGridForm(ICache cache, IJsonConverter jsonConvertHelper, IStokService stokService, IProjeService projeService)
        {
            _stokService = stokService;
            _cache = cache;
            _jsonConverter = jsonConvertHelper;
            _projeService = projeService;
            InitializeComponent();
            InitializeGridForm();
        }
        private void InitializeGridForm()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.kullanici = _cache.kullanici; ;
            universalGrid1.Location = new System.Drawing.Point(12, 289);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1062, 503);
            universalGrid1.TabIndex = 129;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown1;
            Controls.Add(universalGrid1);
            ComboBoxListFill.GetLookupKod(_cache.projes, ref projeKodu);
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref clbStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref clbMalzemeGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List, ref clbMalzemeAltGrup2);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups, ref cbxMalzemeAltGrup);
            ComboBoxListFill.GetLookupAd(_cache.stokTips, ref cbxStokTip);
            Load += async (s, e) => await StokKartGridForm_Load(s, e);
            projeKodu.SelectedIndexChanged += async (s, e) => await projeKodu_SelectedIndexChanged(s, e);
            ctbParcaAdi.TextChanged += async (s, e) => await ctbParcaAdi_TextChanged(s, e);
        }

        private async Task ctbParcaAdi_TextChanged(object s, EventArgs e)
        {
            if (ctbParcaAdi.TextCustom.Length > 3)
            {
                stokKartFilter.stokKart.ad = ctbParcaAdi.TextCustom;
                stokKartFilter.stokKart.parcaAdi = ctbParcaAdi.TextCustom;
                stokKartFilter.stokKart.boyut = ctbParcaAdi.TextCustom;
                await GridDoldur();
            }
        }

        private List<ProjeStokKartDTO> _stokKartDTOs;
        public List<ProjeStokKartDTO> stokKartDTOs
        {
            get
            {
                if (_stokKartDTOs == null)
                {
                    _stokKartDTOs = new List<ProjeStokKartDTO>();
                }
                return _stokKartDTOs;
            }
            set
            {
                _stokKartDTOs = value;
            }
        }

        private List<ProjeStokKart> _stokKarts;
        private List<ProjeStokKart> stokKarts
        {
            get
            {
                if (_stokKarts == null)
                {
                    _stokKarts = new List<ProjeStokKart>();
                }
                return _stokKarts;
            }
            set
            {
                _stokKarts = value;
            }
        }

        private ProjeStokKart _stokKartFilter;
        private ProjeStokKart stokKartFilter
        {
            get
            {
                if (_stokKartFilter == null)
                {
                    _stokKartFilter = new ProjeStokKart();
                }
                return _stokKartFilter;
            }
            set { _stokKartFilter = value; }
        }

        private async Task GridDoldur()
        {
            this.Enabled = false;
            stokKarts.Clear();
            string jsonResult = await _projeService.GetProjeStokKart(stokKartFilter);
            Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult)[0];
            if (result.result != null)
            {
                stokKarts = JsonConvert.DeserializeObject<List<ProjeStokKart>>(result.result);
                List<ProjeStokKartDTO> pskDTOs = new List<ProjeStokKartDTO>();
                foreach (var sk in stokKarts)
                {
                    pskDTOs.Add(ConvertHelper.ToDTO<ProjeStokKartDTO>(sk));
                }
                stokKartDTOs = pskDTOs;
            }
            else
            {
                stokKartDTOs = null;
            }
            await universalGrid1.SetData(stokKartDTOs, this.Name, true);
            this.Enabled = true;
        }
        private void malzemeGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.stokKart.malzemeGrup.Id = int.Parse(clbMalzemeGrup.SelectedValue.ToString());
            ProjeStokKartDTO stokKartDTO = ConvertHelper.ToDTO<ProjeStokKartDTO>(stokKartFilter);
            universalGrid1.Filtrele(stokKartDTO);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(x => x.malzemeGrup.Id == stokKartFilter.stokKart.malzemeGrup.Id).ToList(), ref cbxMalzemeAltGrup);

        }

        public void buttonEkle_Click(object sender, EventArgs e)
        {
            StokKartKayitFormu stokKartTanimlamaFormu = FormFactory.CreateForm<StokKartKayitFormu>();
            if (clbMalzemeGrup.SelectedIndex != -1) stokKartTanimlamaFormu.projeStokKart.stokKart.malzemeGrup.Id = int.Parse(clbMalzemeGrup.SelectedValue.ToString());
            if (cbxMalzemeAltGrup.SelectedIndex != -1) stokKartTanimlamaFormu.projeStokKart.stokKart.malzemeAltGrup.Id = int.Parse(cbxMalzemeAltGrup.SelectedValue.ToString());
            if (clbMalzemeAltGrup2.SelectedIndex != -1) stokKartTanimlamaFormu.projeStokKart.stokKart.malzemeAltGrup2.Id = int.Parse(clbMalzemeAltGrup2.SelectedValue.ToString());
            if (stokKartTanimlamaFormu != null)
            {
                stokKartTanimlamaFormu.Show();
            }
        }

        private async Task projeKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.proje.Id = int.Parse(projeKodu.SelectedValue.ToString());
            await GridDoldur();
        }

        private void cbxStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.stokKart.stokGrup.Id = int.Parse(clbStokGrup.SelectedValue.ToString());
            ProjeStokKartDTO stokKartDTO = ConvertHelper.ToDTO<ProjeStokKartDTO>(stokKartFilter);
            universalGrid1.Filtrele(stokKartDTO);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(x => x.stokGrup.Id == stokKartFilter.stokKart.stokGrup.Id).ToList(), ref clbMalzemeGrup);
        }

        private void cbxMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.stokKart.malzemeAltGrup.Id = int.Parse(cbxMalzemeAltGrup.SelectedValue.ToString());
            ProjeStokKartDTO stokKartDTO = ConvertHelper.ToDTO<ProjeStokKartDTO>(stokKartFilter);
            universalGrid1.Filtrele(stokKartDTO);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(x => x.malzemeAltGrup.Id == stokKartFilter.stokKart.malzemeAltGrup.Id).ToList(), ref clbMalzemeAltGrup2);
        }

        private void cbxMalzemeAltGrup2_DoubleClick(object sender, EventArgs e)
        {
            DIContainer.GetService<AnaVeriTanimlamaFormu<MalzemeAltGrup2>>();
            AnaVeriTanimlamaFormu<MalzemeAltGrup2> anaVeriTanimlamaFormu = AnaVeriTanimlamaFormu<MalzemeAltGrup2>.anaVeriTanimlamaFormu;
            if (anaVeriTanimlamaFormu != null) anaVeriTanimlamaFormu.Show();
        }

        private void cbxStokTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.stokKart.stokTip.Id = int.Parse(cbxStokTip.SelectedValue.ToString());
            ProjeStokKartDTO stokKartDTO = ConvertHelper.ToDTO<ProjeStokKartDTO>(stokKartFilter);
            universalGrid1.Filtrele(stokKartDTO);
        }

        private void StokKartGridForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private async Task StokKartGridForm_Load(object sender, EventArgs e)
        {
            await universalGrid1.SetData(stokKartDTOs, this.Name, true);
        }

        private void stokKartınıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var proejStokKartDTO = (ProjeStokKartDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            ProjeStokKart projeStokKart = ConvertHelper.ToEntity<ProjeStokKart>(proejStokKartDTO);
            StokKartKayitFormu stokKartKayitFormu = FormFactory.CreateForm<StokKartKayitFormu>();
            stokKartKayitFormu.UpdateMode(projeStokKart);
            stokKartKayitFormu.Show();
        }

        private void universalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        private async void stokKartınıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var onay = MessageBox.Show("Stok Kart'ını silmek istediğinizden emin misiniz", "Silme Onay", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                var proejStokKartDTO = (ProjeStokKartDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
                ProjeStokKart projeStokKart = ConvertHelper.ToEntity<ProjeStokKart>(proejStokKartDTO);
                string jsonResult = await _projeService.DeleteProjeStokKart(projeStokKart);
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult)[0];
                if (result?.result != null && !result.result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    universalGrid1.binding.RemoveAt(universalGrid1.Grid.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Stok Kartı Silmede Hata:" + result.result, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

}
