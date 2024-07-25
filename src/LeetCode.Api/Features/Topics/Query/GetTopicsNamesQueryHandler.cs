using LeetCode.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Topics.Query;

public sealed record GetTopicsNamesQuery : IRequest<IReadOnlyList<string>>;

public sealed record GetTopicsNamesQueryHandler : IRequestHandler<GetTopicsNamesQuery, IReadOnlyList<string>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetTopicsNamesQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<string>> Handle(
        GetTopicsNamesQuery request, 
        CancellationToken cancellationToken)
    {
        var names = await _dbContext
            .ProblemTopics
            .AsNoTracking()
            .Select(x => x.Name)
            .ToListAsync(cancellationToken: cancellationToken);

        return names;
    }
}