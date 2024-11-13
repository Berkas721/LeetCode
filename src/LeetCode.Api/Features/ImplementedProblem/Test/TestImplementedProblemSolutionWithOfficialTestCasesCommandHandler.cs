using LeetCode.Data.Contexts;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Exceptions;
using LeetCode.Features.SolutionTest.Test;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ImplementedProblem.Test;

public sealed record TestImplementedProblemSolutionWithOfficialTestCasesCommand(Guid Id)
    : IRequest<TestImplementationProblemResult>;

public class TestImplementedProblemSolutionWithOfficialTestCasesCommandHandler
    : IRequestHandler<TestImplementedProblemSolutionWithOfficialTestCasesCommand, TestImplementationProblemResult>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly ISender _sender;

    public TestImplementedProblemSolutionWithOfficialTestCasesCommandHandler(
        ApplicationDbContext dbContext, 
        ISender sender)
    {
        _dbContext = dbContext;
        _sender = sender;
    }

    public async Task<TestImplementationProblemResult> Handle(
        TestImplementedProblemSolutionWithOfficialTestCasesCommand request, 
        CancellationToken cancellationToken)
    {
        var implementedProblem = await _dbContext
            .ImplementedProblems
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        ResourceNotFoundException.ThrowIfNull(implementedProblem, "blabla");

        var testcases = await _dbContext
            .TestCases
            .Where(x => x.ProblemId == implementedProblem.ProblemId)
            .Select(x => new Dto.SolutionTest.TestCase
            {
                Id = x.Id,
                InputJson = x.Input,
                OutputJson = x.Output
            })
            .ToListAsync(cancellationToken);

        if (testcases.Count == 0)
            throw new Exception("blablabla");

        var testCommand = new CompileAndTestSolutionCodeByTestCasesRequest
        {
            ProblemCode = implementedProblem.ProblemCode,
            SolutionCode = implementedProblem.WorkingSolutionCode,
            LanguageId = implementedProblem.LanguageId,
            TestCases = testcases
        };

        var runTestCaseResults = await _sender.Send(testCommand, cancellationToken);

        return new TestImplementationProblemResult
        {
            ImplementationProblemId = implementedProblem.Id,
            RunTestCaseResults = runTestCaseResults
        };
    }
}