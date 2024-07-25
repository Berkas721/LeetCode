namespace LeetCode.Dto.ProgrammingLanguage;

public sealed record VersionOfProgrammingLanguage
{
    public required long Id { get; init; }

    public required string ProgrammingLanguageName { get; init; }

    public required string VersionName { get; init; }

    public DateOnly RealizedAt { get; init; }

    public required Dictionary<string, string> AdditionalDetails { get; init; }
}