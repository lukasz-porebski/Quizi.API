using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Questions.Create;

public record QuizOpenEndedQuestionCreateData(
    int OrderNumber,
    string Text,
    string CorrectAnswer
) : IQuizQuestionData;