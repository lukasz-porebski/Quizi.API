using Domain.Modules.Roles.Models;
using Domain.Modules.Users.Models;
using LP.Common.Identity.EF.Extensions;
using LP.Common.Infrastructure.Database.EF.Configurations;
using LP.Common.Infrastructure.Database.EF.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.Users.Configurations;

public class UserRoleConfiguration() : BaseEntityCoreConfiguration<UserRole>(nameof(UserRole.RoleId))
{
    public override void Configure(EntityTypeBuilder<UserRole> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.RoleId)!
            .ConfigureAggregateId();

        builder.ConfigureOneToMany<UserRole, Role>(e => e.RoleId);
    }
}