using LeetCode.Abstractions;
using LeetCode.Dto.Enums;
using LeetCode.Utils.SolutionRunners;

namespace LeetCode.Services;

public class SolutionRunnerFactory : ISolutionRunnerFactory
{
    public ISolutionRunner CreateRunner(string problemCode, string solutionCode, long languageId) => 
        (ProgrammingLanguages)languageId switch
        {
            ProgrammingLanguages.CSharp => new CSharpSolutionRunner(problemCode, solutionCode),
            _ => throw new Exception($"Приложение не умеет проверять решения, написанные на языке программирования с id {languageId}")
        };
}