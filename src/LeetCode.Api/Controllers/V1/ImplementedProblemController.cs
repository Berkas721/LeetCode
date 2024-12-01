using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Dto.Solution;
using LeetCode.Dto.TestCase;
using LeetCode.Extensions;
using LeetCode.Features.ImplementedProblem.Create;
using LeetCode.Features.ImplementedProblem.Delete;
using LeetCode.Features.ImplementedProblem.Edit;
using LeetCode.Features.ImplementedProblem.Query;
using LeetCode.Features.ImplementedProblem.Test;
using LeetCode.Features.Solution.Query;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/implemented-problem")]
public class ImplementedProblemController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpGet("{implementedProblemId}")]
    [ProducesResponseType<ImplementedProblemOutput>(200)]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid implementedProblemId, 
        CancellationToken cancellationToken)
    {
        var query = new GetByIdImplementedProblemQuery(implementedProblemId);
        var problem = await Mediator.Send(query, cancellationToken);
        return Ok(problem);
    }

    [HttpGet("{implementedProblemId}/solutions")]
    [Authorize]
    [ProducesResponseType<List<SolutionOutput>>(200)]
    public async Task<IActionResult> GetSolutions(
        [FromRoute] Guid implementedProblemId, 
        CancellationToken cancellationToken)
    {
        var query = new GetSolutionsByImplementedProblemIdQuery(implementedProblemId, User.GetUserId());
        var problems = await Mediator.Send(query, cancellationToken);
        return Ok(problems);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType<Guid>(200)]
    public async Task<IActionResult> Create(
        [FromBody] CreateImplementedProblemInput input, 
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<CreateImplementedProblemCommand>(input) with { UserId = User.GetUserId() };
        var problem = await Mediator.Send(command, cancellationToken);
        return Ok(problem);
    }

    [HttpPut("{implementedProblemId}/update")]
    [Authorize]
    [ProducesResponseType<ImplementedProblemOutput>(200)]
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
        var problem = await Mediator.Send(command, cancellationToken);
        return Ok(problem);
    }

    [HttpPut("{implementedProblemId}/test-working-solution-with-official-testcases")]
    [ProducesResponseType<TestImplementationProblemResult>(200)]
    public async Task<IActionResult> TestOfficialTestcases(
        [FromRoute] Guid implementedProblemId, 
        CancellationToken cancellationToken)
    {
        var command = new TestImplementedProblemSolutionWithOfficialTestCasesCommand(implementedProblemId);
        var testResults = await Mediator.Send(command, cancellationToken);
        return Ok(testResults);
    }

    [HttpPut("{implementedProblemId}/test-working-solution-with-specified-testcases")]
    [ProducesResponseType<TestImplementationProblemResult>(200)]
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
    [ProducesResponseType<string>(200)]
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
    [ProducesResponseType(200)]
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