using LeetCode.Data.Entities;

namespace LeetCode.Data.OwnedTypes;

public class CreateInfo
{
    public DateTime Date { get; set; }

    public Guid CreatorId { get; set; }

    public ApplicationUser? Creator { get; set; }
}