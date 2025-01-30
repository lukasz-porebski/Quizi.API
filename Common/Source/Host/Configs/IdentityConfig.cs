using System.Text;
using Autofac;
using Common.Host.AppSettings;
using Common.Host.Extensions;
using Common.Identity;
using Common.Identity.Interfaces;
using Common.Infrastructure.Database.EF;
using Common.Shared.Providers;
using Common.Shared.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Common.Host.Configs;

internal static class IdentityConfig
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetOptions(BaseAppSettingsSections.Identity);
        var secretKey = Encoding.UTF8.GetBytes(settings.AccessTokenSecretKey);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = settings.Issuer,
                    ValidAudience = settings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey)
                };
            });

        services.AddAuthorization();

        return services;
    }

    public static IApplicationBuilder UseIdentity(this IApplicationBuilder builder)
    {
        builder.UseAuthentication();
        builder.UseAuthorization();

        return builder;
    }

    public static ContainerBuilder RegisterIdentity<TDbContext>(this ContainerBuilder builder)
        where TDbContext : BaseDbContext
    {
        builder
            .Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                return configuration.GetOptions(BaseAppSettingsSections.Identity);
            })
            .AsImplementedInterfaces()
            .SingleInstance();

        builder
            .Register(context => new IdentityService<TDbContext>(
                context.Resolve<IIdentityConfiguration>(),
                context.Resolve<IDateTimeProvider>(),
                context.Resolve<IValidateUserCredentialsService>(),
                context.Resolve<TDbContext>(),
                context.Resolve<IHasher>()
            ))
            .AsImplementedInterfaces();

        return builder;
    }
}