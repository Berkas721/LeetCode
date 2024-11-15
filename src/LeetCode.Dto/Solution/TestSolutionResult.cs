using LeetCode.Dto.Enums;
using LeetCode.Dto.TestCase;

namespace LeetCode.Dto.Solution;

public sealed record TestSolutionResult
{
    public required long SolutionId { get; init; }

    public required IReadOnlyList<RunTestCaseResult> RunTestCaseResults { get; init; }

    public bool IsPassed => RunTestCaseResults.All(x => x.ResultStatus == SolutionTestResultStatus.Passed);
    public bool IsErrorAppear => RunTestCaseResults.Any(x => x.ResultStatus == SolutionTestResultStatus.FailedWithError);
    public bool IsWrongAnswerAppear => RunTestCaseResults.Any(x => x.ResultStatus == SolutionTestResultStatus.FailedWithIncorrectAnswer);
}