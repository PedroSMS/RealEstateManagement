﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RealEstateManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(e => e.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}