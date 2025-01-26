using System.Linq.Expressions;

namespace Common.Shared.Extensions;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> And<T>(
        this Expression<Func<T, bool>> source, Expression<Func<T, bool>> expression)
    {
        var param = source.Parameters[0];
        return Expression.Lambda<Func<T, bool>>(ReferenceEquals(param, expression.Parameters[0])
            ? Expression.AndAlso(source.Body, expression.Body)
            : Expression.AndAlso(source.Body, Expression.Invoke(expression, param)), param);
    }
}