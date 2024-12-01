namespace LeetCode.Dto.ImplementedProblem;

public sealed record ImplementedProblemSecretOutput
{
    public required Guid Id { get; init; }

    public required long ProblemId { get; init; }

    public required long LanguageId { get; init; }
}