using Common.Domain.Entities;
using Common.Infrastructure.Database.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Infrastructure.Database.EF.Configurations;

public abstract class BaseEntityCoreConfiguration<TEntity>(string entityKey) : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntityCore
{
    private readonly string _entityKey = entityKey;

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(nameof(BaseAggregateRoot.Id), _entityKey);

        builder.ConfigureAggregateRootId();
    }
}