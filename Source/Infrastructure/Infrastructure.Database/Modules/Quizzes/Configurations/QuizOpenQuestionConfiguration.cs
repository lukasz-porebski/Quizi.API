using Common.Infrastructure.Database.EF.Configurations;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.Quizzes.Configurations;

public class QuizOpenQuestionConfiguration : BaseEntityConfiguration<QuizOpenQuestion>
{
    public override void Configure(EntityTypeBuilder<QuizOpenQuestion> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Text)
            .HasMaxLength(QuizConstants.MaxQuestionTextLength);

        builder.Property(e => e.Answer)
            .HasMaxLength(QuizConstants.MaxQuestionAnswerTextLength);
    }
}