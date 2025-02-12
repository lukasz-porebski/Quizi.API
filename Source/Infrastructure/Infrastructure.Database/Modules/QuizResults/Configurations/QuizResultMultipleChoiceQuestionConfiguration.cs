using Common.Infrastructure.Database.EF.Configurations;
using Common.Infrastructure.Database.EF.Extensions;
using Domain.Modules.QuizResults.Models;
using Domain.Modules.Quizzes.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.QuizResults.Configurations;

public class QuizResultMultipleChoiceQuestionConfiguration : BaseEntityConfiguration<QuizResultMultipleChoiceQuestion>
{
    public override void Configure(EntityTypeBuilder<QuizResultMultipleChoiceQuestion> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Text)
            .HasMaxLength(QuizConstants.MaxQuestionTextLength);

        builder.ConfigureSubEntities(e => e.Answers);
    }
}