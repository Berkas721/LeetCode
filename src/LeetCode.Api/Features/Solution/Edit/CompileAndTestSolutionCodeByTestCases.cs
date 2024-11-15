using System.Diagnostics;
using LeetCode.Abstractions;
using LeetCode.Dto.Enums;
using LeetCode.Dto.TestCase;
using MediatR;

namespace LeetCode.Features.Solution.Edit;


public sealed record CompileAndTestSolutionCodeByTestCasesRequest 
    : IRequest<IReadOnlyList<RunTestCaseResult>>
{
    public required string ProblemCode { get; init; }
    public required string SolutionCode { get; init; }
    public required long LanguageId { get; init; }
    public required IReadOnlyList<Dto.TestCase.TestCaseData> TestCases { get; init; }
} 

public class CompileAndTestSolutionCodeByTestCases
    : IRequestHandler<CompileAndTestSolutionCodeByTestCasesRequest, IReadOnlyList<RunTestCaseResult>>
{
    private readonly ISolutionRunnerFactory _solutionRunnerFactor;

    public CompileAndTestSolutionCodeByTestCases(ISolutionRunnerFactory solutionRunnerFactor)
    {
        _solutionRunnerFactor = solutionRunnerFactor;
    }

    public async Task<IReadOnlyList<RunTestCaseResult>> Handle(
        CompileAndTestSolutionCodeByTestCasesRequest request, 
        CancellationToken cancellationToken)
    {
        List<RunTestCaseResult> testResults = [];

        var solutionRunner = _solutionRunnerFactor.CreateRunner(request.ProblemCode, request.SolutionCode, request.LanguageId);

        var timer = new Stopwatch();

        foreach (var testcase in request.TestCases)
        {
            try
            {
                timer.Restart();

                var solutionOutput = await solutionRunner.RunAsync(testcase.Input);

                timer.Stop();

                var testResult = solutionOutput != testcase.Output
                    ? new RunTestCaseResult
                    {
                        TestCaseData = testcase,
                        Date = DateTime.UtcNow,
                        ResultStatus = SolutionTestResultStatus.FailedWithIncorrectAnswer,
                        IncorrectAnswer = solutionOutput
                    }
                    : new RunTestCaseResult
                    {
                        TestCaseData = testcase,
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
                testResults.Add(new RunTestCaseResult
                {
                    TestCaseData = testcase,
                    Date = DateTime.UtcNow,
                    ResultStatus = SolutionTestResultStatus.FailedWithIncorrectAnswer,
                    ErrorMessage = ex.Message
                });
            }
        }

        return testResults;
    }
}