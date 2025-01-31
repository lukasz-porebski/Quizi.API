using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Questions.Update;

public record QuizOpenEndedQuestionUpdateData(
    EntityNo? EntityNo,
    int OrderNumber,
    string Text,
    string CorrectAnswer
) : IQuizQuestionUpdateData;