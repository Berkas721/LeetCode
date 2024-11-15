using LeetCode.Data.OwnedTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
{
    [Obsolete("Obsolete")]
    public void Configure(EntityTypeBuilder<Problem> builder)
    {
        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder
            .Property(x => x.Name)
            .HasMaxLength(128);

        builder
            .Property(x => x.Description)
            .HasMaxLength(1024);

        builder.OwnsOne(
            x => x.CreateInfo, 
            OwnedEntitiesConfigurations.ConfigureActionInfo<Problem>()
        );

        builder.OwnsOne(
            x => x.UpdateInfo, 
            OwnedEntitiesConfigurations.ConfigureActionInfo<Problem>()
        );

        builder.OwnsOne(
            x => x.OpenInfo, 
            OwnedEntitiesConfigurations.ConfigureActionInfo<Problem>()
        );
    }
}