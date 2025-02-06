using Common.Domain.Entities;
using Common.Infrastructure.Database.EF.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoreLinq;

namespace Common.Infrastructure.Database.EF.Configurations;

public abstract class BaseSubEntityConfiguration<TEntity>()
    : BaseEntityCoreConfiguration<TEntity>(nameof(BaseEntity.No), nameof(BaseSubEntity.SubNo))
    where TEntity : BaseSubEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        EntityKeys.ForEach(k => builder.ConfigureEntityNo(k));
    }
}