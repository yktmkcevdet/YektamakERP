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
            int sizeX = universalGrid1.Size.Width;
            int sizeY = universalGrid1.Size.Height;
            int locationY = universalGrid1.Location.Y;
            int locationX = universalGrid1.Location.X;
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(sizeX, sizeY);
            universalGrid1.TabIndex = 13;
            Controls.Add(universalGrid1);
            universalGrid1.SetData(new List<StokGrup>(), this.Name);
            Load += async (s, e) => await StokGrupTanimFormu_Load(s, e);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
            Binding();
        }
        public event EventHandler<object> AfterSave;
        private StokGrup _stokGrup;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StokGrup stokGrup
        {
            get { if (_stokGrup == null) { _stokGrup = new(); } return _stokGrup; }
            set { _stokGrup = value; Binding(); }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbStokGrupId, stokGrup, nameof(stokGrup.Id));
            BindHelper.BindData(ctbStokGrupAd, stokGrup, nameof(stokGrup.ad));
            BindHelper.BindData(ctbStokGrupKod, stokGrup, nameof(stokGrup.kod));
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            stokGrup = (StokGrup)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (e.Button == MouseButtons.Right)
            {
                ctxMenu.Show(universalGrid1, e.Location);
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
                universalGrid1.binding.Add(stokGrup);
                AfterSave?.Invoke(sender, e);
            }
        }
        public void UpdateMode(StokGrup stokGrup)
        {
            this.stokGrup = stokGrup;
        }
        private bool CheckFields()
        {
            bool result = true;
            result = CheckFieldHelper.CheckField("*", ctbStokGrupAd) && result;
            result = CheckFieldHelper.CheckField("*", ctbStokGrupKod) && result;
            return result;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            stokGrup = new();
        }

        private void stokGrubunuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"\"{stokGrup.ad}\" grubunu silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string jsonResult = _stokService.DeleteStokGrup(stokGrup);
            if (string.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Silme işleminde hata oluştu");
            }
            else
            {
                MessageBox.Show(jsonResult);
                universalGrid1.binding.Remove(_cache.stokGrups.FirstOrDefault(s => s.Id == stokGrup.Id));
                AfterSave?.Invoke(sender, stokGrup);
            }
        }

        private void StokGrupTanimFormu_FormClosing(object sender, FormClosedEventArgs e)
        {
            universalGrid1.SaveSettings();
        }
    }
}
