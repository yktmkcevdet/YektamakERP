using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace YektamakDesktop.CustomControls
{
    public partial class FilterableComboBox : UserControl
    {
        [Browsable(false)]
        public ReadOnlyComboBox ComboBox => comboBox1;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ReadOnly
        {
            get => comboBox1.ReadOnly;
            set => comboBox1.ReadOnly = value;
        }
        public class ReadOnlyComboBox : ComboBox
        {
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public bool ReadOnly { get; set; }

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

            private const int WM_LBUTTONDOWN = 0x0201;
            private const int WM_LBUTTONDBLCLK = 0x0203;
            private const int WM_KEYDOWN = 0x0100;
            private const int CB_SHOWDROPDOWN = 0x014F;

            public ReadOnlyComboBox()
            {
                // Yazı girişini engelle
                this.KeyPress += (s, e) =>
                {
                    if (ReadOnly)
                        e.Handled = true;
                };

                // Seçim değişince DisplayMember’a göre göster
                this.SelectedIndexChanged += (s, e) =>
                {
                    if (ReadOnly)
                        UpdateDisplayText();
                };
            }

            protected override void WndProc(ref Message m)
            {
                if (ReadOnly)
                {
                    // Fare, klavye ve dropdown açma işlemlerini iptal et
                    if (m.Msg == WM_LBUTTONDOWN ||
                        m.Msg == WM_LBUTTONDBLCLK ||
                        m.Msg == WM_KEYDOWN ||
                        m.Msg == CB_SHOWDROPDOWN)
                        return;
                }

                base.WndProc(ref m);
            }

            protected override void OnCreateControl()
            {
                base.OnCreateControl();

                if (this.DropDownStyle == ComboBoxStyle.DropDown)
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c is TextBox tb)
                        {
                            tb.ReadOnly = ReadOnly;
                            tb.Cursor = Cursors.Default;
                        }
                    }
                }

                if (ReadOnly)
                    UpdateDisplayText();
            }

            protected override void OnEnabledChanged(EventArgs e)
            {
                base.OnEnabledChanged(e);

                if (this.Enabled && this.ReadOnly)
                {
                    this.ForeColor = System.Drawing.SystemColors.WindowText;
                    this.BackColor = System.Drawing.SystemColors.Window;
                }
            }

            private void UpdateDisplayText()
            {
                if (SelectedItem == null)
                    return;

                // DisplayMember varsa onun değerini al
                string displayText = "";

                if (!string.IsNullOrEmpty(DisplayMember))
                {
                    PropertyInfo prop = SelectedItem.GetType().GetProperty(DisplayMember);
                    if (prop != null)
                    {
                        var value = prop.GetValue(SelectedItem);
                        displayText = value?.ToString() ?? "";
                    }
                }
                else
                {
                    // yoksa varsayılan ToString()
                    displayText = SelectedItem.ToString();
                }

                // TextBox’a direkt yaz (kullanıcı yazamaz ama biz yazabiliriz)
                this.Text = displayText;
            }
        }
        private List<object> allItems = new List<object>();
        private bool underlinedStyle = false;
        private bool suppressEvents = false;

        public FilterableComboBox()
        {
            InitializeComponent();

            // Reduce flicker
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            DoubleBuffered = true;

            // ComboBox basic setup
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox1.AutoCompleteMode = AutoCompleteMode.None;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.KeyUp += ComboBox1_KeyUp;
            comboBox1.Enter += comboBox1_Enter;
            comboBox1.Leave += comboBox1_Leave;

            // Layout & region
            this.Resize += (s, e) => { UpdateRegion(); LayoutInnerCombo(); };
            UpdateRegion();
            LayoutInnerCombo();

            SetPlaceholder();
        }

        // --- appearance properties ---
        private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;
        private int borderRadius = 8;
        private Color borderColor = Color.Silver;
        private int borderSize = 1;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor { get => borderColor; set { borderColor = value; Invalidate(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderSize { get => borderSize; set { borderSize = value; Invalidate(); LayoutInnerCombo(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderRadius { get => borderRadius; set { borderRadius = value; UpdateRegion(); Invalidate(); } }

        // Display/Value members
        private string _displayMember = "ad";
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DisplayMember
        {
            get => _displayMember;
            set { _displayMember = value; comboBox1.DisplayMember = value; }
        }
        private string _valueMember = "Id";
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ValueMember
        {
            get => _valueMember;
            set { _valueMember = value; comboBox1.ValueMember = value; }
        }

        // DataSource proxy
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataSource
        {
            get => comboBox1.DataSource;
            set => comboBox1.DataSource = value;
        }
        [Browsable(true)]
        public event MouseEventHandler MouseDown
        {
            add { comboBox1.MouseDown += value; }
            remove { comboBox1.MouseDown -= value; }
        }

        // Placeholder
        private string _placeholder = "Seçiniz...";
        [Category("Behavior")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PlaceholderText
        {
            get => _placeholder;
            set { _placeholder = value; SetPlaceholder(); }
        }

        private void SetPlaceholder()
        {
            // Placeholder only when nothing selected and textbox empty
            if (comboBox1.SelectedIndex == -1 && string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                comboBox1.ForeColor = Color.Gray;
                comboBox1.Text = _placeholder;
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == _placeholder)
            {
                suppressEvents = true;
                comboBox1.Text = "";
                comboBox1.ForeColor = Color.Black;
                suppressEvents = false;
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
                SetPlaceholder();
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            isFocused = true;
            Invalidate();
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            isFocused = false;
            // don't touch this.Text (avoid interfering with comboBox)
            if (string.IsNullOrEmpty(comboBox1.Text))
                SetPlaceholder();
            Invalidate();
        }

        // --- region / painting ---
        private void UpdateRegion()
        {
            // compute rounded region once (on resize / radius change), not every paint
            Rectangle rect = this.ClientRectangle;
            GraphicsPath path = GetFigurePath(rect, borderRadius);
            Region old = this.Region;
            this.Region = new Region(path);
            old?.Dispose();
            path.Dispose();
        }

        private void LayoutInnerCombo()
        {
            // inset the combobox so it doesn't sit exactly on the border. Avoid rapid enter/leave when mouse hovers border.
            int inset = Math.Max(3, borderSize + 2);
            comboBox1.Bounds = new Rectangle(inset, inset, Math.Max(10, this.ClientSize.Width - inset * 2), Math.Max(10, this.ClientSize.Height - inset * 2));
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            comboBox1.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectBorderSmooth = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
            int smoothSize = Math.Max(1, borderSize);

            using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, Math.Max(0, borderRadius - borderSize)))
            using (Pen penBorderSmooth = new Pen(this.Parent?.BackColor ?? this.BackColor, smoothSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Center;
                if (isFocused) penBorder.Color = borderFocusColor;

                // Draw smoothing + border (BUT DO NOT set Region here — we handle region in UpdateRegion).
                g.DrawPath(penBorderSmooth, pathBorderSmooth);
                g.DrawPath(penBorder, pathBorder);
            }
        }
        
        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = Math.Max(0, radius);
            if (r < 1f)
            {
                path.AddRectangle(rect);
                return path;
            }

            float right = rect.Right;
            float bottom = rect.Bottom;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(right - r, rect.Y, r, r, 270, 90);
            path.AddArc(right - r, bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, bottom - r, r, r, 90, 90);
            path.CloseFigure();

            return path;
        }

        // --- selection proxies & events ---
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get => comboBox1.SelectedItem;
            set => comboBox1.SelectedItem = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedValue
        {
            get => comboBox1.SelectedValue;
            set { if (value != null && value.ToString() != "") { comboBox1.SelectedValue = value; } else { SelectedIndex = -1; } }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedDisplayValue
        {
            get => comboBox1.Text;
            set { if (value != null && value.ToString() != "") comboBox1.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get => comboBox1.SelectedIndex;
            set => comboBox1.SelectedIndex = value;
        }

        public event EventHandler SelectedIndexChanged;
        public event EventHandler SelectedValueChanged
        {
            add { comboBox1.SelectedValueChanged += value; }
            remove { comboBox1.SelectedValueChanged -= value; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressEvents) return;
            comboBox1.ForeColor = Color.Black;
            SelectedIndexChanged?.Invoke(this, e);
            SetPlaceholder();
        }

        // --- data helpers ---
        public void SetDataSource<T>(List<T> items)
        {
            suppressEvents = true;
            allItems = items.Cast<object>().ToList();

            comboBox1.DisplayMember = DisplayMember;
            comboBox1.ValueMember = ValueMember;
            object value = comboBox1.SelectedValue;
            var prop = typeof(T).GetProperty(DisplayMember);
            if (prop == null)
                comboBox1.DataSource = items;
            else
                comboBox1.DataSource = items.OrderBy(x => prop.GetValue(x, null)).ToList();

            if (value == null) comboBox1.SelectedIndex = -1; else comboBox1.SelectedValue = value;

            SetPlaceholder();
            suppressEvents = false;
        }

        private void RefreshData(List<object> filteredList)
        {
            if (filteredList != null && filteredList.Count != 0)
            {
                // keep the DataSource usage simple
                comboBox1.DataSource = filteredList;
            }
            comboBox1.DroppedDown = true;
        }

        private void ComboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Escape)
            {
                if (comboBox1.DroppedDown)
                {
                    comboBox1.SelectionStart = comboBox1.Text.Length;
                    comboBox1.SelectionLength = 0;
                }
                return;
            }

            suppressEvents = true;
            string searchText = comboBox1.Text;
            if (string.IsNullOrEmpty(DisplayMember)) return;

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

            RefreshData(filtered);
            suppressEvents = false;
            if (searchText == "")
            {
                comboBox1.DroppedDown = false;
                comboBox1.SelectedIndex = -1;
                return;
            }
            comboBox1.Text = searchText;
            comboBox1.SelectionStart = searchText.Length;
            comboBox1.SelectionLength = 0;
        }
    }
}
