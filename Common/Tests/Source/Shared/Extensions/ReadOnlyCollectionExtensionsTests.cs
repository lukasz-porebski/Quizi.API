using Common.Shared.Extensions;
using FluentAssertions;
using Xunit;

namespace Common.Shared.Tests.Extensions;

public class ReadOnlyCollectionExtensionsTests
{
    [Fact]
    public void GetDifferencesMethod_Should_ReturnToRemoveToAddAndExisting()
    {
        var current = new[]
        {
            new CurrentEntity(1, "One"),
            new CurrentEntity(2, "Two"),
            new CurrentEntity(3, "Three")
        };

        var target = new[]
        {
            new TargetEntity(2, "Two New"),
            new TargetEntity(3, "Three"),
            new TargetEntity(4, "Four")
        };

        var result = current.GetDifferences(c => c.Id, target, t => t.Id);

        result.ToRemove.Values.Select(e => e.Id).Should().Equal(1);
        result.ToAdd.Values.Select(e => e.Id).Should().Equal(4);

        result.Existing.Keys.Should().BeEquivalentTo([2, 3]);
        result.Existing[2].Current.Id.Should().Be(2);
        result.Existing[2].Current.Name.Should().Be("Two");
        result.Existing[2].Target.Id.Should().Be(2);
        result.Existing[2].Target.Name.Should().Be("Two New");
        result.Existing[3].Current.Id.Should().Be(3);
        result.Existing[3].Current.Name.Should().Be("Three");
        result.Existing[3].Target.Id.Should().Be(3);
        result.Existing[3].Target.Name.Should().Be("Three");
    }

    [Fact]
    public void GetDifferencesMethod_Should_Throw_When_CurrentContainsDuplicateKeys()
    {
        var current = new[]
        {
            new CurrentEntity(1, "One"),
            new CurrentEntity(1, "One Duplicate")
        };
        var target = new[] { new TargetEntity(1, "One") };

        var action = () => current.GetDifferences(c => c.Id, target, t => t.Id);

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GetDifferencesMethod_Should_Throw_When_TargetContainsDuplicateKeys()
    {
        var current = new[] { new CurrentEntity(1, "One") };
        var target = new[]
        {
            new TargetEntity(1, "One"),
            new TargetEntity(1, "One Duplicate")
        };

        var action = () => current.GetDifferences(c => c.Id, target, t => t.Id);

        action.Should().Throw<ArgumentException>();
    }

    private record CurrentEntity(int Id, string Name);

    private record TargetEntity(int Id, string Name);
}