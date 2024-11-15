﻿using LeetCode.Dto.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace LeetCode.Dto.Problem;

public sealed record ProblemOutput
{
    public required string Name { get; init; }

    public required string? Description { get; init; }

    // TODO: зависимость от enum ProblemDifficulty, хз как ее обойти
    [SwaggerSchema("0 - Easy, 1 - Medium, 2 - Hard")]
    public required ProblemDifficulty Difficulty { get; init; } 

    // TODO: зависимость от enum ProblemStatus, хз как ее обойти
    [SwaggerSchema("0 - Unknown, 1 - Draft, 2 - Open, 3 - Deleted")]
    public required int Status { get; init; }

    // TODO: переделать потом на ActionInfo
    public required Guid CreatorId { get; init; }
    
    public required DateTime CreatedAt { get; init; }

    public required Guid? UpdaterId { get; init; }
    
    public required DateTime? UpdatedAt { get; init; }

    public required Guid? OpenerId { get; init; }
    
    public required DateTime? OpenedAt { get; init; }
}