using Common.Domain.Entities;

namespace Common.Infrastructure.Database.EF.Configurations;

public abstract class BaseSubEntityConfiguration<TEntity>()
    : BaseEntityCoreConfiguration<TEntity>(nameof(BaseEntity.No), nameof(BaseSubEntity.SubNo))
    where TEntity : BaseSubEntity;