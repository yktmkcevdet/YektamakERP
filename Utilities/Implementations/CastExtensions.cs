using Models;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public static class CastExtensions
    {
        public static IEnumerable<TDto> CastToDTO<TDto>(
            this IEnumerable<object> source, IConvertHelper convertHelper)
            where TDto : IEntity, new()
        {
            foreach (var item in source)
                yield return convertHelper.ToDTO<TDto>(item);
        }

        public static IEnumerable<TEntity> CastToEntity<TEntity>(
            this IEnumerable<object> source, IConvertHelper convertHelper)
            where TEntity : class, IEntity, new()
        {
            foreach (var item in source)
                yield return convertHelper.ToEntity<TEntity>(item);
        }
    }
}
