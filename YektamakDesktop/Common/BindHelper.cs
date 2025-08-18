using Models;
using NPOI.SS.Formula.Functions;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Common
{
    public static class BindHelper
    {
        public static void BindData<T>(FilterableComboBox filterableComboBox, T entity, string valueMember) where T : IEntity
        {
            filterableComboBox.DataBindings.Clear();
            filterableComboBox.DataBindings.Add("SelectedValue", entity, valueMember, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public static void BindData<T>(FilterableCheckedComboBox filterableComboBox, T entity, string valueMember) where T : IEntity
        {
            filterableComboBox.DataBindings.Clear();
            filterableComboBox.DataBindings.Add("SelectedValues", entity, valueMember, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public static void BindDataEnum<T>(FilterableComboBox filterableComboBox, T entity, string valueMember) where T : IEntity
        {
            filterableComboBox.DataBindings.Clear();
            filterableComboBox.DataBindings.Add("SelectedItem", entity, valueMember, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public static void BindData<T>(CustomTextBox customTextBox, T entity, string valueMember) where T : IEntity
        {
            customTextBox.DataBindings.Clear();
            customTextBox.DataBindings.Add("TextCustom", entity, valueMember, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public static void BindData<T>(CustomTextBoxTarih customTextBox, T entity, string valueMember) where T : IEntity
        {
            customTextBox.DataBindings.Clear();
            customTextBox.DataBindings.Add("TextCustom", entity, valueMember, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public static void BindData<T>(CustomTextBoxSayisal customTextBox, T entity, string valueMember) where T : IEntity
        {
            customTextBox.DataBindings.Clear();
            customTextBox.DataBindings.Add("TextCustom", entity, valueMember, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public static void BindData<T>(CheckBox checkBox, T entity, string valueMember) where T : IEntity
        {
            checkBox.DataBindings.Clear();
            checkBox.DataBindings.Add("CheckState", entity, valueMember, true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
