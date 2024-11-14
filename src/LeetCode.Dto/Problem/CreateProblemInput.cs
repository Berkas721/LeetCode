using Swashbuckle.AspNetCore.Annotations;

namespace LeetCode.Dto.Problem;

public sealed record CreateProblemInput
{
    public required string Name { get; init; }

    public required string? Description { get; init; }

    // TODO: зависимость от enum ProblemDifficulty, хз как ее обойти
    [SwaggerSchema("0 - Easy, 1 - Medium, 2 - Hard")]
    public required int Difficulty { get; init; } 

    public List<long>? TopicIds { get; init; }
}