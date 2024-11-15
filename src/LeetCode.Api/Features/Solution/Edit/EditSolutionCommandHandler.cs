using LeetCode.Data.Contexts;
using LeetCode.Dto.Enums;
using LeetCode.Dto.Solution;
using LeetCode.Exceptions;
using LeetCode.Extensions;
using MapsterMapper;
using MediatR;

namespace LeetCode.Features.Solution.Edit;

public sealed record EditSolutionCommand : IRequest<SolutionOutput>
{
    public required long SolutionId { get; init; }

    public required Guid UserId { get; init; }

    public required string? Code { get; init; }
}

public class EditSolutionCommandHandler
    : IRequestHandler<EditSolutionCommand, SolutionOutput>
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public EditSolutionCommandHandler(
        ApplicationDbContext context, 
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SolutionOutput> Handle(
        EditSolutionCommand request, 
        CancellationToken cancellationToken)
    {
        var solutionId = request.SolutionId;

        var solution = await _context
            .ProblemSolutions
            .FindByIdAsync(solutionId, cancellationToken);

        solution.EnsureAuthor(request.UserId);

        if (solution.Status != ProblemSolutionStatus.Draft)
            throw new ForbiddenException($"Нельзя изменить решение с id {solutionId}, так как оно не находится в состоянии черновика");

        if (request.Code is null)
            return _mapper.Map<SolutionOutput>(solution);

        solution.Code = request.Code;
        solution.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<SolutionOutput>(solution);
    }
}