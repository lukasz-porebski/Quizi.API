using Common.Infrastructure.Endpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Common.Host.Configs;

internal static class SimpleServiceCollectionConfig
{
    public static IServiceCollection AddCqrs(this IServiceCollection services, BaseAssemblies assemblies)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(assemblies.Application); });
        services.AddTransient<IGate, Gate>();
        return services;
    }

    public static IServiceCollection AddLogger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSerilog((serviceProvider, lc) => lc.ReadFrom.Configuration(configuration));
        return services;
    }
}