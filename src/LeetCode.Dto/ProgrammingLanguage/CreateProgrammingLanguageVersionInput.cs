using Swashbuckle.AspNetCore.Annotations;

namespace LeetCode.Dto.ProgrammingLanguage;

public record CreateProgrammingLanguageVersionInput
{
    public required string ProgrammingLanguageName { get; init; }

    public required string VersionName { get; init; }

    [SwaggerSchema("Language version official realise date in \"YYYY-MM-DD\" format.")]
    public required string RealizedAt { get; init; }

    public required Dictionary<string, string> AdditionalDetails { get; init; }
}