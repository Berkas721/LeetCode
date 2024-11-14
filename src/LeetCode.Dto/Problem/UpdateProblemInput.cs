using Swashbuckle.AspNetCore.Annotations;

namespace LeetCode.Dto.Problem;

public sealed record UpdateProblemInput
{
    public string? NewName { get; init; }

    public string? NewDescription { get; init; }

    // TODO: зависимость от enum ProblemDifficulty, хз как ее обойти
    [SwaggerSchema("0 - Easy, 1 - Medium, 2 - Hard")]
    public int? NewDifficulty { get; init; } 

    public List<long>? NewTopicIds { get; init; }
}