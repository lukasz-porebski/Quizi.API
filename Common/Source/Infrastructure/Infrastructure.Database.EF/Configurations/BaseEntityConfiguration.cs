using Common.Domain.Entities;

namespace Common.Infrastructure.Database.EF.Configurations;

public abstract class BaseEntityConfiguration<TEntity>() : BaseEntityCoreConfiguration<TEntity>(nameof(BaseEntity.No))
    where TEntity : BaseEntity;