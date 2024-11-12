using LeetCode.Data.Contexts;
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
}