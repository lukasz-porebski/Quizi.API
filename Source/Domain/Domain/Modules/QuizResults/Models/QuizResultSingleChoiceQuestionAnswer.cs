using Domain.Modules.QuizResults.Data.Sub;
using LP.Common.Domain.Entities;
using LP.Common.Domain.ValueObjects;

namespace Domain.Modules.QuizResults.Models;

public class QuizResultSingleChoiceQuestionAnswer : BaseSubEntity
{
    internal QuizResultSingleChoiceQuestionAnswer(
        AggregateId id, EntityNo no, EntityNo subNo, QuizResultClosedQuestionAnswerCreateData data)
        : base(id, no, subNo)
    {
        OrdinalNumber = data.OrdinalNumber;
        Text = data.Text;
        IsCorrect = data.IsCorrect;
        IsSelected = data.IsSelected;
    }

    private QuizResultSingleChoiceQuestionAnswer()
    {
    }

    public int OrdinalNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public bool IsCorrect { get; private set; }
    public bool IsSelected { get; private set; }
}