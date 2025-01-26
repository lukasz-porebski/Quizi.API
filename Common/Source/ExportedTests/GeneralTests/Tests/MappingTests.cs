using AutoMapper;
using Xunit;

namespace Common.GeneralTests.Tests;

public partial class BaseGeneralTests
{
    [Fact]
    public void Mappings_Should_BeValid()
    {
        var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddMaps(_assemblies.InfrastructureEndpoints); });

        var mapper = new Mapper(mapperConfiguration);

        mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }
}