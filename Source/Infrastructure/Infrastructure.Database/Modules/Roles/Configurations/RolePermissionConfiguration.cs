using Common.Identity.EF.Extensions;
using Common.Infrastructure.Database.EF.Configurations;
using Common.Infrastructure.Database.EF.Extensions;
using Domain.Modules.Permissions.Models;
using Domain.Modules.Roles.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.Roles.Configurations;

public class RolePermissionConfiguration() : BaseEntityCoreConfiguration<RolePermission>(nameof(RolePermission.PermissionId))
{
    public override void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.PermissionId)!
            .ConfigureAggregateId();

        builder.ConfigureOneToMany<RolePermission, Permission>(e => e.PermissionId);
    }
}