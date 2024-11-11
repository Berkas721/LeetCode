using LeetCode.Abstractions;
using LeetCode.Services;
using LeetCode.Utils;

namespace LeetCode.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddSolutionRunners(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddKeyedSingleton<ISolutionRunner, CSharpSolutionRunner>(ProgrammingLanguages.CSharpKey);

        return builder;
    }

    private static WebApplicationBuilder AddSolutionTest(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddSingleton<ITestSolution, TestSolution>();

        return builder;
    }
}