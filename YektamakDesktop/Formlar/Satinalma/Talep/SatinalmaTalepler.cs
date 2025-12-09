using ApiService.Interfaces;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepler : Form
    {
        private static ISatinalmaTalepService _satinalmaService;
        private static IConvertHelper _convertHelper;
        private static ICache _cache;
        public SatinalmaTalepler(ISatinalmaTalepService satinalmaService, IConvertHelper convertHelper, ICache cache)
        {
            _satinalmaService = satinalmaService;
            _convertHelper = convertHelper;
            _cache = cache;
            InitializeComponent();
            InitializeUniversalGrid();
        }

        private void InitializeUniversalGrid()
        {
            int sizeX = universalGrid1.Size.Width;
            int sizeY = universalGrid1.Size.Height;
            int locationY = universalGrid1.Location.Y;
            int locationX = universalGrid1.Location.X;
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(sizeX, sizeY);
            universalGrid1.TabIndex = 13;
            Controls.Add(universalGrid1);
            universalGrid1.MouseDown1 += universalGrid1_MouseDown1;
            universalGrid1.SetData(new List<SatinalmaTalepDTO>(), this.Name);
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
        private List<SatinalmaTalepDTO> _satinalmaTalepDTO;
        private List<SatinalmaTalepDTO> satinalmaTalepDTO
        {
            get
            {
                if (_satinalmaTalepDTO == null)
                {
                    _satinalmaTalepDTO = new List<SatinalmaTalepDTO>();
                }
                return _satinalmaTalepDTO;
            }
            set { _satinalmaTalepDTO = value; }
        }
        private async void SatinalmaTalepler_Load(object sender, EventArgs e)
        {
            satinalmaTalepDTO = (await _satinalmaService.GetSatinalmaTalep(new SatinalmaTalep())).CastToDTO<SatinalmaTalepDTO>(_convertHelper).ToList();
            universalGrid1.SetData(satinalmaTalepDTO, this.Name);
        }
        private async void talebiOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            satinalmaTalepFilter = _convertHelper.ToEntity<SatinalmaTalep>((SatinalmaTalepDTO)universalGrid1.binding.Current);
            satinalmaTalepFilter.onayKullanici.Id = _cache.kullanici.Id;
            string jsonResult = await _satinalmaService.SatinalmaTalepOnay(satinalmaTalepFilter);
            MessageBox.Show(jsonResult);
        }


        private void SatinalmaTalepler_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveGridSettings();
        }

        private void görüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTalepDTO = (SatinalmaTalepDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            SatinalmaTalep satinalmaTalep = _convertHelper.ToEntity<SatinalmaTalep>(satinalmaTalepDTO);
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
            SatinalmaTalep satinalmaTalep = _convertHelper.ToEntity<SatinalmaTalep>(satinalmaTalepDTO);
            if (satinalmaTalep.talepEdenKullanici.Id != _cache.kullanici.Id)
            {
                MessageBox.Show("Talep, sadece talebi oluşturan tarafından silebilir.");
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
            SatinalmaTalep satinalmaTalep = _convertHelper.ToEntity<SatinalmaTalep>((SatinalmaTalepDTO)universalGrid1.binding.Current);
            satinalmaTalep.onayKullanici = _cache.kullanici;
            satinalmaTalep.onayDurum = false;
            string jsonResult = await _satinalmaService.SatinalmaTalepOnay(satinalmaTalep);
            if (jsonResult != null && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                universalGrid1.binding.RemoveAt(universalGrid1.Grid.CurrentRow.Index);
            }
            MessageBox.Show(jsonResult);
        }

        private void chkBenimTaleplerim_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void rbTumTalepler_CheckedChanged(object sender, EventArgs e)
        {
            filterOnayDurum = "";
            ApplyFilters();
        }

        private void rbReddedilenTalepler_CheckedChanged(object sender, EventArgs e)
        {
            filterOnayDurum = "false";
            ApplyFilters();
        }

        private void rdOnayBekleyenTalepler_CheckedChanged(object sender, EventArgs e)
        {
            filterOnayDurum = "null";
            ApplyFilters();
        }

        private void rbOnaylanmisTalepler_CheckedChanged(object sender, EventArgs e)
        {
            filterOnayDurum = "true";
            ApplyFilters();
        }
        private int? filterTalep;
        private string filterOnayDurum = "";
        private void panel1_DataContextChanged(object sender, EventArgs e)
        {
            //universalGrid1.SetData(satinalmaTalepDTO.Where(), this.Name);
            //if (rbActigimTalepler.Checked)
            //{
            //    universalGrid1.SetData(satinalmaTalepDTO.Where(s => s.onayKullaniciId == _cache.kullanici.Id).ToList(), this.Name);
            //}
            //else
            //{
            //    universalGrid1.SetData(satinalmaTalepDTO, this.Name);
            //}
        }

        private void rbActigimTalepler_CheckedChanged(object sender, EventArgs e)
        {
            filterTalep = 1;
            ApplyFilters();
        }

        private void rbOnaylayacagimTalepler_CheckedChanged(object sender, EventArgs e)
        {
            filterTalep = 2;
            ApplyFilters();
        }

        private void rbTumKullanic_CheckedChanged(object sender, EventArgs e)
        {
            filterTalep = null;
            ApplyFilters();
        }
        private void ApplyFilters()
        {
            bool? onayDurum=null;
            if(!string.IsNullOrEmpty(filterOnayDurum) && !filterOnayDurum.Contains("null")) onayDurum=Convert.ToBoolean(filterOnayDurum);
            universalGrid1.SetData(
            satinalmaTalepDTO.Where(x => (filterTalep==1?x.talepEdenKullaniciId==_cache.kullanici.Id:(filterTalep==2?x.onayKullaniciId==_cache.kullanici.Id:true)) &&
            x.onayDurum == (string.IsNullOrEmpty(filterOnayDurum) ? x.onayDurum : onayDurum)).ToList(),this.Name);
        }
    }
}
