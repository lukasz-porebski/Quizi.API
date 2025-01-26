using Microsoft.AspNetCore.Builder;
using Serilog;

namespace Common.Host.Configs;

internal static class SimpleApplicationBuilderConfig
{
    public static IApplicationBuilder UseLogger(this IApplicationBuilder builder)
    {
        builder.UseSerilogRequestLogging();
        return builder;
    }
}