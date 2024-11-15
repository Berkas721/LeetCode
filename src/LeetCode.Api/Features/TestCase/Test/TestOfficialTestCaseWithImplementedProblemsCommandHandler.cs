using LeetCode.Data.Contexts;
using LeetCode.Dto.TestCase;
using LeetCode.Extensions;
using LeetCode.Features.Solution.Edit;
using LeetCode.Features.Solution.Test;
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
        var testCaseId = request.Id;
        
        var testcase = await _dbContext
            .TestCases
            .FindByIdAsync(testCaseId, cancellationToken);

        var testcaseDto = new Dto.TestCase.TestCaseData
        {
            Id = testCaseId,
            Input = testcase.Input,
            Output = testcase.Output
        };

        var implementedProblems = await _dbContext
            .ImplementedProblems
            .Where(x => x.ProblemId == testcase.ProblemId)
            .ToListAsync(cancellationToken);

        if (implementedProblems.Count == 0)
            throw new Exception($"Невозможно провести тест для testcase, так как нет ни одной реализации задачи с id {testcase.ProblemId}");

        List<TestTestCaseResult> testReport = [];

        // TODO: лучше наверно все это явно прописать без ISender
        foreach (var implementedProblem in implementedProblems)
        {
            var testCommand = new CompileAndTestSolutionCodeByTestCasesRequest
            {
                ProblemCode = implementedProblem.ProblemCode,
                SolutionCode = implementedProblem.WorkingSolutionCode,
                LanguageId = implementedProblem.LanguageId,
                TestCases = [testcaseDto]
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