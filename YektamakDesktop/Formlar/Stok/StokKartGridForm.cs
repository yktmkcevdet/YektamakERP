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
            Binding();
            Load += async (s, e) => await StokKartGridForm_Load(s, e);
            projeKodu.SelectedIndexChanged += async (s, e) => await projeKodu_SelectedIndexChanged(s, e);
            stokKartınıSilToolStripMenuItem.Click += async (s, e) => await stokKartınıSilToolStripMenuItem_Click(s,e);

            ctbParcaAdi.TextChanged += ctbParcaAdi_TextChanged;
        }

        private void ctbParcaAdi_TextChanged(object s, EventArgs e)
        {
            if (ctbParcaAdi.TextCustom.Length > 2)
            {
                stokKartFilter.stokKart.ad = ctbParcaAdi.TextCustom;
                //stokKartFilter.stokKart.parcaAdi = ctbParcaAdi.TextCustom;
                //stokKartFilter.stokKart.boyut = ctbParcaAdi.TextCustom;
            }
            else
            {
                stokKartFilter.stokKart.ad = null;
                //stokKartFilter.stokKart.parcaAdi = String.Empty;
                //stokKartFilter.stokKart.boyut = String.Empty;
            }
            GridYenile();
        }

        private List<ProjeStokKartDTO> _stokKartDTOs;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            if (!String.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                stokKarts = JsonConvert.DeserializeObject<List<ProjeStokKart>>(jsonResult);
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
            GridYenile();
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(x => x.malzemeGrup.Id == stokKartFilter.stokKart.malzemeGrup.Id).ToList(), ref cbxMalzemeAltGrup);

        }

        private void GridYenile()
        {
            ProjeStokKartDTO stokKartDTO = ConvertHelper.ToDTO<ProjeStokKartDTO>(stokKartFilter);
            universalGrid1.Filtrele(stokKartDTO);
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
        private void Binding()
        {
            projeKodu.DataBindings.Add("SelectedValue", stokKartFilter, "proje.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            clbStokGrup.DataBindings.Add("SelectedValue", stokKartFilter.stokKart.stokGrup, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeGrup.DataBindings.Add("SelectedValue", stokKartFilter.stokKart.malzemeGrup, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            cbxMalzemeAltGrup.DataBindings.Add("SelectedValue", stokKartFilter.stokKart.malzemeAltGrup, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeAltGrup2.DataBindings.Add("SelectedValue", stokKartFilter.stokKart.malzemeAltGrup2, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            cbxStokTip.DataBindings.Add("SelectedValue", stokKartFilter.stokKart.stokTip, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private async Task projeKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //stokKartFilter.proje.Id = int.TryParse(projeKodu.SelectedValue.ToString(),out int projeId)?projeId:null;
            await GridDoldur();
        }

        private void cbxStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridYenile();
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(x => x.stokGrup.Id == stokKartFilter.stokKart.stokGrup.Id).ToList(), ref clbMalzemeGrup);
        }

        private void cbxMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridYenile();
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(x => x.malzemeAltGrup.Id == stokKartFilter.stokKart.malzemeAltGrup.Id).ToList(), ref clbMalzemeAltGrup2);
        }

        private void cbxMalzemeAltGrup2_DoubleClick(object sender, EventArgs e)
        {
            DIContainer.GetService<AnaVeriTanimlamaFormu<MalzemeAltGrup2>>();
            AnaVeriTanimlamaFormu<MalzemeAltGrup2> anaVeriTanimlamaFormu = FormFactory.CreateForm<AnaVeriTanimlamaFormu<MalzemeAltGrup2>>();
            if (anaVeriTanimlamaFormu != null) anaVeriTanimlamaFormu.Show();
        }

        private void cbxStokTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridYenile();
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

        private async Task stokKartınıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Seçilen kayıtlar silinecektir. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                List<ProjeStokKartDTO> projeStokKartDTOs = universalGrid1.GetCheckedRows<ProjeStokKartDTO>();
                for (int i = 0; i < projeStokKartDTOs.Count; i++)
                {
                    var item = projeStokKartDTOs[i];
                    if (_cache.projes.Any(p => p.personel.Id == _cache.kullanici.personel.Id && p.Id == item.Id))
                    {
                        MessageBox.Show($"{item.projekod} koduna ait stok kartını silemezsiniz");
                    }
                    else
                    {
                        string jsonResult = await _projeService.DeleteProjeStokKart(ConvertHelper.ToEntity<ProjeStokKart>(item));
                        if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show($"{item.stokKartkod} silinirken hata oluştu: {jsonResult}");
                            return;
                        }
                        else
                        {
                            projeStokKartDTOs.Remove(item);
                        }
                    }
                }
                universalGrid1.SetData(projeStokKartDTOs, this.Name, true);
            }
        }
    }
}
