namespace LeetCode.Dto.ImplementedProblem;

public sealed record CreateImplementedProblemInput
{
    public required long ProblemId { get; init; }

    public required long LanguageId { get; init; }
}