using Common.Identity.EF.Extensions;
using Common.Infrastructure.Database.EF.Configurations;
using Common.Infrastructure.Database.EF.Extensions;
using Domain.Modules.SharedQuizzes.Models;
using Domain.Modules.Users.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.SharedQuizzes.Configurations;

public class SharedQuizUserConfiguration() : BaseEntityCoreConfiguration<SharedQuizUser>(nameof(SharedQuizUser.UserId))
{
    public override void Configure(EntityTypeBuilder<SharedQuizUser> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.UserId)!
            .ConfigureAggregateId();

        builder.ConfigureOneToMany<SharedQuizUser, User>(e => e.UserId);
    }
}