using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.Problem;
using LeetCode.Extensions;
using LeetCode.Features.Problem.Create;
using LeetCode.Features.Problem.Delete;
using LeetCode.Features.Problem.Edit;
using LeetCode.Features.Problem.Test;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/problem")]
public class ProblemController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpGet("{problemId}")]
    public async Task<IActionResult> GetById(
        [FromRoute] long problemId)
    {
        return Ok();
    }

    // Должно замениться GQL в будущем
    [HttpGet("{problemId}/topics")]
    public async Task<IActionResult> GetTopics(
        [FromRoute] long problemId)
    {
        return Ok();
    }

    [HttpGet("{problemId}/testcases")]
    public async Task<IActionResult> GetTestcases(
        [FromRoute] long problemId)
    {
        return Ok();
    }

    [HttpGet("{problemId}/implemented-problems")]
    public async Task<IActionResult> GetImplementedProblems(
        [FromRoute] long problemId)
    {
        return Ok();
    }

    [HttpGet("{problemId}/solutions")]
    public async Task<IActionResult> GetSolutions(
        [FromRoute] long problemId)
    {
        return Ok();
    }

    // Проверка хватает ли всех данных для открытия задачи
    [HttpGet("{problemId}/check")]
    public async Task<IActionResult> Check(
        [FromRoute] long problemId)
    {
        var command = new TestProblemCommand(problemId);
        var testResult = await Mediator.Send(command);
        return Ok(testResult);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateProblemInput input)
    {
        var command = Mapper.Map<CreateProblemCommand>(input) with { CreatorId = User.GetUserId() };
        var problemId = await Mediator.Send(command);
        return Ok(problemId);
    }

    [HttpPut("{problemId}/update")]
    public async Task<IActionResult> Update(
        [FromRoute] long problemId,
        [FromBody] UpdateProblemInput input)
    {
        var command = Mapper.Map<EditProblemCommand>(input) with
        {
            Id = problemId,
            UpdaterId = User.GetUserId()
        };
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPut("{problemId}/open")]
    public async Task<IActionResult> Open(
        [FromRoute] long problemId)
    {
        var userId = User.GetUserId();
        var command = new OpenProblemForPublicCommand(problemId, userId);
        var problem = await Mediator.Send(command);
        return Ok(problem);
    }

    [HttpDelete("{problemId}/delete")]
    [Authorize]
    public async Task<IActionResult> Delete(
        [FromRoute] long problemId)
    {
        var command = new DeleteProblemCommand(problemId);
        await Mediator.Send(command);
        return Ok();
    }
}