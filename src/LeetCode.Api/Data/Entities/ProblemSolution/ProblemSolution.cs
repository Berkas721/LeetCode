using LeetCode.Data.Enums;

namespace LeetCode.Data.Entities;

public class ProblemSolution
{
    public long Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string? Notes { get; set; }

    public ProblemSolutionStatus Status { get; }

    public DateTime? SubmittedAt { get; }


    public long SessionId { get; set; }

    public ProblemResolveSession? Session { get; set; }


    public Guid RunningDetailsId { get; set; }

    public SolutionRunningDetails? RunningDetails { get; set; }


    public List<SolutionTest>? Tests { get; set; }
}