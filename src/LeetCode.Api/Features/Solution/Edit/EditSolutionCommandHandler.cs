using LeetCode.Data.Contexts;
using LeetCode.Dto.Solution;
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
            .FirstAsync(solutionId, cancellationToken);

        solution.EnsureAuthor(request.UserId);

        if (request.Code is null)
            return _mapper.Map<SolutionOutput>(solution);

        solution.Code = request.Code;
        solution.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<SolutionOutput>(solution);
    }
}