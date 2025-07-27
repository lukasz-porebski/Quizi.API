using Common.Domain.Entities;
using Common.Infrastructure.Database.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Infrastructure.Database.EF.Configurations;

public abstract class BaseAggregateRootConfiguration<TAggregateRoot> : IEntityTypeConfiguration<TAggregateRoot>
    where TAggregateRoot : BaseAggregateRoot
{
    public virtual void Configure(EntityTypeBuilder<TAggregateRoot> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ConfigureAggregateRootId();

        builder.ConfigureAggregateStateChangeInfo(e => e.CreationInto, "Created");
        builder.ConfigureAggregateStateChangeInfo(e => e.UpdateInfo, "Update");
        builder.ConfigureAggregateStateChangeInfo(e => e.RemovalInfo, "Removed");

        builder.Property(e => e.Version)
            .IsRequired()
            .IsConcurrencyToken();
    }
}