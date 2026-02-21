using Common.Shared.Extensions;
using FluentAssertions;
using Xunit;

namespace Common.Shared.Tests.Extensions;

public class DateTimeExtensionsTests
{
    [Fact]
    public void ToTimestampMethod_Should_ReturnZero_For_UnixEpoch()
    {
        var result = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).ToTimestamp();

        result.Should().Be(0);
    }

    [Fact]
    public void ToTimestampMethod_Should_ReturnCorrectTimestamp()
    {
        var result = new DateTime(2024, 6, 15, 12, 30, 45, 123, DateTimeKind.Utc).ToTimestamp();

        result.Should().Be(1718454645123);
    }

    [Fact]
    public void ToTimestampMethod_Should_ReturnNegative_For_DateBeforeUnixEpoch()
    {
        var act = () => new DateTime(1969, 12, 31, 23, 59, 59, DateTimeKind.Utc).ToTimestamp();

        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}
