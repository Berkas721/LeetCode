﻿using System.Reflection;
using LeetCode.Data.Entities;
using LeetCode.Data.Enums;
using LeetCode.Exceptions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Data.Contexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
{
    public DbSet<Problem> Problems { get; set; } = default!;

    public DbSet<ProblemTopic> ProblemTopics { get; set; } = default!;

    public DbSet<ImplementedProblem> ImplementedProblems { get; set; } = default!;

    public DbSet<ProgrammingLanguage> Languages { get; set; } = default!;

    public DbSet<TestCase> TestCases { get; set; } = default!;

    public DbSet<ProblemSolution> ProblemSolutions { get; set; } = default!;

    public DbSet<SolutionTest> SolutionTests { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("leetcode");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public async Task EnsureProblemInStatusAsync(long problemId, ProblemStatus status)
    {
        ProblemStatus? currentStatus = await Problems
            .Where(x => x.Id == problemId)
            .Select(x => x.Status)
            .FirstOrDefaultAsync();

        ResourceNotFoundException.ThrowIfNull(currentStatus, $"не найдена задача с id {problemId}");

        if (currentStatus != status)
            throw new ForbiddenException($"Задача с id {problemId} не находится в необходимом статусе {status}");
    }
}