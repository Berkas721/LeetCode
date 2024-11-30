using LeetCode.Data.Contexts;
using LeetCode.Dto.Enums;
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
            .Include(x => x.ImplementedProblems)
            .Include(x => x.TestCases)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var problemsDto = problems
            .Select(x => new ProblemOutput
            {
                Name = x.Name,
                Description = x.Description,
                Difficulty = x.Difficulty,
                Status = (int)x.Status,
                CreatorId = x.CreateInfo.AgentId,
                CreatedAt = x.CreateInfo.Date,
                UpdaterId = x.UpdateInfo?.AgentId,
                UpdatedAt = x.UpdateInfo?.Date,
                OpenerId = x.OpenInfo?.AgentId,
                OpenedAt = x.OpenInfo?.Date,
            })
            .ToList();

        return problemsDto;
    }
}