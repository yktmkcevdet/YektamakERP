using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
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
        }
        private List<SatinalmaTeklifBaslikDTO> _satinalmaTeklifDTOs;
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
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult)[0];
                List<SatinalmaTeklifBaslik> satinalmaTeklifBasliks = _jsonConverter.ToModelList<SatinalmaTeklifBaslik>(result.result);
                foreach (var item in satinalmaTeklifBasliks.Where(x => (Double.TryParse(x.teklifTutar.tutar?.ToString(), out Double result1) ? x.teklifTutar.tutar : 0) == 0))
                {
                    satinalmaTeklifDTOs.Add(ConvertHelper.ToDTO<SatinalmaTeklifBaslikDTO>(item));
                }
                universalGrid1.SetData(satinalmaTeklifDTOs, this.Name);
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
            Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
            MessageBox.Show(result.result);
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
    }
}
