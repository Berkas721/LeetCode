using LeetCode.Controllers.Abstraction;
using LeetCode.Extensions;
using LeetCode.Features.Solution.Create;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/solutions")]
public class SolutionController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpPost("create-by-implemented-problem/{implementedProblemId:Guid}")]
    [Authorize]
    public async Task<IActionResult> CreateByImplementedProblem(
        [FromRoute] Guid implementedProblemId,
        CancellationToken cancellationToken)
    {
        var command = new CreateSolutionByImplementedProblemCommand(implementedProblemId, User.GetUserId());
        var solutionId = await Mediator.Send(command, cancellationToken);
        return Ok(solutionId);
    }

    [HttpPost("{solutionBaseId:long}/create-copy")]
    [Authorize]
    public async Task<IActionResult> CreateByOtherSolution(
        [FromRoute] long solutionBaseId,
        CancellationToken cancellationToken)
    {
        var command = new CreateSolutionByOtherSolutionCommand(solutionBaseId, User.GetUserId());
        var solutionId = await Mediator.Send(command, cancellationToken);
        return Ok(solutionId);
    }
}