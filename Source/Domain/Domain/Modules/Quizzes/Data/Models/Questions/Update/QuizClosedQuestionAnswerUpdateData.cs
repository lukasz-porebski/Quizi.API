using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Models.Questions.Update;

public record QuizClosedQuestionAnswerUpdateData(
    EntityNo? SubNo,
    int OrderNumber,
    string Text,
    bool IsCorrect
) : IQuizClosedQuestionAnswer;