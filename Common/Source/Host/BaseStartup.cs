using Autofac;
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
        Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("Configs/appsettings.Secrets.json", optional: false, reloadOnChange: true)
            .AddJsonFile(
                env.IsDevelopment() ? $"Configs/appsettings.{env.EnvironmentName}.json" : "Configs/appsettings.json",
                optional: false,
                reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

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
            .AddEf<TDbContext>(Configuration);
    }

    public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();
        else
            app.UseHsts();

        app.UseHttpsRedirection()
            .UseLogger()
            .UseLocalization()
            .UseCustomSwagger(Configuration)
            .UseRouting()
            .UseCustomCors()
            .UseMiddleware<ErrorHandlerMiddleware>()
            .UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

    public virtual void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterConfiguration(Configuration)
            .RegisterMiddlewares()
            .RegisterProviders(Assemblies)
            .RegisterRepositories(Assemblies)
            .RegisterServices(Assemblies)
            .RegisterLocalization();
    }
}