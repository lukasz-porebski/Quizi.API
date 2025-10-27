﻿using Autofac;
using Common.Host.Configs;
using Common.Host.Middlewares;
using Common.Infrastructure.Database.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Common.Host;

public abstract class BaseStartup<TAssemblies, TDbContext>
    where TAssemblies : BaseAssemblies
    where TDbContext : BaseDbContext
{
    protected BaseStartup(IHostEnvironment env, TAssemblies assemblies)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddEnvironmentVariables()
            .AddJsonFile(
                env.IsDevelopment() ? $"Configs/appsettings.{env.EnvironmentName}.json" : "Configs/appsettings.json",
                optional: false,
                reloadOnChange: true);

        if (env.IsDevelopment())
        {
            configurationBuilder = configurationBuilder
                .AddJsonFile("Configs/appsettings.Development.Secrets.json", optional: false, reloadOnChange: true);
        }

        Configuration = configurationBuilder.Build();

        Assemblies = assemblies;
    }

    protected IConfiguration Configuration { get; }
    protected TAssemblies Assemblies { get; }

    public virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(Configuration)
            .AddMvc(Assemblies)
            .AddCustomLocalization()
            .AddLogger(Configuration)
            .AddSwagger(Configuration)
            .AddMapper(Assemblies)
            .AddCqrs(Assemblies)
            .AddIdentity(Configuration)
            .AddEf<TDbContext>(Configuration);
    }

    public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UsePathBase("/api");
        }
        else
            app.UseHsts();

        app.UseLogger()
            .UseLocalization()
            .UseCustomSwagger(Configuration)
            .UseRouting()
            .UseCustomCors()
            .UseMiddleware<ErrorHandlerMiddleware>()
            .UseIdentity()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", () => "OK");
                endpoints.MapControllers();
            })
            .UseAutoMigration<TDbContext>(Configuration);
    }

    public virtual void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterConfiguration(Configuration)
            .RegisterMiddlewares()
            .RegisterProviders(Assemblies)
            .RegisterRepositories(Assemblies)
            .RegisterServices(Assemblies)
            .RegisterFactories(Assemblies)
            .RegisterLocalization()
            .RegisterIdentity<TDbContext>()
            .RegisterUtils()
            .RegisterReadModels(Assemblies);
    }
}