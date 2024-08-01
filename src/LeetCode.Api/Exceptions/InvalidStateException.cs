namespace LeetCode.Exceptions;

public class InvalidStateException : ApiException
{
    public InvalidStateException(string message) : base(message) {}
}