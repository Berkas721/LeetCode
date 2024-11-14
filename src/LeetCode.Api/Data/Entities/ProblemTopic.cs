using LeetCode.Abstractions;

namespace LeetCode.Data.Entities;

public class ProblemTopic : IHasId<long>
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;


    public List<Problem>? Problems { get; set; }
}