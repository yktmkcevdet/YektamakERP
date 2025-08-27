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
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(37, 283);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(913, 291);
            universalGrid1.TabIndex = 18;
            universalGrid1.MouseDown1 += universalGrid1_CellClick;
            universalGrid1.MouseDown1 += Grid_MouseDown1Click;
            Controls.Add(universalGrid1);

            universalGrid1.SetData(_cache.projes.CastToDTO<ProjeDTO>().ToList(), this.Name);
            fcbProjeTip.SetDataSource(_cache.projeTipList);
            fcbMarka.SetDataSource(_cache.markaList);
            fcbMarkaAltGrup.SetDataSource(_cache.markaAltGrupList);
            fcbMirasProje.SetDataSource(_cache.projes);
            Binding();
        }

        private void Grid_MouseDown1Click(object sender, MouseEventArgs e)
        {
            
        }
        private ProjeDTO _projeDTO;
        private ProjeDTO projeDTO
        {
            get
            {
                if (_projeDTO == null)
                {
                    _projeDTO = new();
                }
                return _projeDTO;
            }
            set
            {
                _projeDTO = value;
                Binding();
            }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbId, projeDTO, nameof(projeDTO.Id));
            BindHelper.BindData(fcbProjeTip, projeDTO, nameof(projeDTO.projeTipId));
            BindHelper.BindData(fcbMarka, projeDTO, nameof(projeDTO.markaId));
            BindHelper.BindData(ctbProjeNo, projeDTO, nameof(projeDTO.projeNo));
            BindHelper.BindData(fcbMirasProje, projeDTO, nameof(projeDTO.mirasProjeId));
            BindHelper.BindData(fcbMarkaAltGrup, projeDTO, nameof(projeDTO.markaAltGrupId));
            BindHelper.BindData(fcbMarkaAltGrupKategori, projeDTO, nameof(projeDTO.markaAltGrupKategoriId));
            BindHelper.BindData(ctbAd, projeDTO, nameof(projeDTO.ad));
            BindHelper.BindData(ctbAciklama, projeDTO, nameof(projeDTO.aciklama));
        }
        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            string jsonResult = _projeService.SaveProje(ConvertHelper.ToEntity<Proje>(projeDTO));
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Kaydederken hata: {jsonResult}");
            }
            else
            {
                if (projeDTO.Id == null)
                {
                    var proje = JsonConvert.DeserializeObject<List<Proje>>(jsonResult)[0];
                    _cache.projes.Add(proje);
                    universalGrid1.binding.Add(ConvertHelper.ToDTO<ProjeDTO>(proje));
                }
                else
                {
                    var proje = JsonConvert.DeserializeObject<List<Proje>>(jsonResult)[0];
                    _cache.projes.Where(p => p.Id == proje.Id).ToList().ForEach(p => p = proje);
                    universalGrid1.binding.Remove(universalGrid1.Grid.CurrentRow.DataBoundItem);
                    universalGrid1.binding.Add(projeDTO);
                }
            }
        }
        private void universalGrid1_CellClick(object sender, MouseEventArgs e)
        {
            projeDTO = (ProjeDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1.Grid, e.Location);
            }
        }

        private void projeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projeDTO = (ProjeDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            var proje = ConvertHelper.ToEntity<Proje>(projeDTO);
            string jsonResult = _projeService.DeleteProje(proje);
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Sonuç boş geldi.");
            }
            else
            {
                _cache.projes.Remove(_cache.projes.FirstOrDefault(p=>p.Id==proje.Id));
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            projeDTO = new();
        }
    }
}
