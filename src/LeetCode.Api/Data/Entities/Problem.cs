using LeetCode.Data.Enums;
using LeetCode.Data.OwnedTypes;
using LeetCode.Dto.Enums;

namespace LeetCode.Data.Entities;

public class Problem
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ProblemDifficulty Difficulty { get; set; } = ProblemDifficulty.Easy;

    public ProblemStatus Status { get; set; } = ProblemStatus.Unknown;

    public ActionInfo CreateInfo { get; set; } = default!;

    public ActionInfo? UpdateInfo { get; set; }

    public ActionInfo? OpenInfo { get; set; }

    public ActionInfo? DeleteInfo { get; set; }


    public List<ProblemTopic> Topics { get; set; } = [];

    public List<TestCase>? TestCases { get; set; }

    public List<ImplementedProblem>? ImplementedProblems { get; set; }
}