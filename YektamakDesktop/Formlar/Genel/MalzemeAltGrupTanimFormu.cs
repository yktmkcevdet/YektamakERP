using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class MalzemeAltGrupTanimFormu : Form
    {
        private readonly ICache _cache;
        private readonly IStokService _stokService;
        public MalzemeAltGrupTanimFormu(ICache cache, IStokService stokService)
        {
            _cache = cache;
            _stokService = stokService;
            Initialize();
        }
        private void Initialize()
        {
            InitializeComponent();
            fcbStokGrup.SetDataSource(_cache.stokGrups);
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups);
            Binding();
        }
        private void Binding()
        {
            BindHelper.BindData(ctbMalzemeAltGrupId, malzemeAltGrup, "Id");
            BindHelper.BindData(ctbMalzemeAltGrupKod, malzemeAltGrup, "kod");
            BindHelper.BindData(ctbMalzemeAltGrupAd, malzemeAltGrup, "ad");
            BindHelper.BindData(fcbStokGrup, malzemeAltGrup.malzemeGrup.stokGrup, "Id");
            BindHelper.BindData(fcbMalzemeGrup, malzemeAltGrup.malzemeGrup, "Id");
        }
        public event EventHandler<object> AfterSave;
        private MalzemeAltGrup _malzemeAltGrup;
        public MalzemeAltGrup malzemeAltGrup
        {
            get { if (_malzemeAltGrup == null) { _malzemeAltGrup = new(); } return _malzemeAltGrup; }
            set { _malzemeAltGrup = value; Binding(); }
        }
        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                string jsonResult = _stokService.SaveMalzemeAltGrup(malzemeAltGrup);
                if (jsonResult != null && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    malzemeAltGrup = JsonConvert.DeserializeObject<List<MalzemeAltGrup>>(jsonResult)[0];
                    _cache.malzemeAltGrups.Add(malzemeAltGrup);
                    AfterSave?.Invoke(sender,malzemeAltGrup);
                }
                else
                {
                    MessageBox.Show(jsonResult, "Hata");
                }
            }
        }
        private void fcbStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fcbStokGrup.SelectedIndex == -1) return;
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups.Where(m => m.stokGrup.Id.ToString() == fcbStokGrup.SelectedValue.ToString()).ToList());
        }
        private void MalzemeAltGrupTanimFormu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(this, e.Location);
            }
        }
        private void formuTemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            malzemeAltGrup = null;
        }
        public void UpdateMode(MalzemeAltGrup malzemeAltGrup)
        {
            this.malzemeAltGrup = malzemeAltGrup;
        }
        private bool CheckFields()
        {
            bool result = true;
            result = GlobalData.CheckField("*", ctbMalzemeAltGrupAd) && result;
            result = GlobalData.CheckField("*", ctbMalzemeAltGrupKod) && result;
            result = GlobalData.CheckField("*", fcbStokGrup) && result;
            result = GlobalData.CheckField("*", fcbMalzemeGrup) && result;
            return result;
        }
    }
}
