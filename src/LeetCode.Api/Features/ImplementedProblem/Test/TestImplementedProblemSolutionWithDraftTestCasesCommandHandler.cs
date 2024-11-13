using LeetCode.Data.Contexts;
using LeetCode.Dto.SolutionTest;
using LeetCode.Exceptions;
using LeetCode.Features.SolutionTest.Test;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ImplementedProblem.Test;

public sealed record TestImplementedProblemSolutionWithDraftTestCasesCommand 
    : IRequest<IReadOnlyList<SolutionTestResult>>
{
    public required Guid ImplementedProblemId { get; init; }
    public required IReadOnlyList<Dto.SolutionTest.TestCase> TestCases { get; init; }
}

public class TestImplementedProblemSolutionWithDraftTestCasesCommandHandler
    : IRequestHandler<TestImplementedProblemSolutionWithDraftTestCasesCommand, IReadOnlyList<SolutionTestResult>>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly ISender _sender;

    public TestImplementedProblemSolutionWithDraftTestCasesCommandHandler(
        ApplicationDbContext dbContext, 
        ISender sender)
    {
        _dbContext = dbContext;
        _sender = sender;
    }

    public async Task<IReadOnlyList<SolutionTestResult>> Handle(
        TestImplementedProblemSolutionWithDraftTestCasesCommand request, 
        CancellationToken cancellationToken)
    {
        var implementedProblem = await _dbContext
            .ImplementedProblems
            .Where(x => x.Id == request.ImplementedProblemId)
            .FirstOrDefaultAsync(cancellationToken);

        ResourceNotFoundException.ThrowIfNull(implementedProblem, "blabla");

        var testCommand = new CompileAndTestSolutionCodeByTestCasesRequest
        {
            ProblemCode = implementedProblem.ProblemCode,
            SolutionCode = implementedProblem.WorkingSolutionCode,
            LanguageId = implementedProblem.LanguageId,
            TestCases = request.TestCases
        };

        var testResults = await _sender.Send(testCommand, cancellationToken);

        return testResults;
    }
}