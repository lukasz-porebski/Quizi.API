using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Models;

public class QuizClosedQuestionAnswer : BaseEntity, IQuizClosedQuestionAnswer
{
    internal QuizClosedQuestionAnswer(
        AggregateId id,
        EntityNo no,
        EntityNo subNo,
        QuizClosedQuestionAnswerCreateData data
    ) : base(id, no)
    {
        SubNo = subNo;
        OrderNumber = data.OrderNumber;
        Text = data.Text;
        IsCorrect = data.IsCorrect;
    }

    private QuizClosedQuestionAnswer()
    {
    }

    public EntityNo SubNo { get; private set; } = null!;
    public int OrderNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public bool IsCorrect { get; private set; }
}