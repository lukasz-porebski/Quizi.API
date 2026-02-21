using Common.Shared.Extensions;
using FluentAssertions;
using Xunit;

namespace Common.Shared.Tests.Extensions;

public class StringExtensionsTests
{
    [InlineData("", true)]
    [InlineData(null, true)]
    [InlineData("   ", true)]
    [InlineData("text", false)]
    [Theory]
    public void IsEmptyMethod_Should_ReturnCorrectResult(string? data, bool expectedResult)
    {
        var result = data.IsEmpty();

        result.Should().Be(expectedResult);
    }
}