using Domain.Modules.Quizzes.Extensions;

namespace Domain.Modules.Quizzes.Data.Questions.Create;

public class QuizOpenEndedQuestionCreateData : QuizQuestionData
{
    public string CorrectAnswer { get; }

    public QuizOpenEndedQuestionCreateData(int orderNumber, string text, string correctAnswer)
        : base(orderNumber, text)
    {
        CorrectAnswer = correctAnswer.RemoveIllegalWhiteSpaces();
    }
}