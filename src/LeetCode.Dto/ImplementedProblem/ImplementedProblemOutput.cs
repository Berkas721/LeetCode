namespace LeetCode.Dto.ImplementedProblem;

public sealed record ImplementedProblemOutput
{
    public required Guid Id { get; init; }

    public required long ProblemId { get; init; }

    public required long LanguageId { get; init; }

    public required string ProblemCode { get; init; }

    public required string DefaultSolutionCode { get; init; }

    public required string WorkingSolutionCode { get; init; }

    public required ActionInfo CreateInfo { get; init; }

    public ActionInfo? DeleteInfo { get; init; }
}