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
}
