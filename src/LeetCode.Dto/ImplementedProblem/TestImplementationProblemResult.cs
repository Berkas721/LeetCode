using LeetCode.Dto.Enums;
using LeetCode.Dto.TestCase;

namespace LeetCode.Dto.ImplementedProblem;

public sealed record TestImplementationProblemResult
{
    public required Guid ImplementationProblemId { get; init; }

    public required IReadOnlyList<RunTestCaseResult> RunTestCaseResults { get; init; }

    public bool IsPassed => RunTestCaseResults.All(x => x.ResultStatus == SolutionTestResultStatus.Passed);
}