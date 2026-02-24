using System.Threading.RateLimiting;
using Common.Host.AppSettings;
using Common.Host.Extensions;
using Common.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Host.Configs;

internal static class RateLimiterConfig
{
    public static IServiceCollection AddRateLimiting(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRateLimiter(options =>
        {
            var settings = configuration.GetOptions(BaseAppSettingsSections.AuthRateLimiter);
            options.AddFixedWindowLimiter(IdentityConstants.RateLimiterPolicy, o =>
            {
                o.PermitLimit = settings.PermitLimit;
                o.Window = TimeSpan.FromMinutes(settings.WindowMinutes);
                o.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                o.QueueLimit = settings.QueueLimit;
            });

            options.RejectionStatusCode = 429;
        });

        return services;
    }
}