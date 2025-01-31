using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Models.Questions.Create;

public record QuizOpenQuestionCreateData(
    int OrderNumber,
    string Text,
    string CorrectAnswer
) : IQuizQuestionData;