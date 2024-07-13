namespace LeetCode.Data.Entities.OwnedEntities;

public class DeleteInfo
{
    public DateTime Date { get; set; }

    public Guid DeleterId { get; set; }

    public ApplicationUser? Deleter { get; set; }
}