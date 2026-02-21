using Common.Domain.Extensions;
using Common.TestsCore;
using FluentAssertions;
using Xunit;

namespace Common.Domain.Tests.Extensions;

public class StringExtensionsTests : BaseTest
{
    [Fact]
    public void ToAggregateId_Should_ReturnSameGuid_When_SourceIsValidGuidString()
    {
        var guid = Guid.NewGuid();
        var source = guid.ToString();

        var result = source.ToAggregateId();

        result.ToGuid().Should().Be(guid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("text")]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public void ToAggregateId_Should_ThrowException_When_SourceIsInvalidString(string invalid)
    {
        Action act = () => invalid.ToAggregateId();

        act.Should().Throw<Exception>();
    }
}