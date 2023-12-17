using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Users;

namespace Shop.Persistence.Context
{
    public class IdentitysDatabaseContext:IdentityDbContext<User>
    {
        public IdentitysDatabaseContext(DbContextOptions<IdentitysDatabaseContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //schyma and Tabale
            builder.Entity<IdentityUser<string>>().ToTable("Users","identity");
            builder.Entity<IdentityRole<string>>().ToTable("Roles", "identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "identity");
            //Add Has key
            builder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });
            builder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserToken<string>>().HasKey(x => new { x.UserId, x.Name,x.LoginProvider });
        }
    }
}