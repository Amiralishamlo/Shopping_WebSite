using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Users;
using Shop.Persistence.Context;

namespace Shop.Infrastructure.IdentityConfig
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<IdentitysDatabaseContext>(x=>x.UseSqlServer(configuration.GetConnectionString("Shop_Sql")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentitysDatabaseContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<CustomIdentityError>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            });

            return services;
        }
    }
}
