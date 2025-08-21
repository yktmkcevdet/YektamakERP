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
using System.ComponentModel;
using YektamakDesktop.CustomControls;
using Models.DTO;

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
            headerPanel1.Baslik = "Malzeme Alt Grup Tanımlama";
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Location = new System.Drawing.Point(37, 340);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(627, 409);
            universalGrid1.TabIndex = 16;
            Controls.Add(universalGrid1);
            this.Load += MalzemeAltGrup2TanimFormu_Load;

            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
            fcbStokGrup.SetDataSource(_cache.stokGrups);
            fcbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups);
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups);
            Binding();
        }

        private void MalzemeAltGrup2TanimFormu_Load(object sender, EventArgs e)
        {
            
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            malzemeAltGrup2 = (MalzemeAltGrup2)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        private void Binding()
        {
            BindHelper.BindData(ctbMalzemeAltGrup2Id, malzemeAltGrup2, nameof(malzemeAltGrup2.Id));
            BindHelper.BindData(ctbMalzemeAltGrup2Kod, malzemeAltGrup2, nameof(malzemeAltGrup2.kod));
            BindHelper.BindData(ctbMalzemeAltGrup2Ad, malzemeAltGrup2, nameof(malzemeAltGrup2.ad));
            BindHelper.BindData(fcbStokGrup, malzemeAltGrup2.malzemeAltGrup.malzemeGrup.stokGrup, nameof(malzemeAltGrup2.malzemeAltGrup.malzemeGrup.stokGrup.Id));
            BindHelper.BindData(fcbMalzemeGrup, malzemeAltGrup2.malzemeAltGrup.malzemeGrup, nameof(malzemeAltGrup2.malzemeAltGrup.malzemeGrup.Id));
            BindHelper.BindData(fcbMalzemeAltGrup, malzemeAltGrup2.malzemeAltGrup, nameof(malzemeAltGrup2.malzemeAltGrup.Id));
            universalGrid1.SetData(_cache.malzemeAltGrup2List, this.Name);
        }
        public event EventHandler<object> AfterSave;
        private MalzemeAltGrup2 _malzemeAltGrup2;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            universalGrid1.Filtrele(ConvertHelper.ToDTO<MalzemeAltGrup2DTO>(malzemeAltGrup2));
        }
        private void fcbMalzemeGrup_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (fcbMalzemeGrup.SelectedIndex == -1) return;
            fcbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups.Where(m => m.malzemeGrup.Id.ToString() == fcbMalzemeGrup.SelectedValue.ToString()).ToList());
            universalGrid1.Filtrele(ConvertHelper.ToDTO<MalzemeAltGrup2DTO>(malzemeAltGrup2));
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

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            malzemeAltGrup2 = new MalzemeAltGrup2();
        }

        private void fcbMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(ConvertHelper.ToDTO<MalzemeAltGrup2DTO>(malzemeAltGrup2));
        }
    }
}
