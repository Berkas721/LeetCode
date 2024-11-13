using LeetCode.Dto.ImplementedProblem;

namespace LeetCode.Dto.Problem;

public sealed record TestProblemResult
{
    public required long ProblemId { get; init; }

    public IList<TestImplementationProblemResult> TestImplementationProblemResults { get; set; }
}