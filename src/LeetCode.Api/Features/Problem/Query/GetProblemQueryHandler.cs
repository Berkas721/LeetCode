using LeetCode.Data.Contexts;
using LeetCode.Dto.Problem;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;

namespace LeetCode.Features.Problem.Query;

public sealed record GetProblemQuery(long ProblemId) : IRequest<ProblemOutput>;

public sealed record GetProblemQueryHandler : IRequestHandler<GetProblemQuery, ProblemOutput>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetProblemQueryHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ProblemOutput> Handle(
        GetProblemQuery request, 
        CancellationToken cancellationToken)
    {
        var problem = await _dbContext
            .Problems
            .FindAsync(request.ProblemId);

        ResourceNotFoundException
            .ThrowIfNull(problem, $"не найдена задача с id: {request.ProblemId}");

        return _mapper.Map<ProblemOutput>(problem) with
        {
            CreatorId = problem.CreateInfo.AgentId,
            CreatedAt = problem.CreateInfo.Date,
            UpdaterId = problem.UpdateInfo?.AgentId,
            UpdatedAt = problem.UpdateInfo?.Date,
            OpenerId = problem.OpenInfo?.AgentId,
            OpenedAt = problem.OpenInfo?.Date,
            DeleterId = problem.DeleteInfo?.AgentId,
            DeletedAt = problem.DeleteInfo?.Date
        };
    }
}