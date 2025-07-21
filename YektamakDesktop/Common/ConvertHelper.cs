using Models;
using netDxf.Objects;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Utilities.Interfaces;

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


        public static T ToDTO<T>(object entity, string parentName = "", object dto = null) where T : IEntity, new()
        {
            if (dto == null)
            {
                dto = new T();
            }
            IEnumerable<PropertyInfo> members = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var member in members)
            {
                Type memberType = GetMemberType(member);
                object value = GetValue(member, entity);
                if (memberType.IsClass && memberType != typeof(string) && !typeof(IEnumerable).IsAssignableFrom(memberType))
                {
                    MethodInfo methodInfo = typeof(ConvertHelper).GetMethod("ToDTO", BindingFlags.Static | BindingFlags.Public, null,
                                                                                new Type[] { typeof(object), typeof(string), typeof(object) },
                                                                                null).MakeGenericMethod(dto.GetType());
                    object newEntity = Activator.CreateInstance(entity.GetType());
                    string name = newEntity.GetType().GetProperties().FirstOrDefault(p => p.Name == member.Name).Name;
                    name = $"{parentName}{name}";
                    methodInfo.Invoke(null, new object[] { value, name, dto });
                }
                else
                {
                    var propertyName = string.IsNullOrEmpty(parentName) ? member.Name : $"{parentName}{member.Name}";
                    PropertyInfo propertyInfo = dto.GetType().GetProperty(propertyName);
                    if (propertyInfo != null) propertyInfo.SetValue(dto, value);
                }
            }
            return (T)dto;
        }
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();
        private static readonly ConcurrentDictionary<string, PropertyInfo> PropertyMapCache = new();

        // Circular reference kontrolü için
        private static readonly HashSet<object> ProcessedObjects = new();

        public static T ToDTO2<T>(object entity, string parentName = "", object dto = null) where T : IEntity, new()
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            // Circular reference kontrolü
            if (ProcessedObjects.Contains(entity))
                return dto != null ? (T)dto : new T();

            try
            {
                ProcessedObjects.Add(entity);

                if (dto == null)
                    dto = new T();

                var entityProperties = GetCachedProperties(entity.GetType());
                var dtoProperties = GetCachedProperties(dto.GetType());

                foreach (var entityProperty in entityProperties)
                {
                    try
                    {
                        var value = entityProperty.GetValue(entity);
                        if (value == null) continue;

                        var propertyType = entityProperty.PropertyType;

                        if (IsComplexType(propertyType))
                        {
                            ProcessComplexProperty(entityProperty, value, parentName, dto, dtoProperties);
                        }
                        else
                        {
                            ProcessSimpleProperty(entityProperty, value, parentName, dto, dtoProperties);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log error but continue processing other properties
                        Console.WriteLine($"Error processing property {entityProperty.Name}: {ex.Message}");
                    }
                }

                return (T)dto;
            }
            finally
            {
                ProcessedObjects.Remove(entity);
            }
        }

        private static PropertyInfo[] GetCachedProperties(Type type)
        {
            return PropertyCache.GetOrAdd(type, t =>
                t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                 .Where(p => p.CanRead)
                 .ToArray());
        }

        private static bool IsComplexType(Type type)
        {
            // Nullable türse, gerçek tipini al
            var underlyingType = Nullable.GetUnderlyingType(type) ?? type;

            // Sadece class tiplerini kompleks olarak değerlendir
            if (!underlyingType.IsClass)
                return false;

            // Eğer byte[] ise kompleks sayma
            if (underlyingType == typeof(byte[]))
                return false;

            // IEnumerable olup string olmayanlar kompleks sayılmaz (liste gibi düşünülmüş)
            if (typeof(IEnumerable).IsAssignableFrom(type) && underlyingType != typeof(string))
                return false;

            // String kompleks değil
            if (underlyingType == typeof(string))
                return false;

            // Diğer özel basit class'lar varsa buraya eklenebilir
            if (underlyingType == typeof(decimal) ||
                underlyingType == typeof(DateTime) ||
                underlyingType == typeof(Guid))
                return false;

            // Geriye kalan class'lar kompleks
            return true;
        }
        private static void ProcessComplexProperty(PropertyInfo entityProperty, object value,
            string parentName, object dto, PropertyInfo[] dtoProperties)
        {
            var propertyName = GetPropertyName(entityProperty.Name, parentName);

            // DTO'da bu property var mı kontrol et
            var dtoProperty = FindDtoProperty(dtoProperties, propertyName);
            if (dtoProperty != null && dtoProperty.CanWrite)
            {
                // Eğer DTO property'si de complex type ise, recursive çağrı yap
                if (IsComplexType(dtoProperty.PropertyType))
                {
                    var method = typeof(ConvertHelper).GetMethod(nameof(ToDTO), BindingFlags.Static | BindingFlags.Public);
                    var genericMethod = method.MakeGenericMethod(dtoProperty.PropertyType);

                    var convertedValue = genericMethod.Invoke(null, new object[] { value, parentName, null });
                    dtoProperty.SetValue(dto, convertedValue);
                }
            }
            else
            {
                // Flatten etmek için recursive çağrı
                var method = typeof(ConvertHelper).GetMethod(nameof(ToDTO), BindingFlags.Static | BindingFlags.Public);
                var genericMethod = method.MakeGenericMethod(dto.GetType());

                var newParentName = GetPropertyName(entityProperty.Name, parentName);
                genericMethod.Invoke(null, new object[] { value, newParentName, dto });
            }
        }

        private static void ProcessSimpleProperty(PropertyInfo entityProperty, object value,
            string parentName, object dto, PropertyInfo[] dtoProperties)
        {
            var propertyName = GetPropertyName(entityProperty.Name, parentName);
            var dtoProperty = FindDtoProperty(dtoProperties, propertyName);

            if (dtoProperty != null && dtoProperty.CanWrite)
            {
                // Type conversion gerekiyorsa
                var convertedValue = ConvertValue(value, dtoProperty.PropertyType);
                dtoProperty.SetValue(dto, convertedValue);
            }
        }

        private static string GetPropertyName(string memberName, string parentName)
        {
            return string.IsNullOrEmpty(parentName) ? memberName : $"{parentName}{memberName}";
        }

        private static PropertyInfo FindDtoProperty(PropertyInfo[] dtoProperties, string propertyName)
        {
            var cacheKey = $"{dtoProperties.GetType().FullName}_{propertyName}";

            return PropertyMapCache.GetOrAdd(cacheKey, _ =>
                dtoProperties.FirstOrDefault(p =>
                    string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase)));
        }

        private static object ConvertValue(object value, Type targetType)
        {
            if (value == null) return null;

            var valueType = value.GetType();
            if (valueType == targetType) return value;

            // Nullable type handling
            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var underlyingType = Nullable.GetUnderlyingType(targetType);
                return ConvertValue(value, underlyingType);
            }

            // Basic type conversions
            try
            {
                return Convert.ChangeType(value, targetType);
            }
            catch
            {
                return value; // Conversion başarısız olursa orijinal değeri döndür
            }
        }

        // Cache temizleme metodu (isteğe bağlı)
        public static void ClearCache()
        {
            PropertyCache.Clear();
            PropertyMapCache.Clear();
        }
        public static T ToEntity<T>(object dto, object entity = null, string classNamePrefix = "") where T : class, new()
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (entity == null)
                entity = new T();

            Type entityType = entity.GetType();
            var properties = entityType.GetProperties();

            foreach (var prop in properties)
            {
                if (!prop.CanWrite)
                    continue;

                string fullName = string.IsNullOrEmpty(classNamePrefix) ? prop.Name : classNamePrefix + "." + prop.Name;

                if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string) && !typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                {
                    // İç içe class: örn. entity.StokKart gibi
                    object nestedEntity = prop.GetValue(entity);
                    if (nestedEntity == null)
                    {
                        nestedEntity = Activator.CreateInstance(prop.PropertyType);
                        prop.SetValue(entity, nestedEntity);
                    }

                    // recursive çağrı
                    var method = typeof(ConvertHelper).GetMethod(nameof(ToEntity), BindingFlags.Static | BindingFlags.Public);
                    var genericMethod = method.MakeGenericMethod(prop.PropertyType);
                    var updatedNested = genericMethod.Invoke(null, new object[] { dto, nestedEntity, fullName });

                    prop.SetValue(entity, updatedNested);
                }
                else
                {
                    // DTO tarafındaki düz ad: Örn. ProjeStokKartStokKartAd
                    string flatDtoPropName = fullName.Replace(".", "");
                    PropertyInfo dtoProp = dto.GetType().GetProperty(flatDtoPropName);
                    if (dtoProp != null)
                    {
                        var value = dtoProp.GetValue(dto);
                        prop.SetValue(entity, value);
                    }
                }
            }

            return (T)entity;
        }

    }
}

