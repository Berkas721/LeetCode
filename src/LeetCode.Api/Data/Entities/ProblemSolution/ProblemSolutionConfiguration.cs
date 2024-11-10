using LeetCode.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class ProblemSolutionConfiguration : IEntityTypeConfiguration<ProblemSolution>
{
    public void Configure(EntityTypeBuilder<ProblemSolution> builder)
    {
        builder
            .Property(x => x.Code)
            .HasMaxLength(4096);

        builder
            .HasDiscriminator(x => x.Status)
            .HasValue<ProblemSolution>(ProblemSolutionStatus.Unknown)
            .HasValue<DraftSolution>(ProblemSolutionStatus.Draft)
            .HasValue<AcceptedSolution>(ProblemSolutionStatus.Accepted)
            .HasValue<UnAcceptedSolution>(ProblemSolutionStatus.UnAccepted);
    }
}