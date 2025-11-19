using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Satinalma.Siparis;
using YektamakDesktop.Formlar.Satinalma.Teklif;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTeklifTaleplerFormu : Form
    {
        private readonly ISatinalmaTeklifService _satinalmaTeklifService;
        private readonly IJsonConverter _jsonConverter;
        private readonly ICache _cache;
        public SatinalmaTeklifTaleplerFormu(ISatinalmaTeklifService satinalmaTeklifService, IJsonConverter jsonConverter, ICache cache)
        {
            _satinalmaTeklifService = satinalmaTeklifService;
            _jsonConverter = jsonConverter;
            _cache = cache;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(0, 164);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(959, 509);
            universalGrid1.TabIndex = 1;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown1;
            Controls.Add(universalGrid1);
            universalGrid1.SetData(new List<SatinalmaTeklifBaslikDTO>(), this.Name);
        }
        private List<SatinalmaTeklifBaslikDTO> _satinalmaTeklifDTOs;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<SatinalmaTeklifBaslikDTO> satinalmaTeklifDTOs
        {
            get
            {
                if (_satinalmaTeklifDTOs == null)
                {
                    _satinalmaTeklifDTOs = new();
                }
                return _satinalmaTeklifDTOs;
            }
            set
            {
                _satinalmaTeklifDTOs = value;
            }
        }
        private async void SatinalmaTeklifTaleplerFormu_Load(object sender, EventArgs e)
        {
            try
            {
                var jsonResult = await _satinalmaTeklifService.GetSatinalmaTeklif(new SatinalmaTeklifBaslik());
                if (string.IsNullOrEmpty(jsonResult))
                {
                    return;
                }
                else if (jsonResult.StartsWith("error"))
                {
                    MessageBox.Show(jsonResult);
                    return;
                }
                else
                {
                    List<SatinalmaTeklifBaslik> satinalmaTeklifBasliks = JsonConvert.DeserializeObject<List<SatinalmaTeklifBaslik>>(jsonResult);
                    foreach (var item in satinalmaTeklifBasliks)
                    {
                        satinalmaTeklifDTOs.Add(ConvertHelper.ToDTO<SatinalmaTeklifBaslikDTO>(item));
                    }
                    universalGrid1.SetData(satinalmaTeklifDTOs, this.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
        private void SatinalmaTeklifTaleplerFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private async void teklifTalebiniSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTeklifBaslikDTO = (SatinalmaTeklifBaslikDTO)universalGrid1.binding.Current;
            SatinalmaTeklifBaslik satinalmaTeklifBaslik = ConvertHelper.ToEntity<SatinalmaTeklifBaslik>(satinalmaTeklifBaslikDTO);
            string jsonResult = await _satinalmaTeklifService.DeleteSatinalmaTeklif(satinalmaTeklifBaslik);
            MessageBox.Show(jsonResult);
            universalGrid1.binding.RemoveAt(universalGrid1.Grid.CurrentRow.Index);
        }

        private void teklifTalebiniGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTeklifBaslikDTO = (SatinalmaTeklifBaslikDTO)universalGrid1.binding.Current;
            SatinalmaTeklifBaslik satinalmaTeklifBaslik = ConvertHelper.ToEntity<SatinalmaTeklifBaslik>(satinalmaTeklifBaslikDTO);
            SatinalmaTeklifKayitFormu satinalmaTeklifKayitFormu = FormFactory.CreateForm<SatinalmaTeklifKayitFormu>();
            satinalmaTeklifKayitFormu.UpdateMode(satinalmaTeklifBaslik);
            satinalmaTeklifKayitFormu.ShowDialog();
        }

        private void universalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var satinalmaTeklifBaslikDTO = (SatinalmaTeklifBaslikDTO)universalGrid1.binding.Current;
            SatinalmaTeklifBaslik satinalmaTeklifBaslik = ConvertHelper.ToEntity<SatinalmaTeklifBaslik>(satinalmaTeklifBaslikDTO);
            SatinalmaSiparis satinalmaSiparis = new SatinalmaSiparis();
            satinalmaSiparis.siparisTarihi = DateTime.Today;
            satinalmaSiparis.tutar = satinalmaTeklifBaslik.teklifTutar;
            satinalmaSiparis.firma = satinalmaTeklifBaslik.teklifFirma;
            satinalmaSiparis.aciklama = satinalmaTeklifBaslik.aciklama;
            satinalmaSiparis.vade = satinalmaTeklifBaslik.vade;
            satinalmaSiparis.tutar = satinalmaTeklifBaslik.teklifTutar;
            satinalmaSiparis.dovizCinsi = satinalmaTeklifBaslik.dovizCinsi;
            foreach (var item in satinalmaTeklifBaslik.satinalmaTeklifDetayList)
            {
                SatinalmaSiparisDetay satinalmaSiparisDetay = new SatinalmaSiparisDetay();
                satinalmaSiparisDetay.miktar = item.satinalmaTalepDetay.miktar;
                satinalmaSiparisDetay.aciklama = item.satinalmaTalepDetay.aciklama;
                satinalmaSiparisDetay.birimFiyat = item.birimFiyat;
                satinalmaSiparisDetay.projeStokKart = item.satinalmaTalepDetay.projeStokKart;
                satinalmaSiparis.satinalmaSiparisDetay.Add(satinalmaSiparisDetay);
            }
            var satinalmaSiparisKayitFormu = FormFactory.CreateForm<SatinalmaSiparisKayitFormu>();
            satinalmaSiparisKayitFormu.UpdateMode(satinalmaSiparis);
            satinalmaSiparisKayitFormu.ShowDialog();
        }
    }
}
