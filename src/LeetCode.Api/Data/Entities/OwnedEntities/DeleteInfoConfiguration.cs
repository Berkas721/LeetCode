using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities.OwnedEntities;

public static partial class OwnedEntitiesConfigurations
{
    public static Action<OwnedNavigationBuilder<TEntity, DeleteInfo>> ConfigureDeleteInfo<TEntity>() where TEntity : class
    {
        return builder =>
        {
            builder
                .Property(x => x.Date)
                .HasColumnName("DeletedAt");

            builder
                .Property(x => x.DeleterId)
                .HasColumnName("DeleterId");

            builder
                .HasOne(x => x.Deleter)
                .WithMany()
                .HasForeignKey(x => x.DeleterId);

            builder
                .ToTable(t =>
                    t.HasCheckConstraint(
                        "DeleteInfoConflictCheck",
                        "(\"DeletedAt\" IS NULL AND \"DeleterId\" IS NULL) OR (\"DeletedAt\" IS NOT NULL AND \"DeleterId\" IS NOT NULL)"));
            
        };
    }
}