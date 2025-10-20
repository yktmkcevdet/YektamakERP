using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Stok;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepSatirDetayForm : Form
    {
        private readonly ICache _cache;
        private readonly IProjeService _projeService;
        private readonly IStokService _stokService;
        public SatinalmaTalepSatirDetayForm(ICache cache, IProjeService projeService, IStokService stokService)
        {
            _cache = cache;
            _projeService = projeService;
            _stokService = stokService;
            InitializeComponent();
            Initialize();
        }
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
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
            universalGrid1.SetData(new List<SatinalmaTalepSatirDetayDTO>(), this.Name);
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        public void UpdateMode(List<SatinalmaTalepSatirDetay> satinalmaTalepSatirDetays)
        {
            List<SatinalmaTalepSatirDetayDTO> satinalmaTalepSatirDetayDTOs = new();
            foreach (var satinalmaTalepSatirDetay in satinalmaTalepSatirDetays)
            {
                satinalmaTalepSatirDetayDTOs.Add(ConvertHelper.ToDTO<SatinalmaTalepSatirDetayDTO>(satinalmaTalepSatirDetay));
            }
            universalGrid1.SetData(satinalmaTalepSatirDetayDTOs, this.Name);
        }

        private void SatinalmaTalepSatirDetayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private async void stokKartıGörüntüleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var satinalmaTalepSatirDetayDTO = (SatinalmaTalepSatirDetayDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            SatinalmaTalepSatirDetay satinalmaTalepSatirDetay = ConvertHelper.ToEntity<SatinalmaTalepSatirDetay>(satinalmaTalepSatirDetayDTO);
            ProjeStokKart projeStokKart = satinalmaTalepSatirDetay.projeStokKart;
            string jsonResult = await _projeService.GetProjeStokKart(projeStokKart);
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Stok kartı bulunamadı");
            }
            else
            {
                List<ProjeStokKart> projeStokKarts = JsonConvert.DeserializeObject<List<ProjeStokKart>>(jsonResult);
                if (projeStokKarts.Count > 1)
                {
                    MessageBox.Show("Birden fazla stok kartı bulundu");
                    //projeStokKart = projeStokKarts.Where(p => p.proje.Id == satinalmaTalepSatirDetayDTO.projeId).FirstOrDefault();
                }
                else
                {
                    projeStokKart = projeStokKarts[0];
                }
                StokKartKayitFormu stokKartKayitFormu = FormFactory.CreateForm<StokKartKayitFormu>();
                stokKartKayitFormu.UpdateMode(projeStokKart);
                stokKartKayitFormu.ShowDialog();
            }
        }

        private void pDFGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTalepSatirDetayDTO = (SatinalmaTalepSatirDetayDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            SatinalmaTalepSatirDetay satinalmaTalepSatirDetay = ConvertHelper.ToEntity<SatinalmaTalepSatirDetay>(satinalmaTalepSatirDetayDTO);
            ProjeStokKart projeStokKart = satinalmaTalepSatirDetay.projeStokKart;
            string jsonResult=_stokService.GetStokKartPdf(projeStokKart.stokKart);
            StokKart stokKart = new StokKart();
            if (!String.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                stokKart = JsonConvert.DeserializeObject<List<StokKart>>(jsonResult)[0];
            }
            byte[] dosyaVeri = stokKart.dosyaList[0].dosya;
            string tempFilePath = Path.GetTempFileName() + "." + "pdf";
            if (dosyaVeri != null)
            {
                using (MemoryStream ms = new MemoryStream(dosyaVeri))
                {
                    File.WriteAllBytes(tempFilePath, ms.ToArray());
                    Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
                }
            }
        }
    }
}
