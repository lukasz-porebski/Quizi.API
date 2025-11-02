using Common.Infrastructure.Endpoints;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Host.Configs;

internal static class SimpleServiceCollectionConfig
{
    public static IServiceCollection AddCqrs(this IServiceCollection services, BaseAssemblies assemblies)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(assemblies.Application); });
        services.AddTransient<IGate, Gate>();
        return services;
    }
}