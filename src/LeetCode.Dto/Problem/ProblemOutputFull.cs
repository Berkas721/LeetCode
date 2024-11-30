using LeetCode.Dto.Enums;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Dto.TestCase;
using Swashbuckle.AspNetCore.Annotations;

namespace LeetCode.Dto.Problem;

public sealed record ProblemOutputFull
{
    public required long Id { get; init; }

    public required string Name { get; init; }

    public required string? Description { get; init; }

    [SwaggerSchema("0 - Easy, 1 - Medium, 2 - Hard")]
    public required ProblemDifficulty Difficulty { get; init; } 

    [SwaggerSchema("0 - Unknown, 1 - Draft, 2 - Open, 3 - Deleted")]
    public required int Status { get; init; }

    public required Guid CreatorId { get; init; }

    public required DateTime CreatedAt { get; init; }

    public required Guid? UpdaterId { get; init; }

    public required DateTime? UpdatedAt { get; init; }

    public required Guid? OpenerId { get; init; }

    public required DateTime? OpenedAt { get; init; }

    public required IReadOnlyList<TestCaseOutput> TestCases { get; init; }

    public required IReadOnlyList<ImplementedProblemOutput> ImplementedProblems { get; init; }
}