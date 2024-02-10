using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateManagement.Application.Common.Interfaces;
using RealEstateManagement.Infrastructure.Persistence.Contexts;
using System;

namespace RealEstateManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<RealEstateDbContext>(options =>
        {
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(15), null);
                });
        });

        services.AddDbContext<AuthDbContext>(options =>
        {
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(15), null);
                });
        });

        services.AddScoped<IRealEstateDbContext>(provider => 
            provider.GetRequiredService<RealEstateDbContext>());

        return services;
    }
}
