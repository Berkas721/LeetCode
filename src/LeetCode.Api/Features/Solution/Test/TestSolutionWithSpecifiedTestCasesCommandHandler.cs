using LeetCode.Data.Contexts;
using LeetCode.Dto.Solution;
using LeetCode.Dto.TestCase;
using LeetCode.Extensions;
using LeetCode.Features.Solution.Edit;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Solution.Test;

public sealed record TestSolutionWithSpecifiedTestCasesCommand(long SolutionId, List<TestCaseData> TestCases)
    : IRequest<TestSolutionResult>;

public class TestSolutionWithSpecifiedTestCasesCommandHandler 
    : IRequestHandler<TestSolutionWithSpecifiedTestCasesCommand, TestSolutionResult>
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    private readonly IMediator _mediator;

    public TestSolutionWithSpecifiedTestCasesCommandHandler(
        ApplicationDbContext context, 
        IMapper mapper, 
        IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<TestSolutionResult> Handle(
        TestSolutionWithSpecifiedTestCasesCommand request, 
        CancellationToken cancellationToken)
    {
        var solutionId = request.SolutionId;
        var testCases = request.TestCases;

        var solution = await _context
            .ProblemSolutions
            .Include(x => x.ImplementedProblem)
            .FirstAsync(solutionId, cancellationToken);

        var runTestCasesCommand = new CompileAndTestSolutionCodeByTestCasesRequest
        {
            ProblemCode = solution.ImplementedProblem.ProblemCode,
            SolutionCode = solution.Code,
            LanguageId = solution.ImplementedProblem.LanguageId,
            TestCases = testCases
        };

        var runTestCaseResults = await _mediator.Send(runTestCasesCommand, cancellationToken);

        return new TestSolutionResult
        {
            SolutionId = solutionId,
            RunTestCaseResults = runTestCaseResults
        };
    }
}