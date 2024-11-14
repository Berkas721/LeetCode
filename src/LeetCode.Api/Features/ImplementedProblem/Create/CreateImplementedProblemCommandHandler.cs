using LeetCode.Data.Contexts;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Exceptions;
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

        var language = await _dbContext
            .Languages
            .Where(x => x.Id == request.LanguageId)
            .FirstOrDefaultAsync(cancellationToken);

        ResourceNotFoundException.ThrowIfNull(language, "мдадмамдама");

        var implementedProblem = new Data.Entities.ImplementedProblem
        {
            ProblemCode = language.DefaultProblemCode,
            DefaultSolutionCode = language.DefaultSolutionCode,
            WorkingSolutionCode = language.DefaultSolutionCode,
            CreateInfo = new ActionInfo(request.CreatorId),
            ProblemId = request.ProblemId,
            LanguageId = request.LanguageId,
        };

        _dbContext.ImplementedProblems.Add(implementedProblem);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ImplementedProblemOutput>(implementedProblem);
    }
}