using LeetCode.Abstractions;
using LeetCode.Data.Enums;
using LeetCode.Data.OwnedTypes;

namespace LeetCode.Data.Entities;

public class ProblemSolution 
    : IHasCreateInfo, IHasId<long>
{
    public long Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public ProblemSolutionStatus Status { get; set; }

    public ActionInfo CreateInfo { get; set; }

    public DateTime? UpdatedAt { get; init; }

    public DateTime? SubmittedAt { get; init; }

    public long? TotalUsedTime { get; init; }

    public long? TotalUsedMemory { get; init; }

    public long[]? FailedTestIds { get; init; }


    public Guid ImplementedProblemId { get; set; }

    public ImplementedProblem? ImplementedProblem { get; set; }

    public List<SolutionTest>? Tests { get; set; }
}