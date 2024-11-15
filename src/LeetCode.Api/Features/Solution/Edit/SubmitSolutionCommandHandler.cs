using LeetCode.Data.Contexts;
using LeetCode.Data.Entities;
using LeetCode.Dto.Enums;
using LeetCode.Dto.Solution;
using LeetCode.Dto.TestCase;
using LeetCode.Exceptions;
using LeetCode.Extensions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Solution.Edit;

public sealed record SubmitSolutionCommand(long SolutionId, Guid UserId)
    : IRequest<SubmitSolutionResult>;

public class SubmitSolutionCommandHandler 
    : IRequestHandler<SubmitSolutionCommand, SubmitSolutionResult>
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    private readonly IMediator _mediator;

    public SubmitSolutionCommandHandler(
        ApplicationDbContext context, 
        IMapper mapper, 
        IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<SubmitSolutionResult> Handle(
        SubmitSolutionCommand request, 
        CancellationToken cancellationToken)
    {
        var solutionId = request.SolutionId;

        var solution = await _context
            .ProblemSolutions
            .Include(x => x.ImplementedProblem)
            .FirstAsync(solutionId, cancellationToken);

        solution.EnsureAuthor(request.UserId);

        if (solution.Status != ProblemSolutionStatus.Draft)
            throw new ForbiddenException($"Нельзя сдать задачу c {solutionId}, так как она не находится в состоянии черновика");

        var testCases = await _context
            .TestCases
            .Where(x => x.ProblemId == solution.ImplementedProblem.ProblemId)
            .ToListAsync(cancellationToken);

        var runTestCasesCommand = new CompileAndTestSolutionCodeByTestCasesRequest
        {
            ProblemCode = solution.ImplementedProblem.ProblemCode,
            SolutionCode = solution.Code,
            LanguageId = solution.ImplementedProblem.LanguageId,
            TestCases = _mapper.Map<List<TestCaseData>>(testCases)
        };

        var runTestCaseResults = await _mediator.Send(runTestCasesCommand, cancellationToken);

        var isTestPassed = runTestCaseResults.All(x => x.ResultStatus == SolutionTestResultStatus.Passed);

        solution.SubmittedAt = DateTime.UtcNow;
        solution.Status = isTestPassed
            ? ProblemSolutionStatus.Accepted
            : ProblemSolutionStatus.UnAccepted;

        var solutionTests = runTestCaseResults.Select(x => new SolutionTest
        {
            Date = x.Date,
            ResultStatus = x.ResultStatus,
            UsedTime = x.UsedTime,
            UsedMemory = x.UsedMemory,
            ErrorMessage = x.ErrorMessage,
            IncorrectAnswer = x.IncorrectAnswer,
            SolutionId = solutionId,
            TestCaseId = x.TestCaseData.Id.Value
        });

        await _context.SolutionTests.AddRangeAsync(solutionTests, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        // можно перенести логику определения полей в конструктор SubmitSolutionResult(solutionId, runTestCaseResults)
        var testResult = new SubmitSolutionResult
        {
            SolutionId = solutionId,
            IsPassed = isTestPassed,

            TotalUsedTime = isTestPassed 
                ? runTestCaseResults.Sum(x => x.UsedTime) 
                : null,

            TotalUsedMemory = isTestPassed 
                ? runTestCaseResults.Sum(x => x.UsedMemory) 
                : null,

            TestCaseResultWithError = runTestCaseResults
                .FirstOrDefault(x => x.ResultStatus == SolutionTestResultStatus.FailedWithError),

            TestCaseResultWithWrongAnswer = runTestCaseResults
                .FirstOrDefault(x => x.ResultStatus == SolutionTestResultStatus.FailedWithIncorrectAnswer)
        };

        return testResult;
    }
}