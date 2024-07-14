using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities.SolutionTest;

public class FailedWithIncorrectAnswerTestConfiguration : IEntityTypeConfiguration<FailedWithIncorrectAnswerTest>
{
    public void Configure(EntityTypeBuilder<FailedWithIncorrectAnswerTest> builder)
    {
        builder
            .Property(x => x.IncorrectAnswer)
            .HasMaxLength(1024);
    }
}