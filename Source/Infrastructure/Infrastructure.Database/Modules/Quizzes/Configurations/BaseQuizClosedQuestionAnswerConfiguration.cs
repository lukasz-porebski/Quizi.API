using Common.Infrastructure.Database.EF.Configurations;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Models.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Modules.Quizzes.Configurations;

public abstract class BaseQuizClosedQuestionAnswerConfiguration<TEntity> : BaseSubEntityConfiguration<TEntity>
    where TEntity : BaseQuizClosedQuestionAnswer
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Text)
            .HasMaxLength(QuizConstants.MaxQuestionTextLength);
    }
}