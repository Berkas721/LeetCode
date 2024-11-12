using System.Diagnostics;
using LeetCode.Abstractions;
using LeetCode.Data.Enums;
using LeetCode.Exceptions;
using LeetCode.Utils;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace LeetCode.Services;

public class TestSolution : ITestSolution
{
    private readonly IServiceProvider _provider;
    
    private const string RunSolutionCode = 
        """
        using System.Text.Json;

        var input = JsonSerializer.Deserialize<Problem.InputData>(InputJson);
        var output = Problem.RunUserSolution(input);
        JsonSerializer.Serialize(output);
        """;

    public TestSolution(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task<IReadOnlyList<SolutionTestResult>> TestAsync(
        string problemCode,
        string solutionCode,
        string languageName,
        IReadOnlyList<TestCaseData> testCases)
    {
        List<SolutionTestResult> testResults = [];

        if (!ProgrammingLanguages.All.Contains(languageName))
            throw new ResourceNotFoundException($"Встречен неизвестный системе язык {languageName}");

        var solutionRunnerCreator = _provider.GetKeyedService<ISolutionRunner>(ProgrammingLanguages.CSharpKey);
        var solutionRunner = solutionRunnerCreator.Create(problemCode, solutionCode);

        var timer = new Stopwatch();

        foreach (var testcase in testCases)
        {
            try
            {
                timer.Restart();

                var solutionOutput = await solutionRunner(testcase.InputJson);

                timer.Stop();

                var testResult = solutionOutput != testcase.OutputJson
                    ? new SolutionTestResult
                    {
                        Id = testcase.Id,
                        Date = DateTime.UtcNow,
                        ResultStatus = SolutionTestResultStatus.FailedWithIncorrectAnswer,
                        IncorrectAnswer = solutionOutput
                    }
                    : new SolutionTestResult
                    {
                        Id = testcase.Id,
                        Date = DateTime.UtcNow,
                        ResultStatus = SolutionTestResultStatus.Passed,
                        UsedTime = timer.Elapsed.Milliseconds,
                        UsedMemory = 666
                    };

                testResults.Add(testResult);
            }
            catch (Exception ex)
            {
                testResults.Add(new SolutionTestResult
                {
                    Id = testcase.Id,
                    Date = DateTime.UtcNow,
                    ResultStatus = SolutionTestResultStatus.FailedWithIncorrectAnswer,
                    ErrorMessage = ex.Message
                });
            }
        }

        return testResults;
    }
}

public sealed class SolutionTestResult
{
    public long Id { get; init; }

    public SolutionTestResultStatus ResultStatus { get; init; }

    public DateTime Date { get; set; }

    public long? UsedTime { get; init; }

    public long? UsedMemory { get; init; }

    public string? ErrorMessage { get; init; }

    public string? IncorrectAnswer { get; init; }
}

public sealed record TestCaseData
{
    // Hint: нужен для связки с SolutionTestResultDto
    public long Id { get; init; }

    public string InputJson { get; init; }

    public string OutputJson { get; init; }
}