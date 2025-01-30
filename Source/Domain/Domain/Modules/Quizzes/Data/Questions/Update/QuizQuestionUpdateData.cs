using Common.Domain.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Questions.Update;

public abstract class QuizQuestionUpdateData : QuizQuestionData
{
    public EntityNo? EntityNo { get; }

    protected QuizQuestionUpdateData(EntityNo? entityNo, int orderNumber, string text)
        : base(orderNumber, text)
    {
        EntityNo = entityNo;
    }
}