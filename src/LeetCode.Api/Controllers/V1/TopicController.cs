using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.Topic;
using LeetCode.Features.Topics.Create;
using LeetCode.Features.Topics.Query;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/topic")]
public class TopicController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpGet]
    public async Task<IActionResult> Query()
    {
        var query = new GetTopicsQuery();
        var topics = await Mediator.Send(query);
        return Ok(topics);
    }

    [HttpGet("{topicId}")]
    public async Task<IActionResult> GetById(
        [FromRoute] long topicId)
    {
        var query = new GetTopicQuery(topicId);
        var topic = await Mediator.Send(query);
        return Ok(topic);
    }

    [HttpGet("names")]
    public async Task<IActionResult> GetAllNames()
    {
        var query = new GetTopicsNamesQuery();
        var names = await Mediator.Send(query);
        return Ok(names);
    }

    [HttpGet("problems")]
    public async Task<IActionResult> GetProblems(
        [FromQuery] List<long> topicIds)
    {
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Create(
        [FromBody] CreateTopicInput input)
    {
        var command = Mapper.Map<CreateTopicCommand>(input);
        var topicId = await Mediator.Send(command);
        return Ok(topicId);
    }

    [HttpPost("{topicId}")]
    public async Task<IActionResult> Update(
        [FromRoute] long topicId,
        [FromBody] UpdateTopicInput input)
    {
        return Ok(input);
    }

    [HttpDelete("{topicId}")]
    public async Task<IActionResult> Delete(
        [FromRoute] long topicId)
    {
        return Ok();
    }
}