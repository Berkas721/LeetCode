using LeetCode.Data.Contexts;
using LeetCode.Dto.Topic;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Topics.Query;

public sealed record GetTopicQuery(long Id) : IRequest<Topic>;

public sealed record GetTopicQueryHandler : IRequestHandler<GetTopicQuery, Topic>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetTopicQueryHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Topic> Handle(
        GetTopicQuery request,
        CancellationToken cancellationToken)
    {
        var topicEntity = await _dbContext
            .ProblemTopics
            .FindAsync(request.Id);
        
        ResourceNotFoundException
            .ThrowIfNull(topicEntity, $"не найден topic с id: {request.Id}");

        return _mapper.Map<Topic>(topicEntity);
    }
}