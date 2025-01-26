using Common.GeneralTests.Shared;
using Common.Host;

namespace Common.GeneralTests.Tests;

public abstract partial class BaseGeneralTests(BaseAssemblies assemblies) : BaseExternalTests
{
    private readonly BaseAssemblies _assemblies = assemblies;
}