using Common.Domain.ValueObjects;
using Common.TestsCore;
using Domain.Modules.Permissions.Constants;
using Domain.Modules.Permissions.Data;
using Domain.Modules.Permissions.Specifications;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Modules.Permissions.Specifications;

public class PermissionNameSpecificationTests : BaseTest
{
    private readonly PermissionNameSpecification _specification = new();

    [InlineData(1, true)]
    [InlineData(PermissionConstants.MaxNameLength, true)]
    [InlineData(0, false)]
    [InlineData(PermissionConstants.MaxNameLength + 1, false)]
    [Theory]
    public void PermissionName_Should_BeValid_When_LengthIsInRange(int nameLength, bool expectedResult)
    {
        var data = new PermissionCreationData(AggregateId.Generate(), FixtureString(nameLength));

        var result = _specification.IsValid(data);

        result.Should().Be(expectedResult);
    }
}