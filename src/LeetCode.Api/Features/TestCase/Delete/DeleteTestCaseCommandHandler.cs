﻿using LeetCode.Data.Contexts;
using LeetCode.Exceptions;
using LeetCode.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.TestCase.Delete;

public sealed record DeleteTestCaseCommand(long TestCaseId, Guid UserId) : IRequest;

public class DeleteTestCaseCommandHandler : IRequestHandler<DeleteTestCaseCommand>
{
    private readonly ApplicationDbContext _dbContext;

    public DeleteTestCaseCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(
        DeleteTestCaseCommand request, 
        CancellationToken cancellationToken)
    {
        var testcaseId = request.TestCaseId;
        
        var testCase = await _dbContext
            .TestCases
            .FirstAsync(testcaseId, cancellationToken);

        testCase.EnsureAuthor(request.UserId);
        await _dbContext.EnsureProblemInDraftStatusAsync(testCase.ProblemId);

        _dbContext.TestCases.Remove(testCase);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}