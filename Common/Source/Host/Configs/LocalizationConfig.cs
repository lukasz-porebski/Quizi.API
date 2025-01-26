using System.Globalization;
using Autofac;
using Common.Host.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Common.Host.Configs;

internal static class LocalizationConfig
{
    public static IServiceCollection AddCustomLocalization(this IServiceCollection services)
    {
        services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[]
            {
                new CultureInfo("pl-PL")
            };

            options.DefaultRequestCulture = new RequestCulture(supportedCultures.First());
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });

        return services;
    }

    public static IApplicationBuilder UseLocalization(this IApplicationBuilder builder)
    {
        var options = builder.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>()!;
        builder.UseRequestLocalization(options.Value);
        return builder;
    }

    public static ContainerBuilder RegisterLocalization(this ContainerBuilder builder)
    {
        builder.RegisterType<MessageProvider>().AsImplementedInterfaces().SingleInstance();
        return builder;
    }
}