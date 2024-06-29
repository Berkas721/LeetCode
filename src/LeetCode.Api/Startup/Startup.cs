namespace LeetCode.Startup;

public static partial class Startup
{
    public static Task<WebApplicationBuilder> ConfigureServices(this WebApplicationBuilder builder)
    {
        builder
            .AddSwagger()
            .AddControllers();

        return Task.FromResult(builder);
    }

    public static async Task<WebApplication> Configure(this WebApplication app)
    {
        app
            .UseDevelopmentConfiguration()
            .UseHttpsRedirection();

        return app;
    }
}