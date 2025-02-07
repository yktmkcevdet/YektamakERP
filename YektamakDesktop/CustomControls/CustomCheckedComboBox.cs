using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YektamakDesktop.CustomControls
{
    public partial class CustomCheckedComboBox : UserControl
    {

        private int listBoxVisualSize = 5;
        private bool focusOnTextBox = false;
        /// <summary>
        /// Check statüsü filter metodu içinde değişirse ItemCheck olayı etkisiz olsun diye bir parametre
        /// </summary>
        private bool filterMode=false;
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
        private List<CheckedListBoxDataRow> _listBoxDataRows;
        public List<CheckedListBoxDataRow> listBoxDataRows
        {
            get => _listBoxDataRows;
        }
        /// <summary>
        /// Filtreleme için kullanılacak
        /// </summary>
        private List<string> listBoxTexts = new List<string>();

        private int _checkedCount;
        public int checkedCount
        {
            get => _checkedCount;
        }

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

        public CustomCheckedComboBox()
        {
            InitializeComponent();
            _listBoxDataRows = new List<CheckedListBoxDataRow>();
            ClearListBox();
        }

        public void AddDataRow(int id, string name)
        {
            checkedListBox.Items.Add(name, false);
            _listBoxDataRows.Add(new CheckedListBoxDataRow { id = id, value = name, isChecked = false });                       
            listBoxTexts.Add(name);//Filtreleme için kullanılacak
        }
        /// <summary>
        /// listBoxDataRows listesindeki duruma göre listBox'ı günceller
        /// </summary>
        public void RefreshListBox()
        {
            checkedListBox.Items.Clear();
            for (int i = 0; i < listBoxDataRows.Count; i++)
            {
                checkedListBox.Items.Add(listBoxDataRows[i].value, listBoxDataRows[i].isChecked);
            }
        }
        public void ClearListBox()
        {
            checkedListBox.Items.Clear();            
            _listBoxDataRows.Clear();
        }

        /// <summary>
        /// Checked durumdaki tüm nesneleri unchecked duruma getirir
        /// </summary>
        public void ClearSelections()
        {
            checkedListBox.ClearSelected();
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
            //CloseListBox();
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
            checkedListBox.Font = this.Font;

            checkedListBox.Width = textBox.Width;
            if (isListBoxOpened)
                checkedListBox.Height = textBox.Height * listBoxVisualSize;
            else
                checkedListBox.Height = 0;

            panelDropDownButton.Height = textBox.Height - (panelDropDownButton.Padding.Top + panelDropDownButton.Padding.Bottom) * 3;
            panelDropDownButton.Width = panelDropDownButton.Height;

            panelDropDownButton.Location = new Point(textBox.Width - panelDropDownButton.Width - panelDropDownButton.Padding.Right, panelDropDownButton.Padding.Top * 2);

            this.Height = (this.Padding.Top + this.Padding.Bottom) + textBox.Height + checkedListBox.Height;
        }

        private void CustomCheckedComboBox_FontChanged(object sender, EventArgs e)
        {
            textBox.Font = this.Font;
            checkedListBox.Font = this.Font;
            Resize_CustomCheckedComboBox();
        }

        private void SwitchListBoxVisibility()
        {
            if (checkedListBox.Visible)
            {
                checkedListBox.Visible = false;
                isListBoxOpened = false;
            }
            else
            {
                checkedListBox.Visible = true;
                isListBoxOpened=true;
                this.BringToFront();
            }
            Resize_CustomCheckedComboBox();
        }
        private void CloseListBox()
        {
            checkedListBox.Visible = false;
            isListBoxOpened=false;
            Resize_CustomCheckedComboBox();
        }
        private void OpenListBox()
        {
            checkedListBox.Visible = true;
            isListBoxOpened = true;
            Resize_CustomCheckedComboBox();
            this.BringToFront();
        }

        

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!filterMode)
            {
                CheckedItemsChanged(e);
            }            
        }

        private void CheckedItemsChanged(ItemCheckEventArgs e)
        {
            //filtrelenmiş listede seçim yapıyorsak filtreden geçmemiş seçilenlerin seçimleri etkilenmemeli
            //buna göre bir şey düşünmek lazım
            //bunun için yeni seçilen şeyin durumuna bakarak esas listeye ekleme çıkarma yapılmalı
            //Özetle bu metod filtreli haldeyken de çağırılabilir bunu düşünerek hareket etmeliyiz
            placeHolderText = "";

            if (e.NewValue == CheckState.Checked)
            {
                _listBoxDataRows.Find(x => x.value == checkedListBox.Items[e.Index].ToString()).isChecked = true;
            }
            else
            {
                _listBoxDataRows.Find(x => x.value == checkedListBox.Items[e.Index].ToString()).isChecked = false;
            }

            List<string> checkedItems = new List<string>();
            _checkedCount = 0;
            foreach (var item in _listBoxDataRows)
            {
                if (item.isChecked)
                {
                    checkedItems.Add(item.value);
                    _checkedCount++;
                }
            }
            
            for (int i = 0; i < checkedItems.Count; i++)
            {                
                if (i==0)
                {
                    placeHolderText += checkedItems[i];
                }
                else if (i==4)
                {
                    placeHolderText += "...";                    
                }
                else if(i<4)
                {
                    placeHolderText += " & " + checkedItems[i];
                }
            }
            if (!focusOnTextBox)
            {
                textBox.TextCustom = placeHolderText;
            }
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            

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
            if (this.Key_Press!=null)
            {
                this.Key_Press(this, e);
            }
        }

        private void textBox_Key_Up(object sender, KeyEventArgs e)
        {
            if (this.Key_Up!=null)
            {
                this.Key_Up(this, e);
            }
            textBoxText = textBox.TextCustom;
            //MessageBox.Show(textBox.TextCustom);
            if (!String.IsNullOrEmpty(textBoxText))
                FilterListBox();
            else
            {
                checkedListBox.Items.Clear();
                checkedListBox.Items.AddRange(listBoxTexts.ToArray());

                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    if (_listBoxDataRows.Find(x => x.isChecked && x.value == checkedListBox.Items[i].ToString()) != null)
                        checkedListBox.SetItemCheckState(i, CheckState.Checked);
                }
            }            
        }

        private void textBox_CustomEnter(object sender, EventArgs e)
        {
            OpenListBox();
            textBox.TextCustom = textBoxText;
            focusOnTextBox = true;
        }

        private void textBox_CustomLeave(object sender, EventArgs e)
        {
            textBox.TextCustom = placeHolderText;
            focusOnTextBox = false;
        }

        private void FilterListBox()
        {
            filterMode = true;
            List<string> filteredList = listBoxTexts.FindAll(x => x.ToUpper().Contains(textBoxText.ToUpper()));
            checkedListBox.Items.Clear();
            checkedListBox.Items.AddRange(filteredList.ToArray());
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (_listBoxDataRows.Find(x => x.isChecked && x.value == checkedListBox.Items[i].ToString()) != null)
                    checkedListBox.SetItemCheckState(i,CheckState.Checked);
            }
            
            //MessageBox.Show("FilterListBox Called.\r\n filteredList.Count : " + filteredList.Count.ToString());
            filterMode = false;
        }
        
    }
    /// <summary>
    /// CheckedListBox verilerini ayrı listelerde klonlayabilmek için kullanıyoruz
    /// </summary>
    public class CheckedListBoxDataRow
    {
        public int id;
        public string value;
        public bool isChecked;
    }

}