namespace LeetCode.Data.Entities;

public class ProgrammingLanguage
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;


    public List<ProgrammingLanguageVersion>? Versions { get; set; }
}