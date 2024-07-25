using LeetCode.Data.Contexts;
using LeetCode.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Topics.Search;

public sealed record FindProblemsAssignedByTopicsCommand(IReadOnlyList<long> TopicIds) : 
    IRequest<IReadOnlyList<long>>;

public sealed record FindProblemsAssignedByTopicsCommandHandler : 
    IRequestHandler<FindProblemsAssignedByTopicsCommand, IReadOnlyList<long>>
{
    private readonly ApplicationDbContext _dbContext;

    public FindProblemsAssignedByTopicsCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<long>> Handle(
        FindProblemsAssignedByTopicsCommand request, 
        CancellationToken cancellationToken)
    {
        var topicIds = request.TopicIds;

        if (topicIds.Count == 0)
            return await _dbContext
                .Problems
                .Include(x => x.Topics)
                .Where(x => x.Topics.Count == 0)
                .Select(x => x.Id)
                .ToListAsync(cancellationToken);

        // по каждому topic отбираем множество относящихся к нему problemIds
        // TODO: можно обойтись без объединений если зарегаем ассоциативную таблицу
        var problemsSets = await _dbContext
            .ProblemTopics
            .Where(x => topicIds.Contains(x.Id))
            .Include(x => x.Problems)
            .Select(x => x.Problems
                .Select(x => x.Id))
            .ToListAsync(cancellationToken);

        if (problemsSets.Count != topicIds.Count)
            throw new ResourceNotFoundException("некоторые topic не существуют");

        // находим среди всех множеств общие problemIds
        var problems = problemsSets.First();

        for (int i = 1; i < problemsSets.Count; i++)
            problems = problems.Intersect(problemsSets[i]);

        return problems.ToList();
    }
}