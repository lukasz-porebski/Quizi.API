using AutoFixture;
using Common.Shared.Extensions;
using Common.TestsCore;
using FluentAssertions;
using Xunit;

namespace Common.Shared.Tests.Extensions;

public class EnumerableExtensionsTests : BaseTest
{
    [Fact]
    public void IsEmptyMethod_Should_ReturnTrue_When_CollectionIsNull()
    {
        IEnumerable<object>? data = null;

        var result = data.IsEmpty();

        result.Should().BeTrue();
    }

    [Fact]
    public void IsEmptyMethod_Should_ReturnTrue_When_NotContainElements()
    {
        var data = Enumerable.Empty<object>();

        var result = data.IsEmpty();

        result.Should().BeTrue();
    }

    [Fact]
    public void IsEmptyMethod_Should_ReturnFalse_When_CollectionContainElement()
    {
        var data = Fixture.CreateMany<object>();

        var result = data.IsEmpty();

        result.Should().BeFalse();
    }

    [Theory, MemberData(nameof(CollectionHasUniqueElements))]
    public void ContainsDuplicatesMethod_Should_ReturnFalse_When_CollectionHasUniqueElements(List<string> collection)
    {
        var result = collection.ContainsDuplicates();

        result.Should().BeFalse();
    }

    [Theory, MemberData(nameof(CollectionNotHasUniqueElements))]
    public void ContainsDuplicatesMethod_Should_ReturnTrue_When_CollectionNotHasUniqueElements(List<string> collection)
    {
        var result = collection.ContainsDuplicates();

        result.Should().BeTrue();
    }

    [Fact]
    public void EmptyIfNullMethod_Should_CreateEmptyCollection_If_CollectionIsNull()
    {
        int[]? collection = null;

        var result = collection.EmptyIfNull();

        result.Should().BeEquivalentTo(Enumerable.Empty<int>());
    }

    [Fact]
    public void EmptyIfNullMethod_Should_ReturnUnmodifiedCollection_If_CollectionIsNotNull()
    {
        var collection = Fixture.CreateMany<int>().ToArray();

        var result = collection.EmptyIfNull();

        result.Should().BeEquivalentTo(collection);
    }

    public static TheoryData<List<string>> CollectionHasUniqueElements() =>
    [
        ["two"],
        ["two", "three", "one1"],
        []
    ];

    public static TheoryData<List<string>> CollectionNotHasUniqueElements() =>
        [["two", "two"]];
}