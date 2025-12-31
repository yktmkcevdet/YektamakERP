using ApiService.Interfaces;
using Microsoft.Win32;
using Models;
using netDxf;
using netDxf.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Projemodul
{
    public partial class ProjeDosyaAgacStil : Form
    {
        private readonly ICache _cache;
        private readonly IProjeService _projeService;
        private readonly IStokService _stokService;
        private readonly IConfigurationService _configurationService;
        private readonly IFileService _fileService;
        private readonly IDosyalamaService _dosyalamaService;
        private DxfDocument dxfDoc;
        public ProjeDosyaAgacStil(ICache cache, IProjeService projeService, IStokService stokService, IConfigurationService configurationService, IFileService fileService, IDosyalamaService dosyalamaService)
        {
            _cache = cache;
            _projeService = projeService;
            _stokService = stokService;
            _configurationService = configurationService;
            _fileService = fileService;
            _dosyalamaService = dosyalamaService;
            InitializeComponent();
            panel1.MouseWheel += panel1_MouseWheel;
            this.KeyPreview = true;
            fcbProjeKod.SetDataSource(_cache.projeList.GroupBy(p => p.Id).Select(p => p.First()).ToList());
        }

        private async void fcbProjeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            treeView1.Nodes.Clear();
            TreeNode rootNode = new TreeNode(fcbProjeKod.SelectedDisplayValue.ToString());
            rootNode.Tag = new ProjeBom { projeStokKart = { no = "0" } };
            treeView1.Nodes.Add(rootNode);
            var projeBomList = await _projeService.GetProjeBomList(
                new ProjeBom { proje = { Id = int.Parse(fcbProjeKod.SelectedValue.ToString()) } }
            );
            var hamList = projeBomList.Select(s => s.projeStokKart.no).ToList();
            var list = projeBomList.Where(s => s.projeStokKart.no != null).OrderBy(x => x.projeStokKart.no?.Split('.').Select(int.Parse),
                Comparer<IEnumerable<int>>.Create((a, b) =>
                {
                    var ea = a.GetEnumerator();
                    var eb = b.GetEnumerator();
                    while (ea.MoveNext() && eb.MoveNext())
                    {
                        int cmp = ea.Current.CompareTo(eb.Current);
                        if (cmp != 0) return cmp;
                    }
                    return a.Count().CompareTo(b.Count());
                })).ToList();
            foreach (var item in list)
            {
                TreeNodeCollection currentNodes = treeView1.Nodes;
                string part = string.Empty;
                TreeNode existingNode;
                if (!item.projeStokKart.no.Contains("."))
                {
                    existingNode = new TreeNode(item.projeStokKart.stokKart.kod);
                    existingNode.Tag = item;
                    rootNode.Nodes.Add(existingNode);
                }
                else
                {
                    part = item.projeStokKart.no.Substring(0, item.projeStokKart.no.LastIndexOf("."));
                    TreeNode parentNode = NodeTree(part, currentNodes);
                    TreeNode treeNode = new TreeNode(item.projeStokKart.stokKart.kod);
                    treeNode.Tag = item;
                    parentNode.Nodes.Add(treeNode);
                }
            }
            this.Enabled = true;
        }
        private TreeNode NodeTree(string part, TreeNodeCollection treeNodeCollection)
        {
            var existingNode = treeNodeCollection.Cast<TreeNode>()
                                                .FirstOrDefault(n => ((ProjeBom)n.Tag).projeStokKart.no.ToString() == part);
            if (existingNode != null)
            {
                return existingNode;
            }
            else
            {
                foreach (TreeNode partNode in treeNodeCollection)
                {
                    if (NodeTree(part, partNode.Nodes) is TreeNode childNode)
                        return childNode;
                }
            }
            return null;
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode child in e.Node.Nodes)
            {
                child.Checked = e.Node.Checked;
            }
        }
        private List<object> GetCheckedNodes(TreeNodeCollection nodes)
        {
            List<object> result = new List<object>();

            foreach (TreeNode node in nodes)
            {
                if (node.Checked && ((ProjeBom)node.Tag).Id != null)
                    result.Add(node.Tag);

                // alt node’ları da tara
                result.AddRange(GetCheckedNodes(node.Nodes));
            }

            return result;
        }
        private async Task<string> ExportToPdf(List<object> stokKartlar, string filePath)
        {
            filePath = Path.Combine(filePath, $"{fcbProjeKod.SelectedDisplayValue}.pdf");

            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var doc = new iTextSharp.text.Document())
            using (var copy = new iTextSharp.text.pdf.PdfCopy(doc, fs))
            {
                doc.Open();

                foreach (var item in stokKartlar)
                {
                    var fileName = ((ProjeBom)item).projeStokKart.stokKart.dosyaList
                        .FirstOrDefault(x => x.dosyaTip.Id == 1)?.dosyaFullPath;

                    if (string.IsNullOrEmpty(fileName)) continue;

                    var pdfBytes = await _fileService.GetFileDecompress(fileName);
                    if (pdfBytes == null) continue;

                    using (var reader = new iTextSharp.text.pdf.PdfReader(pdfBytes))
                    {
                        copy.AddDocument(reader);
                    }
                }

                doc.Close();
            }

            return filePath;
        }

        private async void roundedButton1_Click(object sender, EventArgs e)
        {
            var selectedStokKartlar = GetCheckedNodes(treeView1.Nodes);
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            if (openFolderDialog.ShowDialog() == true)
            {
                this.Enabled = false;
                string selectedPath = openFolderDialog.FolderName;
                var pdfPath = await ExportToPdf(selectedStokKartlar, selectedPath);
                Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
                this.Enabled = true;
            }
            else
            {
                MessageBox.Show("Lütfen bir klasör seçin.");
                return;
            }
        }

        private async void roundedButton2_Click(object sender, EventArgs e)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            if (openFolderDialog.ShowDialog() == true)
            {
                this.Enabled = false;
                string selectedPath = openFolderDialog.FolderName;
                var selectedRows = GetCheckedNodes(treeView1.Nodes);
                List<ProjeStokKart> projeStokKarts = selectedRows.Cast<ProjeBom>().Select(s => s.projeStokKart).ToList();
                if (Directory.Exists(selectedPath))
                {
                    var onay = MessageBox.Show("Seçilen klasör içeriğini temizlemek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo);
                    if (onay == DialogResult.Yes)
                    {
                        Directory.Delete(selectedPath, true);
                    }
                }
                await _dosyalamaService.CreateOrderFile(projeStokKarts, selectedPath);
                this.Enabled = true;
            }
            else
            {
                MessageBox.Show("Lütfen bir klasör seçin.");
                return;
            }
        }

        private void ctbParcaKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchText = ctbParcaKodu.TextCustom.Trim();
                if (string.IsNullOrEmpty(searchText))
                    return;

                // Önceki sonuçları temizle
                searchResults.Clear();
                currentMatchIndex = -1;

                // Tüm node’larda arama yap
                SearchTreeNodes(treeView1.Nodes, searchText);

                if (searchResults.Count > 0)
                {
                    currentMatchIndex = 0;
                    SelectNode(searchResults[currentMatchIndex]);
                }
                else
                {
                    MessageBox.Show("Eşleşme bulunamadı.");
                }
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (searchResults.Count == 0)
                {
                    //MessageBox.Show("Önce bir arama yapın.");
                    return;
                }
                // Sonraki eşleşmeye git
                currentMatchIndex = (currentMatchIndex + 1) % searchResults.Count;
                SelectNode(searchResults[currentMatchIndex]);
            }
        }
        List<TreeNode> searchResults = new List<TreeNode>();
        int currentMatchIndex = -1;
        private void SearchTreeNodes(TreeNodeCollection nodes, string searchText)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    searchResults.Add(node);
                }

                // Alt düğümler varsa recursive devam et
                if (node.Nodes.Count > 0)
                {
                    SearchTreeNodes(node.Nodes, searchText);
                }
            }
        }
        private void SelectNode(TreeNode node)
        {
            treeView1.SelectedNode = node;
            node.EnsureVisible(); // Görünür hale getir
            node.BackColor = Color.Yellow; // İsteğe bağlı vurgulama

            // Öncekilerin rengini sıfırlamak istersen:
            foreach (TreeNode n in searchResults)
                if (n != node)
                    n.BackColor = Color.White;
        }

        private async void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var bom = (ProjeBom)e.Node.Tag;
            if (bom.Id != null)
            {
                foreach (var dosya in bom.projeStokKart.stokKart.dosyaList.Where(d => d.dosyaTip.Id == 2))
                {
                    var dxfDosya = await _fileService.GetFileDecompress(dosya.dosyaFullPath);
                    dxfDoc = DxfDocument.Load(new MemoryStream(dxfDosya));
                    BuildSplineCache();
                    FitToScreen();
                }
            }
        }
        PointF ArcPoint(Arc arc, double angleDeg)
        {
            double rad = angleDeg * Math.PI / 180.0;
            return new PointF(
                (float)(arc.Center.X + arc.Radius * Math.Cos(rad)),
                (float)(arc.Center.Y + arc.Radius * Math.Sin(rad))
            );
        }

        bool AngleInArc(double angle, double start, double end)
        {
            if (end < start)
                end += 360;

            if (angle < start)
                angle += 360;

            return angle >= start && angle <= end;
        }
        static int FindKnotSpan(double t, List<double> U, int degree, int n)
        {
            // U: knot vector, n: last control point index (ctrl.Count - 1)

            // t en sondaysa span = n
            if (t >= U[n + 1]) return n;
            if (t <= U[degree]) return degree;

            int low = degree;
            int high = n + 1;
            int mid = (low + high) / 2;

            // U[mid] <= t < U[mid+1] arıyoruz
            while (t < U[mid] || t >= U[mid + 1])
            {
                if (t < U[mid]) high = mid;
                else low = mid;
                mid = (low + high) / 2;
            }
            return mid;
        }
        Vector2 DeBoor(int k, int degree, double t, List<Vector2> ctrl, List<double> knots)
        {
            var d = new Vector2[degree + 1];

            for (int j = 0; j <= degree; j++)
                d[j] = ctrl[k - degree + j];

            for (int r = 1; r <= degree; r++)
            {
                for (int j = degree; j >= r; j--)
                {
                    int idx = k - degree + j;
                    double alpha =
                        (t - knots[idx]) /
                        (knots[idx + degree - r + 1] - knots[idx]);

                    d[j] = (1 - alpha) * d[j - 1] + alpha * d[j];
                }
            }
            return d[degree];
        }
        List<PointF> SampleSpline(Spline spline, int segments = 50)
        {
            var ctrl = spline.ControlPoints
                .Select(p => new Vector2((float)p.X, (float)p.Y))
                .ToList();

            var U = spline.Knots.ToList();
            int p = spline.Degree;
            int n = ctrl.Count - 1;

            // t aralığı: [U[p], U[n+1]]
            double t0 = U[p];
            double t1 = U[n + 1];

            var pts = new List<PointF>(segments + 1);

            for (int i = 0; i <= segments; i++)
            {
                double t = t0 + (t1 - t0) * i / segments;

                int k = FindKnotSpan(t, U, p, n);   // ✅ doğru aralıkta k
                var v = DeBoor(k, p, t, ctrl, U);

                pts.Add(new PointF((float)v.X, (float)v.Y));
            }

            return pts;
        }
        List<List<PointF>> splineSegments = new();
        bool isMeasuring = false;
        PointF? measureStart = null;
        PointF? measureEnd = null;
        PointF? activeSnapPoint = null;
        SnapType activeSnapType = SnapType.None;
        float SnapToleranceWorld => 6f / scale;
        void StartMeasure()
        {
            isMeasuring = true;
            measureStart = null;
            measureEnd = null;
        }
        List<(PointF A, PointF B)> measurements = new();
        void BuildSplineCache()
        {
            splineSegments.Clear();

            foreach (var spline in dxfDoc.Entities.Splines)
            {
                splineSegments.Add(SampleSpline(spline, 40));
            }
        }
        static float scale = 1f;
        PointF pan = new PointF(0, 0);

        bool isPanning = false;
        System.Drawing.Point lastMouse;
        RectangleF GetDxfBounds()
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            void Include(PointF p)
            {
                minX = Math.Min(minX, p.X);
                minY = Math.Min(minY, p.Y);
                maxX = Math.Max(maxX, p.X);
                maxY = Math.Max(maxY, p.Y);
            }

            foreach (var l in dxfDoc.Entities.Lines)
            {
                Include(new PointF((float)l.StartPoint.X, (float)l.StartPoint.Y));
                Include(new PointF((float)l.EndPoint.X, (float)l.EndPoint.Y));
            }

            foreach (var c in dxfDoc.Entities.Circles)
            {
                Include(new PointF((float)(c.Center.X - c.Radius), (float)(c.Center.Y - c.Radius)));
                Include(new PointF((float)(c.Center.X + c.Radius), (float)(c.Center.Y + c.Radius)));
            }

            foreach (var arc in dxfDoc.Entities.Arcs)
            {
                double start = arc.StartAngle;
                double end = arc.EndAngle;
                if (end < start) end += 360;

                // Start & End noktaları
                Include(ArcPoint(arc, arc.StartAngle));
                Include(ArcPoint(arc, arc.EndAngle));

                // Kritik açılar
                double[] criticalAngles = { 0, 90, 180, 270 };
                foreach (var a in criticalAngles)
                {
                    if (AngleInArc(a, start, end))
                        Include(ArcPoint(arc, a));
                }
            }
            foreach (var pts in splineSegments)
            {
                foreach (var p in pts)
                    Include(p);
            }
            return RectangleF.FromLTRB(minX, minY, maxX, maxY);
        }
        Polyline2D SplineToPolyline(Spline spline)
        {
            return spline.ToPolyline2D(50); // segment sayısı
        }
        void FitToScreen()
        {
            var bounds = GetDxfBounds();

            float scaleX = panel1.Width / bounds.Width;
            float scaleY = panel1.Height / bounds.Height;
            scale = Math.Min(scaleX, scaleY) * 0.9f;

            pan.X = panel1.Width / 2f - (bounds.Left + bounds.Width / 2f) * scale;
            pan.Y = panel1.Height / 2f + (bounds.Top + bounds.Height / 2f) * scale;

            panel1.Invalidate();
        }
        PointF ToScreen(double x, double y)
        {
            return new PointF(
                (float)(x * scale + pan.X),
                (float)(-y * scale + pan.Y)
            );
        }
        List<PointF[]> splineScreenCache = new();

        void RebuildScreenCache()
        {
            splineScreenCache.Clear();

            foreach (var pts in splineSegments)
            {
                var arr = new PointF[pts.Count];
                for (int i = 0; i < pts.Count; i++)
                    arr[i] = ToScreen(pts[i].X, pts[i].Y);

                splineScreenCache.Add(arr);
            }
        }
        PointF ScreenToWorld(System.Drawing.Point p)
        {
            return new PointF(
                (p.X - pan.X) / scale,
                -(p.Y - pan.Y) / scale
            );
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (dxfDoc == null) return;
            if (isMeasuring) 
            {
                DrawSnap(e.Graphics);
                return;
            }
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var line in dxfDoc.Entities.Lines)
            {
                var p1 = ToScreen(line.StartPoint.X, line.StartPoint.Y);
                var p2 = ToScreen(line.EndPoint.X, line.EndPoint.Y);
                g.DrawLine(Pens.Black, p1, p2);
                if (line == selectedLine)
                    g.DrawLine(Pens.Red, p1, p2);
                else
                    g.DrawLine(Pens.Black, p1, p2);
            }

            foreach (var circle in dxfDoc.Entities.Circles)
            {
                var c = ToScreen(circle.Center.X, circle.Center.Y);
                float r = (float)(circle.Radius * scale);

                g.DrawEllipse(Pens.Black, c.X - r, c.Y - r, r * 2, r * 2);
            }

            foreach (var arc in dxfDoc.Entities.Arcs)
            {
                var c = ToScreen(arc.Center.X, arc.Center.Y);
                float r = (float)(arc.Radius * scale);

                float start = -(float)arc.StartAngle;
                float sweep = -(float)(arc.EndAngle - arc.StartAngle);
                if (sweep < 0) sweep += 360;

                g.DrawArc(Pens.Black, c.X - r, c.Y - r, r * 2, r * 2, start, sweep);
            }
            RebuildScreenCache();
            foreach (var arr in splineScreenCache)
                g.DrawLines(Pens.Black, arr);

            foreach (var m in measurements)
                DrawMeasurement(g, m.A, m.B);

            if (measureStart != null && measureEnd != null)
                DrawMeasurement(g, measureStart.Value, measureEnd.Value);
            
            //foreach (var seg in splineCache)
            //{
            //    for (int i = 0; i < seg.Count - 1; i++)
            //        g.DrawLine(Pens.Black,
            //            ToScreen(seg[i].X, seg[i].Y),
            //            ToScreen(seg[i + 1].X, seg[i + 1].Y));
            //}
            //foreach (var spline in dxfDoc.Entities.Splines)
            //{
            //    var poly = spline.ToPolyline2D(20);

            //    var verts = poly.Vertexes;

            //    for (int i = 0; i < verts.Count - 1; i++)
            //    {
            //        var p1 = ToScreen(verts[i].Position.X, verts[i].Position.Y);
            //        var p2 = ToScreen(verts[i + 1].Position.X, verts[i + 1].Position.Y);
            //        g.DrawLine(Pens.Black, p1, p2);
            //    }
            //}
        }
        float DistancePointToSegment(PointF p, PointF a, PointF b)
        {
            float dx = b.X - a.X;
            float dy = b.Y - a.Y;

            if (dx == 0 && dy == 0)
                return Distance(p, a);

            float t = ((p.X - a.X) * dx + (p.Y - a.Y) * dy) / (dx * dx + dy * dy);
            t = Math.Max(0, Math.Min(1, t));

            PointF proj = new PointF(a.X + t * dx, a.Y + t * dy);
            return Distance(p, proj);
        }

        float Distance(PointF p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            float oldScale = scale;
            scale *= e.Delta > 0 ? 1.1f : 0.9f;

            pan.X = e.X - (e.X - pan.X) * (scale / oldScale);
            pan.Y = e.Y - (e.Y - pan.Y) * (scale / oldScale);

            panel1.Invalidate();
        }
        void CheckMidpointSnap(PointF mouseWorld)
        {
            foreach (var line in dxfDoc.Entities.Lines)
            {
                PointF a = new((float)line.StartPoint.X, (float)line.StartPoint.Y);
                PointF b = new((float)line.EndPoint.X, (float)line.EndPoint.Y);

                PointF mid = new((a.X + b.X) / 2, (a.Y + b.Y) / 2);

                if (Distance(mouseWorld, mid) < SnapToleranceWorld)
                {
                    activeSnapPoint = mid;
                    activeSnapType = SnapType.MidPoint;
                    return;
                }
            }
        }
        void CheckCenterSnap(PointF mouseWorld)
        {
            foreach (var c in dxfDoc.Entities.Circles)
            {
                PointF center = new((float)c.Center.X, (float)c.Center.Y);

                if (Distance(mouseWorld, center) < SnapToleranceWorld)
                {
                    activeSnapPoint = center;
                    activeSnapType = SnapType.Center;
                    return;
                }
            }

            foreach (var a in dxfDoc.Entities.Arcs)
            {
                PointF center = new((float)a.Center.X, (float)a.Center.Y);

                if (Distance(mouseWorld, center) < SnapToleranceWorld)
                {
                    activeSnapPoint = center;
                    activeSnapType = SnapType.Center;
                    return;
                }
            }
        }
        bool TryLineIntersection(PointF a1, PointF a2, PointF b1, PointF b2, out PointF p)
        {
            p = default;

            float d = (a1.X - a2.X) * (b1.Y - b2.Y) -
                      (a1.Y - a2.Y) * (b1.X - b2.X);

            if (Math.Abs(d) < 0.0001f) return false;

            float xi = ((b1.X - b2.X) * (a1.X * a2.Y - a1.Y * a2.X) -
                        (a1.X - a2.X) * (b1.X * b2.Y - b1.Y * b2.X)) / d;

            float yi = ((b1.Y - b2.Y) * (a1.X * a2.Y - a1.Y * a2.X) -
                        (a1.Y - a2.Y) * (b1.X * b2.Y - b1.Y * b2.X)) / d;

            p = new PointF(xi, yi);
            return true;
        }
        void CheckIntersectionSnap(PointF mouseWorld)
        {
            var lines = dxfDoc.Entities.Lines.ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = i + 1; j < lines.Count; j++)
                {
                    PointF a1 = new((float)lines[i].StartPoint.X, (float)lines[i].StartPoint.Y);
                    PointF a2 = new((float)lines[i].EndPoint.X, (float)lines[i].EndPoint.Y);
                    PointF b1 = new((float)lines[j].StartPoint.X, (float)lines[j].StartPoint.Y);
                    PointF b2 = new((float)lines[j].EndPoint.X, (float)lines[j].EndPoint.Y);

                    if (!TryLineIntersection(a1, a2, b1, b2, out var ip))
                        continue;

                    if (Distance(mouseWorld, ip) < SnapToleranceWorld)
                    {
                        activeSnapPoint = ip;
                        activeSnapType = SnapType.Intersection;
                        return;
                    }
                }
            }
        }
        void UpdateSnap(PointF mouseWorld)
        {
            activeSnapPoint = null;
            activeSnapType = SnapType.None;

            CheckMidpointSnap(mouseWorld);
            if (activeSnapPoint != null) return;

            CheckCenterSnap(mouseWorld);
            if (activeSnapPoint != null) return;

            CheckIntersectionSnap(mouseWorld);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Left)
            {
                isPanning = true;
                lastMouse = e.Location;
            }
            if (!isMeasuring) return;

            PointF world = ScreenToWorld(e.Location);

            // Snap varsa burası snap’ten dönen nokta olur
            PointF p = GetSnapPoint(world) ?? world;

            if (measureStart == null)
            {
                measureStart = p;
            }
            else
            {
                measureEnd = p;
                measurements.Add((measureStart.Value, measureEnd.Value));

                // yeni ölçüye hazır
                measureStart = null;
                measureEnd = null;
            }

            panel1.Invalidate();
        }
        PointF? GetSnapPoint(PointF mouseWorld)
        {
            float tol = 5f / scale;

            foreach (var line in dxfDoc.Entities.Lines)
            {
                var p1 = new PointF((float)line.StartPoint.X, (float)line.StartPoint.Y);
                var p2 = new PointF((float)line.EndPoint.X, (float)line.EndPoint.Y);

                if (Distance(mouseWorld, p1) < tol) return p1;
                if (Distance(mouseWorld, p2) < tol) return p2;
            }
            return null;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPanning)
            {
                pan.X += e.X - lastMouse.X;
                pan.Y += e.Y - lastMouse.Y;
                lastMouse = e.Location;
                panel1.Invalidate();
            }
            if (!isMeasuring) return;

            PointF world = ScreenToWorld(e.Location);
            measureEnd = GetSnapPoint(world) ?? world;

            panel1.Invalidate();
            if (!isMeasuring) return;

            world = ScreenToWorld(e.Location);
            UpdateSnap(world);

            measureEnd = activeSnapPoint ?? world;
            panel1.Invalidate();

        }
        void DrawSnap(Graphics g)
        {
            if (activeSnapPoint == null) return;

            PointF s = ToScreen(activeSnapPoint.Value.X, activeSnapPoint.Value.Y);
            float r = 6;

            switch (activeSnapType)
            {
                case SnapType.MidPoint:
                    g.DrawRectangle(Pens.Green, s.X - r, s.Y - r, r * 2, r * 2);
                    break;

                case SnapType.Center:
                    g.DrawEllipse(Pens.Blue, s.X - r, s.Y - r, r * 2, r * 2);
                    g.DrawLine(Pens.Blue, s.X - r, s.Y, s.X + r, s.Y);
                    g.DrawLine(Pens.Blue, s.X, s.Y - r, s.X, s.Y + r);
                    break;

                case SnapType.Intersection:
                    g.DrawLine(Pens.Red, s.X - r, s.Y - r, s.X + r, s.Y + r);
                    g.DrawLine(Pens.Red, s.X - r, s.Y + r, s.X + r, s.Y - r);
                    break;
            }
        }
        void DrawMeasurement(Graphics g, PointF a, PointF b)
        {
            var sa = ToScreen(a.X, a.Y);
            var sb = ToScreen(b.X, b.Y);

            using var pen = new Pen(Color.Blue, 1) { DashStyle = DashStyle.Dash };
            g.DrawLine(pen, sa, sb);

            float dist = Distance(a, b);

            // orta nokta
            var mid = new PointF((sa.X + sb.X) / 2, (sa.Y + sb.Y) / 2);

            string text = $"{dist:0.##}";

            g.FillRectangle(Brushes.White, mid.X - 20, mid.Y - 10, 40, 20);
            g.DrawString(text, SystemFonts.DefaultFont, Brushes.Blue, mid);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && isMeasuring)
            {
                CancelMeasure();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        void CancelMeasure()
        {
            isMeasuring = false;
            measureStart = null;
            measureEnd = null;
            panel1.Invalidate();
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPanning = false;
        }
        private void pictureBox1_Paint()
        {


            using (var g = panel1.CreateGraphics())
            {

            }
        }
        float pickTolerance = 5f / scale; // ekranda ~5px

        Line selectedLine = null;
        Spline selectedSpline = null;
        float minDist = float.MaxValue;
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            PointF mouseWorld = ScreenToWorld(e.Location);
            foreach (var line in dxfDoc.Entities.Lines)
            {
                PointF a = new((float)line.StartPoint.X, (float)line.StartPoint.Y);
                PointF b = new((float)line.EndPoint.X, (float)line.EndPoint.Y);

                float d = DistancePointToSegment(mouseWorld, a, b);

                if (d < pickTolerance && d < minDist)
                {
                    minDist = d;
                    selectedLine = line;
                }
            }
            for (int s = 0; s < splineSegments.Count; s++)
            {
                var pts = splineSegments[s];

                for (int i = 0; i < pts.Count - 1; i++)
                {
                    float d = DistancePointToSegment(mouseWorld, pts[i], pts[i + 1]);
                    if (d < pickTolerance && d < minDist)
                    {
                        minDist = d;
                        selectedSpline = dxfDoc.Entities.Splines.ToList()[s];
                    }
                }
            }
            panel1.Invalidate();
        }

        private void ProjeDosyaAgacStil_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                StartMeasure();
            }
        }
    }
    enum SnapType
    {
        None,
        EndPoint,
        MidPoint,
        Center,
        Intersection
    }
}
