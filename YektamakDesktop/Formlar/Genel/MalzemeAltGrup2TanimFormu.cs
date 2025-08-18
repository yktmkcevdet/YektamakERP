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
    public partial class MalzemeAltGrup2TanimFormu : Form
    {
        private readonly ICache _cache;
        private readonly IStokService _stokService;
        public MalzemeAltGrup2TanimFormu(ICache cache, IStokService stokService)
        {
            _cache = cache;
            _stokService = stokService;
            Initialize();
        }
        private void Initialize()
        {
            InitializeComponent();

            fcbStokGrup.SetDataSource(_cache.stokGrups);
            fcbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups);
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups);
            Binding();
        }
        private void Binding()
        {
            BindHelper.BindData(ctbMalzemeAltGrup2Id, malzemeAltGrup2, "Id");
            BindHelper.BindData(ctbMalzemeAltGrup2Kod, malzemeAltGrup2, "kod");
            BindHelper.BindData(ctbMalzemeAltGrup2Ad, malzemeAltGrup2, "ad");
            BindHelper.BindData(fcbStokGrup, malzemeAltGrup2.malzemeAltGrup.malzemeGrup.stokGrup, "Id");
            BindHelper.BindData(fcbMalzemeGrup, malzemeAltGrup2.malzemeAltGrup.malzemeGrup, "Id");
            BindHelper.BindData(fcbMalzemeAltGrup, malzemeAltGrup2.malzemeAltGrup, "Id");
        }
        public event EventHandler<object> AfterSave;
        private MalzemeAltGrup2 _malzemeAltGrup2;
        public MalzemeAltGrup2 malzemeAltGrup2
        {
            get { if (_malzemeAltGrup2 == null) { _malzemeAltGrup2 = new(); } return _malzemeAltGrup2; }
            set { _malzemeAltGrup2 = value; Binding(); }
        }
        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                string jsonResult = _stokService.SaveMalzemeAltGrup2(malzemeAltGrup2);
                if (jsonResult != null && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    malzemeAltGrup2 = JsonConvert.DeserializeObject<List<MalzemeAltGrup2>>(jsonResult)[0];
                    _cache.malzemeAltGrup2List.Add(malzemeAltGrup2);
                    AfterSave?.Invoke(this, malzemeAltGrup2);
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
        private void fcbMalzemeGrup_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (fcbMalzemeGrup.SelectedIndex == -1) return;
            fcbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups.Where(m => m.malzemeGrup.Id.ToString() == fcbMalzemeGrup.SelectedValue.ToString()).ToList());
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
            malzemeAltGrup2 = null;
        }
        public void UpdateMode(MalzemeAltGrup2 malzemeAltGrup2)
        {
            this.malzemeAltGrup2 = malzemeAltGrup2;
        }
        private bool CheckFields()
        {
            bool result = true;
            result = GlobalData.CheckField("*", ctbMalzemeAltGrup2Ad) && result;
            result = GlobalData.CheckField("*", ctbMalzemeAltGrup2Kod) && result;
            result = GlobalData.CheckField("*", fcbStokGrup) && result;
            result = GlobalData.CheckField("*", fcbMalzemeGrup) && result;
            result = GlobalData.CheckField("*", fcbMalzemeAltGrup) && result;
            return result;
        }
    }
}
