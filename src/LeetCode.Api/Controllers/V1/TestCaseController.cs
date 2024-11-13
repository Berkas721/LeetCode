using LeetCode.Controllers.Abstraction;
using LeetCode.Dto;
using LeetCode.Dto.SolutionTest;
using LeetCode.Dto.TestCase;
using LeetCode.Extensions;
using LeetCode.Features.TestCase.Create;
using LeetCode.Features.TestCase.Delete;
using LeetCode.Features.TestCase.Edit;
using LeetCode.Features.TestCase.Query;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/testcase")]
public class TestCaseController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpGet("{testcaseId}")]
    public async Task<IActionResult> GetById(
        [FromRoute] long testcaseId)
    {
        var command = new GetTestCaseByIdCommand(testcaseId);
        var testcase = await Mediator.Send(command);
        return Ok(testcase);
    }

    // Проверка для существующих Implemented problems если они есть, возвращает результат тестов с ними
    [HttpPut("check")]
    public async Task<IActionResult> Check(
        [FromBody] TestCase testCase)
    {
        throw new NotImplementedException();
    }

    // Проверка для существующих Implemented problems если они есть, возвращает результат тестов с ними
    [HttpPut("{testcaseId}/check")]
    public async Task<IActionResult> Check(
        [FromRoute] long testcaseId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateTestCaseInput input)
    {
        var command = Mapper.Map<CreateTestCaseCommand>(input) with { CreatorId = User.GetUserId() };
        var testcaseId = await Mediator.Send(command);
        return Ok(testcaseId);
    }

    [HttpPut("{testcaseId}/update")]
    public async Task<IActionResult> Update(
        [FromRoute] long testcaseId,
        [FromBody] EditTestCaseInput input)
    {
        var command = Mapper.Map<EditTestCaseCommand>(input) with { Id = testcaseId };
        var testcase = await Mediator.Send(command);
        return Ok(testcase);
    }

    [HttpPut("{testcaseId}/delete")]
    public async Task<IActionResult> Delete(
        [FromRoute] long testcaseId)
    {
        var command = new DeleteTestCaseCommand(testcaseId);
        await Mediator.Send(command);
        return Ok();
    }
}