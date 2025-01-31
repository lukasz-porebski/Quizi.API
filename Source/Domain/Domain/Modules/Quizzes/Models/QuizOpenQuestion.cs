using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Data.Questions.Update;

namespace Domain.Modules.Quizzes.Models;

public class QuizOpenQuestion : BaseEntity
{
    internal QuizOpenQuestion(AggregateId id, EntityNo no, QuizOpenQuestionCreateData data) : base(id, no)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;
        CorrectAnswer = data.CorrectAnswer;
    }

    private QuizOpenQuestion()
    {
    }

    public int OrderNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public string CorrectAnswer { get; private set; } = null!;

    internal void Update(QuizOpenQuestionUpdateData data)
    {
        if (OrderNumber.Equals(data.OrderNumber)
            && Text.Equals(data.Text)
            && CorrectAnswer.Equals(data.CorrectAnswer))
            return;

        CorrectAnswer = data.CorrectAnswer;
    }
}