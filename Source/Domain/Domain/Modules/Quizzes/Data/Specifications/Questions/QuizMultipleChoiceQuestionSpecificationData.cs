using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

public record QuizMultipleChoiceQuestionSpecificationData(
    int OrderNumber,
    string Text,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> CorrectAnswers,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> WrongAnswers
) : IQuizQuestionBaseSpecificationData;