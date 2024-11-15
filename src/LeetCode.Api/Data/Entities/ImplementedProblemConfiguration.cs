using LeetCode.Data.OwnedTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class ImplementedProblemConfiguration : IEntityTypeConfiguration<ImplementedProblem>
{
    public void Configure(EntityTypeBuilder<ImplementedProblem> builder)
    {
        builder
            .HasAlternateKey(x => new { x.ProblemId, x.LanguageId });

        builder
            .Property(x => x.ProblemCode)
            .HasMaxLength(4096);

        builder
            .Property(x => x.DefaultSolutionCode)
            .HasMaxLength(4096);

        builder
            .Property(x => x.WorkingSolutionCode)
            .HasMaxLength(1024);

        builder.OwnsOne(
            x => x.CreateInfo, 
            OwnedEntitiesConfigurations.ConfigureActionInfo<ImplementedProblem>()
        );
    }
}