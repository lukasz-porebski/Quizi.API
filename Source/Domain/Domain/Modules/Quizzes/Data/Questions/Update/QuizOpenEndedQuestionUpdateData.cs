using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Extensions;

namespace Domain.Modules.Quizzes.Data.Questions.Update;

public record QuizOpenEndedQuestionUpdateData(
    EntityNo? EntityNo,
    int OrderNumber,
    string Text,
    string CorrectAnswer
) : QuizQuestionUpdateData(EntityNo, OrderNumber, Text)
{
    public string CorrectAnswer { get; } = CorrectAnswer.RemoveIllegalWhiteSpaces();
}