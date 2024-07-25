using LeetCode.Data.Contexts;
using LeetCode.Dto.Topic;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Topics.Query;

public sealed record GetTopicsQuery : IRequest<IReadOnlyList<Topic>>;

public sealed record GetTopicsQueryHandler : IRequestHandler<GetTopicsQuery, IReadOnlyList<Topic>>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetTopicsQueryHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<Topic>> Handle(
        GetTopicsQuery request, 
        CancellationToken cancellationToken)
    {
        var topicsEntity = await _dbContext
            .ProblemTopics
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return _mapper.Map<IReadOnlyList<Topic>>(topicsEntity);
    }
}