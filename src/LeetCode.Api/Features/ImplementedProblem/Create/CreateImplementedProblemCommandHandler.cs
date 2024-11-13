using LeetCode.Data.Contexts;
using LeetCode.Dto.ImplementedProblem;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ActionInfo = LeetCode.Data.OwnedTypes.ActionInfo;

namespace LeetCode.Features.ImplementedProblem.Create;

public sealed record CreateImplementedProblemCommand : IRequest<ImplementedProblemOutput>
{
    public required Guid CreatorId { get; init; }
    public required long ProblemId { get; init; }
    public required long LanguageId { get; init; }
    public required string ProblemCode { get; init; }
    public required string WorkingSolutionCode { get; init; }
};

public class CreateImplementedProblemCommandHandler 
    : IRequestHandler<CreateImplementedProblemCommand, ImplementedProblemOutput>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public CreateImplementedProblemCommandHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ImplementedProblemOutput> Handle(
        CreateImplementedProblemCommand request, 
        CancellationToken cancellationToken)
    {
        await _dbContext.ThrowExceptionIfProblemHasOpenStatus(request.ProblemId);

        var duplicate = await _dbContext
            .ImplementedProblems
            .Where(x => x.ProblemId == request.ProblemId && x.LanguageId == request.LanguageId)
            .AnyAsync(cancellationToken);

        if (duplicate)
            throw new Exception("dfssdfsd");

        var implementedProblem = _mapper.Map<Data.Entities.ImplementedProblem>(request);

        implementedProblem.CreateInfo = new ActionInfo
        {
            Date = DateTime.UtcNow,
            AgentId = request.CreatorId
        };

        _dbContext.ImplementedProblems.Add(implementedProblem);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ImplementedProblemOutput>(implementedProblem);
    }
}