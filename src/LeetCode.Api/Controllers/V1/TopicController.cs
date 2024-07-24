using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.Topic;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/topic")]
public class TopicController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpGet]
    public async Task<IActionResult> GetAllNames()
    {
        var names = new List<string>();
        return Ok(names);
    }
    
    [HttpGet("detailed")]
    public async Task<IActionResult> GetAllDetailed()
    {
        var topics = new List<Topic>();
        return Ok(topics);
    }
    
    [HttpGet("{topicId}")]
    public async Task<IActionResult> GetById(
        [FromRoute] long topicId)
    {
        //var topics = new Topic();
        //return Ok(topics);

        return Ok();
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
        return Ok(input);
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