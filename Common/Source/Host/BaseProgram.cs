using System.Globalization;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common.Host.Configs;
using Common.Host.Middlewares;
using Common.Infrastructure.Database.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Common.Host;

public abstract class BaseProgram<TAssemblies, TDbContext>
    where TAssemblies : BaseAssemblies
    where TDbContext : BaseDbContext
{
    protected abstract TAssemblies Assemblies { get; }

    protected static async Task MainCore<TProgram>(string[] args)
        where TProgram : BaseProgram<TAssemblies, TDbContext>, new()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
            .CreateBootstrapLogger();

        try
        {
            Console.WriteLine("ℹ️ Starting up");
            var app = await new TProgram().BuildAsync(args);
            Console.WriteLine("ℹ️ Host built");
            await app.RunAsync();
            Console.WriteLine("✅ Started");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Application start-up failed: {ex}");
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }

    protected virtual void ConfigureConfiguration(IConfigurationBuilder config, IHostEnvironment env)
    {
        config.Sources.Clear();

        config
            .SetBasePath(env.ContentRootPath)
            .AddEnvironmentVariables()
            .AddJsonFile("Configs/appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"Configs/appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

        if (env.IsDevelopment())
            config.AddJsonFile("Configs/appsettings.Development.Secrets.json", optional: false, reloadOnChange: true);
    }

    protected virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks();
        services
            .AddCors(configuration)
            .AddMvc(Assemblies)
            .AddCustomLocalization()
            .AddLogger(configuration)
            .AddSwagger(configuration)
            .AddMapper(Assemblies)
            .AddCqrs(Assemblies)
            .AddIdentity(configuration)
            .AddEf<TDbContext>(configuration)
            .AddRateLimiting(configuration);
    }

    protected virtual Task ConfigureAppAsync(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
            app.UseDeveloperExceptionPage();
        else
            app.UseHsts();

        app.UseLogging()
            .UseHttpsRedirection()
            .UseLocalization()
            .UseCustomSwagger(app.Configuration)
            .UsePathBase("/api")
            .UseRouting()
            .UseCustomCors()
            .UseMiddleware<ErrorHandlerMiddleware>()
            .UseIdentity()
            .UseRateLimiter();

        app.MapHealthChecks("/health");
        app.MapControllers();

        app.UseAutoMigration<TDbContext>();

        return Task.CompletedTask;
    }

    protected virtual void ConfigureContainer(ContainerBuilder builder, IConfiguration configuration) =>
        builder
            .RegisterConfiguration(configuration)
            .RegisterMiddlewares()
            .RegisterProviders(Assemblies)
            .RegisterRepositories(Assemblies)
            .RegisterServices(Assemblies)
            .RegisterFactories(Assemblies)
            .RegisterLocalization()
            .RegisterIdentity<TDbContext>()
            .RegisterUtils()
            .RegisterReadModels(Assemblies)
            .RegisterSeeders(Assemblies)
            .RegisterReadonlyDbContext<TDbContext>(Assemblies);

    private async Task<WebApplication> BuildAsync(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureConfiguration(builder.Configuration, builder.Environment);
        ConfigureServices(builder.Services, builder.Configuration);

        builder.Host
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(containerBuilder =>
                ConfigureContainer(containerBuilder, builder.Configuration));

        var app = builder.Build();
        await ConfigureAppAsync(app);
        return app;
    }
}