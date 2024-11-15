using LeetCode.Data.Contexts;
using LeetCode.Data.Enums;
using LeetCode.Dto.TestCase;
using LeetCode.Exceptions;
using LeetCode.Extensions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.TestCase.Edit;

public sealed record EditTestCaseCommand : IRequest<TestCaseOutput>
{
    public required long TestCaseId { get; init; }

    public required Guid UserId { get; init; }
    
    public required string? NewInput { get; init; }

    public required string? NewOutput { get; init; }
}

public class EditTestCaseCommandHandler :
    IRequestHandler<EditTestCaseCommand, TestCaseOutput>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public EditTestCaseCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TestCaseOutput> Handle(
        EditTestCaseCommand request, 
        CancellationToken cancellationToken)
    {
        var testcaseId = request.TestCaseId;
        var userId = request.UserId;

        var testCase = await _dbContext
            .TestCases
            .FindByIdAsync(testcaseId, cancellationToken);

        testCase.EnsureAuthor(userId);
        await _dbContext.EnsureProblemInStatusAsync(testCase.ProblemId, ProblemStatus.Draft);

        // TODO: хз ставить ли проверку, что работает со всеми Implemented problems если они есть

        if (request.NewInput is not null)
            testCase.Input = request.NewInput;

        if (request.NewOutput is not null)
            testCase.Output = request.NewOutput;

        // TODO: request.UpdateInfo = new ActionInfo(userId)
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TestCaseOutput>(testCase);
    }
}