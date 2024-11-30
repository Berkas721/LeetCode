using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.Auth;
using LeetCode.Extensions;
using LeetCode.Features.Auth;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Route("api/v1/auth")]
public class AuthController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpPost("signup")]
    [ProducesResponseType<Guid>(200)]
    public async Task<IActionResult> SignUp(
        [FromBody] SignUpInput input, 
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<SignUpCommand>(input);
        var userId = await Mediator.Send(command, cancellationToken);
        return Ok(userId);
    }

    [HttpPut("signin")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> SignIn(
        [FromBody] SignInInput input, 
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<SignInCommand>(input);
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPut("signout")]
    [Authorize]
    [ProducesResponseType(200)]
    public async Task<IActionResult> SignOut(
        CancellationToken cancellationToken)
    {
        var command = new SignOutCommand();
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpGet("current-user")]
    [Authorize]
    [ProducesResponseType<User>(200)]
    public async Task<IActionResult> GetCurrentUserInfo( 
        CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var command = new GetUserInfoCommand(userId);
        var user = await Mediator.Send(command, cancellationToken);
        return Ok(user);
    }
}