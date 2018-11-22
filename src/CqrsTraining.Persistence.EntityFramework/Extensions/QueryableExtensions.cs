using System;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsTraining.Persistence.EntityFramework.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<CollectionModel<TEntity>> GetPageAsync<TEntity>(
            this IQueryable<TEntity> source,
            string orderBy,
            int offset,
            int limit)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                throw new ArgumentException(nameof(orderBy));
            }

            if (offset < 0)
            {
                throw new ArgumentException(nameof(offset));
            }

            if (limit < 0)
            {
                throw new ArgumentException(nameof(limit));
            }

            var total = source.DeferredCount().FutureValue();
            var query = source.OrderBy(orderBy).Skip(offset).Take(limit);

            var filtered = query is IDbAsyncEnumerable<TEntity> ? await query.Future().ToListAsync() : query.Future().ToList();

            return new CollectionModel<TEntity>
            {
                Total = total.Value,
                Results = filtered,
                Limit = limit,
                Offset = offset
            };
        }
    }
}
