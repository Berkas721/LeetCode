using Swashbuckle.AspNetCore.Annotations;

namespace LeetCode.Dto.Problem;

public sealed record UpdateProblemInput
{
    public required long Id { get; init; }

    public required string? NewName { get; init; }

    public required string? NewDescription { get; init; }

    // TODO: зависимость от enum ProblemDifficulty, хз как ее обойти
    [SwaggerSchema("0 - Easy, 1 - Medium, 2 - Hard")]
    public required int? NewDifficulty { get; init; } 

    public required bool? IsPremiumRequired { get; init; }

    public required List<long>? NewTopicIds { get; init; }
}