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
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(10, 307);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(704, 299);
            universalGrid1.TabIndex = 15;
            Controls.Add(universalGrid1);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
            fcbStokGrup.SetDataSource(_cache.stokGrups);
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups);

            Binding();
            universalGrid1.SetData(_cache.malzemeAltGrups.CastToDTO<MalzemeAltGrupDTO>().ToList(), this.Name);

        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            malzemeAltGrupDTO = (MalzemeAltGrupDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        private void Binding()
        {
            BindHelper.BindData(ctbMalzemeAltGrupId, malzemeAltGrupDTO, nameof(malzemeAltGrupDTO.Id));
            BindHelper.BindData(ctbMalzemeAltGrupKod, malzemeAltGrupDTO, nameof(malzemeAltGrupDTO.kod));
            BindHelper.BindData(ctbMalzemeAltGrupAd, malzemeAltGrupDTO, nameof(malzemeAltGrupDTO.ad));
            BindHelper.BindData(fcbStokGrup, malzemeAltGrupDTO, nameof(malzemeAltGrupDTO.malzemeGrupstokGrupId));
            BindHelper.BindData(fcbMalzemeGrup, malzemeAltGrupDTO, nameof(malzemeAltGrupDTO.malzemeGrupId));
        }
        public event EventHandler<object> AfterSave;
        private MalzemeAltGrupDTO _malzemeAltGrupDTO;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MalzemeAltGrupDTO malzemeAltGrupDTO
        {
            get { if (_malzemeAltGrupDTO == null) { _malzemeAltGrupDTO = new(); } return _malzemeAltGrupDTO; }
            set { _malzemeAltGrupDTO = value; Binding(); }
        }
        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                string jsonResult = _stokService.SaveMalzemeAltGrup(ConvertHelper.ToEntity<MalzemeAltGrup>(malzemeAltGrupDTO));
                if (jsonResult != null && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    var malzemeAltGrup = JsonConvert.DeserializeObject<List<MalzemeAltGrup>>(jsonResult)[0];
                    malzemeAltGrupDTO = ConvertHelper.ToDTO<MalzemeAltGrupDTO>(malzemeAltGrup);
                    _cache.malzemeAltGrups.Add(malzemeAltGrup);
                    AfterSave?.Invoke(sender, malzemeAltGrup);
                    universalGrid1.binding.Add(malzemeAltGrupDTO);
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
            var list = _cache.malzemeGrups.Where(m => m.stokGrup.Id == ((StokGrup)fcbStokGrup.SelectedItem).Id).ToList();
            fcbMalzemeGrup.SetDataSource(list);
            universalGrid1.Filtrele(malzemeAltGrupDTO);
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
            malzemeAltGrupDTO = null;
        }
        public void UpdateMode(MalzemeAltGrupDTO malzemeAltGrupDTO)
        {
            this.malzemeAltGrupDTO = malzemeAltGrupDTO;
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

        private void MalzemeAltGrupTanimFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private void malzemeGrubunuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var malzemeAltGrup = ConvertHelper.ToEntity<MalzemeAltGrup>(malzemeAltGrupDTO);
            string jsonResult = _stokService.DeleteMalzemeAltGrup(malzemeAltGrup);
            if (string.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(jsonResult, "Silme işleminde hata oluştu.");
            }
            else
            {
                _cache.malzemeAltGrups.Remove(_cache.malzemeAltGrups.FirstOrDefault(m => m.Id == malzemeAltGrup.Id));
                universalGrid1.binding.Remove(malzemeAltGrupDTO);
                AfterSave?.Invoke(this, malzemeAltGrupDTO);
            }
        }

        private void fcbMalzemeGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(malzemeAltGrupDTO);
        }
    }
}
