using Common.Shared.DataStructures;
using Common.Shared.Extensions;
using FluentAssertions;
using Xunit;

namespace Common.Shared.Tests.Extensions;

public class UniqueCollectionExtensionsTests
{
    [Fact]
    public void GetDifferencesMethod_Should_ReturnToRemoveToAddAndExisting()
    {
        var currentsByKey = new UniqueCollection<int, CurrentEntity>(c => c.Id,
        [
            new CurrentEntity(1, "One"),
            new CurrentEntity(2, "Two"),
            new CurrentEntity(3, "Three")
        ]);
        var targetsByKey = new UniqueCollection<int, TargetEntity>(t => t.Id,
        [
            new TargetEntity(2, "Two New"),
            new TargetEntity(3, "Three"),
            new TargetEntity(4, "Four")
        ]);

        var result = currentsByKey.GetDifferences(targetsByKey);

        result.ToRemove.Values.Select(e => e.Id).Should().Equal(1);
        result.ToAdd.Values.Select(e => e.Id).Should().Equal(4);
        result.Existing.Keys.Should().BeEquivalentTo([2, 3]);
        result.Existing[2].Current.Name.Should().Be("Two");
        result.Existing[2].Target.Name.Should().Be("Two New");
        result.Existing[3].Current.Name.Should().Be("Three");
        result.Existing[3].Target.Name.Should().Be("Three");
    }

    [Fact]
    public void ApplyChangesMethod_Should_RemoveAddAndUpdateElements()
    {
        var currentsByKey = new UniqueCollection<int, CurrentEntity>(c => c.Id,
        [
            new CurrentEntity(1, "One"),
            new CurrentEntity(2, "Two"),
            new CurrentEntity(3, "Three")
        ]);
        var targetsByKey = new UniqueCollection<int, TargetEntity>(t => t.Id,
        [
            new TargetEntity(2, "Two Updated"),
            new TargetEntity(3, "Three"),
            new TargetEntity(4, "Four")
        ]);

        var result = currentsByKey.ApplyChanges(
            targetsByKey,
            adding: t => new CurrentEntity(t.Id, t.Name),
            updating: (c, t) => c.Name = t.Name,
            requireUpdate: (c, t) => c.Name != t.Name);

        result.Removed.Values.Select(e => e.Id).Should().Equal(1);
        result.Added.Values.Select(e => e.Id).Should().Equal(4);
        result.Updated.Values.Select(e => e.Id).Should().Equal(2);
        currentsByKey.Values.Select(e => e.Id).Should().BeEquivalentTo([2, 3, 4]);
        currentsByKey.Values.Single(e => e.Id == 2).Name.Should().Be("Two Updated");
        currentsByKey.Values.Single(e => e.Id == 4).Name.Should().Be("Four");
    }

    [Fact]
    public void ApplyChangesMethod_Should_WorkForOverload_WithTargetsEnumerable()
    {
        var currentsByKey = new UniqueCollection<int, CurrentEntity>(c => c.Id,
        [
            new CurrentEntity(1, "One"),
            new CurrentEntity(2, "Two")
        ]);
        var targets = new[]
        {
            new TargetEntity(2, "Two"),
            new TargetEntity(3, "Three")
        };

        var result = currentsByKey.ApplyChanges(
            targets,
            keyTarget: t => t.Id,
            adding: t => new CurrentEntity(t.Id, t.Name),
            updating: (c, t) => c.Name = t.Name,
            requireUpdate: (c, t) => c.Name != t.Name);

        result.Removed.Values.Select(e => e.Id).Should().Equal(1);
        result.Added.Values.Select(e => e.Id).Should().Equal(3);
        result.Updated.Values.Should().BeEmpty();
        currentsByKey.Values.Select(e => e.Id).Should().BeEquivalentTo([2, 3]);
    }

    private record CurrentEntity(int Id, string Name)
    {
        public string Name { get; set; } = Name;
    }

    private record TargetEntity(int Id, string Name);
}