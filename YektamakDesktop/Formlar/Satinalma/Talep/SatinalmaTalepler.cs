using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepler : Form
    {
        private static ISatinalmaTalepService _satinalmaService;
        private static IJsonConverter _jsonConverter;
        private static ICache _cache;
        public SatinalmaTalepler(ISatinalmaTalepService satinalmaService, IJsonConverter jsonConverter, ICache cache)
        {
            _satinalmaService = satinalmaService;
            _jsonConverter = jsonConverter;
            _cache = cache;
            InitializeComponent();
            InitializeUniversalGrid();
        }

        private void InitializeUniversalGrid()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(0, 164);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1138, 424);
            universalGrid1.TabIndex = 13;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown1;
            Controls.Add(universalGrid1);
            Binding();
        }

        private async void Binding()
        {
            await universalGrid1.SetData(satinalmaTalepDTOs, this.Name, false);
        }

        private List<SatinalmaTalepDetayDTO> _satinalmaTalepDTOs;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<SatinalmaTalepDetayDTO> satinalmaTalepDTOs
        {
            get
            {
                if (_satinalmaTalepDTOs == null)
                {
                    _satinalmaTalepDTOs = new List<SatinalmaTalepDetayDTO>();
                }
                return _satinalmaTalepDTOs;
            }
            set
            {
                Binding();
                _satinalmaTalepDTOs = value;
            }
        }

        private SatinalmaTalep _satinalmaTalepFilter;
        private SatinalmaTalep satinalmaTalepFilter
        {
            get
            {
                if (_satinalmaTalepFilter == null)
                {
                    _satinalmaTalepFilter = new SatinalmaTalep();
                }
                return _satinalmaTalepFilter;
            }
            set { _satinalmaTalepFilter = value; }
        }
        private async void SatinalmaTalepler_Load(object sender, EventArgs e)
        {
            string jsonResult = await _satinalmaService.GetSatinalmaTalep(satinalmaTalepFilter);
            if (!String.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                List<SatinalmaTalep> satinalmaTaleps = _jsonConverter.DeserializeObject<List<SatinalmaTalep>>(jsonResult);
                List<SatinalmaTalepDTO> satinalmaTalepDTOs = new List<SatinalmaTalepDTO>();
                foreach (var item in satinalmaTaleps)
                {
                    satinalmaTalepDTOs.Add(ConvertHelper.ToDTO<SatinalmaTalepDTO>(item));
                }
                universalGrid1.SetData(satinalmaTalepDTOs, this.Name, false);
            }
        }
        private async void talebiOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            satinalmaTalepFilter = ConvertHelper.ToEntity<SatinalmaTalep>((SatinalmaTalepDTO)universalGrid1.binding.Current);
            satinalmaTalepFilter.onayKullanici.Id = _cache.kullanici.Id;
            string jsonResult = await _satinalmaService.SatinalmaTalepOnay(satinalmaTalepFilter);
            MessageBox.Show(jsonResult);
        }
        

        private void SatinalmaTalepler_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private void görüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTalepDTO = (SatinalmaTalepDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            SatinalmaTalep satinalmaTalep = ConvertHelper.ToEntity<SatinalmaTalep>(satinalmaTalepDTO);
            SatinalmaTalepKayitFormu satinalmaTalepKayitFormu = FormFactory.CreateForm<SatinalmaTalepKayitFormu>();
            satinalmaTalepKayitFormu.UpdateMode(satinalmaTalep);
            satinalmaTalepKayitFormu.Show();
        }

        private void universalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1.Grid, e.Location);
            }
        }

        private async void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTalepDTO = (SatinalmaTalepDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            SatinalmaTalep satinalmaTalep = ConvertHelper.ToEntity<SatinalmaTalep>(satinalmaTalepDTO);
            if (satinalmaTalep.talepEdenKullanici.Id != _cache.kullanici.Id)
            {
                MessageBox.Show("Bu talebi sadece talep eden silebilir.");
                return;
            }
            var onay = MessageBox.Show("Talebi silmek istediğinizden emin misiniz", "Talep Silme Onay", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                string jsonResult = await _satinalmaService.DeleteSatinalmaTalep(satinalmaTalep);
                if (!String.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(jsonResult);
                    universalGrid1.binding.RemoveAt(universalGrid1.Grid.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarısız" + jsonResult);
                }
            }
        }

        private async void talebiReddetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SatinalmaTalep satinalmaTalep = ConvertHelper.ToEntity<SatinalmaTalep>((SatinalmaTalepDTO)universalGrid1.binding.Current);
            satinalmaTalep.onayKullanici = _cache.kullanici;
            satinalmaTalep.onayDurum = false;
            string jsonResult = await _satinalmaService.SatinalmaTalepOnay(satinalmaTalep);
            if (jsonResult != null && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                universalGrid1.binding.RemoveAt(universalGrid1.Grid.CurrentRow.Index);
            }
            MessageBox.Show(jsonResult);
        }
    }
}
