using ApiService.Interfaces;
using Microsoft.Win32;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Projemodul
{
    public partial class ProjeDosyaAgacStil : Form
    {
        private readonly ICache _cache;
        private readonly IProjeService _projeService;
        private readonly IStokService _stokService;
        private readonly IConfigurationService _configurationService;
        private readonly IFileService _fileService;
        private readonly IFileHelper _fileHelper;
        public ProjeDosyaAgacStil(ICache cache, IProjeService projeService, IStokService stokService, IConfigurationService configurationService, IFileService fileService, IFileHelper fileHelper)
        {
            _cache = cache;
            _projeService = projeService;
            _stokService = stokService;
            InitializeComponent();
            fcbProjeKod.SetDataSource(_cache.projeList.GroupBy(p => p.Id).Select(p => p.First()).ToList());
            _configurationService = configurationService;
            _fileService = fileService;
            _fileHelper = fileHelper;
        }

        private async void fcbProjeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
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

                    var pdfBytes = await _fileService.GetFile(fileName);
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
            await CreateOrderFile();
        }
        private async Task CreateOrderFile()
        {
            this.Enabled = false;
            string destinationPath = string.Empty;
            OpenFolderDialog openFileDialog = new OpenFolderDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                destinationPath = openFileDialog.FolderName;
            }
            else
            {
                MessageBox.Show("Lütfen bir dosya yolu seçin.");
                return;
            }
            var dosyalamaYapisiList = await _cache.dosyalamaYapisiList;
            var selectedRows = GetCheckedNodes(treeView1.Nodes);
            foreach (var row in selectedRows)
            {
                StokKart stokKart = new StokKart { Id = ((ProjeBom)row).projeStokKart.stokKart.Id };
                string jsonResult = _stokService.GetStokKartPdf(stokKart);
                if (jsonResult == "") continue;
                stokKart = JsonConvert.DeserializeObject<List<StokKart>>(jsonResult)[0];
                foreach (var skd in stokKart.dosyaList)
                {
                    foreach (var dosyalamaYapisi in dosyalamaYapisiList)
                    {
                        if (((ProjeBom)row).projeStokKart.stokKart.malzemeGrup.Id == dosyalamaYapisi.malzemeGrupId
                            && (dosyalamaYapisi.malzemeAltGrupId is null || dosyalamaYapisi.malzemeAltGrupId == ((ProjeBom)row).projeStokKart.stokKart.malzemeAltGrup.Id)
                            && (dosyalamaYapisi.boyutId is null || dosyalamaYapisi.boyutId == ((ProjeBom)row).projeStokKart.stokKart.boyutTanim.Id)
                            )
                        {
                            if (dosyalamaYapisi.pdf && skd.dosyaTip.Id == 1)
                                SaveMaterialFile(skd, Path.Combine(destinationPath, dosyalamaYapisi.path, dosyalamaYapisi.klasorAd));
                            if (dosyalamaYapisi.dxf && skd.dosyaTip.Id == 2)
                                SaveMaterialFile(skd, Path.Combine(destinationPath, dosyalamaYapisi.path, dosyalamaYapisi.klasorAd));
                            if (dosyalamaYapisi.step && skd.dosyaTip.Id == 3)
                                SaveMaterialFile(skd, Path.Combine(destinationPath, dosyalamaYapisi.path, dosyalamaYapisi.klasorAd));
                        }
                    }
                }

            }
            this.Enabled = true;
        }
        private async void SaveMaterialFile(StokKartDosya skd, string path)
        {
            string filePath = Path.Combine(path, $"{skd.dosyaAd}.{skd.dosyaUzanti}");
            string directoryPath = Path.GetDirectoryName(filePath);
            // Dizin yoksa oluştur
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            byte[] dosya = await _fileService.GetFile(skd.dosyaFullPath);
            File.WriteAllBytes(filePath, dosya);
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

    }
}
