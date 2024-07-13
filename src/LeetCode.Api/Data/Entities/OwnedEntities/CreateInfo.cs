namespace LeetCode.Data.Entities.OwnedEntities;

public class CreateInfo
{
    public DateTime Date { get; set; }

    public Guid CreatorId { get; set; }

    public ApplicationUser? Creator { get; set; }
}