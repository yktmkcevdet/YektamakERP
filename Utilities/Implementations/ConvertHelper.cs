using Models;
using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Reflection;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class ConvertHelper:IConvertHelper
    {
        /// <summary>
        /// Model listesini datatable'a çevirir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable ToDataTable<T>(List<T> data) where T : IEntity, new()
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
        private void AddColumns(DataTable table, IEnumerable<MemberInfo> members, string parentName)
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
        private void AddValues(DataRow row, IEnumerable<MemberInfo> members, object entity, string parentName)
        {
            foreach (var member in members)
            {
                Type memberType = GetMemberType(member);
                object value = GetValue(member, entity);
                if (member.Name == "stokKartDosya")
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
        /// Nesne üyesinin (Field veya Property) tipini alır.
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private Type GetMemberType(MemberInfo member) =>
            member switch
            {
                FieldInfo field => field.FieldType,
                PropertyInfo property => property.PropertyType,
                _ => throw new ArgumentException("Member must be a field or property.")
            };

        /// <summary>
        /// Bir nesne üyesinin(field ya da property) değerini alır.
        /// </summary>
        /// <param name="member"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private object GetValue(MemberInfo member, object entity) =>
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
        public bool IsComplexType(Type type)
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
        public T ToEntity<T>(object dto, object entity = null, string classNamePrefix = "") where T : class, new()
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
                    IConvertHelper helper = new ConvertHelper();
                    var method = typeof(IConvertHelper).GetMethod(nameof(IConvertHelper.ToEntity), BindingFlags.Public | BindingFlags.Instance);
                    var genericMethod = method.MakeGenericMethod(prop.PropertyType);
                    var updatedNested = genericMethod.Invoke(helper, new object[] { dto, nestedEntity, fullName });

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
        public T ToDTO<T>(object entity, string parentName = "", object dto = null) where T : IEntity, new()
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
                    MethodInfo methodInfo = typeof(IConvertHelper).GetMethod(nameof(IConvertHelper.ToDTO), BindingFlags.Public | BindingFlags.Instance, null,
                                                                                new Type[] { typeof(object), typeof(string), typeof(object) },
                                                                                null).MakeGenericMethod(dto.GetType());
                    object newEntity = Activator.CreateInstance(entity.GetType());
                    string name = newEntity.GetType().GetProperties().FirstOrDefault(p => p.Name == member.Name).Name;
                    name = $"{parentName}{name}";
                    IConvertHelper convertHelper = new ConvertHelper();
                    methodInfo.Invoke(convertHelper, new object[] { value, name, dto });
                }
                else
                {
                    var propertyName = string.IsNullOrEmpty(parentName) ? member.Name : $"{parentName}{member.Name}";
                    PropertyInfo propertyInfo = dto.GetType().GetProperty(propertyName);
                    if (propertyInfo != null && propertyInfo.SetMethod != null) propertyInfo.SetValue(dto, value);
                }
            }
            return (T)dto;
        }
    }
}
