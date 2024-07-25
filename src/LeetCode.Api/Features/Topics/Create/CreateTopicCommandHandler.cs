using LeetCode.Data.Contexts;
using LeetCode.Data.Entities;
using MapsterMapper;
using MediatR;

namespace LeetCode.Features.Topics.Create;

public sealed record CreateTopicCommand : IRequest<long>
{
    public required string Name { get; init; }

    public required string? Description { get; init; }
}

public sealed record CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, long>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public CreateTopicCommandHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<long> Handle(
        CreateTopicCommand request, 
        CancellationToken cancellationToken)
    {
        var topic = _mapper.Map<ProblemTopic>(request);

        await _dbContext
            .ProblemTopics
            .AddAsync(topic, cancellationToken);

        await _dbContext
            .SaveChangesAsync(cancellationToken);

        return topic.Id;
    }
}