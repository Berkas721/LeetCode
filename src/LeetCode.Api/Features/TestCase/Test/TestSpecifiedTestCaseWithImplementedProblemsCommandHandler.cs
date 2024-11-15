using LeetCode.Data.Contexts;
using LeetCode.Dto.TestCase;
using LeetCode.Exceptions;
using LeetCode.Features.Solution.Edit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.TestCase.Test;

public sealed record TestSpecifiedTestCaseWithImplementedProblemsCommand(long ProblemId, Dto.TestCase.TestCaseData TestCaseData) 
    : IRequest<IReadOnlyList<TestTestCaseResult>>;

public class TestSpecifiedTestCaseWithImplementedProblemsCommandHandler 
    : IRequestHandler<TestSpecifiedTestCaseWithImplementedProblemsCommand, IReadOnlyList<TestTestCaseResult>>
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
        TestSpecifiedTestCaseWithImplementedProblemsCommand request, 
        CancellationToken cancellationToken)
    {
        var testCase = request.TestCaseData;
        var problemId = request.ProblemId;

        var problemExist = await _dbContext
            .Problems
            .Where(x => x.Id == problemId)
            .AnyAsync(cancellationToken);

        if (!problemExist)
            throw new ResourceNotFoundException($"задача с id {problemId} не существует");

        var implementedProblems = await _dbContext
            .ImplementedProblems
            .Where(x => x.ProblemId == problemId)
            .ToListAsync(cancellationToken);

        if (implementedProblems.Count == 0)
            throw new Exception($"невозможно провести тест, так как не сущестует реализаций задачи с id {problemId}");

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