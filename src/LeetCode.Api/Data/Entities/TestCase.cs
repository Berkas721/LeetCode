using LeetCode.Data.Entities.OwnedEntities;

namespace LeetCode.Data.Entities;

public class TestCase
{
    public long Id { get; set; }

    public long ProblemId { get; set; }

    public Problem? Problem { get; set; }

    public string Input { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;

    public CreateInfo CreateInfo { get; set; } = default!;
}