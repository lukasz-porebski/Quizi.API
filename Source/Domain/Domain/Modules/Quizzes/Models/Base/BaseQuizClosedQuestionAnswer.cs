using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Models.Base;

public class BaseQuizClosedQuestionAnswer : BaseSubEntity
{
    protected BaseQuizClosedQuestionAnswer(
        AggregateId id,
        EntityNo no,
        EntityNo subNo,
        QuizPersistClosedQuestionAnswerData data
    ) : base(id, no, subNo)
    {
        OrdinalNumber = data.OrdinalNumber;
        Text = data.Text;
        IsCorrect = data.IsCorrect;
    }

    protected BaseQuizClosedQuestionAnswer()
    {
    }

    public int OrdinalNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public bool IsCorrect { get; private set; }

    internal void Update(QuizPersistClosedQuestionAnswerData data)
    {
        OrdinalNumber = data.OrdinalNumber;
        Text = data.Text;
        IsCorrect = data.IsCorrect;
    }
}