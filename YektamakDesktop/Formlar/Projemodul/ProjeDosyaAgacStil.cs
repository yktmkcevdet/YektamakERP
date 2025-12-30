using ApiService.Interfaces;
using Microsoft.Win32;
using Models;
using netDxf;
using netDxf.Entities;
using NPOI.HPSF;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
                    pictureBox1_Paint();
                }
            }
        }
        private void pictureBox1_Paint()
        {
            if (dxfDoc == null) return;

            int x0;
            int y0;

            //Graphics g = e.Graphics;
            //g.Clear(Color.White);
            //Pen pen = new Pen(Color.Black, 1);
            using (var g = panel1.CreateGraphics())
            {
                foreach (var line in dxfDoc.Entities.Lines)
                {
                    g.DrawLine(
                        Pens.Black,
                        (float)line.StartPoint.X,
                        (float)line.StartPoint.Y,
                        (float)line.EndPoint.X,
                        (float)line.EndPoint.Y
                    );
                }
                foreach (Circle circle in dxfDoc.Entities.Circles)
                {
                    g.DrawEllipse(
                        Pens.Black,
                        (float)(circle.Center.X - circle.Radius),
                        (float)(circle.Center.Y - circle.Radius),
                        (float)(2 * circle.Radius),
                        (float)(2 * circle.Radius)
                    );
                }
                foreach (Arc arc in dxfDoc.Entities.Arcs)
                {
                    float x = (float)arc.Center.X + 200;
                    float y = (float)arc.Center.Y + 200;
                    float radius = (float)arc.Radius;
                    float startAngle = (float)arc.StartAngle;
                    float endAngle = (float)arc.EndAngle;

                    // Açıyı saat yönüne çevirme
                    float sweepAngle = endAngle - startAngle;
                    if (sweepAngle < 0)
                        sweepAngle += 360;

                    // Dikdörtgensel çerçeveyi hesapla
                    float topLeftX = x - radius;
                    float topLeftY = y - radius;
                    float diameter = 2 * radius;

                    g.DrawArc(Pens.Black, topLeftX, topLeftY, diameter, diameter, startAngle, sweepAngle);
                }
            }
        }
    }
}
