using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.VerifyQuiz.ValueObjects;

namespace Domain.Modules.Quizzes.Models.Base;

public class BaseQuizClosedQuestionAnswer : BaseSubEntity, IQuizQuestionAnswer
{
    protected BaseQuizClosedQuestionAnswer(
        AggregateId id,
        EntityNo no,
        EntityNo subNo,
        QuizClosedQuestionAnswerPersistData data
    ) : base(id, no, subNo)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;
        IsCorrect = data.IsCorrect;
    }

    protected BaseQuizClosedQuestionAnswer()
    {
    }

    public int OrderNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public bool IsCorrect { get; private set; }

    internal void Update(QuizClosedQuestionAnswerPersistData data)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;
        IsCorrect = data.IsCorrect;
    }
}