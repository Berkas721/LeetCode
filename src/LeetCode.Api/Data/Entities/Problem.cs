using LeetCode.Data.Entities.OwnedEntities;
using LeetCode.Data.Enums;

namespace LeetCode.Data.Entities;

public class Problem
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Difficulty Difficulty { get; set; } = Difficulty.Easy;

    public bool IsPremiumRequired { get; set; }

    public List<ProblemTopic> Topics { get; set; } = [];

    public CreateInfo CreateInfo { get; set; } = default!;

    public DeleteInfo? DeleteInfo { get; set; }
}