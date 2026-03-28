using Domain.Modules.Permissions.Constants;
using Domain.Modules.Permissions.Models;
using LP.Common.Infrastructure.Database.EF.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.Permissions.Configurations;

public class PermissionConfiguration : BaseAggregateRootConfiguration<Permission>
{
    public override void Configure(EntityTypeBuilder<Permission> builder)
    {
        base.Configure(builder);

        builder.HasIndex(u => u.Name).IsUnique();

        builder.Property(u => u.Name)
            .HasMaxLength(PermissionConstants.MaxNameLength);
    }
}