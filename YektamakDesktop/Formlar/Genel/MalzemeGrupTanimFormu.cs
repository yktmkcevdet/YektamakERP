using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class MalzemeGrupTanimFormu : Form
    {
        private readonly ICache _cache;
        private readonly IStokService _stokService;
        private readonly IConvertHelper _convertHelper;
        public MalzemeGrupTanimFormu(ICache cache, IStokService stokService, IConvertHelper convertHelper)
        {
            _cache = cache;
            _stokService = stokService;
            InitializeComponent();
            Initialize();
            _convertHelper = convertHelper;
        }
        public event EventHandler<object> AfterSave;
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
            universalGrid1.SetData(new List<MalzemeGrupDTO>(), this.Name);
            headerPanel1.Baslik = "Malzeme Grup Tanımlama";
            this.Load += async (s, e) => await MalzemeGrupTanimFormu_Load(s, e);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
            fcbStokGrup.SetDataSource(_cache.stokGrups);
            Binding();
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            malzemeGrupDTO = (MalzemeGrupDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        private void Binding()
        {
            BindHelper.BindData(ctbMalzemeGrupId, malzemeGrupDTO, nameof(malzemeGrupDTO.Id));
            BindHelper.BindData(ctbMalzemeGrupKod, malzemeGrupDTO, nameof(malzemeGrupDTO.kod));
            BindHelper.BindData(ctbMalzemeGrupAd, malzemeGrupDTO, nameof(malzemeGrupDTO.ad));
            BindHelper.BindData(fcbStokGrup, malzemeGrupDTO,nameof(malzemeGrupDTO.stokGrupId));
        }
        private MalzemeGrupDTO _malzemeGrupDTO;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MalzemeGrupDTO malzemeGrupDTO
        {
            get { if (_malzemeGrupDTO == null) { _malzemeGrupDTO = new(); } return _malzemeGrupDTO; }
            set { _malzemeGrupDTO = value; Binding(); }
        }
        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                var malzemeGrup = _convertHelper.ToEntity<MalzemeGrup>(malzemeGrupDTO);
                string jsonResult = _stokService.SaveMalzemeGrup(malzemeGrup);
                malzemeGrup = JsonConvert.DeserializeObject<List<MalzemeGrup>>(jsonResult)[0];
                malzemeGrupDTO = _convertHelper.ToDTO<MalzemeGrupDTO>(malzemeGrup);
                universalGrid1.binding.Add(malzemeGrupDTO);
                _cache.malzemeGrups.Add(malzemeGrup);
                AfterSave?.Invoke(this, malzemeGrupDTO);
            }
        }

        private async Task MalzemeGrupTanimFormu_Load(object sender, EventArgs e)
        {
            await universalGrid1.SetData(_cache.malzemeGrups.CastToDTO<MalzemeGrupDTO>(_convertHelper).ToList(), this.Name);
        }
        public void UpdateMode(MalzemeGrupDTO malzemeGrup)
        {
            this.malzemeGrupDTO = malzemeGrup;
        }
        private bool CheckFields()
        {
            bool result = true;
            result = CheckFieldHelper.CheckField("*", ctbMalzemeGrupAd) && result;
            result = CheckFieldHelper.CheckField("*", ctbMalzemeGrupKod) && result;
            result = CheckFieldHelper.CheckField("*", fcbStokGrup) && result;
            return result;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            malzemeGrupDTO = new();
        }

        private void MalzemeGrupTanimFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveGridSettings();
            AfterSave?.Invoke(this, e);
        }

        private void malzemeGrubunuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"\"{malzemeGrupDTO.ad}\" grubunu silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string jsonResult = _stokService.DeleteMalzemeGrup(_convertHelper.ToEntity<MalzemeGrup>(malzemeGrupDTO));
            if (string.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(jsonResult, "Silme işleminde hata oluştu.");
            }
            else
            {
                _cache.malzemeGrups.Remove(_cache.malzemeGrups.FirstOrDefault(m => m.Id == malzemeGrupDTO.Id));
                universalGrid1.binding.Remove(malzemeGrupDTO);
                AfterSave?.Invoke(this, malzemeGrupDTO);
            }
        }

        private void fcbStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(malzemeGrupDTO);
        }
    }
}
