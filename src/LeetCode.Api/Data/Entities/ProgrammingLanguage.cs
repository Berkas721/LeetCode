namespace LeetCode.Data.Entities;

public class ProgrammingLanguage
{
    public long Id { get; set; }

    public string LanguageName { get; set; } = string.Empty;

    public string DefaultProblemCode { get; set; } = string.Empty;

    public string DefaultSolutionCode { get; set; } = string.Empty;

    public List<ImplementedProblem>? ImplementedProblems { get; set; }
}