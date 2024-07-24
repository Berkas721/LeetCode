namespace LeetCode.Dto.Topic;

public sealed record Topic
{
    public required long Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string? Description { get; init; }
}