using LeetCode.Data.Contexts;
using LeetCode.Data.Entities;
using LeetCode.Data.Enums;
using LeetCode.Data.OwnedTypes;
using LeetCode.Dto.Enums;
using LeetCode.Extensions;
using MediatR;

namespace LeetCode.Features.Solution.Create;

public sealed record CreateSolutionByImplementedProblemCommand(Guid ImplementedProblemId, Guid UserId) 
    : IRequest<long>;

public class CreateSolutionByImplementedProblemCommandHandler
    : IRequestHandler<CreateSolutionByImplementedProblemCommand, long>
{
    private readonly ApplicationDbContext _context;

    public CreateSolutionByImplementedProblemCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(
        CreateSolutionByImplementedProblemCommand request, 
        CancellationToken cancellationToken)
    {
        var implementedProblemId = request.ImplementedProblemId;
        var userId = request.UserId;

        var implementedProblem = await _context
            .ImplementedProblems
            .FindByIdAsync(implementedProblemId, cancellationToken);

        await _context.EnsureProblemInStatusAsync(implementedProblem.ProblemId, ProblemStatus.Open);

        var solution = new ProblemSolution
        {
            Code = implementedProblem.DefaultSolutionCode,
            Status = ProblemSolutionStatus.Draft,
            CreateInfo = new ActionInfo(userId),
            ImplementedProblemId = implementedProblemId
        };

        _context.ProblemSolutions.Add(solution);
        await _context.SaveChangesAsync(cancellationToken);

        return solution.Id;
    }
}