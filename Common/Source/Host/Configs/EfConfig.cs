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

    public static IApplicationBuilder UseAutoMigration<TDbContext>(this IApplicationBuilder builder)
        where TDbContext : BaseDbContext
    {
        using var scope = builder.ApplicationServices.CreateScope();

        Console.WriteLine("✅ Starting app migration initialization...");

        var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

        Console.WriteLine($"🔗 ConnectionString: {JsonConvert.SerializeObject(dbContext.Database.GetDbConnection())}");

        // Skip migration in production if database is not accessible
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
        {
            try
            {
                dbContext.Database.CanConnect();
                Console.WriteLine("Database connection successful, proceeding with migration...");
            }
            catch
            {
                Console.WriteLine("Database not accessible, skipping migration for now...");
                return builder;
            }
        }

        var retry = 5;
        while (retry > 0)
        {
            try
            {
                dbContext.Database.Migrate();
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                retry--;
                if (retry == 0)
                    throw;

                Thread.Sleep(5000);
            }
        }

        Console.WriteLine($"End migration initialization");
        return builder;
    }
}