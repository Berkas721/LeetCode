using LeetCode.Data.Contexts;
using LeetCode.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ImplementedProblem.Delete;

public sealed record DeleteImplementedProblemCommand(Guid Id) : IRequest;

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
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        ResourceNotFoundException.ThrowIfNull(implementedProblem, "blablabal");

        _dbContext.ImplementedProblems.Remove(implementedProblem);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}