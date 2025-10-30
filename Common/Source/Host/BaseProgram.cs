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
            Console.WriteLine("ℹ️ Starting up");
            var host = CreateHostBuilder(args).Build();
            Console.WriteLine("ℹ️ Host built");
            host.Run();
            Console.WriteLine("✅ Started");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Application start-up failed: {ex}");
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