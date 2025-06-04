using ApiService.Interfaces;
using Models;
using Models.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.CustomControls;
using ApiService;
using ApiService.Implementetions;
using Newtonsoft.Json.Converters;
using System.Net.Http;
using System.Threading.Tasks;
using System.Globalization;
using ApiService.Constants;

namespace YektamakDesktop
{
    public partial class GlobalData
    {
        /// <summary>
        /// DataGridView nesnesinde DataPropertyName özelliği filtre olarak set edilmiş alanlar için filtre alanı ekler.
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="panelFiltreler"></param>
        /// <param name="panelHeader"></param>
        public static void PlaceFilterFields(DataGridView dataGridView, Panel panelFiltreler)
        {
            int left = 42;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.DataPropertyName == "filtre")
                {

                    if (column.DefaultCellStyle.Format == "d")
                    {
                        CustomTextBoxTarih textBox = new CustomTextBoxTarih();
                        CustomTextBoxTarih textBox2 = new CustomTextBoxTarih();

                        textBox.Width = column.Width - 1;
                        textBox.Top = panelFiltreler.Height - dataGridView.Height - textBox.Height - 1; 
                        textBox.Left = left;
                        textBox.Name = column.Name;
                        textBox.Visible = column.Visible;
                        panelFiltreler.Controls.Add(textBox);
                        
                        textBox2.Width = column.Width - 1;
                        textBox2.Top = panelFiltreler.Height - dataGridView.Height - textBox.Height*2 - 2;
                        textBox2.Left = left;
                        textBox2.Name = column.Name + "First";
                        textBox2.Visible = column.Visible;
                        panelFiltreler.Controls.Add(textBox2);
                    }
                    if (column.DefaultCellStyle.Format.Contains("N"))
                    {
                        CustomTextBoxSayisal textBox = new CustomTextBoxSayisal();
                        CustomTextBoxSayisal textBox2 = new CustomTextBoxSayisal();

                        textBox.Width = column.Width - 1;
                        textBox.Top = panelFiltreler.Height - dataGridView.Height - textBox.Height - 1;
                        textBox.Left = left;
                        textBox.Name = column.Name;
                        textBox.Visible = column.Visible;
                        panelFiltreler.Controls.Add(textBox);

                        textBox2.Width = column.Width - 1;
                        textBox2.Top = panelFiltreler.Height - dataGridView.Height - textBox.Height * 2 - 2;
                        textBox2.Left = left;
                        textBox2.Name = column.Name + "First";
                        textBox2.Visible = column.Visible;
                        panelFiltreler.Controls.Add(textBox2);
                    }
                    else
                    {
                        CustomTextBox textBox = new CustomTextBox();
                        textBox.Width = column.Width - 1;
                        textBox.Top = panelFiltreler.Height - dataGridView.Height - textBox.Height - 1;
                        textBox.Left = left;
                        textBox.Name = column.Name;
                        textBox.Visible = column.Visible;
                        panelFiltreler.Controls.Add(textBox);
                    }
                }
                if (column.DataPropertyName == "cbxFiltre")
                {
                    CustomComboListBox comboBox = new CustomComboListBox();

                    comboBox.Width = column.Width - 1;
                    comboBox.Top = panelFiltreler.Height - dataGridView.Height - comboBox.Height - 1;
                    comboBox.Left = left;
                    comboBox.Name = column.Name;
                    comboBox.Visible = column.Visible;
                    //foreach(Proje proje in GlobalData.tumProjeKodList)
                    //{
                    //    comboBox.AddDataRow(proje.Id, proje.kod);
                    //}
                    panelFiltreler.Controls.Add(comboBox);
                }
                if (column.Visible) left = left + column.Width;
            }
        }
        /// <summary>
        /// Datagridview üstündeki filtre alan genişliklerini kolon genişliklerine eşitler
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="panelFiltreler"></param>
        public static void ResizeFilterFields(DataGridView dataGridView, Panel panelFiltreler)
        {
            int left = 40;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (panelFiltreler.Controls.ContainsKey(column.Name))
                {
                    panelFiltreler.Controls.Find(column.Name, true).First().Width = column.Width;
                    panelFiltreler.Controls.Find(column.Name, true).First().Left = left;
                }
                if (panelFiltreler.Controls.ContainsKey(column.Name + "First"))
                {
                    panelFiltreler.Controls.Find(column.Name + "First", true).First().Width = column.Width;
                    panelFiltreler.Controls.Find(column.Name + "First", true).First().Left = left;
                }
                if (column.Visible) left = left + column.Width;
            }
        }
        /// <summary>
        /// Anantar sütunu verilen kaydın dataTable içindeki index'ini verir
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int IndexOfDataSet(DataTable dataTable, int id)
        {
            int index = -1;
            if (dataTable != null)
            {
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (id == int.Parse(dataTable.Rows[i]["Id"].ToString()))
                        {
                            return i;
                        }
                    }
                }
            }
            return index;
        }
        /// <summary>
        /// Anantar sütunu verilen kaydın dataTable içindeki index'ini verir
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int IndexOfDataSet(DataTable dataTable, long id)
        {
            int index = -1;
            if (dataTable != null)
            {
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (id == int.Parse(dataTable.Rows[i][0].ToString()))
                        {
                            return i;
                        }
                    }
                }
            }
            return index;
        }
        /// <summary>
        /// Anantar sütunu verilen kaydın dataGridView içindeki index'ini verir
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int IndexOfDataGridView(DataGridView dataGridView, int id)
        {
            int index = -1;
            if (dataGridView.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (id == int.Parse(dataGridView.Rows[i].Cells[0].Value.ToString()))
                    {
                        return i;
                    }
                }
            }
            return index;
        }
        /// <summary>
        /// Datagridview'de filtrelenecek alanları model(class) olarak döndürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGridView"></param>
        /// <param name="panelFilter"></param>
        /// <returns></returns>
        public static T GridFilter<T>(Panel panelFilter) where T : IEntity, new()
        {
            T model = new T();
            foreach(Control control in panelFilter.Controls.Cast<Control>().Where(c=>c.GetType().IsSubclassOf(typeof(UserControl))))
            {
                string[] subFields = System.Text.RegularExpressions.Regex.Split(control.Name, @"_");
                MemberInfo member = model.GetType().GetMember(subFields[0])[0];
                Type type = control.GetType();
                string value = "";
                if (control.GetType().GetProperties().Where(x => x.Name == "selectedDataRowValue").Count() > 0)
                {
                    var propertyInfo = control.GetType().GetProperty("selectedDataRowValue");
                    if (propertyInfo != null)
                    {
                        var selectedValue = propertyInfo.GetValue(control);
                        if (selectedValue != null)
                        {
                            value = selectedValue.ToString();
                        }
                    }
                }
                else
                {
                    value = control.GetType().GetProperty("TextCustom").GetValue(control).ToString();
                }
                if (value != "")
                {
                    if (member is PropertyInfo property)
                    {
                        var subField = property.PropertyType.GetField(subFields[1]);

                        if (subField == null)
                        {
                            var subProperty = property.PropertyType.GetProperty(subFields[1]);
                            subField = subProperty.PropertyType.GetField(subFields[2]);
                            subField.SetValue(subProperty.GetValue(property.GetValue(model)), Convert.ChangeType(value, subField.FieldType));
                        }
                        else
                        {
                            subField.SetValue(property.GetValue(model), Convert.ChangeType(value, subField.FieldType));
                        }
                    }
                    else if (member is FieldInfo field)
                    {
                        field.SetValue(model, Convert.ChangeType(value, field.FieldType));
                    }
                }
            }
            return model;
        }
        /// <summary>
        /// Webmethod fonksiyonu ile modele ait veriler filtre nesnesine göre veritabanından çekilir ve datatable nesnesine aktarır
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="filterModel"></param>
        /// <returns></returns>
        public static DataTable FillDataTable<T>(Func<T, string> func, T filterModel) where T : class
        {
            DataTable dataTable = new DataTable();
            string result = func(filterModel);
            if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(result);
            }
            else
            {
                IJsonConverter jsonConverter = new Utilities.Implementations.JsonConverter();
                dataTable = jsonConverter.DeserializeToDataSet(result).Tables[0];
            }
            return dataTable;
        }
        /// <summary>
        /// Webmethod fonksiyonu ile modele ait veriler filtre nesnesine göre veritabanından çekilir ve datatable nesnesine aktarır
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="filterModel"></param>
        /// <returns></returns>
        public static async Task<DataTable> FillDataTableAsync<T>(Func<T, Task<string>> func, T filterModel) where T : class
        {
            DataTable dataTable = new DataTable();

            string result = await func(filterModel); // Async fonksiyon çağrılıyor

            if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(result);
            }
            else
            {
                
                dataTable = _converter.DeserializeToDataSet(result).Tables[0];
            }

            return dataTable;
        }
        /// <summary>
        /// Datatable nesnesini datagrid'e aktarır
        /// </summary>
        /// <param name="dataTable"></param>
        public static string FillDataGrid<T>(DataTable dataTable, DataGridView dataGridView, T filterModel) where T : class, IEntity, new()
        {
            string rowFilter = "";
            dataGridView.Rows.Clear();
            if (dataTable==null || dataTable.Rows.Count == 0)
            {
                //MessageBox.Show("Görüntülenecek kayıt yok");
                return rowFilter;
            }

            DataView dataView = new DataView(dataTable);
            
            RowFilterFromGridFilterFields(filterModel, ref rowFilter);
            dataView.RowFilter = rowFilter==""?"":rowFilter.Substring(5);
            dataTable = dataView.ToTable();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    dataGridView.Rows.Add();
                    foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns)
                    {
                        if (dataGridViewColumn.CellType != typeof(DataGridViewImageCell)) //Güncelle ve sil hücreleri gözardı edilmesi için
                        {
                            if (dataTable.Columns.Contains(dataGridViewColumn.Name))
                            {
                                dataGridView.Rows[i].Cells[dataGridViewColumn.Name].Value = dataTable.Rows[i][dataGridViewColumn.Name];
                            }
                        }
                    }
                }
            }
            else
            {
                //MessageBox.Show("Filtreye uygun kayıt bulunamadı");
            }
            return rowFilter;
        }
        public static void MemberList<T>(T model, string upClassName, ref Dictionary<string,(Type,string)> members) where T : class
        {
            List<MemberInfo> values = model.GetType().GetMembers().ToList();
            
            foreach (MemberInfo memberInfo in model.GetType().GetMembers())
            {
                if (memberInfo is FieldInfo fieldInfo)
                {
                   members.Add(upClassName + fieldInfo.Name, (memberInfo.GetType(), fieldInfo.GetValue(model)?.ToString()));
                }
                else if (memberInfo is PropertyInfo propertyInfo)
                {
                    if (typeof(IEntity).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        Type entityType = propertyInfo.PropertyType; // IEntity'yi implemente eden tipi al
                        object instance = Activator.CreateInstance(entityType); // Yeni bir nesne oluştur
                        MemberList(propertyInfo.GetValue(model), upClassName + memberInfo.Name, ref members);
                    }
                }
            }
        }
        public static void RowFilterFromGridFilterFields<T>(T model,ref string filter, string upClassName = "") where T : class
        {
            List<MemberInfo> values = model.GetType().GetMembers().ToList();

            foreach (MemberInfo memberInfo in model.GetType().GetMembers())
            {
                if (memberInfo is FieldInfo fieldInfo)
                {
                    if (fieldInfo.GetCustomAttribute<FilterAttribute>() != null)
                    {
                        if (fieldInfo.GetValue(model) != null && (Nullable.GetUnderlyingType(fieldInfo.FieldType) != null || fieldInfo.GetValue(model)?.ToString() != "0") && fieldInfo.GetValue(model)?.ToString() != "-1")
                        {
                            if(typeof(string).IsAssignableFrom(fieldInfo.FieldType))
                            {
                                filter += $" and {upClassName + fieldInfo.Name}  like '%{fieldInfo.GetValue(model)?.ToString()}%'";
                            }
                            else
                            {
                                filter += $" and {upClassName + fieldInfo.Name} = '{fieldInfo.GetValue(model)?.ToString()}'";
                            }
                        }
                    }
                }
                else if (memberInfo is PropertyInfo propertyInfo)
                {
                    if (typeof(IEntity).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        RowFilterFromGridFilterFields(propertyInfo.GetValue(model), ref filter, upClassName + memberInfo.Name);
                    }
                    else
                    {
                        if (propertyInfo.GetCustomAttribute<FilterAttribute>() != null)
                        {
                            if (propertyInfo.GetValue(model) != null && (Nullable.GetUnderlyingType(propertyInfo.PropertyType) != null || propertyInfo.GetValue(model)?.ToString() != "0") && propertyInfo.GetValue(model)?.ToString() != "-1")
                            {
                                if (typeof(string).IsAssignableFrom(propertyInfo.PropertyType))
                                {
                                    filter += $" and {upClassName + propertyInfo.Name}  like '%{propertyInfo.GetValue(model)?.ToString()}%'";
                                }
                                else
                                {
                                    filter += $" and {upClassName + propertyInfo.Name} = '{propertyInfo.GetValue(model)?.ToString()}'";
                                }
                            }
                        }
                    }
                }
            }
        }
        public static string RowFilterFromGridFilterFields<T>(DataGridViewColumn dataGridViewColumn, T filterModel,string filter) where T : class
        {
            Type type;
            string valueLastOrDefault = "";
            string valueFirst = "";
            var subFields = Regex.Split(dataGridViewColumn.Name, @"_");
            var s = dataGridViewColumn.Name.Split("_");
            var fieldLastOrDefault = filterModel.GetType().GetField(dataGridViewColumn.Name);
            var fieldFirst = filterModel.GetType().GetField(dataGridViewColumn.Name + "First");
            var property = filterModel.GetType().GetProperty(subFields[0]);
            type = (fieldLastOrDefault==null ? null : fieldLastOrDefault.FieldType);
            if (property!=null && typeof(IEntity).IsAssignableFrom(property.PropertyType))
            {
                string fieldName = subFields[0];
                var subField = property.PropertyType.GetField(fieldName);
                type = subField.FieldType;
                if (subField == null)
                {   //filterModel'in alt modelinin alt modeli ise filtre değeri burada belirlenir
                    //daha da alt modelleri varsa bu if içinde bir if bloğu daha oluşturulmalıdır
                    var subProperty = property.PropertyType.GetProperty(subFields[1]);
                    subField = subProperty.PropertyType.GetField(subFields[2]);
                    type =  subField.FieldType;
                    var deger = subField.GetValue(subProperty.GetValue(property.GetValue(filterModel)));
                    valueLastOrDefault =(deger==null)?string.Empty:deger.ToString(); 
                }
                else
                {
                    
                    var deger = subField.GetValue(property.GetValue(filterModel));
                    valueLastOrDefault = (deger == null) ? string.Empty : deger.ToString();
                }
            }
            if (fieldFirst != null)
            {
                valueFirst = (fieldFirst.GetValue(filterModel) == null) ? "" : fieldFirst.GetValue(filterModel).ToString();
            }
            if (fieldLastOrDefault != null)
            {
                valueLastOrDefault = (fieldLastOrDefault.GetValue(filterModel) == null) ? "" : fieldLastOrDefault.GetValue(filterModel).ToString(); 
            }
            


            if (string.IsNullOrEmpty(filter) && valueLastOrDefault != "")
            {
                if (typeof(int).IsAssignableFrom(type))
                {
                    if (valueLastOrDefault != "0")
                    {
                        filter = $"{dataGridViewColumn.Name} = {valueLastOrDefault}";
                    }
                }
                else if (type == typeof(bool))
                {
                    filter = $"{dataGridViewColumn.Name} = {valueLastOrDefault}";
                }
                else if (type != null && Nullable.GetUnderlyingType(type) == typeof(bool))
                {
                    filter = $"{dataGridViewColumn.Name} = {valueLastOrDefault}";
                }
                else if (!string.IsNullOrEmpty(valueFirst) && valueFirst != DateTime.MinValue.ToString())
                {
                    filter = $"{dataGridViewColumn.Name}  >='{valueFirst}' and {dataGridViewColumn.Name} <='{valueLastOrDefault}' ";
                }
                else
                {
                    if (fieldLastOrDefault!=null && fieldLastOrDefault.FieldType == typeof(DateTime) && valueLastOrDefault != DateTime.MinValue.ToString())
                    {
                        filter = $"{dataGridViewColumn.Name} = '{valueLastOrDefault}'";
                    }
                    else if (valueLastOrDefault != DateTime.MinValue.ToString())
                    {
                        filter = $"{dataGridViewColumn.Name} like '%{valueLastOrDefault}%'";
                    }
                }

            }
            else if (valueLastOrDefault != "" && valueLastOrDefault != DateTime.MinValue.ToString())
            {
                if (typeof(int).IsAssignableFrom(type))
                {
                    if (valueLastOrDefault != "0")
                    {
                        filter += $" and {dataGridViewColumn.Name} = {valueLastOrDefault}";
                    }
                }
                else if (type == typeof(bool))
                {
                    filter += $" and {dataGridViewColumn.Name} = {valueLastOrDefault}";
                }
                else if (Nullable.GetUnderlyingType(type) == typeof(bool))
                {
                    filter += $" and {dataGridViewColumn.Name} = {valueLastOrDefault}";
                }
                //dataView.RowFilter += $"and {dataGridViewColumn.Name} like '%{value}%'";
                else if (!string.IsNullOrEmpty(valueFirst) && valueFirst != DateTime.MinValue.ToString())
                {
                    filter += $" and {dataGridViewColumn.Name}  >='{valueFirst}' and {dataGridViewColumn.Name} <='" +
                        $"{valueLastOrDefault}' ";
                }
                else
                {
                    if (fieldLastOrDefault != null && fieldLastOrDefault.FieldType == typeof(DateTime) && valueLastOrDefault != DateTime.MinValue.ToString())
                    {
                        filter += $" and {dataGridViewColumn.Name} = '{valueLastOrDefault}'";
                    }
                    else if (valueLastOrDefault != DateTime.MinValue.ToString())
                    {
                        filter += $" and {dataGridViewColumn.Name} like '%{valueLastOrDefault}%'";
                    }

                }
            }
            return filter;
        }

        public static void UpdateDataRow<T>(ref DataTable dataTable, T model, int i) where T : IEntity
        {
            UpdateFields(ref dataTable, model, i,"");
            UpdateProperties(ref dataTable, model, i, "");
        }

        private static void UpdateFields<T>(ref DataTable dataTable, T model, int i, string columnNamePreFix) where T : IEntity
        {
            foreach (FieldInfo fieldInfo in model.GetType().GetFields())
            {
                string columnName = columnNamePreFix+fieldInfo.Name;
                if (dataTable.Columns.Contains(columnName))
                {
                    var value = fieldInfo.GetValue(model);

                    if (value is string stringValue)
                    {
                        dataTable.Rows[i][columnName] = stringValue;
                    }
                    else
                    {
                        dataTable.Rows[i][columnName] = JsonConvert.SerializeObject(value??0);
                    }
                    //dataTable.Rows[i][columnName] = fieldInfo.GetValue(model).ToString();
                }
            }
        }
        private static void UpdateProperties<T>(ref DataTable dataTable, T model, int i,string columnNamePreFix) where T : IEntity
        {
            foreach (PropertyInfo propertyInfo in model.GetType().GetProperties())
            {
                string columnName = columnNamePreFix+propertyInfo.Name;
                if (dataTable.Columns.Contains(columnName))
                {
                    var value = propertyInfo.GetValue(model);

                    if (value is null)
                    {
                        dataTable.Rows[i][columnName] = null;
                    }
                    else if (value is string stringValue)
                    {
                        dataTable.Rows[i][columnName] = stringValue;
                    }
                    else if (value is double d)
                    {
                        dataTable.Rows[i][columnName] = d % 1 == 0 ? ((int)d).ToString() : d.ToString(CultureInfo.InvariantCulture);
                    }
                    else if (value is decimal m)
                    {
                        dataTable.Rows[i][columnName] = m % 1 == 0 ? ((int)m).ToString() : m.ToString(CultureInfo.InvariantCulture);
                    }
                    else if (value is float f)
                    {
                        dataTable.Rows[i][columnName] = f % 1 == 0 ? ((int)f).ToString() : f.ToString(CultureInfo.InvariantCulture);
                    }
                    else if (value.GetType().IsPrimitive || value is DateTime)
                    {
                        // Basit türler için ToString kullan
                        dataTable.Rows[i][columnName] = Convert.ToString(value, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        // Karmaşık nesneler için JSON serileştirme
                        dataTable.Rows[i][columnName] = JsonConvert.SerializeObject(value);
                    }
                    //dataTable.Rows[i][columnName] = JsonConvert.SerializeObject(propertyInfo.GetValue(model)).ToString();
                }

                else if (typeof(IEntity).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    UpdateNestedFields(ref dataTable, model, i, propertyInfo, columnName);
                }
            }
        }

        private static void UpdateNestedFields<T>(ref DataTable dataTable, T model, int i, PropertyInfo propertyInfo, string columnNamePreFix) where T : IEntity
        {
            foreach (PropertyInfo nestedPropertyInfo in propertyInfo.PropertyType.GetProperties())
            {
                string columnName = columnNamePreFix + nestedPropertyInfo.Name;
                if (dataTable.Columns.Contains(columnName))
                {
                    var nestedModel = propertyInfo.GetValue(model);
                    dataTable.Rows[i][columnName] = nestedPropertyInfo.GetValue(nestedModel);
                }
                else if (typeof(IEntity).IsAssignableFrom(nestedPropertyInfo.GetValue(propertyInfo.GetValue(model)).GetType()))
                {
                    var nestedModel = (IEntity)nestedPropertyInfo.GetValue(propertyInfo.GetValue(model));
                    UpdateFields(ref dataTable, nestedModel, i, columnName+"_");
                }
                
            }
            foreach (FieldInfo fieldInfo in propertyInfo.PropertyType.GetFields())
            {
                string columnName = columnNamePreFix + fieldInfo.Name;
                if (dataTable.Columns.Contains(columnName))
                {
                    var nestedModel = propertyInfo.GetValue(model);
                    var value = fieldInfo.GetValue(nestedModel);
                    if (fieldInfo.FieldType == typeof(byte[]))
                    {
                        var json = JsonConvert.SerializeObject(value);
                        json = json.Substring(1).Substring(0, json.Length - 2);
                        dataTable.Rows[i][columnName] = json;
                    }
                    else
                    {
                        dataTable.Rows[i][columnName] = value;
                    }
                }
            }
        }
        public static void AdjustControlsOnScroll(DataGridView dataGridView, Panel panelFilter, ScrollEventArgs e, ref int oldScrollOffset)
        {
            int newScrollOffset = dataGridView.HorizontalScrollingOffset;
            int offset = newScrollOffset - oldScrollOffset;
            oldScrollOffset = newScrollOffset;

            foreach (var control in panelFilter.Controls.Cast<Control>().Where(c => c.GetType().IsSubclassOf(typeof(UserControl))))
            {
                control.Left = control.Left - offset;
            }
        }
        public static void DataGridViewCellClick<T>(ref DataTable dataTable,DataGridView dataGridView, DataGridViewCellEventArgs e) where T:IEntity, new()
        {
            if (e.RowIndex == -1) return;
            dataGridView.Rows[e.RowIndex].Selected = true;
            if (e.ColumnIndex == dataGridView.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex || e.ColumnIndex == dataGridView.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
            {
                if (dataGridView.Rows[e.RowIndex].Cells[0].Value == null)
                    return;


                if (e.ColumnIndex == dataGridView.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)//Update
                {
                    UpdateMode(SelectedData<T>(dataTable,dataGridView,e.RowIndex));
                }
                else if (e.ColumnIndex == dataGridView.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)//Delete
                {
                    DeleteRow(SelectedData<T>(dataTable,dataGridView,e.RowIndex), ref dataTable);
                }
            }
        }
        private static T SelectedData<T>(DataTable dataTable,DataGridView dataGridView,int rowIndex) where T:IEntity,new()
        {
            if (dataTable == null || rowIndex < 0) return default(T);
            if (rowIndex >= dataTable.Rows.Count) return default(T);
            T model = new();
            int id = int.Parse(dataGridView.Rows[rowIndex].Cells[0].Value.ToString());

            int i = IndexOfDataSet(dataTable, id);
            IDataTableMapper dataTableConverter = new DataTableMapper();
            model = dataTableConverter.MapToEntity<T>(dataTable.Rows[i]);
            return model;
        }
        private static void UpdateMode<T>(T model) where T:IEntity,new()
        {
            KayitFormuFormAc<T>(model, "UpdateMode");
        }
        private static void DeleteRow<T>(T model,ref DataTable dataTable) where T:IEntity,new()
        {
            DialogResult dialogResult = MessageBox.Show(string.Format("Kaydı silmek istediğinizden emin misiniz"), "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(ApiBaseUrl.server);
                IApiService apiService = new ApiServiceClient(httpClient);
                // Model tipi
                var modelType = model.GetType();

                // "Post" metodunu generic olarak al
                MethodInfo methodInfo = typeof(IApiService)
                    .GetMethods()
                    .First(m => m.Name == "Post" && m.IsGenericMethod);

                // Method'u ilgili generic tipe göre yapılandır
                MethodInfo genericMethod = methodInfo.MakeGenericMethod(modelType);

                // methodName'i oluştur
                string methodName = "Delete" + modelType.Name;

                // Invoke et
                string result = genericMethod.Invoke(apiService, new object[] { model, methodName }).ToString();
                if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("Silme İşlemi Başarılı");
                    int id = 0;
                    MemberInfo[] members=model.GetType().GetMembers();
                    foreach (var member in members.Where(x=>x.MemberType==MemberTypes.Property || x.MemberType==MemberTypes.Field))
                    {
                        if (member.Name.Contains("Id",StringComparison.OrdinalIgnoreCase))
                        {
                            if(member is FieldInfo field)
                            {
                                id=int.Parse(field.GetValue(model).ToString());
                            }
                            else if(member is PropertyInfo property)
                            {
                                id = int.Parse(property.GetValue(model).ToString());
                            }
                            break;
                        }
                    }
                    int i = IndexOfDataSet(dataTable, id);
                    dataTable.Rows[i].Delete();
                }
            }
        }
        /// <summary>
        /// Verilen modelin kayıt formunu açar.
        /// </summary>
        /// <typeparam name="T">IEntity tipinde newlenebilir olmalı</typeparam>
        /// <param name="model">Açılacak formun modeli</param>
        /// <param name="mod">Hangi mod'da açılacaksa o metodun ismi yazılır </param>
        /// <param name="parameters">metod parametreleri geçilir.</param>
        private static void KayitFormuFormAc<T>(T model,string mod) where T:IEntity,new() 
        {
            try
            {
                // Form adını kullanarak tüm assembly'leri tarar.
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                Type targetType = null;

                foreach (var assembly in assemblies)
                {
                    // İlgili formun türünü bulmaya çalışır.

                    targetType = assembly.GetTypes()
                        .Where(type => typeof(Form).IsAssignableFrom(type) && type.Name == typeof(T).Name+"KayitFormu")
                        .FirstOrDefault();

                    if (targetType != null)
                        break;
                }

                // Form bulunduysa açar.
                if (targetType != null)
                {
                    object[] parameters = new object[] { model };
                    MethodInfo method = targetType.GetMethod(mod, new Type[] { typeof(T) });
                    Type type = Type.GetType(targetType.ToString());

                    PropertyInfo propertyInfo = type.GetProperty(type.Name[0].ToString().ToLower() + type.Name.Substring(1), BindingFlags.Static | BindingFlags.Public);
                    object formInstance = propertyInfo.GetValue(null);
                    Form form = formInstance as Form;
                    if (form != null)
                    {
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.Show();
                        method?.Invoke(form, parameters); //method null değilse invoke eder. ? işareti null kontrolünü sağlıyor.
                    }
                }
                else
                {
                    // Form bulunamazsa hata döndürür.
                    MessageBox.Show("Form bulunamadı: " + typeof(T).Name + "KayitFormu");
                }
            }
            catch (Exception ex)
            {
                // Olası istisnaları işler.
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}
