using LeetCode.Controllers.Abstraction;
using LeetCode.Dto;
using LeetCode.Dto.SolutionTest;
using LeetCode.Dto.TestCase;
using LeetCode.Extensions;
using LeetCode.Features.TestCase.Create;
using LeetCode.Features.TestCase.Delete;
using LeetCode.Features.TestCase.Edit;
using LeetCode.Features.TestCase.Query;
using LeetCode.Features.TestCase.Test;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/testcase")]
public class TestCaseController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpGet("{testcaseId}")]
    public async Task<IActionResult> GetById(
        [FromRoute] long testcaseId,
        CancellationToken cancellationToken)
    {
        var query = new GetTestCaseQuery(testcaseId);
        var testcase = await Mediator.Send(query, cancellationToken);
        return Ok(testcase);
    }

    // Проверка для существующих Implemented problems если они есть, возвращает результат тестов с ними
    [HttpPut("check")]
    public async Task<IActionResult> Check(
        [FromQuery] long problemId,
        [FromBody] TestCase testCase,
        CancellationToken cancellationToken)
    {
        var command = new TestSpecifiedTestCaseWithImplementedProblemsCommand(problemId, testCase);
        var testResults = await Mediator.Send(command, cancellationToken);
        return Ok(testResults);
    }

    // Проверка для существующих Implemented problems если они есть, возвращает результат тестов с ними
    [HttpPut("{testcaseId}/check")]
    public async Task<IActionResult> Check(
        [FromRoute] long testcaseId,
        CancellationToken cancellationToken)
    {
        var command = new TestOfficialTestCaseWithImplementedProblemsCommand(testcaseId);
        var testResults = await Mediator.Send(command, cancellationToken);
        return Ok(testResults);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(
        [FromBody] CreateTestCaseInput input,
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<CreateTestCaseCommand>(input) with { CreatorId = User.GetUserId() };
        var testcaseId = await Mediator.Send(command, cancellationToken);
        return Ok(testcaseId);
    }

    [HttpPut("{testcaseId}/update")]
    [Authorize]
    public async Task<IActionResult> Update(
        [FromRoute] long testcaseId,
        [FromBody] EditTestCaseInput input,
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<EditTestCaseCommand>(input) with
        {
            TestCaseId = testcaseId, 
            UserId = User.GetUserId()
        };
        var testcase = await Mediator.Send(command, cancellationToken);
        return Ok(testcase);
    }

    [HttpPut("{testcaseId}/delete")]
    [Authorize]
    public async Task<IActionResult> Delete(
        [FromRoute] long testcaseId,
        CancellationToken cancellationToken)
    {
        var command = new DeleteTestCaseCommand(testcaseId, User.GetUserId());
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }
}