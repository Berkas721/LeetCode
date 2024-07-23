namespace LeetCode.Exceptions;

public class AuthException : ApiException
{
    public AuthException(string message) : base(message) {}
}