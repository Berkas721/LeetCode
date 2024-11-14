using LeetCode.Data.Contexts;
using LeetCode.Extensions;
using MediatR;

namespace LeetCode.Features.Problem.Delete;

public sealed record DeleteProblemCommand(long ProblemId, Guid UserId) : IRequest;

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
        var problemId = request.ProblemId;
        var userId = request.UserId;
        
        var problem = await _dbContext
            .Problems
            .FirstAsync(problemId, cancellationToken);

        problem.EnsureAuthor(userId);

        // TODO: щаменить на problem.DeleteInfo = new ActionInfo(userId);
        _dbContext.Problems.Remove(problem);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}