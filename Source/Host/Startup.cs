using Common.Host;
using Infrastructure.Database;

namespace Host;

public class Startup(IHostEnvironment env)
    : BaseStartup<Assemblies, AppDbContext>(env, new Assemblies());