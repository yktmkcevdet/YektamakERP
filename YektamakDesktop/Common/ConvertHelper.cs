using YektamakDesktop.CustomControls;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace YektamakDesktop.Common
{
    public class ConvertHelper
    {
        /// <summary>
        /// Datatable satırlarını model listesine çevirir.
        /// Masaüstü uygulması için DataGridView nesnesini model listesine çevirmek için kullanılır.
        /// Blazor uygulamasında da kullanılabilmesi için Datatable'a çevirme işlemi yapılmıştır.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(List<DataRow> dt) where T : IEntity, new()
        {
            List<T> list = new List<T>();

            foreach (DataRow row in dt)
            {
                T obj = new T();
                obj = DataRowToModel<T>(row);
                list.Add(obj);
            }

            return list;
        }
        /// <summary>
        /// Model listesini datatable'a çevirir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(List<T> data) where T : IEntity, new()
        {
            DataTable table = new DataTable();

            // T türündeki field ve property'leri al ve cachele
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // DataTable sütunlarını oluştur
            AddColumns(table, fields, "");
            AddColumns(table, properties, "");

            // Verileri doldur
            foreach (var entity in data)
            {
                var row = table.NewRow();

                // Field değerlerini doldur
                AddValues(row, fields, entity, "");

                // Property değerlerini doldur
                AddValues(row, properties, entity, "");

                table.Rows.Add(row);
            }

            return table;
        }


        /// <summary>
        /// DataTable'a sütun ekler (Field ve Property için)
        /// </summary>
        /// <param name="table"></param>
        /// <param name="members"></param>
        /// <param name="parentName"></param>
        private static void AddColumns(DataTable table, IEnumerable<MemberInfo> members, string parentName)
        {
            foreach (var member in members)
            {
                Type memberType = GetMemberType(member);
                string seperator = string.IsNullOrEmpty(parentName) ? "" : "_";
                if (IsComplexType(memberType))
                {
                    // Eğer member kompleks bir türse, içindeki alanları analiz et
                    var innerFields = memberType.GetFields(BindingFlags.Public | BindingFlags.Instance);
                    var innerProperties = memberType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    AddColumns(table, innerFields, $"{parentName}{seperator}{member.Name}");
                    AddColumns(table, innerProperties, $"{parentName}{seperator}{member.Name}");
                }
                else
                {
                    // Eğer basit bir türse, doğrudan sütun ekle
                    var columnName = string.IsNullOrEmpty(parentName) ? member.Name : $"{parentName}{seperator}{member.Name}";
                    var columnType = Nullable.GetUnderlyingType(memberType) ?? memberType;
                    table.Columns.Add(columnName, columnType);
                }
            }
        }
        /// <summary>
        /// DataRow'a değer ekler (Field ve Property için)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="members"></param>
        /// <param name="entity"></param>
        /// <param name="parentName"></param>
        private static void AddValues(DataRow row, IEnumerable<MemberInfo> members, object entity, string parentName)
        {
            foreach (var member in members)
            {
                Type memberType = GetMemberType(member);
                object value = GetValue(member, entity);
                string seperator = string.IsNullOrEmpty(parentName) ? "" : "_";

                if (IsComplexType(memberType) && value != null)
                {
                    // Eğer member kompleks bir türse, içindeki alanları analiz et
                    var innerFields = memberType.GetFields(BindingFlags.Public | BindingFlags.Instance);
                    var innerProperties = memberType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    AddValues(row, innerFields, value, $"{parentName}{seperator}{member.Name}");
                    AddValues(row, innerProperties, value, $"{parentName}{seperator}{member.Name}");
                }
                else
                {
                    // Eğer basit bir türse, doğrudan değer ekle
                    var columnName = string.IsNullOrEmpty(parentName) ? member.Name : $"{parentName}{seperator}{member.Name}";
                    row[columnName] = value ?? DBNull.Value;
                }
            }
        }
        /// <summary>
        /// Member türünü alır (Field veya Property)
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static Type GetMemberType(MemberInfo member) =>
            member switch
            {
                FieldInfo field => field.FieldType,
                PropertyInfo property => property.PropertyType,
                _ => throw new ArgumentException("Member must be a field or property.")
            };

        // Helper: Member değerini alır (Field veya Property)
        private static object GetValue(MemberInfo member, object entity) =>
            member switch
            {
                FieldInfo field => field.GetValue(entity),
                PropertyInfo property => property.GetValue(entity),
                _ => throw new ArgumentException("Member must be a field or property.")
            };
        /// <summary>
        /// Kompleks türleri kontrol eder
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsComplexType(Type type)
        {
            // Nullable türü kontrol et
            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
            {
                // Eğer nullable tür bool ise, kompleks olarak sayma
                if (underlyingType == typeof(bool))
                    return false;
            }

            // Eğer byte[] ise kompleks sayma
            if (type == typeof(byte[]))
                return false;

            // Eğer liste türü ise kompleks sayma (string hariç)
            if (typeof(IEnumerable).IsAssignableFrom(type) && type != typeof(string))
                return false;

            // Basit türleri kontrol et
            return !(type.IsPrimitive || type.IsEnum || type.Equals(typeof(string)) || type.Equals(typeof(decimal)));
        }




        /// <summary>
        /// DataRow'ı model nesnesine çevirir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <param name="upClassName"></param>
        /// <returns></returns>
        public static T DataRowToModel<T>(DataRow dataRow, string upClassName = "") where T : IEntity, new()
        {
            T entity = new T();
            foreach (FieldInfo fieldInfo in entity.GetType().GetFields())
            {
                if (dataRow.Table.Columns.Contains(upClassName + fieldInfo.Name))
                {
                    object value = null;
                    if (fieldInfo.FieldType == typeof(byte[]))
                    {
                        value = JsonConvert.DeserializeObject<byte[]>("\"" + dataRow[upClassName + fieldInfo.Name].ToString() + "\"");
                    }
                    else
                    {
                        object data = dataRow[upClassName + fieldInfo.Name];
                        if (data.ToString() == "" && (fieldInfo.FieldType == typeof(int) || fieldInfo.FieldType == typeof(float) || fieldInfo.FieldType == typeof(float) || fieldInfo.FieldType == typeof(double))) //data değeri sayısal değerse
                        {
                            value = Convert.ChangeType(0, fieldInfo.FieldType);
                        }
                        else if (Nullable.GetUnderlyingType(fieldInfo.FieldType) == typeof(bool))
                        {
                            data = data?.ToString() == "true" ? "1" : data?.ToString() == "false" ? "0" : data;
                            value = data?.ToString() == "1" ? true : data?.ToString() == "0" ? false : null;
                        }
                        else if (fieldInfo.FieldType == typeof(bool))
                        {
                            data = data?.ToString() == "true" ? "1" : data?.ToString() == "false" ? "0" : data;
                            value = data?.ToString() == "1" ? true : false;
                        }
                        else
                        {
                            value = Convert.ChangeType(data, fieldInfo.FieldType);
                        }
                    }
                    fieldInfo.SetValue(entity, value);
                }
            }
            foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
            {
                Type type = propertyInfo.PropertyType;
                if (dataRow.Table.Columns.Contains(upClassName + propertyInfo.Name))
                {
                    if (type == typeof(string) || type.IsPrimitive)
                    {
                        object value = null;
                        string data = dataRow[upClassName + propertyInfo.Name].ToString();
                        if (data.ToString() == "" && propertyInfo.PropertyType == typeof(int))
                        {
                            value = Convert.ChangeType(0, propertyInfo.PropertyType);
                        }
                        else
                        {
                            value = Convert.ChangeType(data, propertyInfo.PropertyType);
                        }
                        propertyInfo.SetValue(entity, value);
                    }
                    else
                    {
                        string data = dataRow[upClassName + propertyInfo.Name].ToString();
                        if (typeof(UserControl).IsAssignableFrom(type))
                        {
                            if (type == typeof(CustomComboListBox))
                            {
                                MethodInfo method = type.GetMethod("SelectDataRowId");
                                if (method != null)
                                {
                                    object[] parameters = new object[] { Convert.ToInt32(dataRow[propertyInfo.Name]) };
                                    method.Invoke(propertyInfo.GetValue(entity), parameters);
                                }
                            }
                            else if (type == typeof(CustomTextBox) || type == typeof(CustomTextBoxSayisal) || type == typeof(CustomTextBoxTarih))
                            {
                                if (dataRow.Table.Columns.Contains(propertyInfo.Name))
                                {
                                    type.GetProperty("TextCustom").SetValue(propertyInfo.GetValue(entity), Convert.ToString(dataRow[propertyInfo.Name]));
                                }
                            }
                        }
                        else
                        {
                            object value = JsonConvert.DeserializeObject(data, type);
                            propertyInfo.SetValue(entity, value);
                        }

                    }
                }


                else if (typeof(IEntity).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    MethodInfo method = typeof(ConvertHelper).GetMethod("DataRowToModel").MakeGenericMethod(type);
                    object value = method.Invoke(null, new object[] { dataRow, upClassName + propertyInfo.Name + "_" });
                    propertyInfo.SetValue(entity, value);
                }
            }
            return entity;
        }
    }
}
