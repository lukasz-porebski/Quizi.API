using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Models.Questions.Update;

public record QuizOpenQuestionUpdateData(
    EntityNo? EntityNo,
    int OrderNumber,
    string Text,
    string CorrectAnswer
) : IQuizQuestionUpdateData;