using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.Problem;
using LeetCode.Extensions;
using LeetCode.Features.Problem.Create;
using LeetCode.Features.Problem.Delete;
using LeetCode.Features.Problem.Edit;
using LeetCode.Features.Problem.Query;
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
        var query = new GetProblemQuery(problemId);
        var problem = await Mediator.Send(query);
        return Ok(problem);
    }

    // нужен graphql...
    [HttpGet("{problemId}/full-info")]
    public async Task<IActionResult> GetFullInfo(
        [FromRoute] long problemId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{problemId}/topics")]
    public async Task<IActionResult> GetTopics(
        [FromRoute] long problemId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{problemId}/testcases")]
    public async Task<IActionResult> GetTestcases(
        [FromRoute] long problemId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{problemId}/implemented-problems")]
    public async Task<IActionResult> GetImplementedProblems(
        [FromRoute] long problemId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{problemId}/solutions")]
    public async Task<IActionResult> GetSolutions(
        [FromRoute] long problemId)
    {
        throw new NotImplementedException();
    }

    // Проверка хватает ли всех данных для открытия задачи и проходят ли они проверки
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
        var command = Mapper.Map<CreateProblemCommand>(input) with { UserId = User.GetUserId() };
        var problemId = await Mediator.Send(command);
        return Ok(problemId);
    }

    [HttpPut("{problemId}/update")]
    [Authorize]
    public async Task<IActionResult> Update(
        [FromRoute] long problemId,
        [FromBody] UpdateProblemInput input)
    {
        var command = Mapper.Map<EditProblemCommand>(input) with
        {
            ProblemId = problemId,
            UserId = User.GetUserId()
        };
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPut("{problemId}/open")]
    [Authorize]
    public async Task<IActionResult> Open(
        [FromRoute] long problemId)
    {
        var command = new OpenProblemForPublicCommand(problemId, User.GetUserId());
        var problem = await Mediator.Send(command);
        return Ok(problem);
    }

    [HttpDelete("{problemId}/delete")]
    [Authorize]
    public async Task<IActionResult> Delete(
        [FromRoute] long problemId)
    {
        var command = new DeleteProblemCommand(problemId, User.GetUserId());
        await Mediator.Send(command);
        return Ok();
    }
}