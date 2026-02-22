using Common.Domain.ValueObjects;
using Common.TestsCore;
using Domain.Shared.Interfaces;
using Domain.Shared.Specifications;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Shared.Specifications;

public class OwnerSpecificationTests : BaseTest
{
    private readonly OwnerSpecification _specification = new();

    [Fact]
    public void IsValid_Should_ReturnTrue_When_OwnerId_Equals_UserId()
    {
        var id = new AggregateId(Guid.NewGuid());

        var result = _specification.IsValid(new TestObject(id, id));

        result.Should().BeTrue();
    }

    [Fact]
    public void IsValid_Should_ReturnFalse_When_OwnerId_DoesNotEqual_UserId()
    {
        var ownerId = new AggregateId(Guid.NewGuid());
        var userId = new AggregateId(Guid.NewGuid());

        var result = _specification.IsValid(new TestObject(ownerId, userId));

        result.Should().BeFalse();
    }

    private sealed record TestObject(AggregateId OwnerId, AggregateId UserId) : IOwnerSpecification;
}