using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Questions.Create;

public record QuizMultipleChoiceQuestionCreateData(
    int OrderNumber,
    string Text,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> CorrectAnswers,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> WrongAnswers
) : IQuizQuestionData;