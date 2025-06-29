using Models;
using netDxf.Objects;
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
        /// Nesne listesini datatable'a çevirir
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IEnumerable<T> list)
        {
            var dt = new DataTable();
            var props = typeof(T).GetProperties();

            foreach (var prop in props)
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (var item in list)
            {
                var row = dt.NewRow();
                foreach (var prop in props)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                dt.Rows.Add(row);
            }

            return dt;
        }

        /// <summary>
        /// Modeli datarow'a çevirir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataRow ToDataRow<T>(T entity) where T : IEntity, new()
        {
            DataTable table = new DataTable();

            // T türündeki field ve property'leri al ve cachele
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // DataTable sütunlarını oluştur
            AddColumns(table, fields, "");
            AddColumns(table, properties, "");
            var row = table.NewRow();
            
            // Field değerlerini doldur
            AddValues(row, fields, entity, "");
            
            // Property değerlerini doldur
            AddValues(row, properties, entity, "");

            return row;
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
                else if (typeof(IEnumerable).IsAssignableFrom(memberType) && memberType != typeof(string))
                {
                    // Generic tipse (List<T> gibi), içeriğini al
                    if (memberType.IsGenericType)
                    {
                        var columnName = string.IsNullOrEmpty(parentName) ? member.Name : $"{parentName}{member.Name}";
                        var columnType = Nullable.GetUnderlyingType(memberType) ?? memberType;
                        Type itemType = memberType.GetGenericArguments().FirstOrDefault();
                        if (itemType != null && typeof(IEntity).IsAssignableFrom(itemType))
                        {
                            table.Columns.Add(columnName, typeof(string));
                        }
                    }
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
                if(member.Name== "stokKartDosya")
                {
                    // stokKartDosya alanı için özel bir kontrol
                    //if (value is byte[] byteArray)
                    //{
                    //    row[$"{parentName}{member.Name}"] = byteArray.Length > 0 ? (object)byteArray : DBNull.Value;
                    //    continue;
                    //}
                }
                if (IsComplexType(memberType) && value != null)
                {
                    // Eğer member kompleks bir türse, içindeki alanları analiz et
                    var innerFields = memberType.GetFields(BindingFlags.Public | BindingFlags.Instance);
                    var innerProperties = memberType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    AddValues(row, innerFields, value, $"{parentName}{member.Name}");
                    AddValues(row, innerProperties, value, $"{parentName}{member.Name}");
                }
                else if (typeof(IEnumerable).IsAssignableFrom(memberType) && memberType != typeof(string))
                {
                    // Generic tipse (List<T> gibi), içeriğini al
                    if (memberType.IsGenericType)
                    {
                        Type itemType = memberType.GetGenericArguments().FirstOrDefault();
                        if (itemType != null && typeof(IEntity).IsAssignableFrom(itemType))
                        {
                            var columnName = string.IsNullOrEmpty(parentName) ? member.Name : $"{parentName}{member.Name}";
                            row[columnName] = JsonConvert.SerializeObject(value ?? DBNull.Value);
                        }
                    }
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
    }
}
