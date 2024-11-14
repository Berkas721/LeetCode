using LeetCode.Data.Contexts;
using LeetCode.Dto.TestCase;
using LeetCode.Exceptions;
using LeetCode.Features.ImplementedProblem.Test;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.TestCase.Test;

public sealed record TestOfficialTestCaseWithImplementedProblemsCommand(long Id) 
    : IRequest<IReadOnlyList<TestTestCaseResult>>;

public class TestOfficialTestCaseWithImplementedProblemsCommandHandler 
    : IRequestHandler<TestOfficialTestCaseWithImplementedProblemsCommand, IReadOnlyList<TestTestCaseResult>>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly ISender _sender;

    public TestOfficialTestCaseWithImplementedProblemsCommandHandler(
        ApplicationDbContext dbContext, 
        ISender sender)
    {
        _dbContext = dbContext;
        _sender = sender;
    }

    public async Task<IReadOnlyList<TestTestCaseResult>> Handle(
        TestOfficialTestCaseWithImplementedProblemsCommand request, 
        CancellationToken cancellationToken)
    {
        var testcase = await _dbContext
            .TestCases
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        ResourceNotFoundException.ThrowIfNull(testcase, "blablabla");
        
        var testcaseDto = new Dto.SolutionTest.TestCase
        {
            InputJson = testcase.Input,
            OutputJson = testcase.Output
        };
        
        var implementedProblemIds = await _dbContext
            .ImplementedProblems
            .Where(x => x.ProblemId == testcase.ProblemId)
            .Select(x => x.Id)
            .ToListAsync(cancellationToken);

        if (implementedProblemIds.Count == 0)
            throw new Exception("blablabla");

        List<TestTestCaseResult> testReport = [];

        // TODO: лучше наверно все это явно прописать без ISender
        foreach (var implementedProblemId in implementedProblemIds)
        {
            var testCommand = new TestImplementedProblemSolutionWithDraftTestCasesCommand
            {
                ImplementedProblemId = implementedProblemId,
                TestCases = [testcaseDto]
            };

            var testResults = await _sender.Send(testCommand, cancellationToken);
            var testResult = testResults.RunTestCaseResults.First();

            testReport.Add(new TestTestCaseResult
            {
                ImplementedProblemId = implementedProblemId,
                RunTestCaseResult = testResult
            });
        }

        return testReport;
    }
}