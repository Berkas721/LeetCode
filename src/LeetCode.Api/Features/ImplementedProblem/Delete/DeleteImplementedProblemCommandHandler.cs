using LeetCode.Data.Contexts;
using LeetCode.Extensions;
using MediatR;

namespace LeetCode.Features.ImplementedProblem.Delete;

public sealed record DeleteImplementedProblemCommand : IRequest
{
    public required Guid ImplementedProblemId { get; init; }
    public required Guid UserId { get; init; }
}

public class DeleteImplementedProblemCommandHandler 
    : IRequestHandler<DeleteImplementedProblemCommand>
{
    private readonly ApplicationDbContext _dbContext;

    public DeleteImplementedProblemCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(
        DeleteImplementedProblemCommand request, 
        CancellationToken cancellationToken)
    {
        var implementedProblem = await _dbContext
            .ImplementedProblems
            .FirstAsync(request.ImplementedProblemId, cancellationToken);

        implementedProblem.EnsureAuthor(request.UserId);

        _dbContext.ImplementedProblems.Remove(implementedProblem);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}