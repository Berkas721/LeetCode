using LeetCode.Data.Entities;

namespace LeetCode.Data.OwnedTypes;

public class DeleteInfo
{
    public DateTime Date { get; set; }

    public Guid DeleterId { get; set; }

    public ApplicationUser? Deleter { get; set; }
}