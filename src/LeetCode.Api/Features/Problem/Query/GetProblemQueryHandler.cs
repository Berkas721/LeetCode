using LeetCode.Data.Contexts;
using LeetCode.Dto.Problem;
using LeetCode.Extensions;
using MediatR;

namespace LeetCode.Features.Problem.Query;

public sealed record GetProblemQuery(long ProblemId) : IRequest<ProblemOutput>;

public sealed record GetProblemQueryHandler : IRequestHandler<GetProblemQuery, ProblemOutput>
{
    private readonly ApplicationDbContext _dbContext;
    public GetProblemQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProblemOutput> Handle(
        GetProblemQuery request, 
        CancellationToken cancellationToken)
    {
        var problem = await _dbContext
            .Problems
            .FirstAsync(request.ProblemId, cancellationToken);

        return new ProblemOutput
        {
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
            DeleterId = problem.DeleteInfo?.AgentId,
            DeletedAt = problem.DeleteInfo?.Date,
        };
    }
}