using System.Reflection;
using Application;
using Common.Host;
using Infrastructure.Database;

namespace Host;

public class Assemblies : BaseAssemblies
{
    public override Assembly Application => typeof(Marker).Assembly;
    public override Assembly ApplicationContracts => typeof(Application.Contracts.Marker).Assembly;
    public override Assembly Domain => typeof(Domain.Marker).Assembly;
    public override Assembly DomainContracts => typeof(Domain.Contracts.Marker).Assembly;
    public override Assembly InfrastructureDatabaseEf => typeof(AppDbContext).Assembly;
    public override Assembly InfrastructureEndpoints => typeof(Infrastructure.Endpoints.Marker).Assembly;
    public override IReadOnlyCollection<Assembly> InfrastructureIntegrations => [];
    public override Assembly Host => typeof(Program).Assembly;
}