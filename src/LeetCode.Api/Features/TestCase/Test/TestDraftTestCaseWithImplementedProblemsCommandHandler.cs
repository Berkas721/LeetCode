using LeetCode.Data.Contexts;
using LeetCode.Dto.TestCase;
using LeetCode.Features.ImplementedProblem.Test;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.TestCase.Test;

public sealed record TestDraftTestCaseWithImplementedProblemsCommand(long ProblemId, Dto.SolutionTest.TestCase TestCase) 
    : IRequest<IReadOnlyList<TestTestCaseResult>>;

public class TestDraftTestCaseWithImplementedProblemsCommandHandler 
    : IRequestHandler<TestDraftTestCaseWithImplementedProblemsCommand, IReadOnlyList<TestTestCaseResult>>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly ISender _sender;

    public TestDraftTestCaseWithImplementedProblemsCommandHandler(
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

        var implementedProblemIds = await _dbContext
            .ImplementedProblems
            .Where(x => x.ProblemId == request.ProblemId)
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
                TestCases = [testCase]
            };

            var testResults = await _sender.Send(testCommand, cancellationToken);
            var testResult = testResults.First();

            testReport.Add(new TestTestCaseResult
            {
                ImplementedProblemId = implementedProblemId,
                TestCase = testCase,
                ResultStatus = testResult.ResultStatus,
                Date = testResult.Date,
                UsedTime = testResult.UsedTime,
                UsedMemory = testResult.UsedMemory,
                ErrorMessage = testResult.ErrorMessage,
                IncorrectAnswer = testResult.IncorrectAnswer
            });
        }

        return testReport;
    }
}