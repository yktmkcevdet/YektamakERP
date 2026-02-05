using ApiService.Interfaces;
using FontAwesome.Sharp;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using YektamakDesktop.Formlar.Satinalma;

namespace YektamakDesktop.Formlar
{
    public partial class MainForm : Form, ITabInfoProvider
    {
        private readonly ICache _cache;
        private bool _isDirty;
        private int _recordCount;
        private int _dragTabIndex = -1;
        private ContextMenuStrip tabsListMenu = new ContextMenuStrip();
        private const int LeftMenuExpandedWidth = 220;
        private const int LeftMenuCollapsedWidth = 26;
        private bool _isLeftMenuExpanded = true;
        private ImageList menuImages;
        private bool _isHoverExpanded = false;
        private Timer _collapseTimer;
        private HashSet<string> _expandedNodePaths = new();

        public MainForm(ICache cache)
        {
            _cache = cache;
            InitializeComponent();
            menuImages = new ImageList
            {
                ImageSize = new Size(24, 24),
                ColorDepth = ColorDepth.Depth32Bit
            };

            treeMenu.ImageList = menuImages;
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
            treeMenu.NodeMouseHover += treeMenu_NodeMouseHover;
            treeMenu.AfterExpand += treeMenu_AfterExpand;
            treeMenu.AfterCollapse += treeMenu_AfterCollapse;
            btnTabs.Click += BtnTabs_Click;
            treeMenu.NodeMouseClick += treeMenu_NodeMouseClick;
            treeMenu.BeforeExpand += (s, e) =>
            {
                if (e.Node.Tag is MenuNodeInfo info &&
                    info.FormFactory != null)
                {
                    e.Cancel = true;
                }
            };
            _collapseTimer = new Timer
            {
                Interval = 300 
            };

            _collapseTimer.Tick += (_, _) =>
            {
                _collapseTimer.Stop();
                ToggleLeftMenu();
            };
        }

        private void treeMenu_AfterExpand(object sender, TreeViewEventArgs e)
        {
            _expandedNodePaths.Add(e.Node.FullPath);
        }

        private void treeMenu_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            _expandedNodePaths.Remove(e.Node.FullPath);
        }
        private void treeMenu_MouseEnter(object sender, EventArgs e)
        {
            _collapseTimer.Stop();
            if (!_isHoverExpanded && !_isLeftMenuExpanded)
            {
                _isHoverExpanded = true;
                ToggleLeftMenu();
            }
        }
        private void RestoreExpandedState()
        {
            foreach (TreeNode node in treeMenu.Nodes)
            {
                RestoreNode(node);
            }
        }

        private void RestoreNode(TreeNode node)
        {
            if (_expandedNodePaths.Contains(node.FullPath))
                node.Expand();

            foreach (TreeNode child in node.Nodes)
                RestoreNode(child);
        }
        private void treeMenu_MouseLeave(object sender, EventArgs e)
        {
            if (_isHoverExpanded && _isLeftMenuExpanded)
            {
                _isHoverExpanded = false;
                _collapseTimer.Start();
            }
        }
        private void btnToggleMenu_Click(object sender, EventArgs e)
        {
            ToggleLeftMenu();
        }
        private void ToggleLeftMenu()
        {
            _isLeftMenuExpanded = !_isLeftMenuExpanded;
            treeMenu.ShowLines = _isLeftMenuExpanded;
            treeMenu.ShowPlusMinus = _isLeftMenuExpanded;
            if (_isLeftMenuExpanded)
            {
                tableLayoutPanel1.ColumnStyles[0].Width = LeftMenuExpandedWidth;
            }
            else
            {
                tableLayoutPanel1.ColumnStyles[0].Width = LeftMenuCollapsedWidth;
            }
            RestoreExpandedState();
            UpdateTreeTextVisibility();
        }
        void UpdateTreeTextVisibility()
        {
            foreach (TreeNode node in treeMenu.Nodes)
            {
                UpdateNodeText(node);
            }
        }

        void UpdateNodeText(TreeNode node)
        {
            if (_isLeftMenuExpanded)
            {
                if (node.Tag is MenuNodeInfo info)
                    node.Text = info.Text;
            }
            else
            {
                //node.Text = ""; // sadece ikon kalır
                //node.Collapse();
            }

            foreach (TreeNode child in node.Nodes)
                UpdateNodeText(child);
        }
        private void treeMenu_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            if (_isLeftMenuExpanded)
                return;

            if (e.Node?.Tag is Menu info)
            {
                toolTip1.SetToolTip(treeMenu, info.ad);
            }
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
        public void OpenFormInTab(Menu item)
        {
            foreach (TabPage page in tabMain.TabPages)
            {
                if (page.Tag is Type t && t.Name == item.formAd)
                {
                    tabMain.SelectedTab = page;
                    return;
                }
            }
            
            var form = FormFactory.CreateFormByName(item.formAd);
            var field = form.GetType()
                .GetField("headerPanel1",
                          BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            if (field?.GetValue(form) is Control panel)
            {
                panel.Visible = false;
            }
            var tabPage = new TabPage(item.ad)
            {
                Tag = form.GetType()
            };

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            
            tabPage.Controls.Add(form);
            tabMain.TabPages.Add(tabPage);
            tabMain.SelectedTab = tabPage;
            tabPage.Text = form is ITabInfoProvider info
                ? info.GetTabTitle()
                : item.ad;
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
                    tabMain.Cursor = Cursors.Hand;
                }
                else
                {
                    tabMain.Cursor = Cursors.Default;
                }
            }
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            BuildTreeMenu();
        }
        void BuildTreeMenu()
        {
            menuImages.ImageSize = new Size(24, 24);
            treeMenu.Nodes.Clear();
            foreach (AnaMenuDTO anaMenu in _cache.anaMenuList.OrderBy(a => a.siraNo))
            {
                var rootNode = CreateHeaderTreeNode(anaMenu);
                foreach (Yetki yetki in _cache.yetkiList.OrderBy(y => y.ekran.siraNo))
                {
                    if (yetki.menu.ad.ToString() == anaMenu.ad)
                    {
                        var iconChar = (IconChar)Enum.Parse(typeof(IconChar), yetki.ekran.menu.icon);
                        var icon = FaImageHelper.Create(iconChar);
                        menuImages.Images.Add(iconChar.ToString(), icon);
                        rootNode.Nodes.Add(new TreeNode(yetki.ekran.ekranAdi)
                        {
                            Tag = yetki.ekran.menu,
                            ImageKey = yetki.ekran.menu.icon,
                            SelectedImageKey = yetki.ekran.menu.icon,
                            
                        });
                    }
                }
                treeMenu.Nodes.Add(rootNode);
            }
        }
        TreeNode CreateHeaderTreeNode(AnaMenuDTO anaMenu)
        {
            var iconChar = (IconChar)Enum.Parse(typeof(IconChar), anaMenu.icon);
            var icon = FaImageHelper.Create(iconChar);
            menuImages.Images.Add(iconChar.ToString(), icon);
            var node = new TreeNode(anaMenu.ad)
            {
                Tag = anaMenu,
                ImageKey = anaMenu.icon,
                SelectedImageKey = anaMenu.icon
            };
            return node;

        }

        private void treeMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Tag is Menu info)
            {
                OpenFormInTab(info);
            }
        }
        

    }
    
    public interface ITabInfoProvider
    {
        string GetTabTitle();   // Sekme başlığı
    }
    public class MenuNodeInfo
    {
        public string Text { get; set; } = "";
        public string YetkiKodu { get; set; } = "";
        public string? IconKey { get; set; }
        public Type? FormType { get; set; }
        public Func<Form>? FormFactory { get; set; }
        public List<MenuNodeInfo> Children { get; set; } = new();
    }
}
