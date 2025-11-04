using Common.Infrastructure.Database.EF.Configurations;
using Common.Infrastructure.Database.EF.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.Quizzes.ValueObjects;
using Domain.Modules.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.Quizzes.Configurations;

public class QuizConfiguration : BaseAggregateRootConfiguration<Quiz>
{
    public override void Configure(EntityTypeBuilder<Quiz> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.Title)
            .HasMaxLength(QuizConstants.MaxTitleLength);

        builder.Property(u => u.Description)
            .HasMaxLength(QuizConstants.MaxDescriptionLength);

        builder.OwnsOne(
            e => e.Settings,
            o =>
            {
                o.Property(p => p.Duration)
                    .HasColumnName(nameof(QuizSettings.Duration).ToLowerInvariant());
                o.Property(p => p.QuestionsCountInRunningQuiz)
                    .HasColumnName(nameof(QuizSettings.QuestionsCountInRunningQuiz).ToLowerInvariant());
                o.Property(p => p.RandomQuestions)
                    .HasColumnName(nameof(QuizSettings.RandomQuestions).ToLowerInvariant());
                o.Property(p => p.RandomAnswers)
                    .HasColumnName(nameof(QuizSettings.RandomAnswers).ToLowerInvariant());
                o.Property(p => p.NegativePoints)
                    .HasColumnName(nameof(QuizSettings.NegativePoints).ToLowerInvariant());
                o.Property(p => p.CopyMode)
                    .HasColumnName(nameof(QuizSettings.CopyMode).ToLowerInvariant());
            });

        builder.ConfigureOneToMany<Quiz, User>(e => e.OwnerId);

        builder.ConfigureEntities(e => e.OpenQuestions);
        builder.ConfigureEntities(e => e.SingleChoiceQuestions);
        builder.ConfigureEntities(e => e.MultipleChoiceQuestions);
    }
}