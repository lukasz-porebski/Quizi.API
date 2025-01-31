using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Questions.Create;

public record QuizClosedQuestionAnswerCreateData(
    int OrderNumber,
    string Text,
    bool IsCorrect
) : IQuizClosedQuestionAnswer;