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
        /// Model içindeki Field ve Property'leri DataTable'a sütun olarak ekler
        /// </summary>
        /// <param name="table"></param>
        /// <param name="members"></param>
        /// <param name="parentName"></param>
        private static void AddColumns(DataTable table, IEnumerable<MemberInfo> members, string parentName)
        {
            foreach (var member in members)
            {
                Type memberType = GetMemberType(member);
                if (IsComplexType(memberType))
                {
                    // Eğer member kompleks bir türse, içindeki alanları analiz et
                    var innerFields = memberType.GetFields(BindingFlags.Public | BindingFlags.Instance);
                    var innerProperties = memberType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    AddColumns(table, innerFields, $"{parentName}{member.Name}");
                    AddColumns(table, innerProperties, $"{parentName}{member.Name}");
                }
                else
                {
                    // Eğer basit bir türse, doğrudan sütun ekle
                    var columnName = string.IsNullOrEmpty(parentName) ? member.Name : $"{parentName}{member.Name}";
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

                if (IsComplexType(memberType) && value != null)
                {
                    // Eğer member kompleks bir türse, içindeki alanları analiz et
                    var innerFields = memberType.GetFields(BindingFlags.Public | BindingFlags.Instance);
                    var innerProperties = memberType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    AddValues(row, innerFields, value, $"{parentName}{member.Name}");
                    AddValues(row, innerProperties, value, $"{parentName}{member.Name}");
                }
                else
                {
                    // Eğer basit bir türse, doğrudan değer ekle
                    var columnName = string.IsNullOrEmpty(parentName) ? member.Name : $"{parentName}{member.Name}";
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

        /// <summary>
        /// Member değerini alır (Field veya Property)
        /// </summary>
        /// <param name="member"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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
            // Nullable türse, gerçek tipini al
            var underlyingType = Nullable.GetUnderlyingType(type) ?? type;

            // Eğer byte[] ise kompleks sayma
            if (underlyingType == typeof(byte[]))
                return false;

            // IEnumerable olup string olmayanlar kompleks sayılmaz (liste gibi düşünülmüş)
            if (typeof(IEnumerable).IsAssignableFrom(type) && underlyingType != typeof(string))
                return false;

            // Basit türler
            return !(underlyingType.IsPrimitive
                     || underlyingType.IsEnum
                     || underlyingType == typeof(string)
                     || underlyingType == typeof(decimal)
                     || underlyingType == typeof(DateTime)
                     || underlyingType == typeof(Guid));
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
                        var underlyingType = Nullable.GetUnderlyingType(fieldInfo.FieldType) ?? fieldInfo.FieldType;
                        var type=fieldInfo.FieldType;
                        object data = dataRow[upClassName + fieldInfo.Name];
                        if (data.ToString() == "" && (type == typeof(int) || type == typeof(float) || type == typeof(double))) //data değeri sayısal değerse
                        {
                            value = Convert.ChangeType(0, fieldInfo.FieldType);
                        }
                        else if (underlyingType == typeof(bool))
                        {
                            data = data?.ToString() == "true" ? true : data?.ToString() == "false" ? false : data;
                            value = data?.ToString() == "1" ? true : data?.ToString() == "0" ? false : null;
                        }
                        else
                        {
                            value = data == null || (data.ToString() is string str && string.IsNullOrWhiteSpace(str)) ? null : Convert.ChangeType(data, underlyingType);
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
                        if (data == null && (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(float) || propertyInfo.PropertyType == typeof(double)))
                        {
                            value = Convert.ChangeType(0, propertyInfo.PropertyType);
                        }
                        else
                        {
                            Type targetType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                            value = data == null || (data.ToString() is string str && string.IsNullOrWhiteSpace(str)) ? null : Convert.ChangeType(data, targetType);
                            //value = Convert.ChangeType(data, propertyInfo.PropertyType);
                        }
                        propertyInfo.SetValue(entity, value);
                    }
                    else
                    {
                        var data = dataRow[upClassName + propertyInfo.Name].ToString();
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
                            object value;
                            if (data.ToString() == "" && (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(float) || propertyInfo.PropertyType == typeof(double))) //data değeri sayısal değerse
                            {
                                value = Convert.ChangeType(0, propertyInfo.PropertyType);
                            }
                            else if (Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(bool) || propertyInfo.PropertyType == typeof(bool))
                            {
                                value = data?.ToString() == "true" ? true : false;
                            }
                            else if (Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(double))
                            {
                                Type targetType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                                value = data == null || (data.ToString() is string str && string.IsNullOrWhiteSpace(str)) ? null : Convert.ChangeType(data, targetType);
                            }
                            else
                            {
                                value = JsonConvert.DeserializeObject(data, type);
                            }
                            propertyInfo.SetValue(entity, value);
                        }

                    }
                }
                else if (typeof(IEntity).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    MethodInfo method = typeof(ConvertHelper).GetMethod("DataRowToModel").MakeGenericMethod(type);
                    object value = method.Invoke(null, new object[] { dataRow, upClassName + propertyInfo.Name });
                    propertyInfo.SetValue(entity, value);
                }
            }
            return entity;
        }
    }
}
