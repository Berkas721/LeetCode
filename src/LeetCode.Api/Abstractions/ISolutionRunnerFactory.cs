namespace LeetCode.Abstractions;

public interface ISolutionRunnerFactory
{
    public ISolutionRunner CreateRunner(string problemCode, string solutionCode, long languageId);
}