using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.Auth;
using LeetCode.Features.Auth;
using MapsterMapper;
using MediatR;
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
}