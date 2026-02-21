using Common.Shared.DataStructures;
using FluentAssertions;
using Xunit;

namespace Common.Shared.Tests.DataStructures;

public class UniqueCollectionTests
{
    [Fact]
    public void Constructor_Should_InitializeValues_And_ThrowOnDuplicateKeys()
    {
        var action = () => CreateCollection(CreateEntity(1, "One"), CreateEntity(1, "One Duplicate"));

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Add_Should_AddElement_And_ContainsKey_Should_ReturnTrue()
    {
        var collection = CreateCollection();

        collection.Add(CreateEntity(1, "One"));

        collection.Count.Should().Be(1);
        collection.ContainsKey(1).Should().BeTrue();
        collection.Values.Select(e => e.Id).Should().Equal(1);
    }

    [Fact]
    public void Add_Should_Throw_When_KeyAlreadyExists()
    {
        var collection = CreateCollection(CreateEntity(1, "One"));

        var action = () => collection.Add(CreateEntity(1, "One Duplicate"));

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Contains_Should_ReturnTrue_When_KeyExists()
    {
        var collection = CreateCollection(CreateEntity(1, "One"));

        collection.Contains(CreateEntity(1, "DoesNotMatter")).Should().BeTrue();
    }

    [Fact]
    public void TryGetValue_Should_ReturnValue_When_KeyExists()
    {
        var collection = CreateCollection(CreateEntity(1, "One"));

        var result = collection.TryGetValue(1, out var value);

        result.Should().BeTrue();
        value.Should().NotBeNull();
        value.Id.Should().Be(1);
        value.Name.Should().Be("One");
    }

    [Fact]
    public void Remove_Should_RemoveElement_When_KeyExists()
    {
        var collection = CreateCollection(CreateEntity(1, "One"), CreateEntity(2, "Two"));

        var removed = collection.Remove(CreateEntity(2, "DoesNotMatter"));

        removed.Should().BeTrue();
        collection.ContainsKey(2).Should().BeFalse();
        collection.Values.Select(e => e.Id).Should().BeEquivalentTo([1]);
    }

    [Fact]
    public void RemoveMany_Should_RemoveAllByKey()
    {
        var collection = CreateCollection(
            CreateEntity(1, "One"),
            CreateEntity(2, "Two"),
            CreateEntity(3, "Three")
        );

        collection.RemoveMany(
        [
            CreateEntity(1, "X"),
            CreateEntity(3, "Y")
        ]);

        collection.Values.Select(e => e.Id).Should().BeEquivalentTo([2]);
    }

    [Fact]
    public void AddMany_Should_AddAllElements()
    {
        var collection = CreateCollection();

        collection.AddMany(
        [
            CreateEntity(1, "One"),
            CreateEntity(2, "Two")
        ]);

        collection.Values.Select(e => e.Id).Should().BeEquivalentTo([1, 2]);
    }

    [Fact]
    public void Clear_Should_RemoveAllElements()
    {
        var collection = CreateCollection(CreateEntity(1, "One"));

        collection.Clear();

        collection.Should().BeEmpty();
        collection.Count.Should().Be(0);
    }

    private record Entity(int Id, string Name);

    private static Entity CreateEntity(int id, string name) => new(id, name);

    private static UniqueCollection<int, Entity> CreateCollection(params Entity[] entities) =>
        new(e => e.Id, entities);
}