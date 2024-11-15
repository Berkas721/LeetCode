using LeetCode.Data.Contexts;
using LeetCode.Data.Entities;
using LeetCode.Data.OwnedTypes;
using LeetCode.Dto.Enums;
using LeetCode.Extensions;
using MediatR;

namespace LeetCode.Features.Solution.Create;

public sealed record CreateSolutionByOtherSolutionCommand(long SolutionBaseId, Guid UserId) 
    : IRequest<long>;

public class CreateSolutionByOtherSolutionCommandHandler 
    : IRequestHandler<CreateSolutionByOtherSolutionCommand, long>
{
    private readonly ApplicationDbContext _context;

    public CreateSolutionByOtherSolutionCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(
        CreateSolutionByOtherSolutionCommand request, 
        CancellationToken cancellationToken)
    {
        var solutionBaseId = request.SolutionBaseId;
        var userId = request.UserId;

        var solutionBase = await _context
            .ProblemSolutions
            .FirstAsync(solutionBaseId, cancellationToken);

        var solutionCopy = new ProblemSolution
        {
            Code = solutionBase.Code,
            Status = ProblemSolutionStatus.Draft,
            CreateInfo = new ActionInfo(userId),
            ImplementedProblemId = solutionBase.ImplementedProblemId
        };

        _context.ProblemSolutions.Add(solutionCopy);
        await _context.SaveChangesAsync(cancellationToken);

        return solutionCopy.Id;
    }
}