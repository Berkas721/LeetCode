using LeetCode.Abstractions;
using LeetCode.Data.Entities;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace LeetCode.Services;

// куча сервисов с ключами, ключи - мб константы названий языков.
// По бд узнаем какойй язык - достаем по ключу соотвествующий сервис
public class CSharpSolutionRunner : ISolutionRunner
{
    private const string RunSolutionCode = 
        """
        var input = JsonSerializer.Deserialize<Problem.InputData>(InputJson);
        var output = Problem.RunUserSolution(input);
        JsonSerializer.Serialize(output)";
        """;

    public Func<string, Task<string>> Create(string problemDefinitionCode, string solutionCode)
    {
        var script = CSharpScript.Create<string>(
            problemDefinitionCode + solutionCode + RunSolutionCode,
            ScriptOptions.Default.WithReferences("System.Text.Json"),
            globalsType: typeof(TestCase));

        // выдаст ошибку если не скомпилируется
        var scriptRunner = script.CreateDelegate();

        return ScriptRunner;

        async Task<string> ScriptRunner(string input) => await scriptRunner(new ScriptGlobalType(input));
    }
}

file class ScriptGlobalType(string InputJson);