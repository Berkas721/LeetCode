using LeetCode.Dto.Enums;

namespace LeetCode.Dto.Solution;

public sealed record SolutionOutput
{
    public required long Id { get; set; }

    public required Guid ImplementedProblemId { get; set; }

    public required string Code { get; set; } = string.Empty;

    public required ActionInfo CreateInfo { get; set; }

    public required ProblemSolutionStatus Status { get; set; }

    public DateTime? UpdatedAt { get; init; }

    public DateTime? SubmittedAt { get; init; }

    public long? TotalUsedTime { get; init; }

    public long? TotalUsedMemory { get; init; }

    public long[]? FailedTestIds { get; init; }
}