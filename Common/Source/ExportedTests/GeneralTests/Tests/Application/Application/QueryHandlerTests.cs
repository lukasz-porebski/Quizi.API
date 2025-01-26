using Common.Host.Utils;
using Xunit;

namespace Common.GeneralTests.Tests;

public partial class BaseGeneralTests
{
    [Fact]
    public void QueryHandlerName_Should_EndWithQueryHandlerWord()
    {
        AssertInvalid(GetQueryHandlerTypes(), t => !t.Name.EndsWith("QueryHandler"));
    }

    [Fact]
    public void QueryHandler_Should_ExistsOnlyInApplicationProject()
    {
        AssertInvalid(_assemblies.GetAllTypes(excludeApplication: true), t => t.IsQueryHandler());
    }

    [Fact]
    public void QueryHandler_Should_BeClass()
    {
        AssertInvalid(GetQueryHandlerTypes(), t => !t.IsClass);
    }

    [Fact]
    public void QueryHandler_Should_BePublic()
    {
        AssertInvalid(GetQueryHandlerTypes(), t => t.IsNotPublic);
    }

    private IEnumerable<Type> GetQueryHandlerTypes() =>
        _assemblies.Application.GetTypes().Where(t => t.IsQueryHandler());
}