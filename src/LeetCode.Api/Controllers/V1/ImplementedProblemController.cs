﻿using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Dto.SolutionTest;
using LeetCode.Extensions;
using LeetCode.Features.ImplementedProblem.Create;
using LeetCode.Features.ImplementedProblem.Delete;
using LeetCode.Features.ImplementedProblem.Edit;
using LeetCode.Features.ImplementedProblem.Query;
using LeetCode.Features.ImplementedProblem.Test;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/implemented-problem")]
public class ImplementedProblemController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpGet("{implementedProblemId}")]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid implementedProblemId)
    {
        var command = new GetByIdImplementedProblemCommand(implementedProblemId);
        var testcase = await Mediator.Send(command);
        return Ok(testcase);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateImplementedProblemInput input)
    {
        var command = Mapper.Map<CreateImplementedProblemCommand>(input) with { CreatorId = User.GetUserId() };
        var testcase = await Mediator.Send(command);
        return Ok(testcase);
    }

    [HttpPut("{implementedProblemId}/update")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid implementedProblemId,
        [FromBody] UpdateImplementedProblemInput input)
    {
        var command = Mapper.Map<EditImplementedProblemCommand>(input) with { Id = implementedProblemId };
        var testcase = await Mediator.Send(command);
        return Ok(testcase);
    }

    [HttpPut("{implementedProblemId}/test-solution-with-official-testcases")]
    public async Task<IActionResult> TestOfficialTestcases(
        [FromRoute] Guid implementedProblemId)
    {
        var command = new TestImplementedProblemSolutionWithOfficialTestCasesCommand(implementedProblemId);
        var testResults = await Mediator.Send(command);
        return Ok(testResults);
    }

    [HttpPut("{implementedProblemId}/test-solution-with-draft-testcases")]
    public async Task<IActionResult> TestDraftTestcases(
        [FromRoute] Guid implementedProblemId,
        [FromBody] IReadOnlyList<TestCase> testCases)
    {
        var command = new TestImplementedProblemSolutionWithDraftTestCasesCommand
        {
            ImplementedProblemId = implementedProblemId,
            TestCases = testCases
        };
        var testResults = await Mediator.Send(command);
        return Ok(testResults);
    }

    [HttpPut("{implementedProblemId}/run-solution")]
    public async Task<IActionResult> CreateOutput(
        [FromRoute] Guid implementedProblemId,
        [FromBody] string testCaseInput)
    {
        var command = new RunImplementedProblemSolutionCommand(implementedProblemId, testCaseInput);
        var testcaseOutput = await Mediator.Send(command);
        return Ok(testcaseOutput);
    }

    [HttpPut("{implementedProblemId}/delete")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid implementedProblemId)
    {
        var command = new DeleteImplementedProblemCommand(implementedProblemId);
        await Mediator.Send(command);
        return Ok();
    }
}