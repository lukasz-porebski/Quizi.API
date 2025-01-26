using Common.Host;
using Infrastructure.Database;

namespace Host;

public class Program : BaseProgram<Startup, Assemblies, AppDbContext>
{
    public static void Main(string[] args) =>
        MainCore(args);
}