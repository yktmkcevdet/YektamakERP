using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Helpers;

namespace YektamakDesktop.Formlar.Projemodul
{
    public partial class ProjeSorumlusuAtamaFormu : Form
    {
        private readonly ICache _cache;
        private readonly IProjeService _projeService;
        private readonly IConvertHelper _convertHelper;
        public ProjeSorumlusuAtamaFormu(IProjeService projeService, ICache cache, IConvertHelper convertHelper)
        {
            _cache = cache;
            _projeService = projeService;
            InitializeComponent();
            Initialize();
            _convertHelper = convertHelper;
        }
        private void Initialize()
        {
            UniversalGridHelper.Replace(ref universalGrid1, this);
            universalGrid1.SetData(new List<ProjeSorumluDTO>(), this.Name);
            Load += async (s, e) => await ProjeSorumlusuAtama_Load(s, e);
            universalGrid1.Grid.MouseClick += Grid_MouseClick;
            customButtonSave1.SaveButtonClick += async (s, e) => await customButtonSave1_SaveButtonClick(s,e);
            fcbPersonel.DisplayMember = "adSoyad";
            fcbProje.DisplayMember = "kod";
            fcbProje.SetDataSource(_cache.projeList.GroupBy(x => new { x.Id,x.kod}).Select(g=>g.First()).ToList());
            fcbPersonel.SetDataSource(_cache.personelList);
            Binding();
        }

        private void Grid_MouseClick(object sender, MouseEventArgs e)
        {
           projeSorumluDTO = (ProjeSorumluDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
        }

        private async Task ProjeSorumlusuAtama_Load(object sender, EventArgs e)
        {
            string jsonResult = await _projeService.GetProjeSorumlu(_convertHelper.ToEntity<ProjeSorumlu>(projeSorumluDTO));
            List<ProjeSorumlu> projeSorumluList = JsonConvert.DeserializeObject<List<ProjeSorumlu>>(jsonResult);
            await universalGrid1.SetData(projeSorumluList.CastToDTO<ProjeSorumluDTO>(_convertHelper).ToList(), this.Name);
        }

        private ProjeSorumluDTO _projeSorumluDTO;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProjeSorumluDTO projeSorumluDTO
        {
            get
            {
                if (_projeSorumluDTO == null) { _projeSorumluDTO = new(); }
                return _projeSorumluDTO;
            }
            set
            {
                _projeSorumluDTO = value;
                Binding();
            }
        }

        private void Binding()
        {
            BindHelper.BindData(ctbId, projeSorumluDTO, nameof(projeSorumluDTO.Id));
            BindHelper.BindData(fcbProje, projeSorumluDTO, nameof(projeSorumluDTO.projeId));
            BindHelper.BindData(fcbPersonel, projeSorumluDTO, nameof(projeSorumluDTO.personelId));
        }

        private async Task customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            var jsonResult=await _projeService.SaveProjeSorumlu(_convertHelper.ToEntity<ProjeSorumlu>(projeSorumluDTO));
            if (jsonResult == null || jsonResult.Contains("erro", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(jsonResult, "Hata");
            }
            else
            {
                projeSorumluDTO=JsonConvert.DeserializeObject<List<ProjeSorumluDTO>>(jsonResult)[0];
            }
        }
        private void RoundedButton1_Click(object sender, System.EventArgs e)
        {
            projeSorumluDTO = new();
        }
    }
}
