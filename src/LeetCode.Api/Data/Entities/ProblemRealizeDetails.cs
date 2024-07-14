using LeetCode.Data.Entities.OwnedEntities;

namespace LeetCode.Data.Entities;

public class ProblemRealizeDetails
{
    public Guid Id { get; set; }

    public long LanguageId { get; set; }

    public ProgrammingLanguage? Language { get; set; }

    public long ProblemId { get; set; }

    public Problem? Problem { get; set; }

    public string DefaultCode { get; set; } = string.Empty;

    public string WorkingSolution { get; set; } = string.Empty;

    // TODO: set боязно оставлять, с init нельзя будет обновлять атрибут, нужно че то придумать
    public Dictionary<string, string> AdditionalDetails { get; set; } = [];

    public CreateInfo CreateInfo { get; set; } = default!;

    public DeleteInfo? DeleteInfo { get; set; }
}