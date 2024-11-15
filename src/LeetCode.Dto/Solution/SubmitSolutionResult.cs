using LeetCode.Dto.TestCase;

namespace LeetCode.Dto.Solution;

public sealed record SubmitSolutionResult
{
    public required long SolutionId { get; init; }
    public required bool IsPassed { get; init; }
    public required long? TotalUsedTime { get; init; }
    public required long? TotalUsedMemory { get; init; }
    public required RunTestCaseResult? TestCaseResultWithError { get; init; }
    public required RunTestCaseResult? TestCaseResultWithWrongAnswer { get; init; }
}