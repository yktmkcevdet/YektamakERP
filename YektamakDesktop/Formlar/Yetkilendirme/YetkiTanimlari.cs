using ApiService.Interfaces;
using Models;
using Models.Attributes;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using ConvertHelper = YektamakDesktop.Common.ConvertHelper;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class YetkiTanimlari : Form
    {
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        private readonly ICache _cache;
        public YetkiTanimlari(IKullaniciYetkiService kullaniciYetkiService, ICache cache)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
            _cache = cache;
            InitializeComponent();
            Initialize();
            treeView1.AfterCheck += async(s,e)=> await treeView1_AfterCheck(s,e);
            comboListBoxRol.SelectedIndexChanged += comboListBoxRol_SelectedIndexChanged;
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Location = new System.Drawing.Point(355, 125);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(428, 421);
            universalGrid1.TabIndex = 56;
            Controls.Add(universalGrid1);
            universalGrid1.Grid.MouseDown += universalGrid1_MouseDown;
        }
        private void comboListBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            Kullanici kullanici = new Kullanici();
            kullanici.rol.Id = comboListBoxRol.selectedDataRowId;
            string jsonResult = _kullaniciYetkiService.GetKullaniciYetki(kullanici);
            List<KullaniciYetki> kullaniciYetkiList = JsonConvert.DeserializeObject<List<KullaniciYetki>>(jsonResult);
            TreeNodes(kullaniciYetkiList);
            ComboBoxListFill.GetLookupAd(_cache.kullaniciList.Where(k => k.rol.Id == comboListBoxRol.selectedDataRowId).ToList(), ref cbxKullanici);
        }
        bool isLoading=false;
        private void TreeNodes(List<KullaniciYetki> kullaniciYetkiList)
        {
            isLoading = true;
            
            foreach (KullaniciYetki yetki in kullaniciYetkiList.OrderBy(k => k.menu.Id).ThenBy(k=>k.altMenu.Id)) 
            {
                var nodes=treeView1.Nodes.Find(yetki.menu.Id.ToString(),true);
                if (nodes.Count()>0)
                {
                    TreeNode node = new TreeNode(yetki.altMenu.ad);
                    node.Name = yetki.altMenu.Id.ToString();
                    if (yetki.rol.Id != null)
                    {
                        node.Checked = true;
                    }
                    nodes[0].Nodes.Add(node);
                }
                else if(kullaniciYetkiList.Any(k => k.altMenu.Id == yetki.menu.Id))
                {
                    var ytk = kullaniciYetkiList.FirstOrDefault(k => k.altMenu.Id == yetki.menu.Id);
                    if (ytk != null)
                    {
                        TreeNode node = new TreeNode(ytk.menu.ad);
                        node.Name = ytk.menu.Id.ToString();
                        TreeNode altNode = new TreeNode(yetki.menu.ad);
                        altNode.Name = yetki.menu.Id.ToString();
                        node.Nodes.Add(altNode);
                        treeView1.Nodes.Add(node);
                    }
                }
                else 
                {
                    TreeNode node = new TreeNode(yetki.menu.ad);
                    node.Name = yetki.menu.Id.ToString() ;
                    
                    treeView1.Nodes.Add(node);
                }
                
            }
            isLoading = false;
        }
        private async Task treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (isLoading) return;
            Yetki yetki = new Yetki();
            yetki.rolId = comboListBoxRol.selectedDataRowId;
            if (e.Node.Parent != null)
            {
                yetki.menu.Id = int.TryParse(e.Node.Parent.Name, out int parentId) ? parentId : yetki.menu.Id;
                yetki.ekran.altMenuId = int.Parse(e.Node.Name);
            }
            else
            {
                yetki.menu.Id = int.Parse(e.Node.Name);
            }

            string jsonResult = await _kullaniciYetkiService.SaveYetki(yetki);
            MessageBox.Show(jsonResult);
        }
        private TreeNode selectedNode;
        private async void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            selectedNode = treeView1.HitTest(e.X, e.Y).Node;
            treeView1.SelectedNode = selectedNode;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(treeView1, e.X, e.Y);
            }
            if (e.Button == MouseButtons.Left)
            {
                bool flowControl = await SetAlanYetkiList();
                if (!flowControl)
                {
                    return;
                }
            }
        }
        private static Type GetFormInstance(string formName)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Type targetType = null;
            foreach (var assembly in assemblies)
            {
                targetType = assembly.GetTypes()
                    .Where(type => typeof(IEntity).IsAssignableFrom(type) && type.Name == formName)
                    .FirstOrDefault();

                if (targetType != null)
                    break;
            }
            return targetType;
        }
        private void menuEkle_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Id = int.Parse(treeView1.SelectedNode.Name);
            AltMenuEkleForm altMenuEkleForm = FormFactory.CreateForm<AltMenuEkleForm>();
            altMenuEkleForm.UpdateMode(menu);
            altMenuEkleForm.Show();
        }
        private async void menuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ekran ekran = new();
            if (treeView1.SelectedNode.Parent == null)
            {
                ekran.menu.Id = int.Parse(treeView1.SelectedNode.Name);
            }
            else
            {
                ekran.menu.Id = int.Parse(treeView1.SelectedNode.Parent.Name);
                ekran.altMenuId = int.Parse(treeView1.SelectedNode.Name);
            }
               
            string httpResult = await _kullaniciYetkiService.DeleteEkran(ekran);
            if (httpResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(httpResult);
            }
            else
            {
                MessageBox.Show("Menu başarı ile silindi!");
            }
            comboListBoxRol_SelectedIndexChanged(sender, e);
        }
        private void YetkiTanimlari_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }
        private AlanYetkiDTO alanYetki { get; set; } = new();
        private List<AlanYetkiDTO> list { get; set; }
        private void alanEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            universalGrid1.AddRow(list);
            universalGrid1.SetData(list, this.Name, true);
        }
        private async void cbxKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flowControl = await SetAlanYetkiList();
            if (!flowControl)
            {
                return;
            }
        }
        private async Task<bool> SetAlanYetkiList()
        {
            if (cbxKullanici.selectedDataRowId == null) return false;
            if (selectedNode == null) return false;
            AlanYetki alanYetki = new AlanYetki();
            alanYetki.kullanici.Id = cbxKullanici.selectedDataRowId == null ? 0 : cbxKullanici.selectedDataRowId;
            alanYetki.formAd = selectedNode.Text;
            string jsonResult = await _kullaniciYetkiService.GetAlanYetki(alanYetki);
            var yetkiListDTO = new List<AlanYetkiDTO>();
            GetFieldListFromAttribute();
            if (!String.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                var yetkiList = JsonConvert.DeserializeObject<List<AlanYetki>>(jsonResult);
                foreach (var yetki in yetkiList)
                {
                    yetkiListDTO.Add(ConvertHelper.ToDTO<AlanYetkiDTO>(yetki));
                }
                yetkiListDTO.RemoveAll(yetkiDTO => !yetkiListDTOFromAttr.Any(y => y.alanAd == yetkiDTO.alanAd));

                var existingAlanAds = yetkiListDTO.Select(y => y.alanAd).ToHashSet();
                var itemsToAdd = yetkiListDTOFromAttr.Where(yetkiDTO => !existingAlanAds.Contains(yetkiDTO.alanAd));
                yetkiListDTO.AddRange(itemsToAdd);
            }
            else
            {
                foreach (var yetkiDTO in yetkiListDTOFromAttr)
                {
                    yetkiListDTO.Add(yetkiDTO);
                }
            }
            list = yetkiListDTO;
            await universalGrid1.SetData(list, this.Name, true);
            return true;
        }
        private static List<AlanYetkiDTO> _yetkiListDTOFromAtrr;
        private static List<AlanYetkiDTO> yetkiListDTOFromAttr
        {
            get
            {
                if (_yetkiListDTOFromAtrr == null)
                {
                    _yetkiListDTOFromAtrr = new List<AlanYetkiDTO>();
                }
                return _yetkiListDTOFromAtrr;
            }
        }
        private void GetFieldListFromAttribute()
        {
            yetkiListDTOFromAttr.Clear();
            string jsonResult = _kullaniciYetkiService.GetMenu(new Menu { ad = selectedNode.Text });
            Menu menu = JsonConvert.DeserializeObject<List<Menu>>(jsonResult)[0];
            var d = GetFormInstance(menu.model);
            if (d != null)
            {
                var properties = d.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var property in properties)
                {
                    var yetki = new AlanYetkiDTO
                    {
                        model = menu.model,
                        formAd = menu.formAd,
                        kullaniciId = cbxKullanici.selectedDataRowId == -1 ? 0 : cbxKullanici.selectedDataRowId
                    };
                    var attrs = property.GetCustomAttributes(typeof(GridDisplayAttribute), true);
                    if (attrs.Length > 0 && attrs[0] is GridDisplayAttribute attr)
                    {
                        yetki.alanAd = attr.Header;
                        yetki.yetki = false;
                        yetkiListDTOFromAttr.Add(yetki);
                    }
                }
            }
        }
        private void universalGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hit = universalGrid1.Grid.HitTest(e.X, e.Y);
                    int rowIndex = hit.RowIndex;
                    universalGrid1.Grid.ClearSelection();
                    if (rowIndex == -1) return;
                    universalGrid1.Grid.Rows[rowIndex].Selected = true;
                    alanYetki = list[rowIndex];
                    contextMenuStrip2.Show(universalGrid1, e.X, e.Y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private async void menuChangeAuth_Click(object sender, EventArgs e)
        {
            try
            {
                var alanYetkiList = universalGrid1.GetCheckedRows<AlanYetkiDTO>();
                if (alanYetkiList.Count > 0)
                {
                    foreach (var alan in alanYetkiList)
                    {
                        alanYetki = alan;
                        await YetkiTanimla();
                    }
                }
                else
                {
                    await YetkiTanimla();
                }
                universalGrid1.SetData(list, this.Name, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async Task YetkiTanimla()
        {
            alanYetki.kullaniciId = cbxKullanici.selectedDataRowId;
            alanYetki.yetki = !alanYetki.yetki;
            alanYetki.formAd = selectedNode.Text;
            string httpResult = await _kullaniciYetkiService.SaveAlanYetki(ConvertHelper.ToEntity<AlanYetki>(alanYetki));
            if (list.Find(y => y == alanYetki) is { } item)
            {
                item.yetki = alanYetki.yetki;
            }
        }

        private void YetkiTanimlari_Load(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.rolList, ref comboListBoxRol);
        }

        private async void yetkileriSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var alanYetkiList = universalGrid1.GetCheckedRows<AlanYetkiDTO>();
                if (alanYetkiList.Count > 0)
                {
                    foreach (var alan in alanYetkiList)
                    {
                        var alanYetki = ConvertHelper.ToEntity<AlanYetki>(alan);
                        string jsonResult = await _kullaniciYetkiService.DeleteAlanYetki(alanYetki);
                        MessageBox.Show(jsonResult);
                        universalGrid1.binding.RemoveAt(universalGrid1.Grid.SelectedCells[0].RowIndex);
                    }
                        
                }
                universalGrid1.SetData(list, this.Name, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
