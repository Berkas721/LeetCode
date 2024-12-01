using LeetCode.Data.Contexts;
using LeetCode.Data.Enums;
using LeetCode.Dto.Problem;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Problem.Query;

public sealed record GetProblemsQuery : IRequest<List<ProblemOutput>>;

public class GetProblemsQueryHandler : IRequestHandler<GetProblemsQuery, List<ProblemOutput>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetProblemsQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProblemOutput>> Handle(
        GetProblemsQuery request, 
        CancellationToken cancellationToken)
    {
        var problems = await _dbContext
            .Problems
            .Where(x => x.Status == ProblemStatus.Open)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var problemsDto = problems
            .Select(problem => new ProblemOutput
            {
                Id = problem.Id,
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
            })
            .ToList();

        return problemsDto;
    }
}