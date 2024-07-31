using LeetCode.Data.Contexts;
using LeetCode.Data.Enums;
using LeetCode.Data.OwnedTypes;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Problem.Create;

public sealed record CreateProblemCommand : IRequest<long>
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public required ProblemDifficulty Difficulty { get; init; } 

    public required bool IsPremiumRequired { get; init; }

    public required List<long> TopicIds { get; init; }

    public required Guid CreatorId { get; init; }
}

public sealed record CreateProblemCommandHandler : IRequestHandler<CreateProblemCommand, long>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public CreateProblemCommandHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<long> Handle(
        CreateProblemCommand request, 
        CancellationToken cancellationToken)
    {
        var problem = _mapper.Map<Data.Entities.Problem>(request);

        problem.CreateInfo = new ActionInfo
        {
            Date = DateTime.UtcNow,
            AgentId = request.CreatorId
        };

        problem.Status = ProblemStatus.Draft;

        var topics = await _dbContext
            .ProblemTopics
            .Where(x => request.TopicIds.Contains(x.Id))
            .ToListAsync(cancellationToken);

        if (topics.Count != request.TopicIds.Count)
            throw new ResourceNotFoundException("некоторые topic не найдены");

        problem.Topics = topics;

        await _dbContext
            .Problems
            .AddAsync(problem, cancellationToken);

        await _dbContext
            .SaveChangesAsync(cancellationToken);

        return problem.Id;
    }
}