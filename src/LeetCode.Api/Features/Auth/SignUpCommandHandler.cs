using LeetCode.Data.Entities;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LeetCode.Features.Auth;

public sealed record SignUpCommand : IRequest<Guid>
{
    public required string UserName { get; init; }

    public required string Password { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required DateOnly Birthday { get; init; }
}

public sealed class SignUpCommandHandler : IRequestHandler<SignUpCommand, Guid>
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly IMapper _mapper;

    private readonly ISender _sender;

    public SignUpCommandHandler(
        UserManager<ApplicationUser> userManager, 
        IMapper mapper, 
        ISender sender)
    {
        _userManager = userManager;
        _mapper = mapper;
        _sender = sender;
    }

    public async Task<Guid> Handle(
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

        var command = _mapper.Map<SignInCommand>(request);

        await _sender.Send(command, cancellationToken);

        return user.Id;
    }
}