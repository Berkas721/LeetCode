using LeetCode.Data.OwnedTypes;

namespace LeetCode.Data.Entities;

public class TestCase
{
    public long Id { get; set; }

    public string Input { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;

    public ActionInfo CreateInfo { get; set; } = default!;


    public long ProblemId { get; set; }

    public Problem? Problem { get; set; }


    public List<SolutionTest>? SolutionTests { get; set; }
}