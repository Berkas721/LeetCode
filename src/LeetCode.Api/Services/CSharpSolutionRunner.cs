using LeetCode.Abstractions;
using LeetCode.Data.Entities;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace LeetCode.Services;

// куча сервисов с ключами, ключи - мб константы названий языков.
// По бд узнаем какойй язык - достаем по ключу соотвествующий сервис
public class CSharpSolutionRunner : ISolutionRunner
{
    private const string NecessaryUsing = 
        "using System.Text.Json;\n";
    
    private const string RunSolutionCode = 
        """
        var input = JsonSerializer.Deserialize<Problem.InputData>(InputJson); 
        var output = Problem.CallUserSolution(input); 
        JsonSerializer.Serialize(output)
        """;

    public Func<string, Task<string>> Create(string problemCode, string solutionCode)
    {
        var script = CSharpScript.Create<string>(
            NecessaryUsing + problemCode + solutionCode + RunSolutionCode,
            ScriptOptions.Default.WithReferences("System.Text.Json"),
            globalsType: typeof(ScriptGlobalType));

        // выдаст ошибку если не скомпилируется
        var scriptRunner = script.CreateDelegate();

        return ScriptRunner;

        async Task<string> ScriptRunner(string input) => await scriptRunner(new ScriptGlobalType(input));
    }

    public class ScriptGlobalType
    {
        public string InputJson { get; init; }

        public ScriptGlobalType(string inputJson)
        {
            InputJson = inputJson;
        }
    }
}