using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.Problem;
using LeetCode.Features.Problem.Create;
using LeetCode.Features.Problem.Query;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/problem")]
public class ProblemController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Create(
        [FromBody] CreateProblemInput input)
    {
        // TODO: вынести куда нибудь
        var userId = User
            .Claims
            .First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
            .Value;

        var command = Mapper.Map<CreateProblemCommand>(input) with { CreatorId = new Guid(userId) };
        var problemId = await Mediator.Send(command);
        return Ok(problemId);
    }

    [HttpGet("{problemId}")]
    public async Task<IActionResult> GetById(
        [FromRoute] long problemId)
    {
        var query = new GetProblemQuery(problemId);
        var problem = await Mediator.Send(query);
        return Ok(problem);
    }
}