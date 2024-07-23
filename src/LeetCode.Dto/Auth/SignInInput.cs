namespace LeetCode.Dto.Auth;

public sealed record SignInInput
{
    public required string UserName { get; init; }

    public required string Password { get; init; }
}