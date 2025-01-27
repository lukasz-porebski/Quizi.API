using System.Linq.Expressions;
using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Infrastructure.Database.EF.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static PropertyBuilder<AggregateId> ConfigureAggregateRootId<T>(this EntityTypeBuilder<T> builder)
        where T : class =>
        builder.ConfigureAggregateId(nameof(BaseAggregateRoot.Id))
            .HasColumnName(nameof(BaseAggregateRoot.Id))
            .ValueGeneratedNever()!;

    public static PropertyBuilder<AggregateId?> ConfigureAggregateId<T>(
        this EntityTypeBuilder<T> source, Expression<Func<T, AggregateId?>> expression)
        where T : class =>
        source.Property(expression).ConfigureAggregateId();

    public static PropertyBuilder<AggregateId?> ConfigureAggregateId<T>(this EntityTypeBuilder<T> source, string columnName)
        where T : class =>
        source.Property<AggregateId?>(columnName).ConfigureAggregateId();

    public static PropertyBuilder<EntityNo> ConfigureEntityNo<T>(
        this EntityTypeBuilder<T> source, Expression<Func<T, EntityNo>> expression)
        where T : class =>
        source.Property(expression).HasConversion(v => v.ToInt(), v => new EntityNo(v));

    public static EntityTypeBuilder<T> ConfigureAggregateStateChangeInfo<T>(
        this EntityTypeBuilder<T> source, Expression<Func<T, AggregateStateChangeInfo?>> expression, string prefix)
        where T : class =>
        source.OwnsOne(
            expression,
            o =>
            {
                o.Property(p => p.UserId).ConfigureAggregateId().HasColumnName($"{prefix}ByUserId");

                const string ownerIdColumnName = "OwnerId";
                o.Property<AggregateId>(ownerIdColumnName);
                o.HasKey(ownerIdColumnName);
                o.WithOwner().HasForeignKey(ownerIdColumnName);

                o.Property(p => p.At).HasColumnName($"{prefix}At");
            });

    public static PropertyBuilder<AggregateId?> ConfigureAggregateId(this PropertyBuilder<AggregateId?> source) =>
        source.HasConversion(v => v != null ? v.ToString() : null, v => v != null ? new AggregateId(v) : null)
            .HasMaxLength(36);

    public static void ConfigureChildren<T, TChild>(
        this EntityTypeBuilder<T> builder, Expression<Func<T, IEnumerable<TChild>>> navigationExpression)
        where T : BaseAggregateRoot
        where TChild : BaseEntityCore =>
        builder.HasMany(navigationExpression!).WithOne().HasForeignKey(nameof(BaseAggregateRoot.Id)).HasPrincipalKey(e => e.Id);

    public static void ConfigureOneToMany<TOne, TMany>(
        this EntityTypeBuilder<TOne> builder, Expression<Func<TOne, object?>> foreignKeyExpression)
        where TOne : class
        where TMany : class =>
        builder.HasOne<TMany>().WithMany().HasForeignKey(foreignKeyExpression);
}