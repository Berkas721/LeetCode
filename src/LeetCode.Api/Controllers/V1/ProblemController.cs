using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.Problem;
using LeetCode.Features.Problem.Create;
using LeetCode.Features.Problem.Delete;
using LeetCode.Features.Problem.Edit;
using LeetCode.Features.Problem.Query;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/problem")]
public class ProblemController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpGet]
    public async Task<IActionResult> Query()
    {
        // хз как много инфы возвращать
        return Ok();
    }

    [HttpGet("{problemId}")]
    public async Task<IActionResult> GetById(
        [FromRoute] long problemId)
    {
        var query = new GetProblemQuery(problemId);
        var problem = await Mediator.Send(query);
        return Ok(problem);
    }

    /* Муторно, долго и должно замениться GQL в будущем
    [HttpGet("{problemId}/topics")]
    public async Task<IActionResult> GetProblemTopics(
        [FromRoute] long problemId)
    {
        return Ok();
    }

    [HttpGet("{problemId}/testcases")]
    public async Task<IActionResult> GetProblemTestcases(
        [FromRoute] long problemId)
    {
        return Ok();
    }

    [HttpGet("{problemId}/solution-running-details")]
    public async Task<IActionResult> GetProblemSolutionRunningDetails(
        [FromRoute] long problemId)
    {
        return Ok();
    }

    [HttpGet("{problemId}/solutions")]
    public async Task<IActionResult> GetProblemSolutions(
        [FromRoute] long problemId)
    {
        // их может быть дохера
        return Ok();
    }
    */

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

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Update(
        [FromBody] UpdateProblemInput input)
    {
        // TODO: вынести куда нибудь
        var userId = User
            .Claims
            .First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
            .Value;

        var command = Mapper.Map<EditProblemCommand>(input) with { UpdaterId = new Guid(userId) };
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("{problemId}")]
    [Authorize]
    public async Task<IActionResult> Open(
        [FromRoute] long problemId)
    {
        // если ее статус - Draft, есть один рабочий Solution running details, есть testcase-s
        return Ok();
    }

    [HttpDelete("{problemId}")]
    [Authorize]
    public async Task<IActionResult> Delete(
        [FromRoute] long problemId)
    {
        var command = new DeleteProblemCommand(problemId);
        await Mediator.Send(command);
        return Ok();
    }
}