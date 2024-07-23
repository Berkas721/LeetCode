namespace LeetCode.Exceptions;

public sealed class ResourceNotFoundException : ApiException
{
    public ResourceNotFoundException(string message) : base(message) {}

    public static void ThrowIfNull<T>(T? value, string message)
    {
        if (value is null)
            throw new ResourceNotFoundException(message);
    }
}