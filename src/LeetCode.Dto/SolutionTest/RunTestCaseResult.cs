using LeetCode.Dto.Enums;

namespace LeetCode.Dto.SolutionTest;

public sealed record RunTestCaseResult
{
    public TestCase TestCase { get; init; }

    public SolutionTestResultStatus ResultStatus { get; init; }

    public DateTime Date { get; init; }

    public long? UsedTime { get; init; }

    public long? UsedMemory { get; init; }

    public string? ErrorMessage { get; init; }

    public string? IncorrectAnswer { get; init; }
}