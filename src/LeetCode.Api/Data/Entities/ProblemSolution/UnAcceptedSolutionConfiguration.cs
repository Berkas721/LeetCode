using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class UnAcceptedSolutionConfiguration : IEntityTypeConfiguration<UnAcceptedSolution>
{
    public void Configure(EntityTypeBuilder<UnAcceptedSolution> builder)
    {
        builder
            .Property(x => x.SubmittedAt)
            .HasColumnName(nameof(ProblemSolution.SubmittedAt));

        builder
            .Property(x => x.SubmittedAt)
            .ValueGeneratedNever();
    }
}