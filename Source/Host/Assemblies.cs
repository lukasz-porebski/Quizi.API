using System.Reflection;
using Application.Contracts.Modules.Users.Commands;
using Application.Modules.Users.CommandHandlers;
using Common.Host;
using Domain.Contracts.Modules.Users.Enums;
using Domain.Modules.Users.Models;
using Infrastructure.Database;
using Infrastructure.Endpoints.Modules.Users;
using Infrastructure.Modules.Users;

namespace Host;

public class Assemblies : BaseAssemblies
{
    public override Assembly Application => typeof(CreateUserCommandHandler).Assembly;
    public override Assembly ApplicationContracts => typeof(CreateUserCommand).Assembly;
    public override Assembly Domain => typeof(User).Assembly;
    public override Assembly DomainContracts => typeof(UserRole).Assembly;
    public override Assembly Infrastructure => typeof(PasswordHasher).Assembly;
    public override Assembly InfrastructureDatabaseEf => typeof(AppDbContext).Assembly;
    public override Assembly InfrastructureEndpoints => typeof(UserController).Assembly;
    public override IReadOnlyCollection<Assembly> InfrastructureIntegrations => [];
    public override Assembly Host => typeof(Program).Assembly;
}