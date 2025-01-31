using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Models.Questions.Create;

public record QuizClosedQuestionAnswerCreateData(
    int OrderNumber,
    string Text,
    bool IsCorrect
) : IQuizClosedQuestionAnswer;