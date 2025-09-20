using AutoMapper;
using Common.Infrastructure.Endpoints;
using Microsoft.Extensions.DependencyInjection;
using MoreLinq.Extensions;

namespace Common.Host.Configs;

public static class MapperConfig
{
    public static Type[] GetProfileTypes(BaseAssemblies assemblies)
    {
        var assembliesWithProfiles = new[]
        {
            typeof(SharedProfile).Assembly,
            assemblies.InfrastructureEndpoints
        };

        var x = assembliesWithProfiles
            .Select(a => a.ExportedTypes)
            .SelectMany(a => a)
            .Where(t => t.IsSubclassOf(typeof(Profile)))
            .Distinct()
            .ToArray();

        return x;
    }

    internal static IServiceCollection AddMapper(this IServiceCollection services, BaseAssemblies assemblies)
    {
        services.AddAutoMapper(c =>
        {
            var types = GetProfileTypes(assemblies);
            types.ForEach(c.AddProfile);
        });
        return services;
    }
}