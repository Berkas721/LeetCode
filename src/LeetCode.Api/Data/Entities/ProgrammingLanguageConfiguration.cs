using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class ProgrammingLanguageConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
{
    public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
    {
        builder
            .HasIndex(x => new { x.LanguageName, x.VersionName })
            .IsUnique();

        builder
            .Property(x => x.LanguageName)
            .HasMaxLength(64);

        builder
            .Property(x => x.VersionName)
            .HasMaxLength(64);
    }
}