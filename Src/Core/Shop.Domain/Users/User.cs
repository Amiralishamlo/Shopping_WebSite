using Microsoft.AspNetCore.Identity;
using Shop.Domain.Attributes;

namespace Shop.Domain.Users
{
    [Auditable]
    public class User:IdentityUser
    {
        public string? FullName { get; set; }
    }
}
