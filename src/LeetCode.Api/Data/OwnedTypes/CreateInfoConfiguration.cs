﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.OwnedTypes;

public static partial class OwnedEntitiesConfigurations
{
    public static Action<OwnedNavigationBuilder<TEntity, CreateInfo>> ConfigureCreateInfo<TEntity>() where TEntity : class
    {
        return builder =>
        {
            builder
                .HasOne(x => x.Creator)
                .WithMany()
                .HasForeignKey(x => x.CreatorId);
        };
    }
}