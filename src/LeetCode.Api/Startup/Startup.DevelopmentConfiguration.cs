namespace LeetCode.Startup;

public static partial class Startup
{
    private static WebApplication UseDevelopmentConfiguration(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
            return app;

        app.UseSwagger(options =>
        {
            options.RouteTemplate = "api/{documentName}/swagger.json";
        });

        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = "swagger";
            options.SwaggerEndpoint("/api/v1/swagger.json", "LeetCode.Api v1");
        });

        var spaDevelopmentServerUrl = app.Configuration["SpaDevelopmentServerUrl"];

        if (string.IsNullOrEmpty(spaDevelopmentServerUrl))
            return app;

        app.UseSpa(config =>
        {
            config.UseProxyToSpaDevelopmentServer(spaDevelopmentServerUrl);
        });

        return app;
    }
}
