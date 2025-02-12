using AutoMapper;
using Common.Host.Configs;
using Xunit;

namespace Common.GeneralTests.Tests;

public partial class BaseGeneralTests
{
    [Fact]
    public void Mappings_Should_BeValid()
    {
        var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddMaps(MapperConfig.GetAssemblies(_assemblies)));

        var mapper = new Mapper(mapperConfiguration);

        mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }
}