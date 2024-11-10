using LeetCode.Data.Enums;

namespace LeetCode.Data.Entities;

public class ProblemSolution
{
    public long Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public ProblemSolutionStatus Status { get; }

    public DateTime? SubmittedAt { get; set; }

    public Guid ImplementedProblemId { get; set; }

    public ImplementedProblem? ImplementedProblem { get; set; }

    public List<SolutionTest>? Tests { get; set; }
}