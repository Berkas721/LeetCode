using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class FailedWithErrorTestConfiguration : IEntityTypeConfiguration<FailedWithErrorTest>
{
    public void Configure(EntityTypeBuilder<FailedWithErrorTest> builder)
    {
        builder
            .Property(x => x.ErrorMessage)
            .HasMaxLength(1024);
    }
}