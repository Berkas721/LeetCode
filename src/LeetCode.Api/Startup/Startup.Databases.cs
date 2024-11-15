using LeetCode.Data.Contexts;
using LeetCode.Data.Entities;
using LeetCode.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql;

namespace LeetCode.Startup;

public partial class Startup
{
    private static WebApplicationBuilder AddApplicationDbContext(this WebApplicationBuilder builder)
    {
        var connectionString = builder
            .Configuration
            .GetConnectionString("ApplicationDbContext")!;

        builder
            .Services
            .AddDbContextPool<ApplicationDbContext>(options =>
            {
                var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
                var searchPaths = connectionStringBuilder.SearchPath?.Split(',');

                options.UseNpgsql(connectionString, o =>
                {
                    if (searchPaths is { Length: > 0 })
                    {
                        var mainSchema = searchPaths[0];
                        o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, mainSchema);
                    }
                });
            });

        return builder;
    }
    
    private static async Task MigrateDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        await using var dbContext = scope
            .ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        if (!dbContext.Database.IsRelational()) return;

        await dbContext.Database.MigrateAsync();
    }
    
    private static async Task SeedDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        await using var dbContext = scope
            .ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        if (!dbContext.Users.Any())
        {
            var userManager = scope
                .ServiceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();

            await userManager
                .CreateAsync(SeedingData.User, "string");

            var user = await dbContext.Users.FirstAsync();
            user.Id = SeedingData.UserId;
        }

        if (!dbContext.Languages.Any())
            await dbContext.Languages.AddAsync(SeedingData.Language);

        if (!dbContext.Problems.Any())
            await dbContext.Problems.AddAsync(SeedingData.Problem);

        if (!dbContext.ImplementedProblems.Any())
            await dbContext.ImplementedProblems.AddAsync(SeedingData.ImplementedProblem);

        if (!dbContext.TestCases.Any())
            await dbContext.TestCases.AddRangeAsync(SeedingData.TestCases);

        await dbContext.SaveChangesAsync();
    }
}