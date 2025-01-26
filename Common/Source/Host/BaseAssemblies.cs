using System.Reflection;

namespace Common.Host;

public abstract class BaseAssemblies
{
    public abstract Assembly Application { get; }
    public abstract Assembly ApplicationContracts { get; }
    public abstract Assembly Domain { get; }
    public abstract Assembly DomainContracts { get; }
    public abstract Assembly InfrastructureDatabaseEf { get; }
    public abstract Assembly InfrastructureEndpoints { get; }
    public abstract IReadOnlyCollection<Assembly> InfrastructureIntegrations { get; }
    public abstract Assembly Host { get; }

    public IReadOnlyList<Type> GetAllTypes(
        bool excludeApplication = false,
        bool excludeApplicationContracts = false,
        bool excludeDomain = false,
        bool excludeDomainContracts = false,
        bool excludeInfrastructureDatabaseEf = false,
        bool excludeInfrastructureEndpoints = false,
        bool excludeInfrastructureIntegrations = false,
        bool excludeHost = false)
    {
        var result = new List<Type>();

        if (!excludeApplication)
            result.AddRange(Application.GetTypes());

        if (!excludeApplicationContracts)
            result.AddRange(ApplicationContracts.GetTypes());

        if (!excludeDomain)
            result.AddRange(Domain.GetTypes());

        if (!excludeDomainContracts)
            result.AddRange(DomainContracts.GetTypes());

        if (!excludeInfrastructureDatabaseEf)
            result.AddRange(InfrastructureDatabaseEf.GetTypes());

        if (!excludeInfrastructureEndpoints)
            result.AddRange(InfrastructureEndpoints.GetTypes());

        if (!excludeInfrastructureIntegrations)
            result.AddRange(InfrastructureIntegrations.SelectMany(i => i.GetTypes()));

        if (!excludeHost)
            result.AddRange(Host.GetTypes());

        return result;
    }
}