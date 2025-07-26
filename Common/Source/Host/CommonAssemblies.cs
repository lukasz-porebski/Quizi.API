using System.Reflection;
using System.Windows.Input;
using Common.Application.CQRS;
using Common.Domain.Contracts;
using Common.Domain.Entities;
using Common.Infrastructure.Database.EF;
using Common.Infrastructure.Endpoints;
using Common.Infrastructure.Integration;
using Common.Infrastructure.ReadModels.Dapper;

namespace Common.Host;

public class CommonAssemblies : BaseAssemblies
{
    public override Assembly Application => typeof(ICommandHandler<>).Assembly;
    public override Assembly ApplicationContracts => typeof(ICommand).Assembly;
    public override Assembly Domain => typeof(BaseAggregateRoot).Assembly;
    public override Assembly DomainContracts => typeof(Marker).Assembly;
    public override Assembly? Infrastructure => null;
    public override Assembly InfrastructureDatabaseEf => typeof(BaseDbContext).Assembly;
    public override Assembly InfrastructureEndpoints => typeof(BaseController).Assembly;
    public override IReadOnlyCollection<Assembly> InfrastructureIntegrations => [typeof(BaseApi).Assembly];
    public override Assembly InfrastructureReadModels => typeof(IDatabaseConnectionStringProvider).Assembly;
    public override Assembly Host => typeof(BaseAssemblies).Assembly;
}