using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class ProblemResolveSessionConfiguration : IEntityTypeConfiguration<ProblemResolveSession>
{
    public void Configure(EntityTypeBuilder<ProblemResolveSession> builder)
    {
        builder
            .HasAlternateKey(x => new { x.UserId, x.ProblemId });
    }
}