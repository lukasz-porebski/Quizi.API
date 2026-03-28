using System.Reflection;
using Application.Contracts.Modules.Users.Commands;
using Application.Modules.Users.CommandHandlers;
using Domain.Modules.Users.Models;
using Infrastructure.Database;
using Infrastructure.Endpoints.Modules.Users;
using Infrastructure.ReadModels.Modules.Quizzes;
using LP.Common.Host;

namespace Host;

public class AppAssemblies : BaseAssemblies
{
    public override Assembly Application => typeof(CreateUserCommandHandler).Assembly;
    public override Assembly ApplicationContracts => typeof(CreateUserCommand).Assembly;
    public override Assembly Domain => typeof(User).Assembly;
    public override Assembly DomainContracts => typeof(UserRole).Assembly;
    public override Assembly? Infrastructure => null;
    public override Assembly InfrastructureDatabaseEf => typeof(AppDbContext).Assembly;
    public override Assembly InfrastructureEndpoints => typeof(UserController).Assembly;
    public override IReadOnlyCollection<Assembly> InfrastructureIntegrations => [];
    public override Assembly InfrastructureReadModels => typeof(QuizzesReadModel).Assembly;
    public override Assembly Host => typeof(Program).Assembly;
}