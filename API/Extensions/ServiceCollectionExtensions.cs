// <copyright file="ServiceCollectionExtensions.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

using API.Services.Remesas;

namespace API.Extensions;

/// <summary>
/// Extensions for services implementations.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
            .AddScoped<IRemesasRepository, RemesasRepository>();
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        return services
            .AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services
        , IConfiguration configuration)
    {
        return services.AddDbContext<EFContext>(options =>
                 options.UseSqlServer(configuration.GetSection("AppConfig:DefaultConnectionSqlServer").Value));
    }

    public static IServiceCollection AddBusinessServices(this IServiceCollection services
       )
    {
        return services
            .AddScoped<RemesaService>();
    }
}