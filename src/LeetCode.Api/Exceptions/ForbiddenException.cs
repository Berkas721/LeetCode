namespace LeetCode.Exceptions;

public class ForbiddenException(string message) 
    : ApiException(message);