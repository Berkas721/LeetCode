using LeetCode.Data.Contexts;
using LeetCode.Exceptions;
using MediatR;

namespace LeetCode.Features.Topics.Delete;

public sealed record DeleteTopicCommand(long Id) : IRequest;

public sealed record DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand>
{
    private readonly ApplicationDbContext _dbContext;

    public DeleteTopicCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(
        DeleteTopicCommand request, 
        CancellationToken cancellationToken)
    {
        var topic = await _dbContext
            .ProblemTopics
            .FindAsync(request.Id);
        
        ResourceNotFoundException
            .ThrowIfNull(topic, $"не найден topic с id: {request.Id}");

        _dbContext
            .ProblemTopics
            .Remove(topic);

       await _dbContext
           .SaveChangesAsync(cancellationToken);
    }
}