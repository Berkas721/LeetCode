using LeetCode.Data.Entities.OwnedEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class SolutionRunningDetailsConfiguration : IEntityTypeConfiguration<SolutionRunningDetails>
{
    public void Configure(EntityTypeBuilder<SolutionRunningDetails> builder)
    {
        builder
            .HasAlternateKey(x => new { x.ProblemId, x.LanguageId });

        builder
            .Property(x => x.DefaultCode)
            .HasMaxLength(1024);

        builder
            .Property(x => x.WorkingSolution)
            .HasMaxLength(1024);

        builder.OwnsOne(
            x => x.CreateInfo, 
            OwnedEntitiesConfigurations.ConfigureCreateInfo<SolutionRunningDetails>()
        );

        builder.OwnsOne(
            x => x.DeleteInfo, 
            OwnedEntitiesConfigurations.ConfigureDeleteInfo<SolutionRunningDetails>()
        );
    }
}