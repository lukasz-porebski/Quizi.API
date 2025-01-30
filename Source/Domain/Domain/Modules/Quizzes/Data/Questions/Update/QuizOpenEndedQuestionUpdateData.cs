using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Extensions;

namespace Domain.Modules.Quizzes.Data.Questions.Update;

public class QuizOpenEndedQuestionUpdateData : QuizQuestionUpdateData
{
    public string CorrectAnswer { get; }

    public QuizOpenEndedQuestionUpdateData(EntityNo? entityNo, int orderNumber,
        string text, string correctAnswer)
        : base(entityNo, orderNumber, text)
    {
        CorrectAnswer = correctAnswer.RemoveIllegalWhiteSpaces();
    }
}