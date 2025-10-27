using System.Net.Sockets;
using Common.Host.AppSettings;
using Common.Host.Extensions;
using Common.Infrastructure.Database.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Common.Host.Configs;

internal static class EfConfig
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

    public static IApplicationBuilder UseAutoMigration<TDbContext>(
        this IApplicationBuilder builder, IConfiguration configuration)
        where TDbContext : BaseDbContext
    {
        using var scope = builder.ApplicationServices.CreateScope();

        try
        {
            Console.WriteLine("✅ Starting app migration initialization...");

            var settings = configuration.GetOptions(BaseAppSettingsSections.Database);
            Console.WriteLine("✅ Settings");
            Console.WriteLine(JsonConvert.SerializeObject(settings));

            var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

            try
            {
                using var c = new TcpClient();
                c.Connect("127.0.0.1", 1433);
                Console.WriteLine("[TCP] 127.0.0.1:1433 reachable");
            }
            catch (Exception e)
            {
                Console.WriteLine($"[TCP] 127.0.0.1:1433 NOT reachable: {e.Message}");
            }

            var delaysSeconds = new[] { 5, 10, 20, 30, 30 };
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
                    if (i == delaysSeconds.Length - 1) throw;
                    Thread.Sleep(TimeSpan.FromSeconds(delaysSeconds[i]));
                }
            }

            Console.WriteLine($"End migration initialization");
        }
        catch (Exception e)
        {
            Console.WriteLine(JsonConvert.SerializeObject(e));
        }

        return builder;
    }
}