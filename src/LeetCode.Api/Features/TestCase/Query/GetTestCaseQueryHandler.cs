using LeetCode.Data.Contexts;
using LeetCode.Dto.TestCase;
using LeetCode.Exceptions;
using LeetCode.Extensions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.TestCase.Query;

public sealed record GetTestCaseQuery(long Id) : IRequest<TestCaseOutput>;

public class GetTestCaseQueryHandler
    : IRequestHandler<GetTestCaseQuery, TestCaseOutput>
{
    private readonly ApplicationDbContext _dbContext;
    
    private readonly IMapper _mapper;

    public GetTestCaseQueryHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TestCaseOutput> Handle(
        GetTestCaseQuery request, 
        CancellationToken cancellationToken)
    {
        var testCase = await _dbContext
            .TestCases
            .FirstAsync(request.Id, cancellationToken);

        return _mapper.Map<TestCaseOutput>(testCase);
    }
}