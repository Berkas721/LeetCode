namespace LeetCode.Dto.TestCase;

public sealed record CreateTestCaseInput
{
    public required string Input { get; init; }

    public required string Output { get; init; }

    public required long ProblemId { get; init; }
}