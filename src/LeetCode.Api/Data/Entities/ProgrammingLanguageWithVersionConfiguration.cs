using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class ProgrammingLanguageWithVersionConfiguration : IEntityTypeConfiguration<ProgrammingLanguageWithVersion>
{
    public void Configure(EntityTypeBuilder<ProgrammingLanguageWithVersion> builder)
    {
        builder
            .HasAlternateKey(x => new { x.Name, x.Version });

        builder
            .HasOne(x => x.Language)
            .WithMany()
            .HasForeignKey(x => x.Name)
            .HasPrincipalKey(x => x.Name);

        builder
            .Property(x => x.Name)
            .HasMaxLength(64);

        builder
            .Property(x => x.Version)
            .HasMaxLength(64);
    }
}