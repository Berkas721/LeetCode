using LeetCode.Data.Contexts;
using LeetCode.Dto.Problem;
using LeetCode.Exceptions;
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
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        ResourceNotFoundException.ThrowIfNull(problem, "blablabla");

        if(problem.ImplementedProblems.Count < 1)
            throw new Exception("нельзя перевести статус");

        if(problem.TestCases.Count < 1)
            throw new Exception("нельзя перевести статус");

        var implementedProblemsIds = problem
            .ImplementedProblems
            .Select(x => x.Id)
            .ToList();

        var testResult = new TestProblemResult
        {
            ProblemId = problem.Id
        };

        foreach (var implementedProblemsId in implementedProblemsIds)
        {
            var runImplementedProblemResult = await _sender.Send(
                new TestImplementedProblemSolutionWithOfficialTestCasesCommand(implementedProblemsId), 
                cancellationToken);

            testResult.TestImplementationProblemResults.Add(runImplementedProblemResult);
        }

        return testResult;
    }
}