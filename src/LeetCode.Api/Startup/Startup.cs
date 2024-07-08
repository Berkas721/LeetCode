namespace LeetCode.Startup;

public static partial class Startup
{
    public static Task<WebApplicationBuilder> ConfigureServices(this WebApplicationBuilder builder)
    {
        builder
            .AddAuth()
            .AddApplicationDbContext()
            .AddIdentity()
            .AddSwagger()
            .AddControllers()
            .AddMapper()
            .AddMediator();

        return Task.FromResult(builder);
    }

    public static async Task<WebApplication> Configure(this WebApplication app)
    {
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseDevelopmentConfiguration();
        app.MapControllers();

        await app.MigrateDatabaseAsync();

        return app;
    }
}