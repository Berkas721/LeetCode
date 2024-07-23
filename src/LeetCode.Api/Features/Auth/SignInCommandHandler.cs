﻿using LeetCode.Data.Entities;
using LeetCode.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Auth;

public sealed record SignInCommand : IRequest
{
    public required string UserName { get; init; }

    public required string Password { get; init; }
}

public sealed record SignInCommandHandler : IRequestHandler<SignInCommand>
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public SignInCommandHandler(
        SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task Handle(
        SignInCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await _signInManager
            .PasswordSignInAsync(
                request.UserName,
                request.Password,
                isPersistent: true,
                lockoutOnFailure: false);

        if (result.Succeeded)
            return;

        var user = await _signInManager
            .UserManager
            .Users
            .FirstOrDefaultAsync(
                x => x.UserName == request.UserName,
                cancellationToken: cancellationToken);

        if (user is null)
            throw new AuthException($"не существует пользователя с ником {request.UserName}");

        throw new AuthException("неправильный пароль");
    }
}