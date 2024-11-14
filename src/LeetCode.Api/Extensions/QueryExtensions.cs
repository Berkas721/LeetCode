using LeetCode.Abstractions;
using LeetCode.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Extensions;

public static class QueryExtensions
{
    public static async Task<TSource> FirstAsync<TSource, TKey>(
        this IQueryable<TSource> query, 
        TKey entityId,
        CancellationToken cancellationToken = default) 
        where TSource : IHasId<TKey> 
        where TKey : IEquatable<TKey>
    {
        var entity = await query
            .Where(x => x.Id.Equals(entityId))
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is not null)
            return entity;

        throw new ResourceNotFoundException($"{typeof(TSource).Name} с id {entityId} не найдено");
    }
}