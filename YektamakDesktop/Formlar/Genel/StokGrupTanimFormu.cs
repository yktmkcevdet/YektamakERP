using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class StokGrupTanimFormu : Form
    {
        private readonly ICache _cache;
        private readonly IStokService _stokService;
        public StokGrupTanimFormu(ICache cache, IStokService stokService)
        {
            _cache = cache;
            _stokService = stokService;
            Initialize();
        }
        private void Initialize()
        {
            InitializeComponent();
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new Point(0, 219);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(800, 232);
            universalGrid1.TabIndex = 3;
            Controls.Add(universalGrid1);
            Load += async (s, e) => await StokGrupTanimFormu_Load(s, e);
            universalGrid1.Grid.MouseClick += UniversalGrid1_MouseDown1;
            Binding();
        }
        public event EventHandler<object> AfterSave;
        private StokGrup _stokGrup;
        public StokGrup stokGrup
        {
            get { if (_stokGrup == null) { _stokGrup = new(); } return _stokGrup; }
            set { _stokGrup = value; Binding(); }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbStokGrupId, stokGrup, "Id");
            BindHelper.BindData(ctbStokGrupAd, stokGrup, "ad");
            BindHelper.BindData(ctbStokGrupKod, stokGrup, "kod");
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                stokGrup = (StokGrup)universalGrid1.Grid.CurrentRow.DataBoundItem;
            }
        }

        private async Task StokGrupTanimFormu_Load(object sender, EventArgs e)
        {
            await universalGrid1.SetData(_cache.stokGrups, this.Name);
        }

        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                string jsonResult = _stokService.SaveStokGrup(stokGrup);
                stokGrup = JsonConvert.DeserializeObject<List<StokGrup>>(jsonResult)[0];
                AfterSave?.Invoke(sender, stokGrup);
            }
        }
        public void UpdateMode(StokGrup stokGrup)
        {
            this.stokGrup = stokGrup;
        }
        private bool CheckFields()
        {
            bool result = true;
            result = GlobalData.CheckField("*", ctbStokGrupAd) && result;
            result = GlobalData.CheckField("*", ctbStokGrupKod) && result;
            return result;
        }
    }
}
