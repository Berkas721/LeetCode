using LeetCode.Dto.Enums;

namespace LeetCode.Dto.TestCase;

// наверное этот record должен состоять из TestCaseId, List<TestTestCaseInSpecifiedImplementedProblemResult> и IsPassed 
// но и так сойдет
public sealed record TestTestCaseResult
{
    public required Guid ImplementedProblemId { get; init; }

    public required RunTestCaseResult RunTestCaseResult { get; init; }
}