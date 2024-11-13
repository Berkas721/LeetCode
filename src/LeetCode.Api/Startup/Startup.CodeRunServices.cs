using LeetCode.Abstractions;
using LeetCode.Services;

namespace LeetCode.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddSolutionRunnerFactory(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddSingleton<ISolutionRunnerFactory, SolutionRunnerFactory>();

        return builder;
    }
}