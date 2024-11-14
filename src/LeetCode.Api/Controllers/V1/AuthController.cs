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
    public async Task<IActionResult> SignUp(
        [FromBody] SignUpInput input)
    {
        var command = Mapper.Map<SignUpCommand>(input);
        var userId = await Mediator.Send(command);
        return Ok(userId);
    }

    [HttpPut("signin")]
    public async Task<IActionResult> SignIn(
        [FromBody] SignInInput input)
    {
        var command = Mapper.Map<SignInCommand>(input);
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPut("signout")]
    [Authorize]
    public async Task<IActionResult> SignOut()
    {
        var command = new SignOutCommand();
        await Mediator.Send(command);
        return Ok();
    }

    [HttpGet("current-user")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUserInfo()
    {
        var userId = User.GetUserId();
        var command = new GetUserInfoCommand(userId);
        var user = await Mediator.Send(command);
        return Ok(user);
    }
}