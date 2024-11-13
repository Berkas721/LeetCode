using LeetCode.Data.Contexts;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ImplementedProblem.Edit;

public sealed record EditImplementedProblemCommand : IRequest<ImplementedProblemOutput>
{
    public required Guid Id { get; init; }
    public string? ProblemCode { get; init; }

    public string? WorkingSolutionCode { get; init; }
};

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
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        ResourceNotFoundException.ThrowIfNull(implementedProblem, "blablabal");
        await _dbContext.ThrowExceptionIfProblemHasOpenStatus(implementedProblem.ProblemId);

        if (request.ProblemCode is not null)
            implementedProblem.ProblemCode = request.ProblemCode;

        if (request.WorkingSolutionCode is not null)
            implementedProblem.WorkingSolutionCode = request.WorkingSolutionCode;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ImplementedProblemOutput>(implementedProblem);
    }
}