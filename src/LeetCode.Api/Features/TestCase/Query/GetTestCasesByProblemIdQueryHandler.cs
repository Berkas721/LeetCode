using LeetCode.Data.Contexts;
using LeetCode.Dto.TestCase;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.TestCase.Query;

public sealed record GetTestCasesByProblemIdQuery(long ProblemId) : IRequest<List<TestCaseOutput>>;

public class GetTestCasesByProblemIdQueryHandler : IRequestHandler<GetTestCasesByProblemIdQuery, List<TestCaseOutput>>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetTestCasesByProblemIdQueryHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<TestCaseOutput>> Handle(
        GetTestCasesByProblemIdQuery request, 
        CancellationToken cancellationToken)
    {
        var testCases = await _dbContext
            .TestCases
            .Where(x => x.ProblemId == request.ProblemId)
            .AsTracking()
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<TestCaseOutput>>(testCases);
    }
}