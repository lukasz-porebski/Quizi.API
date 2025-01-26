using Common.Host.Utils;
using Xunit;

namespace Common.GeneralTests.Tests;

public partial class BaseGeneralTests
{
    [Fact]
    public void CommandHandlerName_Should_EndWithCommandHandlerWord()
    {
        AssertInvalid(GetCommandHandlerTypes(), t => !t.Name.EndsWith("CommandHandler"));
    }

    [Fact]
    public void CommandHandler_Should_ExistsOnlyInApplicationProject()
    {
        AssertInvalid(_assemblies.GetAllTypes(excludeApplication: true), t => t.IsCommandHandler());
    }

    [Fact]
    public void CommandHandler_Should_BeClass()
    {
        AssertInvalid(GetCommandHandlerTypes(), t => !t.IsClass);
    }

    [Fact]
    public void CommandHandler_Should_BePublic()
    {
        AssertInvalid(GetCommandHandlerTypes(), t => t.IsNotPublic);
    }

    private IEnumerable<Type> GetCommandHandlerTypes() =>
        _assemblies.Application.GetTypes().Where(t => t.IsCommandHandler());
}