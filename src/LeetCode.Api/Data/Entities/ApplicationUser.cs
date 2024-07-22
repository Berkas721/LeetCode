using Microsoft.AspNetCore.Identity;

namespace LeetCode.Data.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateOnly Birthday { get; set; }

    public DateOnly Registration { get; set; }
}