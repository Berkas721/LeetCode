namespace LeetCode.Data.Entities;

public class AcceptedSolution : ProblemSolution
{
    public new DateTime SubmittedAt { get; set; }

    public int TotalUsedTime { get; set; }

    public int TotalUsedMemory { get; set; }
}