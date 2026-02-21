using Common.Shared.Extensions;
using FluentAssertions;
using Xunit;

namespace Common.Shared.Tests.Extensions;

public class ReadOnlyCollectionTests
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

        var diffs = current.GetDifferences(c => c.Id, target, t => t.Id);

        diffs.ToRemove.Values.Select(e => e.Id).Should().Equal(1);
        diffs.ToAdd.Values.Select(e => e.Id).Should().Equal(4);

        diffs.Existing.Keys.Should().BeEquivalentTo([2, 3]);
        diffs.Existing[2].Current.Id.Should().Be(2);
        diffs.Existing[2].Current.Name.Should().Be("Two");
        diffs.Existing[2].Target.Id.Should().Be(2);
        diffs.Existing[2].Target.Name.Should().Be("Two New");
        diffs.Existing[3].Current.Id.Should().Be(3);
        diffs.Existing[3].Current.Name.Should().Be("Three");
        diffs.Existing[3].Target.Id.Should().Be(3);
        diffs.Existing[3].Target.Name.Should().Be("Three");
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

        var act = () => current.GetDifferences(c => c.Id, target, t => t.Id);

        act.Should().Throw<ArgumentException>();
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

        var act = () => current.GetDifferences(c => c.Id, target, t => t.Id);

        act.Should().Throw<ArgumentException>();
    }

    private record CurrentEntity(int Id, string Name);

    private record TargetEntity(int Id, string Name);
}