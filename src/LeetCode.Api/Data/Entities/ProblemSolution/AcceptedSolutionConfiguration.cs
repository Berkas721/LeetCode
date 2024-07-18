using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class AcceptedSolutionConfiguration : IEntityTypeConfiguration<AcceptedSolution>
{
    public void Configure(EntityTypeBuilder<AcceptedSolution> builder)
    {
        builder
            .Property(x => x.SubmittedAt)
            .HasColumnName(nameof(ProblemSolution.SubmittedAt));

        builder
            .Property(x => x.SubmittedAt)
            .ValueGeneratedNever();
    }
}