using LeetCode.Services;

namespace LeetCode.Abstractions;

public interface ITestSolution
{
    public Task<IReadOnlyList<SolutionTestResult>> TestAsync(
        string solutionCode,
        string problemDefinitionsCode,
        string languageName,
        IReadOnlyList<TestCaseData> testCases);
}