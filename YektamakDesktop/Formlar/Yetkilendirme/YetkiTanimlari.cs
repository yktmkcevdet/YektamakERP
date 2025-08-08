using ApiService.Interfaces;
using Models;
using Models.Attributes;
using Models.DTO;
using Models.Models;
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
using YektamakDesktop.Formlar.Satinalma;
using ConvertHelper = YektamakDesktop.Common.ConvertHelper;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class YetkiTanimlari : Form, IForm
    {
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        private readonly ICache _cache;
        private readonly IJsonConverter _jsonConverter;
        private readonly IDataTableMapper _dataTableMapper;
        public YetkiTanimlari(IKullaniciYetkiService kullaniciYetkiService, ICache cache, IJsonConverter jsonConverter, IDataTableMapper dataTableMapper)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
            _cache = cache;
            _jsonConverter = jsonConverter;
            _dataTableMapper = dataTableMapper;
            InitializeComponent();
            Initialize();
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
            this.Shown += YetkiTanimlari_Shown;
            universalGrid1.Grid.MouseDown += universalGrid1_MouseDown;
        }
        private async void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                universalGrid1.Grid.Rows[e.RowIndex].Selected = true;
                if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
                {
                    if (universalGrid1.Grid.Rows[e.RowIndex].Cells[1].Value == null)
                        return;
                    var alanyetkiDto = (AlanYetkiDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
                    AlanYetki alanYetki = ConvertHelper.ToEntity<AlanYetki>(alanyetkiDto);
                    //if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)//Update
                    //{

                    //}
                    if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)//Sil
                    {
                        string jsonResult = await _kullaniciYetkiService.DeleteAlanYetki(alanYetki);
                        Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
                        MessageBox.Show(result.result);
                        universalGrid1.binding.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void YetkiTanimlari_Shown(object sender, EventArgs e)
        {

        }


        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private YetkiTanimlari()
        {

        }
        private void comboListBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            Kullanici kullanici = new Kullanici();
            kullanici.rol.Id = comboListBoxRol.selectedDataRowId;
            string httpResult = _kullaniciYetkiService.GetKullaniciYetki(kullanici);
            DataSet dataSet = _jsonConverter.DeserializeToDataSet(httpResult);
            TreeNode treeNode;
            treeNode = TreeNodes(dataSet);
            ComboBoxListFill.GetLookupAd(_cache.kullaniciList.Where(k => k.rol.Id == comboListBoxRol.selectedDataRowId).ToList(), ref cbxKullanici);
        }
        private TreeNode TreeNodes(DataSet dataSet)
        {
            TreeNode treeNode = new TreeNode();
            foreach (DataRow dataRow in dataSet.Tables[0].Select("rolId=1")) //RolId=1 yazılmasının sebebi menü başlıklarının admin rolü için tanımlanmış olduğundan dolayı.
            {
                treeNode = new TreeNode(dataRow["ad"].ToString());
                treeNode.Checked = true;
                treeNode.Name = dataRow["Id"].ToString();
                // İkinci tablodan verileri kullanarak alt düğümleri oluştur
                TreeNodesLevel1(dataSet, treeNode, dataRow);
                treeView1.Nodes.Add(treeNode);
            }

            return treeNode;
        }
        private void TreeNodesLevel1(DataSet dataSet, TreeNode treeNode, DataRow dataRow)
        {
            foreach (DataRow dr in dataSet.Tables[1].Select("rolId=" + comboListBoxRol.selectedDataRowId + " or rolId is null"))
            {
                if (dr["Id"].ToString() == dataRow["Id"].ToString() && !string.IsNullOrEmpty(dr["AltMenuId"].ToString()))
                {
                    TreeNode node = new TreeNode(dr["EkranAdi"].ToString());
                    node.Name = dr["AltMenuId"].ToString();
                    TreeNodesLevel2(dataSet, dr, node);
                    if (!string.IsNullOrEmpty(dr["YetkiId"].ToString()))
                    {
                        node.Checked = true;
                    }
                    else
                    {
                        treeNode.Checked = false;
                    }
                    treeNode.Nodes.Add(node);
                }
            }
        }
        private void TreeNodesLevel2(DataSet dataSet, DataRow dr, TreeNode node)
        {
            foreach (DataRow dr1 in dataSet.Tables[1].Select("rolId=" + comboListBoxRol.selectedDataRowId + " or rolId is null"))
            {
                if (dr1["Id"].ToString() == dr["AltMenuId"].ToString())
                {
                    TreeNode node1 = new TreeNode(dr1["EkranAdi"].ToString());
                    node1.Name = dr1["AltMenuId"].ToString();
                    TreeNodesLevel3(dataSet, dr1, node1);
                    if (!string.IsNullOrEmpty(dr1["YetkiId"].ToString()))
                    {
                        node1.Checked = true;
                    }
                    else
                    {
                        node1.Checked = false;
                    }
                    node.Nodes.Add(node1);
                }
            }
        }
        private void TreeNodesLevel3(DataSet dataSet, DataRow dr1, TreeNode node1)
        {
            foreach (DataRow dr2 in dataSet.Tables[1].Select("rolId=" + comboListBoxRol.selectedDataRowId + " or rolId is null"))
            {
                if (dr2["Id"].ToString() == dr1["AltMenuId"].ToString())
                {
                    TreeNode node2 = new TreeNode(dr2["EkranAdi"].ToString());
                    node2.Name = dr2["AltMenuId"].ToString();
                    if (!string.IsNullOrEmpty(dr2["YetkiId"].ToString()))
                    {
                        node2.Checked = true;
                    }
                    else
                    {
                        node2.Checked = false;
                    }
                    node1.Nodes.Add(node2);
                }
            }
        }
        private async void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
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

            string httpResult = await _kullaniciYetkiService.SaveYetki(yetki);
            if (httpResult.Contains("error"))
            {
                MessageBox.Show(httpResult);
            }
            else
            {
                MessageBox.Show("Yetki güncellendi");
            }
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
            ekran.altMenuId = int.Parse(treeView1.SelectedNode.Name);
            ekran.menu.Id = int.Parse(treeView1.SelectedNode.Parent.Name);
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
        private async System.Threading.Tasks.Task<bool> SetAlanYetkiList()
        {
            if (cbxKullanici.selectedDataRowId == null) return false;
            if (selectedNode == null) return false;
            AlanYetki alanYetki = new AlanYetki();
            alanYetki.kullanici.Id = cbxKullanici.selectedDataRowId == null ? 0 : cbxKullanici.selectedDataRowId;
            alanYetki.formAd = selectedNode.Text;
            string alanYetkiJson = await _kullaniciYetkiService.GetAlanYetki(alanYetki);
            Result result = _jsonConverter.DeserializeToModelList<Result>(alanYetkiJson)[0];
            var yetkiListDTO = new List<AlanYetkiDTO>();
            GetFieldListFromAttribute();
            if (result.result != null && !result.result.Contains("error",StringComparison.OrdinalIgnoreCase))
            {
                var yetkiList = JsonConvert.DeserializeObject<List<AlanYetki>>(result.result);
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
            universalGrid1.SetData(list, this.Name, true);
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
            Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult)[0];
            Menu menu = JsonConvert.DeserializeObject<List<Menu>>(result.result)[0];
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
                    //list = universalGrid1.binding.DataSource as List<AlanYetkiDTO>;
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
            Result result = _jsonConverter.DeserializeToModelList<Result>(httpResult)[0];
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
                        //Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
                        //MessageBox.Show(result.result);
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
