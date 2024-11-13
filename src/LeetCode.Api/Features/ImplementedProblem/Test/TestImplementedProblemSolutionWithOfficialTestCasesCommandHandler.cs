using LeetCode.Data.Contexts;
using LeetCode.Dto.SolutionTest;
using LeetCode.Exceptions;
using LeetCode.Features.SolutionTest.Test;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ImplementedProblem.Test;

public sealed record TestImplementedProblemSolutionWithOfficialTestCasesCommand(Guid Id)
    : IRequest<IReadOnlyList<SolutionTestResult>>;

public class TestImplementedProblemSolutionWithOfficialTestCasesCommandHandler
    : IRequestHandler<TestImplementedProblemSolutionWithOfficialTestCasesCommand, IReadOnlyList<SolutionTestResult>>
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

    public async Task<IReadOnlyList<SolutionTestResult>> Handle(
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

        var testResults = await _sender.Send(testCommand, cancellationToken);

        return testResults;
    }
}