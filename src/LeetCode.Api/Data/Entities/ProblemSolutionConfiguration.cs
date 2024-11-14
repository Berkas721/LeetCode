using LeetCode.Data.OwnedTypes;
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

        builder.OwnsOne(
            x => x.CreateInfo, 
            OwnedEntitiesConfigurations.ConfigureActionInfo<ProblemSolution>()
        );
    }
}