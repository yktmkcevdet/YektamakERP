using Models;
using System.Collections.Generic;
using Utilities.Interfaces;

namespace YektamakDesktop.Common
{
    public static class CastExtensions
    {
        public static IEnumerable<TDto> CastToDTO<TDto>(this IEnumerable<object> source) where TDto : IEntity, new()
        {
            foreach (var item in source)
            {
                yield return ConvertHelper.ToDTO<TDto>(item);
            }
        }
        public static IEnumerable<TEntity> CastToEntity<TEntity>(this IEnumerable<object> source) where TEntity : class, IEntity, new()
        {
            foreach (var item in source)
            {
                yield return ConvertHelper.ToEntity<TEntity>(item);
            }
        }
    }
}
