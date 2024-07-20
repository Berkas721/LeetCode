using LeetCode.Data.Enums;

namespace LeetCode.Data.Entities;

public class FailedWithErrorTest : SolutionTest
{
    public SolutionTestErrorType ErrorType { get; set; }

    public string ErrorMessage { get; set; } = string.Empty;
}