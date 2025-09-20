using AutoMapper;
using Common.Host.Configs;
using Microsoft.Extensions.Logging;
using Moq;
using MoreLinq;
using Xunit;

namespace Common.GeneralTests.Tests;

public partial class BaseGeneralTests
{
    [Fact]
    public void Mappings_Should_BeValid()
    {
        var mapperConfiguration = new MapperConfiguration(
            cfg =>
            {
                var types = MapperConfig.GetProfileTypes(assemblies);
                types.ForEach(cfg.AddProfile);
            },
            CreateLoggerFactoryMock());

        var mapper = new Mapper(mapperConfiguration);

        mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }

    private static ILoggerFactory CreateLoggerFactoryMock()
    {
        var logger = new Mock<ILogger>();

        var result = new Mock<ILoggerFactory>();
        result.Setup(m => m.CreateLogger(It.IsAny<string>())).Returns(logger.Object);

        return result.Object;
    }
}