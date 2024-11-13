namespace LeetCode.Abstractions;

public interface ISolutionRunner
{
    public Task<string> RunAsync(string inputJson);
}