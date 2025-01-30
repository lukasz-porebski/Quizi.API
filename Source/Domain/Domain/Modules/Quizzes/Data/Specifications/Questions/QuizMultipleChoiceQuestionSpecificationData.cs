using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

internal record QuizMultipleChoiceQuestionSpecificationData(
    int OrderNumber,
    string Text,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> CorrectAnswers,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> WrongAnswers
) : QuizQuestionBaseSpecificationData(OrderNumber, Text);