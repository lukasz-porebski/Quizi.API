using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Common.Domain.Tests.Entities;

public class BaseAggregateRootTests
{
    private readonly AggregateId _testId = AggregateId.Generate();
    private readonly AggregateStateChangeInfo _testInfo = new(AggregateId.Generate(), DateTime.UtcNow);

    [Fact]
    public void Constructor_Should_SetIdCorrectly()
    {
        var aggregateWithId = new TestAggregateRoot(_testId);
        var aggregateWithoutId = new TestAggregateRoot();

        aggregateWithId.Id.Should().Be(_testId);
        aggregateWithoutId.Id.Should().BeNull();
    }

    [Fact]
    public void InitialState_Should_HaveDefaultValues()
    {
        var aggregate = new TestAggregateRoot();

        aggregate.CreationInto.Should().Be(AggregateStateChangeInfo.Empty);
        aggregate.UpdateInfo.Should().BeNull();
        aggregate.RemovalInfo.Should().BeNull();
        aggregate.Version.Should().Be(1);
    }

    [Fact]
    public void Init_Should_SetCreationInfo_And_Throw_When_AlreadyInitialized()
    {
        var aggregate = new TestAggregateRoot();

        aggregate.Init(_testInfo);

        aggregate.CreationInto.Should().Be(_testInfo);
        aggregate.Version.Should().Be(1);

        var action = () => aggregate.Init(_testInfo);
        action.Should().Throw<Exception>();
    }

    [Fact]
    public void Update_Should_SetUpdateInfo_IncrementVersion_And_Throw_When_NotInitialized()
    {
        var aggregate = new TestAggregateRoot();

        var action = () => aggregate.Update(_testInfo);
        action.Should().Throw<Exception>();

        aggregate.Init(_testInfo);
        aggregate.Update(_testInfo);
        
        aggregate.UpdateInfo.Should().Be(_testInfo);
        aggregate.Version.Should().Be(2);

        aggregate.Update(_testInfo);
        aggregate.Version.Should().Be(3);
    }

    [Fact]
    public void Remove_Should_SetRemovalInfo_And_Throw_When_AlreadyRemoved()
    {
        var aggregate = new TestAggregateRoot();
        aggregate.Init(_testInfo);

        aggregate.Remove(_testInfo);
        aggregate.RemovalInfo.Should().Be(_testInfo);

        var action = () => aggregate.Remove(_testInfo);
        action.Should().Throw<Exception>().WithMessage("Aggregate is already removed.");
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Equality_Should_WorkBasedOnId(bool sameId)
    {
        var id1 = sameId ? _testId : AggregateId.Generate();
        var id2 = sameId ? _testId : AggregateId.Generate();

        var aggregate1 = new TestAggregateRoot(id1);
        var aggregate2 = new TestAggregateRoot(id2);

        aggregate1.Equals(aggregate2).Should().Be(sameId);
        (aggregate1 == aggregate2).Should().Be(sameId);
        (aggregate1 != aggregate2).Should().Be(!sameId);
    }

    [Fact]
    public void Equality_Should_HandleNull_And_ReferenceCases()
    {
        var aggregate = new TestAggregateRoot(_testId);

        aggregate.Equals(null).Should().BeFalse();
        aggregate!.Equals(aggregate).Should().BeTrue();
        aggregate.Equals(new object()).Should().BeFalse();

        (aggregate == null).Should().BeFalse();
        (null == aggregate).Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_Should_BeBasedOnId()
    {
        var aggregate = new TestAggregateRoot(_testId);
        aggregate.GetHashCode().Should().Be(_testId.GetHashCode());
    }

    private class TestAggregateRoot : BaseAggregateRoot
    {
        public TestAggregateRoot(AggregateId id) : base(id)
        {
        }

        public TestAggregateRoot()
        {
        }
    }
}