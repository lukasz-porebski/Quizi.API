using Common.Host.AppSettings;
using Common.Host.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Host.Configs;

internal static class CorsConfig
{
    private const string Origin = "appAllowedOrigin";

    public static IServiceCollection AddCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            var settings = configuration.GetOptions(BaseAppSettingsSections.Main);
            options.AddPolicy(Origin, builder =>
            {
                builder.WithOrigins(settings.CorsOrigin)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return services;
    }

    public static IApplicationBuilder UseCustomCors(this IApplicationBuilder builder)
    {
        builder.UseCors(Origin);

        return builder;
    }
}