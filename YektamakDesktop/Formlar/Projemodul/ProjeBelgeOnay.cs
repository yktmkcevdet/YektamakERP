using ApiService.Implementations;
using ApiService.Interfaces;
using Models;
using Models.DTO;
using netDxf;
using netDxf.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
            universalGrid1.Grid.SelectionChanged += UniversalGrid1_SelectionChanged;
            universalGrid1.Grid.RowPrePaint += dataGridView1_RowPrePaint;
            universalGrid1.SetData(new List<StokKartDosyaDTO>(), this.Name, true);
            fcbProjeKod.SetDataSource(_cache.projeList);
        }

        private async void UniversalGrid1_SelectionChanged(object sender, EventArgs e)
        {
            skd = (StokKartDosyaDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (skd.dosyaTipId == 1)
            {

                pdfPopup.GetInstance(
                        await _fileService.GetFileDecompress(skd.dosyaFullPath)
                    );
            }
            else if (skd.dosyaTipId == 2)
            {
                var dxfDosya = await _fileService.GetFileDecompress(skd.dosyaFullPath);
                if (dxfDosya != null)
                {
                    label.Text = "";
                    DxfDrawHelper.dxfDoc = DxfDocument.Load(new MemoryStream(dxfDosya));
                    DxfDrawHelper.BuildSplineCache();
                    DxfDrawHelper.FitToScreen(panel1);
                }
                else
                {
                    label.Text = "DXF dosyası bulunamadı";
                    DxfDrawHelper.dxfDoc = null;
                }
                panel1.Invalidate();
            }
            else { pdfPopup.GetInstance(null); }


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
            await _stokService.SaveStokKartDosya(_convertHelper.ToEntity<StokKartDosya>(skd));
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
        Circle selected;
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (DxfDrawHelper.dxfDoc == null) return;
            if (DxfDrawHelper.isMeasuring)
            {
                DxfDrawHelper.DrawSnap(e.Graphics);
                return;
            }
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (var ent in DxfDrawHelper.dxfDoc.Entities.All)
            {
                DxfDrawHelper.DrawEntity(g, ent);
                if (ent.Type == EntityType.Line) continue;
                if (ent.Type == EntityType.Circle) continue;
                if (ent.Type == EntityType.Arc) continue;
                if (ent.Type == EntityType.Spline) continue;
                if (ent.Type == EntityType.Insert) continue;
                label.Text = $"{ent.Type.ToString()} çizilemedi";
            }

            DxfDrawHelper.RebuildScreenCache();
            foreach (var spl in DxfDrawHelper.splineScreenCache)
            {
                using var pen = new Pen(spl.color);
                g.DrawLines(pen, spl.arr);
            }

            foreach (var m in DxfDrawHelper.measurements)
                DxfDrawHelper.DrawMeasurement(g, m.A, m.B);

            if (DxfDrawHelper.measureStart != null && DxfDrawHelper.measureEnd != null)
                DxfDrawHelper.DrawMeasurement(g, DxfDrawHelper.measureStart.Value, DxfDrawHelper.measureEnd.Value);
            if (selected != null)
            {
                DxfDrawHelper.DrawPlusMarkup(g, selected);
            }
        }

        private async void roundedButton2_Click(object sender, EventArgs e)
        {
            using (var frm = new RedSebep())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    skd.kontrolEdenKullaniciId = _cache.kullanici.Id;
                    skd.kontrolSonucu = false;
                    skd.kontrolTarihi = DateTime.Now;
                    skd.kontrolRedSebepAciklama = frm.Reason;
                    await _stokService.SaveStokKartDosya(_convertHelper.ToEntity<StokKartDosya>(skd));
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
            }
        }

        private PdfGoruntuleme pdfPopup
        {
            get { if (_pdfPopup == null || _pdfPopup.IsDisposed) { _pdfPopup = FormFactory.CreateForm<PdfGoruntuleme>(); } return _pdfPopup; }
            set { _pdfPopup = value; }
        }
    }
}
