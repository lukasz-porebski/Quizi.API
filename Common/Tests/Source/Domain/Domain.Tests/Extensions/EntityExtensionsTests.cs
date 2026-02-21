using Common.Domain.Extensions;
using Common.Domain.Interfaces;
using Common.Domain.ValueObjects;
using Common.TestsCore;
using FluentAssertions;
using Xunit;

namespace Common.Domain.Tests.Extensions;

public class EntityExtensionsTests : BaseTest
{
    private const string Updated1 = "Updated1";
    private const string Updated2 = "Updated2";
    private const string New1 = "New1";
    private const string New2 = "New2";
    private const string New3 = "New3";

    [Fact]
    public void ApplyChanges_Should_UpdateExistingItems()
    {
        const string original1 = "Original1";
        const string original2 = "Original2";
        var current = new List<TestEntity>
        {
            new(new EntityNo(1), original1),
            new(new EntityNo(2), original2)
        };
        var target = new List<TestTargetEntity>
        {
            new(new EntityNo(1), Updated1),
            new(new EntityNo(2), Updated2)
        };
        var updatedItems = new List<(TestEntity Current, TestTargetEntity Target)>();

        void Updating(TestEntity c, TestTargetEntity t)
        {
            c.Name = t.Name;
            updatedItems.Add((c, t));
        }

        current.ApplyChanges(target, (no, t) => new TestEntity(no, t.Name), Updating);

        updatedItems.Count.Should().Be(2);
        current.Count.Should().Be(2);
        current[0].Name.Should().Be(Updated1);
        current[1].Name.Should().Be(Updated2);
    }

    [Fact]
    public void ApplyChanges_Should_AddNewItems_WhenTargetHasNullNo()
    {
        const string existing1 = "Existing1";
        var current = new List<TestEntity>
        {
            new(new EntityNo(1), existing1),
        };
        var target = new List<TestTargetEntity>
        {
            new(new EntityNo(1), existing1),
            new(null, New1),
            new(null, New2),
        };

        current.ApplyChanges(target, (no, t) => new TestEntity(no, t.Name), (c, t) => c.Name = t.Name);

        current.Count.Should().Be(3);
        current.Should().Contain(e => e.Name == existing1);
        current.Should().Contain(e => e.Name == New1);
        current.Should().Contain(e => e.Name == New2);
    }

    [Fact]
    public void ApplyChanges_Should_RemoveMissingItems()
    {
        const string keep1 = "Keep1";
        const string remove2 = "Remove2";

        var current = new List<TestEntity>
        {
            new(new EntityNo(1), keep1),
            new(new EntityNo(2), remove2),
            new(new EntityNo(3), remove2),
        };
        var target = new List<TestTargetEntity>
        {
            new(new EntityNo(1), keep1),
        };

        current.ApplyChanges(target, (no, t) => new TestEntity(no, t.Name), (c, t) => c.Name = t.Name);

        current.Count.Should().Be(1);
        current.Should().ContainSingle(e => e.No.ToInt() == 1 && e.Name == keep1);
    }

    [Fact]
    public void ApplyChanges_Should_RespectRequireUpdatePredicate()
    {
        const string original1 = "Original1";
        const string original2 = "Original2";

        var current = new List<TestEntity>
        {
            new(new EntityNo(1), original1),
            new(new EntityNo(2), original2),
        };
        var target = new List<TestTargetEntity>
        {
            new(new EntityNo(1), Updated1),
            new(new EntityNo(2), Updated2),
        };
        var updatedItems = new List<(TestEntity Current, TestTargetEntity Target)>();
        bool RequireUpdate(TestEntity c, TestTargetEntity t) => c.Name != t.Name;

        current.ApplyChanges(
            target,
            (no, t) => new TestEntity(no, t.Name),
            (c, t) =>
            {
                c.Name = t.Name;
                updatedItems.Add((c, t));
            },
            RequireUpdate);

        updatedItems.Count.Should().Be(2);
        current[0].Name.Should().Be(Updated1);
        current[1].Name.Should().Be(Updated2);
    }

    [Fact]
    public void ApplyChanges_Should_SkipUpdate_WhenRequireUpdateReturnsFalse()
    {
        const string same1 = "Same1";
        const string different2 = "Different2";
        var current = new List<TestEntity>
        {
            new(new EntityNo(1), same1),
            new(new EntityNo(2), different2),
        };
        var target = new List<TestTargetEntity>
        {
            new(new EntityNo(1), same1),
            new(new EntityNo(2), Updated2),
        };

        var updatedItems = new List<(TestEntity Current, TestTargetEntity Target)>();
        bool RequireUpdate(TestEntity c, TestTargetEntity t) => c.Name != t.Name;

        current.ApplyChanges(
            target,
            (no, t) => new TestEntity(no, t.Name),
            (c, t) =>
            {
                c.Name = t.Name;
                updatedItems.Add((c, t));
            },
            RequireUpdate);

        updatedItems.Count.Should().Be(1);
        current[0].Name.Should().Be(same1);
        current[1].Name.Should().Be(Updated2);
    }

    [Fact]
    public void ApplyChanges_Should_WorkWithEmptyCollections()
    {
        var current = new List<TestEntity>();
        var target = new List<TestTargetEntity>
        {
            new(null, New1),
            new(null, New2),
        };

        current.ApplyChanges(target, (no, t) => new TestEntity(no, t.Name), (c, t) => c.Name = t.Name);

        current.Count.Should().Be(2);
        current.Should().Contain(e => e.Name == New1);
        current.Should().Contain(e => e.Name == New2);
    }

    [Fact]
    public void ApplyChanges_Should_WorkWithEmptyTarget()
    {
        const string remove1 = "Remove1";
        const string remove2 = "Remove2";

        var current = new List<TestEntity>
        {
            new(new EntityNo(1), remove1),
            new(new EntityNo(2), remove2),
        };
        var target = new List<TestTargetEntity>();

        current.ApplyChanges(target, (no, t) => new TestEntity(no, t.Name), (c, t) => c.Name = t.Name);

        current.Should().BeEmpty();
    }

    [Fact]
    public void ApplyNew_Should_AddNewItemsWithSequentialNumbers()
    {
        const string existing1 = "Existing1";
        const string existing2 = "Existing2";

        var current = new List<TestEntity>
        {
            new(new EntityNo(1), existing1),
            new(new EntityNo(2), existing2)
        };
        var newData = new List<TestTargetEntity>
        {
            new(null, New1),
            new(null, New2),
            new(null, New3)
        };

        current.ApplyNew(newData, (no, t) => new TestEntity(no, t.Name));

        current.Count.Should().Be(5);
        current.Should().Contain(e => e.Name == existing1 && e.No.ToInt() == 1);
        current.Should().Contain(e => e.Name == existing2 && e.No.ToInt() == 2);
        current.Should().Contain(e => e.Name == New1);
        current.Should().Contain(e => e.Name == New2);
        current.Should().Contain(e => e.Name == New3);

        var newItems = current.Where(e => e.Name.StartsWith("New")).OrderBy(e => e.No).ToList();
        newItems[0].No.ToInt().Should().BeGreaterThan(2);
        newItems[1].No.ToInt().Should().Be(newItems[0].No.ToInt() + 1);
        newItems[2].No.ToInt().Should().Be(newItems[1].No.ToInt() + 1);
    }

    [Fact]
    public void ApplyNew_Should_WorkWithEmptyCurrentCollection()
    {
        const string first = "First";
        const string second = "Second";

        var current = new List<TestEntity>();
        var newData = new List<TestTargetEntity>
        {
            new(null, first),
            new(null, second)
        };

        current.ApplyNew(newData, (no, t) => new TestEntity(no, t.Name));

        current.Count.Should().Be(2);
        current.Should().Contain(e => e.Name == first);
        current.Should().Contain(e => e.Name == second);

        var items = current.OrderBy(e => e.No).ToList();
        items[0].No.ToInt().Should().BeGreaterThan(0);
        items[1].No.ToInt().Should().Be(items[0].No.ToInt() + 1);
    }

    [Fact]
    public void NextNo_Should_ReturnNextNumber_WhenCollectionHasItems()
    {
        const string item1 = "Item1";
        const string item2 = "Item2";
        const string item3 = "Item3";

        var current = new List<TestEntity>
        {
            new(new EntityNo(1), item1),
            new(new EntityNo(3), item2),
            new(new EntityNo(2), item3)
        };

        var nextNo = current.NextNo();

        nextNo.ToInt().Should().BeGreaterThan(3);
    }

    [Fact]
    public void NextNo_Should_ReturnGeneratedNumber_WhenCollectionIsEmpty()
    {
        var current = new List<TestEntity>();

        var nextNo = current.NextNo();

        nextNo.ToInt().Should().BeGreaterThan(0);
    }

    [Fact]
    public void NextNo_Should_WorkWithSingleItem()
    {
        const string singleItem = "SingleItem";

        var current = new List<TestEntity>
        {
            new(new EntityNo(5), singleItem)
        };

        var nextNo = current.NextNo();

        nextNo.ToInt().Should().BeGreaterThan(5);
    }

    private record TestEntity(EntityNo No, string Name) : IUpdateableEntity
    {
        public EntityNo No { get; } = No;
        public string Name { get; set; } = Name;
    }

    private record TestTargetEntity(EntityNo? No, string Name) : IPersistableEntity
    {
        public EntityNo? No { get; } = No;
        public string Name { get; } = Name;
    }
}