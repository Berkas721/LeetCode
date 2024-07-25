using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class ProgrammingLanguageVersionConfiguration : IEntityTypeConfiguration<ProgrammingLanguageVersion>
{
    public void Configure(EntityTypeBuilder<ProgrammingLanguageVersion> builder)
    {
        builder
            .HasAlternateKey(x => new { x.Name, x.LanguageName });

        builder
            .HasOne<ProgrammingLanguage>(x => x.Language)
            .WithMany(x => x.Versions)
            .HasForeignKey(x => x.LanguageName)
            .HasPrincipalKey(x => x.Name);

        builder
            .Property(x => x.Name)
            .HasMaxLength(64);

        builder
            .Property(x => x.LanguageName)
            .HasMaxLength(64);
    }
}