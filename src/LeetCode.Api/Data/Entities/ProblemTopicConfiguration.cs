﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class ProblemTopicConfiguration : IEntityTypeConfiguration<ProblemTopic>
{
    public void Configure(EntityTypeBuilder<ProblemTopic> builder)
    {
        builder
            .HasAlternateKey(x => x.Name);

        builder
            .Property(x => x.Name)
            .HasMaxLength(64);

        builder
            .Property(x => x.Description)
            .HasMaxLength(256);
    }
}