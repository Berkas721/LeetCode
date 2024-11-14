using LeetCode.Abstractions;
using LeetCode.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Extensions;

public static class EntityExtensions
{
    public static void EnsureAuthor<TSource>(this TSource data, Guid userId) 
        where TSource : IHasCreateInfo
    {
        if (data.CreateInfo.AgentId == userId)
            return;

        throw new ForbiddenException(
            $"Пользователь с id {userId} не является владельцем сущности {data.GetType()}");
    }

    public static void EnsureAuthor<TSource, TKey>(this TSource data, Guid userId) 
        where TSource : IHasCreateInfo, IHasId<TKey>
    {
        if (data.CreateInfo.AgentId == userId)
            return;

        throw new ForbiddenException(
            $"Пользователь с id {userId} не является владельцем сущности {data.GetType()} с id {data.Id}");
    }
}