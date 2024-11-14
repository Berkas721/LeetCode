using LeetCode.Data.Contexts;
using LeetCode.Data.OwnedTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.TestCase.Create;

public sealed record CreateTestCaseCommand : IRequest<long>
{
    public required string Input { get; init; }

    public required string Output { get; init; }

    public required long ProblemId { get; init; }

    public required Guid CreatorId { get; init; }
}

public class CreateTestCaseCommandHandler : IRequestHandler<CreateTestCaseCommand, long>
{
    private readonly ApplicationDbContext _dbContext;

    public CreateTestCaseCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> Handle(
        CreateTestCaseCommand request, 
        CancellationToken cancellationToken)
    {
        var testCase = new Data.Entities.TestCase
        {
            Input = request.Input,
            Output = request.Output,
            CreateInfo = new ActionInfo
            {
                Date = DateTime.UtcNow,
                AgentId = request.CreatorId
            },
            ProblemId = request.ProblemId
        };

        await _dbContext.EnsureProblemInDraftStatusAsync(request.ProblemId);

        var duplicate = await _dbContext
            .TestCases
            .Where(x => x.ProblemId == testCase.ProblemId && x.Input == testCase.Input)
            .AnyAsync(cancellationToken);

        if (duplicate)
            throw new Exception("blablabal");

        // TODO: проверка что работает со всеми Implemented problems если они есть

        _dbContext.TestCases.Add(testCase);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return testCase.Id;
    }
}