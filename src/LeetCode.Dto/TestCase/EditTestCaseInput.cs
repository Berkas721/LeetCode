namespace LeetCode.Dto.TestCase;

public sealed record EditTestCaseInput
{
    public string? NewInput { get; init; }

    public string? NewOutput { get; init; }
}