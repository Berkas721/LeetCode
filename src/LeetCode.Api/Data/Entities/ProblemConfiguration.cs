using LeetCode.Data.Entities.OwnedEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
{
    public void Configure(EntityTypeBuilder<Problem> builder)
    {
        builder
            .HasAlternateKey(x => x.Name);

        builder
            .Property(x => x.Name)
            .HasMaxLength(128);

        builder
            .Property(x => x.Description)
            .HasMaxLength(1024);

        builder.OwnsOne(
            x => x.CreateInfo, 
            OwnedEntitiesConfigurations.ConfigureCreateInfo<Problem>()
        );

        builder.OwnsOne(
            x => x.DeleteInfo, 
            OwnedEntitiesConfigurations.ConfigureDeleteInfo<Problem>()
        );

    }
}