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
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(37, 283);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(913, 291);
            universalGrid1.TabIndex = 18;
            universalGrid1.Grid.MouseClick += universalGrid1_CellClick;
            universalGrid1.MouseDown1 += Grid_MouseDown1Click;

            Controls.Add(universalGrid1);
            foreach (var proje in _cache.projes)
            {
                projeDTOs.Add(ConvertHelper.ToDTO<ProjeDTO>(proje));
            }
            universalGrid1.SetData(projeDTOs, this.Name);
            fcbProjeTip.SetDataSource(_cache.projeTipList);
            fcbMarka.SetDataSource(_cache.markaList);
            fcbMarkaAltGrup.SetDataSource(_cache.markaAltGrupList);
            fcbMirasProje.SetDataSource(_cache.projes);
            Binding();
        }

        private void Grid_MouseDown1Click(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Show(universalGrid1.Grid, e.Location);
        }

        private List<ProjeDTO> _projeDTOs;
        public List<ProjeDTO> projeDTOs
        {
            get
            {
                if (_projeDTOs == null)
                {
                    _projeDTOs = new List<ProjeDTO>();
                }
                return _projeDTOs;
            }
            set
            {
                _projeDTOs = value;
                Binding();
            }
        }
        private Proje _proje;
        private Proje proje
        {
            get
            {
                if (_proje == null)
                {
                    _proje = new Proje();
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
            BindHelper.BindData(ctbId, proje, "Id");
            BindHelper.BindData(fcbProjeTip, proje.projeTip, "Id");
            BindHelper.BindData(fcbMarka, proje.marka, "Id");
            BindHelper.BindData(ctbProjeNo, proje, "projeNo");
        }
        private void ProjeTanimlamaFormu_Load(object sender, EventArgs e)
        {

        }
        

        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            string jsonResult = _projeService.SaveProje(proje);
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Kaydederken hata: {jsonResult}");
            }
            else
            {
                proje = JsonConvert.DeserializeObject<List<Proje>>(jsonResult)[0];
                projeDTOs.Add(ConvertHelper.ToDTO<ProjeDTO>(proje));
            }
        }

        private void universalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {

        }
        private void universalGrid1_CellClick(object sender, MouseEventArgs e)
        {
            try
            {
                ProjeDTO projeDTO = (ProjeDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
                proje = ConvertHelper.ToEntity<Proje>(projeDTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void projeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjeDTO projeDTO = (ProjeDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            proje = ConvertHelper.ToEntity<Proje>(projeDTO);
            string jsonResult = _projeService.DeleteProje(proje);
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Sonuç boş geldi.");
            }
            else
            {
                _cache.projes.Remove(proje);
                projeDTOs.Remove(projeDTO);
            }
        }
    }
}
