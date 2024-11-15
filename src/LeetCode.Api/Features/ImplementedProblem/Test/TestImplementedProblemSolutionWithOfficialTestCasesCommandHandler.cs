using LeetCode.Data.Contexts;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Extensions;
using LeetCode.Features.Solution.Edit;
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
            .FirstAsync(request.Id, cancellationToken);

        var testcases = await _dbContext
            .TestCases
            .Where(x => x.ProblemId == implementedProblem.ProblemId)
            .Select(x => new Dto.TestCase.TestCaseData
            {
                Id = x.Id,
                Input = x.Input,
                Output = x.Output
            })
            .ToListAsync(cancellationToken);

        if (testcases.Count == 0)
            throw new Exception("Для тестирования кода нужен минимум 1 testcase");

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