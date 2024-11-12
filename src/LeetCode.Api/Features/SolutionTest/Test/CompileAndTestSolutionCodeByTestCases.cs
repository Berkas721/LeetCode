using System.Diagnostics;
using LeetCode.Abstractions;
using LeetCode.Dto.SolutionTest;
using LeetCode.Exceptions;
using LeetCode.Utils;
using MediatR;

namespace LeetCode.Features.SolutionTest.Test;


public sealed record CompileAndTestSolutionCodeByTestCasesRequest 
    : IRequest<IReadOnlyList<SolutionTestResult>>
{
    public required string ProblemCode { get; init; }
    public required string SolutionCode { get; init; }
    public required string LanguageCode { get; init; }
    public required IReadOnlyList<Dto.SolutionTest.TestCase> TestCases { get; init; }
} 

public class CompileAndTestSolutionCodeByTestCases
    : IRequestHandler<CompileAndTestSolutionCodeByTestCasesRequest, IReadOnlyList<SolutionTestResult>>
{
    private readonly IServiceProvider _provider;

    public CompileAndTestSolutionCodeByTestCases(IServiceProvider serviceProvider)
    {
        _provider = serviceProvider;
    }

    public async Task<IReadOnlyList<SolutionTestResult>> Handle(
        CompileAndTestSolutionCodeByTestCasesRequest request, 
        CancellationToken cancellationToken)
    {
        List<SolutionTestResult> testResults = [];

        if (!ProgrammingLanguages.All.Contains(request.LanguageCode))
            throw new ResourceNotFoundException($"Встречен неизвестный системе язык {request.LanguageCode}");

        var solutionRunnerCreator = _provider.GetKeyedService<ISolutionRunner>(ProgrammingLanguages.CSharpKey);
        var solutionRunner = solutionRunnerCreator.Create(request.ProblemCode, request.SolutionCode);

        var timer = new Stopwatch();

        foreach (var testcase in request.TestCases)
        {
            try
            {
                timer.Restart();

                var solutionOutput = await solutionRunner(testcase.InputJson);

                timer.Stop();

                var testResult = solutionOutput != testcase.OutputJson
                    ? new SolutionTestResult
                    {
                        TestCase = testcase,
                        Date = DateTime.UtcNow,
                        ResultStatus = SolutionTestResultStatus.FailedWithIncorrectAnswer,
                        IncorrectAnswer = solutionOutput
                    }
                    : new SolutionTestResult
                    {
                        TestCase = testcase,
                        Date = DateTime.UtcNow,
                        ResultStatus = SolutionTestResultStatus.Passed,
                        UsedTime = timer.Elapsed.Milliseconds,
                        // TODO: сделать рассчет памяти
                        UsedMemory = 666
                    };

                testResults.Add(testResult);
            }
            catch (Exception ex)
            {
                testResults.Add(new SolutionTestResult
                {
                    TestCase = testcase,
                    Date = DateTime.UtcNow,
                    ResultStatus = SolutionTestResultStatus.FailedWithIncorrectAnswer,
                    ErrorMessage = ex.Message
                });
            }
        }

        return testResults;
    }
}