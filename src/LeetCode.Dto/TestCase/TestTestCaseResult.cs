using LeetCode.Dto.SolutionTest;

namespace LeetCode.Dto.TestCase;

public sealed record TestTestCaseResult
{
    public required Guid ImplementedProblemId { get; init; }

    public required RunTestCaseResult RunTestCaseResult { get; init; }
}