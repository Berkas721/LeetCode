using LeetCode.Data.Contexts;
using LeetCode.Dto.TestCase;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.TestCase.Edit;

public sealed record EditTestCaseCommand : IRequest<TestCaseOutput>
{
    public required long Id { get; init; }
    
    public required string? NewInput { get; init; }

    public required string? NewOutput { get; init; }
}

public class EditTestCaseCommandHandler : IRequestHandler<EditTestCaseCommand, TestCaseOutput>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public EditTestCaseCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TestCaseOutput> Handle(
        EditTestCaseCommand request, 
        CancellationToken cancellationToken)
    {
        var testCase = await _dbContext
            .TestCases
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        ResourceNotFoundException.ThrowIfNull(testCase, "blablbalba");

        // TODO: проверка что работает со всеми Implemented problems если они есть

        if (request.NewInput is not null)
            testCase.Input = request.NewInput;

        if (request.NewOutput is not null)
            testCase.Output = request.NewOutput;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TestCaseOutput>(testCase);
    }
}