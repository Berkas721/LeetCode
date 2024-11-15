using LeetCode.Data.Contexts;
using LeetCode.Data.Enums;
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
        var problemId = request.ProblemId;

        var testCase = new Data.Entities.TestCase
        {
            Input = request.Input,
            Output = request.Output,
            CreateInfo = new ActionInfo(request.CreatorId),
            ProblemId = problemId
        };

        await _dbContext.EnsureProblemInStatusAsync(request.ProblemId, ProblemStatus.Draft);

        var duplicateExists = await _dbContext
            .TestCases
            .Where(x => x.ProblemId == testCase.ProblemId)
            .Where(x => x.Input == testCase.Input)
            .AnyAsync(cancellationToken);

        if (duplicateExists)
            throw new Exception($"Для задачи с id {problemId} уже существует testcase с таким же входным значением");

        // TODO: хз ставить ли проверку, что все Implemented problems должны проходить это testcase

        _dbContext.TestCases.Add(testCase);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return testCase.Id;
    }
}