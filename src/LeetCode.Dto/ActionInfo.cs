namespace LeetCode.Dto;

public sealed record ActionInfo
{
    public required DateTime Date { get; init; }

    public required Guid AgentId { get; init; }
}