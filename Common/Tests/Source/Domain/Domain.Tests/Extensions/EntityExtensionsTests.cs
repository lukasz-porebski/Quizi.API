using AutoFixture;
using Common.Domain.Interfaces;
using Common.Domain.ValueObjects;
using Common.TestsCore;
using FluentAssertions;
using Xunit;

namespace Common.Domain.Extensions;

public class EntityExtensionsTests : BaseTest
{
    [Fact]
    public void GetNextNoMethod_Should_ReturnEntityId_With_ValueGreaterByOneThanLargestCurrentlyEntityId()
    {
        var children = Fixture.CreateMany<TestEntity>().ToArray();
        var maxId = children.Max(c => c.No)!.ToInt();

        var result = children.NextNo();

        result.Should().Be(new EntityNo(maxId + 1));
    }

    private record TestEntity(EntityNo No) : IUpdateableEntity;
}