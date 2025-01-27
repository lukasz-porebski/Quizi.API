using Common.Infrastructure.Database.EF.Configurations;
using Domain.Modules.Users.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.Users.Configurations;

public class UserConfiguration : BaseAggregateRootConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.Email)
            .HasMaxLength(320);

        builder.Property(u => u.HashedPassword)
            .HasMaxLength(150);
    }
}