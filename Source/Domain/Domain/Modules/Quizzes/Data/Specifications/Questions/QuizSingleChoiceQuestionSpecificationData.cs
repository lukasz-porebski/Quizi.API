using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

public record QuizSingleChoiceQuestionSpecificationData(
    int OrderNumber,
    string Text,
    QuizQuestionOrderedAnswer CorrectAnswer,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> WrongAnswers
) : IQuizQuestionBaseSpecificationData;