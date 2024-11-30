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

    public static List<Problem> Problems =>
    [
        new Problem
        {
            Id = 1,
            Name = "Сложение чисел",
            Description = "Напиши код для нахождения суммы 2-ух чисел",
            Difficulty = ProblemDifficulty.Easy,
            Status = ProblemStatus.Open,
            CreateInfo = new ActionInfo(UserId)
        },
        new Problem
        {
            Id = 2,
            Name = "Максимальное число",
            Description = "Напиши код для нахождения максимального числа",
            Difficulty = ProblemDifficulty.Medium,
            Status = ProblemStatus.Open,
            CreateInfo = new ActionInfo(UserId)
        },
        new Problem
        {
            Id = 3,
            Name = "Максимальное число под номером n",
            Description = "Напиши код для нахождения максимального числа под номером n",
            Difficulty = ProblemDifficulty.Hard,
            Status = ProblemStatus.Open,
            CreateInfo = new ActionInfo(UserId)
        },
        new Problem
        {
            Id = 4,
            Name = "Вычитание чисел",
            Description = "Напиши код для нахождения разницы 2-ух чисел",
            Difficulty = ProblemDifficulty.Easy,
            Status = ProblemStatus.Open,
            CreateInfo = new ActionInfo(UserId)
        },
        new Problem
        {
            Id = 5,
            Name = "Умножение чисел",
            Description = "Напиши код для нахождения результата умножения 2-ух чисел",
            Difficulty = ProblemDifficulty.Easy,
            Status = ProblemStatus.Open,
            CreateInfo = new ActionInfo(UserId)
        }
    ];

    public static List<ImplementedProblem> ImplementedProblems => new()
    {
        new ImplementedProblem
        {
            Id = Guid.NewGuid(),
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
                    throw new NotImplementedException();
                }
            }
            """,
            WorkingSolutionCode =
            """
            public class Solution
            {
                public static int GetSumma(int a, int b)
                {
                    return a + b;
                }
            }
            """,
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 1,
            LanguageId = LanguageId
        },
        new ImplementedProblem
        {
            Id = Guid.NewGuid(),
            ProblemCode = 
            """
            public class Problem
            {
                public class InputData
                {
                    public float[] list { get; init; }
                }
               
                public class OutputData
                {
                    public float? max { get; init; }
                }
           
                public static OutputData CallUserSolution(InputData input)
                {
                    return new OutputData
                    {
                        max = Solution.FindMax(input.list)
                    };
                }
            }
            """,
            DefaultSolutionCode = 
            """
            public class Solution
            {
                public static float? FindMax(float[] list)
                {
                    throw new NotImplementedException();
                }
            }
            """,
            WorkingSolutionCode = 
            """
            public class Solution
            {
                public static float? FindMax(float[] list)
                {
                    if (list.Length == 0) 
                        return null;

                    float max = list[0];

                    for (int i = 1; i < list.Length; i++)
                    {
                        if (list[i] > max)
                        {
                            max = list[i];
                        }
                    }
            
                    return max;
                }
            }
            """,
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 2,
            LanguageId = LanguageId
        },
        new ImplementedProblem
        {
            Id = Guid.NewGuid(),
            ProblemCode = 
                """
                public class Problem
                {
                    public class InputData
                    {
                         public float[] list { get; init; }
                         public int n { get; init; }
                    }
               
                     public class OutputData
                    {
                        public float? max { get; init; }
                    }
               
                    public static OutputData CallUserSolution(InputData input)
                    {
                        return new OutputData
                        {
                            max = Solution.FindNthMax(
                                input.list,
                                input.n)
                        };
                    }
                }
                """,
            DefaultSolutionCode = 
                """
                public class Solution
                {
                    public static float? FindNthMax(float[] list, int n)
                    {
                        throw new NotImplementedException();
                    }
                }
                """,
            WorkingSolutionCode = 
                """
                public class Solution
                {
                    public static float? FindNthMax(float[] list, int n)
                    {
                        if(list.Length < n-1) 
                            return null;
                    
                        for (int i = 0; i < list.Length - 1; i++)
                        {
                            for (int j = i + 1; j < list.Length; j++)
                            {
                                if (list[i] < list[j])
                                {
                                    float temp = list[i];
                                    list[i] = list[j];
                                    list[j] = temp;
                                }
                            }
                        }
                
                        return list[n - 1];
                    }
                }
                """,
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 3,
            LanguageId = LanguageId
        },
        new ImplementedProblem
        {
            Id = Guid.NewGuid(),
            ProblemCode =
                """
                public class Problem
                {
                    public class InputData
                    {
                        public float a { get; init; }
                        public float b { get; init; }
                    }
                 
                    public class OutputData
                    {
                        public float difference { get; init; }
                    }
                 
                    public static OutputData CallUserSolution(InputData input)
                    {
                        return new OutputData
                        {
                            difference = Solution.FindDifference(
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
                    public static float FindDifference(float a, float b)
                    {
                        throw new NotImplementedException();
                    }
                }
                """,
            WorkingSolutionCode =
                """
                public class Solution
                {
                    public static float FindDifference(float a, float b)
                    {
                        return a - b;
                    }
                }
                """,
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 4,
            LanguageId = LanguageId
        },
        new ImplementedProblem
        {
            Id = Guid.NewGuid(),
            ProblemCode =
                """
                public class Problem
                {
                    public class InputData
                    {
                        public float a { get; init; }
                        public float b { get; init; }
                    }
                 
                    public class OutputData
                    {
                        public float multiplication { get; init; }
                    }
                 
                    public static OutputData CallUserSolution(InputData input)
                    {
                        return new OutputData
                        {
                            multiplication = Solution.Multiply(
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
                    public static float Multiply(float a, float b)
                    {
                        throw new NotImplementedException();
                    }
                }
                """,
            WorkingSolutionCode =
                """
                public class Solution
                {
                    public static float Multiply(float a, float b)
                    {
                        return a * b;
                    }
                }
                """,
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 5,
            LanguageId = LanguageId
        },
    };

    public static List<TestCase> TestCases =>
    [
        new TestCase
        {
            Id = 1,
            Input = "{\"a\":1,\"b\":2}",
            Output = "{\"sum\":3}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 1
        },
        new TestCase
        {
            Id = 2,
            Input = "{\"a\":6,\"b\":5}",
            Output = "{\"sum\":11}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 1
        },
        new TestCase
        {
            Id = 3,
            Input = "{\"a\":-11,\"b\":1}",
            Output = "{\"sum\":-10}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 1
        },
        new TestCase
        {
            Id = 4,
            Input = "{\"a\":100,\"b\":200}",
            Output = "{\"sum\":300}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 1
        },
        new TestCase
        {
            Id = 5,
            Input = "{\"a\":0,\"b\":0}",
            Output = "{\"sum\":0}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 1
        },
        new TestCase
        {
            Id = 6,
            Input = "{\"list\":[1.2, 3.4, 5.6, 7.8]}",
            Output = "{\"max\":7.8}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 2
        },
        new TestCase
        {
            Id = 7,
            Input = "{\"list\":[-10.5, -3.2, -7.8, -1.1]}",
            Output = "{\"max\":-1.1}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 2
        },
        new TestCase
        {
            Id = 8,
            Input = "{\"list\":[]}",
            Output = "{\"max\":null}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 2
        },
        new TestCase
        {
            Id = 9,
            Input = "{\"list\":[0.0, 0.0, 0.0, 0.0]}",
            Output = "{\"max\":0}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 2
        },
        new TestCase
        {
            Id = 10,
            Input = "{\"list\":[99.9, 45.3, 123.4, 12.5]}",
            Output = "{\"max\":123.4}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 2
        },
        new TestCase
        {
            Id = 11,
            Input = "{\"list\":[10.5, 7.8, 3.2, 15.3], \"n\":2}",
            Output = "{\"max\":10.5}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 3
        },
        new TestCase
        {
            Id = 12,
            Input = "{\"list\":[-1.5, -3.0, -7.2, -0.5], \"n\":1}",
            Output = "{\"max\":-0.5}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 3
        },
        new TestCase
        {
            Id = 13,
            Input = "{\"list\":[], \"n\":3}",
            Output = "{\"max\":null}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 3
        },
        new TestCase
        {
            Id = 14,
            Input = "{\"list\":[5.5, 5.5, 5.5], \"n\":2}",
            Output = "{\"max\":5.5}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 3
        },
        new TestCase
        {
            Id = 15,
            Input = "{\"list\":[99.1, 45.3, 123.4, 67.8], \"n\":4}",
            Output = "{\"max\":45.3}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 3
        },
        new TestCase
        {
            Id = 16,
            Input = "{\"a\":5.5, \"b\":3.2}",
            Output = "{\"difference\":2.3}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 4
        },
        new TestCase
        {
            Id = 17,
            Input = "{\"a\":-10.0, \"b\":4.5}",
            Output = "{\"difference\":-14.5}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 4
        },
        new TestCase
        {
            Id = 18,
            Input = "{\"a\":0.0, \"b\":0.0}",
            Output = "{\"difference\":0}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 4
        },
        new TestCase
        {
            Id = 19,
            Input = "{\"a\":100.0, \"b\":150.5}",
            Output = "{\"difference\":-50.5}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 4
        },
        new TestCase
        {
            Id = 20,
            Input = "{\"a\":1.5, \"b\":-2.5}",
            Output = "{\"difference\":4}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 4
        },
        new TestCase
        {
            Id = 21,
            Input = "{\"a\":3.5, \"b\":2.0}",
            Output = "{\"multiplication\":7}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 5
        },
        new TestCase
        {
            Id = 22,
            Input = "{\"a\":-4.0, \"b\":5.0}",
            Output = "{\"multiplication\":-20}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 5
        },
        new TestCase
        {
            Id = 23,
            Input = "{\"a\":0.0, \"b\":7.8}",
            Output = "{\"multiplication\":0}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 5
        },
        new TestCase
        {
            Id = 24,
            Input = "{\"a\":-3.5, \"b\":-2.0}",
            Output = "{\"multiplication\":7}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 5
        },
        new TestCase
        {
            Id = 25,
            Input = "{\"a\":100.0, \"b\":0.01}",
            Output = "{\"multiplication\":1}",
            CreateInfo = new ActionInfo(UserId),
            ProblemId = 5
        }
    ];
}