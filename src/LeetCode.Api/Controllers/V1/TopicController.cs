using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.Topic;
using LeetCode.Features.Topics.Create;
using LeetCode.Features.Topics.Delete;
using LeetCode.Features.Topics.Edit;
using LeetCode.Features.Topics.Query;
using LeetCode.Features.Topics.Search;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/topic")]
public class TopicController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpGet]
    public async Task<IActionResult> Query(
        CancellationToken cancellationToken)
    {
        var query = new GetTopicsQuery();
        var topics = await Mediator.Send(query, cancellationToken);
        return Ok(topics);
    }

    [HttpGet("{topicId}")]
    public async Task<IActionResult> GetById(
        [FromRoute] long topicId, 
        CancellationToken cancellationToken)
    {
        var query = new GetTopicQuery(topicId);
        var topic = await Mediator.Send(query, cancellationToken);
        return Ok(topic);
    }

    [HttpGet("names")]
    public async Task<IActionResult> GetAllNames( 
        CancellationToken cancellationToken)
    {
        var query = new GetTopicsNamesQuery();
        var names = await Mediator.Send(query, cancellationToken);
        return Ok(names);
    }

    [HttpGet("problems")]
    public async Task<IActionResult> GetProblems(
        [FromQuery(Name = "topicId")] List<long> topicIds, 
        CancellationToken cancellationToken)
    {
        var command = new FindProblemsAssignedByTopicsCommand(topicIds);
        var problemIds = await Mediator.Send(command, cancellationToken);
        return Ok(problemIds);
    }

    [HttpPut]
    public async Task<IActionResult> Create(
        [FromBody] CreateTopicInput input, 
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<CreateTopicCommand>(input);
        var topicId = await Mediator.Send(command, cancellationToken);
        return Ok(topicId);
    }

    [HttpPost("{topicId}")]
    public async Task<IActionResult> Edit(
        [FromRoute] long topicId,
        [FromBody] UpdateTopicInput input, 
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<EditTopicCommand>(input) with { Id = topicId };
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete("{topicId}")]
    public async Task<IActionResult> Delete(
        [FromRoute] long topicId, 
        CancellationToken cancellationToken)
    {
        var command = new DeleteTopicCommand(topicId);
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }
}