using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class ProgrammingLanguageConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
{
    public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
    {
        builder
            .HasAlternateKey(x => new { x.Name, x.Version });

        builder
            .Property(x => x.Version)
            .HasMaxLength(32);

        builder
            .Property(x => x.Name)
            .HasMaxLength(32);
    }
}