using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.SolutionTest;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/implemented-problem")]
public class ImplementedProblemController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpGet("{implementedProblemId}")]
    public async Task<IActionResult> GetById(
        [FromRoute] long implementedProblemId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        return Ok();
    }

    [HttpPost("{testcaseId}/update")]
    public async Task<IActionResult> Update(
        [FromRoute] long implementedProblemId)
    {
        return Ok();
    }

    [HttpPost("{testcaseId}/test-solution-with-official-testcases")]
    public async Task<IActionResult> TestOfficialTestcases(
        [FromRoute] long implementedProblemId)
    {
        return Ok();
    }

    [HttpPost("{testcaseId}/test-solution-with-draft-testcases")]
    public async Task<IActionResult> TestDraftTestcases(
        [FromRoute] long implementedProblemId,
        [FromBody] IReadOnlyList<TestCase> testCases)
    {
        return Ok();
    }

    [HttpPost("{testcaseId}/run-solution")]
    public async Task<IActionResult> CreateOutput(
        [FromRoute] long implementedProblemId,
        [FromBody] string testCaseInput)
    {
        return Ok();
    }

    [HttpPost("{testcaseId}/delete")]
    public async Task<IActionResult> Delete(
        [FromRoute] long testcaseId)
    {
        return Ok();
    }
}