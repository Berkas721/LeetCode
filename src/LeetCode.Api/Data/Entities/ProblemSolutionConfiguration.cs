using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class ProblemSolutionConfiguration : IEntityTypeConfiguration<ProblemSolution>
{
    public void Configure(EntityTypeBuilder<ProblemSolution> builder)
    {
        builder
            .HasAlternateKey(x => new { x.SessionId, x.SubmittedAt });

        builder
            .Property(x => x.Code)
            .HasMaxLength(1024);

        builder
            .Property(x => x.Notes)
            .HasMaxLength(512);
    }
}