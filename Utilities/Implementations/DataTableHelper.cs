using Models;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class DataTableHelper: IDataTableHelper
    {
        /// <summary>
        /// Datatable satırlarını model listesine çevirir.
        /// Masaüstü uygulması için DataGridView nesnesini model listesine çevirmek için kullanılır.
        /// Blazor uygulamasında da kullanılabilmesi için Datatable'a çevirme işlemi yapılmıştır.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<T> DataTableRowsToModelList<T>(List<DataRow> dt) where T : IEntity, new()
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
        /// Datatable satırını model nesnesine dönüştürür
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <param name="upClassName"></param>
        /// <returns></returns>
        public T DataRowToModel<T>(DataRow dataRow, string upClassName = "") where T : IEntity, new()
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
                        object value = JsonConvert.DeserializeObject(data, type);
                        propertyInfo.SetValue(entity, value);
                    }
                }


                else if (typeof(IEntity).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    MethodInfo method = typeof(DataTableHelper).GetMethod(nameof(DataRowToModel)).MakeGenericMethod(type);
                    
                    var converterInstance = new DataTableHelper();
                    object value = method.Invoke(converterInstance, new object[] { dataRow, upClassName + propertyInfo.Name + "_" });
                    propertyInfo.SetValue(entity, value);
                }
            }
            return entity;
        }
        
    }
}
