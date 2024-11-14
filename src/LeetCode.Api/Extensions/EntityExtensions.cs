using LeetCode.Abstractions;
using LeetCode.Exceptions;

namespace LeetCode.Extensions;

public static class EntityExtensions
{
    public static void EnsureAuthor<TSource>(this TSource data, Guid userId) 
        where TSource : IHasCreateInfo
    {
        if (data.CreateInfo.AgentId == userId)
            return;

        // хз как обойти это, EnsureAuthor<TSource, TKey> заставляет явно указывать TKey  
        var errorMessage = data switch
        {
            IHasId<long> dataWithLongId =>
                $"Пользователь с id {userId} не является владельцем сущности {data.GetType()} с id {dataWithLongId.Id}",
            IHasId<Guid> dataWithGuidId =>
                $"Пользователь с id {userId} не является владельцем сущности {data.GetType()} с id {dataWithGuidId.Id}",
            _ =>
                $"Пользователь с id {userId} не является владельцем сущности {data.GetType()}"
        };

        throw new ForbiddenException(errorMessage);
    }
}