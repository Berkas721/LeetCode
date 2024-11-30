using LeetCode.Data.Contexts;
using LeetCode.Dto;
using LeetCode.Dto.Enums;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Dto.Problem;
using LeetCode.Dto.TestCase;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Problem.Query;

public sealed record GetProblemsQuery : IRequest<List<ProblemOutputFull>>;

public class GetProblemsQueryHandler : IRequestHandler<GetProblemsQuery, List<ProblemOutputFull>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetProblemsQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProblemOutputFull>> Handle(
        GetProblemsQuery request, 
        CancellationToken cancellationToken)
    {
        var problems = await _dbContext
            .Problems
            .Include(x => x.ImplementedProblems)
            .Include(x => x.TestCases)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var problemsDto = problems
            .Select(problem => new ProblemOutputFull
            {
                Id = 0,
                Name = problem.Name,
                Description = problem.Description,
                Difficulty = problem.Difficulty,
                Status = (int)problem.Status,
                CreatorId = problem.CreateInfo.AgentId,
                CreatedAt = problem.CreateInfo.Date,
                UpdaterId = problem.UpdateInfo?.AgentId,
                UpdatedAt = problem.UpdateInfo?.Date,
                OpenerId = problem.OpenInfo?.AgentId,
                OpenedAt = problem.OpenInfo?.Date,
                TestCases = problem.
                    TestCases
                    .Select(x => new TestCaseOutput
                    {
                        Id = x.Id,
                        Input = x.Input,
                        Output = x.Output,
                        CreateInfo = null,
                        ProblemId = x.ProblemId
                    })
                    .ToList(),
                ImplementedProblems = problem
                    .ImplementedProblems
                    .Select(x => new ImplementedProblemOutput
                    {
                        Id = x.Id,
                        ProblemId = x.ProblemId,
                        LanguageId = x.LanguageId,
                        ProblemCode = null,
                        DefaultSolutionCode = null,
                        WorkingSolutionCode = null,
                        CreateInfo = null
                    })
                    .ToList()
            })
            .ToList();

        return problemsDto;
    }
}