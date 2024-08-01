using System.Security.Claims;
using LeetCode.Exceptions;

namespace LeetCode.Extensions;

public static class UserClaimsExtension
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        var userId = principal
            .FindFirstValue(ClaimTypes.NameIdentifier);

        if(userId is null)
            throw new AuthException("Пользователь не аутентифицирован");

        return Guid.Parse(userId);
    }
}