namespace LeetCode.Dto.Topic;

public sealed record CreateTopicInput
{
    public required string Name { get; init; }
    
    public required string? Description { get; init; }
}