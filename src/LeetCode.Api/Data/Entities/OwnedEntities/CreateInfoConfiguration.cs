using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities.OwnedEntities;

public static partial class OwnedEntitiesConfigurations
{
    public static Action<OwnedNavigationBuilder<TEntity, CreateInfo>> ConfigureCreateInfo<TEntity>() where TEntity : class
    {
        return builder =>
        {
            builder
                .Property(x => x.Date)
                .HasColumnName("CreatedAt");

            builder
                .Property(x => x.CreatorId)
                .HasColumnName("CreatorId");

            builder
                .HasOne(x => x.Creator)
                .WithMany()
                .HasForeignKey(x => x.CreatorId);
        };
    }
}