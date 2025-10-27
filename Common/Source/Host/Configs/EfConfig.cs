﻿using Common.Host.AppSettings;
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
            Console.WriteLine(settings);

            var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

            Console.WriteLine($"🔗 ConnectionString: {JsonConvert.SerializeObject(dbContext.Database.GetDbConnection())}");

            var retry = 1;
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
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return builder;
    }
}