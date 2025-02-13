using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class YetkiTanimlari : Form, IForm
    {
        private static YetkiTanimlari _yetkiTanimlari;
        public static YetkiTanimlari yetkiTanimlari
        {
            get
            {
                if (_yetkiTanimlari == null)
                {
                    _yetkiTanimlari = new YetkiTanimlari();
                    GlobalData.Yetki(ref _yetkiTanimlari);
                }
                return _yetkiTanimlari;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public YetkiTanimlari()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>()
            {
                treeView1,
                comboListBoxRol
            };
            foreach (Rol rol in Enum.GetValues(typeof(Rol)))
            {
                comboListBoxRol.AddDataRow((int)rol, rol.ToString());
            }
        }
        #region mouseDrag
        bool mouseDown;
        private Point offset;
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreepPos = PointToScreen(e.Location);
                Location = new Point(currentScreepPos.X - offset.X, currentScreepPos.Y - offset.Y);
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion mouseDrag

        private void comboListBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            Kullanici kullanici = new Kullanici();
            kullanici.rolId = comboListBoxRol.selectedDataRowId;
            string httpResult = WebMethods.GetKullaniciYetki(kullanici);
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            DataSet dataSet = jsonConverter.JsonStringToDataSet(httpResult);
            TreeNode treeNode;
            foreach (DataRow dataRow in dataSet.Tables[0].Select("rolId=1")) //RolId=1 yazılmasının sebebi menü başlıklarının admin rolü için tanımlanmış olduğundan dolayı.
            {
                treeNode = new TreeNode(dataRow["ad"].ToString());
                treeNode.Checked = true;
                treeNode.Name = dataRow["Id"].ToString();
                // İkinci tablodan verileri kullanarak alt düğümleri oluştur
                foreach (DataRow dr in dataSet.Tables[1].Select("rolId=" + comboListBoxRol.selectedDataRowId + " or rolId is null"))
                {
                    if (dr["Id"].ToString() == dataRow["Id"].ToString() && !string.IsNullOrEmpty(dr["AltMenuId"].ToString()))
                    {
                        TreeNode node = new TreeNode(dr["EkranAdi"].ToString());
                        node.Name = dr["AltMenuId"].ToString();
                        foreach(DataRow dr1 in dataSet.Tables[1].Select("rolId=" + comboListBoxRol.selectedDataRowId + " or rolId is null"))
                        {
                            if (dr1["Id"].ToString() == dr["AltMenuId"].ToString())
                            {
                                TreeNode node1 = new TreeNode(dr1["EkranAdi"].ToString());
                                node1.Name = dr1["AltMenuId"].ToString();
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
                treeView1.Nodes.Add(treeNode);
            }
        }

        private async void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Yetki yetki = new Yetki();
            yetki.rolId = comboListBoxRol.selectedDataRowId;
            if(e.Node.Parent != null)
            {
				yetki.menu.Id = int.TryParse(e.Node.Parent.Name, out int parentId) ? parentId : yetki.menu.Id;
				yetki.ekran.altMenuId = int.Parse(e.Node.Name);
			}
            else
            {
                yetki.menu.Id= int.Parse(e.Node.Name);
            }

			string httpResult = await WebMethods.SaveYetki(yetki);
            if (httpResult.Contains("error"))
            {
                MessageBox.Show(httpResult);
            }
            else
            {
                MessageBox.Show("Yetki güncellendi");
            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode selectedNode = treeView1.HitTest(e.X, e.Y).Node;
            treeView1.SelectedNode = selectedNode;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(treeView1, e.X, e.Y);
            }
        }

        private void menuEkle_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Id = int.Parse(treeView1.SelectedNode.Name);
            AltMenuEkle altMenuEkle = AltMenuEkle.altMenuekle;
            if(altMenuEkle != null )
            {
                altMenuEkle.Show();
                altMenuEkle.SaveMode(menu);
            }
        }
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _yetkiTanimlari = null;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void menuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ekran ekran = new();
            ekran.altMenuId = int.Parse(treeView1.SelectedNode.Name);
            ekran.menu.Id = int.Parse(treeView1.SelectedNode.Parent.Name);
            string httpResult = await WebMethods.DeleteEkran(ekran);
            if (httpResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(httpResult);
            }
            else
            {
                MessageBox.Show("Menu başarı ile silindi!");
            }
            comboListBoxRol_SelectedIndexChanged(null, null);
        }
    }
}
