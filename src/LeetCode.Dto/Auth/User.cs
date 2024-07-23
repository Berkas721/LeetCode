namespace LeetCode.Dto.Auth;

public sealed record User
{
    public required string UserName { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required IList<string> Roles { get; init; }

    public required DateOnly Birthday { get; init; }
}