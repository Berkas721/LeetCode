using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.OwnedTypes;

public static partial class OwnedEntitiesConfigurations
{
    public static Action<OwnedNavigationBuilder<TEntity, DeleteInfo>> ConfigureDeleteInfo<TEntity>() where TEntity : class
    {
        return builder =>
        {
            builder
                .HasOne(x => x.Deleter)
                .WithMany()
                .HasForeignKey(x => x.DeleterId);
        };
    }
}