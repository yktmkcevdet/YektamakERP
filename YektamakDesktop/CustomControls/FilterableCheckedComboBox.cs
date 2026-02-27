using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace YektamakDesktop.CustomControls
{
    public partial class FilterableCheckedComboBox : UserControl
    {
        private List<object> allItems = new List<object>();
        private bool isFocused = false;

        private Color borderFocusColor = Color.HotPink;
        private int borderRadius = 5;
        private Color borderColor = Color.Silver;
        private int borderSize = 1;

        private string _placeholder = "Seçiniz...";

        [Category("Custom")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PlaceholderText
        {
            get => _placeholder;
            set { _placeholder = value; SetPlaceholder(); }
        }

        [Category("Custom")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DisplayMember { get; set; } = "ad";

        [Category("Custom")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ValueMember { get; set; } = "Id";

        [Category("Custom")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }

        [Category("Custom")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }

        public FilterableCheckedComboBox()
        {
            InitializeComponent();
            InitializeDropDown();
            InitializeCustom();
        }
        private Label infoLabel;
        private void InitializeCustom()
        {
            
            textBox.Click += (s, e) => ShowDropDown();
            textBox.Enter += (s, e) => { isFocused = true; Invalidate(); RemovePlaceholder(); };
            textBox.Leave += (s, e) => { isFocused = false; Invalidate(); if (string.IsNullOrEmpty(textBox.Text)) SetPlaceholder(); };
            textBox.KeyUp += TextBox_KeyUp;
            infoLabel = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 20,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "0 kayıt seçildi"
            };

            this.Controls.Add(infoLabel);
            checkedListBox.ItemCheck += CheckedListBox_ItemCheck;
            SetPlaceholder();
        }
        private void InitializeDropDown()
        {
            ToolStripControlHost host = new ToolStripControlHost(checkedListBox)
            {
                AutoSize = false,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                Size = checkedListBox.Size
            };
            host.Size = new Size(this.Width, 200);
            dropDown = new ToolStripDropDown
            {
                Padding = Padding.Empty
            };
            dropDown.Items.Add(host);
            //dropDown.Items.Add(infoLabel.Text);
        }
        private bool dropDownOpen = false;
        private void ShowDropDown()
        {
            if (dropDown == null)
                InitializeDropDown();
            if(dropDownOpen)
            {
                dropDown.Close();
                dropDownOpen = false;
            }
            else
            {
                dropDown.Show(this, 0, this.Height);
                dropDownOpen = true;
            }
        }

        public void SetDataSource<T>(List<T> items)
        {
            allItems = items.Cast<object>().ToList();
            RefreshList(allItems);
            SetPlaceholder();
        }
        public event EventHandler ItemsChanged;
        private void RefreshList(List<object> items)
        {
            checkedListBox.DataSource = null;
            checkedListBox.Items.Clear();
            checkedListBox.DisplayMember = DisplayMember;
            checkedListBox.ValueMember = ValueMember;
            foreach (var item in items)
                checkedListBox.Items.Add(item, true);
        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                UpdateText();
                ItemsChanged?.Invoke(this, e);
                infoLabel.Text = $"{checkedListBox.CheckedItems.Count} kayıt seçildi";
            });
        }

        private void UpdateText()
        {
            var selected = checkedListBox.CheckedItems.Cast<object>()
                .Select(item =>
                {
                    var prop = TypeDescriptor.GetProperties(item)[DisplayMember];
                    return prop?.GetValue(item)?.ToString();
                });

            textBox.ForeColor = Color.Black;
            textBox.Text = selected.Any() ? string.Join(", ", selected) : "";
            if (string.IsNullOrEmpty(textBox.Text))
                SetPlaceholder();
        }

        private void SetPlaceholder()
        {
            if (checkedListBox.CheckedItems.Count == 0)
            {
                textBox.Text = _placeholder;
                textBox.ForeColor = Color.Gray;
            }
        }

        private void RemovePlaceholder()
        {
            if (textBox.Text == _placeholder && textBox.ForeColor == Color.Gray)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Escape)
                return;

            string searchText = textBox.Text;
            if (searchText == _placeholder) searchText = "";

            var filtered = allItems
                .Where(item =>
                {
                    var prop = TypeDescriptor.GetProperties(item)[DisplayMember];
                    if (prop != null)
                    {
                        var value = prop.GetValue(item)?.ToString();
                        return value != null && value.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                    }
                    return false;
                })
                .ToList();

            RefreshList(filtered);
            ShowDropDown();
        }

        public List<object> SelectedValues =>
            checkedListBox.CheckedItems.Cast<object>()
            .Select(item =>
            {
                var prop = TypeDescriptor.GetProperties(item)[ValueMember];
                return prop?.GetValue(item);
            }).ToList();

        public List<object> SelectedItems =>
            checkedListBox.CheckedItems.Cast<object>().ToList();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            Rectangle rectBorderSmooth = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
            int smoothSize = borderSize > 0 ? borderSize : 1;

            using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
            using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                penBorder.Alignment = PenAlignment.Center;
                if (isFocused) penBorder.Color = borderFocusColor;

                graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                graph.DrawPath(penBorder, pathBorder);
            }
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
