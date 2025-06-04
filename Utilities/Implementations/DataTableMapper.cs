using Models;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class DataTableMapper : IDataTableMapper
    {
        /// <summary>
        /// DataTable satırlarını entity listesine dönüştürür.
        /// Masaüstü uygulaması için DataGridView nesnesini model listesine çevirmek için kullanılır.
        /// Blazor uygulamasında da kullanılabilmesi için DataTable'a çevirme işlemi yapılmıştır.
        /// </summary>
        /// <typeparam name="T">Dönüştürülecek entity tipi</typeparam>
        /// <param name="dataRows">Dönüştürülecek DataRow listesi</param>
        /// <returns>Entity listesi</returns>
        public List<T> MapToEntityList<T>(List<DataRow> dataRows) where T : IEntity, new()
        {
            if (dataRows == null)
                return new List<T>();

            var entityList = new List<T>();

            foreach (var row in dataRows)
            {
                var entity = MapToEntity<T>(row);
                entityList.Add(entity);
            }

            return entityList;
        }

        /// <summary>
        /// DataRow'u entity nesnesine dönüştürür
        /// </summary>
        /// <typeparam name="T">Dönüştürülecek entity tipi</typeparam>
        /// <param name="dataRow">Kaynak DataRow</param>
        /// <param name="classNamePrefix">Sütun adı öneki</param>
        /// <returns>Dönüştürülmüş entity</returns>
        public T MapToEntity<T>(DataRow dataRow, string classNamePrefix = "") where T : IEntity, new()
        {
            if (dataRow == null)
                throw new ArgumentNullException(nameof(dataRow));

            var entity = new T();

            MapFields(entity, dataRow, classNamePrefix);
            MapProperties(entity, dataRow, classNamePrefix);

            return entity;
        }

        /// <summary>
        /// Field'ları map eder
        /// </summary>
        private void MapFields<T>(T entity, DataRow dataRow, string classNamePrefix) where T : IEntity
        {
            var fields = entity.GetType().GetFields();

            foreach (var field in fields)
            {
                var columnName = classNamePrefix + field.Name;

                if (!dataRow.Table.Columns.Contains(columnName))
                    continue;

                var value = ConvertFieldValue(dataRow[columnName], field.FieldType);
                field.SetValue(entity, value);
            }
        }

        /// <summary>
        /// Property'leri map eder
        /// </summary>
        private void MapProperties<T>(T entity, DataRow dataRow, string classNamePrefix) where T : IEntity
        {
            var properties = entity.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (!property.CanWrite)
                    continue;

                var columnName = classNamePrefix + property.Name;

                if (dataRow.Table.Columns.Contains(columnName))
                {
                    MapSimpleProperty(entity, dataRow, property, columnName);
                }
                else if (IsEntityType(property.PropertyType))
                {
                    MapNestedEntity(entity, dataRow, property, classNamePrefix);
                }
            }
        }

        /// <summary>
        /// Basit property map eder (string, primitive, complex)
        /// </summary>
        private void MapSimpleProperty<T>(T entity, DataRow dataRow, PropertyInfo property, string columnName) where T : IEntity
        {
            var propertyType = property.PropertyType;

            if (IsSimpleType(propertyType))
            {
                var value = ConvertSimpleValue(dataRow[columnName], propertyType);
                property.SetValue(entity, value);
            }
            else
            {
                var jsonData = dataRow[columnName]?.ToString();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    var value = JsonConvert.DeserializeObject(jsonData, propertyType);
                    property.SetValue(entity, value);
                }
            }
        }

        /// <summary>
        /// İç içe entity map eder
        /// </summary>
        private void MapNestedEntity<T>(T entity, DataRow dataRow, PropertyInfo property, string classNamePrefix) where T : IEntity
        {
            var nestedPrefix = classNamePrefix + property.Name;
            var method = typeof(DataTableMapper).GetMethod(nameof(MapToEntity))
                                                .MakeGenericMethod(property.PropertyType);

            var nestedEntity = method.Invoke(this, new object[] { dataRow, nestedPrefix });
            property.SetValue(entity, nestedEntity);
        }

        /// <summary>
        /// Field değerini dönüştürür
        /// </summary>
        private object ConvertFieldValue(object data, Type fieldType)
        {
            if (data == null || data == DBNull.Value)
                return GetDefaultValue(fieldType);

            // Byte array özel durumu
            if (fieldType == typeof(byte[]))
            {
                return JsonConvert.DeserializeObject<byte[]>($"\"{data}\"");
            }

            return ConvertValue(data, fieldType);
        }

        /// <summary>
        /// Basit değeri dönüştürür
        /// </summary>
        private object ConvertSimpleValue(object data, Type propertyType)
        {
            if (data == null || data == DBNull.Value)
                return GetDefaultValue(propertyType);

            var stringValue = data.ToString();

            // Boş string ve sayısal tipler için özel durum
            if (string.IsNullOrEmpty(stringValue) && IsNumericType(propertyType))
            {
                return Convert.ChangeType(0, propertyType);
            }

            return ConvertValue(data, propertyType);
        }

        /// <summary>
        /// Değer dönüştürme işlemi
        /// </summary>
        private object ConvertValue(object data, Type targetType)
        {
            var stringValue = data?.ToString();

            // Boolean özel durumları
            if (IsNullableBoolean(targetType))
            {
                return ConvertToNullableBoolean(stringValue);
            }

            if (targetType == typeof(bool))
            {
                return ConvertToBoolean(stringValue);
            }

            // Diğer tipler için genel dönüştürme
            var underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            if (data == null || data == DBNull.Value)
                return null;

            return Convert.ChangeType(data, underlyingType);
        }

        /// <summary>
        /// Nullable boolean dönüştürme
        /// </summary>
        private bool? ConvertToNullableBoolean(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.ToLower() switch
            {
                "true" or "1" => true,
                "false" or "0" => false,
                _ => null
            };
        }

        /// <summary>
        /// Boolean dönüştürme
        /// </summary>
        private bool ConvertToBoolean(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            return value.ToLower() switch
            {
                "true" or "1" => true,
                _ => false
            };
        }

        /// <summary>
        /// Tip kontrolü yardımcı metodları
        /// </summary>
        private static bool IsSimpleType(Type type)
        {
            return type == typeof(string) ||
                   type.IsPrimitive ||
                   type.IsEnum ||
                   Nullable.GetUnderlyingType(type) != null;
        }

        private static bool IsEntityType(Type type)
        {
            return typeof(IEntity).IsAssignableFrom(type);
        }

        private static bool IsNumericType(Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type) ?? type;

            return underlyingType == typeof(int) ||
                   underlyingType == typeof(float) ||
                   underlyingType == typeof(double) ||
                   underlyingType == typeof(decimal) ||
                   underlyingType == typeof(long) ||
                   underlyingType == typeof(short) ||
                   underlyingType == typeof(byte);
        }

        private static bool IsNullableBoolean(Type type)
        {
            return Nullable.GetUnderlyingType(type) == typeof(bool);
        }

        private static object GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
