using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.Auth;
using LeetCode.Features.Auth;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.V1;

[Microsoft.AspNetCore.Components.Route("api/v1/auth")]
public class AuthController(IMediator mediator, IMapper mapper) : ApplicationController(mediator, mapper)
{
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(
        [FromBody] SignUpInput input)
    {
        var command = Mapper.Map<SignUpCommand>(input);
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(
        [FromBody] SignInInput input)
    {
        var command = Mapper.Map<SignInCommand>(input);
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("signout")]
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
        // TODO: вынести куда нибудь
        var userId = User
            .Claims
            .First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
            .Value;

        var command = new GetUserInfoCommand(new Guid(userId));
        var user = await Mediator.Send(command);
        return Ok(user);
    }
}