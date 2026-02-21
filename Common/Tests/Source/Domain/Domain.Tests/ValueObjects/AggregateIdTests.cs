using FluentAssertions;
using Xunit;

namespace Common.Domain.ValueObjects;

public class AggregateIdTests
{
    [Fact]
    public void PassingEmptyGuidForAggregateIdCreation_Should_ThrowException()
    {
        var emptyGuid = Guid.Empty;

        Action action = () => new AggregateId(emptyGuid);

        action.Should().Throw<Exception>();
    }

    [Fact]
    public void PassingValidGuidForAggregateIdCreation_Should_CreateAggregateId()
    {
        var validGuid = Guid.NewGuid();

        var aggregateId = new AggregateId(validGuid);

        aggregateId.Should().NotBeNull();
    }

    [Theory]
    [MemberData(nameof(InvalidStrings))]
    public void PassingInvalidStringForAggregateIdCreation_Should_ThrowException(string invalidString)
    {
        Action action = () => new AggregateId(invalidString);

        action.Should().Throw<Exception>();
    }

    [Fact]
    public void PassingValidStringForAggregateIdCreation_Should_CreateAggregateId()
    {
        var validString = Guid.NewGuid().ToString();

        var aggregateId = new AggregateId(validString);

        aggregateId.Should().NotBeNull();
    }

    [Fact]
    public void ToGuidMethod_Should_ReturnCorrectGuid()
    {
        var validGuid = Guid.NewGuid();
        var aggregateId = new AggregateId(validGuid);

        var result = aggregateId.ToGuid();

        result.Should().Be(validGuid);
    }

    [Fact]
    public void ToStringMethod_Should_ReturnCorrectGuidAsString()
    {
        var validGuid = Guid.NewGuid();
        var aggregateId = new AggregateId(validGuid);

        var result = aggregateId.ToString();

        result.Should().Be(validGuid.ToString());
    }

    [Fact]
    public void EqualsMethod_Should_ReturnTrue_When_AggregateIdsAreEqual()
    {
        var guid = Guid.NewGuid();
        var aggregateId1 = new AggregateId(guid);
        var aggregateId2 = new AggregateId(guid);

        var result = aggregateId1.Equals(aggregateId2);

        result.Should().BeTrue();
    }

    [Fact]
    public void EqualsMethod_Should_ReturnFalse_When_AggregateIdsAreNotEqual()
    {
        var aggregateId1 = new AggregateId(Guid.NewGuid());
        var aggregateId2 = new AggregateId(Guid.NewGuid());

        var result = aggregateId1.Equals(aggregateId2);

        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsMethod_Should_ReturnTrue_When_ObjectIsAggregateId_And_IsEqual()
    {
        var guid = Guid.NewGuid();
        var aggregateId1 = new AggregateId(guid);
        var aggregateId2 = (object)new AggregateId(guid);

        var result = aggregateId1.Equals(aggregateId2);

        result.Should().BeTrue();
    }

    [Fact]
    public void EqualsMethod_Should_ReturnFalse_When_ObjectIsAggregateId_And_IsNotEqual()
    {
        var aggregateId1 = new AggregateId(Guid.NewGuid());
        var aggregateId2 = (object)new AggregateId(Guid.NewGuid());

        var result = aggregateId1.Equals(aggregateId2);

        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsMethod_Should_ReturnFalse_When_ObjectIsNotAggregateId()
    {
        var aggregateId = new AggregateId(Guid.NewGuid());
        var obj = new object();

        var result = aggregateId.Equals(obj);

        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsOperator_Should_ReturnTrue_When_AggregateIdsAreEqual()
    {
        var guid = Guid.NewGuid();
        var aggregateId1 = new AggregateId(guid);
        var aggregateId2 = new AggregateId(guid);

        var result = aggregateId1 == aggregateId2;

        result.Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_Should_ReturnFalse_When_AggregateIdsAreNotEqual()
    {
        var aggregateId1 = new AggregateId(Guid.NewGuid());
        var aggregateId2 = new AggregateId(Guid.NewGuid());

        var result = aggregateId1 == aggregateId2;

        result.Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_Should_ReturnFalse_When_AggregateIdsAreEqual()
    {
        var guid = Guid.NewGuid();
        var aggregateId1 = new AggregateId(guid);
        var aggregateId2 = new AggregateId(guid);

        var result = aggregateId1 != aggregateId2;

        result.Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_Should_ReturnTrue_When_AggregateIdsAreNotEqual()
    {
        var aggregateId1 = new AggregateId(Guid.NewGuid());
        var aggregateId2 = new AggregateId(Guid.NewGuid());

        var result = aggregateId1 != aggregateId2;

        result.Should().BeTrue();
    }

    [Fact]
    public void GenerateMethod_Should_ReturnNewAggregateId()
    {
        var result = AggregateId.Generate();

        result.Should().NotBeNull();
    }

    public static TheoryData<string> InvalidStrings() =>
    [
        "",
        " ",
        "text",
        Guid.Empty.ToString()
    ];
}