namespace LeetCode.Data.Entities;

public class ProgrammingLanguage
{
    public long Id { get; set; }

    public string LanguageName { get; set; } = string.Empty;

    public string VersionName { get; set; } = string.Empty;

    public DateOnly RealizedAt { get; set; }

    public Dictionary<string, string> AdditionalDetails { get; set; } = [];

    public List<ImplementedProblem>? ImplementedProblems { get; set; }
}