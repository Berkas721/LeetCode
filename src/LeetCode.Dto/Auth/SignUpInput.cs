using Swashbuckle.AspNetCore.Annotations;

namespace LeetCode.Dto.Auth;

public sealed record SignUpInput
{
    public required string UserName { get; init; }

    public required string Password { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    [SwaggerSchema("Birthday of the person in \"YYYY-MM-DD\" format.")]
    public required string Birthday { get; init; }
}