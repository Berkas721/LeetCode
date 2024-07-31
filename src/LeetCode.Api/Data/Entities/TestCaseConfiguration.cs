using LeetCode.Data.OwnedTypes;
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
            .HasMaxLength(2048);

        builder
            .Property(x => x.Output)
            .HasMaxLength(2048);

        builder.OwnsOne(
            x => x.CreateInfo,
            OwnedEntitiesConfigurations.ConfigureActionInfo<TestCase>()
        );
    }
}