using LeetCode.Abstractions;
using LeetCode.Dto.Enums;

namespace LeetCode.Data.Entities;

public class SolutionTest : IHasId<long>
{
    public long Id { get; init; }

    public DateTime Date { get; set; }

    public SolutionTestResultStatus ResultStatus { get; init; }

    public long? UsedTime { get; init; }

    public long? UsedMemory { get; init; }

    public string? ErrorMessage { get; init; }

    public string? IncorrectAnswer { get; init; }


    public long SolutionId { get; init; }

    public ProblemSolution? Solution { get; init; }


    public long TestCaseId { get; init; }

    public TestCase? TestCase { get; init; }
}