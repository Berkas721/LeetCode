using LeetCode.Data.Contexts;
using LeetCode.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.TestCase.Delete;

public sealed record DeleteTestCaseCommand(long Id) : IRequest;

public class DeleteTestCaseCommandHandler : IRequestHandler<DeleteTestCaseCommand>
{
    private readonly ApplicationDbContext _dbContext;

    public DeleteTestCaseCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(
        DeleteTestCaseCommand request, 
        CancellationToken cancellationToken)
    {
        var testCase = await _dbContext
            .TestCases
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        ResourceNotFoundException.ThrowIfNull(testCase, "blablbalba");
        await _dbContext.ThrowExceptionIfProblemHasOpenStatus(testCase.ProblemId);

        _dbContext.TestCases.Remove(testCase);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}