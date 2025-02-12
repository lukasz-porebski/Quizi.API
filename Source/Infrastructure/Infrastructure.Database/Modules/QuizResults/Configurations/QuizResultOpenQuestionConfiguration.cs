using Common.Infrastructure.Database.EF.Configurations;
using Domain.Modules.QuizResults.Models;
using Domain.Modules.Quizzes.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.QuizResults.Configurations;

public class QuizResultOpenQuestionConfiguration : BaseEntityConfiguration<QuizResultOpenQuestion>
{
    public override void Configure(EntityTypeBuilder<QuizResultOpenQuestion> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Text)
            .HasMaxLength(QuizConstants.MaxQuestionTextLength);

        builder.Property(e => e.CorrectAnswer)
            .HasMaxLength(QuizConstants.MaxQuestionAnswerTextLength);

        builder.Property(e => e.GivenAnswer)
            .HasMaxLength(QuizConstants.MaxQuestionAnswerTextLength);
    }
}