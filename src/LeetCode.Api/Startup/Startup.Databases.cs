using LeetCode.Data.Contexts;
using Microsoft.EntityFrameworkCore;

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
                options.UseNpgsql(connectionString));

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