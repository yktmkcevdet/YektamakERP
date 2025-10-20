using ApiService.Interfaces;
using Microsoft.Win32;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
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
        public ProjeDosyaAgacStil(ICache cache, IProjeService projeService, IStokService stokService, IConfigurationService configurationService)
        {
            _cache = cache;
            _projeService = projeService;
            _stokService = stokService;
            InitializeComponent();
            fcbProjeKod.SetDataSource(_cache.projes);
            _configurationService = configurationService;
        }

        private async void fcbProjeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            TreeNode rootNode = new TreeNode(fcbProjeKod.SelectedDisplayValue.ToString());
            rootNode.Tag = new ProjeBom { projeStokKart = { no = "0" } };
            treeView1.Nodes.Add(rootNode);
            var jsonResult = await _projeService.GetProjeBomList(
                new ProjeBom { proje = { Id = int.Parse(fcbProjeKod.SelectedValue.ToString()) } }
            );

            var projeBomList = JsonConvert.DeserializeObject<List<ProjeBom>>(jsonResult);
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
                if (node.Checked)
                    result.Add(node.Tag);

                // alt node’ları da tara
                result.AddRange(GetCheckedNodes(node.Nodes));
            }

            return result;
        }
        private void ExportToPdf(List<object> stokKartlar, string filePath)
        {
            filePath = Path.Combine(filePath, $"{fcbProjeKod.SelectedDisplayValue}.pdf");
            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var doc = new iTextSharp.text.Document())
            using (var copy = new iTextSharp.text.pdf.PdfCopy(doc, fs))
            {
                doc.Open();

                foreach (var item in stokKartlar)
                {
                    if (item == null) continue;
                    var jsonResult = _stokService.GetStokKartPdf(((ProjeBom)item).projeStokKart.stokKart);
                    if (jsonResult == "") continue;
                    StokKart pdfStokKart = JsonConvert.DeserializeObject<List<StokKart>>(jsonResult).FirstOrDefault();
                    var pdfBytes = pdfStokKart.dosyaList
                                      .FirstOrDefault(x => x.dosyaTip.Id == 1)
                                      ?.dosya;

                    if (pdfBytes != null)
                    {
                        using (var reader = new iTextSharp.text.pdf.PdfReader(pdfBytes))
                        {
                            copy.AddDocument(reader); // PDF'i ana dokümana ekle
                        }
                    }
                }

                doc.Close();
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            var selectedStokKartlar = GetCheckedNodes(treeView1.Nodes);
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            if (openFolderDialog.ShowDialog() == true)
            {
                string selectedPath = openFolderDialog.FolderName;
                ExportToPdf(selectedStokKartlar, selectedPath);
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
            string destinationPath = string.Empty;
            OpenFolderDialog openFileDialog = new OpenFolderDialog();
            
            if (openFileDialog.ShowDialog()==true)
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
                StokKart stokKart = new StokKart { Id = ((ProjeBom)row).projeStokKart.Id };
                string jsonResult = _stokService.GetStokKartPdf(stokKart);
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
                                SaveMaterialFile(skd, Path.Combine(destinationPath,dosyalamaYapisi.path, dosyalamaYapisi.klasorAd));
                            if (dosyalamaYapisi.dxf && skd.dosyaTip.Id == 2)
                                SaveMaterialFile(skd, Path.Combine(destinationPath,dosyalamaYapisi.path, dosyalamaYapisi.klasorAd));
                            if (dosyalamaYapisi.step && skd.dosyaTip.Id == 3)
                                SaveMaterialFile(skd, Path.Combine(destinationPath,dosyalamaYapisi.path, dosyalamaYapisi.klasorAd));
                        }
                    }
                }
                
            }
        }
        private void SaveMaterialFile(StokKartDosya skd, string path)
        {
            string filePath = Path.Combine(path, $"{skd.dosyaAd}.{skd.dosyaUzanti}");
            string directoryPath = Path.GetDirectoryName(filePath);
            // Dizin yoksa oluştur
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            File.WriteAllBytes(filePath, skd.dosya);
        }
    }
}
