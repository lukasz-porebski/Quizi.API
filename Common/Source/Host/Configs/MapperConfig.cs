using System.Reflection;
using Common.Infrastructure.Endpoints;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Host.Configs;

public static class MapperConfig
{
    public static Assembly[] GetAssemblies(BaseAssemblies assemblies) =>
        [typeof(SharedProfile).Assembly, assemblies.InfrastructureEndpoints];

    internal static IServiceCollection AddMapper(this IServiceCollection services, BaseAssemblies assemblies)
    {
        services.AddAutoMapper(GetAssemblies(assemblies));
        return services;
    }
}