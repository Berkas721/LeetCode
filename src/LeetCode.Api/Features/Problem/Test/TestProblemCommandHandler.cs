using LeetCode.Data.Contexts;
using LeetCode.Dto.Problem;
using LeetCode.Extensions;
using LeetCode.Features.ImplementedProblem.Test;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Problem.Test;

public sealed record TestProblemCommand(long Id) 
    : IRequest<TestProblemResult>;

public class TestProblemCommandHandler 
    : IRequestHandler<TestProblemCommand, TestProblemResult>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly ISender _sender;

    public TestProblemCommandHandler(
        ApplicationDbContext dbContext, 
        ISender sender)
    {
        _dbContext = dbContext;
        _sender = sender;
    }

    public async Task<TestProblemResult> Handle(
        TestProblemCommand request, 
        CancellationToken cancellationToken)
    {
        var problem = await _dbContext
            .Problems
            .Include(x => x.ImplementedProblems)
            .Include(x => x.TestCases)
            .FirstAsync(request.Id, cancellationToken);

        if(problem.ImplementedProblems.Count < 1)
            throw new Exception("невозможно провести тест, нет ни одной реализации задачи");

        if(problem.TestCases.Count < 1)
            throw new Exception("невозможно провести тест, нет ни одного тестового значения");

        var implementedProblemsIds = problem
            .ImplementedProblems
            .Select(x => x.Id)
            .ToList();

        var testProblemResult = new TestProblemResult
        {
            ProblemId = problem.Id
        };

        foreach (var implementedProblemsId in implementedProblemsIds)
        {
            var testImplementedProblemResult = await _sender.Send(
                new TestImplementedProblemSolutionWithOfficialTestCasesCommand(implementedProblemsId), 
                cancellationToken);

            testProblemResult.TestImplementationProblemResults.Add(testImplementedProblemResult);
        }

        return testProblemResult;
    }
}