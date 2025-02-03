using Common.Infrastructure.Database.EF.Configurations;
using Common.Infrastructure.Database.EF.Extensions;
using Domain.Modules.SharedQuizzes.Models;
using Domain.Modules.Users.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.SharedQuizzes.Configurations;

public class SharedQuizConfiguration : BaseAggregateRootConfiguration<SharedQuiz>
{
    public override void Configure(EntityTypeBuilder<SharedQuiz> builder)
    {
        base.Configure(builder);

        builder.ConfigureOneToMany<SharedQuiz, User>(e => e.OwnerId);

        builder.ConfigureEntities(e => e.Users);
    }
}