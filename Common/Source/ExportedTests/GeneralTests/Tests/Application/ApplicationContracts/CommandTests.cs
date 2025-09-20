using Common.Application.CQRS;
using Common.Host.Utils;
using Xunit;

namespace Common.GeneralTests.Tests;

public partial class BaseGeneralTests
{
    [Fact]
    public void CommandName_Should_EndWithCommandWord()
    {
        AssertInvalid(GetCommandTypes(), t => !t.Name.EndsWith("Command"));
    }

    [Fact]
    public void Command_Should_ExistsOnlyInApplicationContractsProject()
    {
        AssertInvalid(assemblies.GetAllTypes(excludeApplicationContracts: true), t => t.IsCommand());
    }

    [Fact]
    public void Command_Should_BeRecord()
    {
        AssertInvalid(GetCommandTypes(), t => !t.IsRecord());
    }

    [Fact]
    public void Command_Should_BePublic()
    {
        AssertInvalid(GetCommandTypes(), t => t.IsNotPublic);
    }

    [Fact]
    public void Command_Should_HasHandler()
    {
        AssertDeclarationHasImplementation(GetCommandTypes(), GetCommandHandlerTypes(), typeof(ICommandHandler<>));
    }

    [Fact]
    public void Command_Should_HasExactlyOneHandler()
    {
        AssertNumberOfDeclarationsAndImplementationsAreSame(GetCommandTypes(), GetCommandHandlerTypes());
    }

    private IEnumerable<Type> GetCommandTypes() =>
        assemblies.ApplicationContracts.GetTypes().Where(t => t.IsCommand());
}