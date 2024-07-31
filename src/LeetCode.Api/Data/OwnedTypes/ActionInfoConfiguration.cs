using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.OwnedTypes;

public static partial class OwnedEntitiesConfigurations
{
    public static Action<OwnedNavigationBuilder<TEntity, ActionInfo>> ConfigureActionInfo<TEntity>() where TEntity : class
    {
        return builder =>
        {
            builder
                .HasOne(x => x.Agent)
                .WithMany()
                .HasForeignKey(x => x.AgentId);
        };
    }
}