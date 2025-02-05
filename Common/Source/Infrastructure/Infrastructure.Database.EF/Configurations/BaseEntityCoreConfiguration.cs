using Common.Domain.Entities;
using Common.Infrastructure.Database.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoreLinq;

namespace Common.Infrastructure.Database.EF.Configurations;

public abstract class BaseEntityCoreConfiguration<TEntity>(params string[] entityKeys) : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntityCore
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var keys = new List<string>([nameof(BaseAggregateRoot.Id)]);
        keys.AddRange(entityKeys);

        builder.HasKey(keys.ToArray());

        builder.ConfigureAggregateRootId();
        entityKeys.ForEach(k => builder.ConfigureEntityNo(k));
    }
}