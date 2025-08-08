using NPOI.POIFS.NIO;
using RtfPipe.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using YektamakDesktop.Common;

namespace YektamakDesktop.CustomControls
{
    public partial class FilterableComboBox : UserControl
    {
        [Browsable(false)]
        public ComboBox ComboBox => comboBox1;
        private List<object> allItems = new List<object>();
        private bool underlinedStyle = false;
        public bool UnderlinedStyle { get => underlinedStyle; set { underlinedStyle = value; this.Invalidate(); } }
        public FilterableComboBox()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox1.AutoCompleteMode = AutoCompleteMode.None;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.KeyUp += ComboBox1_KeyUp;
            comboBox1.Enter += comboBox1_Enter;
            comboBox1.Leave += comboBox1_Leave;
            SetPlaceholder();
        }
        private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;
        private int borderRadius = 5;
        private Color borderColor = Color.Silver;
        private int borderSize = 1;
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }
        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }
        private string _displayMember = "ad"; // Default display member
        [Browsable(true)]
        public string DisplayMember
        {
            get => _displayMember;  
            set { _displayMember = value; this.comboBox1.DisplayMember = value; }
        }
        private string _valueMember = "Id"; // Default value member
        [Browsable(true)]
        public string ValueMember
        {
            get => _valueMember;
            set { _valueMember = value; this.comboBox1.ValueMember = value; }
        }
        [Browsable(false)]
        public object DataSource
        {
            get => comboBox1.DataSource;
            set => comboBox1.DataSource = value;
        }
        private string _placeholder = "Seçiniz...";
        [Category("Behavior")]
        public string PlaceholderText
        {
            get => _placeholder;
            set
            {
                _placeholder = value;
                SetPlaceholder();
            }
        }

        private void SetPlaceholder()
        {
            if (comboBox1.SelectedIndex == -1)
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
                comboBox1.BackColor = Color.White;
                comboBox1.ForeColor = Color.Black;
                suppressEvents = false;
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                SetPlaceholder();
            }
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            isFocused = true;
            if (this.Text == _placeholder)
            {
                this.Text = "";
                this.ForeColor = Color.Black;
            }
            this.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            isFocused = false;
            if (string.IsNullOrEmpty(this.Text))
            {
                SetPlaceholder();
            }
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics graph = e.Graphics;
            Rectangle rectBorderSmooth = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);//Orjinal çerçevenin borderSize kadar küçültülmüş hali
            int smoothSize = borderSize > 0 ? borderSize : 1;//Negatif borderSize olmasın diye
            using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
            using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                //Drawing
                //this.Region = new Region(pathBorderSmooth);//Set the rounded region of UserControl
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                penBorder.Alignment = PenAlignment.Center;
                if (isFocused) penBorder.Color = borderFocusColor;
                //Draw border smoothing
                graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                //Draw border
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
        [Browsable(false)]
        public object SelectedItem
        {
            get => comboBox1.SelectedItem;
            set => comboBox1.SelectedItem = value;
        }

        [Browsable(false)]
        public object SelectedValue
        {
            get => comboBox1.SelectedValue;
            set { if (value != null && value.ToString() != "") comboBox1.SelectedValue = value; }
        }
        [Browsable(false)]
        public object SelectedDisplayValue
        {
            get => comboBox1.Text;
            set { if (value != null && value.ToString() != "") comboBox1.Text = value.ToString(); }
        }
        [Browsable(false)]
        public int SelectedIndex
        {
            get => comboBox1.SelectedIndex;
            set => comboBox1.SelectedIndex = value;
        }

        [Browsable(false)]
        public object SelectedObject;
        //{
        //    get { return comboBox1.SelectedItem; }
        //    set { comboBox1.SelectedItem = value; }
        //}

        public event EventHandler SelectedIndexChanged;
        //{
        //    add { comboBox1.SelectedIndexChanged += value; }
        //    remove { comboBox1.SelectedIndexChanged -= value; }
        //}
        public event EventHandler SelectedValueChanged
        {
            add { comboBox1.SelectedValueChanged += value; }
            remove { comboBox1.SelectedValueChanged -= value; }
        }

        private bool suppressEvents = false;
        public void SetDataSource<T>(List<T> items)
        {
            suppressEvents = true;
            allItems = items.Cast<object>().ToList();

            comboBox1.DisplayMember = DisplayMember; // bu değer yukarıdan alınmalı
            comboBox1.ValueMember = ValueMember;
            object value = comboBox1.SelectedValue; // Seçili indeksi sakla
            comboBox1.DataSource = items;
            if (value == null)
            {
                comboBox1.SelectedIndex = -1; // Seçili öğe yoksa -1 yap
            }
            else
            {
                comboBox1.SelectedValue = value; // Seçili öğe varsa onu ayarla
            }
            SetPlaceholder();
            suppressEvents = false;
        }
        private void RefreshData(List<object> filteredList)
        {
            if (filteredList != null && filteredList.Count != 0)
            {
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressEvents)
                return;

            comboBox1.ForeColor = Color.Black;
            SelectedIndexChanged?.Invoke(this, e);
        }

        private void FilterableComboBox_Load(object sender, EventArgs e)
        {
        }

        private void FilterableComboBox_DoubleClick(object sender, EventArgs e)
        {
            DoubleClick1?.Invoke(this, e);
        }

        [Browsable(true)]
        public event EventHandler DoubleClick1;


        public override Color BackColor
        {
            get => base.BackColor;
            set { base.BackColor = value; comboBox1.BackColor = value; }
        }
        public override Color ForeColor
        {
            get => base.ForeColor;
            set { base.ForeColor = value; comboBox1.ForeColor = value; }
        }

    }
}
