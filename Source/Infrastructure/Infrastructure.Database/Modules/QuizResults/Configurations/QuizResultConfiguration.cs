using Common.Infrastructure.Database.EF.Configurations;
using Common.Infrastructure.Database.EF.Extensions;
using Domain.Modules.QuizResults.Models;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.Users.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.QuizResults.Configurations;

public class QuizResultConfiguration : BaseAggregateRootConfiguration<QuizResult>
{
    public override void Configure(EntityTypeBuilder<QuizResult> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Title)
            .HasMaxLength(QuizConstants.MaxTitleLength);

        builder.ConfigureDateTimePeriod(e => e.QuizRunningPeriod, "QuizRunning");

        builder.ConfigureOneToMany<QuizResult, Quiz>(e => e.QuizId);
        builder.ConfigureOneToMany<QuizResult, User>(e => e.UserId);

        builder.ConfigureEntities(e => e.OpenQuestions);
        builder.ConfigureEntities(e => e.SingleChoiceQuestions);
        builder.ConfigureEntities(e => e.MultipleChoiceQuestions);
    }
}