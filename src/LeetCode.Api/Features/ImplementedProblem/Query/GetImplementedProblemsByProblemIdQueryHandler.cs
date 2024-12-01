using LeetCode.Data.Contexts;
using LeetCode.Dto.ImplementedProblem;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ImplementedProblem.Query;

public sealed record GetImplementedProblemsByProblemIdQuery(long ProblemId) 
    : IRequest<List<ImplementedProblemSecretOutput>>;

public class GetImplementedProblemsByProblemIdQueryHandler 
    : IRequestHandler<GetImplementedProblemsByProblemIdQuery, List<ImplementedProblemSecretOutput>>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetImplementedProblemsByProblemIdQueryHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ImplementedProblemSecretOutput>> Handle(
        GetImplementedProblemsByProblemIdQuery request, 
        CancellationToken cancellationToken)
    {
        var implementedProblems = await _dbContext
            .ImplementedProblems
            .Where(x => x.ProblemId == request.ProblemId)
            .Select(x => new ImplementedProblemSecretOutput
            {
                Id = x.Id,
                ProblemId = x.ProblemId,
                LanguageId = x.LanguageId
            })
            .AsTracking()
            .ToListAsync(cancellationToken);

        return implementedProblems;
    }
}