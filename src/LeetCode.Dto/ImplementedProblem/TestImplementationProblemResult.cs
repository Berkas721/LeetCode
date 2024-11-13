using LeetCode.Dto.SolutionTest;

namespace LeetCode.Dto.ImplementedProblem;

public sealed record TestImplementationProblemResult
{
    public required Guid ImplementationProblemId { get; init; }

    public required IReadOnlyList<RunTestCaseResult> RunTestCaseResults { get; init; }
}