using Common.Host.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace Common.Host.Configs;

internal static class LoggerConfig
{
    public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
    {
        builder.UseSerilogRequestLogging(options =>
        {
            options.EnrichDiagnosticContext = (context, http) =>
            {
                if (http.TryGetUserId(out var userId))
                    context.Set("UserId", userId.ToString());
            };

            options.GetLevel = (http, _, ex) => ex != null || http.Response.StatusCode >= 500
                ? LogEventLevel.Error
                : http.Response.StatusCode >= 400
                    ? LogEventLevel.Warning
                    : LogEventLevel.Information;
        });

        return builder;
    }

    public static IServiceCollection AddLogger(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSerilog((_, lc) =>
        {
            lc.ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext();
        });

        return services;
    }
}