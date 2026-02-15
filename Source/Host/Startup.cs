using Common.Host;
using Host.StartupConfigs;
using Infrastructure.Database;

namespace Host;

public class Startup(IHostEnvironment env)
    : BaseStartup<Assemblies, AppDbContext>(env, new Assemblies())
{
    public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        base.Configure(app, env);

        app.UseSeeders().GetAwaiter().GetResult();
    }
}