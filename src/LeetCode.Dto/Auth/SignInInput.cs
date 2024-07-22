namespace LeetCode.Dto.Auth;

public sealed record SignInInput
{
    public required string Username { get; init; }

    public required string Password { get; init; }
}