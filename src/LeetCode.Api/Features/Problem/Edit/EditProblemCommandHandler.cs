using LeetCode.Data.Contexts;
using LeetCode.Data.Enums;
using LeetCode.Data.OwnedTypes;
using LeetCode.Dto.Enums;
using LeetCode.Exceptions;
using LeetCode.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Problem.Edit;

public sealed record EditProblemCommand : IRequest
{
    public required long ProblemId { get; init; }

    public required Guid UserId { get; init; }

    public required string? NewName { get; init; }

    public required string? NewDescription { get; init; }

    public required ProblemDifficulty? NewDifficulty { get; init; } 

    public required List<long>? NewTopicIds { get; init; }
}

public sealed record EditProblemCommandHandler : IRequestHandler<EditProblemCommand>
{
    private readonly ApplicationDbContext _dbContext;

    public EditProblemCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(
        EditProblemCommand request, 
        CancellationToken cancellationToken)
    {
        var problemId = request.ProblemId;
        var userId = request.UserId;
        
        var problem = await _dbContext
            .Problems
            .Include(x => x.Topics)
            .FirstAsync(problemId, cancellationToken);

        problem.EnsureAuthor(userId);

        if (problem.Status != ProblemStatus.Draft)
            throw new ForbiddenException($"задачу с id {problemId} нельзя изменять, так как она находится не в состоянии черновика");

        if (request.NewName is not null)
            problem.Name = request.NewName;

        if (request.NewDescription is not null)
            problem.Description = request.NewDescription;

        if (request.NewDifficulty is not null)
            problem.Difficulty = (ProblemDifficulty)request.NewDifficulty;

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

        problem.UpdateInfo = new ActionInfo(request.UserId);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}