﻿namespace LeetCode.Data.Entities;

public class ProgrammingLanguageVersion
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateOnly RealizedAt { get; set; }

    public Dictionary<string, string> AdditionalDetails { get; set; } = [];


    public string LanguageName { get; set; } = string.Empty;

    public ProgrammingLanguage? Language { get; set; }


    public List<SolutionRunningDetails>? SolutionRunningDetails { get; set; }
}