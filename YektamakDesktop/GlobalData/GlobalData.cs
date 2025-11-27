using Newtonsoft.Json;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YektamakDesktop.Abstracts;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop
{
    public partial class GlobalData
    {
        
        public GlobalData()
        {
          
        }
        
        
        public static bool CheckField(string mesaj, CustomTextBox customTextBox)
        {
            bool result = true;

            object value = customTextBox.TextCustom;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                customTextBox.textBox.ForeColor = Color.Red;
                customTextBox.textBox.BackColor = Color.LightPink;
                customTextBox.PlaceholderText = mesaj;
                result = false;
            }
            return result;
        }
        
        public static bool CheckField(string mesaj, CustomComboListBox customComboListBox) 
        {
            bool result = true;

            object value = customComboListBox.selectedDataRowId;

            if (customComboListBox.listBoxDataRows.Count>0 && (value == null || value.ToString()=="-1" || string.IsNullOrWhiteSpace(value.ToString())))
            {
                customComboListBox.textBox.textBox.ForeColor = Color.LightPink;
                customComboListBox.textBox.PlaceholderText = mesaj;
                result = false;
            }
            return result;
        }
        public static bool CheckField(string mesaj,  FilterableComboBox filterableComboBox)
        {
            bool result = true;
            int kayitSayisi = (filterableComboBox.DataSource as IList)?.Count ?? 0;
            if (kayitSayisi == 0) return result;
            object value = filterableComboBox.SelectedValue;

            if (value == null || JsonConvert.SerializeObject(value) == "-1" || string.IsNullOrWhiteSpace(value.ToString()))
            {
                filterableComboBox.ComboBox.BackColor = Color.LightPink;
                filterableComboBox.PlaceholderText = mesaj;
                result = false;
            }
            return result;
        }
        
        public static bool CheckField(string mesaj, CustomTextBoxTarih customTextBoxTarih)
        {
            bool result = true;

            object value = customTextBoxTarih.TextCustom;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                customTextBoxTarih.textBox.BackColor = Color.LightPink;
                customTextBoxTarih.textBox.PlaceholderText = mesaj;
                result = false;
            }
            return result;
        }
        public static bool CheckField<T>(string mesaj, CustomDataGrid<T> customDataGrid) where T : DataControl,new()
        {
            bool result = true;

            int value = customDataGrid.dataSource.Where(x => x.newRec == false).Count();

            if (value == 0)
            {
               MessageBox.Show(mesaj, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            return result;
        }
        public static bool CheckField(string mesaj, CustomTextBoxSayisal customTextBoxSayisal) 
        {
            bool result = true;

            float value = float.TryParse(customTextBoxSayisal.TextCustom.ToString(), out float sayi)?sayi:0;

            if (value == 0)
            {
                customTextBoxSayisal.textBox.BackColor = Color.LightPink;
                customTextBoxSayisal.textBox.PlaceholderText = mesaj;
                result = false;
            }
            return result;
        }
    }
}
