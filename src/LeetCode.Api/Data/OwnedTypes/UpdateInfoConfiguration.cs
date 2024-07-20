using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.OwnedTypes;

public static partial class OwnedEntitiesConfigurations
{
    public static Action<OwnedNavigationBuilder<TEntity, UpdateInfo>> ConfigureUpdateInfo<TEntity>() where TEntity : class
    {
        return builder =>
        {
            builder
                .HasOne(x => x.Updater)
                .WithMany()
                .HasForeignKey(x => x.UpdaterId);
        };
    }
}