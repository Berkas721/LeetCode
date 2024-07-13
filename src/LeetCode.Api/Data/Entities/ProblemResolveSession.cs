namespace LeetCode.Data.Entities;

public class ProblemResolveSession
{
    public long Id { get; set; }

    public DateTime StartedAt { get; set; }


    public Guid UserId { get; set; }

    public ApplicationUser? User { get; set; }


    public long ProblemId { get; set; }
    
    public Problem? Problem { get; set; }


    public List<ProblemSolution> Solutions { get; set; } = [];
}