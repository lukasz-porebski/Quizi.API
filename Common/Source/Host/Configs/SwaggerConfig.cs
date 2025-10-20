using Common.Host.AppSettings;
using Common.Host.AppSettings.Sections;
using Common.Host.Extensions;
using Common.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Common.Host.Configs;

internal static class SwaggerConfig
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<SwaggerSettings>(configuration.GetSection(BaseAppSettingsSections.Swagger.Name));
        var settings = configuration.GetOptions(BaseAppSettingsSections.Swagger);

        if (!settings.Enabled)
            return services;

        return services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(settings.Name, new OpenApiInfo { Title = settings.Title, Version = settings.Version });
            c.AddServer(new OpenApiServer { Url = "/api" });

            if (!settings.IncludeSecurity)
                return;

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    []
                }
            });
        });
    }

    public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder builder, IConfiguration configuration)
    {
        var options = configuration.GetOptions(BaseAppSettingsSections.Swagger);
        if (!options.Enabled)
            return builder;

        var routePrefix = options.RoutePrefix.IsEmpty()
            ? BaseAppSettingsSections.Swagger.Name
            : options.RoutePrefix;

        builder.UseStaticFiles()
            .UseSwagger(c => c.RouteTemplate = routePrefix + "/{documentName}/swagger.json");

        return options.ReDocEnabled
            ? builder.UseReDoc(c =>
            {
                c.RoutePrefix = routePrefix;
                c.SpecUrl = $"{options.Name}/swagger.json";
            })
            : builder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{routePrefix}/{options.Name}/swagger.json", options.Title);
                c.RoutePrefix = routePrefix;
            });
    }
}