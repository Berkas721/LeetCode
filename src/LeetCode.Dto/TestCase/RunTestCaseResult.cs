using LeetCode.Dto.Enums;

namespace LeetCode.Dto.TestCase;

public sealed record RunTestCaseResult
{
    public TestCaseData TestCaseData { get; init; }

    public SolutionTestResultStatus ResultStatus { get; init; }

    public DateTime Date { get; init; }

    public long? UsedTime { get; init; }

    public long? UsedMemory { get; init; }

    public string? ErrorMessage { get; init; }

    public string? IncorrectAnswer { get; init; }
}