using LeetCode.Data.Contexts;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Extensions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ActionInfo = LeetCode.Data.OwnedTypes.ActionInfo;

namespace LeetCode.Features.ImplementedProblem.Create;

public sealed record CreateImplementedProblemCommand : IRequest<Guid>
{
    public required Guid UserId { get; init; }
    public required long ProblemId { get; init; }
    public required long LanguageId { get; init; }
};

public class CreateImplementedProblemCommandHandler 
    : IRequestHandler<CreateImplementedProblemCommand, Guid>
{
    private readonly ApplicationDbContext _dbContext;

    public CreateImplementedProblemCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(
        CreateImplementedProblemCommand request, 
        CancellationToken cancellationToken)
    {
        var problemId = request.ProblemId;
        var languageId = request.LanguageId;
        
        await _dbContext.EnsureProblemInDraftStatusAsync(problemId);

        var duplicateExists = await _dbContext
            .ImplementedProblems
            .Where(x => x.ProblemId == problemId && x.LanguageId == languageId)
            .AnyAsync(cancellationToken);

        if (duplicateExists)
            throw new Exception($"Для задачи с id {problemId} уже существует реализация на языке с id {languageId}");

        var language = await _dbContext
            .Languages
            .FirstAsync(languageId, cancellationToken);

        var implementedProblem = new Data.Entities.ImplementedProblem
        {
            ProblemCode = language.DefaultProblemCode,
            DefaultSolutionCode = language.DefaultSolutionCode,
            WorkingSolutionCode = language.DefaultSolutionCode,
            CreateInfo = new ActionInfo(request.UserId),
            ProblemId = problemId,
            LanguageId = languageId,
        };

        _dbContext.ImplementedProblems.Add(implementedProblem);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return implementedProblem.Id;
    }
}