using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class MalzemeGrupTanimFormu : Form
    {
        private readonly ICache _cache;
        private readonly IStokService _stokService;
        public MalzemeGrupTanimFormu(ICache cache, IStokService stokService)
        {
            _cache = cache;
            _stokService = stokService;
            Initialize();
        }
        public event EventHandler<object> AfterSave;
        private void Initialize()
        {
            InitializeComponent();
            fcbStokGrup.SetDataSource(_cache.stokGrups);
            Load += async (s, e) => await MalzemeGrupTanimFormu_Load(s, e);
            Binding();
        }
        private void Binding()
        {
            BindHelper.BindData(ctbMalzemeGrupId, malzemeGrup, "Id");
            BindHelper.BindData(ctbMalzemeGrupKod, malzemeGrup, "kod");
            BindHelper.BindData(ctbMalzemeGrupAd, malzemeGrup, "ad");
            BindHelper.BindData(fcbStokGrup, malzemeGrup.stokGrup, "Id");
        }
        private MalzemeGrup _malzemeGrup;
        public MalzemeGrup malzemeGrup
        {
            get { if (_malzemeGrup == null) { _malzemeGrup = new(); } return _malzemeGrup; }
            set { _malzemeGrup = value; Binding(); }
        }
        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                string jsonResult =  _stokService.SaveMalzemeGrup(malzemeGrup);
                malzemeGrup = JsonConvert.DeserializeObject<List<MalzemeGrup>>(jsonResult)[0];
                _cache.malzemeGrups.Add(malzemeGrup);
                AfterSave?.Invoke(this, malzemeGrup);
            }
        }

        private async Task MalzemeGrupTanimFormu_Load(object sender, EventArgs e)
        {
        }
        public void UpdateMode(MalzemeGrup malzemeGrup)
        {
            this.malzemeGrup=malzemeGrup;
        }
        private bool CheckFields()
        {
            bool result = true;
            result = GlobalData.CheckField("*", ctbMalzemeGrupAd) && result;
            result = GlobalData.CheckField("*", ctbMalzemeGrupKod) && result;
            result = GlobalData.CheckField("*", fcbStokGrup) && result;
            return result;
        }
    }
}
