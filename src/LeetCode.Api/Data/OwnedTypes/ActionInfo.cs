using LeetCode.Data.Entities;

namespace LeetCode.Data.OwnedTypes;

public class ActionInfo
{
    public DateTime Date { get; set; }

    public Guid AgentId { get; set; }

    public ApplicationUser? Agent { get; set; }
}