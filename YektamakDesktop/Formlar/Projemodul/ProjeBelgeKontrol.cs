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
    public partial class ProjeBelgeKontrol : Form
    {
        private readonly ICache _cache;
        private readonly IProjeService _projeService;
        private readonly IConvertHelper _convertHelper;
        private readonly IFileService _fileService;
        private readonly IStokService _stokService;
        private StokKartDosyaDTO skd;
        public ProjeBelgeKontrol(ICache cache, IProjeService projeService, IConvertHelper convertHelper, IFileService fileService, IStokService stokService)
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
            panel2.MouseWheel += panel2_MouseWheel;
            panel2.MouseClick += panel2_MouseClick;
            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseMove += panel2_MouseMove;
            panel2.MouseUp += panel2_MouseUp;
        }

        private void Initialize()
        {
            UniversalGridHelper.Replace(ref universalGrid1, this);
            universalGrid1.Grid.SelectionChanged += UniversalGrid1_SelectionChanged;
            universalGrid1.Grid.RowPrePaint += dataGridView1_RowPrePaint;
            universalGrid1.SetData(new List<StokKartDosyaDTO>(), this.Name, false);
            fcbProjeKod.SetDataSource(_cache.projeList);
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups.Where(m => m.stokGrup.Id == 1).ToList());
        }

        private async void UniversalGrid1_SelectionChanged(object sender, EventArgs e)
        {
            if (universalGrid1.Grid.CurrentRow == null) return;
            skd = (StokKartDosyaDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            var projeStokKart = (await _projeService.GetProjeStokKart(new ProjeStokKart { proje = {Id=int.Parse(fcbProjeKod.SelectedValue.ToString())},stokKart = { Id = skd.stokKartId } }))[0];
            var pdfFullPath = projeStokKart.stokKart.dosyaList.FirstOrDefault(d => d.isActive==true && d.dosyaTip.Id == 1)?.dosyaFullPath;
            var dxffFullPath = projeStokKart.stokKart.dosyaList.FirstOrDefault(d => d.isActive == true && d.dosyaTip.Id == 2)?.dosyaFullPath;
            pdfPopup.GetInstance(
                    await _fileService.GetFileDecompress(pdfFullPath)
                );
            var dxfDosya = await _fileService.GetFileDecompress(dxffFullPath);
            if (dxfDosya != null)
            {
                panel2.Controls.Clear();
                DxfDrawHelper.dxfDoc = DxfDocument.Load(new MemoryStream(dxfDosya));
                DxfDrawHelper.BuildSplineCache();
                DxfDrawHelper.FitToScreen(panel1);
            }
            else
            {
                panel2.Controls.Clear();
                Label label = new Label();
                label.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
                label.ForeColor = Color.Red;
                label.Location = new System.Drawing.Point(15, 15);
                label.Name = "label";
                label.Size = new Size(500, 23);
                label.TabIndex = 0;
                label.Text = "DXF dosyası bulunamadı";
                panel2.Controls.Add(label);
                DxfDrawHelper.dxfDoc = null;
            }
            panel2.Invalidate();
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
        List<ProjeStokKart> projeStokKarts;
        private async void fcbProjeKod_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            fcbDosyaTip.SetDataSource(_cache.dosyaTipList);
            ProjeStokKart projeStokKart = new ProjeStokKart();
            projeStokKart.proje.Id = Convert.ToInt32(fcbProjeKod.SelectedValue.ToString());
            projeStokKarts = await _projeService.GetProjeStokKart(projeStokKart);
            List<StokKartDosyaDTO> stokKartDosyaDTOs = new List<StokKartDosyaDTO>();
            foreach (var psk in projeStokKarts.Where(p => p.stokKart.malzemeGrup.Id == (fcbMalzemeGrup.SelectedValue == null ? p.stokKart.malzemeGrup.Id : int.Parse(fcbMalzemeGrup.SelectedValue.ToString()))))
            {
                foreach (var stokKartDosya in psk.stokKart.dosyaList.Where(d => d.isActive == true))
                {
                    stokKartDosyaDTOs.Add(_convertHelper.ToDTO<StokKartDosyaDTO>(stokKartDosya));
                }
            }
            universalGrid1.SetData(stokKartDosyaDTOs, this.Name, false);
        }

        private void ProjeBelgeKontrol_FormClosing(object sender, FormClosingEventArgs e)
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && DxfDrawHelper.isMeasuring)
            {
                DxfDrawHelper.CancelMeasure(panel1);
                return true;
            }
            if (keyData==Keys.F5)
            {
                DxfDrawHelper.StartMeasure();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        Circle selected;
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (DxfDrawHelper.dxfDoc == null) return;
            if (DxfDrawHelper.isMeasuring)
            {
                DxfDrawHelper.DrawSnap(e.Graphics);
                //return;
            }
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            panel2.Controls.Clear();
            foreach (var ent in DxfDrawHelper.dxfDoc.Entities.All)
            {
                DxfDrawHelper.DrawEntity(g, ent);
                if (ent.Type == EntityType.Line) continue;
                if (ent.Type == EntityType.Circle) continue;
                if (ent.Type == EntityType.Arc) continue;
                if (ent.Type == EntityType.Spline) continue;
                if (ent.Type == EntityType.Insert) continue;
                Label label = new Label();
                label.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
                label.ForeColor = Color.Red;
                label.Location = new System.Drawing.Point(15, 15);
                label.Name = "label";
                label.Size = new Size(500, 23);
                label.TabIndex = 0;
                label.Text = $"{ent.Type.ToString()} çizilemedi";
                panel2.Controls.Add(label);
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
        private void panel2_MouseWheel(object sender, MouseEventArgs e)
        {
            float oldScale = DxfDrawHelper.scale;
            DxfDrawHelper.scale *= e.Delta > 0 ? 1.1f : 0.9f;

            DxfDrawHelper.pan.X = e.X - (e.X - DxfDrawHelper.pan.X) * (DxfDrawHelper.scale / oldScale);
            DxfDrawHelper.pan.Y = e.Y - (e.Y - DxfDrawHelper.pan.Y) * (DxfDrawHelper.scale / oldScale);

            panel2.Invalidate();
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Left)
            {
                DxfDrawHelper.isPanning = true;
                DxfDrawHelper.lastMouse = e.Location;
            }
            PointF world = DxfDrawHelper.ScreenToWorld(e.Location);
            if (DxfDrawHelper.isMeasuring)
            {
                PointF p = DxfDrawHelper.GetSnapPoint(world) ?? world;

                if (DxfDrawHelper.measureStart == null)
                {
                    DxfDrawHelper.measureStart = p;
                }
                else
                {
                    DxfDrawHelper.measureEnd = p;
                    DxfDrawHelper.measurements.Add((DxfDrawHelper.measureStart.Value, DxfDrawHelper.measureEnd.Value));

                    // yeni ölçüye hazır
                    DxfDrawHelper.measureStart = null;
                    DxfDrawHelper.measureEnd = null;
                }
            }
            else
            {
                selected = DxfDrawHelper.FindCircleAt(world);


            }


            // Snap varsa burası snap’ten dönen nokta olur


            panel2.Invalidate();
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (DxfDrawHelper.isPanning)
            {
                DxfDrawHelper.pan.X += e.X - DxfDrawHelper.lastMouse.X;
                DxfDrawHelper.pan.Y += e.Y - DxfDrawHelper.lastMouse.Y;
                DxfDrawHelper.lastMouse = e.Location;
                panel2.Invalidate();
            }
            if (!DxfDrawHelper.isMeasuring) return;

            PointF world = DxfDrawHelper.ScreenToWorld(e.Location);
            DxfDrawHelper.measureEnd = DxfDrawHelper.GetSnapPoint(world) ?? world;

            DxfDrawHelper.UpdateSnap(world);

            DxfDrawHelper.measureEnd = DxfDrawHelper.activeSnapPoint ?? world;
            panel2.Invalidate();
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            DxfDrawHelper.isPanning = false;
        }
        float minDist = float.MaxValue;
        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            //PointF mouseWorld = DxfDrawHelper.ScreenToWorld(e.Location);
            //foreach (var line in DxfDrawHelper.dxfDoc.Entities.Lines)
            //{
            //    PointF a = new((float)line.StartPoint.X, (float)line.StartPoint.Y);
            //    PointF b = new((float)line.EndPoint.X, (float)line.EndPoint.Y);

            //    float d = DxfDrawHelper.DistancePointToSegment(mouseWorld, a, b);

            //    if (d < DxfDrawHelper.pickTolerance && d < minDist)
            //    {
            //        minDist = d;
            //        //selectedLine = line;
            //    }
            //}
            //for (int s = 0; s < DxfDrawHelper.splineSegments.Count; s++)
            //{
            //    var spl = DxfDrawHelper.splineSegments[s];

            //    for (int i = 0; i < spl.points.Count - 1; i++)
            //    {
            //        float d = DxfDrawHelper.DistancePointToSegment(mouseWorld, spl.points[i], spl.points[i + 1]);
            //        if (d < DxfDrawHelper.pickTolerance && d < minDist)
            //        {
            //            minDist = d;
            //            //selectedSpline = DxfDrawHelper.dxfDoc.Entities.Splines.ToList()[s];
            //        }
            //    }
            //}
            //panel2.Invalidate();
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

        private void fcbMalzemeGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<StokKartDosyaDTO> stokKartDosyaDTOs = new List<StokKartDosyaDTO>();
            foreach (var psk in projeStokKarts.Where(p => p.stokKart.malzemeGrup.Id == (fcbMalzemeGrup.SelectedValue == null ? p.stokKart.malzemeGrup.Id : int.Parse(fcbMalzemeGrup.SelectedValue.ToString()))))
            {
                foreach (var stokKartDosya in psk.stokKart.dosyaList.Where(d => d.isActive == true ))
                {
                    stokKartDosyaDTOs.Add(_convertHelper.ToDTO<StokKartDosyaDTO>(stokKartDosya));
                }
            }
            universalGrid1.SetData(stokKartDosyaDTOs, this.Name, false);
        }

        private PdfGoruntuleme pdfPopup
        {
            get { if (_pdfPopup == null || _pdfPopup.IsDisposed) { _pdfPopup = FormFactory.CreateForm<PdfGoruntuleme>(); } return _pdfPopup; }
            set { _pdfPopup = value; }
        }
    }
}
