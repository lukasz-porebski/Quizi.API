using Common.Host.AppSettings;
using Common.Host.Extensions;
using Common.Infrastructure.Database.EF;
using Common.Infrastructure.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Common.Host.Configs;

internal static class SimpleServiceCollectionConfig
{
    public static IServiceCollection AddEf<TDbContext>(this IServiceCollection services, IConfiguration configuration)
        where TDbContext : BaseDbContext
    {
        services.AddDbContext<TDbContext>(options =>
        {
            var settings = configuration.GetOptions(BaseAppSettingsSections.Database);
            options.UseSqlServer(settings.ConnectionString);
        });
        return services;
    }

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