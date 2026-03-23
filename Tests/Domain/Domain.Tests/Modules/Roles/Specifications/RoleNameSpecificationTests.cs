using Common.Domain.ValueObjects;
using Common.TestsCore;
using Domain.Modules.Roles.Constants;
using Domain.Modules.Roles.Data;
using Domain.Modules.Roles.Specifications;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Modules.Roles.Specifications;

public class RoleNameSpecificationTests : BaseTest
{
    private readonly RoleNameSpecification _specification = new();

    [InlineData(1, true)]
    [InlineData(RoleConstants.MaxNameLength, true)]
    [InlineData(0, false)]
    [InlineData(RoleConstants.MaxNameLength + 1, false)]
    [Theory]
    public void RoleName_Should_BeValid_When_LengthIsInRange(int nameLength, bool expectedResult)
    {
        var data = new RoleCreationData(AggregateId.Generate(), FixtureString(nameLength), new HashSet<AggregateId>());

        var result = _specification.IsValid(data);

        result.Should().Be(expectedResult);
    }
}