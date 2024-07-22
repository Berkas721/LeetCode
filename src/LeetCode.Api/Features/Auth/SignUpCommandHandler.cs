using LeetCode.Data.Entities;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LeetCode.Features.Auth;

public sealed record SignUpCommand : IRequest
{
    public string UserName { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public DateOnly Birthday { get; init; }
}

public sealed class SignUpCommandHandler : IRequestHandler<SignUpCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly IMapper _mapper;

    public SignUpCommandHandler(
        UserManager<ApplicationUser> userManager, 
        IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task Handle(
        SignUpCommand request, 
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<ApplicationUser>(request);

        user.Registration = DateOnly.FromDateTime(DateTime.UtcNow);

        var result = await _userManager
            .CreateAsync(user, request.Password);

        if (!result.Succeeded)
            throw new AuthException("Невозможно зарегистрировать нового пользователя: " + string.Join("; ",
                result
                    .Errors
                    .Select(x => x.Description)));
    }
}