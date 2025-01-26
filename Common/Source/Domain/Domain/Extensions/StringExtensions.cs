using Common.Domain.ValueObjects;

namespace Common.Domain.Extensions;

public static class StringExtensions
{
    public static AggregateId ToAggregateId(this string source) =>
        new(source);
}