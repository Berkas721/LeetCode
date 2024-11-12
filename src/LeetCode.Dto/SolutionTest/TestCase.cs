namespace LeetCode.Dto.SolutionTest;

public sealed record TestCase
{
    public long? Id { get; init; }

    public required string InputJson { get; init; }

    public required string OutputJson { get; init; }
}