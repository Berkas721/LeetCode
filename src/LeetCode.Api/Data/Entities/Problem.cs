using LeetCode.Data.Enums;
using LeetCode.Data.OwnedTypes;

namespace LeetCode.Data.Entities;

public class Problem
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ProblemDifficulty Difficulty { get; set; } = ProblemDifficulty.Easy;

    public bool IsPremiumRequired { get; set; }

    public DateTime? OpenAt { get; set; }

    public CreateInfo CreateInfo { get; set; } = default!;

    public UpdateInfo? UpdateInfo { get; set; }

    public DeleteInfo? DeleteInfo { get; set; }


    public List<ProblemTopic> Topics { get; set; } = [];
}