using LeetCode.Data.Entities;

namespace LeetCode.Data.OwnedTypes;

public class UpdateInfo
{
    public DateTime Date { get; set; }

    public Guid UpdaterId { get; set; }

    public ApplicationUser? Updater { get; set; }
}