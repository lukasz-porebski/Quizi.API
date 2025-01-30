using Common.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Identity.EF.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static PropertyBuilder<AggregateId?> ConfigureAggregateId(this PropertyBuilder<AggregateId?> source) =>
        source.HasConversion(v => v != null ? v.ToString() : null, v => v != null ? new AggregateId(v) : null)
            .HasMaxLength(36);
}