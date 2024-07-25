namespace LeetCode.Dto.Topic;

public sealed record UpdateTopicInput
{
    public required string? NewName { get; init; }
    
    public required string? NewDescription { get; init; }
}