using ApiService.Implementations;
using ApiService.Interfaces;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar.Ortak;
using YektamakDesktop.Helpers;

namespace YektamakDesktop.Formlar.Projemodul
{
    public partial class ProjeBelgeOnay : Form
    {
        private readonly ICache _cache;
        private readonly IProjeService _projeService;
        private readonly IConvertHelper _convertHelper;
        private readonly IFileService _fileService;
        private readonly IStokService _stokService;
        private StokKartDosyaDTO skd;
        public ProjeBelgeOnay(ICache cache, IProjeService projeService, IConvertHelper convertHelper, IFileService fileService, IStokService stokService)
        {
            _cache = cache;
            _projeService = projeService;
            _convertHelper = convertHelper;
            _fileService = fileService;
            _stokService = stokService;
            InitializeComponent();
            Initialize();
            Binding();
            pdfPopup.Dock = DockStyle.Fill;
            pdfPopup.TopLevel = false;
            panel1.Controls.Add(pdfPopup);
            pdfPopup.Show();
        }
        private void Initialize()
        {
            UniversalGridHelper.Replace(ref universalGrid1, this);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
            universalGrid1.Grid.RowPrePaint += dataGridView1_RowPrePaint;
            universalGrid1.SetData(new List<StokKartDosyaDTO>(), this.Name, true);
            fcbProjeKod.SetDataSource(_cache.projeList);
        }

        private async void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                skd = (StokKartDosyaDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
                if (skd.dosyaTipId == 1)
                {

                    pdfPopup.GetInstance(
                            await _fileService.GetFileDecompress(skd.dosyaFullPath)
                        );
                }
            }
        }

        private StokKartDosyaDTO _stokKartDosya;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StokKartDosyaDTO stokKartDosya
        {
            get { if (_stokKartDosya == null) { _stokKartDosya = new(); Binding(); } return _stokKartDosya; }
            set { _stokKartDosya = value; }
        }
        private void Binding()
        {
            BindHelper.BindData(fcbDosyaTip, stokKartDosya, nameof(stokKartDosya.dosyaTipId));
        }

        private void fcbStokGrup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups.Where(m => m.stokGrup.Id.ToString() == fcbStokGrup.SelectedValue.ToString()).ToList());
        }

        private async void fcbProjeKod_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            fcbStokGrup.SetDataSource(_cache.stokGrups);
            fcbDosyaTip.SetDataSource(_cache.dosyaTipList);
            ProjeStokKart projeStokKart = new ProjeStokKart();
            projeStokKart.proje.Id = Convert.ToInt32(fcbProjeKod.SelectedValue.ToString());
            var projeStokKarts = await _projeService.GetProjeStokKart(projeStokKart);
            List<StokKartDosyaDTO> stokKartDosyaDTOs = new List<StokKartDosyaDTO>();
            foreach (var psk in projeStokKarts)
            {
                foreach (var stokKartDosya in psk.stokKart.dosyaList.Where(d => d.isActive == true))
                {
                    stokKartDosyaDTOs.Add(_convertHelper.ToDTO<StokKartDosyaDTO>(stokKartDosya));
                }
            }
            universalGrid1.SetData(stokKartDosyaDTOs, this.Name, true);
        }

        private void ProjeBelgeOnay_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveGridSettings();
        }

        private void fcbDosyaTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(stokKartDosya);
        }
        private PdfGoruntuleme _pdfPopup;

        private async void roundedButton1_Click(object sender, EventArgs e)
        {
            skd.kontrolEdenKullaniciId = _cache.kullanici.Id;
            skd.kontrolSonucu = true;
            skd.kontrolTarihi = DateTime.Now;
            _stokService.SaveStokKartDosya(_convertHelper.ToEntity<StokKartDosya>(skd));
            int i = universalGrid1.Grid.CurrentRow.Index;

            if (i < universalGrid1.Grid.Rows.Count - 1)
            {
                universalGrid1.Grid.CurrentCell =
                universalGrid1.Grid.Rows[i + 1].Cells[0];
                skd = (StokKartDosyaDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
                if (skd.dosyaTipId == 1)
                {

                    pdfPopup.GetInstance(
                            await _fileService.GetFileDecompress(skd.dosyaFullPath)
                        );
                }
            }
        }
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = universalGrid1.Grid.Rows[e.RowIndex];

            if (row.Cells["Kontrol Durumu"].Value == null)
                return;

            bool isActive = Convert.ToBoolean(row.Cells["Kontrol Durumu"].Value);

            row.DefaultCellStyle.BackColor =
                isActive ? Color.LightGreen : Color.LightGray;
        }

        private PdfGoruntuleme pdfPopup
        {
            get { if (_pdfPopup == null || _pdfPopup.IsDisposed) { _pdfPopup = FormFactory.CreateForm<PdfGoruntuleme>(); } return _pdfPopup; }
            set { _pdfPopup = value; }
        }
    }
}
