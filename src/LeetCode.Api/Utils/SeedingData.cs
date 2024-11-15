using LeetCode.Data.Entities;
using LeetCode.Data.Enums;
using LeetCode.Data.OwnedTypes;
using LeetCode.Dto.Enums;

namespace LeetCode.Utils;

public static class SeedingData
{
    public static Guid UserId => Guid.Parse("d1e79568-09d0-4798-a549-38498afd7969");
    public static ApplicationUser User => new()
    {
        Id = UserId,
        UserName = "string",
        FirstName = "string",
        LastName = "string",
        Birthday = DateOnly.Parse("2014-9-11"),
        Registration = DateOnly.Parse("2014-9-11")
    };

    public static long LanguageId => 1;
    public static ProgrammingLanguage Language => new()
    {
        Id = LanguageId,
        LanguageName = "CSharp",
        DefaultProblemCode = 
            """
            public class Problem 
            { 
                public class InputData  
                { 
                    // properties of your testcase input
                } 
             
                public class OutputData  
                { 
                    // properties of your testcase output
                } 
             
                public static OutputData CallUserSolution(InputData input)  
                { 
                    // call Solution.SomeSolutionMethods to form OutputData
                } 
            } 
            """,
        DefaultSolutionCode = 
            """
            public class Solution 
            { 
                // some methods that users will be required to create
            } 
            """
    };

    public static long ProblemId => 1;
    public static Problem Problem => new()
    {
        Id = ProblemId,
        Name = "Задача для тестов",
        Description = "Надо написать код для сложения a и b",
        Difficulty = ProblemDifficulty.Easy,
        Status = ProblemStatus.Draft,
        CreateInfo = new ActionInfo(UserId)
    };

    public static Guid ImplementedProblemId => Guid.Parse("c7272279-87bb-4172-b0d6-7093aa5b1976");
    public static ImplementedProblem ImplementedProblem => new()
    {
        Id = ImplementedProblemId,
        ProblemCode =
            """
            public class Problem
            {
                public class InputData
                {
                    public int a { get; init; }
                    public int b { get; init; }
                }
             
                public class OutputData
                {
                    public int sum { get; init; }
                }
             
                public static OutputData CallUserSolution(InputData input)
                {
                    return new OutputData
                    {
                        sum = Solution.GetSumma(
                            input.a,
                            input.b)
                    };
                }
            }
            """,
        DefaultSolutionCode =
            """
            public class Solution
            {
                public static int GetSumma(int a, int b)
                {
                    throw NotImplementedException();
                }
            }
            """,
        WorkingSolutionCode =
            """
            public class Solution
            {
                public static int GetSumma(int a, int b)
                {
                    return a+b;
                }
            }
            """,
        CreateInfo = new ActionInfo(UserId),
        ProblemId = ProblemId,
        LanguageId = LanguageId
    };

    public static List<TestCase> TestCases => [
        new()
        {
            Id = 1,
            Input = "{\"a\":1,\"b\":2}",
            Output = "{\"sum\":3}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = ProblemId
        },
        new()
        {
            Id = 2,
            Input = "{\"a\":6,\"b\":5}",
            Output = "{\"sum\":11}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = ProblemId
        },
        new()
        {
            Id = 3,
            Input = "{\"a\":-11,\"b\":1}",
            Output = "{\"sum\":-10}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = ProblemId
        }
    ];
}