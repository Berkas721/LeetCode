namespace LeetCode.Dto.ImplementedProblem;

public sealed record CreateImplementedProblemInput
{
    public required long ProblemId { get; init; }

    public required long LanguageId { get; init; }

    public required string ProblemCode { get; init; }

    public required string WorkingSolutionCode { get; init; }
}