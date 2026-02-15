using Common.Infrastructure.Database.EF.Configurations;
using Common.Infrastructure.Database.EF.Extensions;
using Domain.Modules.Roles.Constants;
using Domain.Modules.Roles.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.Roles.Configurations;

public class RoleConfiguration : BaseAggregateRootConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);

        builder.HasIndex(u => u.Name).IsUnique();

        builder.Property(u => u.Name)
            .HasMaxLength(RoleConstants.MaxNameLength);

        builder.ConfigureEntities(e => e.Permissions);
    }
}