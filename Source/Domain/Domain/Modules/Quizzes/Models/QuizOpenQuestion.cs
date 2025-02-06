using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Models;

public class QuizOpenQuestion : BaseEntity
{
    internal QuizOpenQuestion(AggregateId id, EntityNo no, QuizOpenQuestionPersistData data) : base(id, no)
    {
        OrdinalNumber = data.OrdinalNumber;
        Text = data.Text;
        Answer = data.Answer;
    }

    private QuizOpenQuestion()
    {
    }

    public int OrdinalNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public string Answer { get; private set; } = null!;

    internal void Update(QuizOpenQuestionPersistData data)
    {
        if (OrdinalNumber.Equals(data.OrdinalNumber)
            && Text.Equals(data.Text)
            && Answer.Equals(data.Answer))
            return;

        Answer = data.Answer;
    }
}