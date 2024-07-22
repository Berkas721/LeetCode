using Microsoft.OpenApi.Models;

namespace LeetCode.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "LeetCode.Api", Version = "v1" });

            options.EnableAnnotations();
        });

        return builder;
    }

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

        return app;
    }
}