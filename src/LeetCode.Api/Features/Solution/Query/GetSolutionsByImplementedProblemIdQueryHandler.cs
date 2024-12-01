using LeetCode.Data.Contexts;
using LeetCode.Dto.Solution;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Solution.Query;

public sealed record GetSolutionsByImplementedProblemIdQuery(Guid Id, Guid UserId) 
    : IRequest<List<SolutionOutput>>;

public class GetSolutionsByImplementedProblemIdQueryHandler 
    : IRequestHandler<GetSolutionsByImplementedProblemIdQuery, List<SolutionOutput>>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetSolutionsByImplementedProblemIdQueryHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<SolutionOutput>> Handle(
        GetSolutionsByImplementedProblemIdQuery request, 
        CancellationToken cancellationToken)
    {
        var solutions = await _dbContext
            .ProblemSolutions
            .Where(x => x.ImplementedProblemId == request.Id)
            .Where(x => x.CreateInfo.AgentId == request.UserId)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<SolutionOutput>>(solutions);
    }
}