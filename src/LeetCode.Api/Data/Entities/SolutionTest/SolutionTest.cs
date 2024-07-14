using LeetCode.Data.Enums;

namespace LeetCode.Data.Entities.SolutionTest;

public class SolutionTest
{
    public long Id { get; set; }

    public DateTime Date { get; set; }

    public SolutionTestResultStatus ResultStatus { get; }


    public long SolutionId { get; set; }

    public ProblemSolution? Solution { get; set; }


    public long TestCaseId { get; set; }

    public TestCase? TestCase { get; set; }
}