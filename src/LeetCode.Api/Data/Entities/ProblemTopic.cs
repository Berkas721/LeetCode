namespace LeetCode.Data.Entities;

public class ProblemTopic
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;


    public List<Problem>? Problems { get; set; }
}