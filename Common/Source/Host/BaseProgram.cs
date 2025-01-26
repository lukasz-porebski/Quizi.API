using Autofac.Extensions.DependencyInjection;
using Common.Infrastructure.Database.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using static Microsoft.Extensions.Hosting.Host;

namespace Common.Host;

public abstract class BaseProgram<TStartup, TAssemblies, TDbContext>
    where TStartup : BaseStartup<TAssemblies, TDbContext>
    where TAssemblies : BaseAssemblies
    where TDbContext : BaseDbContext
{
    protected static void MainCore(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateBootstrapLogger();

        try
        {
            Log.Information("Starting up");
            CreateHostBuilder(args).Build().Run();
            Log.Information("Started");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application start-up failed");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<TStartup>(); });
}