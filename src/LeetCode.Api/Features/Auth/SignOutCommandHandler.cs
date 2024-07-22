using LeetCode.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LeetCode.Features.Auth;

public sealed record SignOutCommand : IRequest;

public sealed class SignOutCommandHandler : IRequestHandler<SignOutCommand>
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public SignOutCommandHandler(
        SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task Handle(
        SignOutCommand request, 
        CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
    }
}