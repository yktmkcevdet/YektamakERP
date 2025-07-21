using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToEntityTest();
        }
        static IEnumerable<string> argsEnumerable(string[] ar)
        {
            foreach (var arg in ar)
            {
                yield return arg;
            }
        }
        public static T ToEntity<T>(object dto, object entity = null, string classNamePrefix = "") where T : new()
        {
            IEnumerable<PropertyInfo> properties;
            if (entity == null)
            {
                entity = new T();
                properties = entity.GetType().GetProperties();
            }
            else
            {
                PropertyInfo nestType = entity.GetType().GetProperty(classNamePrefix.Split('.').Last());
                var gg = nestType.GetValue(entity, null);
                properties = gg.GetType().GetProperties();
            }
            string[] propertyNames;
            Type currentType = entity.GetType();
            foreach (var property in properties)
            {
                if (!property.CanWrite)
                    continue;
                //var splitChar = string.IsNullOrWhiteSpace(classNamePrefix) ? "" : ".";
                //var parentName = classNamePrefix + splitChar + property.Name;
                var parentName = classNamePrefix == "" ? property.Name : classNamePrefix + "." + property.Name;

                if (property.PropertyType.IsClass)
                {

                    var method = typeof(Program).GetMethod(nameof(ToEntity), BindingFlags.Static | BindingFlags.Public);
                    var genericMethod = method.MakeGenericMethod(entity.GetType());

                    var convertedValue = genericMethod.Invoke(null, new object[] { dto, entity, parentName });
                }
                else
                {
                    PropertyInfo nestedPropertyInfo = null;
                    var nestedProperty = entity;
                    foreach (var nestClassName in parentName.Split('.'))
                    {
                        var b = nestedProperty;

                        if (b is PropertyInfo aa)
                        {
                            nestedProperty = aa.GetType();
                            var tty = aa.GetValue(nestClassName, null);
                            Console.WriteLine(nestedProperty?.GetType().FullName);
                        }
                        var a = nestedProperty.GetType().GetProperty(nestClassName);
                        if (a.PropertyType.IsClass)
                        {
                            nestedProperty = nestedProperty.GetType().GetProperty(nestClassName);
                        }
                        else
                        {
                            nestedPropertyInfo = nestedProperty.GetType().GetProperty(nestClassName);
                        }
                    }
                    PropertyInfo propertyInfo = dto.GetType().GetProperty(string.Join(".", parentName));
                    if (propertyInfo != null)
                    {
                        var value = propertyInfo.GetValue(dto, null);
                        nestedPropertyInfo.SetValue(entity, value, null);
                    }
                }
            }
            return (T)entity;
        }
        public static void ToEntityTest()
        {
            var dto = new ProjeStokKartDTO { projeId = 1, stokKartad = "Yılmaz" };
            var result = ToEntity<ProjeStokKart>(dto);
            Console.WriteLine($"Name: {result.proje.Id}, Surname: {result.stokKart.ad}");
        }
    }
}
