using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma.Siparis
{
    public partial class SatinalmaSiparisler : Form
    {
        private readonly ICache _cache;
        private readonly ISatinalmaSiparisService _satinalmaSiparisService;
        private readonly IJsonConverter _jsonConverter;
        public SatinalmaSiparisler(ICache cache, ISatinalmaSiparisService satinalmaSiparisService, IJsonConverter jsonConverter)
        {
            _cache = cache;
            _satinalmaSiparisService = satinalmaSiparisService;
            _jsonConverter = jsonConverter;
            InitializeComponent();
            Initialize();
            Binding();
        }
        private SatinalmaSiparis _satinalmaSiparis;
        private SatinalmaSiparis satinalmaSiparis
        {
            get { if (_satinalmaSiparis == null) { _satinalmaSiparis = new(); } return _satinalmaSiparis; }
            set { _satinalmaSiparis = value; Binding(); }
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(12, 160);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1019, 451);
            universalGrid1.TabIndex = 1;
            Controls.Add(universalGrid1);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
            universalGrid1.SetData(new List<SatinalmaSiparisDTO>(), this.Name);
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            var satinalmaSiparisDTO = (SatinalmaSiparisDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            satinalmaSiparis = ConvertHelper.ToEntity<SatinalmaSiparis>(satinalmaSiparisDTO);
            contextMenuStrip1.Show(universalGrid1, e.Location);
        }

        private void Binding()
        {
            BindHelper.BindData(fcbProjeKod, satinalmaSiparis.proje, nameof(satinalmaSiparis.proje.Id));
            BindHelper.BindData(fcbFirma, satinalmaSiparis.firma, nameof(satinalmaSiparis.firma.Id));
        }
        private async void SatinalmaSiparisler_Load(object sender, System.EventArgs e)
        {
            string jsonData = await _satinalmaSiparisService.GetSatinalmaSiparisAsync(new SatinalmaSiparis());
            var data = _jsonConverter.DeserializeObject<List<SatinalmaSiparis>>(jsonData);
            if (data == null)
                data = new List<SatinalmaSiparis>();
            await universalGrid1.SetData(data.CastToDTO<SatinalmaSiparisDTO>().ToList(), this.Name);
        }

        private void siparişiGörüntüleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var frm = FormFactory.CreateForm<SatinalmaSiparisKayitFormu>();
            frm.UpdateMode(satinalmaSiparis);
            frm.ShowDialog();
        }

        private async void siparişiSilToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            string jsonResult = await _satinalmaSiparisService.DeleteSatinalmaSiparis(satinalmaSiparis);
            if (!string.IsNullOrWhiteSpace(jsonResult) && !jsonResult.Contains("error",StringComparison.OrdinalIgnoreCase))
            {
                universalGrid1.binding.Remove(universalGrid1.Grid.CurrentRow);
                MessageBox.Show("Sipariş Silindi");
                SatinalmaSiparisler_Load(null, null);
            }
        }
    }
}
