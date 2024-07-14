namespace LeetCode.Data.Entities;

public class ProgrammingLanguage
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;

    //public DateOnly RealizedAt { get; set; }

    // TODO: set боязно оставлять, с init нельзя будет обновлять атрибут, нужно че то придумать
    public Dictionary<string, string> AdditionalDetails { get; set; } = [];
}