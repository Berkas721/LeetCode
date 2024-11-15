using LeetCode.Data.Contexts;
using LeetCode.Data.Enums;
using LeetCode.Data.OwnedTypes;
using LeetCode.Dto.Enums;
using LeetCode.Dto.Problem;
using LeetCode.Extensions;
using LeetCode.Features.Problem.Test;
using MapsterMapper;
using MediatR;

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
        var problemId = request.ProblemId;
        var userId = request.UserId;
        
        var problem = await _dbContext
            .Problems
            .FindByIdAsync(problemId, cancellationToken);

        problem.EnsureAuthor(userId);

        if (problem.Status != ProblemStatus.Draft)
            throw new Exception($"задачу с id {problemId} нельзя изменить, так как она находится не в состоянии черновика");

        var testResult = await _sender.Send(
            new TestProblemCommand(problem.Id), 
            cancellationToken);

        foreach (var testImplementationProblemResult in testResult.TestImplementationProblemResults)
        {
            foreach (var runTestCaseResult in testImplementationProblemResult.RunTestCaseResults)
            {
                if (runTestCaseResult.ResultStatus != SolutionTestResultStatus.Passed)
                    throw new Exception($"нельзя открыть задачу, потому что реализация с id " +
                                        $"{testImplementationProblemResult.ImplementationProblemId} не проходит тест");
            }
        }

        problem.Status = ProblemStatus.Open;
        problem.OpenInfo = new ActionInfo(userId);
        problem.UpdateInfo = new ActionInfo(userId);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProblemOutput>(problem);
    }
}

