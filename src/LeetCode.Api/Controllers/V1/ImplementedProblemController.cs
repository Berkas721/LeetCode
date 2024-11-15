using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Dto.TestCase;
using LeetCode.Extensions;
using LeetCode.Features.ImplementedProblem.Create;
using LeetCode.Features.ImplementedProblem.Delete;
using LeetCode.Features.ImplementedProblem.Edit;
using LeetCode.Features.ImplementedProblem.Query;
using LeetCode.Features.ImplementedProblem.Test;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/implemented-problem")]
public class ImplementedProblemController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpGet("{implementedProblemId}")]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid implementedProblemId, 
        CancellationToken cancellationToken)
    {
        var query = new GetByIdImplementedProblemQuery(implementedProblemId);
        var testcase = await Mediator.Send(query, cancellationToken);
        return Ok(testcase);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(
        [FromBody] CreateImplementedProblemInput input, 
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<CreateImplementedProblemCommand>(input) with { UserId = User.GetUserId() };
        var testcase = await Mediator.Send(command, cancellationToken);
        return Ok(testcase);
    }

    [HttpPut("{implementedProblemId}/update")]
    [Authorize]
    public async Task<IActionResult> Update(
        [FromRoute] Guid implementedProblemId,
        [FromBody] UpdateImplementedProblemInput input, 
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<EditImplementedProblemCommand>(input) with
        {
            ImplementedProblemId = implementedProblemId,
            UserId = User.GetUserId()
        };
        var testcase = await Mediator.Send(command, cancellationToken);
        return Ok(testcase);
    }

    [HttpPut("{implementedProblemId}/test-working-solution-with-official-testcases")]
    public async Task<IActionResult> TestOfficialTestcases(
        [FromRoute] Guid implementedProblemId, 
        CancellationToken cancellationToken)
    {
        var command = new TestImplementedProblemSolutionWithOfficialTestCasesCommand(implementedProblemId);
        var testResults = await Mediator.Send(command, cancellationToken);
        return Ok(testResults);
    }

    [HttpPut("{implementedProblemId}/test-working-solution-with-specified-testcases")]
    public async Task<IActionResult> TestDraftTestcases(
        [FromRoute] Guid implementedProblemId,
        [FromBody] IReadOnlyList<TestCaseData> testCases, 
        CancellationToken cancellationToken)
    {
        var command = new TestImplementedProblemSolutionWithDraftTestCasesCommand
        {
            ImplementedProblemId = implementedProblemId,
            TestCases = testCases
        };
        var testResults = await Mediator.Send(command, cancellationToken);
        return Ok(testResults);
    }

    [HttpPut("{implementedProblemId}/run-working-solution")]
    public async Task<IActionResult> RunWorkingSolution(
        [FromRoute] Guid implementedProblemId,
        [FromBody] string testCaseInput, 
        CancellationToken cancellationToken)
    {
        var command = new RunImplementedProblemSolutionCommand(implementedProblemId, testCaseInput);
        var testcaseOutput = await Mediator.Send(command, cancellationToken);
        return Ok(testcaseOutput);
    }

    [HttpDelete("{implementedProblemId}/delete")]
    [Authorize]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid implementedProblemId, 
        CancellationToken cancellationToken)
    {
        var command = new DeleteImplementedProblemCommand
        {
            ImplementedProblemId = implementedProblemId,
            UserId = User.GetUserId()
        };
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }
}