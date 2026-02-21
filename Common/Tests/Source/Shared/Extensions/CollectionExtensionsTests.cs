using Common.Shared.DataStructures;
using Common.Shared.Extensions;
using Common.TestsCore;
using FluentAssertions;
using Xunit;

namespace Common.Shared.Tests.Extensions;

public class CollectionExtensionsTests : BaseTest
{
    [Fact]
    public void SetMethod_Should_ReplaceAllElements()
    {
        var collection = new List<int> { 1, 2, 3 };
        var newElements = new[] { 4, 5, 6 };

        collection.Set(newElements);

        collection.Should().Equal(newElements);
    }

    [Fact]
    public void SetMethod_Should_ClearCollection_When_NewCollectionIsEmpty()
    {
        var collection = new List<int> { 1, 2, 3 };

        collection.Set([]);

        collection.Should().BeEmpty();
    }

    [Fact]
    public void RemoveManyMethod_Should_RemoveSpecifiedElements()
    {
        var collection = new List<int> { 1, 2, 3, 4, 5 };

        collection.RemoveMany([2, 4]);

        collection.Should().Equal(1, 3, 5);
    }

    [Fact]
    public void RemoveManyMethod_Should_NotModifyCollection_When_ElementsDoNotExist()
    {
        var collection = new List<int> { 1, 2, 3 };

        collection.RemoveMany([4, 5]);

        collection.Should().Equal(1, 2, 3);
    }

    [Fact]
    public void AddManyMethod_Should_AddAllElements()
    {
        var collection = new List<int> { 1, 2, 3 };

        collection.AddMany([4, 5, 6]);

        collection.Should().Equal(1, 2, 3, 4, 5, 6);
    }

    [Fact]
    public void ApplyChangesMethod_Should_ReturnAddedElements()
    {
        var currents = new List<TestEntity>
        {
            new(1, "One"),
            new(2, "Two")
        };
        var targets = new[]
        {
            new TestDto(1, "One"),
            new TestDto(2, "Two"),
            new TestDto(3, "Three")
        };

        var result = ApplyChanges(currents, targets);

        result.Added.Should().ContainSingle();
        result.Added.Should().Contain(e => e.Id == 3 && e.Name == "Three");
    }

    [Fact]
    public void ApplyChangesMethod_Should_ReturnRemovedElements()
    {
        var currents = new List<TestEntity>
        {
            new(1, "One"),
            new(2, "Two"),
            new(3, "Three")
        };
        var targets = new[]
        {
            new TestDto(1, "One"),
            new TestDto(2, "Two")
        };

        var result = ApplyChanges(currents, targets);

        result.Removed.Should().ContainSingle();
        result.Removed.Should().Contain(e => e.Id == 3 && e.Name == "Three");
    }

    [Fact]
    public void ApplyChangesMethod_Should_ReturnUpdatedElements()
    {
        var currents = new List<TestEntity>
        {
            new(1, "One"),
            new(2, "Two")
        };
        var targets = new[]
        {
            new TestDto(1, "One Updated"),
            new TestDto(2, "Two")
        };

        var result = ApplyChanges(currents, targets);

        result.Updated.Should().ContainSingle();
        result.Updated.Should().Contain(e => e.Id == 1 && e.Name == "One Updated");
    }

    [Fact]
    public void ApplyChangesMethod_Should_NotUpdateElements_When_NoChangesDetected()
    {
        var currents = new List<TestEntity>
        {
            new(1, "One"),
            new(2, "Two")
        };
        var targets = new[]
        {
            new TestDto(1, "One"),
            new TestDto(2, "Two")
        };

        var result = ApplyChanges(currents, targets);

        result.Updated.Should().BeEmpty();
    }

    private static CollectionChanges<TestEntity, TestDto, int> ApplyChanges(
        List<TestEntity> currents,
        TestDto[] targets) =>
        currents.ApplyChanges(
            targets,
            c => c.Id,
            t => t.Id,
            t => new TestEntity(t.Id, t.Name),
            (c, t) => c.Name = t.Name,
            (c, t) => c.Name != t.Name);

    private record TestEntity(int Id, string Name)
    {
        public string Name { get; set; } = Name;
    }

    private record TestDto(int Id, string Name);
}