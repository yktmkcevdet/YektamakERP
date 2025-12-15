using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YektamakDesktop.Formlar.Satinalma;

namespace YektamakDesktop.Formlar
{
    public partial class MainForm : Form, ITabInfoProvider
    {
        private bool _isDirty;
        private int _recordCount;
        private int _dragTabIndex = -1;
        private ContextMenuStrip tabsListMenu = new ContextMenuStrip();
        private const int LeftMenuExpandedWidth = 220;
        private const int LeftMenuCollapsedWidth = 48;
        private bool _isLeftMenuExpanded = true;

        public MainForm()
        {
            InitializeComponent();
            tabMain.DrawMode = TabDrawMode.OwnerDrawFixed; // şimdilik kalsın (ileride kapatma butonu için lazım)
            tabMain.Padding = new Point(20, 4);   // ❌ için alan
            
            tabContextMenu = new ContextMenuStrip();

            tabContextMenu.Items.Add("Kapat", null, (_, _) => CloseSelectedTab());
            tabContextMenu.Items.Add("Diğerlerini Kapat", null, (_, _) => CloseOtherTabs());
            tabContextMenu.Items.Add("Hepsini Kapat", null, (_, _) => CloseAllTabs());

            tabMain.MouseUp += TabMain_MouseUp;
            tabMain.DrawItem += TabMain_DrawItem;
            tabMain.MouseDown += TabMain_MouseDown;
            tabMain.MouseMove += tabMain_MouseMove;
            btnTabs.Click += BtnTabs_Click;
            treeMenu.NodeMouseDoubleClick += treeMenu_NodeMouseDoubleClick;
        }
        private void btnToggleMenu_Click(object sender, EventArgs e)
        {
            ToggleLeftMenu();
        }
        private void ToggleLeftMenu()
        {
            _isLeftMenuExpanded = !_isLeftMenuExpanded;
            tableLayoutPanel1.ColumnStyles[0].Width = _isLeftMenuExpanded
                ? LeftMenuExpandedWidth
                : LeftMenuCollapsedWidth;

            treeMenu.ShowLines = _isLeftMenuExpanded;
            treeMenu.ShowPlusMinus = _isLeftMenuExpanded;
        }
        private void BtnTabs_Click(object? sender, EventArgs e)
        {
            BuildTabsListMenu();
            tabsListMenu.Show(btnTabs, new Point(0, btnTabs.Height));
        }
        private void RebuildTabItems(string filter)
        {
            // Arama kutusu ve separator dışındaki öğeleri sil
            while (tabsListMenu.Items.Count > 2)
                tabsListMenu.Items.RemoveAt(2);

            filter = (filter ?? "").Trim().ToLowerInvariant();

            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                var tab = tabMain.TabPages[i];
                var title = tab.Text ?? "";

                if (!string.IsNullOrEmpty(filter) &&
                    !title.ToLowerInvariant().Contains(filter))
                    continue;

                int index = i;

                var item = new ToolStripMenuItem(title)
                {
                    Checked = tabMain.SelectedIndex == index
                };

                item.Click += (_, _) => tabMain.SelectedIndex = index;

                // İstersen sağ tarafta kapatma da ekleyelim
                item.DropDownItems.Add("Kapat", null, (_, _) => CloseTab(index));

                tabsListMenu.Items.Add(item);
            }

            if (tabsListMenu.Items.Count == 2)
                tabsListMenu.Items.Add(new ToolStripMenuItem("(Eşleşen sekme yok)") { Enabled = false });
        }

        private void BuildTabsListMenu()
        {
            tabsListMenu.Items.Clear();

            // Arama kutusu (ToolStripTextBox)
            var txtSearch = new ToolStripTextBox
            {
                //PlaceholderText = "Sekme ara...",
                AutoSize = false,
                Width = 220
            };

            txtSearch.TextChanged += (_, _) => RebuildTabItems(txtSearch.Text);

            tabsListMenu.Items.Add(txtSearch);
            tabsListMenu.Items.Add(new ToolStripSeparator());

            RebuildTabItems(""); // ilk yükleme
        }

        private void tabMain_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                if (tabMain.GetTabRect(i).Contains(e.Location))
                {
                    _dragTabIndex = i;
                    break;
                }
            }
        }
        private void LoadData()
        {
            // data yükle
            _recordCount = 12;
            UpdateTabTitle();
        }
        private void txtAciklama_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
            UpdateTabTitle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            _isDirty = false;
            UpdateTabTitle();
        }
        public void UpdateTabTitle()
        {
            if (this.Parent is TabPage tab &&
                tab.Parent is TabControl tabControl &&
                tabControl.FindForm() is MainForm main)
            {
                main.RefreshTabTitle(this);
            }
        }
        public void RefreshTabTitle(Form frm)
        {
            foreach (TabPage tab in tabMain.TabPages)
            {
                if (tab.Controls.Count > 0 &&
                    ReferenceEquals(tab.Controls[0], frm))
                {
                    if (frm is ITabInfoProvider info)
                        tab.Text = info.GetTabTitle();
                    else
                        tab.Text = frm.Text;

                    break;
                }
            }
        }
        public string GetTabTitle()
        {
            var title = "Satınalma Talepler";

            if (_recordCount > 0)
                title += $" ({_recordCount})";

            if (_isDirty)
                title = "* " + title;

            return title;
        }
        private void TabMain_MouseUp(object? sender, MouseEventArgs e)
        {
            _dragTabIndex = -1;
            if (e.Button != MouseButtons.Right)
                return;

            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                if (tabMain.GetTabRect(i).Contains(e.Location))
                {
                    tabMain.SelectedIndex = i;
                    tabContextMenu.Show(tabMain, e.Location);
                    break;
                }
            }
        }
        private void CloseSelectedTab()
        {
            if (tabMain.SelectedIndex >= 0)
                CloseTab(tabMain.SelectedIndex);
        }
        private void CloseOtherTabs()
        {
            int selected = tabMain.SelectedIndex;

            for (int i = tabMain.TabPages.Count - 1; i >= 0; i--)
            {
                if (i != selected)
                    CloseTab(i);
            }
        }
        private void CloseAllTabs()
        {
            for (int i = tabMain.TabPages.Count - 1; i >= 0; i--)
            {
                CloseTab(i);
            }
        }
        private void TabMain_DrawItem(object? sender, DrawItemEventArgs e)
        {
            var tabPage = tabMain.TabPages[e.Index];
            var rect = e.Bounds;

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            // Arka plan
            using var backBrush = new SolidBrush(isSelected ? Color.White : Color.LightGray);
            e.Graphics.FillRectangle(backBrush, rect);

            // Başlık
            TextRenderer.DrawText(
                e.Graphics,
                tabPage.Text,
                tabMain.Font,
                new Rectangle(rect.X + 6, rect.Y + 4, rect.Width - 25, rect.Height),
                Color.Black,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );

            // ❌ butonu
            var closeRect = new Rectangle(
                rect.Right - 18,
                rect.Top + 6,
                12,
                12
            );

            TextRenderer.DrawText(
                e.Graphics,
                "x",
                tabMain.Font,
                closeRect,
                Color.DarkRed,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }
        public void OpenFormInTab(MenuItemInfo item)
        {
            foreach (TabPage page in tabMain.TabPages)
            {
                if (page.Tag is Type t && t == item.FormType)
                {
                    tabMain.SelectedTab = page;
                    return;
                }
            }

            var form = item.FormFactory();
            
            var tabPage = new TabPage(item.Text)
            {
                Tag = item.FormType
            };

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            tabPage.Controls.Add(form);
            tabMain.TabPages.Add(tabPage);
            tabMain.SelectedTab = tabPage;
            tabPage.Text = form is ITabInfoProvider info
                ? info.GetTabTitle()
                : form.Text;
            form.Show();
        }
        private void TabMain_MouseDown(object? sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                var rect = tabMain.GetTabRect(i);

                var closeRect = new Rectangle(
                    rect.Right - 18,
                    rect.Top + 6,
                    12,
                    12
                );

                if (closeRect.Contains(e.Location))
                {
                    CloseTab(i);
                    break;
                }
            }
            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                if (tabMain.GetTabRect(i).Contains(e.Location))
                {
                    _dragTabIndex = i;
                    break;
                }
            }
        }
        private void tabMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragTabIndex < 0)
                return;

            if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
                return;

            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                if (i == _dragTabIndex)
                    continue;

                if (tabMain.GetTabRect(i).Contains(e.Location))
                {
                    SwapTabs(_dragTabIndex, i);
                    _dragTabIndex = i;
                    break;
                }
            }
        }
        private void SwapTabs(int fromIndex, int toIndex)
        {
            if (fromIndex == toIndex)
                return;

            var tabFrom = tabMain.TabPages[fromIndex];
            tabMain.TabPages.Remove(tabFrom);
            tabMain.TabPages.Insert(toIndex, tabFrom);
            tabMain.SelectedIndex = toIndex;
        }
        private void CloseTab(int index)
        {
            var tabPage = tabMain.TabPages[index];

            if (tabPage.Controls.Count > 0 && tabPage.Controls[0] is Form frm)
            {
                frm.Close();
                frm.Dispose();
            }

            tabMain.TabPages.RemoveAt(index);
        }
        void LoadTopMenu(Modul modul)
        {
            flowTopMenu.Controls.Clear();

            var menuItems = MenuProvider.GetMenu(modul);

            foreach (var item in menuItems)
            {
                //if (!YetkiVarMi(item.YetkiKodu))
                //    continue;

                var btn = CreateTopMenuButton(item);
                
                flowTopMenu.Controls.Add(btn);
            }
        }
        Button CreateTopMenuButton(MenuItemInfo item)
        {
            var btn = new Button
            {
                Width = 150,
                Height = 42,
                Text = "  " + item.Text,
                Image = item.Icon,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextAlign = ContentAlignment.MiddleCenter,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(245, 245, 245),
                Tag = item
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.Click += TopMenuButton_Click;

            return btn;
        }
        private void TopMenuButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is MenuItemInfo item)
            {
                OpenFormInTab(item);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab?.Controls.Count == 0)
                return;

            if (tabMain.SelectedTab.Controls[0] is not Form activeForm)
                return;

            HighlightTopMenu(activeForm.GetType());
        }
        void HighlightTopMenu(Type activeFormType)
        {
            foreach (Control ctrl in flowTopMenu.Controls)
            {
                if (ctrl is Button btn && btn.Tag is MenuItemInfo item)
                {
                    bool isActive =
                        item.FormFactory().GetType() == activeFormType;

                    btn.BackColor = isActive
                        ? Color.FromArgb(200, 230, 255)
                        : Color.FromArgb(245, 245, 245);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //LoadTopMenu(Modul.Satinalma);
            BuildTreeMenu();
        }
        void BuildTreeMenu()
        {
            treeMenu.Nodes.Clear();

            var menuTree = MenuProvider.GetTreeMenu();

            foreach (var root in menuTree)
            {
                //if (!YetkiVarMi(root.YetkiKodu))
                //    continue;

                var rootNode = CreateTreeNode(root);
                treeMenu.Nodes.Add(rootNode);
            }
        }
        TreeNode CreateTreeNode(MenuNodeInfo info)
        {
            var node = new TreeNode(info.Text)
            {
                Tag = info
            };

            foreach (var child in info.Children)
            {
                //if (!YetkiVarMi(child.YetkiKodu))
                //    continue;

                node.Nodes.Add(CreateTreeNode(child));
            }

            return node;
        }
        private void treeMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Tag is MenuNodeInfo info &&
                info.FormFactory != null)
            {
                OpenFormInTab(new MenuItemInfo
                {
                    Text = info.Text,
                    FormType = info.FormType!,
                    FormFactory = info.FormFactory
                });
            }
        }
        

    }
    public class MenuItemInfo
    {
        public string Text { get; set; } = "";
        public string YetkiKodu { get; set; } = "";
        public Func<Form> FormFactory { get; set; } = null!;
        public Image? Icon { get; set; }
        public Type FormType { get; set; } = null!;
        public Modul Modul { get; set; }
    }
    public static class MenuProvider
    {
        public static List<MenuNodeInfo> GetTreeMenu()
        {
            return new()
            {
                new MenuNodeInfo
                {
                    Text = "Satınalma",
                    YetkiKodu = "MOD_SATINALMA",
                    Children =
                    {
                        new MenuNodeInfo
                        {
                            Text = "Satınalma Talepler",
                            YetkiKodu = "SAT_TALEP",
                            FormType = typeof(SatinalmaTalepler),
                            FormFactory = () => FormFactory.CreateForm<SatinalmaTalepler>()
                        },
                        new MenuNodeInfo
                        {
                            Text = "Teklifler",
                            YetkiKodu = "SAT_TEKLIF",
                            FormType = typeof(SatinalmaTalepTeklifFormu),
                            FormFactory = () => FormFactory.CreateForm<SatinalmaTalepTeklifFormu>()
                        }
                    }
                }
            };
        }
        public static List<MenuItemInfo> GetMenu(Modul modul)
        {
            return modul switch
            {
                Modul.Satinalma => new()
            {
                new MenuItemInfo
                {
                    Text = "Satınalma Talep",
                    YetkiKodu = "SAT_TALEP",
                    FormType = typeof(SatinalmaTalepler),
                    FormFactory = () => FormFactory.CreateForm<SatinalmaTalepler>()
                },
                new MenuItemInfo
                {
                    Text = "Teklif Toplama",
                    YetkiKodu = "SAT_TEKLIF",
                    FormType = typeof(SatinalmaTeklifTaleplerFormu),
                    FormFactory = () => FormFactory.CreateForm<SatinalmaTeklifTaleplerFormu>()
                }
            },
                _ => new()
            };
        }
    }

    public enum Modul
    {
        Satis,
        Satinalma,
        Stok,
        Proje,
        Planlama,
        Imalat,
        Sevk,
        Kurulum
    }
    public interface ITabInfoProvider
    {
        string GetTabTitle();   // Sekme başlığı
    }
    public class MenuNodeInfo
    {
        public string Text { get; set; } = "";
        public string YetkiKodu { get; set; } = "";
        public Type? FormType { get; set; }
        public Func<Form>? FormFactory { get; set; }
        public List<MenuNodeInfo> Children { get; set; } = new();
    }
}
