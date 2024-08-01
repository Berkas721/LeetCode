using LeetCode.Data.Contexts;
using LeetCode.Data.Enums;
using MediatR;

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
            .FindAsync(request.ProblemId);

        problem.Status = ProblemStatus.Deleted;

        await _dbContext
            .SaveChangesAsync(cancellationToken);
    }
}