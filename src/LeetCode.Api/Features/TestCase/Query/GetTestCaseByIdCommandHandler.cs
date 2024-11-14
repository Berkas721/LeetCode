using LeetCode.Data.Contexts;
using LeetCode.Dto.TestCase;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.TestCase.Query;

public sealed record GetTestCaseByIdCommand(long Id) : IRequest<TestCaseOutput>;

public class GetTestCaseByIdCommandHandler
    : IRequestHandler<GetTestCaseByIdCommand, TestCaseOutput>
{
    private readonly ApplicationDbContext _dbContext;
    
    private readonly IMapper _mapper;

    public GetTestCaseByIdCommandHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TestCaseOutput> Handle(
        GetTestCaseByIdCommand request, 
        CancellationToken cancellationToken)
    {
        var testCase = await _dbContext
            .TestCases
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        ResourceNotFoundException.ThrowIfNull(testCase, "blablabla");

        return _mapper.Map<TestCaseOutput>(testCase);
    }
}