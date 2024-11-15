using LeetCode.Data.Contexts;
using LeetCode.Dto.Solution;
using LeetCode.Extensions;
using MapsterMapper;
using MediatR;

namespace LeetCode.Features.Solution.Query;

public sealed record GetSolutionQuery(long SolutionId) 
    : IRequest<SolutionOutput>;

public class GetSolutionQueryHandler 
    : IRequestHandler<GetSolutionQuery, SolutionOutput>
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public GetSolutionQueryHandler(
        ApplicationDbContext context, 
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SolutionOutput> Handle(
        GetSolutionQuery request,
        CancellationToken cancellationToken)
    {
        var problem = await _context
            .ProblemSolutions
            .FindByIdAsync(request.SolutionId, cancellationToken);

        return _mapper.Map<SolutionOutput>(problem);
    }
}