using LeetCode.Abstractions;
using LeetCode.Controllers.Abstraction;
using LeetCode.Data.Contexts;
using LeetCode.Dto.Problem;
using LeetCode.Extensions;
using LeetCode.Features.Problem.Create;
using LeetCode.Features.Problem.Delete;
using LeetCode.Features.Problem.Edit;
using LeetCode.Features.Problem.Query;
using LeetCode.Services;
using LeetCode.Utils;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

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

    /*
    [HttpGet("{problemId}")]
    public async Task<IActionResult> GetById(
        [FromRoute] long problemId,
        [FromServices] ApplicationDbContext dbContext,
        [FromServices] ITestSolution testSolution)
    {
        return Ok();
    }

    // Должно замениться GQL в будущем
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
        var userId = User.GetUserId();
        var command = Mapper.Map<CreateProblemCommand>(input) with { CreatorId = userId };
        var problemId = await Mediator.Send(command);
        return Ok(problemId);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Update(
        [FromBody] UpdateProblemInput input)
    {
        var userId = User.GetUserId();
        var command = Mapper.Map<EditProblemCommand>(input) with { UpdaterId = userId };
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