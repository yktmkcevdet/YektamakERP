using Models;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace YektamakDesktop.Common
{
    public class ConvertHelper
    {
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
                    MethodInfo methodInfo = typeof(ConvertHelper).GetMethod(nameof(ToDTO), BindingFlags.Static | BindingFlags.Public, null,
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
                    if (propertyInfo != null && propertyInfo.SetMethod!=null) propertyInfo.SetValue(dto, value);
                }
            }
            return (T)dto;
        }
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();
        private static readonly ConcurrentDictionary<string, PropertyInfo> PropertyMapCache = new();

        // Circular reference kontrolü için
        private static readonly HashSet<object> ProcessedObjects = new();


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

