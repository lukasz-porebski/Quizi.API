using Domain.Modules.Quizzes.Extensions;

namespace Domain.Modules.Quizzes.Data.Questions.Create;

public record QuizOpenEndedQuestionCreateData(int OrderNumber, string Text, string CorrectAnswer)
    : QuizQuestionData(OrderNumber, Text)
{
    public string CorrectAnswer { get; } = CorrectAnswer.RemoveIllegalWhiteSpaces();
}