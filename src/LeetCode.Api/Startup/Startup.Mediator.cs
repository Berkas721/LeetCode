using System.Reflection;

namespace LeetCode.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(config => 
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return builder;
    }
}