using Common.Domain.Entities;
using Common.Infrastructure.Database.EF.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Infrastructure.Database.EF.Configurations;

public abstract class BaseSubEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity>
    where TEntity : BaseSubEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.ConfigureEntityNo(e => e.SubNo);
    }
}