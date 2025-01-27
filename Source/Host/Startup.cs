using Autofac;
using Common.Host;
using Host.StartupConfigs;
using Infrastructure.Database;

namespace Host;

public class Startup(IHostEnvironment env)
    : BaseStartup<Assemblies, AppDbContext>(env, new Assemblies())
{
    public override void ConfigureContainer(ContainerBuilder builder)
    {
        base.ConfigureContainer(builder);

        builder.RegisterUtils();
    }
}