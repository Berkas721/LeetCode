using LeetCode.Data.Contexts;
using LeetCode.Data.Enums;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Exceptions;
using LeetCode.Extensions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ImplementedProblem.Edit;

public sealed record EditImplementedProblemCommand : IRequest<ImplementedProblemOutput>
{
    public required Guid ImplementedProblemId { get; init; }
    public required Guid UserId { get; init; }
    public string? ProblemCode { get; init; }
    public string? DefaultSolutionCode { get; init; }
    public string? WorkingSolutionCode { get; init; }
}

public class EditImplementedProblemCommandHandler 
    : IRequestHandler<EditImplementedProblemCommand, ImplementedProblemOutput>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public EditImplementedProblemCommandHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ImplementedProblemOutput> Handle(
        EditImplementedProblemCommand request, 
        CancellationToken cancellationToken)
    {
        var implementedProblem = await _dbContext
            .ImplementedProblems
            .FindByIdAsync(request.ImplementedProblemId, cancellationToken);

        implementedProblem.EnsureAuthor(request.UserId);
        await _dbContext.EnsureProblemInStatusAsync(implementedProblem.ProblemId, ProblemStatus.Draft);

        if (request.ProblemCode is not null)
            implementedProblem.ProblemCode = request.ProblemCode;

        if (request.DefaultSolutionCode is not null)
            implementedProblem.DefaultSolutionCode = request.DefaultSolutionCode;

        if (request.WorkingSolutionCode is not null)
            implementedProblem.WorkingSolutionCode = request.WorkingSolutionCode;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ImplementedProblemOutput>(implementedProblem);
    }
}