using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepOnayFormu : Form
    {
        private readonly IJsonConverter _jsonConverter;
        private readonly ISatinalmaTalepService _satinalmaService;
        private readonly ICache _cache;
        public SatinalmaTalepOnayFormu(IJsonConverter jsonConverter, ISatinalmaTalepService satinalmaService, ICache cache)
        {
            _jsonConverter = jsonConverter;
            _satinalmaService = satinalmaService;
            _cache = cache;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1=DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(0, 125);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1094, 532);
            universalGrid1.TabIndex = 1;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown;
            Controls.Add(universalGrid1);
        }

        private SatinalmaTalepDTO _satinalmaTalepOnayDTO;
        public SatinalmaTalepDTO satinalmaTalepOnayDTO
        {
            get
            {
                if (_satinalmaTalepOnayDTO == null)
                {
                    _satinalmaTalepOnayDTO = new SatinalmaTalepDTO();
                }
                return _satinalmaTalepOnayDTO;
            }
            set
            {
                _satinalmaTalepOnayDTO = value;
            }
        }
        private SatinalmaTalepDTO _satinalmaTalepFilter;
        private SatinalmaTalepDTO satinalmaTalepFilter
        {
            get
            {
                if (_satinalmaTalepFilter == null)
                {
                    _satinalmaTalepFilter = new SatinalmaTalepDTO();
                }
                return _satinalmaTalepFilter;
            }
            set { _satinalmaTalepFilter = value; }
        }
        private List<SatinalmaTalepDTO> _satinalmaTalepOnayList;
        public List<SatinalmaTalepDTO> satinalmaTalepOnayList
        {
            get
            {
                if (_satinalmaTalepOnayList == null)
                {
                    _satinalmaTalepOnayList = new List<SatinalmaTalepDTO>();
                }
                return _satinalmaTalepOnayList;
            }
            set { _satinalmaTalepOnayList = value; }
        }
        private void SatinalmaTalepOnayFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }
        private async void SatinalmaTalepOnayFormu_Load(object sender, EventArgs e)
        {
            var jsonResult = await _satinalmaService.GetSatinalmaTalep(new SatinalmaTalep());
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            else
            {
                List<SatinalmaTalep> satinalmaTalep = _jsonConverter.DeserializeObject<List<SatinalmaTalep>>(jsonResult);
                foreach (var item in satinalmaTalep.Where(t => t.onayDurum == null))
                {
                    satinalmaTalepOnayList.Add(ConvertHelper.ToDTO<SatinalmaTalepDTO>(item));
                }
            }

            universalGrid1.SetData(satinalmaTalepOnayList, this.Name);
        }

        private async void talebiOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SatinalmaTalep satinalmaTalep = ConvertHelper.ToEntity<SatinalmaTalep>(satinalmaTalepOnayDTO);
            satinalmaTalep.onayKullanici = _cache.kullanici;
            satinalmaTalep.onayDurum = true;
            string jsonResult = await _satinalmaService.SatinalmaTalepOnay(satinalmaTalep);
            MessageBox.Show(jsonResult);
            if (!String.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                universalGrid1.binding.RemoveAt(universalGrid1.Grid.CurrentRow.Index);
            }
        }

        private void universalGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = universalGrid1.Grid.HitTest(e.X, e.Y);
            int rowIndex = hit.RowIndex;
            if (e.Button == MouseButtons.Right && rowIndex != -1)
            {
                universalGrid1.Grid.ClearSelection();
                universalGrid1.Grid.Rows[rowIndex].Selected = true;
                satinalmaTalepOnayDTO = satinalmaTalepOnayList[rowIndex];
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }
        

        private async void talebiReddetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SatinalmaTalep satinalmaTalep = ConvertHelper.ToEntity<SatinalmaTalep>(satinalmaTalepOnayDTO);
            satinalmaTalep.onayKullanici = _cache.kullanici;
            satinalmaTalep.onayDurum = false;
            string jsonResult = await _satinalmaService.SatinalmaTalepOnay(satinalmaTalep);
            MessageBox.Show(jsonResult);
            if (!String.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                universalGrid1.binding.RemoveAt(universalGrid1.Grid.CurrentRow.Index);
            }
        }

        private void talebiGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTalepDTO = (SatinalmaTalepDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            SatinalmaTalep satinalmaTalep = ConvertHelper.ToEntity<SatinalmaTalep>(satinalmaTalepDTO);
            SatinalmaTalepKayitFormu satinalmaTalepKayitFormu = FormFactory.CreateForm<SatinalmaTalepKayitFormu>();
            satinalmaTalepKayitFormu.UpdateMode(satinalmaTalep);
            satinalmaTalepKayitFormu.Show();
        }
    }
}
