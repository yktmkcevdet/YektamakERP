using Spire.Pdf.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.CustomControls
{
    public partial class FilterableComboBox : UserControl
    {
        private ComboBox InnerComboBox => comboBox1;
        private List<object> allItems = new List<object>();

        public FilterableComboBox()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox1.AutoCompleteMode = AutoCompleteMode.None;
            comboBox1.KeyUp += ComboBox1_KeyUp;
        }

        [Browsable(true)]
        public string DisplayMember
        {
            get => comboBox1.DisplayMember;
            set => comboBox1.DisplayMember = value;
        }
        [Browsable(true)]
        public string ValueMember
        {
            get => comboBox1.ValueMember;
            set => comboBox1.ValueMember = value;
        }
        [Browsable(false)]
        public object DataSource
        {
            get => comboBox1.DataSource;
            set => comboBox1.DataSource = value;
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
            set => comboBox1.SelectedValue = value;
        }

        [Browsable(false)]
        public object SelectedObject { get { return comboBox1.SelectedItem; } set { comboBox1.SelectedItem=value; } }

        public event EventHandler SelectedIndexChanged
        {
            add { comboBox1.SelectedIndexChanged += value; }
            remove { comboBox1.SelectedIndexChanged -= value; }
        }
        public event EventHandler SelectedValueChanged
        {
            add { comboBox1.SelectedValueChanged += value; }
            remove { comboBox1.SelectedValueChanged -= value; }
        }

        //protected virtual void OnSelectedIndexChanged(EventArgs e)
        //{
        //    SelectedIndexChanged?.Invoke(this, e);
        //}
        //protected virtual void OnSelectedValueChanged(EventArgs e)
        //{
        //    SelectedValueChanged?.Invoke(this, e);
        //}
        public void SetDataSource<T>(List<T> items)
        {
            allItems = items.Cast<object>().ToList();

            comboBox1.DisplayMember = DisplayMember; // bu değer yukarıdan alınmalı
            comboBox1.ValueMember = ValueMember;
            comboBox1.DataSource = allItems;
        }

        private void RefreshData(List<object> filteredList)
        {
            comboBox1.DisplayMember = DisplayMember;
            comboBox1.ValueMember = ValueMember;
            comboBox1.DataSource = null;
            comboBox1.DataSource = filteredList;
            comboBox1.DroppedDown = true;

            comboBox1.SelectionStart = comboBox1.Text.Length;
            comboBox1.SelectionLength = 0;
        }

        
        private void ComboBox1_KeyUp(object sender, KeyEventArgs e)
        {
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
            comboBox1.Text = searchText;
        }
    }
}
