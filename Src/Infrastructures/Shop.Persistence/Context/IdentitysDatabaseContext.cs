using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Users;

namespace Shop.Persistence.Context
{
    public class IdentitysDatabaseContext:IdentityDbContext
    {
        public IdentitysDatabaseContext(DbContextOptions<IdentitysDatabaseContext> options):base(options)
        {
            
        }
    }
}
