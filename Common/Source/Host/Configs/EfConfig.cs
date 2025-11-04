using Common.Host.AppSettings;
using Common.Host.Extensions;
using Common.Infrastructure.Database.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Common.Host.Configs;

public static class EfConfig
{
    public static DbContextOptionsBuilder UsePostgreSql(this DbContextOptionsBuilder builder, string connectionString)
    {
        builder.UseNpgsql(connectionString).UseLowerCaseNamingConvention();
        return builder;
    }

    internal static IServiceCollection AddEf<TDbContext>(this IServiceCollection services, IConfiguration configuration)
        where TDbContext : BaseDbContext
    {
        services.AddDbContext<TDbContext>(options =>
        {
            var settings = configuration.GetOptions(BaseAppSettingsSections.Database);
            options.UsePostgreSql(settings.ConnectionString);
        });
        return services;
    }

    internal static IApplicationBuilder UseAutoMigration<TDbContext>(this IApplicationBuilder builder)
        where TDbContext : BaseDbContext
    {
        using var scope = builder.ApplicationServices.CreateScope();

        try
        {
            Console.WriteLine("✅ Starting app migration initialization...");

            var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

            var delaysSeconds = new[] { 5, 10, 15 };
            for (var i = 0; i < delaysSeconds.Length; i++)
            {
                try
                {
                    dbContext.Database.Migrate();
                    Console.WriteLine("[EF MIGRATION] Success");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[EF MIGRATION] Attempt {i + 1} failed: {ex.Message}");
                    if (i == delaysSeconds.Length - 1)
                        throw;

                    Thread.Sleep(TimeSpan.FromSeconds(delaysSeconds[i]));
                }
            }

            Console.WriteLine("✅ End migration initialization");
        }
        catch (Exception e)
        {
            Console.WriteLine(JsonConvert.SerializeObject(e));
        }

        return builder;
    }
}