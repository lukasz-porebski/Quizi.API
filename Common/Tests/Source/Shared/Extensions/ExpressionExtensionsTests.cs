using System.Linq.Expressions;
using Common.Shared.Extensions;
using FluentAssertions;
using Xunit;

namespace Common.Shared.Tests.Extensions;

public class ExpressionExtensionsTests
{
    [Fact]
    public void AndMethod_Should_CombineExpressions_When_ParametersAreTheSameReference()
    {
        var param = Expression.Parameter(typeof(TestEntity), "e");
        var left = Expression.Lambda<Func<TestEntity, bool>>(
            Expression.GreaterThan(
                Expression.Property(param, nameof(TestEntity.Value)),
                Expression.Constant(10)),
            param);
        var right = Expression.Lambda<Func<TestEntity, bool>>(
            Expression.LessThan(
                Expression.Property(param, nameof(TestEntity.Value)),
                Expression.Constant(20)),
            param);

        var result = left.And(right);

        result.Body.Should().BeAssignableTo<BinaryExpression>();
        ((BinaryExpression)result.Body).NodeType.Should().Be(ExpressionType.AndAlso);
        AssertCombined(result.Compile());
    }

    [Fact]
    public void AndMethod_Should_CombineExpressions_When_ParametersAreDifferentReferences()
    {
        Expression<Func<TestEntity, bool>> left = e => e.Value > 10;
        Expression<Func<TestEntity, bool>> right = e => e.Value < 20;

        var result = left.And(right);

        result.Body.Should().BeAssignableTo<BinaryExpression>();
        ((BinaryExpression)result.Body).Right.Should().BeAssignableTo<InvocationExpression>();
        AssertCombined(result.Compile());
    }

    private static void AssertCombined(Func<TestEntity, bool> combined)
    {
        combined(new TestEntity(15)).Should().BeTrue();
        combined(new TestEntity(9)).Should().BeFalse();
        combined(new TestEntity(25)).Should().BeFalse();
    }

    private record TestEntity(int Value);
}