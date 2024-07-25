using LeetCode.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ProgrammingLanguages.Query;

public sealed record GetProgrammingLanguageNamesQuery : IRequest<IReadOnlyList<string>>;

public sealed record GetProgrammingLanguageNamesQueryHandler : 
    IRequestHandler<GetProgrammingLanguageNamesQuery, IReadOnlyList<string>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetProgrammingLanguageNamesQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<string>> Handle(
        GetProgrammingLanguageNamesQuery request, 
        CancellationToken cancellationToken)
    {
        var names = await _dbContext
            .Languages
            .Select(x => x.Name)
            .ToListAsync(cancellationToken);

        return names;
    }
}