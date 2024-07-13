using LeetCode.Data.Entities.OwnedEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class TestCaseConfiguration : IEntityTypeConfiguration<TestCase>
{
    public void Configure(EntityTypeBuilder<TestCase> builder)
    {
        builder
            .HasAlternateKey(x => new { x.ProblemId, x.Input });

        builder
            .Property(x => x.Input)
            .HasMaxLength(1024);

        builder
            .Property(x => x.Output)
            .HasMaxLength(1024);

        builder.OwnsOne(
            x => x.CreateInfo,
            OwnedEntitiesConfigurations.ConfigureCreateInfo<TestCase>()
        );
    }
}