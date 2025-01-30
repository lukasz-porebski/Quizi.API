using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

internal record QuizSingleChoiceQuestionSpecificationData(
    int OrderNumber,
    string Text,
    QuizQuestionOrderedAnswer CorrectAnswer,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> WrongAnswers
) : QuizQuestionBaseSpecificationData(OrderNumber, Text);