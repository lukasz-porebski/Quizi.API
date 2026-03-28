using Host.StartupConfigs;
using Infrastructure.Database;
using LP.Common.Host;

namespace Host;

public class Program : BaseProgram<AppAssemblies, AppDbContext>
{
    protected override AppAssemblies Assemblies => new();

    public static async Task Main(string[] args) =>
        await MainCore<Program>(args);

    protected override async Task ConfigureAppAsync(WebApplication app)
    {
        await base.ConfigureAppAsync(app);
        await app.UseSeeders();
    }
}