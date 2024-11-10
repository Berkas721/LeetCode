using LeetCode.Data.OwnedTypes;

namespace LeetCode.Data.Entities;

public class ImplementedProblem
{
    public Guid Id { get; set; }

    public string DefaultCode { get; set; } = string.Empty;

    public string WorkingSolutionCode { get; set; } = string.Empty;

    public Dictionary<string, string> AdditionalDetails { get; set; } = [];

    public ActionInfo CreateInfo { get; set; } = default!;

    public ActionInfo? DeleteInfo { get; set; }


    public long ProblemId { get; set; }

    public Problem? Problem { get; set; }


    public long LanguageId { get; set; }

    public ProgrammingLanguage? Language { get; set; }


    public List<ProblemSolution>? Solutions { get; set; }
}