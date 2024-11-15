namespace LeetCode.Dto.TestCase;

public sealed record TestCaseData
{
    public long? Id { get; init; }

    public required string Input { get; init; }

    public required string Output { get; init; }
}