using LeetCode.Data.Contexts;
using LeetCode.Data.Enums;
using LeetCode.Data.OwnedTypes;
using LeetCode.Dto.Enums;
using LeetCode.Dto.Problem;
using LeetCode.Exceptions;
using LeetCode.Features.Problem.Test;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Problem.Edit;

public sealed record OpenProblemForPublicCommand(long ProblemId, Guid UserId) 
    : IRequest<ProblemOutput>;

public class OpenProblemForPublicCommandHandler 
    : IRequestHandler<OpenProblemForPublicCommand, ProblemOutput>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly ISender _sender;

    private readonly IMapper _mapper;

    public OpenProblemForPublicCommandHandler(
        ApplicationDbContext dbContext, 
        ISender sender, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _sender = sender;
        _mapper = mapper;
    }

    public async Task<ProblemOutput> Handle(
        OpenProblemForPublicCommand request, 
        CancellationToken cancellationToken)
    {
        var problem = await _dbContext
            .Problems
            .Where(x => x.Id == request.ProblemId)
            .FirstOrDefaultAsync(cancellationToken);

        ResourceNotFoundException.ThrowIfNull(problem, "blablabla");

        if (problem.Status != ProblemStatus.Draft)
            throw new Exception("нельзя перевести статус");

        var testResult = await _sender.Send(
            new TestProblemCommand(problem.Id), 
            cancellationToken);

        foreach (var testImplementationProblemResult in testResult.TestImplementationProblemResults)
        {
            foreach (var runTestCaseResult in testImplementationProblemResult.RunTestCaseResults)
            {
                if (runTestCaseResult.ResultStatus != SolutionTestResultStatus.Passed)
                    throw new Exception("нельзя перевести статус потому что testCase или implementationProblem не проходят проверку");
            }
        }

        problem.Status = ProblemStatus.Open;
        problem.OpenInfo = new ActionInfo
        {
            Date = DateTime.UtcNow,
            AgentId = request.UserId
        };

        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProblemOutput>(problem);
    }
}

