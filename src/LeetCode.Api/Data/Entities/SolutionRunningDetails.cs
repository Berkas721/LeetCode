using LeetCode.Data.OwnedTypes;

namespace LeetCode.Data.Entities;

public class SolutionRunningDetails
{
    public Guid Id { get; set; }

    public string DefaultCode { get; set; } = string.Empty;

    public string WorkingSolution { get; set; } = string.Empty;

    public Dictionary<string, string> AdditionalDetails { get; set; } = [];

    public ActionInfo CreateInfo { get; set; } = default!;

    public ActionInfo? DeleteInfo { get; set; }


    public long ProblemId { get; set; }

    public Problem? Problem { get; set; }


    public long LanguageId { get; set; }

    public ProgrammingLanguageVersion? Language { get; set; }


    public List<ProblemSolution>? Solutions { get; set; }
}