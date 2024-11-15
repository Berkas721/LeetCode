using LeetCode.Abstractions;
using LeetCode.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Extensions;

public static class QueryExtensions
{
    public static async Task<TSource> FindByIdAsync<TSource, TKey>(
        this IQueryable<TSource> query, 
        TKey id,
        CancellationToken cancellationToken = default) 
        where TSource : IHasId<TKey> 
        where TKey : IEquatable<TKey>
    {
        var entity = await query
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is not null)
            return entity;

        throw new ResourceNotFoundException($"Не найдена сущность {typeof(TSource).Name} с id {id}");
    }
}