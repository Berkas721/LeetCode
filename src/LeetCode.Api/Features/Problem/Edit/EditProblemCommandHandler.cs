using LeetCode.Data.Contexts;
using LeetCode.Data.Enums;
using LeetCode.Data.OwnedTypes;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Problem.Edit;

public sealed record EditProblemCommand : IRequest
{
    public required long Id { get; init; }

    public required Guid UpdaterId { get; init; }

    public required string? NewName { get; init; }

    public required string? NewDescription { get; init; }

    public required ProblemDifficulty? NewDifficulty { get; init; } 

    public required bool? IsPremiumRequired { get; init; }

    public required List<long>? NewTopicIds { get; init; }
}

public sealed record EditProblemCommandHandler : IRequestHandler<EditProblemCommand>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public EditProblemCommandHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Handle(
        EditProblemCommand request, 
        CancellationToken cancellationToken)
    {
        var problem = await _dbContext
            .Problems
            .Include(x => x.Topics)
            .FirstAsync(
                x => x.Id == request.Id, 
                cancellationToken);
        
        ResourceNotFoundException
            .ThrowIfNull(problem, $"не найдена задача с id: {request.Id}");

        if (problem.Status != ProblemStatus.Draft)
            throw new Exception($"задача с id {request.Id} не находится в состоянии черновика");

        if (request.NewName is not null)
            problem.Name = request.NewName;

        if (request.NewDescription is not null)
            problem.Description = request.NewDescription;

        if (request.NewDifficulty is not null)
            problem.Difficulty = (ProblemDifficulty)request.NewDifficulty;

        if (request.IsPremiumRequired is not null)
            problem.IsPremiumRequired = (bool)request.IsPremiumRequired;

        if (request.NewTopicIds is not null)
        {
            // TODO: подумать как убрать дубляж кода
            var topics = await _dbContext
                .ProblemTopics
                .Where(x => request.NewTopicIds.Contains(x.Id))
                .ToListAsync(cancellationToken);

            if (topics.Count != request.NewTopicIds.Count)
                throw new ResourceNotFoundException("некоторые topic не найдены");

            problem.Topics = topics;
        }

        problem.UpdateInfo = new ActionInfo
        {
            Date = DateTime.UtcNow,
            AgentId = request.UpdaterId
        };

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}