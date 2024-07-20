using System.Reflection;
using LeetCode.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Data.Contexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
{
    public DbSet<Problem> Problems { get; set; } = default!;

    public DbSet<ProblemTopic> ProblemTopics { get; set; } = default!;

    public DbSet<SolutionRunningDetails> SolutionsRunningDetails { get; set; } = default!;

    public DbSet<ProgrammingLanguage> Languages { get; set; } = default!;

    public DbSet<ProgrammingLanguageWithVersion> LanguagesWithVersion { get; set; } = default!;

    public DbSet<TestCase> TestCases { get; set; } = default!;

    public DbSet<ProblemResolveSession> ProblemResolveSessions { get; set; } = default!;

    public DbSet<ProblemSolution> ProblemSolutions { get; set; } = default!;

    public DbSet<AcceptedSolution> AcceptedProblemSolutions { get; set; } = default!;

    public DbSet<UnAcceptedSolution> UnAcceptedProblemSolutions { get; set; } = default!;

    public DbSet<DraftSolution> DraftProblemSolutions { get; set; } = default!;

    public DbSet<SolutionTest> SolutionTests { get; set; } = default!;

    public DbSet<PassedTest> PassedSolutionTests { get; set; } = default!;

    public DbSet<FailedWithErrorTest> FailedWithErrorSolutionTests { get; set; } = default!;

    public DbSet<FailedWithIncorrectAnswerTest> FailedWithIncorrectAnswersSolutionTests { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}