using Common.Infrastructure.Database.EF.Configurations;
using Domain.Modules.QuizResults.Models;
using Domain.Modules.Quizzes.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.QuizResults.Configurations;

public class QuizResultMultipleChoiceQuestionAnswerConfiguration : BaseSubEntityConfiguration<QuizResultMultipleChoiceQuestionAnswer>
{
    public override void Configure(EntityTypeBuilder<QuizResultMultipleChoiceQuestionAnswer> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Text)
            .HasMaxLength(QuizConstants.MaxQuestionTextLength);
    }
}