using LeetCode.Abstractions;
using LeetCode.Data.OwnedTypes;
using LeetCode.Dto.Enums;

namespace LeetCode.Data.Entities;

public class ProblemSolution 
    : IHasCreateInfo, IHasId<long>
{
    public long Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public ProblemSolutionStatus Status { get; set; }

    public ActionInfo CreateInfo { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? SubmittedAt { get; set; }

    public long? TotalUsedTime { get; set; }

    public long? TotalUsedMemory { get; set; }

    public long[]? FailedTestIds { get; set; }


    public Guid ImplementedProblemId { get; set; }

    public ImplementedProblem? ImplementedProblem { get; set; }

    public List<SolutionTest>? Tests { get; set; }
}