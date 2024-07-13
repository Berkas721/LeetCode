namespace LeetCode.Data.Entities;

public class ProblemSolution
{
    public long Id { get; set; }

    public DateTime? SubmittedAt { get; set; }

    public string Code { get; set; } = string.Empty;

    public string? Notes { get; set; }


    public long SessionId { get; set; }
    
    public ProblemResolveSession? Session { get; set; }

    
    public long LanguageId { get; set; }
    
    public ProgrammingLanguage? Language { get; set; }
}