using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Satinalma.Teklif;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTekliflerFormu : Form
    {
        private readonly ISatinalmaTeklifService _satinalmaTeklifService;
        private readonly ICache _cache;
        public SatinalmaTekliflerFormu(ISatinalmaTeklifService satinalmaTeklifService, IJsonConverter jsonConverter, ICache cache)
        {
            _satinalmaTeklifService = satinalmaTeklifService;
            _cache = cache;
            InitializeComponent();
            Initialize();

        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(0, 200);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(959, 473);
            universalGrid1.TabIndex = 1;
            Controls.Add(universalGrid1);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1; ;
            ComboBoxListFill.GetLookupKod(_cache.projes, ref clbProjeKod);
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref clbStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref clbMalzemeGrup);
            clbProjeKod.DisplayMember = "kod";
            Load += async (s, e) => await SatinalmaTeklifTaleplerFormu_Load(s, e);
            FormClosing += async (s, e) => await SatinalmaTeklifTaleplerFormu_FormClosing(s, e);
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            satinalmaTeklifDTO = (SatinalmaTeklifBaslikDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        private SatinalmaTeklifBaslikDTO _satinalmaTeklifDTO;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SatinalmaTeklifBaslikDTO satinalmaTeklifDTO
        {
            get
            {
                if (_satinalmaTeklifDTO == null)
                {
                    _satinalmaTeklifDTO = new();
                }
                return _satinalmaTeklifDTO;
            }
            set
            {
                _satinalmaTeklifDTO = value;
            }
        }
        private async Task SatinalmaTeklifTaleplerFormu_Load(object sender, EventArgs e)
        {
            try
            {
                var jsonResult = await _satinalmaTeklifService.GetSatinalmaTeklif(new SatinalmaTeklifBaslik());
                var satinalmaTeklifBasliks = JsonConvert.DeserializeObject<List<SatinalmaTeklifBaslik>>(jsonResult);
                
                await universalGrid1.SetData(satinalmaTeklifBasliks.CastToDTO<SatinalmaTeklifBaslikDTO>().ToList(), this.Name, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
        private async Task SatinalmaTeklifTaleplerFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            await universalGrid1.SaveSettings();
        }

        private void teklifiGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SatinalmaTeklifKayitFormu teklifKayitFormu = FormFactory.CreateForm<SatinalmaTeklifKayitFormu>();
            teklifKayitFormu.UpdateMode(ConvertHelper.ToEntity<SatinalmaTeklifBaslik>(satinalmaTeklifDTO));
            teklifKayitFormu.ShowDialog();
        }
    }
}
