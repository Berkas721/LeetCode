using LeetCode.Data.Contexts;
using LeetCode.Dto.TestCase;
using LeetCode.Features.SolutionTest.Test;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.TestCase.Test;

public sealed record TestDraftTestCaseWithImplementedProblemsCommand(long ProblemId, Dto.SolutionTest.TestCase TestCase) 
    : IRequest<IReadOnlyList<TestTestCaseResult>>;

public class TestSpecifiedTestCaseWithImplementedProblemsCommandHandler 
    : IRequestHandler<TestDraftTestCaseWithImplementedProblemsCommand, IReadOnlyList<TestTestCaseResult>>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly ISender _sender;

    public TestSpecifiedTestCaseWithImplementedProblemsCommandHandler(
        ApplicationDbContext dbContext, 
        ISender sender)
    {
        _dbContext = dbContext;
        _sender = sender;
    }

    public async Task<IReadOnlyList<TestTestCaseResult>> Handle(
        TestDraftTestCaseWithImplementedProblemsCommand request, 
        CancellationToken cancellationToken)
    {
        var testCase = request.TestCase;

        var problemExist = await _dbContext
            .Problems
            .Where(x => x.Id == request.ProblemId)
            .AnyAsync(cancellationToken);

        if (!problemExist)
            throw new Exception("blablabla");

        var implementedProblems = await _dbContext
            .ImplementedProblems
            .Where(x => x.ProblemId == request.ProblemId)
            .ToListAsync(cancellationToken);

        if (implementedProblems.Count == 0)
            throw new Exception("blablabla");

        List<TestTestCaseResult> testReport = [];

        foreach (var implementedProblem in implementedProblems)
        {
            var testCommand = new CompileAndTestSolutionCodeByTestCasesRequest
            {
                ProblemCode = implementedProblem.ProblemCode,
                SolutionCode = implementedProblem.WorkingSolutionCode,
                LanguageId = implementedProblem.LanguageId,
                TestCases = [testCase]
            };

            var testResults = await _sender.Send(testCommand, cancellationToken);

            testReport.Add(new TestTestCaseResult
            {
                ImplementedProblemId = implementedProblem.Id,
                RunTestCaseResult = testResults.First()
            });
        }

        return testReport;
    }
}