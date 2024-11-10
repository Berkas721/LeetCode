using LeetCode.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class SolutionTestConfiguration : IEntityTypeConfiguration<SolutionTest>
{
    public void Configure(EntityTypeBuilder<SolutionTest> builder)
    {
        builder
            .HasAlternateKey(x => new { x.SolutionId, x.TestCaseId });

        builder
            .Property(x => x.IncorrectAnswer)
            .HasMaxLength(1024);

        builder
            .Property(x => x.ErrorMessage)
            .HasMaxLength(1024);
    }
}