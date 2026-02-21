using Common.Domain.ValueObjects;
using Common.TestsCore;
using FluentAssertions;
using Xunit;

namespace Common.Domain.Tests.ValueObjects;

public class DateTimePeriodTests : BaseTest
{
    private static readonly DateTime FixedNow = new(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Constructor_Should_SetStartAndEnd_When_StartIsEarlierThanEnd()
    {
        var start = FixedNow;
        var end = start.AddHours(1);

        var period = new DateTimePeriod(start, end);

        period.Start.Should().Be(start);
        period.End.Should().Be(end);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    public void Constructor_Should_ThrowArgumentOutOfRange_When_StartIsNotEarlierThanEnd(
        int startOffsetHours, int endOffsetHours)
    {
        var now = FixedNow;
        var start = now.AddHours(startOffsetHours);
        var end = now.AddHours(endOffsetHours);

        Action act = () => _ = new DateTimePeriod(start, end);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}