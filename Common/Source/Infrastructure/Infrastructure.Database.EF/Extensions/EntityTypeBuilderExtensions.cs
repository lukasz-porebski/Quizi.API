using System.Linq.Expressions;
using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Common.Identity.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Infrastructure.Database.EF.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static PropertyBuilder<AggregateId> ConfigureAggregateRootId<T>(this EntityTypeBuilder<T> builder)
        where T : class =>
        builder.ConfigureAggregateId(nameof(BaseAggregateRoot.Id))
            .HasColumnName(nameof(BaseAggregateRoot.Id).ToLowerInvariant())
            .ValueGeneratedNever()!;

    public static PropertyBuilder<AggregateId?> ConfigureAggregateId<T>(
        this EntityTypeBuilder<T> source, Expression<Func<T, AggregateId?>> expression)
        where T : class =>
        source.Property(expression).ConfigureAggregateId();

    public static PropertyBuilder<AggregateId?> ConfigureAggregateId<T>(this EntityTypeBuilder<T> source, string columnName)
        where T : class =>
        source.Property<AggregateId?>(columnName).ConfigureAggregateId();

    public static PropertyBuilder<EntityNo> ConfigureEntityNo<T>(this EntityTypeBuilder<T> source, string columnName)
        where T : class =>
        source.Property<EntityNo>(columnName).ConfigureEntityNo();

    public static PropertyBuilder<EntityNo> ConfigureEntityNo<T>(
        this EntityTypeBuilder<T> source, Expression<Func<T, EntityNo>> expression)
        where T : class =>
        source.Property(expression).HasConversion(v => v.ToInt(), v => new EntityNo(v));

    public static PropertyBuilder<EntityNo> ConfigureEntityNo(this PropertyBuilder<EntityNo> source) =>
        source.HasConversion(v => v.ToInt(), v => new EntityNo(v));

    public static EntityTypeBuilder<T> ConfigureAggregateStateChangeInfo<T>(
        this EntityTypeBuilder<T> source, Expression<Func<T, AggregateStateChangeInfo?>> expression, string prefix)
        where T : class =>
        source.OwnsOne(
            expression,
            o =>
            {
                o.Property(p => p.UserId)
                    .ConfigureAggregateId()
                    .HasColumnName($"{prefix}ByUserId".ToLowerInvariant())
                    .IsRequired(false)
                    .HasDefaultValue(null);

                o.WithOwner()
                    .HasForeignKey(nameof(BaseAggregateRoot.Id));

                o.Property(p => p.At).HasColumnName($"{prefix}At".ToLowerInvariant());
            });

    public static EntityTypeBuilder<T> ConfigureDateTimePeriod<T>(
        this EntityTypeBuilder<T> source, Expression<Func<T, DateTimePeriod?>> expression, string? prefix = null)
        where T : class =>
        source.OwnsOne(
            expression,
            o =>
            {
                var namePrefix = prefix ?? "";
                o.Property(p => p.Start).HasColumnName($"{namePrefix}PeriodStart".ToLowerInvariant());
                o.Property(p => p.End).HasColumnName($"{namePrefix}PeriodEnd".ToLowerInvariant());

                o.WithOwner()
                    .HasForeignKey(nameof(BaseAggregateRoot.Id));
            });

    public static void ConfigureEntities<T, TChild>(
        this EntityTypeBuilder<T> builder, Expression<Func<T, IEnumerable<TChild>>> navigationExpression)
        where T : BaseAggregateRoot
        where TChild : BaseEntityCore =>
        builder.HasMany(navigationExpression!)
            .WithOne()
            .HasForeignKey(nameof(BaseAggregateRoot.Id))
            .HasPrincipalKey(nameof(BaseAggregateRoot.Id));

    public static void ConfigureSubEntities<T, TChild>(
        this EntityTypeBuilder<T> builder, Expression<Func<T, IEnumerable<TChild>>> navigationExpression)
        where T : BaseEntity
        where TChild : BaseSubEntity =>
        builder.HasMany(navigationExpression!)
            .WithOne()
            .HasForeignKey(nameof(BaseAggregateRoot.Id), nameof(BaseEntity.No))
            .HasPrincipalKey(nameof(BaseAggregateRoot.Id), nameof(BaseEntity.No));

    public static void ConfigureOneToMany<TOne, TMany>(
        this EntityTypeBuilder<TOne> builder, Expression<Func<TOne, object?>> foreignKeyExpression)
        where TOne : class
        where TMany : class =>
        builder.HasOne<TMany>().WithMany().HasForeignKey(foreignKeyExpression).OnDelete(DeleteBehavior.Restrict);
}