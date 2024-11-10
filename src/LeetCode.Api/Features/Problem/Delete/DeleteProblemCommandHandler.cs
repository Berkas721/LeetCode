using LeetCode.Data.Contexts;
using LeetCode.Data.Enums;
using LeetCode.Data.OwnedTypes;
using LeetCode.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Problem.Delete;

public sealed record DeleteProblemCommand(long ProblemId) : IRequest;

public sealed record DeleteProblemCommandHandler : IRequestHandler<DeleteProblemCommand>
{
    private readonly ApplicationDbContext _dbContext;

    public DeleteProblemCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(
        DeleteProblemCommand request, 
        CancellationToken cancellationToken)
    { 
        var problem = await _dbContext
            .Problems
            .Where(x => x.Id == request.ProblemId)
            .FirstOrDefaultAsync(cancellationToken);

        ResourceNotFoundException.ThrowIfNull(problem, "blablabla");

        if (problem.DeleteInfo is not null)
            throw new InvalidOperationException($"Задача с id: {problem.Id} уже удалена");

        problem.DeleteInfo = new ActionInfo
        {
            Date = DateTime.UtcNow,
            // TODO: дсотать из авторизированного пользователя
            AgentId = Guid.NewGuid()
        };

        await _dbContext
            .SaveChangesAsync(cancellationToken);
    }
}