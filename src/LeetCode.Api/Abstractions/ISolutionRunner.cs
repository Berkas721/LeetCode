namespace LeetCode.Abstractions;

public interface ISolutionRunner
{
    public Func<string, Task<string>> Create(string problemDefinitionCode, string solutionCode);
}