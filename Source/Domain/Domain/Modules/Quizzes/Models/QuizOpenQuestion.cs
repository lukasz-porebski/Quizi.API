using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.VerifyQuiz.ValueObjects;

namespace Domain.Modules.Quizzes.Models;

public class QuizOpenQuestion : BaseEntity, IQuizQuestionAnswer
{
    internal QuizOpenQuestion(AggregateId id, EntityNo no, QuizOpenQuestionPersistData data) : base(id, no)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;
        Answer = data.Answer;
    }

    private QuizOpenQuestion()
    {
    }

    public int OrderNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public string Answer { get; private set; } = null!;

    internal void Update(QuizOpenQuestionPersistData data)
    {
        if (OrderNumber.Equals(data.OrderNumber)
            && Text.Equals(data.Text)
            && Answer.Equals(data.Answer))
            return;

        Answer = data.Answer;
    }
}