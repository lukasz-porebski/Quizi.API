using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Data.Questions.Update;

namespace Domain.Modules.Quizzes.Models;

public class OpenEndedQuestion : BaseQuizQuestion
{
    internal OpenEndedQuestion(AggregateId id, EntityNo no, QuizOpenEndedQuestionCreateData data)
        : base(id, no, data)
    {
        CorrectAnswer = data.CorrectAnswer;
    }

    private OpenEndedQuestion()
    {
    }

    public string CorrectAnswer { get; private set; } = null!;

    internal void Update(QuizOpenEndedQuestionUpdateData data)
    {
        if (OrderNumber.Equals(data.OrderNumber)
            && Text.Equals(data.Text)
            && CorrectAnswer.Equals(data.CorrectAnswer))
            return;

        base.Update(data);
        CorrectAnswer = data.CorrectAnswer;
    }
}