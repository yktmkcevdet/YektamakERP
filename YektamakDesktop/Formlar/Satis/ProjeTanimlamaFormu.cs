using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class ProjeTanimlamaFormu : Form
    {
        private readonly ICache _cache;
        private readonly IProjeService _projeService;
        private readonly IJsonConverter _jsonConverter;
        public ProjeTanimlamaFormu(ICache cache, IProjeService projeService, IJsonConverter jsonConverter)
        {
            _cache = cache;
            _projeService = projeService;
            _jsonConverter = jsonConverter;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
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
            universalGrid1.MouseDown1 += universalGrid1_CellClick;

            universalGrid1.SetData(new List<ProjeDTO>(), this.Name);
            universalGrid1.SetData(_cache.projes
                .GroupBy(p => new { p.Id })
                .Select(g => ConvertHelper.ToDTO<ProjeDTO>(g.First())).ToList(), this.Name);
            fcbProjeTip.SetDataSource(_cache.projeTipList);
            fcbMarka.SetDataSource(_cache.markaList);
            fcbMarkaAltGrup.SetDataSource(_cache.markaAltGrupList);
            fcbMirasProje.SetDataSource(_cache.projes);
            Binding();
        }
        private Proje _proje;
        private Proje proje
        {
            get
            {
                if (_proje == null)
                {
                    _proje = new();
                }
                return _proje;
            }
            set
            {
                _proje = value;
                Binding();
            }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbId, proje, nameof(proje.Id));
            BindHelper.BindData(fcbProjeTip, proje.projeTip, nameof(proje.projeTip.Id));
            BindHelper.BindData(fcbMarka, proje.marka, nameof(proje.marka.Id));
            BindHelper.BindData(ctbProjeNo, proje, nameof(proje.projeNo));
            BindHelper.BindData(fcbMirasProje, proje, nameof(proje.mirasProjeId));
            BindHelper.BindData(fcbMarkaAltGrup, proje.markaAltGrup, nameof(proje.markaAltGrup.Id));
            BindHelper.BindData(fcbMarkaAltGrupKategori, proje.markaAltGrupKategori, nameof(proje.markaAltGrupKategori.Id));
            BindHelper.BindData(ctbAd, proje, nameof(proje.ad));
            BindHelper.BindData(ctbAciklama, proje, nameof(proje.aciklama));
            
        }
        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            //string jsonResultMarka = _projeService.GetMarka();
            //proje.marka = _jsonConverter.DeserializeObject<List<Marka>>(jsonResultMarka).FirstOrDefault(m => m.Id == proje.marka.Id);
            string jsonResult = _projeService.SaveProje(proje);
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Kaydederken hata: {jsonResult}");
            }
            else
            {
                if (proje.Id == null)
                {
                    proje = JsonConvert.DeserializeObject<List<Proje>>(jsonResult)[0];
                    _cache.projes.Add(proje);
                    universalGrid1.binding.Add(ConvertHelper.ToDTO<ProjeDTO>(proje));
                }
                else
                {
                    proje = JsonConvert.DeserializeObject<List<Proje>>(jsonResult)[0];
                    _cache.projes.Where(p => p.Id == proje.Id).ToList().ForEach(p => p = proje);
                    universalGrid1.binding.Remove(universalGrid1.Grid.CurrentRow.DataBoundItem);
                    universalGrid1.binding.Add(ConvertHelper.ToDTO<ProjeDTO>(proje));
                }
            }
        }
        private void universalGrid1_CellClick(object sender, MouseEventArgs e)
        {
            proje = ConvertHelper.ToEntity<Proje>(((ProjeDTO)universalGrid1.Grid.CurrentRow.DataBoundItem));
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1.Grid, e.Location);
            }
        }

        private void projeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var projeDTO = (ProjeDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            proje = ConvertHelper.ToEntity<Proje>(projeDTO);
            string jsonResult = _projeService.DeleteProje(proje);
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Sonuç boş geldi.");
            }
            else
            {
                proje = new();
                universalGrid1.binding.Remove(projeDTO);
                _cache.projes.Remove(_cache.projes.FirstOrDefault(p => p.Id == proje.Id));
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            proje = new();
        }

        private void ProjeTanimlamaFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }
    }
}
