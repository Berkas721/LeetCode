﻿using LeetCode.Abstractions;
using LeetCode.Exceptions;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace LeetCode.Utils.SolutionRunners;

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

    private readonly ScriptRunner<string> _scriptRunner;

    public CSharpSolutionRunner(string problemCode, string solutionCode)
    {
        var script = CSharpScript.Create<string>(
            NecessaryUsing + problemCode + solutionCode + RunSolutionCode,
            ScriptOptions.Default.WithReferences("System.Text.Json"),
            globalsType: typeof(ScriptGlobalType));

        try
        {
            _scriptRunner = script.CreateDelegate();
        }
        catch (Exception ex)
        {
            throw new CompilationException($"не удалось скомпилировать C# файл: {ex.Message}");
        }
    }

    public async Task<string> RunAsync(string inputJson) => 
        await _scriptRunner(new ScriptGlobalType(inputJson));
}

public class ScriptGlobalType
{
    public string InputJson { get; init; }

    public ScriptGlobalType(string inputJson)
    {
        InputJson = inputJson;
    }
}