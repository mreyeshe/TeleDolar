// <copyright file="DependencyContainer.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

using API.Common.Mappings;
using AutoMapper;
using Microsoft.OpenApi.Models;

namespace API.IoC;

public static class DependencyContainer
{
    /// <summary>
    /// Dependency Injection Services.
    /// </summary>
    /// <param name="services">Service Collection to add Injection.</param>
    /// <param name="configuration">Configuration Settings.</param>
    /// <returns>Service Collection.</returns>
    public static IServiceCollection AddCleanArchitectureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        // Application services
        services
            .AddDatabase(configuration)
            .AddUnitOfWork()
            .AddRepositories()
            .AddBusinessServices();

        services.AddSingleton(new MapperConfiguration(mc => mc.AddProfile(new RemesasProfile())).CreateMapper());

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
        });

        return services;
    }
}