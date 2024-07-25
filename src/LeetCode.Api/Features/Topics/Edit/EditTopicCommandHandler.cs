using LeetCode.Data.Contexts;
using LeetCode.Exceptions;
using MediatR;

namespace LeetCode.Features.Topics.Edit;

public sealed record EditTopicCommand : IRequest
{
    public required long Id { get; init; }

    public required string? NewName { get; init; }

    public required string? NewDescription { get; init; }
}

public sealed record EditTopicCommandHandler : IRequestHandler<EditTopicCommand>
{
    private readonly ApplicationDbContext _dbContext;

    public EditTopicCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(
        EditTopicCommand request, 
        CancellationToken cancellationToken)
    {
        var topic = await _dbContext
            .ProblemTopics
            .FindAsync(request.Id);
        
        ResourceNotFoundException
            .ThrowIfNull(topic, $"не найден topic с id: {request.Id}");
        
        if (request.NewName is not null)
            topic.Name = request.NewName;
        
        if (request.NewDescription is not null)
            topic.Description = request.NewDescription;

        await _dbContext
            .SaveChangesAsync(cancellationToken);
    }
}