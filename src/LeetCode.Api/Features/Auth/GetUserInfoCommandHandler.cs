using LeetCode.Data.Entities;
using LeetCode.Dto.Auth;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.Auth;

public sealed record GetUserInfoCommand(Guid UserId) : IRequest<User>;

public sealed class GetUserInfoCommandHandler : IRequestHandler<GetUserInfoCommand, User>
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly IMapper _mapper;

    public GetUserInfoCommandHandler(
        UserManager<ApplicationUser> userManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<User> Handle(
        GetUserInfoCommand request, 
        CancellationToken cancellationToken)
    {
        var user = await _userManager
            .Users
            .FirstOrDefaultAsync(
                x => x.Id == request.UserId, 
                cancellationToken: cancellationToken);

        ResourceNotFoundException
            .ThrowIfNull(user, $"не найден пользователь с id: {request.UserId}");

        var userDto = _mapper.Map<User>(user) with
        {
            Roles = await _userManager.GetRolesAsync(user)
        };

        return userDto;
    }
}