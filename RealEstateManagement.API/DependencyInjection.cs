using Microsoft.AspNetCore.Identity;
using RealEstateManagement.Infrastructure.Persistence.Contexts;

namespace RealEstateManagement.API;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<IdentityUser, IdentityRole>(e =>
            {
                e.Password = new()
                {
                    RequireNonAlphanumeric = true,
                    RequireLowercase = true,
                    RequireUppercase = true,
                };
            })
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders()
            .AddApiEndpoints();

        return services;
    }
}
