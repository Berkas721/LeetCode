namespace LeetCode.Dto.TestCase;

public sealed record TestCaseOutput
{
    public required long Id { get; init; }

    public required string Input { get; init; }

    public required string Output { get; init; }

    public required ActionInfo CreateInfo { get; init; }

    public required long ProblemId { get; init; }
}