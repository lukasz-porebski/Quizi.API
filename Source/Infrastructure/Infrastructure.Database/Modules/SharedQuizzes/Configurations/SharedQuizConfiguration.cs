using Common.Infrastructure.Database.EF.Configurations;
using Common.Infrastructure.Database.EF.Extensions;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.SharedQuizzes.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.SharedQuizzes.Configurations;

public class SharedQuizConfiguration : BaseAggregateRootConfiguration<SharedQuiz>
{
    public override void Configure(EntityTypeBuilder<SharedQuiz> builder)
    {
        base.Configure(builder);

        builder.HasIndex(e => e.QuizId).IsUnique();

        builder.ConfigureOneToMany<SharedQuiz, Quiz>(e => e.QuizId);

        builder.ConfigureEntities(e => e.Users);
    }
}