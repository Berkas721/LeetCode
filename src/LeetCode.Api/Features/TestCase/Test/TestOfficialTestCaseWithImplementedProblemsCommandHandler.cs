using LeetCode.Data.Contexts;
using LeetCode.Dto.TestCase;
using LeetCode.Exceptions;
using LeetCode.Features.SolutionTest.Test;
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
        
        var implementedProblems = await _dbContext
            .ImplementedProblems
            .Where(x => x.ProblemId == testcase.ProblemId)
            .ToListAsync(cancellationToken);

        if (implementedProblems.Count == 0)
            throw new Exception("blablabla");

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