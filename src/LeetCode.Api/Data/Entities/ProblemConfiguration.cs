using LeetCode.Data.OwnedTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
{
    [Obsolete("Obsolete")]
    public void Configure(EntityTypeBuilder<Problem> builder)
    {
        builder
            .HasAlternateKey(x => x.Name);

        builder
            .Property(x => x.Name)
            .HasMaxLength(128);

        builder
            .Property(x => x.Description)
            .HasMaxLength(1024);

        builder.OwnsOne(
            x => x.CreateInfo, 
            OwnedEntitiesConfigurations.ConfigureActionInfo<Problem>()
        );

        builder.OwnsOne(
            x => x.DeleteInfo, 
            OwnedEntitiesConfigurations.ConfigureActionInfo<Problem>()
        );

        builder.OwnsOne(
            x => x.UpdateInfo, 
            OwnedEntitiesConfigurations.ConfigureActionInfo<Problem>()
        );

        builder.OwnsOne(
            x => x.OpenInfo, 
            OwnedEntitiesConfigurations.ConfigureActionInfo<Problem>()
        );
        
        
        // TODO: изучить Marten чтоб обойти это безобразие, убрать потом [Obsolete("Obsolete")]
        builder
            .ToTable("Problems")
            .HasCheckConstraint(
                "Status_constraint",
                "(\"Status\" = 3 AND \"DeleteInfo_Date\" IS NOT NULL) OR " +
                "(\"Status\" = 2 AND \"OpenInfo_Date\" IS NOT NULL) OR " +
                "(\"Status\" = 1 AND \"DeleteInfo_Date\" IS NULL AND \"OpenInfo_Date\" IS NULL) OR + " +
                "\"Status\" = 0"
            );
    }
}