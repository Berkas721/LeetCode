﻿using LeetCode.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeetCode.Data.Entities;

public class SolutionTestConfiguration : IEntityTypeConfiguration<SolutionTest>
{
    public void Configure(EntityTypeBuilder<SolutionTest> builder)
    {
        builder
            .HasAlternateKey(x => new { x.SolutionId, x.TestCaseId });

        builder
            .HasDiscriminator(x => x.ResultStatus)
            .HasValue<SolutionTest>(SolutionTestResultStatus.Unknown)
            .HasValue<PassedTest>(SolutionTestResultStatus.Passed)
            .HasValue<FailedWithErrorTest>(SolutionTestResultStatus.FailedWithError)
            .HasValue<FailedWithIncorrectAnswerTest>(SolutionTestResultStatus.FailedWithIncorrectAnswer);
    }
}