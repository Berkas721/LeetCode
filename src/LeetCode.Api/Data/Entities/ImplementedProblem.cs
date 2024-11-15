using LeetCode.Abstractions;
using LeetCode.Data.OwnedTypes;

namespace LeetCode.Data.Entities;

public class ImplementedProblem : IHasCreateInfo, IHasId<Guid>
{
    public Guid Id { get; set; }

    public string ProblemCode { get; set; } = string.Empty;

    public string DefaultSolutionCode { get; set; } = string.Empty;

    public string WorkingSolutionCode { get; set; } = string.Empty;

    public ActionInfo CreateInfo { get; set; } = default!;


    public long ProblemId { get; set; }

    public Problem? Problem { get; set; }


    public long LanguageId { get; set; }

    public ProgrammingLanguage? Language { get; set; }


    public List<ProblemSolution>? Solutions { get; set; }
}