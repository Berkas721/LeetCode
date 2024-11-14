namespace LeetCode.Dto.ImplementedProblem;

public sealed record UpdateImplementedProblemInput
{
    public string? ProblemCode { get; init; }

    public string? DefaultSolutionCode { get; init; }

    public string? WorkingSolutionCode { get; init; }
}