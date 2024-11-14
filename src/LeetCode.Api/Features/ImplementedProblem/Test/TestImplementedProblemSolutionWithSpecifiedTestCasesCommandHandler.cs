using LeetCode.Data.Contexts;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Dto.SolutionTest;
using LeetCode.Exceptions;
using LeetCode.Extensions;
using LeetCode.Features.SolutionTest.Test;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ImplementedProblem.Test;

public sealed record TestImplementedProblemSolutionWithDraftTestCasesCommand 
    : IRequest<TestImplementationProblemResult>
{
    public required Guid ImplementedProblemId { get; init; }
    public required IReadOnlyList<Dto.SolutionTest.TestCase> TestCases { get; init; }
}

public class TestImplementedProblemSolutionWithSpecifiedTestCasesCommandHandler
    : IRequestHandler<TestImplementedProblemSolutionWithDraftTestCasesCommand, TestImplementationProblemResult>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly ISender _sender;

    public TestImplementedProblemSolutionWithSpecifiedTestCasesCommandHandler(
        ApplicationDbContext dbContext, 
        ISender sender)
    {
        _dbContext = dbContext;
        _sender = sender;
    }

    public async Task<TestImplementationProblemResult> Handle(
        TestImplementedProblemSolutionWithDraftTestCasesCommand request, 
        CancellationToken cancellationToken)
    {
        var implementedProblem = await _dbContext
            .ImplementedProblems
            .FirstAsync(request.ImplementedProblemId, cancellationToken);

        ResourceNotFoundException.ThrowIfNull(implementedProblem, "blabla");

        var testCommand = new CompileAndTestSolutionCodeByTestCasesRequest
        {
            ProblemCode = implementedProblem.ProblemCode,
            SolutionCode = implementedProblem.WorkingSolutionCode,
            LanguageId = implementedProblem.LanguageId,
            TestCases = request.TestCases
        };

        var runTestCaseResults = await _sender.Send(testCommand, cancellationToken);

        return new TestImplementationProblemResult
        {
            ImplementationProblemId = implementedProblem.Id,
            RunTestCaseResults = runTestCaseResults
        };
    }
}