using Common.Shared.Extensions;
using FluentAssertions;
using Xunit;

namespace Common.Shared.Tests.Extensions;

public class EnumExtensionsTests
{
    [Fact]
    public void ValueToStringMethod_Should_ReturnEnumIntValueAsString()
    {
        var result = TestEnum.Value1.ValueToString();

        result.Should().Be("1");
    }

    private enum TestEnum
    {
        Value1 = 1
    }
}