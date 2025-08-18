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
        public string PlaceholderText
        {
            get => _placeholder;
            set { _placeholder = value; SetPlaceholder(); }
        }

        [Category("Custom")]
        public string DisplayMember { get; set; } = "ad";

        [Category("Custom")]
        public string ValueMember { get; set; } = "Id";

        [Category("Custom")]
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }

        [Category("Custom")]
        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }

        public FilterableCheckedComboBox()
        {
            InitializeComponent();
            InitializeCustom();
        }


        private void InitializeCustom()
        {
            textBox.Click += (s, e) => ShowDropDown();
            textBox.Enter += (s, e) => { isFocused = true; Invalidate(); RemovePlaceholder(); };
            textBox.Leave += (s, e) => { isFocused = false; Invalidate(); if (string.IsNullOrEmpty(textBox.Text)) SetPlaceholder(); };
            textBox.KeyUp += TextBox_KeyUp;

            checkedListBox.ItemCheck += CheckedListBox_ItemCheck;

            SetPlaceholder();
        }

        private void ShowDropDown()
        {
            
            checkedListBox.Height = Math.Min(200, checkedListBox.PreferredHeight);
            checkedListBox.Width = this.Width;
            dropDown.Show(this, 0, this.Height);
        }

        public void SetDataSource<T>(List<T> items)
        {
            allItems = items.Cast<object>().ToList();
            RefreshList(allItems);
            SetPlaceholder();
        }

        private void RefreshList(List<object> items)
        {
            checkedListBox.DataSource = null;
            checkedListBox.Items.Clear();
            checkedListBox.DataSource = items;
            checkedListBox.DisplayMember = DisplayMember;
            checkedListBox.ValueMember = ValueMember;
        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate { UpdateText(); });
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

        public List<object> SelectedValues
        {
            get
            {
                return checkedListBox.CheckedItems.Cast<object>().ToList();
            }
            set
            {
                // Önce tüm işaretleri kaldır
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                    checkedListBox.SetItemChecked(i, false);

                if (value == null) return;

                // Gelen listedeki değerleri işaretle
                foreach (var val in value)
                {
                    int index = checkedListBox.Items.IndexOf(val);
                    if (index >= 0)
                        checkedListBox.SetItemChecked(index, true);
                }
            }
        }


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
    public class CustomDropDown : ToolStripDropDown
    {
        public Padding InnerPadding { get; set; } = Padding.Empty;

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            foreach (ToolStripItem item in Items)
            {
                item.Margin = InnerPadding;
            }
        }
    }
}
