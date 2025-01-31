using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Questions.Update;

public record QuizMultipleChoiceQuestionUpdateData(
    EntityNo? EntityNo,
    int OrderNumber,
    string Text,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> CorrectAnswers,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> WrongAnswers
) : IQuizQuestionUpdateData;