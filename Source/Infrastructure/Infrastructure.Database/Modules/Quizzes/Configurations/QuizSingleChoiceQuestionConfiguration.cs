using Common.Infrastructure.Database.EF.Configurations;
using Common.Infrastructure.Database.EF.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.Quizzes.Configurations;

public class QuizSingleChoiceQuestionConfiguration : BaseEntityConfiguration<QuizSingleChoiceQuestion>
{
    public override void Configure(EntityTypeBuilder<QuizSingleChoiceQuestion> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Text)
            .HasMaxLength(QuizConstants.MaxQuestionTextLength);

        builder.ConfigureSubEntities(e => e.Answers);
    }
}