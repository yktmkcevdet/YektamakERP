using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace YektamakDesktop.CustomControls
{
    /// <summary>
    /// Filtreleme fonksiyonu olan comboboxs
    /// </summary>
    public partial class CustomComboListBox : UserControl
    {
        private int listBoxVisualSize = 5;

        private bool _focusOnTextBox = false;
        private bool focusOnTextBox
        {
            get => _focusOnTextBox;
            set
            {
                _focusOnTextBox = value;
                if (!value)
                {
                    CheckFocusOnControl();
                }
            }
        }
        private bool _focusOnPanel = false;
        private bool focusOnPanel
        {
            get => _focusOnPanel;
            set
            {
                _focusOnPanel = value;
                if (!value)
                {
                    CheckFocusOnControl();
                }
            }
        }
        private bool _focusOnListBox = false;
        private bool focusOnListBox
        {
            get => _focusOnListBox;
            set
            {
                _focusOnListBox = value;
                if (!value)
                {
                    CheckFocusOnControl();
                }
            }
        }
        /// <summary>
        /// ListBox büyüklüğünü görünmesi istenen eleman sayısına göre ayarlar
        /// </summary>
        public int ListBoxVisualSize
        {
            get => listBoxVisualSize;
            set
            {
                if (value > 1)
                    listBoxVisualSize = value;
                Resize_CustomCheckedComboBox();
            }
        }

        public bool isListBoxOpened = false;

        private string textBoxText, placeHolderText;
        private List<ListBoxDataRow> _listBoxDataRows = new();
        public List<ListBoxDataRow> listBoxDataRows
        {
            get => _listBoxDataRows;
        }
        /// <summary>
        /// Filtreleme için kullanılacak
        /// </summary>
        private List<string> listBoxTexts = new();



        private int _selectedDataRowId = -1;
        public int selectedDataRowId { get => _selectedDataRowId; }
        private string _selectedDataRowValue;
        public string selectedDataRowValue { get => _selectedDataRowValue; }


        [Browsable(true)]
        [Category("Property Changed")]
        [Description("Event is raised when the value of the Text property is changed on Control.")]
        public new event EventHandler TextChanged;

        [Browsable(true)]
        [Category("Key")]
        [Description("Occurs when the control has focus and the user presses and releases a key.")]
        public event EventHandler Key_Press;

        [Browsable(true)]
        [Category("Key")]
        [Description("Occurs when a key is released.")]
        public event KeyEventHandler Key_Up;

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Occurs when the value of the SelectedIndex property changes.")]
        public event EventHandler SelectedIndexChanged;

        public CustomComboListBox()
        {
            InitializeComponent();
            ClearListBox();
            _listBoxDataRows = new List<ListBoxDataRow>();
        }

        public void AddDataRow(int id, string name)
        {
            listBox.Items.Add(name);
            _listBoxDataRows.Add(new ListBoxDataRow { id = id, value = name });
            listBoxTexts.Add(name);//Filtreleme için kullanılacak
        }

        /// <summary>
        /// listBoxDataRow listesinden id numaralı nesneyi çıkarıp listbox görünümünü de yeniden düzenler
        /// </summary>
        /// <param name="id"></param>
        public void RemoveDataRow(int id)
        {
            try
            {
                listBoxDataRows.Remove(listBoxDataRows.Find(dataRow => dataRow.id == id));
                RefreshListBox();
            }
            catch { }
        }
        /// <summary>
        /// listBoxDataRows listesindeki duruma göre listBox'ı günceller
        /// </summary>
        public void RefreshListBox()
        {
            listBox.Items.Clear();
            listBoxTexts.Clear();
            placeHolderText = "";
            textBox.PlaceholderText = placeHolderText;
            _selectedDataRowId = -1;
            _selectedDataRowValue = "";
            for (int i = 0; i < listBoxDataRows.Count; i++)
            {
                listBox.Items.Add(listBoxDataRows[i].value);
                listBoxTexts.Add(listBoxDataRows[i].value);
            }
        }
        /// <summary>
        /// Combolistbox'ı tamamen temizler
        /// </summary>
        public void ClearListBox()
        {
            listBox.Items.Clear();
            _listBoxDataRows.Clear();
            listBoxTexts.Clear();
            SelectDataRowId(-1);
        }

        /// <summary>
        /// Checked durumdaki tüm nesneleri unchecked duruma getirir
        /// </summary>
        public void ClearSelections()
        {
            listBox.ClearSelected();
            //for (int i = 0; i < checkedListBox.Items.Count; i++)
            //{
            //    checkedListBox.SetItemChecked(i, false);
            //}
        }

        private void CustomCheckedComboBox_Load(object sender, EventArgs e)
        {
            Resize_CustomCheckedComboBox();
            CloseListBox();
        }



        private void panelDropDownButton_Click(object sender, EventArgs e)
        {
            SwitchListBoxVisibility();
        }

        private void CustomCheckedComboBox_MouseLeave(object sender, EventArgs e)
        {

        }

        private void CustomCheckedComboBox_Leave(object sender, EventArgs e)
        {
            CloseListBox();
        }

        private void CustomCheckedComboBox_Resize(object sender, EventArgs e)
        {
            Resize_CustomCheckedComboBox();
        }

        private void Resize_CustomCheckedComboBox()
        {
            textBox.Width = this.Width - this.Padding.Horizontal;
            textBox.Font = this.Font;
            listBox.Font = this.Font;

            listBox.Width = textBox.Width;
            if (isListBoxOpened)
                listBox.Height = textBox.Height * listBoxVisualSize;
            else
                listBox.Height = 0;

            panelDropDownButton.Height = textBox.Height - (panelDropDownButton.Padding.Top + panelDropDownButton.Padding.Bottom) * 3;
            panelDropDownButton.Width = panelDropDownButton.Height;

            panelDropDownButton.Location = new Point(textBox.Width - panelDropDownButton.Width - panelDropDownButton.Padding.Right, panelDropDownButton.Padding.Top * 2);

            this.Height = (this.Padding.Top + this.Padding.Bottom) + textBox.Height + listBox.Height;
        }

        private void CustomCheckedComboBox_FontChanged(object sender, EventArgs e)
        {
            textBox.Font = this.Font;
            listBox.Font = this.Font;
            Resize_CustomCheckedComboBox();
        }

        private void SwitchListBoxVisibility()
        {
            if (listBox.Visible)
            {
                listBox.Visible = false;
                isListBoxOpened = false;
            }
            else
            {
                listBox.Visible = true;
                isListBoxOpened = true;
                this.BringToFront();
            }
            Resize_CustomCheckedComboBox();
        }
        private void CloseListBox()
        {
            listBox.Visible = false;
            isListBoxOpened = false;
            Resize_CustomCheckedComboBox();
            //this.Parent.Focus();
        }
        private void OpenListBox()
        {
            listBox.Visible = true;
            isListBoxOpened = true;
            Resize_CustomCheckedComboBox();
            this.BringToFront();
        }






        private void textBox_Enter(object sender, EventArgs e)
        {
            focusOnTextBox = true;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            focusOnTextBox = false;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.TextChanged != null)
            {
                this.TextChanged(this, e);
            }

        }
        /// <summary>
        /// Bu olayla birlikte textBox KeyPress event'i bu kontrolün Key_Press eventini tetiklemiş oluyor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Key_Press(object sender, KeyPressEventArgs e)
        {
            if (this.Key_Press != null)
            {
                this.Key_Press(this, e);
            }
        }

        private void textBox_Key_Up(object sender, KeyEventArgs e)
        {
            if (this.Key_Up != null)
            {
                this.Key_Up(this, e);
            }
            textBoxText = textBox.TextCustom;
            //MessageBox.Show(textBox.TextCustom);
            if (!String.IsNullOrEmpty(textBoxText))
                FilterListBox();
            else
            {
                listBox.Items.Clear();
                listBox.Items.AddRange(listBoxTexts.ToArray());
            }
        }

        private void textBox_CustomEnter(object sender, EventArgs e)
        {
            OpenListBox();
            textBox.TextCustom = textBoxText;
            focusOnTextBox = true;
        }


        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                placeHolderText = listBox.Items[listBox.SelectedIndex].ToString();
            }

            if (!focusOnTextBox)
            {
                textBox.TextCustom = placeHolderText;
            }
            _selectedDataRowId = -1;
            try
            {
                _selectedDataRowId = listBoxDataRows[listBoxDataRows.FindIndex(x => x.value == placeHolderText)].id;
            }
            catch { }
            if (_selectedDataRowId > -1)
            {
                _selectedDataRowValue = placeHolderText;
            }
            CloseListBox();

            if (this.SelectedIndexChanged != null)
            {
                this.SelectedIndexChanged(this, e);
            }
        }

        private void panelDropDownButton_Enter(object sender, EventArgs e)
        {
            focusOnPanel = true;
        }

        private void panelDropDownButton_Leave(object sender, EventArgs e)
        {
            focusOnPanel = false;
        }

        private void listBox_Enter(object sender, EventArgs e)
        {
            focusOnListBox = true;
        }

        private void listBox_Leave(object sender, EventArgs e)
        {
            focusOnListBox = false;
        }
        /// <summary>
        /// Eğer bu custom control üzerindeki hiçbir şey üzerinde focus kalmamışsa listbox'ı kapat
        /// </summary>
        private void CheckFocusOnControl()
        {
            if (!focusOnTextBox && !focusOnListBox)
            {
                //CloseListBox();
            }
        }

        private void FilterListBox()
        {
            List<string> filteredList = listBoxTexts.FindAll(x => x.ToUpper().Contains(textBoxText.ToUpper()));
            listBox.Items.Clear();
            listBox.Items.AddRange(filteredList.ToArray());


            //MessageBox.Show("FilterListBox Called.\r\n filteredList.Count : " + filteredList.Count.ToString());
        }

        /// <summary>
        /// Verilen index'teki kaydı seçer SelectedIndexChanged eventini de çağırır
        /// </summary>
        /// <param name="listBoxIndex"></param>
        public void Select(int listBoxIndex)
        {
            if (listBoxIndex > -1 && listBox.Items.Count > 0)
            {
                listBox.SelectedIndex = listBoxIndex;
            }
        }
        /// <summary>
        /// Id numarası verilen DataRow'un listbox'taki index değerini verir. Eğer böyle bir id bulunamazsa -1 döner.
        /// </summary>
        /// <param name="dataRowId"></param>
        /// <returns></returns>
        public int IndexOfDataRowId(int dataRowId)
        {
            int listboxIndex = listBoxDataRows.FindIndex(x => x.id == dataRowId);
            return listboxIndex;
        }
        /// <summary>
        /// Id numarası verilen DataRow'un listbox'taki index değerini verir. Eğer böyle bir id bulunamazsa -1 döner.
        /// </summary>
        /// <param name="dataRowId"></param>
        /// <returns></returns>
        public int IndexOfDataRowId(long dataRowId)
        {
            int listboxIndex = listBoxDataRows.FindIndex(x => x.id == dataRowId);
            return listboxIndex;
        }

        /// <summary>
        /// Verilen dataRowId numaralı kaydı seçer ve listbox'ın SelectedIndexChanged eventini de çağırır
        /// </summary>
        /// <param name="dataRowId"></param>
        public void SelectDataRowId(int dataRowId)
        {
            if (dataRowId > -1 && listBox.Items.Count > 0)
            {
                Select(IndexOfDataRowId(dataRowId));
            }
            else
            {
                _selectedDataRowId = -1;
                textBox.TextCustom = "";
                placeHolderText = "";
                listBox.ClearSelected();
            }
        }
        public void SelectDataRowId(long dataRowId)
        {
            if (dataRowId > -1 && listBox.Items.Count > 0)
            {
                Select(IndexOfDataRowId(dataRowId));
            }
            else
            {
                _selectedDataRowId = -1;
                textBox.TextCustom = "";
                placeHolderText = "";
                listBox.ClearSelected();
            }
        }
        public void SelectDataRowValue(string dataRowValue)
        {
            if (!string.IsNullOrEmpty(dataRowValue) && listBox.Items.Count >= 0)
            {
                ListBoxDataRow listBoxDataRow = (listBoxDataRows.Find(x => x.value == dataRowValue));
                if (listBoxDataRow != null)
                {
                    Select(IndexOfDataRowId(listBoxDataRow.id));
                }
                else
                {
                    placeHolderText = dataRowValue;
                    listBox_SelectedIndexChanged(null, null);
                }
            }
            else
            {
                _selectedDataRowId = -1;
                textBox.TextCustom = "";
                placeHolderText = "";
                listBox.ClearSelected();
            }
        }

        private void listBox_MouseLeave(object sender, EventArgs e)
        {
            textBox.TextCustom = placeHolderText;
            Point mousePosition = Cursor.Position; // Fare imlecinin ekran koordinatları

            // TextBox'un sınırlarını ekran koordinatlarına dönüştürme
            Rectangle textBoxBounds = textBox.Bounds;
            Point textBoxTopLeft = textBox.PointToScreen(textBoxBounds.Location);
            Size textBoxSize = textBoxBounds.Size;
            Rectangle textBoxScreenBounds = new Rectangle(textBoxTopLeft, textBoxSize);
            if (!textBoxScreenBounds.Contains(mousePosition))
            {
                CloseListBox();
            }
            focusOnTextBox = false;
        }
    }
    /// <summary>
    /// CheckedListBox verilerini ayrı listelerde klonlayabilmek için kullanıyoruz
    /// </summary>
    public class ListBoxDataRow
    {
        public int id;
        public string value;
    }


}