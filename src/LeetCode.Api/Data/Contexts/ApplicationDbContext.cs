﻿using System.Reflection;
using LeetCode.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Data.Contexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
{
    public DbSet<Problem> Problems { get; set; } = default!;

    public DbSet<ProblemTopic> ProblemTopics { get; set; } = default!;

    public DbSet<ProblemRealizeDetails> ProblemRealizeDetails { get; set; } = default!;

    public DbSet<ProgrammingLanguage> Languages { get; set; } = default!;

    public DbSet<TestCase> TestCases { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}